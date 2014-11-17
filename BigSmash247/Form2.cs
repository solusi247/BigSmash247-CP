using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BigSmash247
{
    public partial class frmYarnError : Form
    {
        // http://stackoverflow.com/questions/12469423/calling-a-method-from-another-form-in-c-sharp
        private Form1 frm1;

        public frmYarnError()
        {
            InitializeComponent();
        }

        public frmYarnError(Form1 otherForm)
        {
            InitializeComponent();
            this.frm1 = otherForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.frm1.refreshYarnStatus();
        }
    }
}
