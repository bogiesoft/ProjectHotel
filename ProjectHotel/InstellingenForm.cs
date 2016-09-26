using Newtonsoft.Json;
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
    public partial class InstellingenForm : Form
    {
        
        public InstellingenForm()
        {
            Instellingen Instelling = JsonConvert.DeserializeObject<Instellingen>(File.ReadAllText(@"..\..\..\config.json"));
            InitializeComponent();
            SchoonTB.Text = Instelling.Schoonmaakduur.ToString();
            BiosTB.Text = Instelling.Bioscoopduur.ToString();
            TrapTB.Text = Instelling.Trapduur.ToString();
            DoodTB.Text = Instelling.Doodsduur.ToString();
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
                Instellingen Instellingen = new Instellingen();
                Instellingen.Schoonmaakduur = Int32.Parse(SchoonTB.Text);
                Instellingen.Bioscoopduur = Int32.Parse(BiosTB.Text);
                Instellingen.Trapduur = Int32.Parse(TrapTB.Text);
                Instellingen.Doodsduur = Int32.Parse(DoodTB.Text);
                File.WriteAllText(@"..\..\..\config.json", JsonConvert.SerializeObject(Instellingen));
                this.Close();
            }
        }
    }
}
