using Employee.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select * from Department";
            DataTable dataTable = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))
            
                using (var cmd = new SqlCommand(query, con)) 

                using (var dataAdapter = new SqlDataAdapter(cmd))
                {
                cmd.CommandType = CommandType.Text;
                dataAdapter.Fill(dataTable);
                }
            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
            
        }
        public string Post(DepartmentModel department)
        {
            try
            {
                string query = @"insert into Department([DepartmentName]) values ('" + department.DepartmentName + @"')";
                DataTable dataTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))

                using (var cmd = new SqlCommand(query, con))

                using (var dataAdapter = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    dataAdapter.Fill(dataTable);
                }
                return "Added Successfully";
            }
            catch
            {
                return "Failed";
            }
        }
        public string Put(DepartmentModel department)
        {
            try
            {
                string query = @"update Department set DepartmentName='" + department.DepartmentName + @"'where DepartmentId="+department.DepartmentId+@"";
                DataTable dataTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))

                using (var cmd = new SqlCommand(query, con))

                using (var dataAdapter = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    dataAdapter.Fill(dataTable);
                }
                return "Updating Successfully";
            }
            catch
            {
                return "Failed";
            }
        }
        public string Delete(int id)
        {
            try
            {
                string query = @"delete from Department where DepartmentId=" + id+ @"";
                DataTable dataTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))

                using (var cmd = new SqlCommand(query, con))

                using (var dataAdapter = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    dataAdapter.Fill(dataTable);
                }
                return "Deleting Successfully";
            }
            catch
            {
                return "Failed";
            }
        }
       
    }
}