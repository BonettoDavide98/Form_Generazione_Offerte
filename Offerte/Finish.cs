using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Offerte
{
    public partial class Finish : Form
    {
        public Finish()
        {
            InitializeComponent();
        }

        private void btnEsci_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Close();
            }


        }

        private void btnContinua_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
