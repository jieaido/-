using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

using Microsoft.Reporting.WebForms;

namespace WebApplication1
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
    }
}