using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardWrite : System.Web.UI.Page
    {
        public BoardWriteFormType FormType { get; set; } = BoardWriteFormType.Write; //기본값 : 글쓰기
        private string _Id;//리스트에서 넘겨주는 번호
        //private string _Mode;//뷰에서 넘겨주는 모드값 // Edit, Reply 값

        private string _BaseDir = ""; //Gitrepository\StudyASPNET21\...Files
        private string _FileName = ""; //파일명
        private int _FileSize = 0; // 파일 사이즈
                                   

        protected void Page_Load(object sender, EventArgs e)
        {
            _Id = Request["Id"]; //GET,POST 모두 다 받음

            if (!Page.IsPostBack)
            {
                ViewState["Mode"] = Request["Mode"]; //Edit
                if (ViewState["Mode"].ToString() == "Edit") FormType = BoardWriteFormType.Modify;
                else if (ViewState["Mode"].ToString() == "Reply") FormType = BoardWriteFormType.Reply;
                else FormType = BoardWriteFormType.Write;

                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        LblTitleDescription.Text = "글 쓰기 - 다음 필드들을 입력하세요";
                        break;
                    case BoardWriteFormType.Modify:
                        LblTitleDescription.Text = "글 수정 - 아래 필드을을 수정하세요";
                        DisplayDataForModify();
                        break;
                    case BoardWriteFormType.Reply:
                        LblTitleDescription.Text = "글 답변 - 다음 필드들을 입력하세요";
                        DisplayDataForReply();
                        break;
                }
            }
        }

        

        private void DisplayDataForModify()
        {
            var repo = new DbRepository();
            Note note = repo.GetNoteById(Convert.ToInt32(_Id));
            txtName.Text = note.Name;
            txtEmail.Text = note.Email;
            txtHomepage.Text = note.Homepage;
            txtTitle.Text = note.Title;
            txtContent.Text = note.Content;
            //Encoding
            string encoding = note.Encoding;
            if (encoding == "Text") rdoEncoding.SelectedIndex = 0;
            else if (encoding == "Mixed") rdoEncoding.SelectedIndex = 2;
            else rdoEncoding.SelectedIndex = 1;
        }
        private void DisplayDataForReply()
        {
            var repo = new DbRepository();
            Note note = repo.GetNoteById(Convert.ToInt32(_Id));

            txtTitle.Text = $"답변 : {note.Title}";
            txtContent.Text = $"\n\n작성일 : {note.PostDate}, 작성자 : '{note.Name}'\n-----------------\n>" +
                $"{note.Content.Replace("\n", "\n>")}\n-------------------\n";
        }
        protected void chkUpload_CheckedChanged(object sender, EventArgs e)
        {
            pnlFile.Visible = !pnlFile.Visible;
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            if (IsImageTextcorrect())//보안코드가 맞는지 안맞는지 확인 절차
            {
                if (ViewState["Mode"].ToString() == "Edit") FormType = BoardWriteFormType.Modify;
                else if (ViewState["Mode"].ToString() == "Reply") FormType = BoardWriteFormType.Reply;
                else FormType = BoardWriteFormType.Write;
                //TODO : 파일업로드
                UploadFile();

                Note note = new Note();
                note.Id = Convert.ToInt32(_Id); //없으면 0
                note.Name = txtName.Text; //필수
                note.Email = txtEmail.Text; //필수
                note.Title = txtTitle.Text; //필수
                note.Homepage = txtHomepage.Text; 
                note.Content = txtContent.Text; //필수
                note.FileName = _FileName;
                note.FileSize = _FileSize;
                note.Password = txtPassword.Text;
                note.PostIp = Request.UserHostAddress;
                note.Encoding = rdoEncoding.SelectedValue; // text, Html, Mixed

                DbRepository repo = new DbRepository();

                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        repo.Add(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                    case BoardWriteFormType.Modify:
                        note.ModifyIp = Request.UserHostAddress;
                        //TODO : file 처리
                        note.FileName = ViewState["FileName"].ToString();
                        note.FileSize = Convert.ToInt32(ViewState["FileSize"]);
                        if (repo.UpdateNote(note) > 0) Response.Redirect($"BoardView.aspx?Id={_Id}");
                        else lblError.Text = "업데이트 실패, 암호를 확인하세요.";
                        break;
                    case BoardWriteFormType.Reply:
                        note.ParentNum = Convert.ToInt32(_Id);
                        repo.ReplyNote(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                    default:
                        repo.Add(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                }


            }
        }

        private void UploadFile()
        {
            _BaseDir = Server.MapPath("../Files");//D:\GitRepository\StudyAspNet21\DotNetNote\DotNetNote\Files
            _FileName = "";
            _FileSize = 0;

            if (txtFileName.PostedFile != null)
            {
                if (txtFileName.PostedFile.FileName.Trim().Length>0&&
                    txtFileName.PostedFile.ContentLength>0)
                {
                    if (FormType ==BoardWriteFormType.Modify)// 수정일 경우만
                    {
                        ViewState["FileName"] = Helpers.FileUtility.GetFileNameWithNumbering(_BaseDir, Path.GetFileName(txtFileName.PostedFile.FileName));
                        ViewState["FileSize"] = txtFileName.PostedFile.ContentLength;
                        //업로드
                        txtFileName.PostedFile.SaveAs(Path.Combine(_BaseDir, ViewState["FileName"].ToString()));
                    }
                    else//Write, Reply
                    {
                        _FileName = Helpers.FileUtility.GetFileNameWithNumbering(_BaseDir,Path.GetFileName(txtFileName.PostedFile.FileName));
                        _FileSize = txtFileName.PostedFile.ContentLength;
                        //업로드
                        txtFileName.PostedFile.SaveAs(Path.Combine(_BaseDir, _FileName));
                    }
                }
            }
        }

        private bool IsImageTextcorrect()
        {
            if (Page.User.Identity.IsAuthenticated) //이미 로그인
            {
                return true;
            }
            else
            {
                if (Session["ImageText"] != null)
                {
                    return (txtImageText.Text == Session["ImageText"].ToString());
                }
            }
            return false; //보안코드 일치하지 낳음

        }
    }
}
