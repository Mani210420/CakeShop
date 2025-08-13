using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace CakeShop.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }

        [Required(ErrorMessage = "Please Enter first Name") ]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter Address")]
        [Display(Name = "Address Line 1")]
        [StringLength(100)]
        public string AddressLine1 {  get; set; } = string.Empty;

        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please Enter zip code")]
        [Display(Name = "Zip Code")]
        [StringLength(10, MinimumLength =4)]
        public string ZipCode {  get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter City")]
        [StringLength(50)]
        public string City {  get; set; } = string.Empty;

        [StringLength(50)]
        public string? State { get; set; }

        [Required (ErrorMessage = "Please enter country")]
        [StringLength (50)]
        public string Country {  get; set; } = string.Empty;

        [Required (ErrorMessage ="Enter phone number")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
            )]
        public string Email {  get; set; } = string.Empty;

        [BindNever]
        public decimal OrderTotal { get; set; }

        [BindNever]
        public DateTime OrderPlaced { get; set; }
    }
}
