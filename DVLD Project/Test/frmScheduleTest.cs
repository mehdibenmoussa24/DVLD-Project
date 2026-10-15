using System;
using DVLD.Business;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private TestType.enTestType _TestTypeID = TestType.enTestType.VisionTest;
        private int _AppointmentID = -1;

        public frmScheduleTest(int LocalDrivingLicenseApplicationID, TestType.enTestType TestTypeID, int AppointmentID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            crlScheduleTest1.TestTypeID = _TestTypeID;
            crlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);
        }
    }
}
