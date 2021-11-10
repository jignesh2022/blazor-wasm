#pragma checksum "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\Testeditor.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d86fd1c4dc4e2b2e23edac619b9ed4743e5d1a66"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/testeditor")]
    public partial class Testeditor : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<textarea id=\"editor\" cols=\"50\" rows=\"20\"></textarea>\r\n");
            __builder.OpenElement(1, "button");
            __builder.AddAttribute(2, "class", "btn btn-primary");
            __builder.AddAttribute(3, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 7 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\Testeditor.razor"
                                          HandleClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(4, "Format");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 9 "G:\VS2019 Projects\BlazorWebAssemblyDemo\BlazorProject\Client\Pages\Testeditor.razor"
       
    IJSObjectReference module;
    private string SelectedText = "";


    public string HTMLContent { get; set; } = "<h1>Hello World</h1>";


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/editor.js");
        }


    }

    private async Task HandleClick()
    {
        await module.InvokeVoidAsync("formatDoc", "bold", null);
    }

    public async Task FormatDoc(string command, string value = null)
    {
        await module.InvokeVoidAsync("formatDoc", command, value);
    }




#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591