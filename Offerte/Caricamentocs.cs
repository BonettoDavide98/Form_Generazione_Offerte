using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Offerte
{
    public partial class Caricamentocs : Form
    {
        int i = 0;
        public Caricamentocs()
        {
            InitializeComponent();

            for (i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
            }
        }        
    }
}
