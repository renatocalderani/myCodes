<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UsageReport.WebsiteClearLayout._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
            </hgroup>
            <p>
                Welcome to #### Report Services Website - Developed to create reports of passengers processed on self-checking kiosks
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Please select the report that you would like from the below options:</h3>
    <ol class="round">
        <li class="one">
            <h5>Airline 1</h5>
            <%--<asp:Image ID="imgNZlogo" runat="server" ImageUrl="~/Images/NZlogo.jpg" Height="70px" Width="70px"/>--%>
           This report will bring to you the usage of Airport Kiosks for Airline 1 (Self-Service checking process).
            <a href="Report.aspx?Airline=NZ">Open Airline 1 Report Page</a>
        </li>
        <li class="two">
            <h5>Airline 2</h5>
            <%--<asp:Image ID="imgQFlogo" runat="server" ImageUrl="~/Images/QANTASlogo.png"/>--%>
            This report will bring to you the usage of Airport Kiosks for Airline 2 (Self-Service checking process).
            <a href="Report.aspx?Airline=QF">Open Airline 2 Report Page</a>
        </li>
    </ol>
</asp:Content>