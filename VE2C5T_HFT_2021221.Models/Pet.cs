using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VE2C5T_HFT_2021221.Models
{
    public class Pet
    {
        public Pet(string name, string species, double weight, int age, int monthlyCostInHUF, int petOwnerId, int vetId)
        {
            Name = name;
            Species = species;
            Weight = weight;
            Age = age;
            MonthlyCostInHUF = monthlyCostInHUF;
            PetOwnerId = petOwnerId;
            VetId = vetId;
        }
        public Pet()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Species { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int MonthlyCostInHUF { get; set; }

        [ForeignKey(nameof(PetOwner))]
        public int PetOwnerId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual PetOwner PetOwner { get; set; }

        [ForeignKey(nameof(Vet))]
        public int VetId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Vet Vet { get; set; }
    }
}
