using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class LoadingForm : Form
    {
        private Form nextForm;

        public LoadingForm(Form formToOpen)
        {
            InitializeComponent();
            nextForm = formToOpen;
        }

        private void siticoneLabel1_Click(object sender, EventArgs e)
        {

        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            siticoneRadialProgressBar1.Minimum = 0;
            siticoneRadialProgressBar1.Maximum = 100;
            siticoneRadialProgressBar1.Value = 0;

            timer1.Interval = 30; // скорость
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (siticoneRadialProgressBar1.Value < 100)
            {
                siticoneRadialProgressBar1.Value += 4;
            }
            else
            {
                timer1.Stop();
                nextForm.Show();
                this.Hide();
            }
        }
    }
}
