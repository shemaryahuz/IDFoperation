

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public abstract class Organization
{
    public string dateOfAstablish;
    public string corruntCommender;
    //List<string> myList = new List<string>();


    public Organization(string dateOfAstablish,string corruntCommender)
    {
        this.dateOfAstablish = dateOfAstablish;
        this.corruntCommender = corruntCommender;
        //this.myList = new List<string>();
    }
}



public class IDF : Organization
{
    

    public IDF(string dateOfAstablish, string corruntCommender) : base("1948", corruntCommender)
    {
      
    List<string> myList = new List<string>();
}
}