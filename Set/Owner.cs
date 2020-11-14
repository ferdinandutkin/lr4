using System;
using System.Diagnostics;

namespace LR4
{
    public partial class Set<T>
    {

        public static Owner OwnerInfo { get; private set; }
        public static Date CreationDate { get; private set; }

        static Set()
        {
            OwnerInfo = new Owner("61806555", "Stanislav Tumash", "BSTU");
            CreationDate = "21.09.2020";
        }


        public class Date
        {
            private ushort day, month;
            public ushort Day
            {
                get => day;
                set
                {
                    if (value > 31)
                    {
                        day = 31;
                    }
                    else
                    {
                        day = value;
                    }
                }
            }
            public ushort Month
            {
                get => month;
                set
                {
                    if (value > 12)
                    {
                        month = 12;
                    }
                    else
                    {
                        month = value;
                    }
                }
            }
            public int Year { get; set; }


            public Date(string date)
            {
                string[] tokens = date.Split('.', StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length != 3)
                {
                    Debug.WriteLine("парсинг даты сломался");
                }
                else
                {
                    Day = ushort.Parse(tokens[0]);
                    Month = ushort.Parse(tokens[1]);
                    Year = int.Parse(tokens[2]);

                }

            }

            public Date(ushort day, ushort month, int year)
            {
                Day = day;
                Month = month;
                Year = year;
            }


            public static implicit operator Date(string s) => new Date(s);

            public override string ToString() => $"{Day}.{Month}.{Year}";

            public override bool Equals(object o)
            {

                if ((o == null) || !GetType().Equals(o.GetType()))
                {
                    return false;
                }
                else
                {
                    var d = (Date)o;
                    return (d.Day == Day) && (d.Month == Month) && (d.Year == Year);
                }
            }

            public override int GetHashCode() => HashCode.Combine(Day, Month, Year);
        }

        public class Owner
        {
            public string GithubID { get; private set; }
            public string Name { get; private set; }
            public string Organization { get; private set; }
            public Owner(string id, string name, string organisation)
            {

                GithubID = id;// "61806555";
                Name = name;// "Tumash Stanislav";
                Organization = organisation;// "BSTU";
            }

            public override string ToString() => $"ID: {GithubID}, Имя: {Name}, Организация: {Organization}";
          
        }

    }
   
}
