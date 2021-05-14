using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWeb1
{
    
    public class DictItem
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
    public class dAppItem
    {
        public string Role { get; set; }
        public int AccId { get; set; }

        public int idP { get; set; }

    }
    public class ObstaclesList
    {
        public string str { get; set; }
        public int id { get; set; }
        public List<Obstacle> Obstacles { get; set; }
        public string Search { get; set; }
        public int calc { get; set; }

    }
    public class EditObstacle
    {
        public string str { get; set; }
        public int id { get; set; }
        public Obstacle Obstacle { get; set; }
        public int Back { get; set; }

        public int Save { get; set; }

    }
    public class ResultItem
    {
        public List<Result> results { get; set; }
        public int partisipantId { get; set; }
        public int penalty { get; set; }
        public string clearTime { get; set; }
        public string resTime { get; set; }
        public int clearTickles { get; set; }
        public int resTickles { get; set; }
        public int position { get; set; }
        public string Name { get; set; }
    }
    public class TeamsList
    {
        
        public CompetitionTeam team { get; set; }
        public List<ResultItem> resItems { get; set; }
        public int penalty { get; set; }
        public string clearTime { get; set; }
        public string resTime { get; set; }
        public int clearTickles { get; set; }
        public string TeamName { get; set; }
        public int resTickles { get; set; }
    }
    
    public class Competition_Admin
    {
        public Competition Copmetition_new { get; set; }
        public string IdObstacles { get; set; }
        public List<ObstacleItem> ObstaclesItem { get; set; }

        //public List<Obstacle> Obstacles { get; set; }
        public int ret { get; set; }
        public int idO { get; set; }

        public string ToDelete { get; set; }

    }
    public class Items
    {
        public DateTime CurrentCompTime { get; set; }
        public Account account { get; set; }
        public Admition admition { get; set; }
        public List<Competition> competition { get; set; }
        public List<CompetitionTeam> competitionTeam { get; set; }

        public List<TeamsList> TeamsLst { get; set; }
        public Complexity complexity { get; set; }
        public List<Obstacle> obstacle { get; set; }
        public List<ObstacleCompetition> obstacleCompetition { get; set; }
        public Partisipant partisipant { get; set; }
        public List<Partisipant> partisipants { get; set; }
        public Rank rank { get; set; }
        public RankPartisipant rankPartisipant { get; set; }
        public List<Result> result { get; set; }
        public List<ResultItem> Reses { get; set; }
        public Role role { get; set; }
        public Sex sex { get; set; }
        public List<Team> team { get; set; }
        public List<TeamPartisipant> teamPartisipant{ get; set; }
        public Type type { get; set; }

        
        public bool WithoutAccount { get;set; }
        public string ErrorLogIn { get; set; }
        public string CheckPassword { get; set; }
        public string Register { get; set; }

        public DateTime YearMain { get; set; }
        public string SearchNameMain { get; set; }

        public DateTime? SearchDateFrom { get; set; }
        public DateTime? SearchDateTo { get; set; }

        public string SearchTypes { get; set; }
        public string SearchComplexities { get; set; }

        public bool Solo { get; set; }

        public string CurrentCompName { get; set; }
        public int CurrentTeamId { get; set; }

        public int Age { get; set; }

        public int RankId { get; set; }
        public List<PersPageTeam> PTeams { get; set; }

        public List<ResultItem> ResultsSolo { get; set; }

        public int CurrentCompId { get; set; }
        public List<DictItem> TN { get; set; }

        public int NotAdd { get; set; }
    }
    public class ObstacleItem
    {
        public Obstacle obstacle { get; set; }
        public int OCId { get; set; } 
    }
    public class PersPageTeam
    {
        public Team team { get; set; }
        public Competition comp { get; set; }
        public int? AdmitId { get; set; }
        public int idCT { get; set; }
    }

    public class CreateTeam
    {
        public Team team { get; set; }
        public CompetitionTeam compteam { get; set; }
        public Competition competition { get; set; }
        public List<Partisipant> partisipants { get; set; }
        public TeamPartisipant teamPartisipant { get; set; }
        public int back { get; set; }
        public int idP { get; set; }
        public int save { get; set; }
    }
}
