
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Xtreme
{
	internal partial class frmSysTools
		: System.Windows.Forms.Form
	{

		public frmSysTools()
{
InitializeComponent();
} 
 public  void frmSysTools_old()
			//: base()
		{
			if (m_vb6FormDefInstance is null)
			{
				if (m_InitializingDefInstance)
				{
					m_vb6FormDefInstance = this;
				}
				else
				{
					try
					{
						//For the start-up form, the first instance created is the default instance.
						if (!(System.Reflection.Assembly.GetExecutingAssembly().EntryPoint is null) && System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType == this.GetType())
						{
							m_vb6FormDefInstance = this;
						}
					}
					catch
					{
					}
				}
			}
			//This call is required by the Windows Form Designer.
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			
		}


		private void frmSysTools_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private double mdblResult = 0;
		private double mdblSavedNumber = 0;
		private string mstrDot = "";
		private string mstrOp = "";
		private string mstrDisplay = "";
		private bool mblnDecEntered = false;
		private bool mblnOpPending = false;
		private bool mblnNewEquals = false;
		private bool mblnEqualsPressed = false;
		private int mintCurrKeyIndex = 0;

		private void ctlCalender_SelChange(Object eventSender, AxXtremeSuiteControls._DMonthCalendarEvents_SelChangeEvent eventArgs)
		{
			SystemVariables.gCurrentDate = ctlCalender.Value;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			Top = Convert.ToInt32((Screen.PrimaryScreen.Bounds.Height - Height) / 2d);
			Left = Convert.ToInt32((Screen.PrimaryScreen.Bounds.Width - Width) / 2d);
			ctlCalender.Value = SystemVariables.gCurrentDate;


			XtremeTaskPanel.TaskPanelGroup Group = (XtremeTaskPanel.TaskPanelGroup) wndTaskPanel.Groups.Add(0, "Calculator");
			XtremeTaskPanel.TaskPanelGroupItem Item = (XtremeTaskPanel.TaskPanelGroupItem) Group.Items.Add(0, "", XtremeTaskPanel.XTPTaskPanelItemType.xtpTaskItemTypeControl, Type.Missing);
			Item.Control = panelCalculator;
			panelCalculator.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Item.BackColor));


			Group.Expanded = true;

			Group = (XtremeTaskPanel.TaskPanelGroup) wndTaskPanel.Groups.Add(0, "Calender");
			Item = (XtremeTaskPanel.TaskPanelGroupItem) Group.Items.Add(0, "", XtremeTaskPanel.XTPTaskPanelItemType.xtpTaskItemTypeControl, Type.Missing);
			Item.Control = panelCalender;
			panelCalender.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Item.BackColor));


			Group.Expanded = true;

			Group = (XtremeTaskPanel.TaskPanelGroup) wndTaskPanel.Groups.Add(0, "Notes");
			Item = (XtremeTaskPanel.TaskPanelGroupItem) Group.Items.Add(0, "", XtremeTaskPanel.XTPTaskPanelItemType.xtpTaskItemTypeControl, Type.Missing);
			Item.Control = panelNotes;
			panelNotes.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Item.BackColor));


			Group.Expanded = true;

		}


		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				int intIndex = 0;

				if (KeyCode == ((int) Keys.Back))
				{
					intIndex = 0;
				}
				else if (KeyCode == ((int) Keys.Delete))
				{ 
					intIndex = 1;
				}
				else if (KeyCode == ((int) Keys.Escape))
				{ 
					intIndex = 2;
				}
				else if (KeyCode == ((int) Keys.D0) || KeyCode == ((int) Keys.NumPad0))
				{ 
					intIndex = 18;
				}
				else if (KeyCode == ((int) Keys.D1) || KeyCode == ((int) Keys.NumPad1))
				{ 
					intIndex = 13;
				}
				else if (KeyCode == ((int) Keys.D2) || KeyCode == ((int) Keys.NumPad2))
				{ 
					intIndex = 14;
				}
				else if (KeyCode == ((int) Keys.D3) || KeyCode == ((int) Keys.NumPad3))
				{ 
					intIndex = 15;
				}
				else if (KeyCode == ((int) Keys.D4) || KeyCode == ((int) Keys.NumPad4))
				{ 
					intIndex = 8;
				}
				else if (KeyCode == ((int) Keys.D5) || KeyCode == ((int) Keys.NumPad5))
				{ 
					intIndex = 9;
				}
				else if (KeyCode == ((int) Keys.D6) || KeyCode == ((int) Keys.NumPad6))
				{ 
					intIndex = 10;
				}
				else if (KeyCode == ((int) Keys.D7) || KeyCode == ((int) Keys.NumPad7))
				{ 
					intIndex = 3;
				}
				else if (KeyCode == ((int) Keys.D8) || KeyCode == ((int) Keys.NumPad8))
				{ 
					intIndex = 4;
				}
				else if (KeyCode == ((int) Keys.D9) || KeyCode == ((int) Keys.NumPad9))
				{ 
					intIndex = 5;
				}
				else if (KeyCode == ((int) Keys.Decimal))
				{ 
					intIndex = 20;
				}
				else if (KeyCode == ((int) Keys.Add))
				{ 
					intIndex = 21;
				}
				else if (KeyCode == ((int) Keys.Subtract))
				{ 
					intIndex = 16;
				}
				else if (KeyCode == ((int) Keys.Multiply))
				{ 
					intIndex = 11;
				}
				else if (KeyCode == ((int) Keys.Divide))
				{ 
					intIndex = 6;
				}
				else
				{
					return;
				}

				cmdCalc[intIndex].Focus();
				cmdCalc_ClickEvent(cmdCalc[intIndex], new EventArgs());
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}


		private void Form_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				int intIndex = 0;

				switch(Strings.Chr(KeyAscii).ToString())
				{
					case "S" : case "s" :  
						intIndex = 7; 
						break;
					case "P" : case "p" :  
						intIndex = 12; 
						break;
					case "R" : case "r" :  
						intIndex = 17; 
						break;
					case "*" : case "*" :  
						intIndex = 11; 
						break;
					case "=" :  
						intIndex = 22; 
						break;
					default: 
						if (KeyAscii == 0)
						{
							eventArgs.Handled = true;
						} 
						return;
				}

				cmdCalc[intIndex].Focus();
				cmdCalc_ClickEvent(cmdCalc[intIndex], new EventArgs());
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}

		}

		private void cmdCalc_ClickEvent(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmdCalc, eventSender);


			mintCurrKeyIndex = Index;

			if (mstrDisplay == "ERROR")
			{
				mstrDisplay = "";
			}

			string strPressedKey = cmdCalc[Index].Text;

			switch(strPressedKey)
			{
				case "0" : case "1" : case "2" : case "3" : case "4" : case "5" : case "6" : case "7" : case "8" : case "9" : 
					if (mblnOpPending)
					{
						mstrDisplay = "";
						mblnOpPending = false;
					} 
					if (mblnEqualsPressed)
					{
						mstrDisplay = "";
						mblnEqualsPressed = false;
					} 
					mstrDisplay = mstrDisplay + strPressedKey; 
					break;
				case "." : 
					if (mblnOpPending)
					{
						mstrDisplay = "";
						mblnOpPending = false;
					} 
					if (mblnEqualsPressed)
					{
						mstrDisplay = "";
						mblnEqualsPressed = false;
					} 
					if (mstrDisplay.IndexOf('.') >= 0)
					{
						SystemSounds.Beep.Play();
					}
					else
					{
						mstrDisplay = mstrDisplay + strPressedKey;
					} 
					break;
				case "+" : case "-" : case "*" : case "/" : 
					mdblResult = Conversion.Val(mstrDisplay); 
					mstrOp = strPressedKey; 
					mblnOpPending = true; 
					mblnDecEntered = false; 
					mblnNewEquals = true; 
					break;
				case "%" : 
					mdblSavedNumber = (Conversion.Val(mstrDisplay) / 100d) * mdblResult; 
					mstrDisplay = mdblSavedNumber.ToString(); 
					break;
				case "=" : 
					if (mblnNewEquals)
					{
						mdblSavedNumber = Conversion.Val(mstrDisplay);
						mblnNewEquals = false;
					} 
					switch(mstrOp)
					{
						case "+" : 
							mdblResult += mdblSavedNumber; 
							break;
						case "-" : 
							mdblResult -= mdblSavedNumber; 
							break;
						case "*" : 
							mdblResult *= mdblSavedNumber; 
							break;
						case "/" : 
							if (mdblSavedNumber == 0)
							{
								mstrDisplay = "ERROR";
							}
							else
							{
								mdblResult /= mdblSavedNumber;
							} 
							break;
						default:
							mdblResult = Conversion.Val(mstrDisplay); 
							break;
					} 
					if (mstrDisplay != "ERROR")
					{
						mstrDisplay = mdblResult.ToString();
					} 
					mblnEqualsPressed = true; 
					break;
				case "+/-" : 
					if (mstrDisplay != "")
					{
						if (mstrDisplay.StartsWith("-"))
						{
							mstrDisplay = mstrDisplay.Substring(Math.Max(mstrDisplay.Length - 2, 0));
						}
						else
						{
							mstrDisplay = "-" + mstrDisplay;
						}
					} 
					break;
				case "§" : 
					if (Conversion.Val(mstrDisplay) != 0)
					{
						mstrDisplay = mstrDisplay.Substring(0, Math.Min(Strings.Len(mstrDisplay) - 1, mstrDisplay.Length));
						mdblResult = Conversion.Val(mstrDisplay);
					} 
					break;
				case "CE" : 
					mstrDisplay = ""; 
					break;
				case "C" : 
					mstrDisplay = ""; 
					mdblResult = 0; 
					mdblSavedNumber = 0; 
					break;
				case "1/x" : 
					if (Conversion.Val(mstrDisplay) == 0)
					{
						mstrDisplay = "ERROR";
					}
					else
					{
						mdblResult = Conversion.Val(mstrDisplay);
						mdblResult = 1 / mdblResult;
						mstrDisplay = mdblResult.ToString();
					} 
					break;
				case "Ö" : 
					if (Conversion.Val(mstrDisplay) < 0)
					{
						mstrDisplay = "ERROR";
					}
					else
					{
						mdblResult = Conversion.Val(mstrDisplay);
						mdblResult = Math.Sqrt(mdblResult);
						mstrDisplay = mdblResult.ToString();
					} 
					break;
			}

			if (mstrDisplay == "")
			{
				lblDisplay.Text = "0.";
			}
			else
			{
				mstrDot = (mstrDisplay.IndexOf('.') >= 0) ? "" : ".";
				lblDisplay.Text = mstrDisplay + mstrDot;
				if (lblDisplay.Text.StartsWith("0"))
				{
					lblDisplay.Text = lblDisplay.Text.Substring(1);
				}
			}

			if (lblDisplay.Text == ".")
			{
				lblDisplay.Text = "0.";
			}

		}

		//Private Sub lblDisplay_KeyDown(KeyCode As Integer, Shift As Integer)
		//Call Form_KeyDown(KeyCode, Shift)
		//End Sub
		//
		//Private Sub lblDisplay_KeyPress(KeyAscii As Integer)
		//Call Form_KeyPress(KeyAscii)
		//End Sub
		//
		//Private Sub lblDisplay_Click()
		//
		//End Sub
		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}
			wndTaskPanel.SetBounds(0, 0, this.Width, this.Height);
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}