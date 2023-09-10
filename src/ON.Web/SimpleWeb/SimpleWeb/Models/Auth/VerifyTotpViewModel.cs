using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.Auth
{
    public class VerifyTotpViewModel
    {
        public VerifyTotpViewModel() { }

        public string TotpID { get; set; }

        [Display(Name = "Device Name")]
        [Required]
        [StringLength(40, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        public string DeviceName { get; set; }

        [Display(Name = "One Time Code from Device")]
        [Required]
        [StringLength(6, ErrorMessage = "{0} length must be {2} numbers.", MinimumLength = 6)]
        public string Code { get; set; }

        public string QRCode { get; set; }
        public string Key { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
