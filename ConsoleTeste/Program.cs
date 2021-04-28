using System;

public class Program
{
    public static Program instance;


    public string RetirarZeroArrayIndexZero(string array_string)
    {
        string[] array = array_string.Split(",");

        for (int i = 0; i < array_string.Split(",").Length; i++)
        {
            if (i == 0)
                array[i] = "1";
            break;
        }

        return ConcatenarArrayParaString(array);
    }

    public string ConcatenarArrayParaString(string[] array)
    {
        string array_string = "";

        for (int i = 0; i < array.Length; i++)
        {
            if (array.Length != (i + 1) && !String.IsNullOrEmpty(array[i]))
                array_string += $"{array[i]},";
            else if (!String.IsNullOrEmpty(array[i]))
                array_string += $"{array[i]}";

        }
        return array_string.TrimEnd(',');
    }

    public string OrdenaArray(params string[] arr)
    {
        int n = arr.Length;
        String temp;

        // Sorting strings using bubble sort
        for (int j = 0; j < n - 1; j++)
        {
            for (int i = j + 1; i < n; i++)
            {
                if (arr[j].CompareTo(arr[i]) > 0)
                {
                    temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }
            }
        }

        return RetirarZeroArrayIndexZero(ConcatenarArrayParaString(arr));
    }

    public int PegaUltimoElementoArray(params string[] args)
    {

        return Convert.ToInt32(args[args.Length - 1]);
    }

    public string[] RemoveItemArray(string[] args, string elemento)
    {
        int posicao = 0;

        var new_array = new string[args.Length + 1];

        for (int o = 0; o < (args.Length); o++)
        {
            if (!string.IsNullOrEmpty(args[o]))
                new_array[o] = args[o];
        }

        for (int c = 0; c < new_array.Length; c++)
        {
            if (new_array[c] == elemento)
                posicao = c;
        }

        int pos = posicao + 1;
        int i;
        for (i = pos - 1; i < 9; i++)
        {
            new_array[i] = new_array[i + 1];
        }

        return new_array;
    }

    public string BuscaItensFaltantesNaSequencia(params string[] args)
    {
        var resultado = string.Empty;

        var array_todos = new string[PegaUltimoElementoArray(args[0].Split(','))];
        var array_original = args[0].Split(',');
        var array_temp = array_todos;

        for (int i = 0; i < array_todos.Length; i++)
            array_todos[i] = (i + 1).ToString();

        for (int i = 0; i < array_todos.Length; i++)
        {
            for (int j = 0; j < array_original.Length; j++)
            {
                if (array_todos[i] == array_original[j])
                {
                    //Console.WriteLine($"Posiçao: {i + 1}");
                    //Console.WriteLine(array_todos[i]);
                    //Console.WriteLine(true);
                    //Console.WriteLine(array_original[j]);
                    array_temp = RemoveItemArray(array_temp, array_todos[i]);
                    //ConcatenarArrayParaString(array_temp);
                    //Console.WriteLine(ConcatenarArrayParaString(array_temp));
                }
            }
        }

        return ConcatenarArrayParaString(array_temp);
    }

    // Não alterar o codigo abaixo abaixo!
    public static void Main()
    {
        instance = instance ?? new Program();

        var ordenado = instance.OrdenaArray("6", "3", "5", "4", "01", "7", "9");
        var itensFaltantes = instance.BuscaItensFaltantesNaSequencia(ordenado);

        var resultadoOrdenadoEsperado = "1,3,4,5,6,7,9";
        var resultadoItensFaltantesEsperado = "2,8";

        Console.WriteLine(ordenado == resultadoOrdenadoEsperado ? $"CORRETO {ordenado} == {resultadoOrdenadoEsperado}" : $"INCORRETO {ordenado} != {resultadoOrdenadoEsperado}");
        Console.WriteLine(itensFaltantes == resultadoItensFaltantesEsperado ? $"CORRETO {itensFaltantes} == {resultadoItensFaltantesEsperado}" : $"INCORRETO {itensFaltantes} != {resultadoItensFaltantesEsperado}");
    }
}