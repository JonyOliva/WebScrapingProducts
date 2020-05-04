using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace WebScrapingProducts
{
    class FullHardWeb : SitioWeb
    {
        public FullHardWeb(string _url) : base(_url)
        {
        }
        public override Producto[] getProductos()
        {
            throw new NotImplementedException();
        }

        protected override string getNombre(HtmlNode item)
        {
            throw new NotImplementedException();
        }

        protected override string getPrecio(HtmlNode item)
        {
            throw new NotImplementedException();
        }
    }
}
