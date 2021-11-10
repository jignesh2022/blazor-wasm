#pragma checksum "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\ViewBlog.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be9cc3a07d3049d8b3d19650d56e19f205208a5c"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorProject.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\_Imports.razor"
using BlazorProject.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\_Imports.razor"
using BlazorProject.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\ViewBlog.razor"
using BlazorProject.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\ViewBlog.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\ViewBlog.razor"
using Newtonsoft.Json.Linq;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/viewblog/{BlogId:int}")]
    public partial class ViewBlog : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "style", "background-color:#FFFFFF; padding:10px;");
#nullable restore
#line 8 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\ViewBlog.razor"
     if (Blog != null)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "title");
            __builder.AddContent(4, 
#nullable restore
#line 11 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\ViewBlog.razor"
             Blog.Title

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddContent(5, 
#nullable restore
#line 13 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\ViewBlog.razor"
          $"{Blog.UpdatedAt.ToString()} | {@Blog.CreatedBy}"

#line default
#line hidden
#nullable disable
            );
            __builder.OpenElement(6, "div");
            __builder.AddContent(7, 
#nullable restore
#line 14 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\ViewBlog.razor"
              Blog.Summary

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n        <br>\r\n        ");
            __builder.OpenElement(9, "div");
            __builder.AddContent(10, 
#nullable restore
#line 16 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\ViewBlog.razor"
               (MarkupString)Blog.Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 17 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\ViewBlog.razor"
    }
    else
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(11, "<div class=\"alert alert-secondary\">Not found.</div>");
#nullable restore
#line 21 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\ViewBlog.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 23 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\ViewBlog.razor"
       

    [Parameter]
    public int BlogId { get; set; }

    private Blog Blog;

    /*protected override async Task OnInitializedAsync()
    {
        if (BlogId > 0)
        {
            Blog = await BlogService.GetBlog(BlogId);
        }
    }*/

    protected override async Task OnInitializedAsync()
    {
        if (BlogId > 0)
        {
            ResponseDTO rdto = await BlogService.GetBlog(BlogId);

            if(rdto.StatusCode == 200)
            {               
                Blog = ((JObject)rdto.Data).ToObject<Blog>();             

            }
        }
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Services.IBlogService BlogService { get; set; }
    }
}
#pragma warning restore 1591
