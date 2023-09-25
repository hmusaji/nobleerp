
using System;
using System.Windows.Forms;
using UpgradeHelpers;
using UpgradeHelpers.Gui;

namespace Xtreme
{
	internal partial class frmSysReportDesign
		: System.Windows.Forms.Form
	{

		public clsReportDefinition oReportProperties = null;
		public clsAccessAllowed UserAccess = null;

		private int mReportID = 0;
		private int mRecordCount = 0;
		private int mIsDashboard = 0;

		private const string mColumnPrefix = "Column";
		public frmSysReportDesign()
{
InitializeComponent();
} 
 public  void frmSysReportDesign_old()
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
			
			InitExtendedProperties();
		}
		void InitExtendedProperties()
		{
			this.grdReportDesign.setScrollTips(false);
			this.grdReportHeader.setScrollTips(false);
		}



		public int ReportID
		{
			get
			{
				return mReportID;
			}
		}


		public bool Dashboard
		{
			get
			{
				return mIsDashboard != 0;
			}
		}


		public clsAccessAllowed SetReportAccess
		{
			set
			{
				UserAccess = value;
			}
		}


		public int RecordCount
		{
			set
			{
				mRecordCount = value;
			}
		}


		public string ParametersSetSQL
		{
			set
			{
				oReportProperties.ParameterSetSQL = value;
			}
		}


		public string ReportFromDate
		{
			set
			{
				oReportProperties.ReportFromDate = value;
			}
		}


		public string ReportToDate
		{
			set
			{
				oReportProperties.ReportToDate = value;
			}
		}


		public string ReportTitleFilter
		{
			set
			{
				oReportProperties.ReportTitleFilterText = value;
			}
		}


		public string SetFixedWhereClause
		{
			set
			{
				oReportProperties.SetFixedWhereClause = value;
			}
		}


		public bool ShowReportOptionsFirst
		{
			get
			{
				bool tempBool = false;
				string auxVar = oReportProperties.GetReportInformation("show_report_options_first");
				return (Boolean.TryParse(auxVar, out tempBool)) ? tempBool : Convert.ToBoolean(Double.Parse(auxVar));
			}
		}


		public string ReportName
		{
			get
			{
				if (SystemVariables.gPreferedLanguage == SystemVariables.Language.English)
				{
					return oReportProperties.GetReportInformation("l_report_name");
				}
				else
				{
					return oReportProperties.GetReportInformation("a_report_name");
				}
			}
		}


		public void SetReportID(int pNewReportID, int pReportAliasID = 0, bool IsDashboard = false)
		{
			mReportID = pNewReportID;
			mIsDashboard = (IsDashboard) ? -1 : 0;
			if (!oReportProperties.ChangeCurrentReportInformation(pNewReportID, pReportAliasID))
			{
				oReportProperties.SaveReportInformation(mReportID, mIsDashboard != 0);
			}
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				SystemMenu.SetMeCurrentInWindowList(Conversion.Str(this.Handle.ToInt32()));
			}
		}

		private void Form_Initialize()
		{
			oReportProperties = new clsReportDefinition();
			oReportProperties.AttachObjects(this, grdReportDesign, grdReportHeader, vspReportPrinter, DockingPaneManager); //, tcbSystemReport
		}

		private void btnFormToolBar_Click(int Index)
		{
			oReportProperties.ToolBarButtonClick(Index);
		}

		public void CloseForm()
		{
			this.Close();
			oReportProperties = null;
		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			oReportProperties = null;
			UserAccess = null;

			SystemMenu.RemoveMeFromWindowList(Conversion.Str(this.Handle.ToInt32()));
		}

		public void ToolBarButtonClick(int KeyIndex)
		{
			oReportProperties.ToolBarButtonClick(KeyIndex);
		}
	}
}