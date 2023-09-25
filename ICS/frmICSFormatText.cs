using System;
using System.Drawing;
using System.Windows.Forms;


namespace Xtreme
{
	internal partial class frmICSFormatText
		: System.Windows.Forms.Form
	{

		public frmICSFormatText()
{
InitializeComponent();
} 
 public  void frmICSFormatText_old()
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


		private void frmICSFormatText_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		private int mButtonType = 0; //1 For PreText & 2 for PostText
		private int mLineNo = 0;
		private string mProdDesc = "";
		private bool mIsOkClicked = false;

		public int LineNo
		{
			get
			{
				return mLineNo;
			}
			set
			{
				mLineNo = value;
			}
		}

		public bool IsOkClicked
		{
			get
			{
				return mIsOkClicked;
			}
			set
			{
				mIsOkClicked = value;
			}
		}

		public int ButtonType
		{
			get
			{
				return mButtonType;
			}
			set
			{
				mButtonType = value;
			}
		}

		public string ProdDesc
		{
			get
			{
				return mProdDesc;
			}
			set
			{
				mProdDesc = value;
			}
		}


		private void cmdReset_Click()
		{
			rtbProdDesc.Text = "";
		}

		private void cmdColor_Click(Object eventSender, EventArgs eventArgs)
		{
			if (ReflectionHelper.GetValueForcedToCursor(ColorTranslator.ToOle(rtbProdDesc.SelectionColor)) == CursorHelper.CursorDefault)
			{
				rtbProdDesc.SelectionColor = Color.Blue;
			}
			else
			{
				rtbProdDesc.SelectionColor = ColorTranslator.FromOle(0);
			}
			rtbProdDesc.Refresh();
		}

		private void cmdBold_Click(Object eventSender, EventArgs eventArgs)
		{
			if (!ReflectionHelper.GetPrimitiveValue<bool>(rtbProdDesc.SelectionFont.Bold))
			{
				rtbProdDesc.SelectionFont = rtbProdDesc.SelectionFont.Change(bold:true);
			}
			else
			{
				rtbProdDesc.SelectionFont = rtbProdDesc.SelectionFont.Change(bold:false);
			}
		}

		private void cmdItalic_Click(Object eventSender, EventArgs eventArgs)
		{
			if (!ReflectionHelper.GetPrimitiveValue<bool>(rtbProdDesc.SelectionFont.Italic))
			{
				rtbProdDesc.SelectionFont = rtbProdDesc.SelectionFont.Change(italic:true);
			}
			else
			{
				rtbProdDesc.SelectionFont = rtbProdDesc.SelectionFont.Change(italic:false);
			}
		}

		private void cmdOkCancel_CancelClick(Object Sender, EventArgs e)
		{
			IsOkClicked = false;
			this.Hide();
		}

		private void cmdOkCancel_OKClick(Object Sender, EventArgs e)
		{
			IsOkClicked = true;
			if (rtbProdDesc.Text.Trim() != "")
			{
				ProdDesc = (mButtonType == 3) ? rtbProdDesc.Text : rtbProdDesc.Rtf;
			}
			else
			{
				ProdDesc = "";
			}
			this.Hide();
		}

		private void cmdUnderline_Click(Object eventSender, EventArgs eventArgs)
		{
			if (!ReflectionHelper.GetPrimitiveValue<bool>(rtbProdDesc.SelectionFont.Underline))
			{
				rtbProdDesc.SelectionFont = rtbProdDesc.SelectionFont.Change(underline:true);
			}
			else
			{
				rtbProdDesc.SelectionFont = rtbProdDesc.SelectionFont.Change(underline:false);
			}
		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				SystemForms.SystemFormKeyDown(this, ref KeyCode, Shift);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{
			//Modified By:Rizwan. 8-1-2007. To Set caption as per field used.
			//-----------------------------------
			if (mButtonType == 1)
			{
				this.Text = "Product Pre Description";
			}
			else if (mButtonType == 2)
			{ 
				this.Text = "Product Post Description";
			}
			else if (mButtonType == 3)
			{ 
				this.Text = "Product Name";
			}
			if (mButtonType == 3)
			{
				rtbProdDesc.Text = ProdDesc;
				rtbProdDesc.MaxLength = 400;
				cmdBold.Visible = false;
				cmdItalic.Visible = false;
				cmdUnderline.Visible = false;
				cmdColor.Visible = false;
			}
			else
			{
				rtbProdDesc.Rtf = ProdDesc;
			}
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			frmICSFormatText.DefInstance = null;
		}

		private void rtbProdDesc_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (ReflectionHelper.GetPrimitiveValue<bool>(rtbProdDesc.SelectionFont.Bold))
				{
					rtbProdDesc.SelectionFont = rtbProdDesc.SelectionFont.Change(bold:false);
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}
	}
}