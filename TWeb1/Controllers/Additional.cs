using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

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

        private readonly DBLab1Context _context;
        public Additional(DBLab1Context context)
        {
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
