using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
namespace ExicoAspMvcPaging
{
    public class Pager : APager
    {

        public Pager(int TotalItems, int ItemsPerPage, PagerOptions options)
            : base(TotalItems, ItemsPerPage, options)
        {
        }

        public Pager(int TotalItems, int ItemsPerPage)
            : base(TotalItems, ItemsPerPage)
        {
        }

        public override string Render()
        {
            if (GetTotalPages() <= 1 && !this.Options.ShowEvenOnlyOnePage) return "";

            Dictionary<string, string> html = new Dictionary<string, string>();

            html["f"] = null;
            html["l"] = null;
            html["p"] = null;
            html["n"] = null;

            if (this.Options.ShowFirstAndLast)
            {
                html["f"] = new FirstLink(this, this.Options.FirstText) { Class = "firstlast" }.Render();
                html["l"] = new LastLink(this, this.Options.LastText) { Class = "firstlast" }.Render();
            }
            if (this.Options.ShowNextAndPrev)
            {
                html["p"] = new PrevLink(this, this.Options.PrevText) { Class = "nextprev" }.Render();
                html["n"] = new NextLink(this, this.Options.NextText) { Class = "nextprev" }.Render();
            }

            //@TODO : think about it later
            int from = this.Options.ShowFirstAndLast ? 2 : 1;
            int to = this.Options.ShowFirstAndLast ? this.GetTotalPages() - 1 : this.GetTotalPages();

            IList<string> links = new List<string>();

            int halfPage = this.Options.NumberOfPagesToDisplay/2;
            int startPage = this.CurrentPageNumber() - halfPage;
            if (this.CurrentPageNumber() + halfPage > this.GetTotalPages())
            {
                startPage = this.GetTotalPages() - this.Options.NumberOfPagesToDisplay + 1;
            }
            if (startPage <= 0) startPage = 1;
            int pagePrint = 1;
            bool started = false;

            for (int i = 1; i <= this.GetTotalPages(); i++)
            {
                bool display = false;
                if (this.Options.NumberOfPagesToDisplay > 0)
                {
                    if (!started && i == startPage)
                    {
                        started = true;
                    }
                    if (started && pagePrint <= this.Options.NumberOfPagesToDisplay)
                    {
                        display = true;
                        pagePrint++;
                    }


                }
                if (this.Options.NumberOfPagesToDisplay <= 0 || display)
                {
                    links.Add(new NumberedLink(this, i).Render());
                }
            }

            html["a"] = String.Join("", links.ToArray());//all other links

            List<string> final = new List<string>();
            final.Add(html["f"] ?? "");
            final.Add(html["p"] ?? "");
            final.Add(html["a"] ?? "");
            final.Add(html["n"] ?? "");
            final.Add(html["l"] ?? "");


            return string.Format("<div class='{0}' >{1}</div>",
                                  this.Options.WrapperDivClass,
                                  string.Join("", final.ToArray())
                                );

        }


    }
}
