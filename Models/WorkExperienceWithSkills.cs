namespace CV_creator.Models
{
    public class WorkExperienceWithSkills
    {
        public WorkExperience WorkExperience { get; set; }
        public List<Skills> Skills { get; set; } = new List<Skills>();
        public Skills NewSkill { get; set; }
        public List<Address> Address { get; set; }
        public Address NewAddress { get; set; }

    }
}
