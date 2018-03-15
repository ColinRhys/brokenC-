using System.ComponentModel.DataAnnotations;
 
namespace theWall.Models{
    public abstract class BaseEntity{}

    public class User : BaseEntity{
        [Required]
        [MinLength(2)]
        public string first_name {get;set;}
        [Required]
        [MinLength(2)]
        public string last_name{get;set;}
        [Required]
        [EmailAddress]
        public string email{get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string password{get;set;}
        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage="Passwords must match!")]
        public string confirmPassword{get;set;}
    }
    public class LoginUser : BaseEntity{
        [Required]
        [EmailAddress]
        public string email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string password{get;set;}
    }
}