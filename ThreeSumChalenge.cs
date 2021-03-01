using System;
using System.Collections.Generic;

namespace Chalenge02
{
    /*
    Mi solucion consiste en hacer bucles anidados que hagan todas las combinaciones posibles de 3 numeros para comprobar si suman 0. 
    Para evitar en cada solucion tener indices repetidos, se verifica que no se tome un indice ya tomado para la solucion actual a combinar. 
    Luego para quitar duplicados se verifica cada numero de cada solucion con el resto de soluciones, se guarda en un array, 
    y luego se eliminan de la solucion segun el array de duplicados.
    Tambien se corrobora que no hayan soluciones duplicadas aunque sean de diferente indice del array. 
    Por ejemplo, si hay 6 ceros en el array, solo se toma una solucion de tres ceros como valida.
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Resultado:");

            var nums = new int[6];
            nums[0] = -1;
            nums[1] = 0;
            nums[2] = 1;
            nums[3] = 2;
            nums[4] = -1;
            nums[5] = -4;


            try
            {
                var result = ThreeSum(nums);

                Console.Write("[");
                foreach (var r in result)
                {
                    Console.Write("[");
                    foreach (var t in r)
                    {
                        Console.Write(t.ToString() + ",");
                    }
                    Console.Write("]");
                }
                Console.Write("]");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Solucion
        static List<List<int>> ThreeSum(int[] nums)
        {
            const int resultado = 0;
            List<int> triplete = null;
            List<List<int>> soluciones = new List<List<int>>();

            //guardo los indices del array de los numeros que ya se tomaron para la solucion actual
            List<int> indexUsado = null;

            //por si el array tiene menos de 3 numeros
            if (nums.Length < 3)
                return soluciones;

            //tomo a
            for(int x=0; x<nums.Length; x++)
            {
                indexUsado = new List<int>();

                indexUsado.Add(x);
                int a = nums[x];

                //tomo b
                for (int y = 0; y < nums.Length; y++)
                {    
                    if(!indexUsado.Contains(y))
                    {
                        indexUsado.Add(y);
                        int b = nums[y];

                        //tomo c
                        for (int z = 0; z < nums.Length; z++)
                        {
                            if (!indexUsado.Contains(z))
                            {
                                int c = nums[z];
                                if ((a + b + c) == resultado)
                                {
                                    triplete = new List<int>();
                                    triplete.Add(a);
                                    triplete.Add(b);
                                    triplete.Add(c);


                                    soluciones.Add(triplete);
                                    
                                }
                                    
                            }
                        }
                            
                    }
                        
                }
                
                
            }

            //QUITAR DUPLICADOS

            //para eliminar las soluciones duplicadas aunque esten en distinto orden
            List<List<int>> solucionesABorrar = new List<List<int>>();

            //recorro las soluciones desde la primera hasta la penultima para comparar con el resto
            for(int i=0;i<soluciones.Count-1;i++)
            {
                //tomo la soluciones a comparar con la anteriormente tomada
                for(int y = i+1; y < soluciones.Count; y++)
                {
                    int repetidos = 0;

                    //copio la solucion a comparar (para evitar pasarla por referencia)
                    List<int> comparados = new List<int>();
                    comparados.Add(soluciones[y][0]);
                    comparados.Add(soluciones[y][1]);
                    comparados.Add(soluciones[y][2]);

                    for(int x = 0;x < soluciones[i].Count; x++)
                    {
                        if (comparados.Contains(soluciones[i][x]))
                        {
                            repetidos += 1;
                            comparados.Remove(soluciones[i][x]);
                        }
                    }
                    if(repetidos == 3)
                    {
                        solucionesABorrar.Add(soluciones[i]);   
                    }
                    repetidos = 0;
                    
                }
            }
            //borro las soluciones duplicadas
            foreach(var i in solucionesABorrar)
            {
                soluciones.Remove(i);
            }

            return soluciones;
        }
    }
}
