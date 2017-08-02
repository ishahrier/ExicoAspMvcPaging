using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExicoAspMvcPaging
{
    public class LastLink:ABaseLink
    {


        public LastLink(APager p,string text):base(p)           
        {
            this.Text = text;            
        }


        public override int GetPageNumber()
        {
            return _Pager.GetTotalPages();
        }

        protected override bool ShouldRender()
        {
            return !(this._Pager.CurrentPageNumber() == this._Pager.GetTotalPages());
        }
    }
}
