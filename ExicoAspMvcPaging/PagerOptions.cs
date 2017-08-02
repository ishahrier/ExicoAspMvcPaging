using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExicoAspMvcPaging
{
    public class PagerOptions
    {
        public string  NextText { get; set; }//the text for the next link
        public string  PrevText { get; set; }//text for the previous link
        public string  FirstText { get; set; }//text for the first link
        public string  LastText { get; set; }//text for the first link
        public string  WrapperDivClass { get; set; }//the class name for the div that sorrounds the links
        public Boolean ShowFirstAndLast { get; set; }//toggle on and off displaying the "First" and "Last" link
        public Boolean ShowNextAndPrev { get; set; }//toggle on and off displaying the "Prev" and "Next" link
        public string  Controller { get; set; }//if a controller is specified
        public string  Action { get; set; }//if an action is specified
        public string  PageParam { get; set; }//the page url param default is "page"  
        public Boolean ShowEvenOnlyOnePage { get; set; }//render the pager even if there is only one page
        public int NumberOfPagesToDisplay { get; set; } // the number of page links that will be shown on a page
        
        public PagerOptions()
        {
            this.PageParam          = "page";
            this.WrapperDivClass    = "pages";
            this.ShowFirstAndLast   = true;
            this.ShowNextAndPrev    = true;
            this.FirstText          = "First";
            this.LastText           = "Last";
            this.NextText           = ">";
            this.PrevText           = "<";
            this.Controller         = null;
            this.Action             = null;
            this.ShowEvenOnlyOnePage= false;
            this.NumberOfPagesToDisplay = 0; //will display links for every page number by default

        }
    }
}
