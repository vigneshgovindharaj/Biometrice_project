using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPS.App_Code.BO
{
    public class WardBO
    {
        private  string i_VillageID;
        private  string i_WardID;
        private  string s_WardName;
        private  int i_ModifiedBy;
        private  DateTime dt_CreatedDate;
        private  DateTime dt_ModifiedDate;

        public  string I_VillageID
        {
            get
            {
                return i_VillageID;
            }

            set
            {
                i_VillageID = value;
            }
        }

        public  string I_WardID
        {
            get
            {
                return i_WardID;
            }

            set
            {
                i_WardID = value;
            }
        }

        public  string S_WardName
        {
            get
            {
                return s_WardName;
            }

            set
            {
                s_WardName = value;
            }
        }

        public  int I_ModifiedBy
        {
            get
            {
                return i_ModifiedBy;
            }

            set
            {
                i_ModifiedBy = value;
            }
        }

        public  DateTime Dt_CreatedDate
        {
            get
            {
                return dt_CreatedDate;
            }

            set
            {
                dt_CreatedDate = value;
            }
        }

        public  DateTime Dt_ModifiedDate
        {
            get
            {
                return dt_ModifiedDate;
            }

            set
            {
                dt_ModifiedDate = value;
            }
        }
    }
}