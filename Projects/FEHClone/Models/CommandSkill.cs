using System;
using System.ComponentModel.DataAnnotations;

namespace FEHClone.Models
{
    //** Make this into an abstract class?
    public class CommandSkill
    {
        [Key]
        public int Id { get; set; }
        public int HeroId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public int Range { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // TODO: Add Hero association
    }
}