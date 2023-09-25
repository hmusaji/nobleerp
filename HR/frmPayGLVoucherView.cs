
using System;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmPayGLVoucherView
		: System.Windows.Forms.Form
	{

		public frmPayGLVoucherView()
{
InitializeComponent();
} 
 public  void frmPayGLVoucherView_old()
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
			InitializeComponent();
		}


		private void frmPayGLVoucherView_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private XArrayHelper aVoucherDetails = null;
		private clsToolbar oThisFormToolBar = null;

		private const int gccAccountNo = 0;
		private const int gccAccountName = 1;
		private const int gccDebit = 2;
		private const int gccCredit = 3;
		private const int gccCCCode = 4;
		private const int gccCCName = 5;
		private const int gccComments = 6;

		private const int mMaxCols = 6;
		public bool mPostTransaction = false;


		public XArrayHelper AssignArray
		{
			set
			{
				aVoucherDetails = value;
			}
		}


		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == 13)
				{
					SendKeys.Send("{TAB}");
					return;
				}

				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift, this.ActiveControl.Name);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			this.Top = 0;
			this.Left = 0;

			//**--format & define the new toolbar
			oThisFormToolBar = new clsToolbar();
			oThisFormToolBar.AttachObject(this); //, tcbSystemForm

			oThisFormToolBar.ShowNewButton = false;
			oThisFormToolBar.ShowSaveButton = false;
			oThisFormToolBar.ShowDeleteButton = false;
			oThisFormToolBar.ShowPrintButton = true;
			oThisFormToolBar.ShowFindButton = true;
			oThisFormToolBar.ShowHelpButton = true;
			oThisFormToolBar.ShowPostButton = true;
			oThisFormToolBar.ShowExitButton = true;
			oThisFormToolBar.BeginExitButtonWithGroup = true;
			oThisFormToolBar.DisableHelpButton = true;

			this.WindowState = FormWindowState.Maximized;

			//Call DrawToolbar(Me, picFormToolbar, btnFormToolBar(3))
			//Set btnFormToolBar(3).Picture = frmSysMain.imlMainToolBar.ListImages("imgPrint").Picture
			//Set btnFormToolBar(4).Picture = frmSysMain.imlSystemIcons.ListImages("imgPostingTransactions").Picture
			//Set btnFormToolBar(5).Picture = frmSysMain.imlMainToolBar.ListImages("imgHelp").Picture
			//Set btnFormToolBar(8).Picture = frmSysMain.imlMainToolBar.ListImages("imgExit").Picture


			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGrid(grdVoucherDetails, false, false, false, (0xFFFFFF).ToString(), (0x0).ToString(), true, true, C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow, 2.4f, 1.4f, "&HB4D9F8", "&HB4D9F8", 280);
			//define voucher grid columns
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Account No.", 1200, false, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Account Name", 3000, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Debit", 1050, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Credit", 1050, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, true, "", C1.Win.C1TrueDBGrid.AlignHorzEnum.Far);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Code", 1200, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, false);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Cost Name", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near);
			SystemGrid.DefineSystemVoucherGridColumn(grdVoucherDetails, "Comments", 1500, true, ColorTranslator.ToOle(Color.White).ToString(), ColorTranslator.ToOle(Color.Black).ToString(), C1.Win.C1TrueDBGrid.AlignHorzEnum.Near);

			SystemProcedure.SetLabelCaption(this);

			//.HoldFields
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.TDBGrid property grdVoucherDetails.Array was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			grdVoucherDetails.setArray(aVoucherDetails);
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[gccAccountNo].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[gccAccountName].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[gccDebit].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[gccCredit].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[gccCCCode].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[gccCCName].AllowSizing = true;
			//UPGRADE_WARNING: (2081) Getting a DataColumn not from a split has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2081
			grdVoucherDetails.Splits[0].DisplayColumns[gccComments].AllowSizing = true;
			//.Enabled = False

			mPostTransaction = false;

			grdVoucherDetails.Rebind(true);
			grdVoucherDetails.Refresh();

			int cnt = 0;
			decimal mDrAmt = 0;
			decimal mCrAmt = 0;

			int tempForEndVar = aVoucherDetails.GetLength(0) - 1;
			for (cnt = 0; cnt <= tempForEndVar; cnt++)
			{
				mDrAmt += ((decimal) Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(cnt, gccDebit), "###############0.000")));
				mCrAmt += ((decimal) Conversion.Val(StringsHelper.Format(aVoucherDetails.GetValue(cnt, gccCredit), "###############0.000")));
			}

			grdVoucherDetails.Columns[gccDebit].FooterText = StringsHelper.Format(mDrAmt, "###,###,###,##0.000");
			grdVoucherDetails.Columns[gccCredit].FooterText = StringsHelper.Format(mCrAmt, "###,###,###,##0.000");

		}

		public void CloseForm()
		{
			this.Hide();
		}

		public void PrintReport(int pEntryId = 0)
		{
			C1.Win.C1TrueDBGrid.PrintInfo withVar = null;
			withVar = grdVoucherDetails.PrintInfo;
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.PrintInfo property withVar.PreviewCaption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar.setPreviewCaption(" Payroll GL Entry ");
			//UPGRADE_ISSUE: (2064) TrueOleDBGrid80.PrintInfo property withVar.PreviewInitZoom was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			withVar.setPreviewInitZoom(80);

			withVar.PageSettings.Margins.Left = 600;

			withVar.PageFooter = "\\p of page \\P";
			//UPGRADE_WARNING: (2065) TrueOleDBGrid80.PrintInfo method withVar.PrintPreview has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2065
			withVar.PrintPreview();
		}

		public bool Post()
		{
			DialogResult ans = MessageBox.Show("Are you sure you want to post the entry to GL? ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);

			if (ans == System.Windows.Forms.DialogResult.Yes)
			{
				mPostTransaction = true;
				CloseForm();
			}
			else
			{
				mPostTransaction = false;
			}

			return false;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			oThisFormToolBar = null;
		}
	}
}