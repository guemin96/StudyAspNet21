using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    public partial class FrmButton : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) Txtnum.Text = "0"; 
            /*최초 초기화 시켜주는 역할 ispostback=> 게시물이 처음 게시되었는지 다시 로드가 된것인지 
             여기서 다시 로드란 버튼을 클릭했을때 깜박거리면서 불러오는 현상을 말함
             즉 ispostback이 아닐 경우(!ispostback)라는 말은 다시 로드를 한 것이 아니라는 소리이기 때문에 
             게시물의 처음 게시했다는 말이 된다.*/
            
        }

        protected void BtnInc_Click(object sender, EventArgs e)
        {
            Txtnum.Text = $"{int.Parse(Txtnum.Text) + 1}";
        }

        protected void BtnDec_Click(object sender, EventArgs e)
        {
            Txtnum.Text = $"{int.Parse(Txtnum.Text) - 1}";

        }

        protected void BtnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.naver.com");
        }

        protected void BtnImage_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}