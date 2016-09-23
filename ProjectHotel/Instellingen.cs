using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectHotel
{
    public partial class Instellingen : Form
    {
        public int Schoonmaakduur { get; private set; }
        public int Bioscoopduur { get; private set; }
        public int Trapduur { get; private set; }
        public int Doodsduur { get; private set; }
        public Instellingen(int schoonmaak, int bioscoop, int trap, int dood)
        {
            //string text = File.ReadAllText(@"C:\Users\Andre\Documents\Visual Studio 2015\Projects\CsharpDll\movie.json");
            InitializeComponent();
            SchoonTB.Text = schoonmaak.ToString();
            BiosTB.Text = bioscoop.ToString();
            TrapTB.Text = trap.ToString();
            DoodTB.Text = dood.ToString();
        }

        private void AnnuleerB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpslaanB_Click(object sender, EventArgs e)
        {
            if (!SchoonTB.Text.All(char.IsDigit) || !BiosTB.Text.All(char.IsDigit) || !TrapTB.Text.All(char.IsDigit) || !DoodTB.Text.All(char.IsDigit) || SchoonTB.Text.Equals("") || BiosTB.Text.Equals("") || TrapTB.Text.Equals("") || DoodTB.Text.Equals(""))
            {
                MessageBox.Show("Vul alle velden correct in aub");
            }
            else
            {

                Schoonmaakduur = Int32.Parse(SchoonTB.Text);
                Bioscoopduur = Int32.Parse(BiosTB.Text);
                Trapduur = Int32.Parse(TrapTB.Text);
                Doodsduur = Int32.Parse(DoodTB.Text);
                this.Close();
            }
        }
    }
}
