using System;
using System.ComponentModel.DataAnnotations;

namespace FEHClone.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desc { get; set; }
        public int Slot { get; set; } //**Make this into an enum instead? 1||2||3*/
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // TODO: Add Hero association

        public enum SlotLocation {A, B, C};
    }
}