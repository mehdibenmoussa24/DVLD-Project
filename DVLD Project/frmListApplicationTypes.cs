using System;
using System.Collections.Generic;
using DVLD.Business;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmListApplicationTypes : Form
    {
        private DataTable _dtApplicationTypes;

        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtApplicationTypes = ApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = _dtApplicationTypes;

            lblRecordsCount.Text = _dtApplicationTypes.Rows.Count.ToString();

            dgvApplicationTypes.Columns[0].HeaderText = "ID";
            dgvApplicationTypes.Columns[0].Width = 110;

            dgvApplicationTypes.Columns[1].HeaderText = "Title";
            dgvApplicationTypes.Columns[1].Width = 400;

            dgvApplicationTypes.Columns[2].HeaderText = "Fees";
            dgvApplicationTypes.Columns[2].Width = 100;
        }
    }
}
