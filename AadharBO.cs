using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPS.App_Code.BO
{
    public class AadharBO
    {
        
        private  string i_AadharID;
        private  string s_FirstName;
        private  string s_LastName;
        private  string i_MobileNumber;
        private  string s_Biometric;
        private  string s_Address;
        private  string i_PinCode;
        private  int i_ModifiedBy;
        private  DateTime dt_CreatedDate;
        private  DateTime dt_ModifiedDate;
        private bool status;

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

        public  string FirstName
        {
            get
            {
                return s_FirstName;
            }

            set
            {
                s_FirstName = value;
            }
        }

        public  string LastName
        {
            get
            {
                return s_LastName;
            }

            set
            {
                s_LastName = value;
            }
        }

        public  string MobileNumber
        {
            get
            {
                return i_MobileNumber;
            }

            set
            {
                i_MobileNumber = value;
            }
        }

        public  string Biometric
        {
            get
            {
                return s_Biometric;
            }

            set
            {
                s_Biometric = value;
            }
        }

        public  string Address
        {
            get
            {
                return s_Address;
            }

            set
            {
                s_Address = value;
            }
        }

        public  string PinCode
        {
            get
            {
                return i_PinCode;
            }

            set
            {
                i_PinCode = value;
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
        { get; set; }
    }
}

