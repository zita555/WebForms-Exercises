<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ex06Custom.aspx.cs" Inherits="WebAppFSIS.ExercisePages.Ex06Custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exercise 06 Custom</h1>
    <br />
    <div>
        <asp:Label ID="TeamsLabel" runat="server" Text="Select a Team"></asp:Label>&nbsp;&nbsp;
        <asp:DropDownList ID="TeamList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="Fetch" runat="server" Text="Fetch" CausesValidation="false" OnClick="Fetch_Click" />
        <br /><br />
        <asp:Label ID="MessageLabel" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Panel id="TeamInfo" runat="server">
            <asp:Label runat="server" Text="Coach: "></asp:Label>&nbsp;&nbsp;
            <asp:Label id="Coach" runat="server"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Assistant Coach: "></asp:Label>&nbsp;&nbsp;
            <asp:Label id="AssistantCoach" runat="server"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Wins: "></asp:Label>&nbsp;&nbsp;
            <asp:Label id="Wins" runat="server"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Losses: "></asp:Label>&nbsp;&nbsp;
            <asp:Label id="Losses" runat="server"></asp:Label>
        </asp:Panel>
        <br />
        <asp:GridView ID="PlayerList" runat="server"
            AutoGenerateColumns="false"
            CssClass="table table-striped"
            GridLines="Horizontal"
            BorderStyle="None"
            AllowPaging="true"
            OnPageIndexChanging="PlayerList_PageIndexChanging"
            PageSize="5">

            <Columns>
                <asp:TemplateField HeaderText="Player ID" Visible="true">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="PlayerID" runat="server"
                            Text='<%# string.Format("{0}", Eval("PlayerID")) %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="First Name" Visible="true">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="FirstName" runat="server"
                            Text='<%# Eval("FirstName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name" Visible="true">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="LastName" runat="server"
                            Text='<%# Eval("LastName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Age" Visible="true">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="Age" runat="server"
                            Text='<%# string.Format("{0}", Eval("Age")) %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender" Visible="true">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="Gender" runat="server"
                            Text='<%# Eval("Gender") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Guardian ID" Visible="true">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="GuardianID" runat="server"
                            Text='<%# string.Format("{0}", Eval("GuardianID")) %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Alberta Health Care Number" Visible="true">
                    <itemstyle horizontalalign="Left" />
                    <itemtemplate>
                        <asp:Label ID="AlbertaHealthCareNumber" runat="server"
                            Text='<%# Eval("AlbertaHealthCareNumber") %>'>
                        </asp:Label>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Medical Alert Details" Visible="true">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="MedicalAlertDetails" runat="server"
                            Text='<%# Eval("MedicalAlertDetails") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
        <%-- Todo Custom Grid View --%>
    </div>
</asp:Content>

