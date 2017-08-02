using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExicoAspMvcPaging
{
    public abstract class ABaseLink : IBaseLink
    {

        protected Dictionary<string, string> _InLineStyles;//holds inline style attributes
        public string Text { get; set; }//the text
        public string Class { get; set; }//the css class name
        public string Id { get; set; }//css id name
        public string Title { get; set; }//the title tag 
        protected APager _Pager { get; set; }//reference to the Pager implementation

        public ABaseLink(APager p)
        {
            this._InLineStyles = new Dictionary<string, string>();
            this._Pager = p;
        }

        //builds the href
        public string GetHref()
        {
            string url = HttpContext.Current.Request.Url.Query;
            if (_Pager.HasPageParam())
            {
                int currentPage = this._Pager.CurrentPageNumber();
                url = url.Replace(_Pager.Options.PageParam + "=" + currentPage, _Pager.Options.PageParam + "=" + this.GetPageNumber());
            }
            else
            {
                url += ((url.Contains("?") ? "&" : "?")
                    + this._Pager.Options.PageParam
                    + "="
                    + this.GetPageNumber());
            }
            //if controller and action is specified then use them to build href
            if (_Pager.Options.Controller != null && _Pager.Options.Action != null)
            {
                return
                string.Format("/{0}/{1}{2}", _Pager.Options.Controller, _Pager.Options.Action, url);
            }
            else//else use current url
            {

                return  url;
            }
        }

        //checks if it is the currently selected link
        public Boolean IsSelected()
        {
            return this._Pager.CurrentPageNumber() == this.GetPageNumber();
        }

        //determing the page number for this link
        public abstract int GetPageNumber();

        //if this link should be rendered or not
        protected abstract Boolean ShouldRender();

        //set inline style for this link
        public void SetInlineStyle(string attribute, string value)
        {
            if (this._InLineStyles[attribute] == null)
            {
                this._InLineStyles.Add(attribute, value);
            }
            else
            {
                this._InLineStyles[attribute] = value;
            }
        }

        //builds the k=>v pair for the inline style attribute
        public string GetInlineStylesCssString()
        {
            return String.Join(";",
                                   (
                                    from pair in this._InLineStyles
                                    select String.Format("{0}:{1}", pair.Key, pair.Key)
                                   ).ToArray()
                               );
        }

        //renders the link
        public string Render()
        {
            if (this.ShouldRender())
            {
                string baseStructure = @"<a 
                                            href  ='{0}' 
                                            id    ='{1}' 
                                            class ='{2}' 
                                            title ='{3}'
                                            style ='{4}'
                                    >               {5}
                                    </a>";
                string link;
                if (this.IsSelected())
                {
                    link = this.Text;
                }
                else
                {
                    link =
                 string.Format(
                                        baseStructure,
                                        this.IsSelected() ? "#" : this.GetHref(),
                                        this.Id,
                                        this.Class + (this.IsSelected() ? "nopointer current" : ""),
                                        this.Title,
                                        this.GetInlineStylesCssString(),
                                        this.Text
                                    );
                }
                return link;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
