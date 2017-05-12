using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LondonTubeDB.Context;
using LondonTubeDB.Model;
using System.Configuration;
using LondonTube.Models;

namespace LondonTube.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LondonTubeModel ltm = new LondonTubeModel();

            return View(ltm);
        }

        [HttpPost]
        public ActionResult Index(LondonTubeModel model)
        {
            LondonTubeModel ltm = new LondonTubeModel();
            if (ModelState.IsValid)
            {
                LTContext dc = new LTContext(ConfigurationManager.ConnectionStrings["LondonTube"].ConnectionString);

                Station s = (from ss in dc.Stations
                             where ss.StationId == model.StationId
                             select ss).FirstOrDefault();

                List<TubeLine> tbls = new List<TubeLine>();
                List<StationModel> smFrom = GetStationModelFrom(s.StationName, model.NoOfStation);
                List<StationModel> smTo = GetStationModelTo(s.StationName, model.NoOfStation);
                ltm.StationModelList = new List<StationModel>();
                for (int i = 0; i < smFrom.Count; i++)
                {
                    ltm.StationModelList.Add(smFrom[i]);
                }
                for (int j = 0; j < smTo.Count; j++)
                {
                    StationModel smToj = new StationModel();
                    smToj.FromStation = smTo[j].ToStation;
                    smToj.ToStation = smTo[j].FromStation;

                    if (!ltm.StationModelList.Any(l => l.ToStation == smToj.ToStation))
                        ltm.StationModelList.Add(smToj);
                }
                ltm.StationModelList = ltm.StationModelList.OrderBy(l => l.ToStation).ToList();
            }


            return View(ltm);
        }

        public List<StationModel> GetStationModelFrom(string StationName, int NoOfStation)
        {
            List<StationModel> newsm = new List<StationModel>();
            LTContext dc = new LTContext(ConfigurationManager.ConnectionStrings["LondonTube"].ConnectionString);
            List<TubeLine> tsA = (from tls in dc.TubeLines
                                  where tls.FromStation == StationName
                                  select tls).ToList();
            int iCount = 1;
            while (iCount < NoOfStation)
            {
                List<StationModel> smlA = new List<StationModel>();
                List<TubeLine> tsB = GetTubeLineFromMore(tsA);
                if (tsB.Count > 0)
                {
                    tsA = tsB;
                }
                iCount += 1;
            }
            if (iCount == NoOfStation)
            {
                if (tsA.Count > 0)
                {
                    foreach (var s in GetTubeLineEnd(tsA))
                    {
                        newsm.Add(s);
                    }
                }
            }
            return newsm;
        }

        public List<StationModel> GetTubeLineEnd(List<TubeLine> tsE)
        {
            List<StationModel> smlE = new List<StationModel>();
            for (int e = 0; e < tsE.Count; e++)
            {
                StationModel smE = new StationModel();
                smE.FromStation = tsE[e].FromStation;
                smE.ToStation = tsE[e].ToStation;
                smlE.Add(smE);
            }
            return smlE;
        }
        public List<TubeLine> GetTubeLineFromMore(List<TubeLine> tlInput)
        {
            LTContext dc = new LTContext(ConfigurationManager.ConnectionStrings["LondonTube"].ConnectionString);
            List<TubeLine> tsE = new List<TubeLine>();
            List<TubeLine> tsTot = new List<TubeLine>();
            string ToStation = "";
            string FromStation = "";
            if (tlInput.Count > 0)
            {
                List<StationModel> smlD = new List<StationModel>();
                for (int d = 0; d < tlInput.Count; d++)
                {
                    StationModel smD = new StationModel();
                    smD.FromStation = tlInput[d].FromStation;
                    smD.ToStation = tlInput[d].ToStation;
                    smlD.Add(smD);
                    ToStation = tlInput[d].ToStation;
                    FromStation = tlInput[d].FromStation;
                    tsE = (from tls in dc.TubeLines
                           where tls.FromStation == ToStation
                           && tls.ToStation != FromStation
                           select tls).ToList();
                    foreach (var t in tsE)
                    {
                        tsTot.Add(t);
                    }
                }
            }
            return tsTot;
        }
        public List<StationModel> GetStationModelTo(string StationName, int NoOfStation)
        {
            List<StationModel> newsm = new List<StationModel>();
            LTContext dc = new LTContext(ConfigurationManager.ConnectionStrings["LondonTube"].ConnectionString);
            List<TubeLine> tsA = (from tls in dc.TubeLines
                                  where tls.FromStation == StationName
                                  select tls).ToList();
            int iCount = 1;
            while (iCount < NoOfStation)
            {
                List<StationModel> smlA = new List<StationModel>();
                List<TubeLine> tsB = new List<TubeLine>();
                if (iCount == 1)
                  tsB = GetTubeLineToStart(tsA);
                else
                  tsB = GetTubeLineToMore(tsA);
                if (tsB.Count > 0)
                {
                    tsA = tsB;
                }
                iCount += 1;
            }
            if (iCount == NoOfStation)
            {
                if (tsA.Count > 0)
                {
                    foreach (var s in GetTubeLineEnd(tsA))
                    {
                        newsm.Add(s);
                    }
                }
            }
            return newsm;
        }

        public List<TubeLine> GetTubeLineToStart(List<TubeLine> tlInput)
        {
            LTContext dc = new LTContext(ConfigurationManager.ConnectionStrings["LondonTube"].ConnectionString);
            List<TubeLine> tsE = new List<TubeLine>();
            List<TubeLine> tsTot = new List<TubeLine>();
            string ToStation = "";
            string FromStation = "";
            if (tlInput.Count > 0)
            {
                List<StationModel> smlD = new List<StationModel>();
                for (int d = 0; d < tlInput.Count; d++)
                {
                    StationModel smD = new StationModel();
                    smD.FromStation = tlInput[d].FromStation;
                    smD.ToStation = tlInput[d].ToStation;
                    smlD.Add(smD);
                    ToStation = tlInput[d].ToStation;
                    FromStation = tlInput[d].FromStation;
                    tsE = (from tls in dc.TubeLines
                           where tls.ToStation == ToStation
                           && tls.FromStation != FromStation
                           select tls).ToList();
                    foreach (var t in tsE)
                    {
                        tsTot.Add(t);
                    }
                }
            }
            return tsTot;
        }
        public List<TubeLine> GetTubeLineToMore(List<TubeLine> tlInput)
        {
            LTContext dc = new LTContext(ConfigurationManager.ConnectionStrings["LondonTube"].ConnectionString);
            List<TubeLine> tsE = new List<TubeLine>();
            List<TubeLine> tsTot = new List<TubeLine>();
            string ToStation = "";
            string FromStation = "";
            if (tlInput.Count > 0)
            {
                List<StationModel> smlD = new List<StationModel>();
                for (int d = 0; d < tlInput.Count; d++)
                {
                    StationModel smD = new StationModel();
                    smD.FromStation = tlInput[d].FromStation;
                    smD.ToStation = tlInput[d].ToStation;
                    smlD.Add(smD);
                    ToStation = tlInput[d].ToStation;
                    FromStation = tlInput[d].FromStation;
                    tsE = (from tls in dc.TubeLines
                           where tls.ToStation == FromStation
                           && tls.FromStation != ToStation
                           select tls).ToList();
                    foreach (var t in tsE)
                    {
                        tsTot.Add(t);
                    }
                }
            }
            return tsTot;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}