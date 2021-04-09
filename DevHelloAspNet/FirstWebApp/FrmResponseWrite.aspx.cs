using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    public partial class FrmResponseWrite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("안녕하세요.<br />");
        }

        protected void BtnMessage_Click(object sender, EventArgs e)
        {
            Response.Write("<p style='color:blue;'>반갑습니다.</p>");
            Response.Write("<span style='color:blue;'>p와 span의 차이를 알겠지?.</span>");
            //span은 딱 붙어서 나오는 반면 p는 paragrape라는 말처럼 위아래로 한칸씩 띄어져 나옴
        }

        protected void BtnJs_Click(object sender, EventArgs e)
        {
            string strScript = @"<script language = 'javascript'>
                                  window.alert('안녕하세요!');
                                 </script>";
            Response.Write(strScript);
                                    
        }

        protected void BtnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.naver.com");
        }
    }
}