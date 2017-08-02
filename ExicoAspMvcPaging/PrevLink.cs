using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExicoAspMvcPaging
{
    public class PrevLink:ABaseLink
    {

        public PrevLink(APager p, string text)
            : base(p)           
        {
            this.Text = text;
            
        }

        public override int GetPageNumber()
        {
            return _Pager.CurrentPageNumber() == 1 ? 1 : _Pager.CurrentPageNumber()-1;
        }

        protected override bool ShouldRender()
        {
            return  !(_Pager.CurrentPageNumber() == 1);
        }
    }
}