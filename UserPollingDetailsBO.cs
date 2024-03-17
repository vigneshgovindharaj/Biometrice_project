using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPS.App_Code.BO
{
    public class UserPollingDetailsBO
    {
        private static string i_EnrollmentIdID;
        private static string s_VoterId;
        private static string i_LACID;
        private static string s_BoothMemberID;
        private static string i_MemberID;
        private static string s_MemberName;
        private static string b_Status;
        private static int i_ModifiedBy;
        private static DateTime dt_CreatedDate;
        private static DateTime dt_ModifiedDate;

        public static string I_EnrollmentIdID
        {
            get
            {
                return i_EnrollmentIdID;
            }

            set
            {
                i_EnrollmentIdID = value;
            }
        }

        public static string S_VoterId
        {
            get
            {
                return s_VoterId;
            }

            set
            {
                s_VoterId = value;
            }
        }

        public static string I_LACID
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

        public static string S_BoothMemberID
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

        public static string I_MemberID
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

        public static string S_MemberName
        {
            get
            {
                return s_MemberName;
            }

            set
            {
                s_MemberName = value;
            }
        }

        public static string B_Status
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

        public static int I_ModifiedBy
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

        public static DateTime Dt_CreatedDate
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

        public static DateTime Dt_ModifiedDate
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