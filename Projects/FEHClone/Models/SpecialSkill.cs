using System;
using System.ComponentModel.DataAnnotations;

namespace FEHClone.Models
{
    public class SpecialSkill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desc { get; set; }
        public int CoolDown { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // TODO: Add Hero association
    }
}