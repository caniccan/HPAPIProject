using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.DataTransferObjects.Requests
{
    public class AddCharacterRequest
    {
        [Required(ErrorMessage ="Karakter adı gereklidir.")]
        [StringLength(50,ErrorMessage ="Karakter adı 50 karakterden uzun olamaz")]
        [MinLength(3,ErrorMessage ="Karakter adı en az 3 karakterden oluşmalıdır.")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthYear { get; set; }
        public string? Gender { get; set; }
        public string? Wands { get; set; }
        [DataType(DataType.Currency)]
        public double? Height { get; set; }
        public int? Mass { get; set; }
        public string? HairColor { get; set; }
        public string? SkinColor { get; set; }
        public string? EyeColor { get; set; }
        public bool HaveNose { get; set; } = true;
        public string? Pet { get; set; }
    }
}
