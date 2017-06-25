using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database
{
    public partial class LicenseActivate : Form
    {
        public LicenseActivate(string code)
        {
            InitializeComponent();
            textBox1.Text = code;
        }

    }
}
