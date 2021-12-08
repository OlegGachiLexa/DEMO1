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
    public partial class Form2 : Form
    {
        public List<Авторизация> login = new List<Авторизация>();

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = $"Время: {DateTime.Now.ToString("%H:%m:%s")}";
            label4.Text = $"Дата: {DateTime.Now.ToString("dd:MM:yyyy")}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fetchLogin();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            bool auth = this.login.Exists(user => user.Электронная_почта == textBox1.Text &&
                                                     user.Пароль == textBox2.Text);

            MessageBox.Show(auth.ToString());

        }

        public void fetchLogin()
        {
            using (Model1 db = new Model1())
            {
                this.login.Clear();
                foreach (Авторизация user in db.Авторизация)
                {
                    this.login.Add(user);
                }
            }
        }

    }
}
