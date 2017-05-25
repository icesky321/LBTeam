using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class Tradeleads
    {
        LB.SQLServerDAL.TradeleadsDA da = new SQLServerDAL.TradeleadsDA();

        public int GetTradeleadsSum()
        {
            return da.GetTradeleadsSum();
        }

        public LB.SQLServerDAL.Tradeleads NewTradeleads(LB.SQLServerDAL.Tradeleads tradeleads)
        {
            return da.NewTradeleads(tradeleads);
        }

        public void UpdateTradeleads(LB.SQLServerDAL.Tradeleads tradeleadsinfo)
        {
            da.UpdateTradeleads(tradeleadsinfo);
        }

        public void DeleteTradeleads(int infoId)
        {
            da.DeleteTradeleads(infoId);
        }

        public IQueryable<LB.SQLServerDAL.Tradeleads> GetTradeleads()
        {
            return da.GetTradeleads();
        }

        public IQueryable<LB.SQLServerDAL.Tradeleads> GetTradeleadsByUserId(int UserId)
        {
            return da.GetTradeleadsByUserId(UserId);
        }

        public IQueryable<LB.SQLServerDAL.Tradeleads> GetTradeleadsByTSId(int TSId)
        {
            return da.GetTradeleadsByTSId(TSId);
        }

        public LB.SQLServerDAL.Tradeleads GetTradeleadsByinfoId(int InfoId)
        {
            return da.GetTradeleadsByinfoId(InfoId);
        }

        public IQueryable GetTradeleadsByTradeType(int TId, bool Audit)
        {
            return da.GetTradeleadsByTradeType(TId, Audit);
        }

        public IQueryable GetTradeleadsByAddressAndType(string province, string city, string country, string street, int TId)
        {
            return da.GetTradeleadsByAddressAndType(province, city, country, street, TId);
        }

        public IQueryable<LB.Model.TradeleadsModel> GetTradeleadsInfoByAudit(string Audit, string province, string city, string country, string street, string TId)
        {
            return da.GetTradeleadsInfoByAudit(Audit, province, city, country, street, TId);
        }

        public IQueryable<LB.Model.TradeleadsModel> GetTradeleadsInfoByAll()
        {
            return da.GetTradeleadsInfoByAll();
        }

        public LB.Model.TradeleadsModel GetTradeleadsInfoModelByinfoId(int InfoId)
        {
            return da.GetTradeleadsInfoModelByinfoId(InfoId);
        }
    }

}
