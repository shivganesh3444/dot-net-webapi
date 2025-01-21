using books_list_api.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace books_list_api.ActionResult
{
    public class CustomActionResultType : IActionResult
    {
        private readonly CustomActionResultVM _customActionResultVM;
        public CustomActionResultType(CustomActionResultVM customActionResultVM) {
         _customActionResultVM = customActionResultVM;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var ObjectResult = new ObjectResult
                (_customActionResultVM.Exception ?? _customActionResultVM.Publishers as object)
            {
                StatusCode = _customActionResultVM.Exception != null ? StatusCodes.Status500InternalServerError
                                : StatusCodes.Status200OK
            };

            await ObjectResult.ExecuteResultAsync(context);
        }
    }
}
