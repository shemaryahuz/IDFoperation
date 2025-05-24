using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IDFoperationApp
{
    internal class AMAN
    {
        public List<IntelligencMessage> Messages = new List<IntelligencMessage>();//מיצר רשימה של הודעות 
       // public Dictionary<string, int> messagesAmount = new Dictionary<string, int>();
        public Dictionary<string, int[]> troristRates = new Dictionary<string, int[]>();//רשימה של רמת המסוכנות
        public IntelligencMessage CreateMessage(Terrorist terrorist, string location, DateTime time)//פונקציה שמייצרת הודעות מודיעין ומוסיפה אותם לרשימת ההודעות
        {
            IntelligencMessage message = new IntelligencMessage(terrorist, location, time);
            this.Messages.Add(message);

            return message;
        }
            Public <Dictionary<string, int[]>> orderMessages(IntelligencMessage messages)
            {
                if (troristRates.ContainsKey(messages.Terrorist.Name))
                {
                    troristRates[messages.Terrorist.Name][0]++;
                }
                else { troristRates[messages.Terrorist.Name][0] = 1; }


                string knife = "knife";
                string gan = "gun";

                int danger = 0;
                if (messages.Terrorist.Weapons.Contains(knife))
                { danger++; }
                if (messages.Terrorist.Weapons.Contains(gan))
                {
                    danger += 2;
                }
                else { danger += 3; }
                this.troristRates[messages.Terrorist.Name][1] = danger;
                return troristRates;
            }
        

        public List< Dictionary<string, string[]>> rateTrorist(Dictionary<string, List<int>> troristRates)
        {
            List<Dictionary<string, int[]>> orderdenger = new List<Dictionary<string,int[]>>();
            int theMostDanger = 0;
            foreach(var p in troristRates)
            {
                if(p.Value[1] >= theMostDanger)
                {
                    orderdenger.Insert(0,p);

                }
            }
            return orderdenger;
        }
        
    }
}
