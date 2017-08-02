using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExicoAspMvcPaging
{
    public abstract class APager : IPager
    {
        public APager(int totalItems, int itemsPerPage)
            : this(totalItems, itemsPerPage, new PagerOptions())
        {

        }

        public APager(int totalItems, int itemsPerPage, PagerOptions options)
        {
            this.TotalItems = totalItems;
            this.ItemsPerPage = itemsPerPage;
            this.Options = options;


        }

        public int TotalItems { get; set; }//total count of the collection
        public int ItemsPerPage { get; set; }//number of items to be displayed per page
        public PagerOptions Options { get; set; }//options/configuration


        //checks if url has page param
        public Boolean HasPageParam()
        {
            return !(HttpContext.Current.Request.QueryString[this.Options.PageParam] == null);
        }

        //determines the current page number by reading the page param in the url
        public int CurrentPageNumber()
        {
            if (!this.HasPageParam())
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(HttpContext.Current.Request.QueryString[this.Options.PageParam]);
            }
        }

        //how many pages will there be 
        public int GetTotalPages()
        {
            int pages = (int)TotalItems / ItemsPerPage;
            pages += TotalItems % ItemsPerPage > 0 ? 1 : 0;
            return pages;
        }

        //renders the numbered links,first and last (if enabled), prev and next (if enabled)
        public abstract string Render();
        //generate a recommended css theme
        public static string GenerateDefaultCssTheme(string wrapperDivClassName)
        {
            string divClass = wrapperDivClassName ?? "{0}";
            if (!divClass.StartsWith(".")) divClass = "." + divClass;

            return String.Format(
                            @"      {0} {  
                                        padding: 1em;
                                        margin: 1em 0;
                                        clear: left;
                                        font-family:Tahoma;
                                        font-size:12px;
                                        
                                    }

                                    {0} a {
	                                    color:#006643;
                                        display: block;
                                        float: left;
                                        padding: 0.2em 0.5em;
                                        margin-right: 0.2em;
                                        border: 1px solid #006643;
                                        background: #fff;
                                        text-decoration: none;
                                    }


                                    {0} a.current {
                                        border: 1px solid #006643;
                                        font-weight: bold;
                                        background: #006643;
                                        color: #fff;
                                    }
                                    {0} a.nopointer {
                                        cursor:default;
                                    }


                                    {0} a:hover {
                                        border-color: #006643;
                                        background:#006643;
                                        color:White;
                                    }

                                    {0} a.firstlast {
                                        font-weight: bold;
                                    }", divClass);
        }

        

  
    }
}

