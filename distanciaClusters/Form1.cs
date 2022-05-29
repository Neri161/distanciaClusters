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
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            generarXY = new KMeans(6, 3);
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

            generarXY.pitagoras();
            generarXY.calcularMinimo();

        }
    }
}
