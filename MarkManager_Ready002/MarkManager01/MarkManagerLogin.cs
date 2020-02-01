using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkManager01
{
    public partial class MarkManagerLogin : Form 
    {
        public MarkManagerLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string user, pass; //creating static password and username
            user = textUser.Text;
            pass = textPass.Text;
            if(user=="admin" && pass == "admin")
            {
                MarkManager2018 login2 = new MarkManager2018(); // loads form2 (markmanager2018) if credentials are correct
                login2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Credentials!\nTry again!");
                return;
            }
            

        }

        private void label1_Click(object sender, EventArgs e) //forgot password help box
        {
            MessageBox.Show("Username: admin\nPassword: admin");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
