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
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            chart1.ChartAreas.Add(new ChartArea());
            String[][] lines = readFile("C:\\Documents\\WriteLines.txt");
            var series = new Series();
            series.Points.AddXY(1.0, lines[1][0]);
            series.Points.AddXY(2.0, 48);
            series.Points.AddXY(3.0, 53.0);
            chart1.Series.Add(series);
            
        }
        private String[][] readFile(string filePath)
        {
            //Pass the file path and file name to the StreamReader constructor
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StreamReader sr = new StreamReader(Path.Combine(docPath, "WriteLines.txt"));
            //variables
            String line;
            string[] splitline = new string[3];
            var numlines = File.ReadLines("WriteLines.txt").Count();
            string[] Date = new string[numlines];
            string[] Distance = new string[numlines];
            string[] Time = new string[numlines];
            //Read the first line of text
            line = sr.ReadLine();
            splitline = line.Split(' ');
            //Continue to read until you reach end of file
            int i = 0;
            while (line != null)
            { 
                //read the next line
                //split the line in 3
                splitline = line.Split(' ');
                //get all of the 
                Date[i] = splitline[0];
                Distance[i] = splitline[1];
                Time[i] = splitline[2];
                line = sr.ReadLine();
                i++;
            }
            //Creating return string
            String[][] lines = new string[][] {Date,Distance,Time};
            //Closing file
            sr.Close();
            return lines;  
        }
    }
}
