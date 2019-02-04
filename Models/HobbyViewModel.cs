using System;

namespace Workflow.Models
{
    public class HobbyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Started { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}