using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using SystemDAO;

namespace WindowsFormsApplication1
{
    public  static class NyData
    {
        
        public static IEnumerable<NyModel> Getdata(int year,int month)
        {
            
            List<NyModel> resultlist=new List<NyModel>();
            int maxdayinthismonth = DateTime.DaysInMonth(year, month);
            for (int i = 1; i<=maxdayinthismonth; i++)
            {
                string cmd = "select TagName, sum(Val) as sumval from " +
                         "(select TagName,Val,DateAndTime from FloatTable where DateAndTime between @date1 and @date2)  " +
                         "as dt group by tagname  ";
                var startdate = new DateTime(year, month, i);
                var date1 = new SqlParameter()
                {
                    ParameterName = "@date1",
                    Value = startdate,


                };

                var enddate = startdate.AddHours(24.0);
                var date2 = new SqlParameter()
                {
                    ParameterName = "@date2",
                    Value = enddate,
                };

                var s = SqlHelper.ExecuteReader(CommandType.Text, cmd,date1,date2);
                using (s)
                {
                    if (s.HasRows)
                    {

                        while (s.Read())
                        {
                            var model = new NyModel
                            {
                                TagDate = startdate,
                                TagName =TagnameDict[s[0].ToString()],
                                Tagval = float.Parse(string.IsNullOrEmpty(s[1].ToString())?"0f":s[1].ToString())
                            };
                            resultlist.Add(model);
                        }

                    }
                    else
                    {
                        foreach (var kv in TagnameDict)
                        {
                            var model = new NyModel { TagDate = startdate,TagName =kv.Value,Tagval =0f};
                            resultlist.Add(model);
                        }
                        
                    }
                }
               
              

            }

            return resultlist.ToList();
        }

        public static void CreateDate(ProgressBar pb, int num = 10000)
        {
            pb.Value = 0;
            pb.Maximum = num;
            for (int i = 0; i < num; i++)
            {
                Random r = new Random();
                int year = r.Next(2015, 2026);
                int month = r.Next(1, 13);
                int date = r.Next(1, 29);
                int hour = r.Next(0, 24);
                int min = r.Next(0, 60);
                DateTime dt = new DateTime(year, month, date, hour, min, 0);
                foreach (var key in TagnameDict.Keys)
                {
                    string cmd2 = "insert into FloatTable(TagName,Val,DateAndTime) values (@name,@val,@date)";
                    SqlParameter p1=new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = key
                    };
                    SqlParameter p2=new SqlParameter()
                    {
                        ParameterName = "@date",
                        Value = dt
                    };
                    SqlParameter p3=new SqlParameter()
                    {
                        ParameterName = "@val",
                        Value = (int)(r.NextDouble()*100)*100
                    };
                    SqlHelper.ExecteNonQueryText(cmd2, p1, p2, p3);
                }
            }
            pb.Value += 1;
            MessageBox.Show("OK!");
           
        }

       
        private static readonly Dictionary<string, string> TagnameDict = new Dictionary<string, string>()
        {
            {"[JSWS]AI_01", "压力1"},
            {"[JSWS]AI_02", "压力2"},
            {"[JSWS]FIT_01", "流量1"},
            {"[JSWS]FIT_02", "流量2"},
            {"[JSWS]FIT_03", "流量3"},
            {"[JSWS]FIT_04", "流量4"},
            {"[JSWS]FIT_05", "流量5"},
            {"[JSWS]FIT_06", "流量6"},
            {"[JSWS]FIT_07", "流量7"},
            {"[JSWS]FIT_08", "流量8"},
            {"[JSWS]LAS_03", "气量8"},
            {"[JSWS]LIT_01", "也为1"},
            {"[JSWS]LIT_02", "也为2"},
            {"[JSWS]LIT_03", "也为3"},
            {"[JSWS]LIT_04", "也为4"},
            {"[JSWS]LIT_05", "也为5"},
            {"[JSWS]LIT_06", "也为6"},
            {"[JSWS]LIT_07", "也为7"},

        };

    }

    public class NyModel
    {
        public string TagName;
        public DateTime TagDate;
        public float Tagval;
    }
}
