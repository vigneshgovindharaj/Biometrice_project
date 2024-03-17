using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPS.App_Code.BO
{
    public class DistrictBO
    {
        private  int i_DistrictID;
        private  int i_StateID;
        private  string s_DistrictName;
        private  int i_ModifiedBy;
        private  DateTime dt_CreatedDate;
        private  DateTime dt_ModifiedDate;

        public  int DistrictID
        {
            get
            {
                return i_DistrictID;
            }

            set
            {
                i_DistrictID = value;
            }
        }

        public  int StateID
        {
            get
            {
                return i_StateID;
            }

            set
            {
                i_StateID = value;
            }
        }

        public  string DistrictName
        {
            get
            {
                return s_DistrictName;
            }

            set
            {
                s_DistrictName = value;
            }
        }

        public  int ModifiedBy
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

        public  DateTime CreatedDate
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

        public  DateTime ModifiedDate
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