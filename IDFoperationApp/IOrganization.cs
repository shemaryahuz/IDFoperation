using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    public abstract class Organization
    {
        public string dateOfAstablish;
        public string corruntCommender;
        //List<string> myList = new List<string>();


        public Organization(string dateOfAstablish, string corruntCommender)
        {
            this.dateOfAstablish = dateOfAstablish;
            this.corruntCommender = corruntCommender;
            //this.myList = new List<string>();
        }
    }

