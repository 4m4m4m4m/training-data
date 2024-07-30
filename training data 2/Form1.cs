using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace training_data_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Main(object sender, EventArgs e) => Console.WriteLine("Hello World!");

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt"), true))
            {
                DateTime dateTime = DateTime.Today;
                outputFile.WriteLine(dateTime.ToString("d", CultureInfo.CreateSpecificCulture("ru-RU")) + " " + distanceText.Text + " " + timeText.Text);
            }
        }
    }
}
