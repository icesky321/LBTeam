using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.Model
{
    public class UserInfoModel
    {
        public UserInfoModel()
        {
            UserName = string.Empty;
            MobilePhoneNum = string.Empty;
            Province = string.Empty;
            City = string.Empty;
            Town = string.Empty;
            Street = string.Empty;
            IDCard = string.Empty;
            BankName = string.Empty;
            Account = string.Empty;
            Chop = string.Empty;
            CopName = string.Empty;
            Bizlicense = string.Empty;
            HWPermit = string.Empty;
            CopDetail = string.Empty;
            RealName = string.Empty;
        }

        public Int32 UserId
        {
            get;
            set;
        }
        public Int32 UserTypeId
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string MobilePhoneNum
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
        public DateTime CreateTime
        {
            get;
            set;
        }
        public string IDCard
        {
            get;
            set;
        }
        public bool IDAuthentication
        {
            get;
            set;
        }
        public bool Audit
        {
            get;
            set;
        }
        public DateTime AuditDate
        {
            get;
            set;
        }
        public string BankName
        {
            get;
            set;
        }
        public string Account
        {
            get;
            set;
        }
        public bool ChopAuthentication
        {
            get;
            set;
        }
        public string Chop
        {
            get;
            set;
        }
        public bool InCharge
        {
            get;
            set;
        }
        public Int32 CopId
        {
            get;
            set;
        }
        public string CopName
        {
            get;
            set;
        }
        public string Bizlicense
        {
            get;
            set;
        }
        public bool BAuthentication
        {
            get;
            set;
        }
        public string HWPermit
        {
            get;
            set;
        }

        public bool HWAuthentication
        {
            get;
            set;
        }

        public string CopDetail
        {
            get;
            set;
        }

        public bool IsApproved
        {
            get;
            set;
        }

        public string RealName
        {
            get;
            set;
        }
    }
}
