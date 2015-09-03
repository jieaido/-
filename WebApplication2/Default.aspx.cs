using System;
using System.Data;
using System.IO;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using SharedLibrary;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(DropDownList2.SelectedValue);
            int month=Convert.ToInt32(DropDownList1.SelectedValue);
            var dt = new DataTable();
            dt.Columns.Add("TagDate", typeof(DateTime));
            dt.Columns.Add("TagName");
            dt.Columns.Add("TagVal", typeof(float));
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
            var localreport = this.ReportViewer1.LocalReport;
            localreport.DataSources.Clear();
            localreport.DataSources.Add(hh);
            //localreport.SetParameters(new ReportParameter("rDate",new DateTime(2015,8,1).ToShortDateString()));

            localreport.Refresh();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Microsoft.Reporting.WebForms.Warning[] Warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string fileNameExtension;
            var localreport = this.ReportViewer1.LocalReport;
            string deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";

            
            if (localreport.DataSources.Count==0)
            {
                try
                {
                    byte[] bs = localreport.Render("Excel", deviceInfo, out mimeType, out encoding, out fileNameExtension,
                out streamids, out Warnings);
                    bs = localreport.Render("Excel");
                    var di = Directory.CreateDirectory(@"d:\2005\");
                    using (FileStream fs = new FileStream(di.FullName + DateTime.Now.ToString("D") + ".xls", FileMode.Create))
                    {
                        fs.Write(bs, 0, bs.Length);
                        fs.Close();
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }
         
        }
    }
}