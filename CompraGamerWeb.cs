using System;
using System.Collections.Generic;
using System.Text;
using ScrapySharp.Network;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System.Linq;

namespace WebScrapingProducts
{
    class CompraGamerWeb : SitioWeb
    {
        public CompraGamerWeb(String _url) :base(_url)
        {
        }

        public override Producto[] getProductos()
        {
            browser = new ScrapingBrowser();
            WebPage homePage = browser.NavigateToPage(new Uri(url));
            HtmlNode[] components = homePage.Html.CssSelect("li.products__item div.products__wrap.clearfix").ToArray();
            return Producto.assemble(components, getNombre, getPrecio);
        }

        protected override string getNombre(HtmlNode item)
        {
            return item.CssSelect("h4.products__name").FirstOrDefault().InnerText.Trim();
        }

        protected override string getPrecio(HtmlNode item)
        {
            return string.Concat(item.CssSelect("span.products__price-new").FirstOrDefault().InnerText.Where( x => Char.IsDigit(x)));
        }
    }
}
