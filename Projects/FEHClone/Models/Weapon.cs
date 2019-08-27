using System;
using System.ComponentModel.DataAnnotations;

namespace FEHClone.Models
{
    public class Weapon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desc { get; set; }
        public string WeaponType { get; set; }
        [Required]
        public int Range { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // TODO: Add Hero association
    }
}