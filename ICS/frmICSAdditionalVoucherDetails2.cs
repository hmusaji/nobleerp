
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;



namespace Xtreme
{
	internal partial class frmICSAdditionalVoucherDetails2
		: System.Windows.Forms.Form
	{

		//''Notes: 08-mar-2006
		//''This form will only be called during inventory transaction when
		//''preference final_payment screen is enabled on company and voucher level
		//''The inventory transaction should be cash.
		//''The cash_cd and credit_card_cd are saved in icsadditionalvouchedetails table
		//''the cash_cd on icsadditionalvouchedetails will be taken from its parent voucher eg. sales
		//''

		private SystemICSConstants.ShowOptions mPostOptionType = (SystemICSConstants.ShowOptions) 0;

		private const int mNormalHeight = 3735;
		private const int mAdvancedHeight = 4695;

		private const string mAdvancedCaption = "&Advanced Mode >>";
		private const string mNormalCaption = "<< &Normal Mode";

		private const int lcCashAmt = 7;
		private const int lcCreditCardAmt = 9;
		private const int lcTotalAmt = 3;

		private const int conTxtCashGLAC = 2;
		private const int conTxtCreditCardGLAC = 3;
		private const int conTxtCreditVoucherAC = 1;
		private const int conTxtCreditVoucherNo = 0;

		private const int conNTxtChangeAmt = 0;
		private const int conNTxtCashAmt = 1;
		private const int conNTxtCreditCardAmt = 2;
		private const int conNTxtVoucherAmt = 3;
		private const int conNTxtTotalAmt = 4;
		private const int conNTxtAmtReceived = 5;
		private const int conNTxtCreditVoucherAmt = 6;

		private const int conOptCredit = 0;
		private const int conOptCash = 1;

		private decimal mNetVoucherAmt = 0;
		private int mEntryId = 0;
		private int mButtonPressed = 0;
		private const int ctlAdvancedModeDetailsIndex = 6;
		public frmICSAdditionalVoucherDetails2()
{
InitializeComponent();
}
}
}
