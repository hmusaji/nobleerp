
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;




namespace Xtreme
{
    internal partial class frmICSAlternateUnit
        : System.Windows.Forms.Form
    {

        private int mProductCode = 0;

        private const int cGrdUnitEntryId = 0;
        private const int cGrdLineNo = 1;
        private const int cGrdBaseQty = 2;
        private const int cGrdBaseSymbol = 3;
        private const int cGrdEqual = 4;
        private const int cGrdAltQty = 5;
        private const int cGrdAltSymbol = 6;
        private const int cGrdSalesRate = 7;

        private const int conMaxArrayValue = 7;

        //public XArrayHelper aAdditionalVoucherDetails = null;
        public string mBaseUnitSymbol = "";
        public frmICSAlternateUnit()
        {
            InitializeComponent();
        }
    }
}
