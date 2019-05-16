using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiseTech;
using ATS;
using System.Text.RegularExpressions;
using ATS.Models;

namespace ATS.UI.CST.Controls
{
    public partial class SystemSetting : UserControl
    {
        List<TextBox> TBList = new List<TextBox>();
        List<ComboBox> CBLsit = new List<ComboBox>();
     

        public SystemSetting()
        {
            InitializeComponent();

            Language.Bind("SystemSetting.LabelWarmSetting", LabelWarmSetting);
            Language.Bind("SystemSetting.LabelWeightSetting", LabelWeightSetting);
            Language.Bind("SystemSetting.labelMachingValue", labelMachingValue);
            Language.Bind("SystemSetting.labelColdWarmSetting", labelColdWarmSetting);

            Language.Bind("SystemSetting.labelWarmTime", labelWarmTime);
            Language.Bind("SystemSetting.labelNormal", labelNormal);
            Language.Bind("SystemSetting.labelExpired1st", labelExpired1st);
            Language.Bind("SystemSetting.labelExpired2rd", labelExpired2rd);
            Language.Bind("SystemSetting.labelResinWeight", labelResinWeight);
            Language.Bind("SystemSetting.labelCurrentWeight", labelCurrentWeight);
            Language.Bind("SystemSetting.labelTotalWeight", labelTotalWeight);
            Language.Bind("SystemSetting.labelEmptyWeight", labelEmptyWeight);
            Language.Bind("SystemSetting.labelUseWeightCheck", labelUseWeightCheck);
            Language.Bind("SystemSetting.labelColdTempSetting", labelColdTempSetting);
            Language.Bind("SystemSetting.labelWarmTempSetting", labelWarmTempSetting);
            Language.Bind("SystemSetting.lbSetting", LbSetting);
            Language.Bind("SystemSetting.LabelWSetting", LabelWSetting);
            Language.Bind("SystemSetting.labeLifting", labeLifting);
            Language.Bind("SystemSetting.labelTransfer", labelTransfer);
            Language.Bind("SystemSetting.labelDelayTime", labelDelayTime);
            Language.Bind("SystemSetting.labelShockTime", labelShockTime);
            Language.Bind("SystemSetting.labelUseTempCheck", labelUseTempCheck);
            Language.Bind("SystemSetting.labelLiftingSpeedTitle", labelLiftingSpeedTitle);
            Language.Bind("SystemSetting.labelTransferSpeedTitle", labelTransferSpeedTitle);
            Language.Bind("SystemSetting.labelDelayTimeTitle", labelDelayTimeTitle);
            Language.Bind("SystemSetting.labelShockTimeTitle", labelShockTimeTitle);
            Language.Bind("SystemSetting.textBoxHelp", textBoxHelp);




            Language.SetText("SystemSetting.Open", "Open", "啟用");
            Language.SetText("SystemSetting.Close", "Close", "關閉");
            Language.SetText("SystemSetting.SaveSuccess", "Save Setting Success", "設定儲存成功");

            if (AppData.IsRuntime)
            {
                Load += SystemSetting_Load;
            }
            MainTabsPanel.RefreshEvent += RefreshEvent;
            PLCconnect.ReadSystemStatus.BottleWeightEvent += new Action<string>(BottleWeightEvent);
        }

        public void SystemSetting_Load(object sender, EventArgs e)
        {
            InitControlText();
            IniControlList(this);
            
        }


