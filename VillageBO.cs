using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPS.App_Code.BO
{
    public class VillageBO
    {
        private  int i_VillageID;
       
        private  string s_VillageName;
        private  int i_ModifiedBy;
        private  DateTime dt_CreatedDate;
        private  DateTime dt_ModifiedDate;
        private int i_Male;
        private int i_Female;
        private int i_Others;
        public  int VillageID
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

       

        public  string VillageName
        {
            get
            {
                return s_VillageName;
            }

            set
            {
                s_VillageName = value;
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

        public int Male
        {
            get
            {
                return i_Male;
            }

            set
            {
                i_Male = value;
            }
        }

        public int Female
        {
            get
            {
                return i_Female;
            }

            set
            {
                i_Female = value;
            }
        }

        public int Others
        {
            get
            {
                return i_Others;
            }

            set
            {
                i_Others = value;
            }
        }

    }
}