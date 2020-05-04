using HtmlAgilityPack;
using System;
using System.Linq;
using System.Collections.Generic;

namespace WebScrapingProducts
{
    public class Producto
    {
        public double Precio { get; set; }
        public string Nombre { get; set; }
        public int Idcategoria { get; set; }
        public int Stock { get; set; }

        public static Producto[] assemble(HtmlNode[] components, Func<HtmlNode, string> getNombre, Func<HtmlNode, string> getPrecio)
        {
            List<Producto> resultados = new List<Producto>();
            Random rng = new Random();
            string[] perifericos = new string[] { "mouse", "teclado", "cable", "auriculares", "joystick"};
            foreach (var item in components)
            {
                Producto prod = new Producto();
                prod.Nombre = getNombre(item);
                prod.Precio = float.Parse(getPrecio(item));
                prod.Stock = rng.Next(0, 25);
                prod.Idcategoria = ((prod.Nombre.Split(' ').Where(x => perifericos.Contains(x.ToLower()))).Count() != 0) ? 2 : 1;
                resultados.Add(prod);
            }
            return resultados.ToArray();
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, \nPrecio: {Precio}, \nCat: {Idcategoria}, \nStock: {Stock}\n";
        }
    }
}
