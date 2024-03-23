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
        AddFilter addFilter = null;
        static string path = @"Settings\Filters.txt";
        bool enabled = true;
        int countCheckPage = 0;
        int countError = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "Парсер Avito";
            notifyIcon1.BalloonTipText = "Приложение свернуто";
            notifyIcon1.Text = "Парсер Avito";

            if (!Directory.Exists("Settings") || !File.Exists(path))
            {
                Directory.CreateDirectory("Settings");
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    fileStream.Dispose();
                }
                File.Create("Settings\\TelegramToken.txt").Dispose();
            }
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
                string nameElement = line[3];

                thread[i] = new Thread(new ThreadStart(delegate { StartParsing(link, nameElement, minPrice, maxPrice); }));
                thread[i].Start();
            }
        }
        private void StartParsing(string link, string nameElement, string minPrice, string maxPrice)
        {
            while (enabled)
            {

                List<string> parsing = new List<string>();

                Random random = new Random();

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
                    string response = Avito.GetPage(link);
                    if (response == null)
                        MessageBox.Show("пиздец");
                    for (int p = 1; p < Avito.GetMaxPage(response); p++)
                    {
                        if (enabled == false)
                        {
                            break;
                        }
                        else
                        {
                            if (p != 1)
                                response = Avito.GetPage(link + "&p=" + p.ToString());
                            if (response != null)
                            {
                                parsing = Avito.ParseString(response, Convert.ToInt32(maxPrice), Convert.ToInt32(minPrice), nameElement);
                                this.Invoke((MethodInvoker)delegate
                                {
                                    CountCheckPage.Text = "Просмотренно странниц: " + ++countCheckPage;
                                    for (int i = 0; i < parsing.Count; i++)
                                    {
                                        if (!Log.Text.Contains(parsing[i].ToString()))
                                        {
                                            Log.Text += parsing[i];
                                            Telega.Start(parsing[i]);
                                        }
                                    }
                                });
                            }
                            else
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    CountError.Text = "Ошибок: " + ++countError;
                                });
                            }

                            //for (int i = 0; i < parsing.Count; i++)
                            //{
                            //    this.Invoke((MethodInvoker)delegate
                            //    {
                            //        if (!Log.Text.Contains(parsing[i].ToString()))
                            //        {
                            //            Log.Text += parsing[i];
                            //            Telega.Start(parsing[i]);
                            //        }
                            //    });
                            //}
                            Thread.Sleep(GetSettingCount(path) * random.Next(30000, 60000));
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
            if (addFilter == null || addFilter.IsDisposed)
            {
                addFilter = new AddFilter();
                addFilter.Show();
            }
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

        private void AddToken_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("Settings"))
            {
                if (File.Exists("Settings\\TelegramToken.txt"))
                {
                    Process.Start("C:\\Windows\\System32\\notepad.exe", @"Settings\TelegramToken.txt");
                }
                else
                {
                    File.Create("Settings\\TelegramToken.txt").Dispose();
                    Process.Start("C:\\Windows\\System32\\notepad.exe", @"Settings\TelegramToken.txt");
                }
            }
            else
            {
                Directory.CreateDirectory("Settingts");
                File.Create("Settings\\TelegramToken.txt").Dispose();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }
    }
}
