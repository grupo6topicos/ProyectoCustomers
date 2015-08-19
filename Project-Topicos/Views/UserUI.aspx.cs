using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using System.Data;

namespace Views
{
    public partial class UserUI : System.Web.UI.Page
    {
        CustomerControllers cm = new CustomerControllers();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack){
                Initial_Load();
                StartForm();
            }
                
            ClientScript.GetPostBackEventReference(this, String.Empty);
            MethodClick(Request.Form["__EVENTTARGET"]);
        }

        private void MethodClick(string click)
        {
            switch (click)
            {
                case "ddlType_SelectedIndexChanged":
                    ddlType_SelectedIndexChanged(this, new EventArgs());
                    break;
                case "ddlCountry_SelectedIndexChanged":
                    ddlCountry_SelectedIndexChanged(this, new EventArgs());
                    break;
                case "ddlProvince_SelectedIndexChanged":
                    ddlProvince_SelectedIndexChanged(this, new EventArgs());
                    break;
                case "ddlCity_SelectedIndexChanged":
                    ddlCity_SelectedIndexChanged(this, new EventArgs());
                    break;
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Initial_Load();
            switch (ddlType.SelectedValue.Trim())
            {
                case "1":
                    LoadCountry();
                    break;
                case "2":
                    LoadProvince();
                    break;
                case "3":
                    LoadCity();
                    break;
                case "0":
                    StartForm();
                    break;
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedValue.Trim().Equals("Selected"))
            {
                Initial_Load();
            }
            else
            {
                title.InnerHtml = "Customers from " + ddlCountry.SelectedValue.Trim() + " Country";
                gvCustomers.DataSource = cm.ListCustomers_Country(ddlCountry.SelectedValue.Trim());
                gvCustomers.PageIndex = 0;
                gvCustomers.DataBind();
            }
        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvince.SelectedValue.Trim().Equals("Selected"))
            {
                Initial_Load();
            }
            else
            {
                title.InnerHtml = "Customers from " + ddlProvince.SelectedValue.Trim() + " Province";
                gvCustomers.DataSource = cm.ListCustomers_Province(ddlProvince.SelectedValue.Trim());
                gvCustomers.PageIndex = 0;
                gvCustomers.DataBind();
            }
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCity.SelectedValue.Trim().Equals("Selected"))
            {
                Initial_Load();
            }
            else
            {
                title.InnerHtml = "Customers from " + ddlCity.SelectedValue.Trim() + " City";
                gvCustomers.DataSource = cm.ListCustomers_City(ddlCity.SelectedValue.Trim());
                gvCustomers.PageIndex = 0;
                gvCustomers.DataBind();
                
            }
        }

        private void LoadCountry()
        {
            province.Visible = false;
            city.Visible = false;
            country.Visible = true;
            fillDDL(ddlCountry, cm.ListCountries(), "Country", "Country");
        }

        private void LoadCity()
        {
            country.Visible = false;
            province.Visible = false;
            city.Visible = true;
            fillDDL(ddlCity, cm.ListCities(), "City", "City");
        }

        private void LoadProvince()
        {
            province.Visible = true;
            country.Visible = false;
            city.Visible = false;
            fillDDL(ddlProvince, cm.ListProvinces(), "Province", "Province");
        }

        private void StartForm()
        {
            province.Visible = false;
            country.Visible = false;
            city.Visible = false;
        }

        private void Initial_Load()
        {
            try
            {
                title.InnerHtml = "Full load of Customers";
                gvCustomers.DataSource = null;
                gvCustomers.DataSource = cm.ListCustomers();
                gvCustomers.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void fillDDL(DropDownList ddl, DataTable list, String field, String value)
        {
            ddl.DataSource = list;
            ddl.DataTextField = field;
            ddl.DataValueField = value;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "Select"));
        }

        protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            switch (ddlType.SelectedValue.Trim())
            {
                case "1":
                    if (!ddlCountry.SelectedValue.Trim().Equals("Selected"))
                    {
                        title.InnerHtml = "Customers from " + ddlCountry.SelectedValue.Trim() + " Country";
                        gvCustomers.DataSource = cm.ListCustomers_Country(ddlCountry.SelectedValue.Trim());
                        gvCustomers.DataBind();
                    }
                    else
                        Initial_Load();
                    break;
                case "2":
                    if(!ddlProvince.SelectedValue.Trim().Equals("Selected")){
                        title.InnerHtml = "Customers from " + ddlProvince.SelectedValue.Trim() + " Province";
                        gvCustomers.DataSource = cm.ListCustomers_Province(ddlProvince.SelectedValue.Trim());
                        gvCustomers.DataBind();
                    }
                    else
                        Initial_Load();
                    break;
                case "3":
                     if(!ddlCity.SelectedValue.Trim().Equals("Selected"))
                     {
                         title.InnerHtml = "Customers from " + ddlCity.SelectedValue.Trim() + " City";
                         gvCustomers.DataSource = cm.ListCustomers_City(ddlCity.SelectedValue.Trim());
                         gvCustomers.DataBind();
                     }
                     else
                         Initial_Load();
                    break;
                case "0":
                    StartForm();
                    Initial_Load();
                    break;
            }
            gvCustomers.PageIndex = e.NewPageIndex;
            gvCustomers.DataBind();
        }
    }
}