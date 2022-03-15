using System.ComponentModel.DataAnnotations;

namespace ManagingDevices.Domain.Models
{
    public class DeviceRequestModel
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Model { get; set; }
        [Required]
        [MaxLength(255)]
        public string Manafacturer { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReleaseDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateTaken { get; set; }
    }
}
