<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArticleProcessorWebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


     <asp:Panel ID="serviceTitle" runat="server" HorizontalAlign="Center">
        <h1><b>Web Application Portotype</b></h1>
    </asp:Panel>

    <asp:Panel runat="server" ID="serviceInfo" CssClass="jumbotron" BorderWidth="3">
        <h3>Application Information</h3>
        <hr />
        <h4>This Web Application has been implemented for CSE445 - Homework 5. This application takes 3 of the Web Services developed as part of
            Homework 3, and utilizes them in a combined, web-based, online-article processor. The selected applications will take a web URL, and return to the user
            a series of information about the article's referenced links, top [10] content words, and sentences using a user-specified word.
        </h4>
    </asp:Panel>

    <asp:Panel runat="server" ID="input" CssClass="jumbotron" BorderWidth="3">
        <h3>Article & Search Term Input:</h3>
        <hr />
        <asp:Label Text="Enter URL Here:   " runat="server" />
        <asp:TextBox ID="urlInput" runat="server" width="800"/>
        <br />
        <br />
        <asp:Label Text="Enter Sentence Search Term Here:   " runat="server" />
        <asp:TextBox ID="searchInput" runat="server" Width="800" />
        <br />
        <br />
        <asp:Button Text="Compute Information" runat="server" />
    </asp:Panel>

    <asp:Panel runat="server" ID="viewStats" CssClass="jumbotron" BorderWidth="3">
        <h3>View Information</h3>
        <hr />
        <asp:Button ID="viewWords" Text="View Content Words" runat="server" HorizontalAlign="Center" />
        <br />
        <br />
        <asp:Button ID="viewSentences" Text="View Searched Sentences" runat="server" HorizontalAlign="Center" />
        <br />
        <br />
        <asp:Button ID="viewLinks" Text="View Referenced Links" runat="server" HorizontalAlign="Center" />
    </asp:Panel>


</asp:Content>
