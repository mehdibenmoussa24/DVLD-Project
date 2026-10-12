using System;
using DVLD.Business;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmLogin : Form
    {
       
        public frmLogin()
        {
            InitializeComponent();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = User.FindByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (user != null)
            {

                if (chkRememberMe.Checked)
                {
                    //store username and password
                    Global.SaveCredential(Global.enCredentialType.Username, txtUserName.Text.Trim());
                    Global.SaveCredential(Global.enCredentialType.Password, txtPassword.Text.Trim());
                }
                else
                {
                    //store empty username and password
                    Global.SaveCredential(Global.enCredentialType.Username, "");
                    Global.SaveCredential(Global.enCredentialType.Password, "");

                }

                //incase the user is not active
                if (!user.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Global.CurrentUser = user;
                this.Hide();
                Main frm = new Main(this);
                frm.ShowDialog();


            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (Global.GetStoredCredential(Global.enCredentialType.Username, ref UserName) && Global.GetStoredCredential(Global.enCredentialType.Password, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                if(!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
                    chkRememberMe.Checked = true;
                else
                    chkRememberMe.Checked = false;
            }
            else
                chkRememberMe.Checked = false;

        }
    }
}
