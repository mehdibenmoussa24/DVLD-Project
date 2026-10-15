using System;
using DVLD.Business;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmTakeTest : Form
    {
        private int _AppointmentID;
        private TestType.enTestType _TestType;

        private int _TestID = -1;


        public frmTakeTest(int AppointmentID, TestType.enTestType TestType)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _TestType = TestType;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           

        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            
        }
    }
}
