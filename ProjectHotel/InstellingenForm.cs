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
            var Velden = Controls.OfType<TextBox>();
            bool VeldenCorrect = true;
            foreach (var item in Velden)
            {
                if (string.IsNullOrWhiteSpace(item.Text) || !item.Text.All(char.IsDigit))
                {
                    VeldenCorrect = false;
                    FoutMelding.SetError(item, "Dit veld is incorrect ingevuld");
                }
            }
            if(VeldenCorrect == true)
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
