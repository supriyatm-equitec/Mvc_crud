using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

namespace EmployeeCrud.Models
{
    public class EmpDb
    {
        public SqlConnection con;
       private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            con = new SqlConnection(constr);
        }



        //show data in table
        public List<EmpModel> GetAllEmployees()
        {
            
                connection();
                con.Open();
                IList<EmpModel> EmpList = SqlMapper.Query<EmpModel>(con, "GetEmployees").ToList();
                con.Close();
                return EmpList.ToList();
            
}

        //add new employees

        public void AddEmp(EmpModel emp)
        {
            connection();
            con.Open();
            con.Execute("INSERT INTO Employeetbl (Name, Age, Mobile_no, City) VALUES (@Name, @Age, @Mobile_no, @City)", emp);
            con.Close();
        }


        //To Update Employee details      
        public void UpdateEmployee(EmpModel objUpdate)
        {
            try
            {
                connection();
                con.Open();
                con.Execute("UpdateEmpDetails", objUpdate, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

        //delete data
        public bool DeleteEmployee(int Id)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", Id);
            connection();
            con.Open();
            con.Execute("DeleteEmpById", param, commandType: CommandType.StoredProcedure);
            con.Close();
            return true;
        }


    }
}