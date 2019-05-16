using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Data;
using ATS.Events;
using DecaTech.GlobalTypes;
using DecaTech.SoapCommunication;

namespace ATS.Models
{
	
	public static class VmsMessager
	{
		public static string Host = "Messenger2";
		public static string Vms1 = "Messenger1";
		//public static string Host = "ATS1";
		//public static string Vms1 = "VMS1";
		public static string Vms2 = "VMS2";
		public static string ConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\decatech\\db\\Soap.mdb";
		

		public static event EventHandler<VmsReplyEventArgs> OnReply;
		public static event EventHandler<VmsRequestEventArgs> OnRequest;

		// Objects needed for connecting and sending messages
		private static SoapMessenger soapMessenger;
		private static SoapSubscription aubscription;

		//private VmsMessager()
		//{
		//	Initialize();
		//}
		public static void Initialize()
		{
			try
			{
				soapMessenger = new SoapMessenger();
				// Initialize the connection between client and host
				soapMessenger.Initialize(ConnectionString, Host);
				soapMessenger.AutoAddNewContact = true;
				soapMessenger.MultiThreadedReceiving = true;
				// Initialize things for opening the log that shows connections and messages sent and recieved
				soapMessenger.TraceJSON = true;
				soapMessenger.Trace.LogSettings.LogEnabled = true;
				soapMessenger.Trace.LogSettings.TraceCount = 200;
				soapMessenger.Trace.ShowTrace(); // show the log
				soapMessenger.AddContact(Vms1); // add our contact (View 1)
				//soapMessenger.AddContact(Vms2); // add our contact (View 2)

				// Set up our subscription object. Not entirely sure, but is seems to be for . 
				// The important part is setting up the ApiReciever, see private Boolean ApiReceiver(SoapAPI api)
				// It allows us to get replies back from the host. Also, we want to listen for those replies so
				// ListenIncoming should be true
				aubscription = new SoapSubscription();
				aubscription.ApiReceiver = new ReceiveApiDelegate(ApiReceiver);
				aubscription.ListenIncoming = true;
				aubscription.ListenOutgoing = false;
				aubscription.ListenExecutionRequest = false;
				aubscription.ListenExecuted = false;
				soapMessenger.Subscriptions.Add(aubscription);

				soapMessenger.Start();
			}
			catch (Exception ex)
			{
				//MessageBox.Show("Error: " + ex.ToString());
			}
		}
		// For recieving and sending replies to host as far as I can tell
		private static bool ApiReceiver(SoapAPI api)
		{
			try
			{
				// Based on what myApi.MessageType is
				switch (api.MessageType)
				{
					case MessageTypes.Request: // Did we recieve a request for a reply from the host?
						OnRequest?.Invoke(api, new VmsRequestEventArgs
						{
							Request = new VmsCommand(api)
						});

						break;
					case MessageTypes.Reply: // Did we recieve a reply from the host?
						OnReply?.Invoke(api, new VmsReplyEventArgs
						{
							Reply = new VmsCommand(api)
						});
						break;
					default:
						break;
				}
				return true;
			}
			catch (Exception ex)
			{
				//MessageBox.Show("Error: " + ex.ToString());
				return false;
			}
		}
		public static bool SendCommand(VmsCommand vmsCommand)
		{
			bool test = false;
			try
			{
				vmsCommand.MessageType = MessageTypes.Request; // request a reply from Messenger2
				soapMessenger.SetApiIdentity(vmsCommand);
				test = soapMessenger.SendApi(vmsCommand);
			}
			catch (Exception ex)
			{
				//MessageBox.Show("Error: " + ex.ToString());
			}
			//MessageBox.Show("test: " + test.ToString());
			return test;
		}
		public static void SendReply(SoapAPI api)
		{

			soapMessenger.SendApi(api);
			//MessageBox.Show("Reply sent to : " + api.SenderId + " - " + api.Name);
		}

		public static bool IsConnectedTo(string cantactId)
		{
			return soapMessenger.IsConnectedTo(cantactId);
		}
	}
}
