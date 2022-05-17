using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Ionic.Zip;

namespace файловый_менеджер
{
    public partial class Form1 : Form
    {
        private string путь1;

        private void Print (DirectoryInfo[] dir, FileInfo[] fil)
        {

            foreach (var i in dir)//вывод папок
            {
                listBox1.Items.Add(i.Name);
            }
            foreach (var i in fil)
            {
                listBox1.Items.Add(i.Name);
            }
        }
        private void инициализация() 
        {
            DriveInfo [] диски = DriveInfo.GetDrives(); // возвращает массив дисков 
            textBox1.Text = диски[0].Name; //выводим первый диск
            string путь = textBox1.Text; // сейчас тут находится С
            DirectoryInfo папка = new DirectoryInfo(путь);
            DirectoryInfo[] папки = папка.GetDirectories();// передает массив папок
            FileInfo[] файлы = папка.GetFiles();//файлов
            foreach (var i in папки)//вывод папок
            {
                listBox1.Items.Add(i.Name);
            }
            foreach (var i in файлы)
            {
                listBox1.Items.Add(i.Name);
            }

        }
        public Form1()
        {
            InitializeComponent();
            инициализация();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string путь = textBox1.Text;
            DirectoryInfo папка = new DirectoryInfo(путь);
            DirectoryInfo[] папки = папка.GetDirectories();
            FileInfo[] файлы = папка.GetFiles();
            Print(папки, файлы);
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            textBox1.Text = textBox1.Text + "\\" + listBox1.SelectedItem.ToString();
            string путь = textBox1.Text;
            if (Directory.Exists(путь))
            {
                listBox1.Items.Clear();
                DirectoryInfo папка = new DirectoryInfo(путь);
                DirectoryInfo[] папки = папка.GetDirectories();
                FileInfo[] файлы = папка.GetFiles();
                foreach (var i in папки)
                {
                    listBox1.Items.Add(i.Name);
                }
                foreach (var i in файлы)
                {
                    listBox1.Items.Add(i.Name);
                }
            }
            else if (File.Exists(путь))
            {

                Process.Start(new ProcessStartInfo(textBox1.Text) { UseShellExecute = true });//сказать, что нашел в инете

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(путь1))
            {
                Directory.Delete(путь1);
            }
            else
            {
                File.Delete(путь1);
            }
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null) // проверка на то, нажали ли мы на пустое
            {
                        путь1 = textBox1.Text + "\\" + listBox1.SelectedItem.ToString(); ;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            переименовать форма = new переименовать(путь1, listBox1,textBox1.Text);
            форма.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string delname = путь1;
            string res;
            string zipfile;
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (ZipFile zip = new ZipFile(Encoding.UTF8))
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestSpeed;
                if (File.Exists(delname))
                {
                    zip.AddFile(delname);
                    zipfile = delname.Remove(delname.Length - 4); // Кладем в архив одиночный файл (4- расширение и точка)
                    res = listBox1.SelectedItem.ToString().Remove(listBox1.SelectedItem.ToString().Length - 4) + ".zip";
                }

                else
                {
                    zip.AddDirectory(delname);
                    zipfile = delname;
                    res = listBox1.SelectedItem.ToString() + ".zip";
                }

                //Обрезаем расширение файла
                zip.Save(zipfile + ".zip");
            }
            listBox1.Items.Add(res);
        }
    }
}
