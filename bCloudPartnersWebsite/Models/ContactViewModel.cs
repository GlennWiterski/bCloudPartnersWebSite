using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bCloudPartnersWebsite.ViewModel
{
    public class ContactViewModel
    {
        [Required (ErrorMessage ="Name is required")]
        [StringLength(30, ErrorMessage = "Name can be not be longer than 30 characters")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required(ErrorMessage = "A message is required")]
        [StringLength(500, ErrorMessage = "Message can not be longer than 500 characters")]
        public string Message { get; set; }

    }
}
