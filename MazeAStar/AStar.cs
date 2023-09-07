using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAStar
{
    public class AStar
    {
        public AStar()
        {
            
        }

        public void Buscar(Nodo origen, Nodo destino)
        {
            List<Nodo> abiertos = new();
            List<Nodo> cerrados = new();
            bool existeRuta = true;
            bool solucionEncontrada = false;

            abiertos.Add(origen);

            do
            {
                if(abiertos.Count == 0)
                {
                    existeRuta = false;
                }
                else
                {
                    var mejorNodo = abiertos.OrderBy(x => x.F).First();
                    abiertos.Remove(mejorNodo);
                    cerrados.Add(mejorNodo);

                    if (mejorNodo.Col != destino.Col || mejorNodo.Ren != destino.Ren)
                    {

                    }
                    else
                    {
                        solucionEncontrada=true;
                    }
                }

            } while (existeRuta && !solucionEncontrada);
        }



    }
}
