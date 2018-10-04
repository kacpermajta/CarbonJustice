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
    public partial class CrimeInf : Form
    {
        public CrimeInf()
        {
            InitializeComponent();
        }

        private void CrimeInf_Load(object sender, EventArgs e)
        {
            Mechanics.Crime thisCrime = Mechanics.CrimeScene[Mechanics.activeCrime];
            Label newText = new Label();
            newText.Text = "Powiązania frakcyjne:";
            newText.Location = new Point(20, 20);
            newText.Size = new Size(210, 20);
            newText.BackColor = Color.White;
            Controls.Add(newText);

            newText = new Label();
            newText.Text = Mechanics.Factions[thisCrime.suspect].name+ " [podejrzani]";
            newText.Location = new Point(30, 60);
            newText.Size = new Size(210, 20);
            newText.BackColor = Color.White;
            Controls.Add(newText);

            newText = new Label();
            newText.Text = Mechanics.Factions[thisCrime.victim].name + " [ofiara]";
            newText.Location = new Point(30, 82);
            newText.Size = new Size(210, 20);
            newText.BackColor = Color.White;
            Controls.Add(newText);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mechanics.CrimeScene[Mechanics.activeCrime].solve();
        }
    }
}
