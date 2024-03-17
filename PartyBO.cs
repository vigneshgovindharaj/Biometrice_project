using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPS.App_Code.BO
{
    public class PartyBO
    {
        private  int i_PartyID;
        private  string s_PartyName;
        private  string b_Status;
        private  int i_StateID;
        private  int i_ModifiedBy;
        private  DateTime dt_CreatedDate;
        private  DateTime dt_ModifiedDate;

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

        public  string S_PartyName
        {
            get
            {
                return s_PartyName;
            }

            set
            {
                s_PartyName = value;
            }
        }

        public  string B_Status
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