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
    public partial class Lost : Form
    {
        public Lost(string name)
        {
            InitializeComponent();
            Label newText = new Label();
            newText.Text = "Frakcja "+ name + " wszczęła zamieszki na terenie całego miasta. Wszystkie siły wojska i policji zostały wysłane do pacyfikacji. Od poprzedniego incydentu minęło "+Mechanics.lifetime.ToString()+" dni.";
            newText.Location = new Point(20, 40);
            newText.Size = new Size(660, 100);
            newText.BackColor = Color.White;
            Controls.Add(newText);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Mechanics.Initialize(Mechanics.mainForm);
            return;
        }
    }
}
