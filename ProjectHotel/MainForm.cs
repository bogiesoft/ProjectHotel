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
    public partial class MainForm : Form
    {
        public MainForm()
        {
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


            //Koppelt de aangemaakte gangen aan elkaar en de lobby.
            #region Koppeling

            lobby.buren.Add(a_1, 1);

            a_1.buren.Add(a_2, 1);
            a_1.buren.Add(kamers[0], 0);

            a_2.buren.Add(a_3, 1);
            a_2.buren.Add(kamers[1], 0);

            a_3.buren.Add(a_4, 1);
            a_3.buren.Add(kamers[2], 0);

            a_4.buren.Add(kamers[3], 0);

            #endregion

            //#region DijkstraTest
            //Gast gast = new Gast();
            //gast.locatie = lobby;
            //gast.kamer = kamers[1];
            //gast.PrintPath();
            //#endregion
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
