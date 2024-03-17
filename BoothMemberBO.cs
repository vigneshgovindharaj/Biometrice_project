using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPS.App_Code.BO
{
   public class BoothMemberBO
    {
        
        private  string i_AadharID;
        private  string s_BoothMemberID;
        private  string i_LACID;
        private  DateTime dt_PollingDate;
        private  int i_ModifiedBy;
        private  DateTime dt_CreatedDate;
        private  DateTime dt_ModifiedDate;
        private bool b_status;
        public  string AadharID
        {
            get
            {
                return i_AadharID;
            }

            set
            {
                i_AadharID = value;
            }
        }

        public  string BoothMemberID
        {
            get
            {
                return s_BoothMemberID;
            }

            set
            {
                s_BoothMemberID = value;
            }
        }

        public  string LACID
        {
            get
            {
                return i_LACID;
            }

            set
            {
                i_LACID = value;
            }
        }

        public  DateTime PollingDate
        {
            get
            {
                return dt_PollingDate;
            }

            set
            {
                dt_PollingDate = value;
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
        public bool Status
        {
            get
            {
                return b_status;
            }

            set
            {
                b_status = value;
            }
        }
        public string BMName
        { get; set; }
        public int AlternateMobileNumber
        { get; set; }
        public int StateID
        { get; set; }
        public int DistrictID
        { get; set; }
        public int TalukID
        { get; set; }
        public int VillageID
        { get; set; }
       
    }
}
