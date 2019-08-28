using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FEHClone.Models
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        public int WeaponId { get; set; }
        public int CommandSkillId { get; set; }
        public int SpecialSkillId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        public string MovementType { get; set; } //**Make this into an enum/interface instead? */
        public string Raritiy { get; set; } //** Have multiple rarities? */
        public string CharacterImageUrl { get; set; } // TODO: Refactor to hold character image
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Nav Properties
        public Weapon Weapon { get; set; }
        public CommandSkill CommandSkill { get; set; }
        public SpecialSkill Special { get; set; }
        // TODO: Add Weapon association (required)
        // TODO: Add CommandSkill association
        // TODO: Add SpecialSkill association
        // TODO: Add A-slot association
        // TODO: Add B-slot association
        // TODO: Add C-slot association


    }
}