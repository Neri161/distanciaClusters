using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace distanciaClusters
{
    class KMeans
    {
        public int[,] XY { get; set; }
        public int n { get; set; }
        public int K { get; set; }
        public int[,] clusters { get; set; }
        public Random rn = new Random();
        public Distancia[,] distancias;
        public List<Distancia> distanciasMinimas=new List<Distancia>();
        public KMeans(int x, int k)
        {
            n = x;
            this.K = k;
            XY = new int[n, 2];
            clusters = new int[K, 2];
            distancias= new Distancia[n,K];
        }
        public void generarPuntos()
        {

            for (int i = 0; i < n; i++)
            {

                XY[i, 0] = rn.Next(1, 11);
                XY[i, 1] = rn.Next(1, 11);
            }
        }
        public void seleccionarCentroides()
        {
            for (int i = 0; i < K; i++)
            {
                clusters[i, 0] = rn.Next(1, n);
                clusters[i, 1] = rn.Next(1, n);
            }
        }
        public void pitagoras()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < K; j++)
                {
                    distancias[i,j]=(new Distancia(j, Math.Sqrt(Math.Pow(clusters[j, 0] - XY[i, 0], 2) + Math.Pow(clusters[j, 1] - XY[i, 1], 2))));

                }
            }
        }
        public void calcularMinimo()
        {
            Distancia disAux=new Distancia();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= K-1; j++)
                {
                    if(distancias[i,j].distancias< distancias[i, j+1].distancias)
                    {
                        disAux = distancias[i, j];
                    }
                }
                distanciasMinimas.Add(disAux);
            }
        }

    }
    public class Distancia
    {
        public int grupo { get; set; }
        public double distancias { get; set; }
        public Distancia(int grupo, double distancias)
        {
            this.grupo = grupo;
            this.distancias = distancias;
        }
        public Distancia()
        {            
        }

    }
}
