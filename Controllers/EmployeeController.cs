using Employee.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select * from Employee";
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
        public string Post(EmployeeModel employee)
        {
            try
            {
                string query = @"insert into Employee([EmployeeName],[DepartmentName],[DateOfJoining],[PhotoFileName]) values ('"  +employee.EmployeeName + @"','"+ employee.DepartmentName + @"','" + employee.DateOfJoining.ToString()+ @"','"+employee.PhoteFileName+@"')";
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
        public string Put(EmployeeModel employee)
        {
            try
            {
                string query = @"update Employee set DepartmentName='" + employee.DepartmentName + "',EmployeeName = '" + employee.EmployeeName + "',DateOfJoining= '" + employee.DateOfJoining + @"'where EmployeeId=" + employee.EmployeeId + @"";
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
                string query = @"delete from Employee where EmployeeId=" + id + @"";
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
        [System.Web.Http.Route("api/Employee/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string FileName = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + FileName);
                postedFile.SaveAs(physicalPath);
                return FileName;
            }
            catch (Exception)
            {
                return "anonymous.png";
            }
        }
        [System.Web.Http.Route("api/Employee/Departments")]
        public HttpResponseMessage GetDepList() 
        {
            string query = @"select DepartmentName from Department";
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
    }
}