using HP.DataTransferObjects.Responses;

namespace HPAPI.Models
{
    public class CacheProofModel
    {
        public IEnumerable<CharacterDisplayResponse> Characters { get; set; }
        public DateTime CacheTime { get; set; }
    }
}
