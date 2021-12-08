using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Machine_Tools
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = $"Время: {DateTime.Now.ToString("%H:%m:%s")}";
            label4.Text = $"Дата: {DateTime.Now.ToString("dd:MM:yyyy")}";
        }
    }
}
