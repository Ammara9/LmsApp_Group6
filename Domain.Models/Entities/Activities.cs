using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class Activities
    {
        public int Id { get; set; } //primär nyckel
        public int ModuleId { get; set; } //FK
        public int ActivityTypeId { get; set; } //FK

        public Module? Module { get; set; } //NP
        public ActivityType? ActivityType { get; set; } //NP
        public string ActivityName { get; set; } = string.Empty;
        public string ActivityDescription { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
