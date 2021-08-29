using Student_curd.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Student_curd.Controllers
{
    public class CStudentController : ApiController
    {
        [HttpGet]
        [Route("api/gettblStudent")]
         public  List<MStudent> GetMStudent()
        {
            List<MStudent> students = new List<MStudent>();
            MStudent mStudentdata = new MStudent();
            SqlConnection con = new SqlConnection("data source=.; database=Curd;integrated security=SSPI");
            try { 
            con.Open();
            string query = "select * from tblStudent";
            SqlCommand cm = new SqlCommand(query, con);
            SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    mStudentdata = new MStudent();
                    mStudentdata.Id = Convert.ToInt32(dr["Id"]);
                    mStudentdata.Sname = Convert.ToString(dr["Sname"]);
                    mStudentdata.Sphoneno = Convert.ToString(dr["Sphoneno"]);
                    mStudentdata.Semail = Convert.ToString(dr["Semail"]);
                    mStudentdata.Sbranch = Convert.ToString(dr["Sbranch"]);
                    students.Add(mStudentdata);
                }


            }
            catch(Exception ex)
            {
               
            }
            return students;
          }




        // GET: api/CStudent
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CStudent/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CStudent
        [HttpPost]
        [Route("api/insertStudent")]
        public string insertMStudent([FromBody] MStudent student)
        {
           
            try
            {
                SqlConnection con = new SqlConnection("data source=.; database=Curd;integrated security=SSPI");
                con.Open();
                SqlCommand cm = new SqlCommand("insert into tblStudent values(" + student.Id + ", '" + student.Sname + "'," +
                    "'" + student.Sphoneno + "','" + student.Semail + "','" + student.Sbranch + "');",con);
                SqlDataReader dr = cm.ExecuteReader(); 
            }
            catch(Exception ex)
            {

            }
            return " insert data sucessfully";
        }

        // PUT: api/CStudent/5
        [HttpPut]
        [Route("api/UpdatetblStudent")] 
        public  string UpdateStudent(int Id,[FromBody] MStudent stdata)
        {
            try
            {
                SqlConnection con = new SqlConnection("data source=.; database=Curd;integrated security=SSPI");
                con.Open();
                SqlCommand cm = new SqlCommand("UpdateMStudent stdata set  Sname='" + stdata.Sname + "',Sphoneno='" + stdata.Sphoneno + "'," +
                    "Semail='" + stdata.Semail + "',Sbranch='" + stdata.Sbranch + "' where Id=3",con);
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {

            }
            return "data updated";
        }

        // DELETE: api/CStudent/5
        [HttpDelete]
        [Route("api/DeleteStudent")]
        public string MStudent(int Id)
        {
            try
            {
                SqlConnection con = new SqlConnection("data source=.; database=Curd;integrated security=SSPI");
                con.Open();
                string query = "delete from tblStudent where Id=" + Id + "";
                SqlCommand cm = new SqlCommand(query, con);
                SqlDataReader dr = cm.ExecuteReader();
            }
            catch(Exception ex)
            {

            }
            return "deleted";
        }
    }
}
