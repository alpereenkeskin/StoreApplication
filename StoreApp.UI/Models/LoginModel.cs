using System.ComponentModel.DataAnnotations;

namespace StoreApp.UI.Models
{
    public class LoginModel
    {
        private string? _returnUrl;
        [Required(ErrorMessage = "Username is required !")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required !")]
        public string? Password { get; set; }
        public string ReturnUrl
        {
            get
            {
                if (_returnUrl is null)
                {
                    return "/";
                }
                else
                {
                    return _returnUrl;
                }

            }
            set
            {
                _returnUrl = value;
            }
        }


    }
}