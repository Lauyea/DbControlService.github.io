using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace DbControlService
{
    /// <summary>
    ///DbControlService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://camins.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class DbControlService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool CreateSingleStation(int _SN, string _Model, int _ProductLot,
            long _InTime, long _OutTime)
        {
            using(var db = new StationContext())
            {
                Station station = new Station
                {
                    SN = _SN,
                    Model = _Model,
                    ProductLot = _ProductLot,
                    InTime = _InTime,
                    OutTime = _OutTime
                };
                db.Stations.Add(station);
                db.SaveChanges();
            }
                return true;
        }

        [WebMethod]
        public bool CreateMultiStatoin(List<Station> stations)
        {
            using(var db = new StationContext())
            {
                db.Stations.AddRange(stations);
                db.SaveChanges();
            }
            return true;
        }

        [WebMethod]
        public List<Station> ReadAllStationsToList()
        {
            using(var db = new StationContext())
            {
                var stations = db.Stations.ToList();
                return stations;
            }
        }

        [WebMethod]
        public List<Station> ReadStationsByModel(string modelName)
        {
            using(var db = new StationContext())
            {
                var stations = db.Stations.Where(m => m.Model == modelName).ToList();
                return stations;
            }
        }

        [WebMethod]
        public bool UpdateStationsBySN(int _SN, string _Model, int _ProductLot,
            long _InTime, long _OutTime)
        {
            using(var db = new StationContext())
            {
                var stations = db.Stations.Where(s => s.SN == _SN).ToList();
                foreach(var station in stations)
                {
                    station.Model = _Model;
                    station.ProductLot = _ProductLot;
                    station.InTime = _InTime;
                    station.OutTime = _OutTime;
                }
                db.SaveChanges();
                return true;
            }
        }

        [WebMethod]
        public bool DeleteStationsBySN(int _SN)
        {
            using (var db = new StationContext())
            {
                var stations = db.Stations.Where(s => s.SN == _SN);
                db.Stations.RemoveRange(stations);
                db.SaveChanges();
                return true;
            }
        }

        [WebMethod]
        public bool DropStationsTable()
        {
            using(var db = new StationContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE Station");
                db.SaveChanges();
            }
            return true;
        }
    }
}
