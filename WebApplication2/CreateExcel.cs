using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Security.Policy;
using System.Text;
using Microsoft.Reporting.WebForms;
using Quartz;

namespace SharedLibrary
{
    public class CreateExcel:IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var path = Createpath(DateTime.Now.Year, DateTime.Now.Month);
            if (!DirExist(DateTime.Now.Year,DateTime.Now.Month))
            {
                Directory.CreateDirectory(path);
            }
            var localreport = CreateLocalReport(DateTime.Now.Year, DateTime.Now.Month);
            ReportToExcel(localreport,path);
        }
        /// <summary>
        /// 导出成为excel
        /// </summary>
        /// <param name="localreport">报表</param>
        /// <param name="path">路径</param>
        private static void ReportToExcel(LocalReport localreport,string path)
        {
            if (localreport.DataSources.Count == 0) return;

            //Warning[] warnings;
            //string[] streamids;
            //string mimeType;
            //string encoding;
            //string fileNameExtension;
            //byte[] bs = localreport.Render("Excel", deviceInfo, out mimeType, out encoding, out fileNameExtension,
            //    out streamids, out warnings);
            
                localreport.ReportPath = @"C:\Users\jieai\Desktop\南阳报表工程\WindowsFormsApplication1\WebApplication2\Report3.rdlc";
                var bs = localreport.Render("Excel");
                
                var di = Directory.CreateDirectory(path);
                using (FileStream fs = new FileStream(path + DateTime.Now.ToString("D") + ".xls", FileMode.Create))
                {
                    fs.Write(bs, 0, bs.Length);
                    fs.Close();
                }
            }
            
       
        /// <summary>
        /// 填充本地报表
        /// </summary>
        /// <returns>根据时间填充一个新报表</returns>
        private static LocalReport CreateLocalReport(int year,int month )
        {
            var dt = new DataTable();
            dt.Columns.Add("TagDate", typeof (DateTime));
            dt.Columns.Add("TagName");
            dt.Columns.Add("TagVal", typeof (float));
            var datasource = NyData.Getdata(year, month);
            foreach (var source in datasource)
            {
                DataRow dr = dt.NewRow();
                dr[0] = source.TagDate;
                dr[1] = source.TagName;
                // dr[2] = string.IsNullOrEmpty(source.Tagval)?"0":source.Tagval;
                dr[2] = source.Tagval;
                dt.Rows.Add(dr);
            }

            var hh = new ReportDataSource("Message", dt);
            var localreport = new LocalReport();
            localreport.DataSources.Clear();
            localreport.DataSources.Add(hh);
            return localreport;
        }

        public bool DirExist(int year,int month)
        {
            return Directory.Exists(Createpath(year,month));
        }

        public string Createpath(int year, int month)
        {
            return  @"d:\报表\" + year + @"\" + month + @"\";
        }
    }
}
