using System;

public class Program
{
    public static Program instance;

    /// <summary>
    /// Método tem o objetivo de pegar o último elemento do array.
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public int PegaUltimoElementoArray(params string[] array) => Convert.ToInt32(array[array.Length - 1]);

    /// <summary>
    /// Método tem objetivo de transformar um string para o array desde a string seja contatenada com 
    /// vírgula ",";
    /// </summary>
    /// <param name="array_string"></param>
    /// <returns></returns>
    public string[] StringParaArray(string array_string) => array_string.Split(",");

    /// <summary>
    /// Método para retirar o zero da string 01, tendo a posição do index 0 do array.
    /// Na implementação do método se faz o Split() da vírgula "," na string para conversão do string para array.
    /// </summary>
    /// <param name="array_string"></param>
    /// <returns></returns>
    public string RetirarZeroArrayIndexZero(string array_string)
    {
        string[] array = StringParaArray(array_string);

        for (int i = 0; i < array_string.Split(",").Length; i++)
            if (i == 0)
                array[i] = "1";

        return ConcatenarArrayParaString(array);
    }

    /// <summary>
    /// Método tem o objetivo de concatenar um array para string,
    /// sendo a concatenação com vírgula ",".
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Método tem objetivo de ordenar um array em ordem crescente usando algoritimo bubble sort 
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public string OrdenaArray(params string[] array)
    {
        int tamanho_array = array.Length;
        string string_temporaria;

        for (int j = 0; j < tamanho_array - 1; j++)

            for (int i = j + 1; i < tamanho_array; i++)

                if (array[j].CompareTo(array[i]) > 0)
                {
                    string_temporaria = array[j];
                    array[j] = array[i];
                    array[i] = string_temporaria;
                }

        return RetirarZeroArrayIndexZero(ConcatenarArrayParaString(array));
    }

    /// <summary>
    /// Método tem objetivo de remover o item do array, através do elemento desejado.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="elemento"></param>
    /// <returns></returns>
    public string[] RemoveItemArray(string[] array, string elemento)
    {
        int posicao = 0;
        var novo_array = new string[array.Length + 1];

        for (int o = 0; o < (array.Length); o++)
            if (!string.IsNullOrEmpty(array[o]))
                novo_array[o] = array[o];

        for (int c = 0; c < 10; c++)
            if (novo_array[c] == elemento)
                posicao = c;

        int pos = posicao + 1;
        int i;
        for (i = pos - 1; i < 9; i++)
            novo_array[i] = novo_array[i + 1];

        return novo_array;
    }

    /// <summary>
    /// Método tem o objetivo de retornar os itens faltantes do array que sendo passado por paramentro
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public string BuscaItensFaltantesNaSequencia(params string[] array)
    {
        var array_todos = new string[PegaUltimoElementoArray(array[0].Split(','))];
        var array_original = StringParaArray(array[0]);
        var array_temporario = array_todos;

        for (int i = 0; i < array_todos.Length; i++)
            array_todos[i] = (i + 1).ToString();

        for (int i = 0; i < array_todos.Length; i++)

            for (int j = 0; j < array_original.Length; j++)

                if (array_todos[i] == array_original[j])
                    array_temporario = RemoveItemArray(array_temporario, array_todos[i]);

        return ConcatenarArrayParaString(array_temporario);
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