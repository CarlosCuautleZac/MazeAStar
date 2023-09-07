using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAStar
{
    public class Nodo
    {
        #region Estado
        public int Ren { get; set; }
        public int Col { get; set; }
        public static bool[,] Tablero { get; set; }
        #endregion

        public static int RenDest { get; private set; }
        public static int ColDest { get; private set; }

        public int G { get; set; }
        public int H => Math.Abs(Ren - Nodo.RenDest)+Math.Abs(Col - Nodo.ColDest);
        public int F => G + H;

        public IEnumerable<Nodo> GenerarSucesores()
        {
            if(Ren>0 && !Tablero[Col, Ren - 1])
            {
                yield return new Nodo()
                {
                    Ren = Ren - 1,
                    Col = Col,
                    G = G + 1
                };
            }

            if (Ren > 0 && !Tablero[Col, Ren - 1])
            {
                yield return new Nodo()
                {
                    Ren = Ren - 1,
                    Col = Col,
                    G = G + 1
                };
            }

            if(Ren)
        }


    }
}
