using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using ParserAvito.work;
using System.Net;

namespace ParserAvito
{
    public partial class Form1 : Form
    {
        AddFilter AddFilter = new AddFilter();
        static string path = @"Settings\Filters.txt";
        bool enabled = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void startButton_Click(object sender, EventArgs e)
        {
            PictureBoxZXC.Enabled = true;
            PictureBoxZXC.Visible = true;

            Thread[] thread = new Thread[ReadSettings(path).Length];
            enabled = true;
            string[] settings = ReadSettings(path);
            for (int i = 0; i < settings.Length; i++)
            {
                string[] line = settings[i].Split('|');
                string link = line[0];
                string minPrice = line[1];
                string maxPrice = line[2];
                string maxPage = line[3];
                string nameElement = line[4];

                thread[i] = new Thread(new ThreadStart(delegate { StartParsing(link, nameElement, minPrice, maxPrice, maxPage); }));
                thread[i].Start();
            }
        }
        private void StartParsing(string link, string nameElement, string minPrice, string maxPrice, string maxPage)
        {
            while (enabled)
            {

                List<string> parsing = new List<string>();

                Random random = new Random();
                for (int p = 1; p < Convert.ToInt32(maxPage); p++)
                {
                    if (enabled == false)
                    {
                        break;
                    }
                    else
                    {
                        if (!Connection.OK())
                        {
                            MessageBox.Show("Отсутствует интернет соединение");

                            enabled = false;

                            Invoke((MethodInvoker)delegate
                            {
                                CheckZXCCat();
                            });
                            break;
                        }
                        else
                        {
                            string response = Avito.GetPage(link + "&p=" + p.ToString());
                            if (response != null)
                            {
                                parsing = Avito.ParseString(response, Convert.ToInt32(maxPrice), Convert.ToInt32(minPrice), nameElement);
                            }
                            else
                            {
                                MessageBox.Show("Ошибка запроса");
                            }

                            for (int i = 0; i < parsing.Count; i++)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    if (!Log.Text.Contains(parsing[i].ToString()))
                                    {
                                        Log.Text += parsing[i];
                                    }
                                });
                            }
                            Thread.Sleep(GetSettingCount(path) * random.Next(65000, 80000));
                        }
                    }
                }
            }
        }


        private static string[] ReadSettings(string path)
        {
            string[] settings = File.ReadAllLines(path);
            return settings;
        }

        private int GetSettingCount(string path)
        {
            string[] settings = File.ReadAllLines(path);
            return settings.Length;
        }

        // от какой страницы
        private void numericMIn_ValueChanged(object sender, EventArgs e)
        {

        }

        // по какую страницу
        private void numericMax_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Log_TextChanged(object sender, EventArgs e)
        {
            logText.Text = $@"Log[{Log.Lines.Count()}]";
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            PictureBoxZXC.Visible = false;
            PictureBoxZXC.Enabled = false;
            enabled = false;
        }

        private void CheckZXCCat()
        {
            if (enabled)
            {
                PictureBoxZXC.Visible = true;
                PictureBoxZXC.Enabled = true;
            }
            else
            {
                PictureBoxZXC.Visible = false;
                PictureBoxZXC.Enabled = false;
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddFilter.Show();
        }

        private void OpenSettings_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                Process.Start("C:\\Windows\\System32\\notepad.exe", @"Settings\Filters.txt");
            }
            else
                MessageBox.Show("Фильтры отсутствуют");
        }
    }
}
