using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MazeAStar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Nodo.Tablero = new bool[9, 9];
            //Nodo.Tablero[1, 5] = true;
            //Nodo.Tablero[2, 5] = true;

            //Nodo inicial = new Nodo()
            //{
            //    Col = 1,
            //    Ren = 0,
            //    G = 0
            //};

            //Nodo final = new Nodo()
            //{
            //    Col = 8,
            //    Ren = 7
            //};


            //AStar aStar = new AStar();
            //var camino = aStar.Buscar(inicial, final);
        }

        Rectangle[,] cuadritos;
        Nodo final = new();
        Nodo inicial = new();

        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {
            int filas = int.Parse(txtFilas.Text);
            int columnas = int.Parse(txtColumnas.Text);
            int obstaculos = int.Parse(txtObstaculos.Text);

            tablero.Rows = filas;
            tablero.Columns = columnas;
            cuadritos = new Rectangle[columnas, filas];
            Nodo.Tablero = new bool[columnas, filas];

            for (int i = 0; i < columnas; i++)
            {
                for (int j = 0; j < filas; j++)
                {
                    cuadritos[i, j] = new Rectangle()
                    {
                        Stroke = Brushes.Black
                    };
                    tablero.Children.Add(cuadritos[i, j]);
                }

            }

            Random r  = new Random();

            for (int i = 0; i < obstaculos; i++)
            {
                int fila = r.Next(filas);
                int columna = r.Next(columnas);
                cuadritos[r.Next(columna), r.Next(fila)].Fill = Brushes.DarkSeaGreen;
                Nodo.Tablero[columna,fila] = true;
            }

            //Nodo inicial = new();
            final = new();
            inicial = new();

            do
            {
                int fila = r.Next(filas);
                int columna = r.Next(columnas);
                inicial.Col = columna;
                inicial.Ren = fila;

            } while (Nodo.Tablero[inicial.Col, inicial.Ren]);

            

            do
            {
                int fila = r.Next(filas);
                int columna = r.Next(columnas);
                final.Col = columna;
                final.Ren = fila;

            } while (Nodo.Tablero[inicial.Col, inicial.Ren]);

            cuadritos[inicial.Col, inicial.Ren].Fill = Brushes.Green;
            cuadritos[final.Col, final.Ren].Fill = Brushes.Blue;
        }

        private void btnResvolver_Click(object sender, RoutedEventArgs e)
        {
            AStar aStar = new();
            var solucion = aStar.Buscar(inicial, final);

            foreach (var x in solucion)
            {
                cuadritos[x.Col, x.Ren].Fill = Brushes.Red;
            }
        }
    }
}
