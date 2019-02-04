using System.Collections.Generic;

namespace Workflow.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string SerialisedHobbies { get; set; }
        public string HobbiesAsString
        {
            get
            {
                if(this.Hobbies != null && this.Hobbies.Count > 0)
                    return string.Join(",", this.Hobbies);
                return "No Hobbies added";
            }
        }
        public List<HobbyViewModel> Hobbies { get; set; }
    }
}