using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWeb1.Controllers
{
    public class MainController : Controller
    {
        private readonly DBLab1Context _context;
        public MainController(DBLab1Context context)
        {
            _context = context;
        }
        public IActionResult Main(int year=1)
        {
            var data = new Items();
            
            data.account = _context.Accounts.FirstOrDefault(a => a.AccountId == Dict.dApp.AccId);
            var tempdate1 = (DateTime?)TempData["DateFrom"];
            DateTime dateVarFrom = tempdate1.HasValue ? (DateTime)tempdate1 : new DateTime(1753,1,2);
            var tempdate2 = (DateTime?)TempData["DateTo"];
            DateTime dateVarTo = tempdate2.HasValue ? (DateTime)tempdate2 : DateTime.Now.AddYears(1);
            data.SearchDateFrom = dateVarFrom.Date;
            data.SearchDateTo = dateVarTo.Date;
            string compes = (string)TempData["Comlexities"];
            var comps =compes!=null? compes.Split(',').ToList():Dict.ListComplexity.Select(a=>a.ID.ToString()).ToList();            
            string types = (string)TempData["Types"];
            var typs = types != null ? types.Split(',').ToList() : Dict.ListType.Select(a => a.ID.ToString()).ToList();            
            string Search = (string)TempData["Search"];
            int showComp = 1;
            if(Dict.dApp.Role== "адмін")
            {
                showComp = -100;
            }
            data.competition = _context.Competitions.Where(a=>a.IsDeleted!=showComp).Where(a => a.StartTime >= dateVarFrom&&a.StartTime<=dateVarTo
            &&(a.Name.Contains(Search)
            ||Search==null
            ||a.Place.Contains(Search)
            ||a.Description.Contains(Search)                
            )).Where(a=>comps.Contains(a.IdComplexity.ToString())).Where(a => typs.Contains(a.IdType.ToString())).ToList();
            data.competition = data.competition.OrderByDescending(a => a.StartTime).ToList();
            

            
            return View(data);
            
        }

        [HttpPost]
        public IActionResult Main(Items items)
        {
            if (items.SearchNameMain == null) { items.SearchNameMain = ""; }
            TempData["Search"] = items.SearchNameMain;
            
            TempData["DateFrom"] = items.SearchDateFrom;
            TempData["DateTo"] = items.SearchDateTo;
            TempData["Types"] = items.SearchTypes;
            TempData["Comlexities"] = items.SearchComplexities;
            TempData["DateFrom"] = items.SearchDateFrom;
            TempData["DateTo"] =  items.SearchDateTo;

            return RedirectToAction("Main", "Main");
        }
        public IActionResult MainGuest()
        {          
            var data = new Items();    
            
            var dateVar = DateTime.Now.AddYears(-1);
            data.competition = _context.Competitions.Where(a => a.IsDeleted != 1).Where(a => a.StartTime > dateVar).ToList();
            return View();
        }


        public IActionResult PersonPage(int idP=-1)
        {
             
            var  AccId= Dict.dApp.AccId;
            
            var data = new Items();
            
            data.account = _context.Accounts.FirstOrDefault(a => a.AccountId == AccId);
            if (data.account == null)
            {
                return RedirectToAction("Register", "Account");
            }
            if (idP == -1) { 
                data.partisipant = _context.Partisipants.FirstOrDefault(a => a.IdAccount == AccId);
            }
            else
            {
                data.partisipant = _context.Partisipants.FirstOrDefault(a => a.ParticipantId == idP);                
            }
            if (data.partisipant == null)
            {                
                return RedirectToAction("PersonPageNew", "Main");
            }
            data.partisipant.Name = data.partisipant.Name.Trim();
            data.partisipant.Phone_number = data.partisipant.Phone_number==null?"": data.partisipant.Phone_number.Trim();
            data.account = _context.Accounts.FirstOrDefault(a => a.AccountId == data.partisipant.IdAccount);
            data.Age = DateTime.Now.Year-data.partisipant.DateOfBirth.Year;
            if (data.partisipant.DateOfBirth.Month<DateTime.Now.Month
                ||(data.partisipant.DateOfBirth.Month == DateTime.Now.Month
                && data.partisipant.DateOfBirth.Day<DateTime.Now.Day)) {
                data.Age--;
            }
            data.rankPartisipant = _context.RankPartisipants.Where(a => a.PartisipantId == data.partisipant.ParticipantId).OrderByDescending(a => a.DateOfAchievement).FirstOrDefault();
            if (data.rankPartisipant == null)
            {
                data.rankPartisipant = new RankPartisipant();
                data.rankPartisipant.RankId = 1;
            }
            var test = from R in _context.Results
                       join CO in _context.ObstacleCompetitions on R.ObstacleCompetitionId equals CO.ObstacleCompetitionId
                       join C in _context.Competitions on CO.CompetitionId equals C.CompetitionId
                       where R.PartisipantId == data.partisipant.ParticipantId
                       select C;
            var teams = from PT in _context.TeamPartisipants
                        join T in _context.Teams on PT.TeamId equals T.TeamId
                        join CT in _context.CompetitionTeams on T.TeamId equals CT.TeamId
                        join C in _context.Competitions on CT.CompetitionId equals C.CompetitionId
                        where C.StartTime >= DateTime.Now.AddDays(-7)
                        where PT.PartisipantId == data.partisipant.ParticipantId
                        where T.IsDeleted!=1
                        select new PersPageTeam {team = T,AdmitId=CT.AdmittedId,comp=C };


            data.PTeams = teams.ToList();
            foreach(var it in data.PTeams)
            {
                it.idCT = _context.CompetitionTeams.Where(a => a.CompetitionId == it.comp.CompetitionId && a.TeamId == it.team.TeamId).Select(a => a.CompetitionTeamId).FirstOrDefault();
            }
            data.competition = test.Distinct().ToList();
            return View(data);
        }
        public IActionResult PersonPageNew()
        {
            var AccId = Dict.dApp.AccId;
            
            var data = new Items();
            data.account = _context.Accounts.FirstOrDefault(a => a.AccountId == AccId);
            if (data.account == null)
            {
                return RedirectToAction("Register","Account");
            }
            data.partisipant = _context.Partisipants.FirstOrDefault(a => a.IdAccount == AccId);
            if (data.partisipant == null)
            {
                data.partisipant = new Partisipant();
                data.partisipant.DateOfBirth = new DateTime(1753, 1, 2);
                data.rankPartisipant = new RankPartisipant();
                data.rankPartisipant.RankId = 1;
                
                return View(data);
            }
            return RedirectToAction("PersonPage","Main");
        }
        [HttpPost]
        public IActionResult PersonPageNew(Items items)
        {

            var part = new Partisipant();
            
            part.Name = items.partisipant.Name;
            part.DateOfBirth = items.partisipant.DateOfBirth;
            part.IdRole = 1;
            part.IdSex = items.partisipant.IdSex;
            part.IdAccount = Dict.dApp.AccId;
            part.Phone_number = items.partisipant.Phone_number;
            var acc = _context.Accounts.FirstOrDefault(a => a.AccountId == Dict.dApp.AccId);
            acc.RoleName = "учасник";
            Dict.dApp.Role = "учасник";
            
            _context.Partisipants.Add(part);
            _context.SaveChanges();
            var rank = new RankPartisipant { PartisipantId = part.ParticipantId, RankId = items.rankPartisipant.RankId, DateOfAchievement = items.rankPartisipant.DateOfAchievement >=new DateTime(1753, 1, 2) ? items.rankPartisipant.DateOfAchievement: new DateTime(1753, 1, 2) };
            _context.RankPartisipants.Add(rank);
            _context.SaveChanges();

            Dict.dApp.idP = part.ParticipantId;
            return RedirectToAction("PersonPage","Main");
        }
        [HttpPost]
        public IActionResult PersonPage(Items items)
        {

            var part = _context.Partisipants.FirstOrDefault(a=>a.ParticipantId==items.partisipant.ParticipantId);
            var acc = _context.Accounts.FirstOrDefault(a => a.AccountId == part.IdAccount);
            acc.RoleName = items.account.RoleName;
            part.Name = items.partisipant.Name;
            part.DateOfBirth = items.partisipant.DateOfBirth;
            part.IdRole = 1;
            part.IdSex = items.partisipant.IdSex;
            part.IdAccount = acc.AccountId;
            part.Phone_number = items.partisipant.Phone_number;
            var rank = new RankPartisipant { PartisipantId = items.partisipant.ParticipantId, RankId = items.rankPartisipant.RankId, DateOfAchievement = items.rankPartisipant.DateOfAchievement >= new DateTime(1753, 1, 2) ? items.rankPartisipant.DateOfAchievement : new DateTime(1753, 1, 2) };
            _context.RankPartisipants.Add(rank);

            _context.SaveChanges();
            

            return RedirectToAction("PersonPage", "Main",new {idP=part.ParticipantId });
        }


        public IActionResult Competition(int id)
        {
            var compet = _context.Competitions.FirstOrDefault(a => a.CompetitionId == id);

            var data = new Items();
            data.CurrentCompId = id;
            data.CurrentCompFileId = compet.IdFile;
            data.CurrentCompTime = compet.StartTime;
            var requests = from T in _context.Teams
                           join CT in _context.CompetitionTeams on T.TeamId equals CT.TeamId
                           where CT.CompetitionId == id
                           where T.IsDeleted!=1
                           select CT;
            data.competitionTeam = requests.Distinct().ToList();
            data.obstacle = (from OC in _context.ObstacleCompetitions
                             join O in _context.Obstacles on OC.ObstacleId equals O.ObstacleId
                             where OC.CompetitionId == id
                             where OC.IsDeleted!=1
                             select O).ToList();

            List<int> lstOC = (from OC in _context.ObstacleCompetitions
                               where OC.CompetitionId==id
                               select OC.ObstacleCompetitionId
                               ).ToList();
            if(DateTime.Now >= compet.StartTime)
            {
                foreach(var it in data.competitionTeam)
                {
                    if (Dict.ListAdmitions.FirstOrDefault(a => a.ID == it.AdmittedId).Name == "допущено")
                    {
                        it.AdmittedId = Dict.ListAdmitions.FirstOrDefault(a => a.Name.Trim().Equals("брали участь")).ID;
                    }
                    if (Dict.ListAdmitions.FirstOrDefault(a => a.ID == it.AdmittedId).Name == "відхилено"|| Dict.ListAdmitions.FirstOrDefault(a => a.ID == it.AdmittedId).Name == "не допущено")
                    {
                        it.AdmittedId = Dict.ListAdmitions.FirstOrDefault(a => a.Name.Trim().Equals("не з'явились")).ID;
                    }
                    _context.SaveChanges();
                }
            }
            var temptest = Dict.dApp.Role;
            if (Dict.ListType.FirstOrDefault(a => a.ID == compet.IdType).Name.Contains("собист"))
            {
                data.Solo = true;
            }
            else { data.Solo = false; }
            
            data.TeamsLst = new List<TeamsList>();
            var temp = (from CT in _context.CompetitionTeams
                        where CT.CompetitionId == id
                        select CT).ToList();
            foreach(var item in temp)
            {
                var TL = new TeamsList();
                TL.team = item;
                int clTicks = 0;
                int Spenalty = 0;
                TL.resItems = new List<ResultItem>();
                var tmp = (from ct in _context.CompetitionTeams
                           join pt in _context.TeamPartisipants on ct.TeamId equals pt.TeamId
                           join p in _context.Partisipants on pt.PartisipantId equals p.ParticipantId
                           where ct.CompetitionId == id
                           where pt.TeamId == item.TeamId
                           select p).ToList();
                TL.TeamName = (from ct in _context.CompetitionTeams
                           join pt in _context.TeamPartisipants on ct.TeamId equals pt.TeamId
                           join p in _context.Partisipants on pt.PartisipantId equals p.ParticipantId
                           join t in _context.Teams on pt.TeamId equals t.TeamId
                           where ct.CompetitionId == id
                           where pt.TeamId == item.TeamId
                           select t.Name).FirstOrDefault();
                foreach (var part in tmp)
                {
                    var reI = new ResultItem();
                    reI.partisipantId = part.ParticipantId;
                    reI.Name = part.Name;

                    reI.results = _context.Results.Where(a => a.PartisipantId == part.ParticipantId&&lstOC.Contains(a.ObstacleCompetitionId)).ToList();
                    TL.resItems.Add(reI);
                }

                foreach(var it in TL.resItems)
                {
                    int pen = 0;
                    int calc = 0;
                    foreach(var res in it.results)
                    {
                        pen += res.Penalty;
                        calc += int.Parse(res.Time.Split(":")[0]) * 3600 + int.Parse(res.Time.Split(":")[1]) * 60 + int.Parse(res.Time.Split(":")[2]);
                    }
                    it.penalty = pen;
                    it.clearTime = CalculateTime(calc);
                    it.clearTickles = calc;
                    it.resTickles = calc + pen * 30;
                    it.resTime = CalculateTime(calc + pen * 30);
                    Spenalty += pen;
                    clTicks += calc;
                }
                TL.clearTime = CalculateTime(clTicks);
                TL.resTime = CalculateTime(clTicks + Spenalty * 30);
                TL.clearTickles = clTicks;
                TL.resTickles = clTicks + Spenalty * 30;
                TL.penalty = Spenalty;
                data.TeamsLst.Add(TL);
            }
            data.TeamsLst = data.TeamsLst.OrderBy(a => a.resTickles).ToList();
            data.ResultsSolo = new List<ResultItem>();
            int i = 1;
            foreach(var it in data.TeamsLst)
            {
                var yyy = _context.CompetitionTeams.FirstOrDefault(a => a.CompetitionTeamId == it.team.CompetitionTeamId);
                it.team.Position = i;
                it.team.Penalty = it.penalty;
                it.team.ResultTime = it.resTime;
                it.team.ClearTime = it.clearTime;
                yyy.Position = i;
                yyy.Penalty = it.penalty;
                yyy.ResultTime = it.resTime;
                yyy.ClearTime = it.clearTime;
                _context.SaveChanges();
                foreach(var itt in it.resItems)
                {
                    data.ResultsSolo.Add(itt);
                }
                i++;
            }
            i = 1;
            data.ResultsSolo = data.ResultsSolo.OrderBy(a => a.resTickles).ToList();
            foreach(var it in data.ResultsSolo)
            {
                it.position = i;
                i++;
            }
            data.TN = new List<DictItem>();
            foreach(var it in data.competitionTeam)
            {
                var temp1 = new DictItem();
                temp1.ID = it.TeamId;
                temp1.Name = _context.Teams.FirstOrDefault(a => a.TeamId == it.TeamId).Name;
                data.TN.Add(temp1);
            } 





            return View(data);

        }



        public IActionResult CompTeamAdmition(int id,int admit)
        {
            var temp = _context.CompetitionTeams.FirstOrDefault(a => a.CompetitionTeamId == id);
            temp.AdmittedId = admit;
            _context.SaveChanges();
            return RedirectToAction("Competition", "Main", new { id = temp.CompetitionId });
        }
        public static string CalculateTime(int time)
        {
            string temp;
            int a1 = (time / 3600);
            int a2 = (time - a1 * 3600) / 60;
            int a3 =  time - a1 * 3600 - a2 * 60;

            temp = a1.ToString() + ":" + a2.ToString() + ":" + a3.ToString();
            if (a3 < 10)
            {
                var n = temp.Split(":")[0] + ":" + temp.Split(":")[1] + ":" + "0" + temp.Split(":")[2];
                temp = n;
            }
            if (a2 < 10)
            {
                var n = temp.Split(":")[0] + ":" + "0" + temp.Split(":")[1] + ":" + temp.Split(":")[2];
                temp = n;
            }
            if (a1 < 10)
            {
                var n = "0" + temp;
                temp = n;
            }
            return temp;
        }
        public IActionResult CompetitionAdmin(string str="",int id=-1)
        {
            //var data = items;         
            var data = new Competition_Admin();
            data.ObstaclesItem = new List<ObstacleItem>();
            data.ToDelete = "";
            if (id == -1) {
                data.Copmetition_new = new Competition();
                data.Copmetition_new.IsDeleted = 1;
                data.Copmetition_new.Name = "";
                data.Copmetition_new.Place = "";
                data.Copmetition_new.StartTax = 0;
                data.Copmetition_new.IdType = 1;
                data.Copmetition_new.IdComplexity = 1;
                data.Copmetition_new.StartTime = DateTime.Now;
                data.IdObstacles = "";
                data.Copmetition_new.Description = "";
                _context.Competitions.Add(data.Copmetition_new);
                _context.SaveChanges();
            }
            else
            {
                data.Copmetition_new = _context.Competitions.FirstOrDefault(a => a.CompetitionId == id);
                data.Copmetition_new.Name = data.Copmetition_new.Name.Trim();
                data.Copmetition_new.Place = data.Copmetition_new.Place.Trim();
                data.Copmetition_new.Description = data.Copmetition_new.Description.Trim();
                data.ObstaclesItem = (from CO in _context.ObstacleCompetitions
                                      join O in _context.Obstacles on CO.ObstacleId equals O.ObstacleId
                                      where CO.CompetitionId == id
                                      where CO.IsDeleted!=1
                                      select new ObstacleItem
                                      {
                                          OCId = CO.ObstacleCompetitionId,
                                          obstacle = O
                                      }).ToList();

            }

            return View(data);
        }
        public IActionResult RemoveObstacle(int id)
        {
            var temp = _context.ObstacleCompetitions.FirstOrDefault(a => a.ObstacleCompetitionId == id);
            temp.IsDeleted = 1;
            _context.SaveChanges();
            return RedirectToAction("CompetitionAdmin", "Main", new { id = temp.CompetitionId });
        }
        [HttpPost]
        public IActionResult CompetitionAdmin(Competition_Admin comp)
        {
            var temp = _context.Competitions.FirstOrDefault(a => a.CompetitionId == comp.Copmetition_new.CompetitionId);
            temp.Description = comp.Copmetition_new.Description;
            temp.Place = comp.Copmetition_new.Place;
            temp.StartTax = comp.Copmetition_new.StartTax;
            temp.StartTime = comp.Copmetition_new.StartTime;
            temp.Name = comp.Copmetition_new.Name;
            temp.IdComplexity = comp.Copmetition_new.IdComplexity;
            temp.IdType = comp.Copmetition_new.IdType;
            temp.IsDeleted = 0;
            _context.SaveChanges();
            if (comp.ToDelete !=null&& comp.ToDelete.Contains("/"))
            {
                for(int i=1; i < comp.ToDelete.Split("/").Length; i++)
                {
                    var s = comp.ToDelete.Split("/")[i];
                    var X = _context.ObstacleCompetitions.FirstOrDefault(a => a.ObstacleId == int.Parse(s) && a.CompetitionId == comp.Copmetition_new.CompetitionId);
                    X.IsDeleted = 1;
                    _context.SaveChanges();
                }
            }
            
            if (comp.ret == 1)
            {
                return RedirectToAction("EditObstacle", "Main", new { idC =comp.Copmetition_new.CompetitionId, idO = comp.idO, str = comp.IdObstacles, back = 1 });
            }
            if (comp.ret == 2)
            {
                return RedirectToAction("AddObstacle", "Main", new { id = comp.Copmetition_new.CompetitionId, str = comp.IdObstacles });
            }
            return RedirectToAction("Main", "Main");
        }

        public IActionResult ListObstacles()
        {
            return RedirectToAction("AddObstacle", "Main", new { id = 0, str = "", obs = 22 });
        }
        public IActionResult AddObstacle(int id, string str,int obs=-1, string Search="")
        {
            var data = new ObstaclesList();
            data.str = str;
            data.id = id;
            data.Search = Search;
            data.calc = 1;
            if (obs != -1)
            {
                data.obs = 1;
            }
            else
            {
                data.obs = 0;
            }
            if (Search == "")
            {
                data.Obstacles = _context.Obstacles.Where(a=>a.IsDeleted!=1).OrderByDescending(a=>a.ObstacleId).ToList();
            }
            else
            {
                data.Obstacles = _context.Obstacles.Where(a => a.IsDeleted != 1).Where(a => a.Name.Contains(Search)||a.AdditionalDescription.Contains(Search)).OrderBy(a => a.ObstacleId).OrderByDescending(a=>a.Name).ToList();
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult AddObstacle(ObstaclesList data)
        {
            return RedirectToAction("AddObstacle", "Main", new { id = data.id, str = data.str, Search = data.Search });
        }


        public IActionResult AddObs(int idC,int idO,string str,int calc)
        {
            var temp = new ObstacleCompetition {CompetitionId=idC,ObstacleId=idO,ObstaclePosition=calc };
            _context.ObstacleCompetitions.Add(temp);
            _context.SaveChanges();
            str = str + "/" + idO.ToString();
            return RedirectToAction("CompetitionAdmin", "Main", new { str = str, id = idC });
        }
        public IActionResult DeleteObstacle(int idC, int idO, string str,string Search)
        {
            var temp = _context.Obstacles.FirstOrDefault(a => a.ObstacleId == idO);
            temp.IsDeleted = 1;
            _context.SaveChanges();
            return RedirectToAction("AddObstacle", "Main", new { str = str, id = idC,Search=Search });
        }

        public IActionResult CreateObstacle(int idC,string str="")
        {
            return RedirectToAction("EditObstacle", "Main", new { idC = idC, str = str });
        }
        public IActionResult EditObstacle(int idC,string str,int back,int idO=-1)
        {
            var data = new EditObstacle();
            data.id = idC;
            data.str = str;
            data.Back = back;
            data.Save = 1;
            if (idO == -1)
            {
                data.Obstacle = new Obstacle();
                data.Obstacle.Name = "";
                data.Obstacle.IsDeleted = 1;
                data.Obstacle.AdditionalDescription = "";
                data.Obstacle.ConditionsOvercoming = "";
                data.Obstacle.CriticalTime = "00:00:00";
                data.Obstacle.OptTime = "00:00:00";
                data.Obstacle.Height = 0;
                data.Obstacle.Length = 0;
                data.Obstacle.EquipmentObstacle = "";
                data.Obstacle.EquipmentStart = "";
                data.Obstacle.EquipmentTarget = "";
                data.Obstacle.MovementFirst = "";

                _context.Obstacles.Add(data.Obstacle);
                _context.SaveChanges();
            }
            else
            {

                data.Obstacle = _context.Obstacles.FirstOrDefault(a => a.ObstacleId == idO);
                data.Obstacle.OptTime = data.Obstacle.OptTime.Trim();
                data.Obstacle.CriticalTime = data.Obstacle.CriticalTime.Trim();
                data.Obstacle.Name = data.Obstacle.Name.Trim();
                data.Obstacle.AdditionalDescription = data.Obstacle.AdditionalDescription==null?"": data.Obstacle.AdditionalDescription.Trim();
                data.Obstacle.EquipmentTarget = data.Obstacle.EquipmentTarget == null ? "": data.Obstacle.EquipmentTarget.Trim();
                data.Obstacle.EquipmentStart = data.Obstacle.EquipmentStart==null?"": data.Obstacle.EquipmentStart.Trim();
                data.Obstacle.EquipmentObstacle = data.Obstacle.EquipmentObstacle==null?"": data.Obstacle.EquipmentObstacle.Trim();
                data.Obstacle.MovementFirst = data.Obstacle.MovementFirst==null?"": data.Obstacle.MovementFirst.Trim();
                data.Obstacle.ConditionsOvercoming = data.Obstacle.ConditionsOvercoming==null?"": data.Obstacle.ConditionsOvercoming.Trim();
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult EditObstacle(EditObstacle data)
        {
            data.Obstacle.AdditionalDescription = data.Obstacle.AdditionalDescription == null ? "" : data.Obstacle.AdditionalDescription.Trim();
            data.Obstacle.EquipmentTarget = data.Obstacle.EquipmentTarget == null ? "" : data.Obstacle.EquipmentTarget.Trim();
            data.Obstacle.EquipmentStart = data.Obstacle.EquipmentStart == null ? "" : data.Obstacle.EquipmentStart.Trim();
            data.Obstacle.EquipmentObstacle = data.Obstacle.EquipmentObstacle == null ? "" : data.Obstacle.EquipmentObstacle.Trim();
            data.Obstacle.MovementFirst = data.Obstacle.MovementFirst == null ? "" : data.Obstacle.MovementFirst.Trim();
            data.Obstacle.ConditionsOvercoming = data.Obstacle.ConditionsOvercoming == null ? "" : data.Obstacle.ConditionsOvercoming.Trim();
            data.Obstacle.OptTime = data.Obstacle.OptTime==null?"": data.Obstacle.OptTime.Trim();
            data.Obstacle.CriticalTime = data.Obstacle.CriticalTime==null?"": data.Obstacle.CriticalTime.Trim();

            var xxx = _context.ObstacleCompetitions.FirstOrDefault(a => a.ObstacleId == data.Obstacle.ObstacleId);
            if (data.Save == 1) {
                int change = 0;
                var temp = _context.Obstacles.FirstOrDefault(a => a.ObstacleId == data.Obstacle.ObstacleId);
                
                if (!(temp.Name.Trim().Equals(data.Obstacle.Name) &&
                    temp.AdditionalDescription.Trim().Equals(data.Obstacle.AdditionalDescription) &&
                    temp.ConditionsOvercoming.Trim().Equals(data.Obstacle.ConditionsOvercoming) &&
                    temp.Length == data.Obstacle.Length &&
                    temp.Height == data.Obstacle.Height &&
                    temp.CriticalTime.Trim().Equals(data.Obstacle.CriticalTime) &&
                    temp.OptTime.Trim().Equals(data.Obstacle.OptTime) &&
                    temp.EquipmentObstacle.Trim().Equals(data.Obstacle.EquipmentObstacle) &&
                    temp.EquipmentStart.Trim().Equals(data.Obstacle.EquipmentStart) &&
                    temp.EquipmentTarget.Trim().Equals(data.Obstacle.EquipmentTarget) &&
                    temp.MovementFirst.Trim().Equals(data.Obstacle.MovementFirst)))
                { change = 1; }
                if (xxx != null&&change!=0) {
                    temp = new Obstacle();
                    _context.Obstacles.Add(temp);
                }
                
                
                temp.Name = data.Obstacle.Name;
                temp.AdditionalDescription = data.Obstacle.AdditionalDescription;
                temp.ConditionsOvercoming = data.Obstacle.ConditionsOvercoming;
                temp.Length = data.Obstacle.Length;
                temp.Height = data.Obstacle.Height;
                temp.CriticalTime = data.Obstacle.CriticalTime;
                temp.OptTime = data.Obstacle.OptTime;
                temp.EquipmentObstacle = data.Obstacle.EquipmentObstacle;
                temp.EquipmentStart = data.Obstacle.EquipmentStart;
                temp.EquipmentTarget = data.Obstacle.EquipmentTarget;
                temp.MovementFirst = data.Obstacle.MovementFirst;
                temp.IsDeleted = 0;
                _context.SaveChanges();
                if (xxx != null&&change!=0)
                {
                    var t = _context.ObstacleCompetitions.FirstOrDefault(a => a.ObstacleId == data.Obstacle.ObstacleId && a.CompetitionId == data.id);
                    t.ObstacleId = temp.ObstacleId;
                    _context.SaveChanges();
                }

                    if (data.Back == 1)
                {
                    return RedirectToAction("CompetitionAdmin", "Main", new { str = data.str, id = data.id });
                }
                else
                {
                    return RedirectToAction("AddObstacle", "Main", new { str = data.str, id = data.id });
                }
            }
            else
            {
                if (data.Back == 1)
                {
                    return RedirectToAction("CompetitionAdmin", "Main", new { str = data.str, id = data.id });
                }
                else
                {
                    return RedirectToAction("AddObstacle", "Main", new { str = data.str, id = data.id });
                }
            }
        }

        public IActionResult ShowObstacle(int id)
        {
            var data = _context.Obstacles.FirstOrDefault(a => a.ObstacleId == id);
            return PartialView(data);
        }

        public IActionResult DeleteComp(int id)
        {
            var temp = _context.Competitions.FirstOrDefault(a => a.CompetitionId == id);
            if (temp.IsDeleted == 1)
            {
                _context.Competitions.Remove(temp);
                _context.SaveChanges();
                return RedirectToAction("Main", "Main");
            }
            temp.IsDeleted = 1;
            _context.SaveChanges();
            return RedirectToAction("Main", "Main");
        }
        public IActionResult RestoreComp(int id)
        {
            var temp = _context.Competitions.FirstOrDefault(a => a.CompetitionId == id);
            temp.IsDeleted = 0;
            _context.SaveChanges();
            return RedirectToAction("Main", "Main");
        }
        public IActionResult CreateTeam(int id,int idCT =-1)
        {
            var data = new CreateTeam();
            data.save = id;
            data.back = 0;
            data.competition = _context.Competitions.FirstOrDefault(a => a.CompetitionId == id);
            data.partisipants = new List<Partisipant>();
            if (idCT == -1)
            {
                data.team = new Team();
                data.team.IsDeleted = 1;
                data.team.Name = "";
                data.team.Comment = "";
                _context.Teams.Add(data.team);
                _context.SaveChanges();
            }
            else
            {
                data.compteam = _context.CompetitionTeams.FirstOrDefault(a => a.CompetitionTeamId == idCT);
                data.partisipants = (from TP in _context.TeamPartisipants
                                     join CT in _context.CompetitionTeams on TP.TeamId equals CT.TeamId
                                     join P in _context.Partisipants on TP.PartisipantId equals P.ParticipantId
                                     where CT.CompetitionTeamId == data.compteam.CompetitionTeamId
                                     select P).ToList();
                data.team = _context.Teams.FirstOrDefault(a => a.TeamId == data.compteam.TeamId);
            }

            return View(data);
        }
        [HttpPost]
        public IActionResult CreateTeam(CreateTeam items)
        {
            
            var temp1 = _context.CompetitionTeams.FirstOrDefault(a => a.CompetitionId==items.competition.CompetitionId&&a.TeamId==items.team.TeamId);
            if (temp1 == null)
            {
                temp1 = new CompetitionTeam();
                temp1.CompetitionId = items.competition.CompetitionId;
                temp1.TeamId = items.team.TeamId;
                temp1.CompetitionId = items.competition.CompetitionId;
                temp1.AdmittedId = Dict.ListAdmitions.FirstOrDefault(a => a.Name.Contains("не допущено")).ID;
                _context.CompetitionTeams.Add(temp1);
            }
            temp1.IsDeleted = 0;
            temp1.CompetitionId = items.competition.CompetitionId;
            temp1.TeamId = items.team.TeamId;
            
            var temp2 = _context.Teams.FirstOrDefault(a => a.TeamId == items.team.TeamId);
            temp2.IsDeleted = 0;
            temp2.Name = items.team.Name;
            temp2.Comment = items.team.Comment==null?"":items.team.Comment;
            _context.SaveChanges();
            if (items.back == 0)
            {
                return RedirectToAction("Competition", "Main", new { id = items.competition.CompetitionId });
            }
            if (items.back == 1)
            {
                return RedirectToAction("RemovePartisipant", "Main", new { id = items.idP,idC=items.competition.CompetitionId,idT = items.team.TeamId });
            }
            if (items.back == 2)
            {
                return RedirectToAction("ListPartisipants", "Main", new { idC = items.competition.CompetitionId, idT = items.team.TeamId });
            }
            return RedirectToAction("Competition", "Main", new { id = items.competition.CompetitionId }); ;

        }
        public IActionResult DeleteTeam(int idC,int idCT)
        {
            var temp = _context.CompetitionTeams.FirstOrDefault(a => a.CompetitionTeamId == idCT);
            temp.IsDeleted = 1;
            _context.SaveChanges();
            return RedirectToAction("Competition", "Main", new { id = idC });

        }
        public IActionResult RestoreTeam(int idC, int idCT)
        {
            var temp = _context.CompetitionTeams.FirstOrDefault(a => a.CompetitionTeamId == idCT);
            temp.IsDeleted = 0;
            _context.SaveChanges();
            return RedirectToAction("Competition", "Main", new { id = idC });

        }

        public IActionResult ListPartisipants(int idC=-1,int idT=-1)
        {
            
            var data = new Items();
            if (idC != -1 || idT != -1) { 
                data.NotAdd = 0;
            }
            else
            {
                data.NotAdd = 1;
            }
            string search = (string)TempData["Search0"];
           
            if (search == null) { 
                data.partisipants = _context.Partisipants.Where(a=>a.IsDeleted!=1).ToList();
            }
            else
            {
                data.partisipants = _context.Partisipants.Where(a => a.IsDeleted != 1).Where(a=>a.Name.Contains(search)).ToList();
            }
            data.CurrentTeamId = idT;
            data.CurrentCompId = idC;

            return View(data);


        }
        public IActionResult AddPartisipant(int idP,int idT,int idC)
        {
            var temp = _context.CompetitionTeams.FirstOrDefault(a => a.CompetitionId == idC && a.TeamId == idT);
            if (temp == null)
            {
                temp = new CompetitionTeam();
                temp.TeamId = idT;
                temp.CompetitionId = idC;
                temp.IsDeleted = 0;
                _context.CompetitionTeams.Add(temp);
            }
            var temp1 = _context.TeamPartisipants.FirstOrDefault(a => a.TeamId == idT && a.PartisipantId == idP);
            if (temp1 == null)
            {
                temp1 = new TeamPartisipant();
                temp1.TeamId = idT;
                temp1.PartisipantId = idP;
                _context.TeamPartisipants.Add(temp1);
            }
            temp1.IsDeleted = 0;
            temp1.Participated = 1;
            _context.SaveChanges();
            return RedirectToAction("CreateTeam", "Main", new { idCT = temp.CompetitionTeamId, id = idC });
        }
        public IActionResult DeletePartisipant(int id,int idC,int  idT)
        {
            var temp = _context.Partisipants.FirstOrDefault(a => a.ParticipantId == id);
            temp.IsDeleted = 1;
            return RedirectToAction("ListPartisipants", "Main", new { idC = idC, idT = idT });
        }
        public IActionResult RemovePartisipant(int id, int idC, int idT)
        {
            var temp = _context.TeamPartisipants.FirstOrDefault(a => a.PartisipantId == id&&a.TeamId==idT);
            temp.IsDeleted = 1;
            _context.SaveChanges();
            var temp1 = _context.CompetitionTeams.FirstOrDefault(a => a.CompetitionId == idC && a.TeamId == idT);
            return RedirectToAction("CreateTeam", "Main", new { id = idC, idCT = temp1.CompetitionTeamId });
        }
        public IActionResult RestorePartisipant(int id, int idC, int idT)
        {
            var temp = _context.Partisipants.FirstOrDefault(a => a.ParticipantId == id);
            temp.IsDeleted = 0;
            return RedirectToAction("ListPartisipants", "Main", new { idC = idC, idT = idT });
        }

        [HttpPost]
        public IActionResult ListPartisipants(Items items)
        {
            TempData["Search0"] = items.SearchNameMain;
            return RedirectToAction("ListPartisipants", "Main", new { idC = items.CurrentCompId, idT = items.CurrentTeamId });
        }

        public IActionResult ShowTeamComp(int idCT)
        {
            var data = new CreateTeam();
            
            data.back = 0;
           
            
            data.compteam = _context.CompetitionTeams.FirstOrDefault(a => a.CompetitionTeamId == idCT);
            data.partisipants = (from TP in _context.TeamPartisipants
                                 join CT in _context.CompetitionTeams on TP.TeamId equals CT.TeamId
                                 join P in _context.Partisipants on TP.PartisipantId equals P.ParticipantId
                                 where CT.CompetitionTeamId == data.compteam.CompetitionTeamId
                                 select P).ToList();
            data.team = _context.Teams.FirstOrDefault(a => a.TeamId == data.compteam.TeamId);
            data.competition = _context.Competitions.FirstOrDefault(a => a.CompetitionId == data.compteam.CompetitionId);
            return View(data);
        }
    }
}




















/*
 //TempData["Role"] = role;
            //TempData["AccId"] = AccId;
            var data = new Items();
            
            
            var comp = new Competition();
            comp = _context.Competitions.FirstOrDefault(a => a.CompetitionId == id);
            data.CurrentCompName = comp.Name;
            data.CurrentTeamId = comp.CompetitionId;
            var y = Dict.ListComplexity.FirstOrDefault(a => a.ID == comp.IdComplexity);
            if (y.Name.Contains("собист"))
            {
                data.Solo = true;
            }
            else
            {
                data.Solo = false;
            }
            data.competition = new List<Competition>();
            data.competition.Add(comp);
            data.obstacleCompetition = _context.ObstacleCompetitions.Where(a => a.CompetitionId == id && a.IsDeleted != 1).ToList();
            var templst = data.obstacleCompetition.Where(a => a.CompetitionId == id).Select(a => a.ObstacleId).ToList();
            //data.obstacle = _context.Obstacles.Where(a => templst.Contains(a.ObstacleId)).ToList();
            data.obstacle = new List<Obstacle>();

            foreach (var item in templst)
            {
                data.obstacle.Add(_context.Obstacles.FirstOrDefault(a => a.ObstacleId == item));
            }

            List<int> part = new List<int>();
            foreach (var it in data.obstacleCompetition)
            {
                part = _context.Results.Where(a => a.ObstacleCompetitionId == it.ObstacleCompetitionId).Select(a => a.PartisipantId).ToList();
            }
            data.Reses = new List<ResultItem>();
            foreach (var it in part)
            {
                ResultItem ResIt = new ResultItem();
                ResIt.Res = new List<Result>();
                ResIt.points = 0;
                ResIt.CountObs = 0;
                ResIt.penalty = 0;
                ResIt.IDPartis = it;
                foreach (var itt in data.obstacleCompetition)
                {
                    var temp = _context.Results.FirstOrDefault(a => a.ObstacleCompetitionId == itt.ObstacleCompetitionId && a.PartisipantId == it);
                    if (temp != null)
                    {
                        if (temp.Time != null || temp.Time != "")
                        {
                            ResIt.points += int.Parse(temp.Time.Split(":")[0]) * 3600 + int.Parse(temp.Time.Split(":")[1]) * 60 + int.Parse(temp.Time.Split(":")[2]);
                            ResIt.CountObs++;
                            ResIt.penalty += temp.Penalty;
                        }
                        ResIt.Res.Add(temp);
                    }
                }

                ResIt.save = ResIt.points;
                ResIt.points += ResIt.penalty * 30;

                ResIt.TimePenalty = CalculateTime(ResIt.points);
                ResIt.Time = CalculateTime(ResIt.save);
                data.Reses.Add(ResIt);

            }
            data.Reses.OrderBy(a => a.CountObs).OrderBy(a => a.points);
            data.competitionTeam = _context.CompetitionTeams.Where(a => a.CompetitionId == id).ToList();
            data.TeamsLst = new List<TeamsList>();
            foreach (var it in data.competitionTeam)
            {
                TeamsList lst = new TeamsList();
                var x = _context.TeamPartisipants.Where(a => a.TeamId == it.TeamId).Select(a => a.PartisipantId).ToList();
                lst.TeamName = _context.Teams.FirstOrDefault(a => a.TeamId == it.TeamId).Name;
                lst.CompTeam = _context.CompetitionTeams.FirstOrDefault(a => a.TeamId == it.TeamId && a.CompetitionId == id);
                lst.ResItems = data.Reses.Where(a => x.Contains(a.IDPartis)).ToList();
                lst.penalty = 0;
                int tempT1 = 0, tempT2 = 0;
                foreach (var t in lst.ResItems)
                {
                    tempT1 += t.save;
                    tempT2 += t.points;
                    lst.penalty += t.penalty;
                }
                lst.Points = tempT2;
                lst.ClearTime = CalculateTime(tempT1);
                lst.ResTime = CalculateTime(tempT2);
                data.TeamsLst.Add(lst);
            }

            data.TeamsLst.OrderBy(a => a.Points);

            return View(data);


            if (role != "адмін")
            {
                return View(data);
            }
            else
            {
                return RedirectToAction("CompetitionAdmin", "Main", data);
            }
 */