using System.ComponentModel.DataAnnotations;

namespace CV_creator.Models
{
    public class Skills : Entity
    {
        [MaxLength(400), Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        [MaxLength(400), Required(AllowEmptyStrings = false)]
        public string Type { get; set; }

        
        public int JobId { get; set; }
        public WorkExperience Job { get; set; }
    }
}
