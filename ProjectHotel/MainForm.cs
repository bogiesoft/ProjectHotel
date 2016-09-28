using Newtonsoft.Json;
using ProjectHotel.Models;
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
    public partial class MainForm : Form
    {
        Hoteloverzicht Overzicht = new Hoteloverzicht();
        public MainForm()
        {
            List<Hoteloverzicht> Overzicht = JsonConvert.DeserializeObject<List<Hoteloverzicht>>(File.ReadAllText(@"..\..\..\Hotel.json"));
            if (!File.Exists(@"..\..\..\config.json"))
            {
                Instellingen Instellingen = new Instellingen();
                File.WriteAllText(@"..\..\..\config.json", JsonConvert.SerializeObject(Instellingen));
            }
            InitializeComponent();
            InitializeHotel();
        }
        
        /// <summary>
        /// Methode waarin het hotel wordt aangemaakt en gekoppeld.
        /// </summary>
        void InitializeHotel()
        {
            List<Kamer> kamers = new List<Kamer>(); //Lijst met kamers om aan de receptie te geven.

            for(int i = 1; i < 5; i++)
            {
                kamers.Add(new Kamer(i)); //Vult de lijst met kamers met 4 kamers.
            }

            Receptie lobby = new Receptie(kamers); //Maakt de receptie aan

            //Maakt de gangen aan
            Gang a_1 = new Gang(1);
            Gang a_2 = new Gang(2);
            Gang a_3 = new Gang(3);
            Gang a_4 = new Gang(4);


            //Koppeling van alle hotel ruimtes aan elkaar
            #region Koppeling

            lobby.buren.Add(a_1, 1); // Lobby  ---> Gang_1
            a_1.buren.Add(lobby, 1); // Lobby  <--- Gang_1

            a_1.buren.Add(a_2, 1); // Gang_1 ---> Gang_2
            a_2.buren.Add(a_1, 1); // Gang_1 <--- Gang_2
            a_1.buren.Add(kamers[0], 1); // Gang_1 ---> Kamer_1
            kamers[0].buren.Add(a_1, 1); // Gang_1 <--- Kamer_1

            a_2.buren.Add(a_3, 1); // Gang_2 ---> Gang_3
            a_3.buren.Add(a_2, 1); // Gang_2 <--- Gang_3
            a_2.buren.Add(kamers[1], 1); // Gang_2 ---> Kamer_2
            kamers[1].buren.Add(a_2, 1); // Gang_2 <--- Kamer_2

            a_3.buren.Add(a_4, 1); // Gang_3 ---> Gang_4
            a_4.buren.Add(a_3, 1); // Gang_3 <--- Gang_4
            a_3.buren.Add(kamers[2], 1); // Gang_3 ---> Kamer_3
            kamers[2].buren.Add(a_3, 1); // Gang_3 <--- Kamer_3

            a_4.buren.Add(kamers[3], 1); // Gang_4 ---> Kamer_4
            kamers[3].buren.Add(a_4, 1); // Gang_4 <--- Kamer_4

            #endregion

            #region DijkstraTest
            //Er komt een gast
            Gast gast = new Gast();
            gast.locatie = lobby; //begint in de lobby
            gast.kamer = kamers[1]; //krijgt een kamer

            //Gast gaat naar kamer en weer terug
            gast.PrintPath(gast.kamer);
            gast.PrintPath(lobby);

            //Gast krijgt andere kamer en gaat weer lopen
            gast.kamer = kamers[3];
            gast.PrintPath(gast.kamer);
            gast.PrintPath(lobby);
            #endregion
        }

        void Print()
        {
        }
        
        private void InstellingB_Click(object sender, EventArgs e)
        {

            InstellingenForm Instelling = new InstellingenForm();
            Instelling.ShowDialog();
        }
    }
}
