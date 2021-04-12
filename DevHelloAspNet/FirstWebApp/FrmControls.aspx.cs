using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    public partial class FrmControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LsbHobby.Items.Add("농구");
            LsbHobby.Items.Add("배구");
            LsbHobby.Items.Add("야구");

            CboPhoneNum.Items.Add("017");
            CboPhoneNum.Items.Add("016");
            CboPhoneNum.Items.Add("015");
            if (!Page.IsPostBack)
            {
                CtlHidden.Value = DateTime.Now.ToShortTimeString();
            }
        }

        protected void BtnChange_Click(object sender, EventArgs e)
        {
            if (ImgChange.ImageUrl== "~/Images/ASP-NET-Banners-01.png")
            {
                ImgChange.ImageUrl = "~/Images/ASP-NET-Banners-02.png";
            }
            else
            {
                ImgChange.ImageUrl = "~/Images/ASP-NET-Banners-01.png";
            }
        }

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            Response.Write(CtlHidden.Value);
        }
    }
}