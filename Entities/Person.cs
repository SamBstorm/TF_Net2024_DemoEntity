using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_Net2024_DemoEntity.Entities
{
    [Table("PERSON")]
    public class Person
    {
        public Person(){}
        public Person(string firstName, string lastName, string pseudo, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Pseudo = pseudo;
            Email = email;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(name : "FIRST_NAME")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Column(name:"LAST_NAME")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Column(name: "PSEUDO")]
        public string Pseudo { get; set; }

        [Required]
        [StringLength(150)]
        [Column(name: "EMAIL")]
        [EmailAddress]
        public string Email { get; set; }

        public BankAccount BankAccount { get; set; }

        public int? HomeId { get; set; }
        public HomeAddress Home { get; set; }


        public override string ToString()
        {
            return $"ID : {Id} \n" +
                $"Firstname : {FirstName}\n" +
                $"Lastname : {LastName}\n" +
                $"Pseudo : {Pseudo}\n" +
                $"Email : {Email}";
        }
    }
}
