using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DbHandlingWebApp
{
    public partial class FrmMemoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            using (var conn = new SqlConnection(connString))
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand("ListMemo", conn); // DB테이블(저장프로시저)에 ListMemo가 있음
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Memos");

                GrvMemoList.DataSource = ds;
                GrvMemoList.DataBind();
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

            using (var conn = new SqlConnection(connString))
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand("SearchMemo", conn); // DB테이블(저장프로시저)에 SearchMemo가 있음
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchField", CboSearch.SelectedValue); // Name, Title
                cmd.Parameters.AddWithValue("@SearchQuery", TxtSearch.Text.Replace("--",""));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Memos");

                GrvMemoList.DataSource = ds.Tables[0].DefaultView;
                GrvMemoList.DataBind();
            }

        }
    }
}