using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VE2C5T_HFT_2021221.Models
{
    public class PetOwner
    {
        public PetOwner(string name, string phoneNumber, int age, int salaryInHUF)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Age = age;
            SalaryInHUF = salaryInHUF;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber  { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int SalaryInHUF { get; set; }

        [NotMapped]
        public virtual ICollection<Pet> Pets { get; set; }

        public PetOwner()
        {
            Pets = new HashSet<Pet>();
        }
    }
}
