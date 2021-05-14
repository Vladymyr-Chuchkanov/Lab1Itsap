using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TWeb1
{
   
    public partial class Result
    {
        public int ResultId { get; set; }
        [Display(Name = "Учасник")]
        public int PartisipantId { get; set; }
        [Display(Name = "Етап")]
        public int ObstacleCompetitionId { get; set; }
        [Display(Name = "Час")]
        public string Time { get; set; }
        [Display(Name = "Штраф")]
        public int Penalty { get; set; }
        [Display(Name = "Етап")]

        public virtual ObstacleCompetition ObstacleCompetition { get; set; }
        [Display(Name = "Учасник")]
        public virtual Partisipant Partisipant { get; set; }


        
        
    }
}
