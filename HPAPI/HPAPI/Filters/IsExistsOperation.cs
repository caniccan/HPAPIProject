using HP.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HPAPI.Filters
{
    public class IsExistsOperation : IAsyncActionFilter
    {
        private readonly ICharacterService characterService;

        public IsExistsOperation(ICharacterService characterService)
        {
            this.characterService= characterService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult("Id gereklidir");
            }
            else
            {
                var id = (int)context.ActionArguments["id"];
                if (!await characterService.IsCharacterExists(id))
                {
                    context.Result = new NotFoundObjectResult(new { message = $"{id} id'li karakter bulunamadı." });
                }
                else
                {
                    await next.Invoke();
                }
            }
        }
    }
}
