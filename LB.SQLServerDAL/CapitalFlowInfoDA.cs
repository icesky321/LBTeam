using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{
    public class CapitalFlowInfoDA
    {
        LB.SQLServerDAL.LBDataContext dbContext = new LBDataContext(DS.ConnectionString.ConnectionStringLB());

        public LB.SQLServerDAL.CapitalFlowInfo NewCapitalFlowInfo(LB.SQLServerDAL.CapitalFlowInfo capitalflowinfo)
        {
            if (capitalflowinfo != null)
            {
                dbContext.CapitalFlowInfo.InsertOnSubmit(capitalflowinfo);
                dbContext.SubmitChanges();

            }
            return capitalflowinfo;
        }

        public void UpdateCapitalFlowInfo(LB.SQLServerDAL.CapitalFlowInfo capitalflowinfo)
        {
            dbContext.SubmitChanges();
        }

        public IQueryable<LB.Model.UserInfoModel> GetUserInfosBySEO(string province, string city, string country, string street, string UserTypeId, string TelNum)
        {
            var query = from u in dbContext.UserInfo
                        join c in dbContext.CopInfo on u.UserId equals c.UserId into leftGroup1
                        from c in leftGroup1.DefaultIfEmpty()
                        join a in dbContext.Aspnet_Users on u.MobilePhoneNum equals a.UserName into leftGroup2
                        from a in leftGroup2.DefaultIfEmpty()
                        join b in dbContext.Aspnet_Membership on a.UserId equals b.UserId into leftGroup3
                        from b in leftGroup3.DefaultIfEmpty()
                        select new LB.Model.UserInfoModel()
                        {
                            UserId = u.UserId,
                            Account = u.Account,
                            BankName = u.BankName,
                            BAuthentication = c.BAuthentication == null ? false : c.BAuthentication.Value,
                            Bizlicense = c.Bizlicense,
                            City = u.City,
                            UserName = u.UserName,
                            CopDetail = c.CopDetail,
                            CopName = c.CopName,
                            CreateTime = Convert.ToDateTime(u.CreateTime),
                            HWAuthentication = c.HWAuthentication == null ? false : c.HWAuthentication.Value,
                            HWPermit = c.HWPermit,
                            IDAuthentication = u.IDAuthentication == null ? false : u.IDAuthentication.Value,
                            IDCard = u.IDCard,
                            Province = u.Province,
                            Street = u.Street,
                            MobilePhoneNum = u.MobilePhoneNum,
                            Town = u.Town,
                            Audit = u.Audit == null ? false : u.Audit.Value,
                            UserTypeId = Convert.ToInt32(u.UserTypeId),
                            AuditDate = u.AuditDate == null ? Convert.ToDateTime("1900-1-1") : u.AuditDate.Value,
                            IsApproved = Convert.ToBoolean(b.IsApproved)
                        };
            if (province != "---" && province != "-1")
            {
                query = query.Where(p => p.Province.IndexOf(province) >= 0);
            }
            if (city != "--")
            {
                query = query.Where(p => p.City.IndexOf(city) >= 0);
            }
            if (country != "--")
            {
                query = query.Where(p => p.Town.IndexOf(country) >= 0);
            }
            if (street != "--")
            {
                query = query.Where(p => p.Street.IndexOf(street) >= 0);
            }
            if (!string.IsNullOrEmpty(UserTypeId))
            {
                query = query.Where(p => p.UserTypeId == Convert.ToInt32(UserTypeId));
            }
            if (!string.IsNullOrEmpty(TelNum))
            {
                query = query.Where(p => p.MobilePhoneNum.Contains(TelNum));
            }
            return query.AsQueryable<LB.Model.UserInfoModel>();
        }
    }
}
