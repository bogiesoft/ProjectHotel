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
        Instellingen Instellingen = new Instellingen();
        public InstellingenForm()
        {
            InitializeComponent();
            FormVoorbereiden();
        }
        private void FormVoorbereiden()
        {
            try
            {
                Instellingen = JsonConvert.DeserializeObject<Instellingen>(File.ReadAllText(@"..\..\..\config.json"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Het bestand kon niet gevonden worden" + e);
                File.WriteAllText(@"..\..\..\config.json", JsonConvert.SerializeObject(Instellingen));
            }
            TijdeenCB.SelectedItem = Instellingen.Tijdseenheid.ToString();
            SchoonTB.Text = Instellingen.Schoonmaakduur.ToString();
            BiosTB.Text = Instellingen.Bioscoopduur.ToString();
            TrapTB.Text = Instellingen.Trapduur.ToString();
            DoodTB.Text = Instellingen.Doodsduur.ToString();
            RestaurantTB.Text = Instellingen.Restaurantduur.ToString();
            SchoonnoodTB.Text = Instellingen.Schoonnoodduur.ToString();
        }

        private void AnnuleerB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpslaanB_Click(object sender, EventArgs e)
        {
            if (!SchoonTB.Text.All(char.IsDigit) || !BiosTB.Text.All(char.IsDigit) || !TrapTB.Text.All(char.IsDigit) || !DoodTB.Text.All(char.IsDigit) || 
                !RestaurantTB.Text.All(char.IsDigit) || !SchoonnoodTB.Text.All(char.IsDigit) || SchoonTB.Text.Equals("") || BiosTB.Text.Equals("") || 
                TrapTB.Text.Equals("") || DoodTB.Text.Equals("") || RestaurantTB.Text.Equals("") || SchoonnoodTB.Text.Equals("") || TijdeenCB.Text.Equals(""))
            {
                MessageBox.Show("Vul alle velden correct in aub");
            }
            else
            {
                Instellingen.Tijdseenheid = Double.Parse(TijdeenCB.Text);
                Instellingen.Schoonmaakduur = Int32.Parse(SchoonTB.Text);
                Instellingen.Bioscoopduur = Int32.Parse(BiosTB.Text);
                Instellingen.Trapduur = Int32.Parse(TrapTB.Text);
                Instellingen.Doodsduur = Int32.Parse(DoodTB.Text);
                Instellingen.Restaurantduur = Int32.Parse(RestaurantTB.Text);
                Instellingen.Schoonnoodduur = Int32.Parse(SchoonnoodTB.Text);
                File.WriteAllText(@"..\..\..\config.json", JsonConvert.SerializeObject(Instellingen));
                this.Close();
            }
        }
    }
}
