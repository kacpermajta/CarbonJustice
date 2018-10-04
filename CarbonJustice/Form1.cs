using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarbonJustice
{

    public partial class Form1 : Form
    {
        


        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mechanics.Initialize(this);
            Mechanics.notificationPanel = new Panel();
            Mechanics.notificationPanel.AutoScroll = true;

            Mechanics.notificationPanel.Location = new System.Drawing.Point(220, 30);

            Mechanics.notificationPanel.Name = "notificationPanel";

            Mechanics.notificationPanel.Size = new System.Drawing.Size(860, 600);

            Mechanics.notificationPanel.TabIndex = 5;
            Mechanics.notificationPanel.BackColor = Color.FromName("ActiveCaption");
            this.Controls.Add(Mechanics.notificationPanel);

            /*            Mechanics.notificationPanel.AutoScroll = true;
            Mechanics.notificationPanel.Location = new Point(220, 30);
            Mechanics.notificationPanel.Size = new Size(600, 500);*/


            Mechanics.CrimePanel = new Panel();
            Mechanics.CrimePanel.AutoScroll = true;

            Mechanics.CrimePanel.Location = new System.Drawing.Point(1095, 32);

            Mechanics.CrimePanel.Name = "crimePanel";

            Mechanics.CrimePanel.Size = new System.Drawing.Size(252, 317);//1347

//            Mechanics.CrimePanel.TabIndex = 5;
            Mechanics.CrimePanel.BackColor = Color.FromName("ActiveCaption");



            this.Controls.Add(Mechanics.CrimePanel);

            Mechanics.notificationPanel.Visible = true;
 //           Mechanics.notificationPanel.AutoScroll = true;
            Mechanics.RefreshNotifications();
            Mechanics.RefreshCrimes();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            Mechanics.notificationPanel = new Panel();

            Mechanics.notificationPanel.Location = new System.Drawing.Point(220, 30);

            Mechanics.notificationPanel.Name = "notificationPanel";

            Mechanics.notificationPanel.Size = new System.Drawing.Size(600, 500);

            Mechanics.notificationPanel.TabIndex = 5;
            Mechanics.notificationPanel.BackColor = Color.FromName("ActiveCaption");

            /*            Mechanics.notificationPanel.AutoScroll = true;
            Mechanics.notificationPanel.Location = new Point(220, 30);
            Mechanics.notificationPanel.Size = new Size(600, 500);
            this.Controls.Add(Mechanics.notificationPanel);
            Mechanics.notificationPanel.Visible = true;
            */
        }


        public void Rebelion(Mechanics.Faction guilty)
        {
            Mechanics.notificationPanel.Controls.Clear();
            
            //activeFaction = guilty;
            Lost popup = new Lost(guilty.name);
            DialogResult dialogresult = popup.ShowDialog();

            if (dialogresult == DialogResult.OK)
            {
                //                Console.WriteLine("You clicked OK");
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                //                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();
            guilty.Tame(400f);
            Mechanics.mayor();
            Mechanics.RefreshNotifications();

        }


        private void buttonDis_click(object sender, EventArgs e)
        {
            Mechanics.activeDistrict = Convert.ToInt32((sender as Button).Tag);
            DistrictPopup popup = new DistrictPopup(this);
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
//                Console.WriteLine("You clicked OK");
            }
            else if (dialogresult == DialogResult.Cancel)
            {
//                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();
        }

        public void buttonCrime_click(object sender, EventArgs e)
        {
            Mechanics.activeCrime = Convert.ToInt32((sender as Button).Tag);
            CrimeInf popup = new CrimeInf();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                //                Console.WriteLine("You clicked OK");
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                //                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();

        }


        private void buttonFac_click(object sender, EventArgs e)
        {
            Mechanics.activeFaction = Convert.ToInt32((sender as Button).Tag);
            FactionInfo popup = new FactionInfo(this);
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                //                Console.WriteLine("You clicked OK");
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                //                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
           
        }
        private void panel1_init(object sender, PaintEventArgs e)
        {
            Panel thisPanel = (Panel)sender;
            Mechanics.notificationPanel = thisPanel;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel thisPanel = (Panel)sender;
            thisPanel.Controls.Clear();
            int i = Mechanics.GameLog.Count;
            foreach (Mechanics.Notification entry in Mechanics.GameLog)
            {
                i--;

                entry.Display(i, thisPanel);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mechanics.Factions[0].Tame(-2000f);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            instrukcja popup = new instrukcja();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                //                Console.WriteLine("You clicked OK");
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                //                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
        }
    }


}
