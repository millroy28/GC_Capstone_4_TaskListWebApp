#pragma checksum "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01d95fbdaabe0cd7d1e550f83d66e6f5272b5f5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TaskList_Index), @"mvc.1.0.view", @"/Views/TaskList/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\_ViewImports.cshtml"
using GC_CAPSTONE4_TASKLIST;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\_ViewImports.cshtml"
using GC_CAPSTONE4_TASKLIST.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01d95fbdaabe0cd7d1e550f83d66e6f5272b5f5b", @"/Views/TaskList/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b45e59d3184490b45c04925fc37b865465e06fb3", @"/Views/_ViewImports.cshtml")]
    public class Views_TaskList_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<EachTask>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h1>Your Tasklist:</h1>\r\n\r\n");
#nullable restore
#line 10 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
 if (Model.Count == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>Welcome! It appears your task list is empty!</h2>\r\n    <h3>Click <a href=\"/TaskList/AddTask\">here</a> to begin adding tasks!</h3>\r\n");
#nullable restore
#line 14 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<table class=""table"">
    <tr>
        <td><a href=""/TaskList/ViewAll"">View All Tasks</a></td>
        <td><a href=""/TaskList/Index"">View Only Complete Tasks</a></td>
        <td><a href=""/TaskList/AddTask"">Add A Task</a></td>
    </tr>
</table>
<table class=""table table-primary"">
    <tr>
        <th>Task Title</th>
        <th>Description</th>
        <th>Days Until Due</th>
        <th>Due Date</th>
        <th>Completion</th>
        <th>Edit Task</th>
        <th>Delete Task</th>

    </tr>
");
#nullable restore
#line 35 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
     foreach (var t in Model)
    {
        //converts database date to c# DateTime
        //saves difference as string indicating days till due or "past due"
        DateTime dueDate = Convert.ToDateTime(t.DueDate);
        int daysUntillDue = (dueDate - DateTime.Now).Days;
        string daysUntilDueString = daysUntillDue.ToString();
        if(daysUntillDue < 0)
        {
            daysUntilDueString = "Past Due!";
        }
        else if (daysUntillDue == 0)
        {
            daysUntilDueString = "Today!";
        }


        if (t.Complete == false)
        {
         
            if (t.DueDate < DateTime.Today)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"text-danger\">\r\n                    <td>");
#nullable restore
#line 58 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
                   Write(t.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 59 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
                   Write(t.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 60 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
                   Write(daysUntilDueString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 61 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
                   Write(dueDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1725, "\"", 1771, 2);
            WriteAttributeValue("", 1732, "/TaskList/CompleteStatusToggle?id=", 1732, 34, true);
#nullable restore
#line 62 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
WriteAttributeValue("", 1766, t.Id, 1766, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Incomplete</a></td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1820, "\"", 1854, 2);
            WriteAttributeValue("", 1827, "/TaskList/EditTask?id=", 1827, 22, true);
#nullable restore
#line 63 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
WriteAttributeValue("", 1849, t.Id, 1849, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a></td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1897, "\"", 1933, 2);
            WriteAttributeValue("", 1904, "/TaskList/DeleteTask?id=", 1904, 24, true);
#nullable restore
#line 64 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
WriteAttributeValue("", 1928, t.Id, 1928, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a></td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 67 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 71 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
                   Write(t.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 72 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
                   Write(t.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 73 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
                   Write(daysUntilDueString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 74 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
                   Write(dueDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 2266, "\"", 2312, 2);
            WriteAttributeValue("", 2273, "/TaskList/CompleteStatusToggle?id=", 2273, 34, true);
#nullable restore
#line 75 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
WriteAttributeValue("", 2307, t.Id, 2307, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Incomplete</a></td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 2361, "\"", 2395, 2);
            WriteAttributeValue("", 2368, "/TaskList/EditTask?id=", 2368, 22, true);
#nullable restore
#line 76 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
WriteAttributeValue("", 2390, t.Id, 2390, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a></td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 2438, "\"", 2474, 2);
            WriteAttributeValue("", 2445, "/TaskList/DeleteTask?id=", 2445, 24, true);
#nullable restore
#line 77 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
WriteAttributeValue("", 2469, t.Id, 2469, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a></td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 80 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"
            }
        }

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n");
#nullable restore
#line 85 "C:\Users\millr\source\repos\GC_CAPSTONE4_TASKLIST\GC_CAPSTONE4_TASKLIST\Views\TaskList\Index.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<EachTask>> Html { get; private set; }
    }
}
#pragma warning restore 1591