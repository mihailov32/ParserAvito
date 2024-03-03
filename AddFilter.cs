using AngleSharp.Html.Dom;
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

namespace ParserAvito
{
    public partial class AddFilter : Form
    {
        public AddFilter()
        {
            InitializeComponent();
        }

        private void buttonAddFilter_Click(object sender, EventArgs e)
        {
            string path = @"Settings\Filters.txt";
            string filter = "";
            if (LinkValidation() && MinPriceValidation() && MaxPriceValidation() && MaxPageValidation())
            {
                string link = LinkTextBox.Text;
                string minPrice = MinPriceTexBox.Text;
                string maxPrice = MaxPriceTextBox.Text;
                string MaxPage = MaxPageTextBox.Text;
                string name = NameTextBox.Text;
                filter = link + "|" + minPrice + "|" + maxPrice + "|" + MaxPage + "|" + name;
                WriteParameter(filter, path);
            }
            this.Close();

        }
      
        private bool LinkValidation()
        {
            if (LinkTextBox.Text == "")
            {
                LinkTextBox.Text = "Ссылка отсутствует";
                return false;
            }
            else return true;
        }
        private bool MinPriceValidation()
        {
            if (MinPriceTexBox.Text == "")
            {
                MinPriceTexBox.Text = "Пустое поле";
                return false;
            }
            else return true;
        }

        private bool MaxPriceValidation()
        {
            if (MaxPriceTextBox.Text == "")
            {
                MaxPriceTextBox.Text = "Пустое поле";
                return false;
            }
            else return true;
        }

        private bool MaxPageValidation()
        {
            if (MaxPageTextBox.Text == "")
            {
                MaxPageTextBox.Text = "Пустое поле";
                return false;
            }
            else return true;
        }

        private void WriteParameter(string line, string path)
        {
            using (FileStream file = new FileStream(path, FileMode.Append))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
