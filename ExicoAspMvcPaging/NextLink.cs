using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExicoAspMvcPaging
{
    public class NextLink : ABaseLink
    {


        public NextLink(APager p, string text)
            : base(p)
        {
            this.Text = text;
            
        }


        public override int GetPageNumber()
        {
            return _Pager.CurrentPageNumber() + 1 > _Pager.GetTotalPages() ? _Pager.GetTotalPages() : _Pager.CurrentPageNumber() + 1;
        }

        protected override bool ShouldRender()
        {
            return this._Pager.CurrentPageNumber() != _Pager.GetTotalPages();
        }
    }
}
