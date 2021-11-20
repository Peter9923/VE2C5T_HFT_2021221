﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE2C5T_HFT_2021221.Models
{
    public class Pet
    {
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
        public virtual PetOwner PetOwner { get; set; }

        [ForeignKey(nameof(Vet))]
        public int VetId { get; set; }

        [NotMapped]
        public virtual Vet Vet { get; set; }



    }
}
