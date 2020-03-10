<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SimpleQuery.aspx.cs" Inherits="WebAppFSIS.ExercisePages.SimpleQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Simple Query by Primary Key</h1>
    <div class="row">
        <div class="col-md-6">
            <div class="offset-1">
                <asp:Label runat="server" Text="Enter a Team ID:"></asp:Label>&nbsp;&nbsp;
                <asp:TextBox ID="TeamIDArg" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="Fetch" runat="server" Text="Fetch" OnClick="Fetch_Click" />
                <br /><br />
                <asp:Label ID="MessageLabel" runat="server"></asp:Label>
            </div>
        </div>
        <div class="col-md-6">
            <asp:Label runat="server" Text="Team ID"></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="TeamID" runat="server"></asp:Label>
            <br />
            <asp:Label runat="server" Team="Description:"></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="TeamDescription" runat="server" ></asp:Label>
        </div>
    </div>
</asp:Content>
