using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExicoAspMvcPaging
{
    public class FirstLink : ABaseLink
    {
  

        public FirstLink(APager p, string text)
            : base(p)
        {
            this.Text = text;
            
        }


        public override int GetPageNumber()
        {
            return 1;
        }

        protected override bool ShouldRender()
        {
            return this._Pager.CurrentPageNumber() == 1 ? false : true;
        }
    }
}
