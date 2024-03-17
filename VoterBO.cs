using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPS.App_Code.BO
{
    public class VoterBO // Declare Class Public to Access any where 
    {
        //Declaring VoterDetails Variables
        private string i_Voter;
        private  int i_EnrollmentID;
        private  string i_AadharID;
        private  int i_ModifiedBy;
        private  DateTime dt_CreatedDate;
        private  DateTime dt_ModifiedDate;
        private bool status;
        private string s_VoterName;
        public string Voter
        {
            get
            {
                return i_Voter;
            }

            set
            {
                i_Voter = value;
            }
        }
        public  int EnrollmentID
        {
            get
            {
                return i_EnrollmentID;
            }

            set
            {
                i_EnrollmentID = value;
            }
        }

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
        public string VoterName
        {
            get
            {
                return s_VoterName;
            }

            set
            {
                s_VoterName = value;
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
                return status;
            }

            set
            {
                status = value;
            }
        }
    }
}
