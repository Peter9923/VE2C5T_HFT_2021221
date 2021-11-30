using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE2C5T_HFT_2021221.Models
{
    public class Vet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public double SalaryInHUF { get; set; }
        [Required]
        public int Age { get; set; }

        [NotMapped]
        public virtual ICollection<Pet> PetPatients { get; set; }

        public Vet()
        {
            PetPatients = new HashSet<Pet>();
        }

        public Vet(string name, string phoneNumber, double salaryInHUF, int age)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            SalaryInHUF = salaryInHUF;
            Age = age;
        }
    }
}
