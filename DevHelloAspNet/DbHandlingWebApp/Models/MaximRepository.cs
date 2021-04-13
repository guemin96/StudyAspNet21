using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DbHandlingWebApp.Models
{
    public class MaximRepository
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
        
        //입력
        public Maxims AddMaxims(Maxims maxims)
        {
            string query = @"INSERT INTO Maxims (Name, Contents, RegDate) Values (@Name,@Contents,getdate());
                             SELECT CASE(SCOPE_IDENTITY() AS INT);";
            var id = db.Query<int>(query, maxims).Single();
            maxims.Id = id;
            return maxims;
        }
        //조회

        //수정

        //삭제
    }
}