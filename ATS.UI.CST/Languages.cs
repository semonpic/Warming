using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTech;

namespace ATS.UI.CST
{

	public static class Languages
	{
		public static void Init(bool clear = false)
		{
			Language.Setup(clear);

			Language.SetText("SystemName", "Resin Warm System", "膠材回溫系統");

			Language.SetText("MaintainMode", "Maintain", "手動模式");
			Language.SetText("AutoMode", "Automatic" + Environment.NewLine + "SECS GEM OFF", "自動模式");
			Language.SetText("SecsGemMode", "Automatic" + Environment.NewLine + "SECS GEM ON", "連線模式");

			Language.SetText("Stop", "Stop", "停止");
			Language.SetText("Pause", "Pause", "暫停");
			Language.SetText("Run", "Run", "運行中");
			Language.SetText("Reset", "Reset", "初始化");
			Language.SetText("Error", "Error", "錯誤");

			Language.SetText("User", "User", "使用者");
			Language.SetText("Operator", "Operator", "作業員");
			Language.SetText("Engineer", "Engineer", "工程師");
			Language.SetText("Administrator", "Administrator", "管理員");
			Language.SetText("Developer", "Developer", "開發者");

			Language.SetText("StatusPanel.System", "Equipment", "運轉模式");
			Language.SetText("StatusPanel.RunMode", "Mode", "連線模式");
			Language.SetText("StatusPanel.Recipe", "Recipe", "作業模式");
			Language.SetText("StatusPanel.Power", "User", "登入權限");
			Language.SetText("StatusPanel.View1", "PLC Connect ", "PLC連線");
            Language.SetText("StatusPanel.View2", "PLC Connect", "YAMADA連線");
			Language.SetText("StatusPanel.Loadport1", "Cold", "冷藏溫度");
			Language.SetText("StatusPanel.Loadport2", "Warm", "回溫溫度");
			Language.SetText("StatusPanel.Loadport1FoupID", "FoupID", "卡匣埠編號");
			Language.SetText("StatusPanel.Loadport2FoupID", "FoupID", "卡匣埠編號");
			Language.SetText("StatusPanel.Loadport1Count", "ShimNum", "Shim數量");
			Language.SetText("StatusPanel.Loadport2Count", "SleeveNum", "Sleeve數量");
            Language.SetText("StatusPanel.labelColdNum", "ColdNum", "冷藏數量");
            Language.SetText("StatusPanel.LbWarmNum", "WarmNum", "回溫數量");

			Language.SetText("StatusPanel.SecsGem", "SecsGem", "連線模式");
			Language.SetText("StatusPanel.Automatic", "Automatic", "自動模式");
			Language.SetText("StatusPanel.Maintain", "Maintain", "手動模式");

			Language.SetText("AlignerInfomation.Aligner", "Aligner", "尋邊裝置");
			Language.SetText("ViewInfomation.View", "View", "量測機台");
			Language.SetText("RobotInfomation.RobotLeft", "Robot Left", "左手臂");
			Language.SetText("RobotInfomation.RobotRight", "Robot Right", "右手臂");
			Language.SetText("Tabs.Main.Process.Process", "Process", "通訊流程");

			Language.SetText("Tabs.Main", "Main", "主劃頁");
			Language.SetText("Tabs.Mode", "Mode", "模式頁");
			Language.SetText("Tabs.Log", "Log", "記錄頁");
			Language.SetText("Tabs.Maintain", "Maintain", "維護頁");
			Language.SetText("Tabs.IO", "I/O", "I/O頁");
			Language.SetText("Tabs.Settings", "Settings", "設定頁");
			Language.SetText("Tabs.Manage", "Manage", "權限管理頁");

			Language.SetText("Tabs.Main.Process", "Process", "生產狀態");
            Language.SetText("Tabs.Main.StoreInfo", "Store", "倉儲狀況");
            Language.SetText("Tabs.Main.View", "View", "量測機台");
			Language.SetText("Tabs.Main.LoadPort", "LoadPort", "卡匣");
			Language.SetText("Tabs.Main.Reader", "Reader", "讀取器");
			Language.SetText("Tabs.Main.Robot", "Robot", "機器手臂");
			Language.SetText("Tabs.Main.OtherDevices", "OtherDevices", "其他裝置");

			Language.SetText("LoadportInfomation.Loadport", "Loadport", "卡匣埠");
			Language.SetText("LoadportInfomation.Align", "Alignment", "尋邊時間");
			Language.SetText("LoadportInfomation.Inspection", "Inspection", "量測時間");
			Language.SetText("LoadportInfomation.Total", "Total", "總時間");
			Language.SetText("LoadportInfomation.Slot", "Slot ", "層 ");


			Language.SetText("Tabs.IO.Outputs", "Outputs", "輸出");
			Language.SetText("Tabs.IO.Inputs", "Inputs", "輸入");

			Language.SetText("Tabs.Manage.Users", "Users", "使用者");
			Language.SetText("Tabs.Manage.Groups", "Groups", "群組");

			Language.SetText("StatusPanel.Login", "Login", "登入");
			Language.SetText("StatusPanel.Logout", "Logout", "登出");

			Language.SetText("TransportPanel.Selected", "Selected", "已選擇");
			Language.SetText("TransportPanel.Switch", "Switch", "切換");
			Language.SetText("TransportPanel.View1", "View 1 Mode", "View 1 模式");
			Language.SetText("TransportPanel.View2", "View 2 Mode", "View 2 模式");
			Language.SetText("TransportPanel.MixedMode", "Mixed Mode", "混合模式");

			Language.SetText("Tabs.Mode.Equipment", "Equipment", "作業模式");
			Language.SetText("Tabs.Mode.Transport", "Transport", "運轉模式");


			Language.SetText("ControlPanel.LangurageIcon", "中", "En");
			Language.SetText("ControlPanel.Alarm", "Alarm", "警報聲");
			Language.SetText("ControlPanel.Language", "Language", "語言");
			Language.SetText("ControlPanel.Start", "Start", "啟動");
			Language.SetText("ControlPanel.Pause", "Pause", "暫停");
			Language.SetText("ControlPanel.Stop", "Stop", "停止");
            Language.SetText("ControlPanel.Init", "Initialize", "初始化");
			Language.SetText("ControlPanel.LoadStop", "Load Change", "入料變更");

			Language.SetText("LoginPanel.Title", "Login", "登入");
			Language.SetText("LoginPanel.User", "User", "使用者");
			Language.SetText("LoginPanel.Password", "Password", "密碼");
			Language.SetText("LoginPanel.Power", "Power", "權限");
			Language.SetText("LoginPanel.Login", "Login", "登入");
			Language.SetText("LoginPanel.Cancel", "Cancel", "取消");
			Language.SetText("LoginPanel.LoginFail", "Login Fail", "登入失敗");

			// MaintainFFUTabPanel
			Language.SetText("MaintainFFUTabPanel.Connection", "Connection", "連線");
			Language.SetText("MaintainFFUTabPanel.DeviceStatus", "Device Status", "設備狀態");
			Language.SetText("MaintainFFUTabPanel.Setting", "Setting", "設定");
			Language.SetText("MaintainFFUTabPanel.Infomation", "Infomation", "說明");

			Language.SetText("MaintainFFUTabPanel.ConnectionStatus", "Status", "狀態");
			Language.SetText("MaintainFFUTabPanel.Connected", "Connected", "連線");
			Language.SetText("MaintainFFUTabPanel.NotConnected", "Not Connected", "未連線");
			Language.SetText("MaintainFFUTabPanel.ConnectionStart", "Start", "開始");
			Language.SetText("MaintainFFUTabPanel.ConnectionStop", "Stop", "停止");

			Language.SetText("MaintainFFUTabPanel.Mode", "Mode", "模式");
			Language.SetText("MaintainFFUTabPanel.Pressure", "Pressure", "壓差");
			Language.SetText("MaintainFFUTabPanel.Alarm", "Alarm", "警報");
			Language.SetText("MaintainFFUTabPanel.Working", "Working", "運轉");
			Language.SetText("MaintainFFUTabPanel.Power", "Power", "功率");
			Language.SetText("MaintainFFUTabPanel.Speed", "Speed", "轉速");

			Language.SetText("MaintainFFUTabPanel.RunMode", "Run Mode", "運轉模式");
			Language.SetText("MaintainFFUTabPanel.SetSpeed", "Set Speed", "設定轉速");

			Language.SetText("MaintainFFUTabPanel.Default", "Default", "預設");
			Language.SetText("MaintainFFUTabPanel.Custom", "Custom", "自訂");
			Language.SetText("MaintainFFUTabPanel.Stepless", "Stepless", "無段");

			Language.SetText("MaintainFFUTabPanel.DefaultMode", "Default", "預設");
			Language.SetText("MaintainFFUTabPanel.CustomMode", "Custom", "自訂");
			Language.SetText("MaintainFFUTabPanel.SteplessMode", "Stepless", "無段");
			Language.SetText("MaintainFFUTabPanel.SetUp", "Set Up", "設定");

			Language.SetText("ManageUserTabPanel.UserList", "User List", "使用者列表");
			Language.SetText("ManageUserTabPanel.UserInfomation", "User Infomation", "使用者資訊");
			Language.SetText("ManageUserTabPanel.NewUser", "New User", "新增使用者");
			Language.SetText("ManageUserTabPanel.Help", "Help", "說明");
			Language.SetText("ManageUserTabPanel.UserName", "User Name", "使用者名稱");
            Language.SetText("ManageUserTabPanel.BtnIrirEnroll", "Iris Enroll", "註冊虹膜");
            Language.SetText("ManageUserTabPanel.HelpText",
														"User list" + Environment.NewLine +
														"Can query the user's information" + Environment.NewLine + Environment.NewLine +
														"User information box" + Environment.NewLine +
														"Editable user group" + Environment.NewLine +
														"Click \"Update\" when you are done." + Environment.NewLine +
														"Click \"Delete\" if you want to delete the user." + Environment.NewLine + Environment.NewLine +
														"Add user" + Environment.NewLine +
														"Can create a new user" + Environment.NewLine +
														"User password and group can be set" + Environment.NewLine +
														"Different groups will have different permissions" + Environment.NewLine +
														"Click \"Add\" when done.",
														"使用者列表" + Environment.NewLine +
														"可查詢該使用者的資訊" + Environment.NewLine + Environment.NewLine +
														"使用者資訊框" + Environment.NewLine +
														"可修改使用者的群組" + Environment.NewLine +
														"完成後需點擊「更新」" + Environment.NewLine +
														"若需刪除該使用者則點選「刪除」" + Environment.NewLine + Environment.NewLine +
														"新增使用者" + Environment.NewLine +
														"可以建立一個新的使用者" + Environment.NewLine +
														"可設定使用者密碼及群組" + Environment.NewLine +
														"群組不同會有不同權限" + Environment.NewLine +
														"完成後點擊「新增」");

			Language.SetText("ManageUserTabPanel.UserNameInfo", "UserName", "使用者名稱");
			Language.SetText("ManageUserTabPanel.UserGroupInfo", "UserGroup", "使用者群組");
			Language.SetText("ManageUserTabPanel.PermissionInfo", "Permission", "權限");
			Language.SetText("ManageUserTabPanel.OperateInfo", "Operate", "操作");
			Language.SetText("ManageUserTabPanel.UserInfoDelete", "Delete", "刪除");
			Language.SetText("ManageUserTabPanel.UserInfoUpeate", "Update", "更新");
			Language.SetText("ManageUserTabPanel.UserNameAdd", "UserName", "使用者名稱");
			Language.SetText("ManageUserTabPanel.PasswordAdd", "Password", "密碼");
			Language.SetText("ManageUserTabPanel.UserGroupAdd", "UserGroup", "使用者群組");
			Language.SetText("ManageUserTabPanel.OperateAdd", "Operate", "操作");
			Language.SetText("ManageUserTabPanel.AddUserCreate", "Add", "新增");
			Language.SetText("ManageUserTabPanel.AddUserCancel", "Cancel", "取消");

			Language.SetText("ManageUserGroupTabPanel.Allow", "Allow", "允許權限");
			Language.SetText("ManageUserGroupTabPanel.Deny", "Deny", "禁止權限");
			Language.SetText("ManageUserGroupTabPanel.UserGroupList", "UserGroupList", "使用者群組列表");
			Language.SetText("ManageUserGroupTabPanel.UserGroupInfo", "UserGroupInfo", "使用者群組資訊");
			Language.SetText("ManageUserGroupTabPanel.UserGroupHelp", "Help", "說明");
			Language.SetText("ManageUserGroupTabPanel.GroupName", "GroupName", "群組名稱");
			Language.SetText("ManageUserGroupTabPanel.GroupPermission", "GroupPermission", "群組權限");
			//Language.SetText("ManageUserGroupTabPanel.UserGroupHelpText", "", "說明");
			Language.SetText("ManageUserGroupTabPanel.UserGroupHelpText",
														"Select In User Group list" + Environment.NewLine +
														"User Group" + Environment.NewLine +
														"Can query the group of user information" + Environment.NewLine + Environment.NewLine +
														"User's group information box" + Environment.NewLine +
														"Can modify name of user's group" + Environment.NewLine + Environment.NewLine +
														"Group's permission can edit tabcontrol where the group can operate" + Environment.NewLine + Environment.NewLine +
														"Select allow item by clicking >> to deny " + Environment.NewLine +
														"Select  item by clicking << to allow ",
														"使用者群組列表中選擇" + Environment.NewLine +
														"使用者群組" + Environment.NewLine +
														"可查詢該群組的資訊" + Environment.NewLine + Environment.NewLine +
														"使用者群組資訊框" + Environment.NewLine +
														"可修改群組名稱" + Environment.NewLine + Environment.NewLine +
														"群組權限可修改該群組可操作哪些分頁" + Environment.NewLine + Environment.NewLine +
														"選擇允許項目按>則禁止" + Environment.NewLine +
														"選擇禁止項目按<則允許");


			Language.SetText("MaintainLoadportTabPanel.Loadport1Load", "Loadport1  Load", "卡匣埠1" + "\n" + "載入");
			Language.SetText("MaintainLoadportTabPanel.Loadport1Unload", "Loadport1 UnLoad", "卡匣埠1" + "\n" + "載出");
			Language.SetText("MaintainLoadportTabPanel.Loadport1Reset", "Loadport1 Reset", "卡匣埠1" + "\n" + "清除錯誤");

			Language.SetText("MaintainLoadportTabPanel.Loadport2Load", "Loadport2  Load", "卡匣埠2" + "\n" + "載入");
			Language.SetText("MaintainLoadportTabPanel.Loadport2Unload", "Loadport2 UnLoad", "卡匣埠2" + "\n" + "載出");
			Language.SetText("MaintainLoadportTabPanel.Loadport2Reset", "Loadport2 Reset", "卡匣埠2" + "\n" + "清除錯誤");

			Language.SetText("MaintainRobotTabPanel.Commands", "Commands", "常用指令");
			Language.SetText("MaintainRobotTabPanel.GetPut", "GetPut", "取放動作");
			Language.SetText("MaintainRobotTabPanel.PointData", "PointData", "點位資料");
			Language.SetText("MaintainRobotTabPanel.Slider", "Slider", "滑軌");



			Language.SetText("MaintainRobotTabPanel.HomeOrgRetract", "HOME&&ORG&&RETRACT", "各軸回HOME與原點搜尋與雙臂回HOME");
			Language.SetText("MaintainRobotTabPanel.NormalHome", "Normal Home", "各軸移動至HOME");
			Language.SetText("MaintainRobotTabPanel.SafetyHome", "Safety Home", "各軸安全回HOME");
			Language.SetText("MaintainRobotTabPanel.Retract", "Retract", "雙臂回HOME");
			Language.SetText("MaintainRobotTabPanel.ORG", "ORG", "原點搜尋");

			Language.SetText("MaintainRobotTabPanel.HoldRelease", "Hold&&Release", "真空建立與破真空");
			Language.SetText("MaintainRobotTabPanel.ReleaseLarm", "L Arm Release", "左手臂破真空");
			Language.SetText("MaintainRobotTabPanel.ReleaseRarm", "R Arm Release", "右手臂破真空");
			Language.SetText("MaintainRobotTabPanel.HoldLarm", "L Arm Hold", "左手臂真空建立");
			Language.SetText("MaintainRobotTabPanel.HoldRarm", "R Arm Hold", "右手臂真空建立");
			Language.SetText("MaintainRobotTabPanel.SaveLog", "Save Log", "儲存Robot的Log");

			Language.SetText("MaintainRobotTabPanel.LeftPreaent", "Left Present", "左手在席狀態");
			Language.SetText("MaintainRobotTabPanel.RighttPreaent", "Right Present", "右手在席狀態");
			Language.SetText("MaintainRobotTabPanel.LeftHold", "Left Hold", "左手真空狀態");
			Language.SetText("MaintainRobotTabPanel.RightHold", "Right Hold", "右手真空狀態");
			Language.SetText("MaintainRobotTabPanel.RightHold", "Right Hold", "右手真空狀態");

			Language.SetText("MaintainRobotTabPanel.RighttPreaent", "Right Present", "右手在席狀態");
			Language.SetText("MaintainRobotTabPanel.LeftHold", "Left Hold", "左手真空狀態");
			Language.SetText("MaintainRobotTabPanel.RightHold", "Right Hold", "右手真空狀態");
			Language.SetText("MaintainRobotTabPanel.RightHold", "Right Hold", "右手真空狀態");


			Language.SetText("MaintainRobotTabPanel.SelectTarget", "Select Target", "選擇目標");

			Language.SetText("MaintainRobotTabPanel.Aligner", "Aligner", "尋邊裝置");
			Language.SetText("MaintainRobotTabPanel.DataMatrix", "DataMatrix", "二維條碼");
			Language.SetText("MaintainRobotTabPanel.OCRReader", "OCR Reader", "雷刻碼");
			Language.SetText("MaintainRobotTabPanel.View1", "View1", "量測機台1");
			Language.SetText("MaintainRobotTabPanel.View2", "View2", "量測機台2");

			Language.SetText("MaintainRobotTabPanel.SelectArm", "Select Arm", "選擇手臂");
			Language.SetText("MaintainRobotTabPanel.L", "L", "左手臂");
			Language.SetText("MaintainRobotTabPanel.R", "R", "右手臂");

			Language.SetText("MaintainRobotTabPanel.SendCommand", "Send Command", "下組合指令");
			Language.SetText("MaintainRobotTabPanel.Get", "Get", "取片");
			Language.SetText("MaintainRobotTabPanel.Put", "Put", "放片");
			Language.SetText("MaintainRobotTabPanel.GetWait", "GetWait", "取片(軸向與高度" + "\n" + "到位後停止)");
			Language.SetText("MaintainRobotTabPanel.PutWait", "PutWait", "放片(軸向與高度" + "\n" + "到位後停止)");
			Language.SetText("MaintainRobotTabPanel.GetStay", "GetStay", "至取片進入點");


			Language.SetText("MaintainRobotTabPanel.Set", "Set", "設定");
			Language.SetText("MaintainRobotTabPanel.Mode", "Mode", "模式");
			Language.SetText("MaintainRobotTabPanel.Speed", "Speed", "速度");
			Language.SetText("MaintainRobotTabPanel.NormalMode", "NormalMode", "檢查真空在席");
			Language.SetText("MaintainRobotTabPanel.DryMode", "DryMode", "不檢查真空在席");
			Language.SetText("MaintainRobotTabPanel.ResetError", "ResetError", "錯誤解除");

			Language.SetText("MaintainRobotTabPanel.Speed", "Speed", "速度");
			Language.SetText("MaintainRobotTabPanel.NormalMode", "NormalMode", "檢查真空在席");
			Language.SetText("MaintainRobotTabPanel.DryMode", "DryMode", "不檢查真空在席");
			Language.SetText("MaintainRobotTabPanel.ResetError", "ResetError", "錯誤解除");

			Language.SetText("MaintainRobotTabPanel.NormalMode", "NormalMode", "檢查真空在席");
			Language.SetText("MaintainRobotTabPanel.DryMode", "DryMode", "不檢查真空在席");
			Language.SetText("MaintainRobotTabPanel.ResetError", "ResetError", "錯誤解除");

			Language.SetText("MaintainRobotTabPanel.Continue", "Continue", "繼續動作");
			Language.SetText("MaintainRobotTabPanel.Pause", "Pause", "暫停動作");
			Language.SetText("MaintainRobotTabPanel.Stop", "Stop", "停止動作");

			Language.SetText("MaintainRobotTabPanel.loadport1", "loadport1", "卡匣埠1");
			Language.SetText("MaintainRobotTabPanel.LP1ST13", "Slot13", "13層");
			Language.SetText("MaintainRobotTabPanel.LP1ST12", "Slot12", "12層");
			Language.SetText("MaintainRobotTabPanel.LP1ST11", "Slot11", "11層");
			Language.SetText("MaintainRobotTabPanel.LP1ST10", "Slot10", "10層");
			Language.SetText("MaintainRobotTabPanel.LP1ST9", "Slot09", "09層");
			Language.SetText("MaintainRobotTabPanel.LP1ST8", "Slot08", "08層");
			Language.SetText("MaintainRobotTabPanel.LP1ST7", "Slot07", "07層");
			Language.SetText("MaintainRobotTabPanel.LP1ST6", "Slot06", "06層");
			Language.SetText("MaintainRobotTabPanel.LP1ST5", "Slot05", "05層");
			Language.SetText("MaintainRobotTabPanel.LP1ST4", "Slot04", "04層");
			Language.SetText("MaintainRobotTabPanel.LP1ST3", "Slot03", "03層");
			Language.SetText("MaintainRobotTabPanel.LP1ST2", "Slot02", "02層");
			Language.SetText("MaintainRobotTabPanel.LP1ST1", "Slot01", "01層");

			Language.SetText("MaintainRobotTabPanel.loadport2", "loadport2", "卡匣埠2");
			Language.SetText("MaintainRobotTabPanel.LP2ST13", "Slot13", "13層");
			Language.SetText("MaintainRobotTabPanel.LP2ST12", "Slot12", "12層");
			Language.SetText("MaintainRobotTabPanel.LP2ST11", "Slot11", "11層");
			Language.SetText("MaintainRobotTabPanel.LP2ST10", "Slot10", "10層");
			Language.SetText("MaintainRobotTabPanel.LP2ST9", "Slot09", "09層");
			Language.SetText("MaintainRobotTabPanel.LP2ST8", "Slot08", "08層");
			Language.SetText("MaintainRobotTabPanel.LP2ST7", "Slot07", "07層");
			Language.SetText("MaintainRobotTabPanel.LP2ST6", "Slot06", "06層");
			Language.SetText("MaintainRobotTabPanel.LP2ST5", "Slot05", "05層");
			Language.SetText("MaintainRobotTabPanel.LP2ST4", "Slot04", "04層");
			Language.SetText("MaintainRobotTabPanel.LP2ST3", "Slot03", "03層");
			Language.SetText("MaintainRobotTabPanel.LP2ST2", "Slot02", "02層");
			Language.SetText("MaintainRobotTabPanel.LP2ST1", "Slot01", "01層");


			Language.SetText("MaintainViewTabPanel.ViewIOStatus", "View1 I/O Status", "量測機台1 輸入/輸出 狀態");
			Language.SetText("MaintainViewTabPanel.InputStatus", "Input Status", "輸入狀態");
			Language.SetText("MaintainViewTabPanel.ReadyReceive", "ReadyReceive", "允許放片");
			Language.SetText("MaintainViewTabPanel.ReadyPickup", "ReadyPickup", "允許取片");
			Language.SetText("MaintainViewTabPanel.PresentOnView", "PresentOnView1", "量測機台1在席");
			Language.SetText("MaintainViewTabPanel.Fault", "Fault", "錯誤");
			Language.SetText("MaintainViewTabPanel.OutputStatus", "Output Status", "輸出狀態");
			Language.SetText("MaintainViewTabPanel.labelRobotClearStart1", "RobotClearStart", "手臂無干涉");
			Language.SetText("MaintainViewTabPanel.labelRobotPlacing1", "RobotPlacing", "手臂放片中");
			Language.SetText("MaintainViewTabPanel.labelRobotPicking1", "RobotPicking", "手臂取片中");
			Language.SetText("MaintainViewTabPanel.labelVacuumAlarm1", "VacuumAlarm", "真空警報");
			Language.SetText("MaintainViewTabPanel.buttonRobotClearStart", "OFF", "關");
			Language.SetText("MaintainViewTabPanel.buttonRobotPlacing", "OFF", "關");
			Language.SetText("MaintainViewTabPanel.buttonRobotPicking", "OFF", "關");
			Language.SetText("MaintainViewTabPanel.buttonVacuumAlarm", "OFF", "關");

			Language.SetText("MaintainViewTabPanel.Chuck", "Stage", "量測平台");
			Language.SetText("MaintainViewTabPanel.IO", "I/O", "輸入/輸出");


			Language.SetText("MaintainViewTabPanel.ChuckStatusControl", "Chuck Status/Control", "夾爪 狀態/控制");
			Language.SetText("MaintainViewTabPanel.ChuckInputStatus", "InputStatus", "輸入狀態");
			Language.SetText("MaintainViewTabPanel.ChuckPresent", "Present", "在席");
			Language.SetText("MaintainViewTabPanel.ChuckVacuum", "Vacuum", "真空");
			Language.SetText("MaintainViewTabPanel.ChuckPinUpPos", "PinUpPos", "上定位");
			Language.SetText("MaintainViewTabPanel.ChuckDownPos", "DownPos", "下定位");
			Language.SetText("MaintainViewTabPanel.ChuckClampOnPos", "ClampOnPos", "夾定位");
			Language.SetText("MaintainViewTabPanel.ChuckClampOffPos", "ClampOffPos", "開定位");


			Language.SetText("MaintainViewTabPanel.OutputControl", "Output Control", "單獨控制輸出");
			Language.SetText("MaintainViewTabPanel.Pin", "Pin", "頂Pin");
			Language.SetText("MaintainViewTabPanel.PinUp", "Up", "上升");
			Language.SetText("MaintainViewTabPanel.PinDown", "Down", "下降");

			Language.SetText("MaintainViewTabPanel.Clamp", "Clamp", "夾爪");
			Language.SetText("MaintainViewTabPanel.ClampOn", "On", "夾");
			Language.SetText("MaintainViewTabPanel.ClampOff", "Off", "開");

			Language.SetText("MaintainViewTabPanel.Vacuum", "Vacuum", "真空");
			Language.SetText("MaintainViewTabPanel.VacuumOn", "On", "真空吸");
			Language.SetText("MaintainViewTabPanel.VacuumOff", "Off", "破真空");

			Language.SetText("MaintainViewTabPanel.OffAll", "Manual", "手動模式");

			Language.SetText("MaintainViewTabPanel.Command", "Command", "組合指令");
			Language.SetText("MaintainViewTabPanel.Unlock", "Unlock", "量測平台解鎖");
			Language.SetText("MaintainViewTabPanel.Lock", "Lock", "量測平台鎖定");



			Language.SetText("MaintainAlignerTabPanel.SetMode", "SetMode", "設定模式");
			Language.SetText("MaintainAlignerTabPanel.NormalMode", "NormalMode", "檢查真空在席");
			Language.SetText("MaintainAlignerTabPanel.DryMode", "DryMode", "不檢查真空在席");

			Language.SetText("MaintainAlignerTabPanel.Reset", "Reset", "解除");
			Language.SetText("MaintainAlignerTabPanel.ResetError", "ResetError", "錯誤解除");

			Language.SetText("MaintainAlignerTabPanel.groupBoxSaveLog", "SaveLog", "儲存Log");
			Language.SetText("MaintainAlignerTabPanel.SaveLog", "SaveLog", "儲存Log");

			Language.SetText("MaintainAlignerTabPanel.HoldRelease", "Hold&&Release", "真空建立與破真空");
			Language.SetText("MaintainAlignerTabPanel.Hold", "Hold", "真空建立");
			Language.SetText("MaintainAlignerTabPanel.Release", "Release", "破真空");

			Language.SetText("MaintainAlignerTabPanel.AlignAngle", "AlignAngle", "尋邊角度");
			Language.SetText("MaintainAlignerTabPanel.Align", "Align", "尋邊");

			Language.SetText("MaintainAlignerTabPanel.HomeOrgRetract", "HOME&&ORG&&RETRACT", "各軸回HOME與原點搜尋與L/R軸回HOME");
			Language.SetText("MaintainAlignerTabPanel.NormalHome", "Normal Home", "各軸移動至HOME");
			Language.SetText("MaintainAlignerTabPanel.Retract", "Retract", "L/R軸回HOME位置");
			Language.SetText("MaintainAlignerTabPanel.ORG", "ORG Search", "原點搜尋");



			Language.SetText("MaintainSliderTabPanel.Jog", "Jog", "吋動");
			Language.SetText("MaintainSliderTabPanel.JogLeft", "JogLeft", "往左吋動");
			Language.SetText("MaintainSliderTabPanel.JogRight", "JogRight", "往右吋動");
			Language.SetText("MaintainSliderTabPanel.ServoReady", "ServoReady", "伺服準備");
			Language.SetText("MaintainSliderTabPanel.labelServoOn", "ServoOn", "伺服啟動");
			Language.SetText("MaintainSliderTabPanel.ZeroSpeed", "ZeroSpeed", "無速度");
			Language.SetText("MaintainSliderTabPanel.TargetPosition", "TargetPosition", "目標位置");
			Language.SetText("MaintainSliderTabPanel.Home", "Home", "原點");
			Language.SetText("MaintainSliderTabPanel.Brake", "Brake", "煞車");
			Language.SetText("MaintainSliderTabPanel.Warning", "Warning", "警告");
			Language.SetText("MaintainSliderTabPanel.Alarm", "Alarm", "警報");
			Language.SetText("MaintainSliderTabPanel.buttonServoOn", "ServoOn", "伺服啟動");
			Language.SetText("MaintainSliderTabPanel.ServoOff", "ServoOff", "伺服關閉");
			Language.SetText("MaintainSliderTabPanel.MoveTo", "MoveTo", "移動至");
			Language.SetText("MaintainSliderTabPanel.MoveToView1", "View1", "量測機台1");
			Language.SetText("MaintainSliderTabPanel.MoveToLoadport1", "Loadport1", "卡匣埠1");
			Language.SetText("MaintainSliderTabPanel.MoveToLoadport2", "Loadport2", "卡匣埠2");
			Language.SetText("MaintainSliderTabPanel.MoveToDataMatrix", "DataMatrix", "二維碼");
			Language.SetText("MaintainSliderTabPanel.MoveToAligner", "Aligner", "尋邊裝置");
			Language.SetText("MaintainSliderTabPanel.SHome", "SHome", "原點復歸");
			Language.SetText("MaintainSliderTabPanel.MoveToView2", "View2", "量測機台2");
			Language.SetText("MaintainSliderTabPanel.Sensor", "Sensor", "感測器");
			Language.SetText("MaintainSliderTabPanel.LeftLimit", "Left", "左極限");
			Language.SetText("MaintainSliderTabPanel.HomeSensor", "Home", "原點偵測");
			Language.SetText("MaintainSliderTabPanel.RightLimit", "Right", "右極限");
			Language.SetText("MaintainSliderTabPanel.Position", "Position", "點位");
			Language.SetText("MaintainSliderTabPanel.PR1", "Aligner", "尋邊裝置");
			Language.SetText("MaintainSliderTabPanel.PR2", "Loadport1", "卡匣埠1");
			Language.SetText("MaintainSliderTabPanel.PR3", "Loadport2", "卡匣埠2");
			Language.SetText("MaintainSliderTabPanel.PR4", "View1", "量測機台1");
			Language.SetText("MaintainSliderTabPanel.PR5", "View2", "量測機台2");
			Language.SetText("MaintainSliderTabPanel.PR6", "DataMatrix", "二維碼");
			Language.SetText("MaintainSliderTabPanel.LoadPR1", "Load", "載入點位");
			Language.SetText("MaintainSliderTabPanel.LoadPR2", "Load", "載入點位");
			Language.SetText("MaintainSliderTabPanel.LoadPR3", "Load", "載入點位");
			Language.SetText("MaintainSliderTabPanel.LoadPR4", "Load", "載入點位");
			Language.SetText("MaintainSliderTabPanel.LoadPR5", "Load", "載入點位");
			Language.SetText("MaintainSliderTabPanel.LoadPR6", "Load", "載入點位");
			Language.SetText("MaintainSliderTabPanel.SavePR1", "Save", "儲存點位");
			Language.SetText("MaintainSliderTabPanel.SavePR2", "Save", "儲存點位");
			Language.SetText("MaintainSliderTabPanel.SavePR3", "Save", "儲存點位");
			Language.SetText("MaintainSliderTabPanel.SavePR4", "Save", "儲存點位");
			Language.SetText("MaintainSliderTabPanel.SavePR5", "Save", "儲存點位");
			Language.SetText("MaintainSliderTabPanel.SavePR6", "Save", "儲存點位");
			Language.SetText("MaintainSliderTabPanel.SavePR6", "Save", "儲存點位");
			Language.SetText("MaintainSliderTabPanel.CurrentPUU", "Current PUU", "現在位置");

			Language.SetText("MaintainIOTabPanel.MaintainDoorUnlock", "MaintainDoor" + "\n" + "Unlock", "維護門解鎖");
			Language.SetText("MaintainIOTabPanel.MaintainDoorLock", "MaintainDoor" + "\n" + "Lock", "維護門鎖定");

			Language.SetText("Tabs.Run", "Run", "運行");
			Language.SetText("Tabs.Alarm", "Alarm", "警報");
			Language.SetText("Tabs.Product", "Product", "產品");
			Language.SetText("Tabs.System", "System", "系統");
			Language.SetText("Tabs.Robot", "Robot", "手臂");
			Language.SetText("Tabs.Aligner", "Aligner", "尋邊裝置");
			Language.SetText("Tabs.Loadport", "Loadport", "卡匣埠");
			Language.SetText("Tabs.View", "View", "量測機台");

			Language.SetText("Tabs.Loadport1", "Loadport", "卡匣埠");
			Language.SetText("Tabs.MaintainRobot", "Robot", "手臂");
			Language.SetText("Tabs.MaintainView1", "View1", "量測機台1");
			Language.SetText("Tabs.MaintainView2", "View2", "量測機台2");
			Language.SetText("Tabs.MaintainAligner", "Aligner", "尋邊裝置");
			Language.SetText("Tabs.MaintainFFU", "FFU", "風扇");
			Language.SetText("Tabs.MaintainIO", "MaintainIO", "維修(輸入輸出)");
            Language.SetText("Tabs.LbAutoStatus", "Auto", "自動模式");
            Language.SetText("Tabs.LbHandStatus", "Maintain", "手動模式");
            Language.SetText("Tabs.LbDeviceStart", "Start", "設備啟動中");
            Language.SetText("Tabs.LbErrrorStatus", "Alarm", "異常發生");
            Language.SetText("Tabs.LbDevicePause", "Pause", "設備暫停中");
            Language.SetText("Tabs.LbDeviceStop", "Stop", "設備停止中");
            


            Language.SetText("BarcoReader.labelTitle", "Type The Barco", "輸入條碼");
            Language.SetText("BarcoReader.LblBarcoLable", "No. :", "條碼編號 :");
            Language.SetText("BarcoReader.BtnConfirm", "OK", "確認");
            Language.SetText("BarcoReader.BtnCancel", "Cancle", "取消");




            Language.SetText("MachineLocation.ColdlabelTitle", "ColdStore", "冷藏區");
            Language.SetText("MachineLocation.WarmlabelTitle", "WarmStore", "回溫區");
            Language.SetText("MachineLocation.LabelLoadPort", "LoadPort", "入料站");
            Language.SetText("MachineLocation.LabelRt", "Rotage", "手臂站");
            Language.SetText("MachineLocation.LabelStore", "Store", "存儲站");
            Language.SetText("MachineLocation.LabelRecycle", "Recycle", "回收站");
            Language.SetText("MachineLocation.LabelWeight", "Weight", "磅秤站");
            Language.SetText("MachineLocation.LabelOpen", "Bottle", "開蓋站");
            Language.SetText("MachineLocation.LabelLBF", "LBF", "上接站");
            Language.SetText("MachineLocation.LabelTF", "Transfer", "移載倒料站");



            Language.SetText("ResinStore.labelCold", "ColdStore", "冷藏庫位");
            Language.SetText("ResinStore.labelWarm", "WarmStore", "回溫庫位");
            Language.SetText("ResinStore.LBMemo", "Status", "狀態顯示");
            Language.SetText("ResinStore.groupBox3", "Cold", "冷藏");
            Language.SetText("ResinStore.groupBox4", "Warm", "回溫");
            Language.SetText("ResinStore.label5", "Have", "冷藏中");
            Language.SetText("ResinStore.label7", "Expired", "過期");
            Language.SetText("ResinStore.label6", "None", "無料");
            Language.SetText("ResinStore.BtnInwarm1", "Warm", "入回溫");
            Language.SetText("ResinStore.label12", "Have", "回溫中");
            Language.SetText("ResinStore.label10", "Success", "完成");
            Language.SetText("ResinStore.label11", "Expired(1)", "逾時1");
            Language.SetText("ResinStore.label8", "Expired(2)", "逾時2");
            Language.SetText("ResinStore.label9", "None", "無料");
            Language.SetText("ResinStore.BtnOutwarm", "OutWarm", "倒料");


            Language.SetText("TempHistory.TempColdTitle", "ColdTemp", "冷藏區溫度紀錄");
            Language.SetText("TempHistory.TempWarmTitle", "WarmTemp", "回溫區溫度紀錄");

            Language.SetText("SystemSetting.LabelWarmSetting", "WarmSetting", "回溫時間設定資訊");
            Language.SetText("SystemSetting.LabelWeightSetting", "ResinWeightSetting", "膠材重量設定資訊");
            Language.SetText("SystemSetting.labelWarmTime", "WarmTime:", "回溫時間:");
            Language.SetText("SystemSetting.labelNormal", "Normal:", "正常時段:");
            Language.SetText("SystemSetting.labelExpired1st", "Expired1st:", "逾時階段(一):");
            Language.SetText("SystemSetting.labelExpired2rd", "Expired2rd:", "逾時階段(二):");
            Language.SetText("SystemSetting.labelResinWeight", "ResinWeight:", "膠材重量:");
            Language.SetText("SystemSetting.labelCurrentWeight", "CurrentWeight:", "目前膠材重量:");
            Language.SetText("SystemSetting.labelTotalWeight", "TotalWeight:", "滿瓶重量下限:");
            Language.SetText("SystemSetting.labelEmptyWeight", "EmptyWeight:", "空瓶重量上限:");
            Language.SetText("SystemSetting.labelUseWeightCheck", "UseWeightCheck:", "是否啟用重量量測:");
            Language.SetText("SystemSetting.labelMachingValue", "MachingValue", "機構速度設置");
            Language.SetText("SystemSetting.labelColdWarmSetting", "ColdWarmSetting", "冷藏回溫區設置");
            Language.SetText("SystemSetting.labelColdTempSetting", "ColdTemp:", "冷藏設定溫度:");
            Language.SetText("SystemSetting.labelWarmTempSetting", "WarmTemp:", "回溫設定溫度:");
            Language.SetText("SystemSetting.lbSetting", "Warming Time Setting(M)", "正常及逾時回溫時間設定(M)");
            Language.SetText("SystemSetting.LabelWSetting", "WeightSetting(g)", "超過或低於設定重量設定(g)");
            Language.SetText("SystemSetting.labeLifting", "LiftingSpeed:", "升降台速度:");
            Language.SetText("SystemSetting.labelTransfer", "TransferSpeed:", "移載機速度:");
            Language.SetText("SystemSetting.labelDelayTime", "Unload Delay Time:", "到料延遲時間:");
            Language.SetText("SystemSetting.labelShockTime", "Shock Time:", "漏斗震動時間:");
            Language.SetText("SystemSetting.labelUseTempCheck", "Temp detect:", "是否啟用溫度檢測:");
            Language.SetText("SystemSetting.labelLiftingSpeedTitle", "Speed of Lifting at working(%)", "升降台作業時速度設置(%)");
            Language.SetText("SystemSetting.labelTransferSpeedTitle", "Speed of Trasnfer at working(%)", "移載機作業時速度設置(%)");
            Language.SetText("SystemSetting.labelDelayTimeTitle", "ReverseDeleyTime(ms)", "夾爪倒料後延遲時間(ms)");
            Language.SetText("SystemSetting.labelShockTimeTitle", "ShockTime(ms):", "倒料完震動時間(ms)");
            Language.SetText("SystemSetting.textBoxHelp",
                "Warming Time Setting" + Environment.NewLine +
                 Environment.NewLine + 
                 "Can be set:" + Environment.NewLine +
                "Normal" + Environment.NewLine +
                "Expired 1st" + Environment.NewLine +
                "Expired 2nd" + Environment.NewLine +
                Environment.NewLine +
                "Correspond Permission at the Expired" + Environment.NewLine +
                "------------------------------------------" + Environment.NewLine +
                "ResinWeightSetting" + Environment.NewLine +
                 Environment.NewLine +
                "Setting the Weight Before Unload" + Environment.NewLine +
                "Weight Upper Limit And Down Limit" + Environment.NewLine +
                "------------------------------------------" + Environment.NewLine +
                "Warm Temp Setting" + Environment.NewLine +
                 Environment.NewLine +
                "Setting the temp limit at  refrigeration and heating" + Environment.NewLine +
                "Check the door if Alarm",

                "回溫時間設定" + Environment.NewLine +
                 Environment.NewLine +
                "可設定:" + Environment.NewLine +
                "正常回溫時段" + Environment.NewLine +
                "逾時第一階段" + Environment.NewLine +
                "逾時第二階段" + Environment.NewLine +
                Environment.NewLine +
                "逾時階段須有相對應權限允許作業" + Environment.NewLine +
                "------------------------------------------" + Environment.NewLine +
                "膠材重量設定" + Environment.NewLine +
                 Environment.NewLine +
                "設定膠材倒料前" + Environment.NewLine +
                "允許重量及結束作業時重量下限" + Environment.NewLine +
                "------------------------------------------" + Environment.NewLine +
                "回溫區設定" + Environment.NewLine +
                 Environment.NewLine +
                "設定冷藏溫度上限及回溫溫度下限" + Environment.NewLine +
                "如有警報請人員確認有無閉鎖");




            Language.SetText("Maintain.MainPage", "Main", "維護主頁");
            Language.SetText("Maintain.GroupBoxOpr", "Initial", "各軸原點狀態");
            Language.SetText("Maintain.LBUD_OPR", "MainLift", "升降台原點");
            Language.SetText("Maintain.LBTR_OPR", "Transfer", "移載機原點");
            Language.SetText("Maintain.LBBT_OPR", "Open", "開蓋機原點");
            Language.SetText("Maintain.LBRT_OPR", "Rotage", "旋轉軸原點");
            Language.SetText("Maintain.LBCT_OPR", "TransferLifting", "移載升降原點");
            Language.SetText("Maintain.LabelStore", "refrigeration", "冷藏回溫站");
            Language.SetText("Maintain.LabelRotage", "Rotage", "旋轉站");
            Language.SetText("Maintain.LabelWeight", "Scale", "磅秤站");
            Language.SetText("Maintain.LabelOpenBottle", "OpenResin", "開蓋站");
            Language.SetText("Maintain.LabelLoadPort", "LoadPort", "入料站");
            Language.SetText("Maintain.LabelLF", "Connected", "上接站");
            Language.SetText("Maintain.LabelTF", "Transfer", "移載站");
            Language.SetText("Maintain.BtnChangeLocation", "Setting", "開啟校正點位");
            Language.SetText("Maintain.GbTF", "Transfer", "移載機夾具");
            Language.SetText("Maintain.LbTF1", "Load", "入料位置");
            Language.SetText("Maintain.LbTF2", "Unload", "倒料位置");
            Language.SetText("Maintain.LabelTFWait", "Stand by", "待機位置");
            Language.SetText("Maintain.label23", "Jog +", "移載機 JOG+");
            Language.SetText("Maintain.label22", "Jog -", "移載機 JOG-");
            Language.SetText("Maintain.label21", "OPR", "移載機 OPR");
            Language.SetText("Maintain.GbStore", "WarmLifting", "回溫區升降機");
            Language.SetText("Maintain.LbUD10", "OutCold(UP)", "出冷藏取料(上)");
            Language.SetText("Maintain.LbUD0", "OutCold(Down)", "出冷藏取料(下)");
            Language.SetText("Maintain.LbUD3", "InCold(UP)", "入冷藏放料(上)");
            Language.SetText("Maintain.LbUD4", "InCold(Down)", "入冷藏放料(下)");
            Language.SetText("Maintain.LbUD5", "InWarm(UP)", "回溫區放料(上)");
            Language.SetText("Maintain.LbUD6", "InWarm(Down)", "回溫區放料(下)");
            Language.SetText("Maintain.GbRt", "Rotage", "移載區旋轉機");
            Language.SetText("Maintain.LbRT1", "LoadPort", "旋轉至入料口");
            Language.SetText("Maintain.LbRT2", "Store", "旋轉至冷藏區");
            Language.SetText("Maintain.LbRT3", "Scale", "旋轉至磅秤區");
            Language.SetText("Maintain.LbRT4", "Recycle Area", "旋轉至丟棄區");
            Language.SetText("Maintain.LabelRtWait", "StandBy", "待機位置");
            Language.SetText("Maintain.LbRTLogPlus", "JOG +", "旋轉 JOG+");
            Language.SetText("Maintain.LbRTJogReduce", "JOG-", "旋轉 JOG-");
            Language.SetText("Maintain.LbRTOPR", "OPR", "旋轉OPR");
            Language.SetText("Maintain.JogPlus", "LiftingJOG+", "升降台 JOG+");
            Language.SetText("Maintain.JogReduce", "LiftingJOG-", "升降台 JOG-");
            Language.SetText("Maintain.OPR", "LiftingOPR", "升降台 OPR");
            Language.SetText("Maintain.GbOB", "OpenResin", "開蓋夾具");
            Language.SetText("Maintain.BtnBFixtureAdvence", "Forward", "開蓋夾具向前");
            Language.SetText("Maintain.BtnBFixtureBack", "Back", "開蓋夾具向後");
            Language.SetText("Maintain.BtnOBWait", "StandBy", "待機位置");
            Language.SetText("Maintain.BtnBFixtureOpen", "FixtureOpen", "開蓋夾具Open");
            Language.SetText("Maintain.BtnBFixtureLock", "FixtureLock", "開蓋夾具Lock");
            Language.SetText("Maintain.LbOBJogPlus", "JOG+", "開蓋 JOG+");
            Language.SetText("Maintain.LbOBJogReduce", "JOG-", "開蓋 JOG-");
            Language.SetText("Maintain.LbOBOPR", "OPR", "開蓋 OPR");
            Language.SetText("Maintain.GbMain", "MainFixture", "主夾具");
            Language.SetText("Maintain.BtnFixtureBack", "Forward", "入料夾具向前");
            Language.SetText("Maintain.BtnFixtureAdvence", "Back", "入料夾具向後");
            Language.SetText("Maintain.BtnFixtureOpen", "FixtureOpen", "入料夾具開");
            Language.SetText("Maintain.BtnFixtureLock", "FixtureLock", "入料夾具關");
            Language.SetText("Maintain.GbLBF", "TransferConnect", "過度區交接機");
            Language.SetText("Maintain.SendMachine_UDUp", "UP", "交接機上升");
            Language.SetText("Maintain.SendMachine_UD", "Down", "交接機下降");
            Language.SetText("Maintain.SendMachine_LO", "FixtureOpen", "交接機夾具開");
            Language.SetText("Maintain.SendMachine_Lock", "FixtureLock", "交接機夾具關");
            Language.SetText("Maintain.GbStoreLock", "Store", "回溫區庫位");
            Language.SetText("Maintain.BtnWarmDoorOpen", "WarmOpen", "回溫庫門開");
            Language.SetText("Maintain.BtnWarmDoorClose", "WarmClose", "回溫庫門關");
            Language.SetText("Maintain.BtnColdDoorOpen", "ColdOpen", "冷藏庫門開");
            Language.SetText("Maintain.BtnColdDoorClose", "ColdClose", "冷藏庫門關");
            Language.SetText("Maintain.BtnMotorOpen", "StoreMotor", "冷藏/回溫馬達運轉");
            Language.SetText("Maintain.GbTFLock", "TransferFixture", "移載機夾具");
            Language.SetText("Maintain.BtnTFixtureAdvence", "FixtureOpen", "移載機夾具開");
            Language.SetText("Maintain.BtnTFixtureBack", "FixtureLock", "移載機夾具關");
            Language.SetText("Maintain.BtnTFixtureOpen", "FixtureTurn", "移載機夾具轉");
            Language.SetText("Maintain.BtnTFixtureLock", "Reverse", "移載機夾具回");
            Language.SetText("Maintain.BtnShakeOn", "ShakeOpen", "倒料震動開");
            Language.SetText("Maintain.BtnShakeOff", "ShakeClose", "倒料震動關");
            Language.SetText("Maintain.GBUD", "MainLifting", "入料區升降機");
            Language.SetText("Maintain.LbUD2", "Load(UP)", "取膠材位置(上)");
            Language.SetText("Maintain.LbUD1", "Load(Down)", "取膠材位置(下)");
            Language.SetText("Maintain.LbUD19", "LockBottle(UP)", "關蓋上升(上)");
            Language.SetText("Maintain.LbUD14", "LockBottle(Down)", "關蓋上升(下)");
            Language.SetText("Maintain.LbUD9", "OpenBottle(UP)", "開蓋下降(上)");
            Language.SetText("Maintain.LbUD18", "OpenBottle(Down)", "開蓋下降(下)");
            Language.SetText("Maintain.LbUD16", "StandBy", "待機位置");
            Language.SetText("Maintain.LbUD12", "TransferResin(UP)", "移載區取料(上)");
            Language.SetText("Maintain.LbUD13", "TransferResin(Down)", "移載區取料(下)");
            Language.SetText("Maintain.GbWeight", "ScaleLifting", "量測區升降");
            Language.SetText("Maintain.LbUD7", "ScalePut(UP)", "秤重區放料(上)");
            Language.SetText("Maintain.LbUD8", "ScalePut(Down)", "秤重區放料(下)");
            Language.SetText("Maintain.LbUD15", "ScaleTakeAway", "秤重區取料");
            Language.SetText("Maintain.GbLF", "TrasnferLifiting", "輸料區升降機");
            Language.SetText("Maintain.LbLF1", "UP", "接料位置(上)");
            Language.SetText("Maintain.LbLF2", "Down", "接料位置(下)");
            Language.SetText("Maintain.label4", "StandBy", "待機位置");
            Language.SetText("Maintain.label1", "OPR", "升降機 OPR");
            Language.SetText("Maintain.label3", "JOG+", "升降機 JOG+");
            Language.SetText("Maintain.label2", "JOG-", "升降機 JOG-");
            Language.SetText("Maintain.BtnIncold1", "InCold", "入冷藏作業");



            Language.SetText("ResinStore.labelColdTemp1", "Temp1:", "感溫棒1:");
            Language.SetText("ResinStore.labelColdTemp2", "Temp2:", "感溫棒2:");
            Language.SetText("ResinStore.labelColdTemp3", "Temp3:", "感溫棒3:");
            Language.SetText("ResinStore.labelColdTemp4", "Temp4:", "感溫棒4:");
            Language.SetText("ResinStore.labelColdTemp5", "Temp5:", "感溫棒5:");
            Language.SetText("ResinStore.labelWarmTemp1", "Temp1:", "感溫棒1:");
            Language.SetText("ResinStore.labelWarmTemp2", "Temp1:", "感溫棒2:");
            Language.SetText("ResinStore.labelWarmTemp3", "Temp1:", "感溫棒3:");
            Language.SetText("ResinStore.labelWarmTemp4", "Temp1:", "感溫棒4:");
            Language.SetText("ResinStore.labelWarmTemp5", "Temp1:", "感溫棒5:");



            //			Language.Save();
        }
	}
}
