using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace training_data_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            updateChart();
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
            updateChart();
            distanceText.Text = String.Empty;
            timeText.Text = String.Empty;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            updateChart();

        }
        private String[][] readFile()
        {
            //Pass the file path and file name to the StreamReader constructor
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StreamReader sr = new StreamReader(Path.Combine(docPath, "WriteLines.txt"));
            //variables
            String line;
            string[] splitline = new string[3];
            var numlines = File.ReadLines(Path.Combine(docPath, "WriteLines.txt")).Count();
            string[] Date = new string[numlines];
            string[] Distance = new string[numlines];
            string[] Time = new string[numlines];
            //Read the first line of text
            line = sr.ReadLine();
            splitline = line.Split(' ');
            //Continue to read until you reach end of file
            int i = 0;
            while (i <= numlines - 1)
            {
                //split the line in 3
                splitline = line.Split(' ');
                //get all of the 
                Date[i] = splitline[0];
                Distance[i] = splitline[1];
                Time[i] = splitline[2];
                //read the next line
                line = sr.ReadLine();
                i++;
            }
            //Creating return string
            String[][] lines = new string[][] { Date, Distance, Time };
            //Closing file
            sr.Close();
            return lines;
        }
        private void updateChart()
        {
            chart1.Series.Clear();
            String[][] lines = readFile();
            var seriesdist = new Series();
            var seriestime = new Series();
            for (int i = 0; i < lines[0].Length; i++)
            {
                seriesdist.Points.AddXY(lines[0][i], lines[1][i]);
                seriestime.Points.AddXY(lines[0][i], lines[2][i]);
            }
            chart1.Series.Add(seriesdist);
            chart1.Series.Add(seriestime);
            //chart1.Series[0].Points.Clear();
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[0].Name = "Distance";
            chart1.Series[1].ChartType = SeriesChartType.Line;
            chart1.Series[1].Name = "Time";
        }
    }
}
