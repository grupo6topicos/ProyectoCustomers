<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserUI.aspx.cs" Inherits="Views.UserUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <form runat="server">
        <div id="div_DDLType">

            <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Text="Select Type" Value="0"></asp:ListItem>
                <asp:ListItem Text="Country" Value="1"></asp:ListItem>
                <asp:ListItem Text="Province" Value="2"></asp:ListItem>
                <asp:ListItem Text="City" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div id="div_DDLCountry">
            <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <div id="div_DDLProvince">
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <div id="div_DDLCity">
            <asp:DropDownList ID="ddlCity" runat="server" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <div id="div_gv">
            <asp:GridView ID="gvCustomers" runat="server" AllowPaging="true" PageSize="20"></asp:GridView>
        </div>
    </form>
</asp:Content>

