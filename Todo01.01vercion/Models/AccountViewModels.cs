using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Todo01._01vercion.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [Display(Name = "Remember", ResourceType = typeof(Resources.Resource))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [MaxLength(100, ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "RegNameLen")]
        [Display(Name = "RegName", ResourceType = typeof(Resources.Resource))]
        public string Name { get; set; }

        [Required]
        [MaxLength(100, ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "RegSurnameLen")]
        [Display(Name = "RegSurname", ResourceType = typeof(Resources.Resource))]
        public string Surname { get; set; }

        [Required]
        [MaxLength(100, ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "RegPatronymicLen")]
        [Display(Name = "RegPatronymic", ResourceType = typeof(Resources.Resource))]
        public string Patronymic { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "RegPhone", ResourceType = typeof(Resources.Resource))]
        public string PhoneNumber { get; set; }

        [MaxLength(100, ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "RegCommentsLen")]       
        [Display(Name = "RegComments", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.MultilineText)]
        public string Coments { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "RegPasswordLen")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        
        public string Password { get; set; }

        [DataType(DataType.Password)]       
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "RegConfirmPassword")]
        [Display(Name = "RegConfirmPassword", ResourceType = typeof(Resources.Resource))]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "RegPasswordLen")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfNewPass")]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "RegConfirmPassword")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }
    }
}
