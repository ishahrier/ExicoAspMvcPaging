using System;
namespace ExicoAspMvcPaging
{
    interface IBaseLink
    {
        string Class { get; set; }
        string Id { get; set; }
        string Text { get; set; }
        string Title { get; set; }

        void SetInlineStyle(string attribute, string value);
        string GetHref();
        string GetInlineStylesCssString();
        int GetPageNumber();        
        bool IsSelected();
        string Render();
        
    }
}
