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
    public partial class DistrictPopup : Form
    {
//        Form1 mainWin;
        public DistrictPopup(Form1 form1)
        {
            InitializeComponent();

//            mainWin = form1;
        }



        private void DistrictPopup_Load(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Mechanics.Districts[Mechanics.activeDistrict].search();
        }

        private void buttonRepress_Click(object sender, EventArgs e)
        {
            Mechanics.Districts[Mechanics.activeDistrict].repress();
        }

        private void buttonPropag_Click(object sender, EventArgs e)
        {
            Mechanics.Districts[Mechanics.activeDistrict].propaganda();
        }
    }
}
