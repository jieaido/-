using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SharedLibrary;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“DTDataSet.FloatTable”中。您可以根据需要移动或删除它。
            //this.FloatTableTableAdapter.Fill(this.DTDataSet.FloatTable);

            //this.reportViewer1.RefreshReport();
           // this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var ds=new DataSet();
            //     var dt=new DataTable();
            // dt.Columns.Add("TagDate");
            // dt.Columns.Add("TagName");
            // dt.Columns.Add("TagVal");
            // var datasource = NyData.Getdata(2015, 8);
            // foreach (var source in datasource)
            // {
            //     DataRow dr = dt.NewRow();
            //     dr[0] = source.TagDate;  dr[1] = source.TagName;  dr[2] = source.Tagval;
            //     dt.Rows.Add(dr);
            // }
            // ds.Tables.Add(dt);
            //  var hh=  new ReportDataSource("Message",ds.Tables[0]);
            // var localreport = this.reportViewer1.LocalReport;
            // localreport.DataSources.Clear();
            // localreport.DataSources.Add(hh);
           
            var dt = new DataTable();
            dt.Columns.Add("TagDate",typeof(DateTime));
            dt.Columns.Add("TagName");
            dt.Columns.Add("TagVal",typeof(float));
            var datasource = NyData.Getdata(2015, 8);
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
            var localreport = this.reportViewer1.LocalReport;
            localreport.DataSources.Clear();
            localreport.DataSources.Add(hh);
           //localreport.SetParameters(new ReportParameter("rDate",new DateTime(2015,8,1).ToShortDateString()));

            this.reportViewer1.RefreshReport();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(textBox1.Text);
            NyData.CreateDate(num);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
