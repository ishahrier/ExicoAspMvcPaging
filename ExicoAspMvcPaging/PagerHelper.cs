using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExicoAspMvcPaging
{
    public static class PagerHelper
    {
        public static string RenderPaging(this HtmlHelper html,int totalItems,int itemsPerPage){
            Pager p = new Pager(totalItems, itemsPerPage);
            return p.Render();
        }

        public static string RenderPaging(this HtmlHelper html, int totalItems, int itemsPerPage, PagerOptions options)
        {
            Pager p = new Pager(totalItems, itemsPerPage,options);            
            return p.Render();
        }

        public static string RenderPaging(this HtmlHelper html,Pager p)
        {            
            return p.Render();
        }
    }
}