        public void InitControlText()
        {
            TbWarmTime.Text = SystemConfig.WarmTime;
            TbWarmExpired1.Text = SystemConfig.WarmOutTime1;
            TbWarmExpired2.Text = SystemConfig.WarmOutTime2;

            TbWeightULimit.Text = SystemConfig.WeightUpLimit;
            TbWeightDLimit.Text = SystemConfig.WeightDownLimit;
            CBUseWeight.Text = SystemConfig.WeightCheck == "1" ? Language.Text("SystemSetting.Open") : Language.Text("SystemSetting.Close");
            TbUpDownValues.Text = SystemConfig.UpDownValues;
            TbTransferValues.Text = SystemConfig.TransferValues;
            TbDelayTime.Text = SystemConfig.DelayTime;
            TbShakeTime.Text = SystemConfig.ShakeTime;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (IsNotEmpty(TbWarmTime)&& IsNumber(TbWarmTime.Text) && IsNotEmpty(TbWarmExpired1) && IsNumber(TbWarmExpired1.Text) && IsNotEmpty(TbWarmExpired2) && IsNumber(TbWarmExpired2.Text)
                && IsNotEmpty(TbWeightULimit) && IsNumber(TbWeightULimit.Text) && IsNotEmpty(TbWeightDLimit) && IsNumber(TbWeightDLimit.Text) && IsNotEmpty(CBUseWeight) && IsNumber(TbUpDownValues.Text)
                && IsNumber(TbTransferValues.Text) && IsNotEmpty(TbColdSettingTemp) && IsNumber(TbColdSettingTemp.Text) && IsNotEmpty(TbWarmSettingTemp) && IsNumber(TbWarmSettingTemp.Text) && IsNotEmpty(TbDelayTime) && IsNumber(TbDelayTime.Text))
            {
                if (UserData.Instance.Now.Power > 4)
                {
                    SystemConfig SC = new SystemConfig();
                    SC.SaveIniFile(TbWarmTime.Text, TbWarmExpired1.Text, TbWarmExpired2.Text, TbWeightULimit.Text, TbWeightDLimit.Text,
                        CBUseWeight.Text, TbUpDownValues.Text, TbTransferValues.Text, TbColdSettingTemp.Text, TbWarmSettingTemp.Text, CBTempCheck.Text,TbDelayTime.Text,TbShakeTime.Text);
                    PLCconnect.WriteSystem.WriteMachineValues(TbUpDownValues.Text, TbTransferValues.Text,TbDelayTime.Text);
                    MessageBox.Show(Language.Text("SystemSetting.SaveSuccess"), "設定提醒", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    MessageBox.Show("目前使用者權限過低，請切換使用者已進行設定變更(權限大於4)", "權限提醒", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("輸入資料不正確,參數不能為空或輸入不為數字,請確認後重試", "錯誤提醒", MessageBoxButtons.OK);
                return;
            }
        }


        private bool IsNotEmpty(Control Tb)
        {
            return Tb.Text != ""; 
        }

       
        private bool IsNumber(String strNumber)
        {
            Regex NumberPattern = new Regex("[^0-9.-]");
            return !NumberPattern.IsMatch(strNumber);
        }


        private void RefreshEvent()
        {
            TbWarmTime.Text = SystemConfig.WarmTime;
            TbWarmExpired1.Text = SystemConfig.WarmOutTime1;
            TbWarmExpired2.Text = SystemConfig.WarmOutTime2;

            TbWeightULimit.Text = SystemConfig.WeightUpLimit;
            TbWeightDLimit.Text = SystemConfig.WeightDownLimit;
            CBUseWeight.Text = SystemConfig.WeightCheck == "1" ? Language.Text("SystemSetting.Open") : Language.Text("SystemSetting.Close");

            TbUpDownValues.Text = SystemConfig.UpDownValues;
            TbTransferValues.Text = SystemConfig.TransferValues;
            TbDelayTime.Text = SystemConfig.DelayTime;

            TbColdSettingTemp.Text = SystemConfig.ColdSettingTemp;
            TbWarmSettingTemp.Text = SystemConfig.WarmSettingTemp;
            CBTempCheck.Text = SystemConfig.TempCheck == "1" ? Language.Text("SystemSetting.Open") : Language.Text("SystemSetting.Close");

        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            RefreshEvent();
        }

        private void BottleWeightEvent(string NowWeight)
        {
            WiseTech.ThreadSafeHelper.UIThread(this, () =>
                {
                    TBNowWerght.Text = NowWeight;
                });
        }

        private void IniControlList(Control MainControl)
        {


            foreach (Control Col in MainControl.Controls)
            {
                if (Col is TextBox)
                {
                    if (!(Col.Name == textBoxHelp.Name))
                    {
                        TextBox TBCol = (TextBox)Col;
                        TBList.Add(TBCol);
                    }
                }
                if (Col is ComboBox)
                {
                    ComboBox CBCol = (ComboBox)Col;
                    CBLsit.Add(CBCol);
                }

                if (Col is Panel)
                {
                    IniControlList(Col);
                }
            }
            
            EnableListOfControl();

        }

        private void EnableListOfControl()
        {
            if (UserData.Instance.Now.Power < 5)
            {
                foreach (TextBox Tb in TBList)
                {
                    Tb.Enabled = false;
                }
                foreach (ComboBox Cb in CBLsit)
                {
                    Cb.Enabled = false;
                }

                BtnSave.Visible = false;
            }
            else
            {
                foreach (TextBox Tb in TBList)
                {
                    Tb.Enabled = true;
                }
                foreach (ComboBox Cb in CBLsit)
                {
                    Cb.Enabled = true;
                }

                BtnSave.Visible = true;
            }
        }
    }
}
