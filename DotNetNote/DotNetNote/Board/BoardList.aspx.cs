using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardList : System.Web.UI.Page
    {
        private DbRepository _repo;
        //검색모드 이면 true, 보통 false
        public bool SearchMode { get; set; }

        public int RecordCount = 0; //총 레코드 수
        public BoardList()
        {
            _repo = new DbRepository(); //SqlConnection 생성
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SearchMode)
            {
                RecordCount = _repo.GetCountAll();
            }

            LblTotalRecord.Text = $"Total Record : {RecordCount}";

            if (!Page.IsPostBack)
            {
                Displaydata();
            }
        }

        private void Displaydata()
        {
            if (!SearchMode)
            {
                GrvNotes.DataSource = _repo.GetAll(0);
            }
            GrvNotes.DataBind(); //데이터 바인딩 끝
        }
    }
}