using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.Model
{
    public class TradeleadsModel
    {
        public TradeleadsModel()
        {
            Title = string.Empty;
            Province = string.Empty;
            City = string.Empty;
            Town = string.Empty;
            Street = string.Empty;
            Volume = string.Empty;
            Price = string.Empty;
            DetailInfo = string.Empty;
            UserName = string.Empty;
            UnitName = string.Empty;
            TSName = string.Empty;
            TSTypeName = string.Empty;
            PicPath = string.Empty;
            MobilePhoneNum = string.Empty;
        }

        public int infoId
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string Province
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string Town
        {
            get;
            set;
        }
        public string Street
        {
            get;
            set;
        }
        public string Volume
        {
            get;
            set;
        }
        public string Price
        {
            get;
            set;
        }
        public string DetailInfo
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
        public string UnitName
        {
            get;
            set;
        }
        public int TSId
        {
            get;
            set;
        }
        public string TSName
        {
            get;
            set;
        }
        public DateTime ReleaseDate
        {
            get;
            set;
        }
        public int Hits
        {
            get;
            set;
        }
        public int TId
        {
            get;
            set;
        }
        public string TSTypeName
        {
            get;
            set;
        }
        public string PicPath
        {
            get;
            set;
        }
        public bool Audit
        {
            get;
            set;
        }
        public DateTime AuditDatetime
        {
            get;
            set;
        }
        public string MobilePhoneNum
        {
            get;
            set;
        }
        public int UserTypeId
        {
            get;
            set;
        }

        public bool IDAuthentication
        {
            get;
            set;
        }

        public bool UserAudit
        {
            get;
            set;
        }
    }
}
