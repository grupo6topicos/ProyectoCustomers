<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserUI.aspx.cs" Inherits="Views.UserUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <form runat="server">
        <section id="zero" class="wrapper special">
            <div class="inner">
                <div class="features">
                    <div class="feature" id="type" runat="server">
                        <asp:Label ID="lbType" runat="server" Text="Tipo de Consulta"></asp:Label>
                        <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Text="Select Type" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Country" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Province" Value="2"></asp:ListItem>
                            <asp:ListItem Text="City" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </div>
                    <div class="feature" id="country" runat="server">
                        <asp:Label ID="lbCountry" runat="server" Text="Pais"></asp:Label>
                        <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        <br />
                    </div>
                    <div class="feature" id="province" runat="server">
                        <asp:Label ID="lbProvince" runat="server" Text="Provincia"></asp:Label>
                        <asp:DropDownList ID="ddlProvince" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        <br />
                    </div>
                    <div class="Feature" id="city" runat="server">
                        <asp:Label ID="lbCity" runat="server" Text="City"></asp:Label>
                        <asp:DropDownList ID="ddlCity" runat="server" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        <br />
                    </div>
                </div>
            </div>
        </section>

        <section id="one" class="wrapper special">
                <header class="inner">
						<h2 id="title" runat="server">Lorem ipsum feugiat tempus</h2>
					</header>
                
        </section>
        <div class="grid-form">
                    <asp:GridView ID="gvCustomers" runat="server" AllowPaging="true" PageSize="20" OnPageIndexChanging="grdView_PageIndexChanging"></asp:GridView>
        </div>
    </form>
</asp:Content>

