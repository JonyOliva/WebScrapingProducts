using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;

namespace WebScrapingProducts
{
    class FullHardWeb : SitioWeb
    {
        public FullHardWeb(string _url) : base(_url)
        {
        }
        public override Producto[] getProductos()
        {
            browser = new ScrapingBrowser();
            WebPage homePage = browser.NavigateToPage(new Uri(url));
            HtmlNode[] components = homePage.Html.CssSelect("div.item.product-list div.info").ToArray();
            return Producto.assemble(components, getNombre, getPrecio);
        }

        protected override string getNombre(HtmlNode item)
        {
            return item.CssSelect("h3").FirstOrDefault().InnerText.Trim();
        }

        protected override string getPrecio(HtmlNode item)
        {
            string pStr = item.CssSelect("div.price").FirstOrDefault().InnerText.Replace(".00", "").Replace("$", "");
            return pStr.Substring(0, pStr.IndexOf(' '));
        }
    }
}
