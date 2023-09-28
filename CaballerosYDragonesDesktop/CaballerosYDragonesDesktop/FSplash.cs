using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaballerosYDragonesDesktop
{
    public partial class FSplash : Form
    {
        public FSplash(int seg)
        {
            InitializeComponent();
            timerSplash.Interval = seg * 1000;
            timerSplash.Start();
        }

        private void FSplash_Load(object sender, EventArgs e)
        {
            pbSplash.Controls.Add(label1);
        }

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            timerSplash.Stop();
            this.Close();
        }
    }
}
