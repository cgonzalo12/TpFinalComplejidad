using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpfinal
{
    internal class Heap
    {
        private List<Dato> heap;
        private int tamanio;
        public Heap()
        {
            heap = new List<Dato>();
            Dato fals = new Dato(999, "asd");
            heap.Add(fals);
        }

        public int getTamanio()
        {
            return tamanio = heap.Count - 1;
        }
        public List<Dato> getHeap()
        {
            return heap;
        }
        public Dato raiz()
        {
            return heap[1];
        }
        public void imprimirHeap()
        {
            for (int i = 1; i < heap.Count; i++)
            {
                Console.WriteLine(heap[i].ocurrencia + " ");
            }
        }
        public void Add(Dato item)
        {
            heap.Add(item);
            FiltradoHaciaArriba(getTamanio());
        }
        public void FiltradoHaciaArriba(int posicion)
        {
            while (posicion > 1)
            {
                int padr = posicion / 2;
                Dato hijo = heap[posicion];
                Dato padre = heap[padr];
                if (hijo.ocurrencia > padre.ocurrencia)
                {
                    intercambio(posicion, padr);
                    FiltradoHaciaArriba(padr);
                }
                else
                {
                    break;
                }


            }
        }
        public void filtradoHaciaAbajo(int posicion)
        {
            int tamanio = heap.Count;
            while (posicion < tamanio)
            {
                int HIzquierdo = 2 * posicion ; 
                int HDerecho = 2 * posicion +1;   
                int posicionAux = posicion;
                if (HIzquierdo < tamanio && heap[HIzquierdo].ocurrencia > heap[posicionAux].ocurrencia)
                {
                    posicionAux = HIzquierdo;
                }
                if (HDerecho < tamanio && heap[HDerecho].ocurrencia > heap[posicionAux].ocurrencia)
                {
                    posicionAux = HDerecho;
                }
                if (posicionAux == posicion)
                {
                    break; 
                }

                intercambio(posicion, posicionAux);
                posicion = posicionAux;
            }
        }
        public void intercambio(int posicionA, int posicionB)
        {
            Dato dato = heap[posicionA];
            Dato dato2 = heap[posicionB];
            heap[posicionA] = dato2;
            heap[posicionB] = dato; 
        }

        public Dato deleteMax()
        {
            int tamanio=getTamanio();
            Dato auxMax = heap[1];
            intercambio(1, tamanio - 1);
            heap.RemoveAt(tamanio - 1);
            filtradoHaciaAbajo(1);
            Console.WriteLine(auxMax.ToString());
            return auxMax;
        }
        public string caminoHojaI(List<Dato> collected)
        {
            Dato datoAux = new Dato(99999,"");
            collected.Insert(0, datoAux);
            int tamanio = collected.Count-1;
            int pos = 1;
            int hijoI=pos*2;
            string camino = "Camino al hijo mas izquierdo: ";
            camino=camino+ collected[pos].ToString()+"//";
            while (hijoI<=tamanio)
            {
                camino=camino + collected[hijoI].ToString()+"//";
                hijoI=hijoI*2;
            }
            return camino;
        }
        
        public string porNiveles(List<Dato> collected)
        {
            Dato datoAux = new Dato(99999,"");
            collected.Insert(0, datoAux);
            if (collected.Count <= 1)
                return "Heap vacío";

            string camino = "";
            int nivel = 0;
            int cantidadPorNivel = 1;
            int contador = 0;

            camino += $"Nivel {nivel}:";

            for (int i = 1; i < collected.Count; i++)
            {
                camino += collected[i].ToString() + " ";
                contador++;

                if (contador == cantidadPorNivel)
                {
                    nivel++;
                    cantidadPorNivel *= 2;
                    contador = 0;
                    if (i + 1 < collected.Count)
                        camino += $"\nNivel {nivel}:";
                }
            }

            return camino;

        }

    }
}
