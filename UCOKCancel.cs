using System;
using System.ComponentModel;
using System.Windows.Forms;
using UpgradeHelpers.Helpers;

namespace Xtreme
{
	internal partial class UCOkCancel
		: System.Windows.Forms.UserControl
	{

		[field: System.NonSerialized]
		public event System.EventHandler EnabledCancelChange;
		[field: System.NonSerialized]
		public event System.EventHandler EnabledOKChange;
		[field: System.NonSerialized]
		public event System.EventHandler cancelCaptionChange;
		[field: System.NonSerialized]
		public event System.EventHandler DisplayButtonChange;
		[field: System.NonSerialized]
		public event System.EventHandler OkCaptionChange;
		[field: System.NonSerialized]
		public event System.EventHandler EnabledChange;

		//Event Declarations:
		[field: System.NonSerialized]
		public event OKClickHandler OKClick;
		public delegate void OKClickHandler(Object Sender, EventArgs e);
		//Event OKClick() 'MappingInfo=Command2,Command2,-1,Click
		[field: System.NonSerialized]
		public event CancelClickHandler CancelClick;
		public delegate void CancelClickHandler(Object Sender, EventArgs e); //MappingInfo=cmdOK,cmdOK,-1,Click
		//Default Property Values:
		const string m_def_CancelCaption = "&Cancel";
		const string m_def_OkCaption = "&OK";
		const int mIndexOKButton = 0;
		const int mIndexCancelButton = 1;
		const int mSpaceBetweenButtons = 10;
		int mDisplayButton = 0;
		public UCOkCancel()
			: base()
		{
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			ReLoadForm(false);
		}



		private void UserControl_Initialize()
		{
			cmdButton[mIndexOKButton].Left = 0;
			cmdButton[mIndexOKButton].Top = 0;
			cmdButton[mIndexOKButton].Width = 102;
			cmdButton[mIndexOKButton].Height = 29;
			cmdButton[mIndexCancelButton].Left = cmdButton[mIndexOKButton].Left + cmdButton[mIndexOKButton].Width + mSpaceBetweenButtons / 15;
			cmdButton[mIndexCancelButton].Top = 0;
			cmdButton[mIndexCancelButton].Width = 102;
			cmdButton[mIndexCancelButton].Height = 29;
			base.Width = cmdButton[mIndexOKButton].Width + mSpaceBetweenButtons / 15 + cmdButton[mIndexCancelButton].Width;
			base.Height = cmdButton[mIndexOKButton].Height;
		}

		private void UserControl_Resize(Object eventSender, EventArgs eventArgs)
		{
			cmdButton[mIndexOKButton].Left = 0;
			cmdButton[mIndexOKButton].Top = 0;
			cmdButton[mIndexOKButton].Width = 102;
			cmdButton[mIndexOKButton].Height = 29;
			cmdButton[mIndexCancelButton].Left = cmdButton[mIndexOKButton].Left + cmdButton[mIndexOKButton].Width + mSpaceBetweenButtons / 15;
			cmdButton[mIndexCancelButton].Top = 0;
			cmdButton[mIndexCancelButton].Width = 102;
			cmdButton[mIndexCancelButton].Height = 29;
			base.Width = cmdButton[mIndexOKButton].Width + mSpaceBetweenButtons / 15 + cmdButton[mIndexCancelButton].Width;
			base.Height = cmdButton[mIndexOKButton].Height;
		}

		private void cmdButton_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmdButton, eventSender);
			if (Index == 0)
			{
				if (OKClick != null)
				{
					OKClick(this, null);
				}
			}
			else if (Index == 1)
			{ 
				if (CancelClick != null)
				{
					CancelClick(this, null);
				}
			}
		}


		[Browsable(true)]
		public new bool Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				base.Enabled = value;
				cmdButton[mIndexOKButton].Enabled = value;
				cmdButton[mIndexCancelButton].Enabled = value;
				if (EnabledChange != null)
				{
					EnabledChange(this, EventArgs.Empty);
				}
			}
		}



		[Browsable(true)]
		public string OkCaption
		{
			get
			{
				return cmdButton[mIndexOKButton].Text;
			}
			set
			{
				cmdButton[mIndexOKButton].Text = value;
				if (OkCaptionChange != null)
				{
					OkCaptionChange(this, EventArgs.Empty);
				}
			}
		}



		[Browsable(true)]
		public int DisplayButton
		{
			get
			{
				return mDisplayButton;
			}
			set
			{
				if (value == 1)
				{
					cmdButton[mIndexCancelButton].Visible = false;
					//        picOkCancel.Width = cmdButton(mIndexOKButton).Width + 65
					mDisplayButton = 1;
				}
				else if (value == 2)
				{ 
					cmdButton[mIndexCancelButton].Visible = true;
					//       picOkCancel.Width = (cmdButton(mIndexOKButton).Width * 2) + 85
					mDisplayButton = 2;
				}
				UserControl_Resize(this, new EventArgs());
				if (DisplayButtonChange != null)
				{
					DisplayButtonChange(this, EventArgs.Empty);
				}
			}
		}



		[Browsable(true)]
		public string CancelCaption
		{
			get
			{
				return cmdButton[mIndexCancelButton].Text;
			}
			set
			{
				cmdButton[mIndexCancelButton].Text = value;
				if (cancelCaptionChange != null)
				{
					cancelCaptionChange(this, EventArgs.Empty);
				}
			}
		}



		[Browsable(true)][Description("Returns or sets a value that determines whether or not an object can respond to user-generated events.")]
		public bool EnabledOK
		{
			get
			{
				return cmdButton[mIndexOKButton].Enabled;
			}
			set
			{
				cmdButton[mIndexOKButton].Enabled = value;
				if (EnabledOKChange != null)
				{
					EnabledOKChange(this, EventArgs.Empty);
				}
			}
		}



		[Browsable(true)][Description("Returns or sets a value that determines whether or not an object can respond to user-generated events.")]
		public bool EnabledCancel
		{
			get
			{
				return cmdButton[mIndexCancelButton].Enabled;
			}
			set
			{
				cmdButton[mIndexCancelButton].Enabled = value;
				if (EnabledCancelChange != null)
				{
					EnabledCancelChange(this, EventArgs.Empty);
				}
			}
		}


		//**--Load property values from storage
		//UPGRADE_ISSUE: (2068) PropertyBag object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
		//UPGRADE_WARNING: (6002) UserControl Event ReadProperties is not supported. More Information: https://docs.mobilize.net/vbuc/ewis#6002
		private void UserControl_ReadProperties(ref UpgradeStubs.PropertyBag PropBag)
		{
			//UPGRADE_ISSUE: (2064) PropertyBag method PropBag.ReadProperty was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			base.Enabled = ReflectionHelper.GetPrimitiveValue<bool>(PropBag.ReadProperty("Enabled", true));
			//UPGRADE_ISSUE: (2064) PropertyBag method PropBag.ReadProperty was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			cmdButton[mIndexOKButton].Text = ReflectionHelper.GetPrimitiveValue<string>(PropBag.ReadProperty("OkCaption", m_def_OkCaption));
			//UPGRADE_ISSUE: (2064) PropertyBag method PropBag.ReadProperty was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			cmdButton[mIndexCancelButton].Text = ReflectionHelper.GetPrimitiveValue<string>(PropBag.ReadProperty("CancelCaption", m_def_CancelCaption));
			//UPGRADE_ISSUE: (2064) PropertyBag method PropBag.ReadProperty was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			cmdButton[mIndexOKButton].Enabled = ReflectionHelper.GetPrimitiveValue<bool>(PropBag.ReadProperty("EnabledOK", true));
			//UPGRADE_ISSUE: (2064) PropertyBag method PropBag.ReadProperty was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			cmdButton[mIndexCancelButton].Enabled = ReflectionHelper.GetPrimitiveValue<bool>(PropBag.ReadProperty("EnabledCancel", true));

			//UPGRADE_ISSUE: (2064) PropertyBag method PropBag.ReadProperty was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			//UPGRADE_WARNING: (1068) PropBag.ReadProperty() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis#1068
			DisplayButton = ReflectionHelper.GetPrimitiveValue<int>(PropBag.ReadProperty("DisplayButton", 2));
		}

		//**--Write property values to storage
		//UPGRADE_ISSUE: (2068) PropertyBag object was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2068
		//UPGRADE_WARNING: (6002) UserControl Event WriteProperties is not supported. More Information: https://docs.mobilize.net/vbuc/ewis#6002
		private void UserControl_WriteProperties(UpgradeStubs.PropertyBag PropBag)
		{
			//UPGRADE_ISSUE: (2064) PropertyBag method PropBag.WriteProperty was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			PropBag.WriteProperty("Enabled", base.Enabled, true);
			//UPGRADE_ISSUE: (2064) PropertyBag method PropBag.WriteProperty was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			PropBag.WriteProperty("OkCaption", cmdButton[mIndexOKButton].Text, m_def_OkCaption);
			//UPGRADE_ISSUE: (2064) PropertyBag method PropBag.WriteProperty was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			PropBag.WriteProperty("CancelCaption", cmdButton[mIndexCancelButton].Text, m_def_CancelCaption);
			//UPGRADE_ISSUE: (2064) PropertyBag method PropBag.WriteProperty was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			PropBag.WriteProperty("DisplayButton", mDisplayButton, 2);
			//UPGRADE_ISSUE: (2064) PropertyBag method PropBag.WriteProperty was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			PropBag.WriteProperty("EnabledOK", cmdButton[mIndexOKButton].Enabled, true);
			//UPGRADE_ISSUE: (2064) PropertyBag method PropBag.WriteProperty was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis#2064
			PropBag.WriteProperty("EnabledCancel", cmdButton[mIndexCancelButton].Enabled, true);
		}

		private void cmdButton_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmdButton, eventSender);
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == ((int) Keys.Return) || KeyCode == 32)
				{
					cmdButton_Click(cmdButton[Index], new EventArgs());
				}
				if (KeyCode == 37)
				{
					cmdButton[mIndexOKButton].Focus();
					KeyCode = 0;
				}
				if (KeyCode == 39)
				{
					cmdButton[mIndexCancelButton].Focus();
					KeyCode = 0;
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}
	}
}