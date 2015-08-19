using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views
{
    public partial class UserUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlType.SelectedValue.Trim())
            {
                case "1":
                    LoadCountry();
                    break;
                case "2":
                    LoadCity();
                    break;
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadCountry()
        {

        }

        private void LoadCity()
        {

        }
    }
}