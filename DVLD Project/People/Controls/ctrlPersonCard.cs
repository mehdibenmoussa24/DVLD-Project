using DVLD.Business;
using DVLD_Project.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class ctrlPersonCard : UserControl
    {
        private Person _Person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public Person SelectedPersonInfo
        {
            get { return _Person; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            pbPersonalPicture.Image = _Person.Gender == 0 ? Resources.Man : Resources.Female;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    pbPersonalPicture.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void _FillPersonInfo()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            _PersonID = _Person.PersonID;
            lblName.Text = _Person.FullName.ToString();
            lblNationalNo.Text = _Person.NationalNo.ToString();
            lblGender.Text = _Person.Gender == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email.ToString();
            lblAddress.Text = _Person.Address.ToString();
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lblPhone.Text = _Person.Phone.ToString();
            lblCountry.Text = Country.Find(_Person.NationalityCountryID).CountryName;
            _LoadPersonImage();
        }
        public void ResetPersonInfo()
        {
            lblPersonID.Text = "?????";
            lblName.Text = "?????";
            lblNationalNo.Text = "?????";
            lblGender.Text = "?????";
            lblEmail.Text = "?????";
            lblAddress.Text = "?????";
            lblDateOfBirth.Text = "?????";
            lblPhone.Text = "?????";
            lblCountry.Text = "?????";
            pbPersonalPicture.Image = Resources.Man;
        }

        public void LoadPersonData(int PersonID)
        {
            _Person = Person.Find(PersonID);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with Person ID. = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();

        }

        public void LoadPersonData(string NationalNo)
        {
            _Person = Person.Find(NationalNo);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        private void btnEditPersonInfo_Click(object sender, EventArgs e)
        {
            if (_Person != null)
            {
                Form frm = new frmAddUpdatePerson(_Person.PersonID);
                frm.ShowDialog();
            }
        }
         
    }
}
