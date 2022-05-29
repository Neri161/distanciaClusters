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
        public double[,] clusters { get; set; }
        public Random rn = new Random();
        public Distancia[,] distancias;
        public List<Distancia> distanciasMinimas = new List<Distancia>();
        public KMeans(int x, int k)
        {
            n = x;
            this.K = k;
            XY = new int[n, 2];
            clusters = new double[K, 2];
            distancias = new Distancia[n, K];
        }
        public void generarPuntos()
        {

            for (int i = 0; i < n; i++)
            {

                XY[i, 0] = rn.Next(1, 11);//x
                XY[i, 1] = rn.Next(1, 11);//y
            }
        }
        public void seleccionarCentroides()
        {
            for (int i = 0; i < K; i++)
            {
                clusters[i, 0] = rn.Next(1, n);//x
                clusters[i, 1] = rn.Next(1, n);//y
            }
        }
        public void pitagoras()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < K; j++)
                {
                    distancias[i, j] = (new Distancia(j, Math.Sqrt(Math.Pow(clusters[j, 0] - XY[i, 0], 2) + Math.Pow(clusters[j, 1] - XY[i, 1], 2)), XY[i, 0], XY[i, 1]));

                }
            }
        }
        public void calcularMinimo()
        {
            Distancia disAux = new Distancia();
            //Metodo burbuja
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < K; j++)
                {
                    for (int l = K - 1; l >= j; l--)
                    {
                        if (distancias[i, l - 1].distancia > distancias[i, l].distancia)
                        {
                            disAux = distancias[i, l - 1];
                            distancias[i, l - 1] = distancias[i, l];
                            distancias[i, l] = disAux;

                        }
                    }
                }
                distanciasMinimas.Add(distancias[i, 0]);
            }
        }
        public double[,] ActualizarClusters()
        {
            double[,] nuevoValores = new double[K, 2]; //Array Auxiliar para retornar
            for (int i = 0; i < K; i++)
            {
                double sumaX = 0; //suma de las x
                double sumaY = 0; //suma de las y
                int numeroElementosGrupo = 0;
                for (int j = 0; j < distanciasMinimas.Count; j++)
                {
                    if (i == distanciasMinimas[j].grupo)
                    {
                        sumaX += distanciasMinimas[j].XY[0];
                        sumaY += distanciasMinimas[j].XY[1];
                        numeroElementosGrupo++;
                    }

                }
                //Hacer promedio 
                if (numeroElementosGrupo > 1)
                {
                    nuevoValores[i, 0] = (sumaX / numeroElementosGrupo);
                    nuevoValores[i, 1] = (sumaY / numeroElementosGrupo);
                }
                else
                {
                    nuevoValores[i, 0] = clusters[i, 0];
                    nuevoValores[i, 1] = clusters[i, 1];
                }
            }
            return nuevoValores;

        }

    }
    public class Distancia
    {
        public int grupo { get; set; }
        public double distancia { get; set; }
        public int[] XY = new int[2];
        public Distancia(int grupo, double distancias, int x, int y)
        {
            this.grupo = grupo;
            this.distancia = distancias;
            XY[0] = x;
            XY[1] = y;
        }
        public Distancia()
        {
        }

    }
}
