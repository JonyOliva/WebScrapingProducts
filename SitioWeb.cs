using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebScrapingProducts
{
    abstract class SitioWeb
    {
        protected string url { get; set; }
        protected ScrapingBrowser browser;

        public SitioWeb(string _url)
        {
            url = _url;
        }

        public abstract Producto[] getProductos();
        protected abstract string getNombre(HtmlNode item);
        protected abstract string getPrecio(HtmlNode item);
    }
}
