
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using tp1;

namespace tpfinal
{

	public class Estrategia
	{
	
		public String Consulta1(List<string> datos)
		{
            List<Dato> collected = new List<Dato>();
            int n = datos.Count;

            List<Dato> collected1 = new List<Dato>();
            int n1 = datos.Count;

            // Crear un objeto Stopwatch para medir el tiempo con heap
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BuscarConHeap(datos, 5, collected);
            stopwatch.Stop();
            // Obtener el tiempo transcurrido con heap
            TimeSpan elapsedTime = stopwatch.Elapsed;

            // Crear un objeto Stopwatch para medir el tiempo con otro
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            BuscarConOtro(datos, 5, collected);
            stopwatch1.Stop();
            // Obtener el tiempo transcurrido con otro
            TimeSpan elapsedTime1 = stopwatch1.Elapsed;

            string result = $"T({n}) = {elapsedTime.TotalMilliseconds} ms Con Heap";
            result =result+ $"----- T({n}) = {elapsedTime1.TotalMilliseconds} ms Con otro";
            return result;
        }


		public String Consulta2(List<string> datos)
		{
            Heap heap = new Heap();
            List<Dato> collected = new List<Dato>();
            collected=BuscarConHeap(datos, 5, collected);
            string result;
            result=heap.caminoHojaI(collected);
            return result;
        }

		

		public String Consulta3(List<string> datos)
		{
            List<Dato> collected = new List<Dato>();
            collected=BuscarConHeap(datos,5, collected);
            Heap heap = new Heap();
            return heap.porNiveles(collected);
        }



        public List<Dato> BuscarConOtro(List<string> datos, int cantidad, List<Dato> collected)
        {
            List<Dato> aux = new List<Dato>();
            List<Dato> respuesta = new List<Dato>();
            Dato DatoAux;
            aux = ParseToDato(datos);
            aux=reordenarList(aux);
            for (int i = 0; i <= cantidad-1; i++)
            {
                DatoAux = aux[i];
                respuesta.Add(DatoAux);
            }
            return respuesta;
        }

        
        public List<Dato> BuscarConHeap(List<string> datos, int cantidad, List<Dato> collected)
        {
            List<Dato> aux = new List<Dato>();
            Dato DatoAux;
            aux= ParseToDato(datos);

            Heap heap = new Heap();
            foreach (Dato item in aux)
            {
                heap.Add(item);
            }
            for (int i = 1; i <= cantidad; i++)
            {
                DatoAux = heap.deleteMax();
                collected.Add(DatoAux);
            }
            return collected;
        }

        public static List<Dato> ParseToDato(List<string> listaDeStrings)
        {
            
            List<Dato> collected= new List<Dato>();
            foreach (var str in listaDeStrings)
            {
                var datoExistente = collected.FirstOrDefault(d => d.texto == str);

                if (datoExistente != null)
                {
                    datoExistente.ocurrencia++;
                }
                else
                {
                    collected.Add(new Dato(1, str));
                }
            }

            return collected;
        }
        public static List<Dato> reordenarList(List<Dato> lista)
        {
            return lista.OrderByDescending(d => d.ocurrencia).ToList();
        }

    }
}