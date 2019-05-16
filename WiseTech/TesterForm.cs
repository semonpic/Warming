using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiseTech.Log;

namespace WiseTech
{
	public partial class TesterForm : Form
	{
		public TesterForm()
		{
			InitializeComponent();
			Load += TesterForm_Load;
		}

		private void TesterForm_Load(object sender, EventArgs e)
		{
			Logger.Setup(true);
			
			//for (int j = 0; j < 4; j++)
			//{

			//	for (int i = 0; i < 10; i++)
			//	{
			//		Logger.Info("123test" + i);
			//	}
			//}

			//foreach (var item in Logger.Select("ATSCore",0,20))
			//{
			//	Console.WriteLine(item.LogData);
			//}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var sp = new SpinWait();
			var stopwatch = new Stopwatch();
			var t = 0;
			stopwatch.Reset();
			stopwatch.Start();
			SpinWait.SpinUntil(() => {
				return stopwatch.Elapsed >= TimeSpan.FromMilliseconds(2000); },1000);
//			while (t<200)
//			{
//				sp.SpinOnce();
////				SpinWait.SpinUntil(() => { return false; }, 1);
//				t++;
//				//Thread.Sleep(2000);
//				//break;
//			}
			stopwatch.Stop();
			Console.WriteLine(stopwatch.ElapsedMilliseconds);

			t = 0;
			stopwatch.Reset();
			stopwatch.Start();
			while (t<20)
			{
				Thread.Sleep(100);
				t++;
				//break;
			}
			stopwatch.Stop();
			Console.WriteLine(stopwatch.ElapsedMilliseconds);

		}

		private void button2_Click(object sender, EventArgs e)
		{

			var ALIGNMENT = "START ALIGNMENT SECTION:			SEL ALIGNCODE(PCS1)FCSCODE(PCS1) DATUM(PCS1) ORIGINSHIFT(OFF)(0.000000, 0.000000, 0.000000, 0.000000) FIDUCIALS(2)(2, AAI06790_D_)(4, AAI06790_D_) ALIGNMENTMETHOD(Automatic Run) FIXTUREALIGNMENT(OFF) REMEASURE(ON) USEALIGN(AAP00021_A_)			END ALIGNMENT SECTION:";
			
			var FIDUCIALS1Start = ALIGNMENT.IndexOf("FIDUCIALS(") + 16;
			var FIDUCIALSString = ALIGNMENT.Substring(FIDUCIALS1Start);
			var FIDUCIALS1end = FIDUCIALSString.IndexOf(")");
			var FIDUCIALS1 = ALIGNMENT.Substring(FIDUCIALS1Start, FIDUCIALS1end );
			Console.WriteLine(FIDUCIALS1);

			var FIDUCIALS2Start = FIDUCIALSString.IndexOf("(") + 4;
			FIDUCIALSString = FIDUCIALSString.Substring(FIDUCIALS2Start);
			var FIDUCIALS2end = FIDUCIALSString.IndexOf(")");
			var FIDUCIALS2 = FIDUCIALSString.Substring(0, FIDUCIALS2end );

			Console.WriteLine(FIDUCIALS2);




			var INSPECTION = "SEL RECT(-34.087491,144.341808,35.402848,136.390177) ALL() INSPECTION() ALGORITHM(AAI07206_A_G_PE807)  ALIGNCODE(PCS1)  FCSCODE(PCS1)  SELECTIONNAME(SelectionName1)";
			var ALGORITHMStart = INSPECTION.IndexOf("ALGORITHM(") + 10;
			var ALGORITHMString = INSPECTION.Substring(ALGORITHMStart);
			var ALGORITHMend = ALGORITHMString.IndexOf(")");
			var ALGORITHM = ALGORITHMString.Substring(0, ALGORITHMend);
			Console.WriteLine(ALGORITHM);
		}
	}
}
