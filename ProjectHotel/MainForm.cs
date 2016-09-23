using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectHotel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void InstellingB_Click(object sender, EventArgs e)
        {

            Instellingen Instelling = new Instellingen(2, 1, 50 ,1);
            Instelling.ShowDialog();
        }
    }
}
