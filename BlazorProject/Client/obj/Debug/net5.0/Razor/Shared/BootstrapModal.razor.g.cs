#pragma checksum "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Shared\BootstrapModal.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f679c76ac2b5b26d4ed8421b42cfb66a75af1e1b"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorProject.Client.Shared
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
    public partial class BootstrapModal : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "modal" + " " + (
#nullable restore
#line 1 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Shared\BootstrapModal.razor"
                   modalClass

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "tabindex", "-1");
            __builder.AddAttribute(3, "role", "dialog");
            __builder.AddAttribute(4, "style", "display:" + (
#nullable restore
#line 1 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Shared\BootstrapModal.razor"
                                                                           modalDisplay

#line default
#line hidden
#nullable disable
            ) + ";" + " overflow-y:" + " auto;");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "modal-dialog modal-lg");
            __builder.AddAttribute(7, "role", "document");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "modal-content");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "modal-header");
            __builder.OpenElement(12, "h5");
            __builder.AddAttribute(13, "class", "modal-title");
            __builder.AddContent(14, 
#nullable restore
#line 5 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Shared\BootstrapModal.razor"
                                         Title

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n                ");
            __builder.OpenElement(16, "button");
            __builder.AddAttribute(17, "type", "button");
            __builder.AddAttribute(18, "class", "close");
            __builder.AddAttribute(19, "data-dismiss", "modal");
            __builder.AddAttribute(20, "aria-label", "Close");
            __builder.AddAttribute(21, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 6 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Shared\BootstrapModal.razor"
                                                                                                      Close

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(22, "<span aria-hidden=\"true\">&times;</span>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n            ");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "modal-body");
            __builder.AddContent(26, 
#nullable restore
#line 11 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Shared\BootstrapModal.razor"
                 Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n            ");
            __builder.OpenElement(28, "div");
            __builder.AddAttribute(29, "class", "modal-footer");
            __builder.AddContent(30, 
#nullable restore
#line 14 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Shared\BootstrapModal.razor"
                 Footer

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 20 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Shared\BootstrapModal.razor"
 if (showBackdrop)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(31, "<div class=\"modal-backdrop fade show\"></div>");
#nullable restore
#line 23 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Shared\BootstrapModal.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 25 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Shared\BootstrapModal.razor"
       
    [Parameter]
    public RenderFragment Title { get; set; }

    [Parameter]
    public RenderFragment Body { get; set; }

    [Parameter]
    public RenderFragment Footer { get; set; }

    private string modalDisplay = "none;";
    private string modalClass = "";
    private bool showBackdrop = false;

    public void Open()
    {
        modalDisplay = "block;";
        modalClass = "show";
        showBackdrop = true;
    }

    public void Close()
    {
        modalDisplay = "none";
        modalClass = "";
        showBackdrop = false;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591