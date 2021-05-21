using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TWeb1.Controllers
{
    public class Additional : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

       
        private readonly DBLab1Context _context;
        public Additional(DBLab1Context context, IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
        public IActionResult ShowDoc(int id)
        {            
            var F = _context.FilesTbl.Where(a => a.FileId == id).Select(a=>a.FileInsurance).FirstOrDefault();
            if (F == null)
            {
                return null;
            }
            byte[] arr = F;
            return new FileStreamResult(new MemoryStream(arr), "image/jpeg");
        }

        [HttpPost]
        public ActionResult UploadFiles(int idP,int idI, string type)
        {
            if (type == "Insurance")
            {
                var partis = _context.Partisipants.FirstOrDefault(a=>a.ParticipantId==idP);
                var files = _context.FilesTbl.FirstOrDefault(a => a.FileId == idI);
                if (files == null)
                {
                    files = new FilesTBL();
                    _context.FilesTbl.Add(files);
                    _context.SaveChanges();
                }
                if (partis != null)
                {
                    partis.IdFile = files.FileId;
                }
                var x= Request.Form.Files[0];
                MemoryStream target = new MemoryStream();
                x.CopyTo(target);
                byte[] data = target.ToArray();
                files.FileInsurance = data;
                _context.SaveChanges();
                return Json(new { });


            }

            return Json(new { });
        }
        [HttpPost]
        public IActionResult  ExcelPrepare(int idC)
        {
            
            //string docNameFile = "/Content/tmp/" + docName;
            var data = new Items();
            var comp = _context.Competitions.FirstOrDefault(a => a.CompetitionId == idC);
            string str0 = DateTime.Now.Ticks.ToString().Trim();
            string docName = "ResultForm_"+comp.Name.Trim()+str0+".xlsx";
            var obst = (from O in _context.Obstacles
                       join OC in _context.ObstacleCompetitions on O.ObstacleId equals OC.ObstacleId
                       where O.IsDeleted!=1 && OC.CompetitionId==idC&&OC.IsDeleted!=1
                       select O).ToList();
            
            var partisipants = (from P in _context.Partisipants
                                join PT in _context.TeamPartisipants on P.ParticipantId equals PT.PartisipantId
                                join CT in _context.CompetitionTeams on PT.TeamId equals CT.TeamId
                                where CT.CompetitionId == idC && PT.IsDeleted != 1 && CT.IsDeleted != 1 && P.IsDeleted != 1
                                select P).ToList();
            if (!Dict.ListType.FirstOrDefault(a => a.ID == comp.IdType).Name.Contains("собист"))
            {
                partisipants = (from P in _context.Partisipants
                                join PT in _context.TeamPartisipants on P.ParticipantId equals PT.PartisipantId
                                join CT in _context.CompetitionTeams on PT.TeamId equals CT.TeamId
                                where CT.CompetitionId == idC && PT.IsDeleted != 1 && CT.IsDeleted != 1 && P.IsDeleted != 1
                                orderby PT.TeamId
                                select P
                                ).ToList();
            }
            using (XLWorkbook wb = new XLWorkbook(XLEventTracking.Disabled))
            {
                var wr1 = wb.Worksheets.Add("ResultForm");
                wr1.Column(1).Style.Protection.SetLocked(true);
                wr1.Row(1).Style.Protection.SetLocked(true);
                wr1.Cell(1, 1).Value = idC;
                wr1.Cell(1, 2).Value = "Змагання: " + comp.Name;
                wr1.Column(2).Width = 60;
                wr1.Cell(1, 3).Value = "Мiсце проведення: " + comp.Place;
                wr1.Column(3).Width = 60;
                wr1.Column(4).Width = 40;
                wr1.Cell(1,4).Value = "Час початку: " + comp.StartTime;
                wr1.Cell(3, 2).Value = "ПIБ";
                wr1.Cell(3, 3).Value = "Розряд";
                wr1.Cell(3, 4).Value = "Дата Народження";
                wr1.Cell(3, 5).Value = "Команда";
                int i = 4;
                foreach(var part in partisipants)
                {
                    wr1.Cell(i, 1).Value = part.ParticipantId;
                    wr1.Cell(i, 2).Value = part.Name;
                    var tempR = _context.RankPartisipants.Where(a => a.PartisipantId == part.ParticipantId).OrderByDescending(a => a.DateOfAchievement).FirstOrDefault();
                    wr1.Cell(i, 3).Value = Dict.ListRanks.FirstOrDefault(a => a.ID == tempR.RankId).Name;
                    wr1.Cell(i, 4).Value = part.DateOfBirth.ToString("d").Replace("/",".");
                    var tempT = (from T in _context.Teams
                                join TP in _context.TeamPartisipants on T.TeamId equals TP.TeamId
                                join CT in _context.CompetitionTeams on TP.TeamId equals CT.TeamId
                                where TP.PartisipantId == part.ParticipantId&&CT.CompetitionId==idC&&TP.IsDeleted!=1&&CT.IsDeleted!=1
                                select T).ToList();
                    wr1.Cell(i, 5).Value = tempT[0].Name;
                    i++;
                }
                i = 6;
                
                foreach(var obs in obst)
                {
                    wr1.Cell(1, i).Value = obs.ObstacleId;
                    wr1.Cell(2, i).Value = obs.Name;
                    wr1.Cell(2, i+1).Value = "Штраф";
                    wr1.Cell(3, i).Value = "КЧ: " + obs.CriticalTime.Trim() + "/ ОЧ: " + obs.OptTime.Trim();
                    wr1.Column(i).Width = 50;
                    wr1.Column(i + 1).Width = 20;
                    for(int y = 0; y < partisipants.Count; y++)
                    {
                        wr1.Cell(4+y, i).Value = "'00:00:00";
                        wr1.Cell(4+y, i+1).Value = 0;
                        
                    }
                    i+=2;
                }

                //MemoryStream ms = new MemoryStream();

                //string docnamefile = HttpContext.Current.Server.MapPath(docName);
                string xxx = HttpContext.Request.PathBase;
                
                
                string path0 = _hostingEnvironment.WebRootPath;
                string path1 = path0+ "\\Content\\tmp\\"+ docName;
                //string contentRootPath = _hostingEnvironment.ContentRootPath;
                wb.SaveAs(path1);
                return Json(new { name = docName });
                //return 

                //return Json(new { name = docNameFile });

            }
            
            

        }

        public IActionResult UploadResult(int idC)
        {
            var x = Request.Form.Files[0];
            string docName = $"Result{DateTime.Now.Ticks}.xlsx";
            string path0 = _hostingEnvironment.WebRootPath;
            string path1 = path0 + "\\Content\\tmp\\" + docName;
            MemoryStream target = new MemoryStream();
            x.CopyTo(target);
            byte[] dataArr = target.ToArray();
            System.IO.File.WriteAllBytes(path1, dataArr);
            using(XLWorkbook wb = new XLWorkbook(path1))
            {
                //var x22 = wb.Worksheet("ResultFormSolo").Cell(1, 1).Value;
                var wr1 = wb.Worksheet("ResultForm");
                int i = 4;
                List<GridItem> lstP = new List<GridItem>();
                var x23 = wr1.Cell(i, 1).Value;
                while (x23!="")
                {
                    
                    lstP.Add(new GridItem { Idval = int.Parse(wr1.Cell(i, 1).Value.ToString()),row = i });
                    i++;
                    x23 = wr1.Cell(i, 1).Value;
                }
                i = 6;
                x23 = wr1.Cell(1,i).Value;
                List<GridItem> lstO = new List<GridItem>();
                while (x23!="")
                {
                    lstO.Add(new GridItem { Idval = int.Parse(wr1.Cell(1,i).Value.ToString()),col=i });
                    i+=2;
                    x23 = wr1.Cell(1, i).Value;
                }

                foreach(var col in lstO)
                {
                    foreach(var row in lstP)
                    {
                        var temp = _context.ObstacleCompetitions.FirstOrDefault(a => a.CompetitionId == idC && a.ObstacleId == col.Idval);
                        var temp2 = _context.Results.FirstOrDefault(a => a.PartisipantId == row.Idval && a.ObstacleCompetitionId == temp.ObstacleCompetitionId);
                        if (temp2 == null)
                        {
                            temp2 = new Result();
                            temp2.ObstacleCompetitionId = temp.ObstacleCompetitionId;
                            temp2.PartisipantId = row.Idval;
                            _context.Results.Add(temp2);
                        }
                        //var a = int.Parse(wr1.Cell(row.row, col.col + 1).Value.ToString());
                        try { 
                            temp2.Penalty = int.Parse(wr1.Cell(row.row,col.col+1).Value.ToString());
                            var tempx = wr1.Cell(row.row, col.col).Value;
                            temp2.Time = tempx.ToString().Trim();
                        }
                        catch
                        {
                            temp2.Penalty = 0;
                            temp2.Time = "00:00:00";
                        }
                        _context.SaveChanges();

                    }

                }

            }


            return RedirectToAction("Competition", "Main", new { id = idC });
        }



        public FileResult GetFile(string name)
        {
            string x = Path.GetFullPath(name);
            string x1 = _hostingEnvironment.WebRootPath;
            string path1 = x1+ "\\Content\\tmp\\"+ name;
            FileStream fs = System.IO.File.OpenRead(path1);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet,name);
        }
        
        
        /*[HttpPost]
        public IActionResult Excel(int idC)
        {
            var comp = _context.Competitions.FirstOrDefault
        }
        [HttpPost]
        public ActionResult Excel(Items items)
        {
           
                string docName = $"report{DateTime.Now.Ticks}.xlsx";
                string docNameFile = "~/Content/Tmp/" + docName;

                using (XLWorkbook wb = new XLWorkbook(XLEventTracking.Disabled))
                {
                    var wr = wb.Worksheets.Add("all");
                    wr.Cell("A1").Value = "#";
                    wr.Cell("B1").Value = "Full name";
                    wr.Cell("C1").Value = "Recent contact date";
                    wr.Cell("D1").Value = "Recent contact";
                    wr.Cell("E1").Value = "Contacted by";
                    wr.Cell("F1").Value = "Status";
                    var X = AItems.Split('/');
                    wr.Column(1).Width = 18;
                    wr.Column(2).Width = 40;
                    wr.Column(3).Width = 25;
                    wr.Column(4).Width = 100;
                    wr.Column(5).Width = 30;
                    wr.Column(6).Width = 15;

                    for (int i = 0; i < X.Length - 1; i++)
                    {

                        var data = new EditItem();
                        int a0 = X[i].ToInt();
                        data.Item = dbc.ANKETA.FirstOrDefault(a => a.KEY == a0);
                        data.Events = dbc.Database.SqlQuery<ANKETA_Events>("exec spAnketaEvents {0}", X[i].ToInt()).ToList();
                        data.Status = vDict.ListStatus.FirstOrDefault(a => a.ID == data.Item.STATUS)?.Name;
                        wr.Cell(i + 2, 1).Value = data.Item.SER;
                        wr.Cell(i + 2, 2).Value = data.Item.NAME;
                        wr.Cell(i + 2, 3).Value = data.Events[0].Date;
                        wr.Cell(i + 2, 4).Value = data.Events[0].Description;
                        wr.Cell(i + 2, 5).Value = data.Events[0].ContactPerson;
                        wr.Cell(i + 2, 6).Value = data.Status;

                    }

                    using (var stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        stream.Flush();

                        return new FileContentResult(stream.ToArray(),
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                        {
                            FileDownloadName = $"brands_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                        };
                    }
                }
                
                

        }
        public FileResult GetFile(string name)
        {
            string docNameFile = "~/Content/Tmp/" + name;

            //docNameFile = @"D:\tmp\1.xlsx";
            if (System.IO.File.Exists(docNameFile))
            {
                return File(docNameFile, System.Net.Mime.MediaTypeNames.Application.Octet,
                    System.IO.Path.GetFileName(docNameFile));
            }

            return null;
        }*/
    }
}
