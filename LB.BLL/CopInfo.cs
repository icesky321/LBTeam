﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.BLL
{
    public class CopInfo
    {
        LB.SQLServerDAL.CopInfoDA da = new SQLServerDAL.CopInfoDA();

        public LB.SQLServerDAL.CopInfo NewCopInfo(LB.SQLServerDAL.CopInfo copifo)
        {
            return da.NewCopInfo(copifo);
        }

        public LB.SQLServerDAL.CopInfo GetCopInfoeById(int id)
        {
            return da.GetCopInfoeById(id);
        }

        public LB.SQLServerDAL.CopInfo GetCopInfoeByUserId(int UserId)
        {
            return da.GetCopInfoeByUserId(UserId);
        }

        public void UpdateCopInfo(LB.SQLServerDAL.CopInfo CopInfo)
        {
            da.UpdateCopInfo(CopInfo);
        }

        public IQueryable GetCopInfo()
        {
            return da.GetCopInfo();
        }

        public IQueryable GetCopInfodByAddress(string province, string city, string country, string street, int UserTypeId)
        {
            return da.GetCopInfodByAddress(province, city, country, street, UserTypeId);
        }

        public IQueryable GetCopInfoByUserType(int UserTypeId)
        {
            return da.GetCopInfoByUserType(UserTypeId);
        }

        public bool ExistUseId(int UseId)
        {
            return da.ExistUseId(UseId);
        }

        public IQueryable<LB.SQLServerDAL.CopInfo> GetCopInfosByUserType(int UserType)
        {
            return da.GetCopInfosByUserType(UserType);
        }

        public IQueryable GetCopInfoByUserType_RegionCode_TelNum(int UserTypeId, string RegionCode, string TelNum)
        {
            return da.GetCopInfoByUserType_RegionCode_TelNum(UserTypeId, RegionCode, TelNum);
        }
    }
}
