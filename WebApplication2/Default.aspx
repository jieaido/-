<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        
        
        <asp:Panel ID="Panel1" runat="server" Height="39px" style="margin-top: 0px; background-color: #3399FF">
            <div style="text-align: center">
                <h1 style="font-size: xx-large; color: #FF6666">报表系统</h1>
            </div>
        </asp:Panel>
         <asp:Panel ID="Panel2" runat="server" Height="39px" style="margin-top: 0px; background-color: #3399FF">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Height="30px" style="margin-left: 200px" Width="91px" />
             <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="25px" style="margin-left: 200px; font-size: medium;" Width="171px">
                 <asp:ListItem>1</asp:ListItem>
                 <asp:ListItem>2</asp:ListItem>
                 <asp:ListItem>3</asp:ListItem>
                 <asp:ListItem>4</asp:ListItem>
                 <asp:ListItem>5</asp:ListItem>
                 <asp:ListItem>6</asp:ListItem>
                 <asp:ListItem>7</asp:ListItem>
                 <asp:ListItem>8</asp:ListItem>
                 <asp:ListItem>9</asp:ListItem>
                 <asp:ListItem>10</asp:ListItem>
                 <asp:ListItem>11</asp:ListItem>
                 <asp:ListItem>12</asp:ListItem>
             </asp:DropDownList>
             <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Height="25px" style="margin-left: 200px; font-size: medium;" Width="171px">
                 <asp:ListItem>2015</asp:ListItem>
                 <asp:ListItem>2016</asp:ListItem>
                 <asp:ListItem>2017</asp:ListItem>
                 <asp:ListItem>2018</asp:ListItem>
                 <asp:ListItem>2019</asp:ListItem>
                 <asp:ListItem>2020</asp:ListItem>
                 <asp:ListItem>2021</asp:ListItem>
                 <asp:ListItem>2022</asp:ListItem>
                 <asp:ListItem>2023</asp:ListItem>
                 <asp:ListItem>2024</asp:ListItem>
                 <asp:ListItem>2025</asp:ListItem>
                 <asp:ListItem>2026</asp:ListItem>
             </asp:DropDownList>
             <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        </asp:Panel>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="860px" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="Report3.rdlc">
                <DataSources>
                    <%--<rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Message" />--%>
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
       <%-- <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="WebApplication1.DataSet1TableAdapters."></asp:ObjectDataSource>--%>
    </div>

</asp:Content>
