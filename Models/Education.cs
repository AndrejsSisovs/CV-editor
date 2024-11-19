using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace CV_creator.Models
{
    public class Education : Entity
    {
        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string InstitutionName { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string FacultyName { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string FieldOfStudy { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string EducationLevel { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string Status { get; set; }

        
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }


        public int BasicInformationId { get; set; }
        public BasicInformation BasicInformation { get; set; }
        public Address InstitutionAddress { get; set; }
    }
}
