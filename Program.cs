using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace WebScrapingProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            string opc = "";
            List<string> urls = new List<string>();
            List<Producto> productos = new List<Producto>();
            Action Menu = () =>
            {
                Console.Clear();
                Console.WriteLine($"    Urls: {urls.Count}   -   Productos obtenidos: {productos.Count}");
                Console.WriteLine("0. Salir");
                Console.WriteLine("1. Ingresar url");
                Console.WriteLine("2. Obtener productos");
                Console.WriteLine("3. Crear cadena sql y guardar");
                Console.Write("\nDigite una opcion: ");
            };
            while (true)
            {
                Menu();
                opc = Console.ReadLine();
                Console.Clear();
                switch (opc)
                {
                    case "1":
                        Console.Write("Ingrese la URL: ");
                        string urlInput = Console.ReadLine();
                        urls.Add(urlInput.Trim());
                        break;
                    case "2":
                        if (urls.Count == 0)
                            break;
                        
                        foreach (string url in urls.ToArray())
                        {
                            SitioWeb site;
                            if (url.Contains("compragamer"))
                            {
                                site = new CompraGamerWeb(url);
                            }
                            else if (url.Contains("fullh4rd"))
                            {
                                site = new FullHardWeb(url);
                            }
                            else
                            {
                                Console.WriteLine("Error! url invalida");
                                return;
                            }
                            Thread thread = new Thread(() => { 
                                productos.AddRange(site.getProductos());
                                Menu();
                            });
                            thread.Start();
                        }
                        urls.Clear();
                        break;
                    case "3":
                        if (productos.Count == 0)
                            break;
                        SQLFile tosql = new SQLFile(productos.ToArray());
                        productos.Clear();
                        Thread fileThread = new Thread(() => {
                            tosql.saveToDisk();
                        });
                        fileThread.Start();
                        break;
                    case "0":
                    default:
                        return;
                }
            }

        }

        void Menu()
        {

        }

    }
}
