using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExicoAspMvcPaging
{
    public class NumberedLink:ABaseLink
    {
        private int _PageNumber;
        public NumberedLink(APager p,int number)
            : base(p)
        {
            this.Text = (number).ToString();
            this._PageNumber = number;
        }
        public override int GetPageNumber()
        {
            return this._PageNumber;
        }

        protected override bool ShouldRender()
        {
            return true;
        }
    }
}
