using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebScrapingProducts
{
    class SQLFile
    {
        private Producto[] prods { get; }

        public SQLFile(Producto[] productos)
        {
            prods = productos;
        }
        public void saveToDisk()
        {
            if (prods.Length == 0)
                return;

            using (FileStream file = new FileStream("SQLFile.sql", FileMode.Append, FileAccess.Write))
            {
                StreamWriter writer = new StreamWriter(file); 
                foreach (Producto item in prods)
                {
                    writer.WriteLine(getSQLInsert(item));
                }
                writer.Close();
            }
            return;
        }
        private string getSQLInsert(Producto p)
        {
            return $"INSERT INTO PRODUCTOS(Precio_Prod, Nombre_Prod, IDCategoria_Prod, Stock_Prod) \nSELECT {p.Precio}, '{p.Nombre}', {p.Idcategoria}, {p.Stock} \n";
        }
    }
}
