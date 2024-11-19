using System.ComponentModel.DataAnnotations;

namespace CV_creator.Models
{
    public class WorkExperience : Entity
    {
        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string PositionHeld { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string EmploymentType { get; set; }

        
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        
        public int BasicInformationId { get; set; }
        public BasicInformation BasicInformation { get; set; }
        public ICollection<Skills> Skills { get; set; }
        public ICollection<Address> WorkAddresses { get; set; } = new List<Address>();
    }
}
