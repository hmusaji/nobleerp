
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Xtreme
{
	internal partial class frmSysError
		: System.Windows.Forms.Form
	{

		public frmSysError()
{
InitializeComponent();
} 
 public  void frmSysError_old()
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


		private void frmSysError_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		public string mReturnValue = "";
		private string mErrorMessage = "";
		private MsgBoxStyle mButton = MsgBoxStyle.OkOnly;

		public string ErrorMeessage
		{
			set
			{
				mErrorMessage = value;
			}
		}


		public MsgBoxStyle Button
		{
			set
			{
				mButton = value;
			}
		}


		private void btnMore_Click(Object eventSender, EventArgs eventArgs)
		{
			this.Height = 444;
		}

		private void cmdCancel_Click(Object eventSender, EventArgs eventArgs)
		{
			mReturnValue = ((int) System.Windows.Forms.DialogResult.Cancel).ToString();
			this.Hide();
		}

		private void cmdOk_Click(Object eventSender, EventArgs eventArgs)
		{
			mReturnValue = ((int) System.Windows.Forms.DialogResult.OK).ToString();
			this.Hide();
		}

		private void cmdRetry_Click(Object eventSender, EventArgs eventArgs)
		{
			mReturnValue = ((int) System.Windows.Forms.DialogResult.Retry).ToString();
			this.Hide();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis#2080
		private void Form_Load()
		{

			string mysql = "";


			SqlDataReader rsLocalRec = null;

			this.Cursor = CursorHelper.CursorDefault;

			if (SystemVariables.gError_Id != 0)
			{
				mysql = "Select Module_Id, Error_Type, Error_Group ";
				mysql = mysql + " ," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Title" : "A_Title") + " as Title ";
				mysql = mysql + " ," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Error_Description" : "A_Error_Description") + " as Description ";
				mysql = mysql + " ," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Error_Reason" : "A_Error_Reason") + " as Reason ";
				mysql = mysql + " ," + ((SystemVariables.gPreferedLanguage == SystemVariables.Language.English) ? "L_Error_Solution" : "A_Error_Solution") + " as Solution ";
				mysql = mysql + " , Log_Error ";
				mysql = mysql + " from System_Error where Error_Id = " + SystemVariables.gError_Id.ToString();

				SqlCommand sqlCommand = new SqlCommand(mysql, SystemVariables.gConn);
				rsLocalRec = sqlCommand.ExecuteReader();


				if (rsLocalRec.Read())
				{

					if (Convert.ToDouble(rsLocalRec["Error_Group"]) == 1)
					{
						this.btnMore.Visible = true;
						lblRes.Visible = true;
						this.lblReason.Text = Convert.ToString(rsLocalRec["Reason"]);
						this.txtSolution.Text = Convert.ToString(rsLocalRec["Solution"]);
						this.txtModule.Text = SystemVariables.gModule_Name;
						this.txtLineNo.Text = SystemVariables.gLine_No;

					}

					this.Text = Convert.ToString(rsLocalRec["Title"]);
					this.lblError.Text = Convert.ToString(rsLocalRec["Description"]);

					if (Convert.ToDouble(rsLocalRec["Error_Type"]) == 16)
					{
						this.ImgCritical.Visible = true;
						this.cmdOk.Visible = true;

					}
					else if (Convert.ToDouble(rsLocalRec["Error_Type"]) == 48)
					{ 
						this.ImgExclamation.Visible = true;
						this.cmdOk.Visible = true;

					}
					else if (Convert.ToDouble(rsLocalRec["Error_Type"]) == 64)
					{ 
						this.ImgInformation.Visible = true;
						this.cmdOk.Visible = true;

					}
					else if (Convert.ToDouble(rsLocalRec["Error_Type"]) == 2)
					{ 
						this.ImgExclamation.Visible = true;
						this.cmdOk.Visible = true;
						this.cmdOk.Text = "&Abort";
						this.cmdCancel.Visible = true;
						this.cmdRetry.Visible = true;

					}
					else if (Convert.ToDouble(rsLocalRec["Error_Type"]) == 16384)
					{ 
						this.ImgQuestion.Visible = true;
						this.cmdOk.Visible = true;
						this.cmdCancel.Visible = true;

					}
					else if (Convert.ToDouble(rsLocalRec["Error_Type"]) == 1)
					{ 
						this.cmdOk.Visible = true;
						this.cmdCancel.Visible = true;

					}
					else if (Convert.ToDouble(rsLocalRec["Error_Type"]) == 0)
					{ 
						this.cmdOk.Visible = true;

					}
					else if (Convert.ToDouble(rsLocalRec["Error_Type"]) == 32)
					{ 
						this.ImgQuestion.Visible = true;
						this.cmdOk.Visible = true;
						this.cmdCancel.Visible = true;
						this.cmdRetry.Visible = true;

					}
					else if (Convert.ToDouble(rsLocalRec["Error_Type"]) == 5)
					{ 
						this.ImgExclamation.Visible = true;
						this.cmdCancel.Visible = true;
						this.cmdRetry.Visible = true;

					}
					else if (Convert.ToDouble(rsLocalRec["Error_Type"]) == 4)
					{ 
						this.cmdOk.Visible = true;
						this.cmdOk.Text = "&Yes";
						this.cmdCancel.Visible = true;
						this.cmdCancel.Text = "&No";

					}
					else if (Convert.ToDouble(rsLocalRec["Error_Type"]) == 3)
					{ 
						this.cmdOk.Visible = true;
						this.cmdOk.Text = "&No";
						this.cmdCancel.Visible = true;
						this.cmdRetry.Visible = true;
						this.cmdRetry.Text = "&Yes";
					}
					else
					{
						this.cmdOk.Visible = true;
						this.cmdCancel.Visible = true;
						this.cmdRetry.Visible = true;
					}

				}
				else
				{
					MessageBox.Show("No records found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}


			}
			else
			{
				lblError.Text = mErrorMessage;
				lblError.Visible = true;

				if (mButton == MsgBoxStyle.OkOnly)
				{
					this.cmdOk.Visible = true;
					this.ImgCritical.Visible = true;
				}
				else if (mButton == MsgBoxStyle.OkCancel)
				{ 
					this.cmdOk.Visible = true;
					this.cmdCancel.Visible = true;
				}
				else if (mButton == MsgBoxStyle.YesNo)
				{ 
					this.cmdOk.Visible = true;
					this.cmdOk.Text = "&No";
					this.cmdCancel.Visible = true;
					this.cmdRetry.Visible = true;
					this.cmdRetry.Text = "&Yes";
				}
				else if (mButton == MsgBoxStyle.YesNoCancel)
				{ 

				}
				else if (mButton == MsgBoxStyle.Critical)
				{ 
					this.cmdOk.Visible = true;
					this.ImgCritical.Visible = true;
				}
			}

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}