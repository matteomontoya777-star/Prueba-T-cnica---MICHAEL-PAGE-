using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string rutaArchivo = "CadenasTexto.txt";

        if (!File.Exists(rutaArchivo))
        {
            Console.WriteLine("El archivo no existe.");
            return;
        }

        List<string> cadenas = new List<string>(File.ReadAllLines(rutaArchivo));

        Console.Write("Ingrese el carácter a buscar: ");
        string? entrada = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(entrada) || entrada.Length !=1)
        {
            Console.WriteLine("Debe ingresar un solo carácter");
            return;
        }

        char caracterBuscar = entrada[0];

        Console.WriteLine("\nVALIDACIONES:\n");

        foreach (string cadena in cadenas)
        {
            Console.WriteLine($"Cadena: {cadena}");

            bool esAlfabetica = EsSoloAlfabetico(cadena);
            Console.WriteLine($"Solo contiene letras?: {esAlfabetica}");

            bool longitudValida = ValidarLongitud(cadena, 5, 10);
            Console.WriteLine($"Longitud entre 5 y 10?: {longitudValida}");

            int cantidadCaracter = ContarCaracter(cadena, caracterBuscar);
            Console.WriteLine($"Cantidad de '{caracterBuscar}': {cantidadCaracter}");

        }

        Console.ReadLine();
    }

    static bool EsSoloAlfabetico(string texto)
    {
        foreach (char c in texto)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
        }
        return true;
    }

    static bool ValidarLongitud(string texto, int minimo, int maximo)
    {
        return texto.Length >= minimo && texto.Length <= maximo;
    }

    static int ContarCaracter(string texto, char caracter)
    {
        int contador = 0;

        foreach (char c in texto)
        {
            if (c == caracter)
            {
                contador++;
            }
        }

        return contador;
    }
}
