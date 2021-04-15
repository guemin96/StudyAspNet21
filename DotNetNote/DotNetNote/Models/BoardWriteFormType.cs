using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetNote.Models
{
    public enum BoardWriteFormType //enum 열거형
    {
        Write,  //글쓰기 모드
        Modify,  //글수정 모드
        Reply  //댓글 모드
    }
    public enum ContentEncodingType
    {
        Text, //일반텍스
        Html, //HTML입력모드
        Mixed //HTML입력 + 엔터키 모드
    }
}