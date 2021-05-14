using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TWeb1
{
    public partial class Admition
    {
        public Admition()
        {
            CompetitionTeams = new HashSet<CompetitionTeam>();
        }

        public int AdmittedId { get; set; }
        [Display(Name = "Статус заявки")]
        public string Name { get; set; }

        public virtual ICollection<CompetitionTeam> CompetitionTeams { get; set; }
    }
}
