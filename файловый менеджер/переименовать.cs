using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace файловый_менеджер
{
    public partial class переименовать : Form
    {
        string путь2;
        ListBox ListBox2;
        string полупуть;
        public переименовать(string путь1, ListBox listBox1, string textBox1)
        {
            путь2 = путь1;
            ListBox2 = listBox1;
            полупуть = textBox1;

            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String имя = textBox1.Text;
            if (File.Exists(путь2))
            {
                File.Move(путь2, полупуть + "\\" + имя + Path.GetExtension(путь2));
                ListBox2.Items.RemoveAt(ListBox2.SelectedIndex);
                ListBox2.Items.Add(имя + Path.GetExtension(путь2));
                Close();
            }
            else
            {
                Directory.Move(путь2, полупуть + "\\" + имя);//перемещает файл в новое месторасположение 
                ListBox2.Items.RemoveAt(ListBox2.SelectedIndex);
                ListBox2.Items.Add(  имя );
                Close();
            }

        }
    }
}
