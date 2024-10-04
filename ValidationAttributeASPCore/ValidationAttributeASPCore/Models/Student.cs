using System.ComponentModel.DataAnnotations;

namespace ValidationAttributeASPCore.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Please fill this box.")]
        //[StringLength(15, MinimumLength = 3, ErrorMessage ="Name must be with in 3 to 15 characters.")]
        //[MaxLength(15)]
        [MinLength(3, ErrorMessage = "Minimum length must be 3.")]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please fill this box.")]
        //[EmailAddress]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage ="Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please fill this box.")]
        [Range(10, 50, ErrorMessage = "Your age must be bewteen 10 to 50.")]
        public int? Age { get; set; }

        //[Required(ErrorMessage = "Please fill this box.")]
        //[RegularExpression("(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Uppercase, lowercase, Numbers, symbols, Min 8 Chars.")]
        //public string Password { get; set; }

        //[Required(ErrorMessage = "Please fill this box.")]
        //[Compare("Password", ErrorMessage = "Your given password is not matching.")]
        //[Display(Name = "Enter Confirm Password")]
        //public string CPassword { get; set; }

        //[Required(ErrorMessage = "Please fill this box.")]
        //[RegularExpression("^((\\+92)|(0092))-{0,1}\\d{3}-{0,1}\\d{7}$|^\\d{11}$|^\\d{4}-\\d{7}$", ErrorMessage = "Please enter valid phone number.")]
        //public string PhoneNumber { get; set; }

        //[Required(ErrorMessage = "Please fill this box.")]
        //[Url(ErrorMessage = "Invalid URL.")]
        //public string WebSiteURL { get; set; }
    }
}
