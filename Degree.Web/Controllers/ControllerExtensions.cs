using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Degree.Web.Controllers
{
    internal static class ControllerExtensions
    {
        internal static async Task<string> RenderView<DataModel>(this Controller controller, ICompositeViewEngine viewEngine, string viewName, DataModel model)
        {
            var view = viewEngine.FindView(controller.ControllerContext, viewName, false).View;
            controller.ViewData.Model = model;
            using (var writer = new StringWriter())
            {
                await view.RenderAsync(new ViewContext(controller.ControllerContext, view, controller.ViewData, controller.TempData, writer, new HtmlHelperOptions()));
                return writer.ToString();
            }
        }
    }
}
