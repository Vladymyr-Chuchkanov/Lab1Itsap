using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TWeb1
{
    public partial class CompetitionTeam
    {
        public int CompetitionTeamId { get; set; }
        [Display(Name = "Змагання")]
        public int CompetitionId { get; set; }
        [Display(Name = "Команда")]
        public int TeamId { get; set; }
        [Display(Name = "Статус заявки")]
        public int? AdmittedId { get; set; }
        [Display(Name = "Результат")]
        public string ResultTime { get; set; }
        [Display(Name = "Час")]
        public string ClearTime { get; set; }
        [Display(Name = "Штрафи")]
        public int? Penalty { get; set; }
        [Display(Name = "Місце")]
        public int? Position { get; set; }
        [Display(Name = "Статус заявки")]

        public virtual Admition Admitted { get; set; }
        [Display(Name = "Змагання")]
        public virtual Competition Competition { get; set; }
        [Display(Name = "Команда")]
        public virtual Team Team { get; set; }
        public int? IsDeleted { get; set; }
    }
}
