using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
