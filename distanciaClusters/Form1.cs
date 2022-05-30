using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace distanciaClusters
{
    public partial class Form1 : Form
    {
        KMeans generarXY;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Add("datos");
            chart1.Series.Add("clusters");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[0].Color = Color.Blue;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[1].Color = Color.FromArgb(0, 0, 0);
            generarXY = new KMeans(5, 3);
            generarXY.generarPuntos();
            generarXY.seleccionarCentroides();
            for (int i = 0; i < generarXY.n; i++)
            {

                chart1.Series[0].Points.AddXY(generarXY.XY[i, 0], generarXY.XY[i, 1]);
            }
            for (int i = 0; i < generarXY.K; i++)
            {
                chart1.Series[1].Points.AddXY(generarXY.clusters[i, 0], generarXY.clusters[i, 1]);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            List<Distancia> distanciasMinimas = generarXY.iterar();
            for (int j = 0; j < distanciasMinimas.Count(); j++)
            {
                chart1.Series[0].Points.AddXY(distanciasMinimas[j].XY[0], distanciasMinimas[j].XY[1]);
                if (distanciasMinimas[j].grupo == 0)
                {
                    chart1.Series[0].Points[j].Color = Color.DarkOrange;
                }
                if (distanciasMinimas[j].grupo == 1)
                {
                    chart1.Series[0].Points[j].Color = Color.BlueViolet;
                }
                if (distanciasMinimas[j].grupo == 2)
                {
                    chart1.Series[0].Points[j].Color = Color.Brown;
                }
                if(distanciasMinimas[j].grupo != 0 && distanciasMinimas[j].grupo != 1 && distanciasMinimas[j].grupo != 2)
                {
                    chart1.Series[0].Points[j].Color = Color.Blue;
                }
            }
            for (int i = 0; i < generarXY.K; i++)
            {
                chart1.Series[1].Points.AddXY(generarXY.clusters[i, 0], generarXY.clusters[i, 1]);

            }



        }
    }
}
