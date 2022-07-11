using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.work.Meetingroom
{
    public class Logtime: IComparable<Logtime>
    {
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public Logtime()
        {

        }

        public int CompareTo(Logtime? other)
        {
            if(other == null) return 1;
            else
            {
                return this.Start.CompareTo(other.Start);
            }
        }
    }

    public class LogTimeHandler
    {
        public List<Logtime> Logs { get; private set; }
        public LogTimeHandler(List<Logtime> logs)
        {
            Logs = logs;
        }

        public double GetIdleTime()
        {
            double idleTime = 24*60;
            this.Logs.Sort();
            if (Logs.Count == 0) return idleTime;
            if(Logs.Count==1) return idleTime - (Logs[0].End - Logs[0].Start).TotalMinutes;

            Logtime prev = null;
            
            foreach (var curr in Logs)
            {
                if(prev==null)//first element 
                {
                    idleTime -= (curr.End - curr.Start).TotalMinutes;
                    prev = curr;
                }
                else
                {
                    if(curr.Start<prev.End && curr.End <= prev.End)
                    {
                        continue;
                        /*
                        p------------------------------
                        c  ---------------------
                        */
                    }
                    else if(curr.Start < prev.End)
                    {
                        /*
                        p------------------------------------
                        c         ----------------------------------------

                        */
                        idleTime -= (curr.End - prev.End).TotalMinutes;                        
                    }
                    else if(curr.Start >= prev.End)
                    {
                        /*
                          p-------------------------------
                          c                                   -----------------
                        */
                        idleTime -= (curr.End - curr.Start).TotalMinutes;

                    }
                    prev = new Logtime { Start = prev.Start, End = curr.End };
                }
            }
           

            return idleTime;

        }
    }
}
