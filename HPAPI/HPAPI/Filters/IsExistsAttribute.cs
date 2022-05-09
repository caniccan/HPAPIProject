using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HPAPI.Filters
{
    public class IsExistsAttribute : TypeFilterAttribute
    {
        public IsExistsAttribute() : base(typeof(IsExistsOperation))
        {
        }
    }
}
