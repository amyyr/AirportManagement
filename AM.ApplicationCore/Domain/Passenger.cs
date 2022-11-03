using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; } 
        public virtual ICollection<Flight> flights { get; set; }
        [Display(Name = "date of birth"),DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        [StringLength(7)]
        public String PassportNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public String EmailAddress { get; set; }
        [MaxLength(25, ErrorMessage ="le nom est >25 caractéres")]
        [MinLength(3, ErrorMessage ="le nom est <3 caractéres")]
        public String FirstName { get; set; }
        public String LastName { get; set; }
 
        [RegularExpression(@"^[^0-9]{8}$", ErrorMessage = "doit etre numero valid")]

        public String TelNumber { get; set; }




        public bool CheckProfile(String FirstName,String LastName)
        {
            return this.FirstName.Equals(FirstName) && this.LastName.Equals(LastName);
        }
        public bool CheckProfile(String FirstName, String LastName,String EmailAdress)
        {
            return this.FirstName.Equals(FirstName) && this.LastName.Equals(LastName)&& this.EmailAddress.Equals(EmailAdress);
        }
        public override string? ToString()
        {
            return "\nBirthday : "+ BirthDate.ToString()+ " PassportNumber : " + PassportNumber.ToString() + " EmailAdress : " + EmailAddress.ToString()+ " LastName : " + LastName.ToString()+ " TelNumber : " + TelNumber.ToString();
        }
    
    
    
        public virtual void PassengerType()
        {

            Console.WriteLine("im a passanger ");
           
        }
    
    }



}
