﻿using System;
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

        public static int RenDest { get; set; }
        public static int ColDest { get; set; }

        public int G { get; set; }
        public int H => Math.Abs(Ren - Nodo.RenDest)+Math.Abs(Col - Nodo.ColDest);
        public int F => G + H;

        public Nodo? Padre { get; set; }

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

            if (Ren < Tablero.GetLength(0) - 1 && !Tablero[Col, Ren + 1])
            {
                yield return new Nodo()
                {
                    Ren= Ren+ 1,
                    Col = Col,
                    G = G + 1
                };
            }

            if(Col>0 && !Tablero[Col-1, Ren])
            {
                yield return new Nodo()
                {
                    Ren = Ren,
                    Col = Col-1,
                    G = G + 1   
                };
            }
            if (Col<Tablero.GetLength(1)-1 && !Tablero[Col+1,Ren])
            {
                yield return new Nodo()
                {
                    Ren = Ren,
                    Col = Col +1,
                    G = G + 1
                };
            }
        }

        void PropagarG(int g)
        {
            this.G = g;
        }
    }
}
