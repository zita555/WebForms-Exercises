<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Ex09Add.aspx.cs" Inherits="WebAppFSIS.ExercisePages.Ex09Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exercise 10 - Add a Player</h1>
    <asp:DataList ID="Message" runat="server">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>
    <div class="row">
        <%-- Validation --%>
        <div class="col-md-12 text-left">
            <%-- Player ID --%>
            <%--<asp:RequiredFieldValidator ID="RequiredPlayerID" runat="server"
                ErrorMessage="Player ID is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="PlayerID">
            </asp:RequiredFieldValidator>
            <asp:CompareValidator ID="ComparePlayerID" runat="server"
                ErrorMessage="Player ID must be a positive integer" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="PlayerID" Type="Integer" ValueToCompare ="0" Operator="GreaterThanEqual">
            </asp:CompareValidator>--%>

            <%-- First Name --%>
            <asp:RequiredFieldValidator ID="RequiredFirstName" runat="server"
                ErrorMessage="First name is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="FirstName"> 
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegExFirstName" runat="server"
                ErrorMessage="First name can be at most 50 characters" Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="FirstName" ValidationExpression="[a-zA-Z]{0,50}">
            </asp:RegularExpressionValidator>

            <%-- Last Name --%>
            <asp:RequiredFieldValidator ID="RequiredLastName" runat="server"
                ErrorMessage="Last name is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="LastName"> 
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegExLastName" runat="server"
                ErrorMessage="Last name can be at most 50 characters" Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="LastName" ValidationExpression="^[a-zA-Z]{0,50}$">
            </asp:RegularExpressionValidator>
            
            <%-- Age --%>
            <asp:RequiredFieldValidator ID="RequiredAge" runat="server"
                ErrorMessage="Age is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="Age">
            </asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeAge" runat="server"
                ErrorMessage="Age must be between 6 and 14" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="Age" MinimumValue="6" MaximumValue="14" Type="Integer">
            </asp:RangeValidator>

            <%-- Gender --%>
            <asp:RequiredFieldValidator ID="RequiredGender" runat="server"
                ErrorMessage="Gender is Required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="Gender">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegExGender" runat="server"
                ErrorMessage="Gender can only be a single character, F or M." Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="Gender" ValidationExpression="[F,f,M,m]{1}">
            </asp:RegularExpressionValidator>

            <%-- Alberta Health Care Number --%>
            <asp:RequiredFieldValidator ID="RequiredAlbertaHealthCareNumber" runat="server"
                ErrorMessage="Alberta Health Care Number is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="AlbertaHealthCareNumber">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegExAlbertaHealthCareNumber" runat="server"
                ErrorMessage="Alberta Health Care Number must be 10 digits and cannot begin with a 0" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="AlbertaHealthCareNumber" ValidationExpression="[1-9]{1}[0-9]{9}">
            </asp:RegularExpressionValidator>

            <%-- Medical Alert Details --%>
            <%--<asp:RegularExpressionValidator ID="RegExMedicalAlertDetails" runat="server"
                ErrorMessage="Medical Alert Details can be at most 250 characters" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="MedicalAlertDetails" ValidationExpression="[a-zA-Z]{0,250}">
            </asp:RegularExpressionValidator>--%>

            <%-- Team --%>
            <asp:RangeValidator ID="RangeTeamList" runat="server"
                ErrorMessage="A team must be selected" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="TeamList" MinimumValue="1" MaximumValue="2147483647" Type="Integer">
            </asp:RangeValidator>

            <%-- Guardian --%>
            <asp:RangeValidator ID="RangeGuardianList" runat="server"
                ErrorMessage="A guardian must be selected" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="GuardianList" MinimumValue="1" MaximumValue="2147483647" Type="Integer">
            </asp:RangeValidator>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                HeaderText="Address the following concerns with your entered data." />
        </div>
    </div>

    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"
                     AssociatedControlID="FirstName"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"
                     AssociatedControlID="LastName"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="AgeLabel" runat="server" Text="Age"
                     AssociatedControlID="Age"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="Age" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="GenderLabel" runat="server" Text="Gender"
                     AssociatedControlID="Gender"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="Gender" runat="server" MaxLength="1" ></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                <asp:Label ID="TeamListLabel" runat="server" Text="Team"
                     AssociatedControlID="TeamList">
                </asp:Label>
        </div>
        <div class="col-md-8 text-left">
                <asp:DropDownList ID="TeamList" runat="server" Width="350px" >
                </asp:DropDownList>
            <asp:Button ID="LookUpButton" Text="Look Up" runat="server" OnClick="LookUp_Click" CausesValidation="false"/> 
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                <asp:Label ID="GuardianListLabel" runat="server" Text="Guardian"
                     AssociatedControlID="GuardianList">
                </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:DropDownList ID="GuardianList" runat="server" Width="350px" >
                </asp:DropDownList> 
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="AlbertaHealthCareNumberLabel" runat="server" Text="Alberta Health Care Number"
                     AssociatedControlID="AlbertaHealthCareNumber">
                  </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="AlbertaHealthCareNumber" runat="server"> 
                </asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="MedicalAlertDetailsLabel" runat="server" Text="Medical Alert Details"
                     AssociatedControlID="MedicalAlertDetails">
                  </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="MedicalAlertDetails" runat="server"> 
                </asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-6 text-left">
            <asp:Button ID="BackButton" runat="server" Text="Back" CausesValidation="false" OnClick="Back_Click" />&nbsp;&nbsp;
            <asp:Button ID="ClearButton" runat="server" OnClick="Clear_Click" Text="Clear" CausesValidation="false"/>&nbsp;&nbsp;
            <asp:Button ID="AddButton" runat="server" OnClick="Add_Click" Text="Add"/>&nbsp;&nbsp;            
        </div>
    </div>

    <br />
    <div class="offset-2 col-md-6">
    <asp:Label ID="PlayerListLabel" runat="server" AssociatedControlID="PlayerList"></asp:Label>
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
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
