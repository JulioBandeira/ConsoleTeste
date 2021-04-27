using System;

public class Program
{
	public static Program instance;

	public string OrdenaArray(params string[] arr)
	{
		var resultado = string.Empty;

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

		Console.WriteLine(arr);
		return resultado;
	}

	public string BuscaItensFaltantesNaSequencia(params string[] args)
	{
		var resultado = string.Empty;

		// Seu Código Aqui....

		return resultado;
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