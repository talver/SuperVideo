using Ruihit.Controls;
using SuperVideo.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperVideo.view
{
    public partial class frmPassword : RStyleBaseForm
    {
        public string Category { get; set; }
        public string FileName { get; set; }
        public string Password { get; private set; }
        public bool IsPasswordValid { get; private set; }

        public frmPassword(string category, string file)
        {
            Category = category;
            FileName = file;
            InitializeComponent();
            MinimizeBox = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PasswordManegment pm = new PasswordManegment(txtPassword.Text);
            Password = pm.Password;
            IsPasswordValid = pm.IsPasswordValid(FileName);
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {
        }
    }
}
