using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LB.SQLServerDAL
{

    public partial class LBDataContext
    {
        public LBDataContext() :
            base(LB.SQLServerDAL.DS.ConnectionString.ConnectionStringLB(), mappingSource)
        {
            OnCreated();
        }
    }
}
