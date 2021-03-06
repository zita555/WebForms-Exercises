﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ex05.aspx.cs" Inherits="WebAppFSIS.ExercisePages.Ex05" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exercise 05</h1>
    <br />
    <div class="row">
        <div class="col-md-6">
            <div>
                <asp:Label runat="server" Text="Enter a Team ID:"></asp:Label>&nbsp;&nbsp;
                <asp:TextBox ID="TeamIDArg" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="Fetch" runat="server" Text="Fetch" OnClick="Fetch_Click" />
                <br /><br />
                <asp:Label ID="MessageLabel" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <div class="col-md-6">
            <asp:Label runat="server" Text="Team ID: "></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="TeamID" runat="server"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Team Name:"></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="TeamDescription" runat="server" ></asp:Label>
        </div>
    </div>
</asp:Content>

