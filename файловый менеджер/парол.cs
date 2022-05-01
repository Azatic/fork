using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace файловый_менеджер
{
    public partial class парол : Form
    {
        пароли настройки= new пароли();
        public парол()
        {
            InitializeComponent();
            настройки = пароли.выгрузка();
            textBox1.Text = настройки.пароль;
            textBox2.Text = настройки.логин;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            настройки.пароль = textBox1.Text;
            настройки.логин = textBox2.Text;
            настройки.сохранить();
            Form1 форма = new Form1();
            форма.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
