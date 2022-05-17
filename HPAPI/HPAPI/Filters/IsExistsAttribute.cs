using HP.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HPAPI.Filters
{
    public class IsExistsAttribute : TypeFilterAttribute
    {
        //public ICharacterService CharacterService { get; set; }
        public IsExistsAttribute() : base(typeof(IsExistsOperation))
        {
            
            

            
        }
    }
}
