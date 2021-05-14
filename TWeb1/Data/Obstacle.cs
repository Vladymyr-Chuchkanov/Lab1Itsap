using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TWeb1
{
    public partial class Obstacle
    {
        public Obstacle()
        {
            ObstacleCompetitions = new HashSet<ObstacleCompetition>();
        }

        public int ObstacleId { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Display(Name = "Опис")]
        public string AdditionalDescription { get; set; }
        [Display(Name = "Обладнання ВД")]
        public string EquipmentStart { get; set; }
        [Display(Name = "Обладнання ДП")]
        public string EquipmentObstacle { get; set; }
        [Display(Name = "Обладнання ЦД")]
        public string EquipmentTarget { get; set; }
        [Display(Name = "Довжина")]
        public int? Length { get; set; }
        [Display(Name = "Набір висоти")]
        public int? Height { get; set; }
        [Display(Name = "Рух першого")]
        public string MovementFirst { get; set; }
        [Display(Name = "Умови подолання")]
        public string ConditionsOvercoming { get; set; }
        /*[Display(Name = "Умовна складність")]
        public string ConditionalComplexity { get; set; }
        [Display(Name = "Оцінка етапа")]
        public int? ObstacleEvaluation { get; set; }*/
        [Display(Name = "Оптимальний час")]
        public string OptTime { get; set; }
        [Display(Name = "Контрольний час")]
        public string CriticalTime { get; set; }
        public virtual ICollection<ObstacleCompetition> ObstacleCompetitions { get; set; }

        public int IsDeleted { get; set; }
    }
}
