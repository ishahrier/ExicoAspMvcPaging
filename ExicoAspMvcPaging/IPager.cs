using System;
namespace ExicoAspMvcPaging
{
    interface IPager
    {        
        string Render();
        bool   HasPageParam();
        int    GetTotalPages();
        int    CurrentPageNumber();

        PagerOptions Options { get; set; }

        
        int    ItemsPerPage { get; set; }
        int    TotalItems { get; set; }
        
    }
}
