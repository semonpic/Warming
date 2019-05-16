using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace R100Test
{
    public partial class frmIrisOperator : Form
    {
        string userID = ""; //20181213 JackAdd
        string userName = "";


        public frmIrisOperator()
        {
            InitializeComponent();
            inicontrol();
        }


        private void frmIrisOperator_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                nResult = control.AbortCapture();
                nResult = control.Close();

            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteAppErrorLog(err);
            }
        }

        public void CheckUser(string UserID,string Username)
        {
            //inicontrol();
            userID = UserID;
            userName = Username;
            TBUserName.Text = Username;
            if (LoadEnrolledUserInfo(userID))
            {
                //cmdReEnroll.Visible = true;
               // cmdIdentify.Visible = true;
            }
            else
            {
                EnrollUser(userID.ToString(),Username,UserLevel);
            }
        }

        private void frmIrisOperator_Load(object sender, EventArgs e)
        {
            //CheckUser(userID,userName);
        }

        private void cmdReEnroll_Click(object sender, EventArgs e)
        {
            try
            {
                //this.cmdReEnroll.Visible = false;
                control.AbortCapture();
                EnrollUser(userID, userName,UserLevel);
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteAppErrorLog(err);
            }
        }

        private void cmdIdentify_Click(object sender, EventArgs e)
        {
            control.AbortCapture();
            Identify();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picRightEye_Click(object sender, EventArgs e)
        {

        }
    }
}