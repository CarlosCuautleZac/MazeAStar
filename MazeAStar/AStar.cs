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

        List<Nodo> abiertos = new();
        List<Nodo> cerrados = new();

        public void Buscar(Nodo origen, Nodo destino)
        {
           
            Nodo.ColDest = destino.Col;
            Nodo.RenDest = destino.Col;
            bool existeRuta = true;
            bool solucionEncontrada = false;
            Nodo? mejorNodo = new();

            abiertos.Add(origen);

            do
            {
                if(abiertos.Count == 0)
                {
                    existeRuta = false;
                }
                else
                {
                    mejorNodo = abiertos.OrderBy(x => x.F).First();
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
                                    PropagarG(viejo);
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

            if(solucionEncontrada)
            {
                List<Nodo> solucion = new();
                solucion.Add(mejorNodo);
                while (mejorNodo.Padre != null)
                {
                    mejorNodo = mejorNodo.Padre;
                    solucion.Add(mejorNodo);
                }
            }
        }


        void PropagarG(Nodo nodo)
        {
            var hijos = abiertos.Where(x => x.Padre == nodo);
            foreach (var hijo in hijos)
            {
                hijo.G = nodo.G + 1;
            }

            hijos = cerrados.Where(x=>x.Padre == nodo);
            foreach (var hijo in hijos)
            {
                hijo.G = nodo.G + 1;
                PropagarG (hijo);
            }
        }
    }
}
