using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT_Auth.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [Required, MaxLength(30), MinLength(5)]
        public string Name {  get; set; }
        [Required, MaxLength(30), MinLength(5)]
        public string Email {  get; set; }
        [Required, MaxLength(30), MinLength(6)]
        public string Password {  get; set; }
        [MaxLength(30), MinLength(3)]
        public string Phone {  get; set; }
        [MaxLength(30), MinLength(3)]
        public string PhoneNumber {  get; set; }
        //added default value sql: "getdate()"
        public DateTime CreationDate { get; set; }
        //added default value: false
        public bool EmailConfirmed {  get; set; }
        
    }
}
