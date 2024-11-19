using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CV_creator.Models
{
    public class BasicInformation : Entity
    {
        [MaxLength(200), Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [MaxLength(200), Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [MaxLength(200), Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [MaxLength(200), Required(AllowEmptyStrings = false)]
        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }


        public ICollection<Education> Educations { get; set; } = new List<Education>();
        public ICollection<WorkExperience> Jobs { get; set; } = new List<WorkExperience>();
        public Address ResidenceAddress { get; set; }
    }
}
