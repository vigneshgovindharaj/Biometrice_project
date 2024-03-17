using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPS.App_Code.BO
{
    public class TalukBO
    {
        private  int i_TalukID;
        private  string i_DistrictID;
        private  string s_TalukName;
        private  int i_ModifiedBy;
        private  DateTime dt_CreatedDate;
        private  DateTime dt_ModifiedDate;

        public  int TalukID
        {
            get
            {
                return i_TalukID;
            }

            set
            {
                i_TalukID = value;
            }
        }

        public  string DistrictID
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

        public  string TalukName
        {
            get
            {
                return s_TalukName;
            }

            set
            {
                s_TalukName = value;
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