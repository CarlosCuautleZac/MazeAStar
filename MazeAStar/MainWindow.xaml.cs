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
            Nodo.Tablero = new bool[9,9];
            Nodo inicial = new Nodo()
            {
                Col = 1,
                Ren = 0,
                G = 0
            };

            Nodo final = new Nodo()
            {
                Col = 8,
                Ren = 7
            };


            AStar aStar = new AStar();
            aStar.Buscar(inicial,final);
        }
    }
}
