using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPS.App_Code.BO
{
    public class LACDetailsBO
        
    {
        private  string i_LACID;
        private  int i_StateID;
        private  int i_DistrictID;
        private  int i_TalukID;
        private  string b_Status;
       
      
       
        private  int i_Year;
        private  int i_PartyID;
        private  string s_LacName;
        private  int i_MemberID;
        private  int i_ModifiedBy;
        private  DateTime dt_CreatedDate;
        private  DateTime dt_ModifiedDate;

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

        public  string B_State
        {
            get
            {
                return b_Status;
            }

            set
            {
                b_Status = value;
            }
        }

        

       

       
        public int Year
        {
            get
            {
                return i_Year;
            }

            set
            {
                i_Year = value;
            }
        }

        public  int PartyID
        {
            get
            {
                return i_PartyID;
            }

            set
            {
                i_PartyID = value;
            }
        }

        public  string S_LacName
        {
            get
            {
                return s_LacName;
            }

            set
            {
                s_LacName = value;
            }
        }

        public int MemberID
        {
            get
            {
                return i_MemberID;
            }

            set
            {
                i_MemberID = value;
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
