using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab20_CoffeeShopApp.Models
{
    public class UserInfo
    {
        private string fname;
        private string lname;
        private string email;
        private string pnumber;
        private string pword;
        private string bday;


        public string Userfname
        {
            set
            {
                fname = value;
            }

            get
            {
                return fname;
            }
        }


        public string Userlname
        {
            set
            {
                lname = value;
            }

            get
            {
                return lname;
            }
        }


        public string Useremail
        {
            set
            {
                email = value;
            }

            get
            {
                return email;
            }
        }


        public string Userpnumber
        {
            set
            {
                pnumber = value;
            }

            get
            {
                return pnumber;
            }
        }


        public string Userpword
        {
            set
            {
                pword = value;
            }

            get
            {
                return pword;
            }
        }

        public string Userbday
        {
            get
            {
                return bday;
            }

            set
            {
                bday = value;
            }
        }

        public UserInfo():this("","","","","","")
        {

        }


        public UserInfo(string fname, string lname, string email, string pnumber, string pword, string bday)
        {
            this.fname = fname;
            this.lname = lname;
            this.email = email;
            this.pnumber = pnumber;
            this.pword = pword;
            this.bday = bday;
        }
    }
}