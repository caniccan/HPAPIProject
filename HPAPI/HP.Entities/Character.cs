using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.Entities
{
    public class Character : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthYear { get; set; }
        public string? Gender { get; set; }
        public string? Wands { get; set; }
        public double? Height { get; set; }
        public int? Mass { get; set; }
        public string? HairColor { get; set; }
        public string? SkinColor { get; set; }
        public string? EyeColor { get; set; }
        public bool HaveNose { get; set; } = true;
        public string? Pet { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
