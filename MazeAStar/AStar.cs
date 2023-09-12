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
            Nodo.ColDest = destino.Col;
            Nodo.RenDest = destino.Col;
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
                        var sucesores = mejorNodo.GenerarSucesores();
                        foreach (var nodo in sucesores)
                        {
                            Nodo? viejo = abiertos.FirstOrDefault(x => x.Ren == nodo.Ren && x.Col == nodo.Col);
                            if (viejo != null)
                            {
                                if (nodo.G < viejo.G)
                                {
                                    viejo.G = nodo.G;
                                    viejo.Padre = mejorNodo;
                                }
                                    
                            }
                            else
                            {
                                viejo = cerrados.FirstOrDefault(x => x.Ren == nodo.Ren && x.Col == nodo.Col);
                                if(viejo!=null)
                                {
                                    if (nodo.G < viejo.G)
                                    {
                                        viejo.G = nodo.G;
                                        viejo.Padre = mejorNodo;
                                    }
                                }
                            }
                        }
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
