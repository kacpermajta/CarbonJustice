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
    public partial class FactionInfo : Form
    {
        public FactionInfo(Form1 form1)
        {
            InitializeComponent();
        }

        private void FactionInfo_Load(object sender, EventArgs e)
        {
            Label newText = new Label();
            newText.Text = "Frakcja " + Mechanics.Factions[Mechanics.activeFaction].name;
            newText.Location = new Point(20, 20);
            newText.Size = new Size(210, 20);
            newText.BackColor = Color.White;
            Controls.Add(newText);

            for (int i=0; i<Mechanics.numDistricts; i++)
            {
                newText = new Label();
                newText.Text = StringValues.districts[i] + ": ";
                newText.Location = new Point(20, 90+ 32 * i);
                newText.Size = new Size(160, 20);
                newText.BackColor = Color.White;
                Controls.Add(newText);
                newText = new Label();
                newText.Text =  Mechanics.Districts[i].members[Mechanics.activeFaction] + " członków";
                newText.Location = new Point(190, 90 + 32 * i);
                newText.Size = new Size(110, 20);
                newText.BackColor = Color.White;
                Controls.Add(newText);




            }
            newText = new Label();
            newText.Text = "Łączna Liczba:";
            newText.Location = new Point(390, 90);
            newText.Size = new Size(160, 20);
            newText.BackColor = Color.White;
            Controls.Add(newText);
            newText = new Label();
            newText.Text = Mechanics.Factions[Mechanics.activeFaction].members.ToString();
            newText.Location = new Point(410, 122);
            newText.TextAlign = ContentAlignment.MiddleCenter;
            newText.Size = new Size(160, 20);
            newText.BackColor = Color.White;
            Controls.Add(newText);

            newText = new Label();
            newText.Text = "Bojowość*:";
            newText.Location = new Point(390, 160);
            newText.Size = new Size(160, 20);
            newText.BackColor = Color.White;
            Controls.Add(newText);
            newText = new Label();
            newText.Text = ((Mechanics.Factions[Mechanics.activeFaction].battleReady+1000f)/100).ToString("0.#");
            newText.Location = new Point(410, 192);
            newText.TextAlign = ContentAlignment.MiddleCenter;
            newText.Size = new Size(160, 20);
            newText.BackColor = Color.White;
            Controls.Add(newText);

            newText = new Label();
            newText.Text = "Zadowolenie*:";
            newText.Location = new Point(390, 230);
            newText.Size = new Size(160, 20);
            newText.BackColor = Color.White;
            Controls.Add(newText);
            newText = new Label();
            newText.Text = ((Mechanics.Factions[Mechanics.activeFaction].happiness + 1000f)/ 100).ToString("0.#");
            newText.Location = new Point(410, 262);
            newText.TextAlign = ContentAlignment.MiddleCenter;
            newText.Size = new Size(160, 20);
            newText.BackColor = Color.White;
            Controls.Add(newText);


            newText = new Label();
            newText.Text = "*Współczynniki zgodne z socjologiczną teorią Jarzębskiego.  Wartości podane w rozszerzonej skali Wechslera, 0-20. Pamiętaj, wartość 20 przy współczynniku Bojowość grozi buntem frakcji.";
            newText.Location = new Point(390, 360);
            newText.Size = new Size(160, 170);
           
            Controls.Add(newText);



        }
    }
}
