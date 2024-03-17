using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPS.App_Code.BO
{
    public class DECBO
    {
        private  string i_DecID;
        private  string s_DecName;
        private  int i_StateID; 
        private  int i_DistrictID;
        private  int i_ModifiedBy;
        private  DateTime dt_CreatedDate;
        private  DateTime dt_ModifiedDate;

        public  string DecID
        {
            get
            {
                return i_DecID;
            }

            set
            {
                i_DecID = value;
            }
        }

        public  string DecName
        {
            get
            {
                return s_DecName;
            }

            set
            {
                s_DecName = value;
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