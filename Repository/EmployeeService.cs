using MegaMindsTask.DAL;
using MegaMindsTask.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;

namespace MegaMindsTask.Repository
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDataAccessLayer _dal;
        public EmployeeService(IDataAccessLayer dal)
        {
             _dal = dal;
        }
        public int Add(Employee emp)
        {
            int i = 0;
            string sqlquery = "Proc_SaveEmployee";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ID",emp.ID),
                new SqlParameter("@Name",emp.Name),
                new SqlParameter("@Email",emp.Email),
                new SqlParameter("@Phone_Number",emp.PhoneNumber),
                new SqlParameter("@Address",emp.Address),
                new SqlParameter("@State",emp.State),
                new SqlParameter("@City", emp.City),
                new SqlParameter("@Agree",emp.Agree)
            };
            i=_dal.Execute(sqlquery, parameters);
            return i;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> employees = new List<Employee>();
            DataTable dt=new DataTable();
            string sqlquery = "Proc_GetEmployee";
            dt=_dal.Get(sqlquery);
            foreach(DataRow dr in dt.Rows)
            {
                employees.Add(new Employee{
                    ID = dr["ID"] is DBNull ? 0 : Convert.ToInt32(dr["ID"]),
                    Name = dr["Name"] is DBNull ? string.Empty : dr["Name"].ToString(),
                    Email = dr["Email"] is DBNull ? string.Empty : dr["Email"].ToString(),
                    PhoneNumber = dr["Phone_Number"] is DBNull ? string.Empty : dr["Phone_Number"].ToString(),
                    Address = dr["Address"] is DBNull ? string.Empty : dr["Address"].ToString(),
                    State = dr["State"] is DBNull ? string.Empty : dr["Address"].ToString(),
                    City = dr["City"] is DBNull ? string.Empty : dr["City"].ToString(),
                    Agree = dr["Agree"] is DBNull ? false : Convert.ToBoolean(dr["Agree"])
                });
            }
            return employees;
        }

        public Employee GetById(int id)
        {
            Employee emp = new Employee();
            string sqlquery = "Proc_GetEmployeeByID";
            SqlParameter[] param =
            {
                new SqlParameter("@ID",id)
            };
            DataTable dt = new DataTable();
            dt=_dal.Get(sqlquery, param);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    emp.ID = dr["ID"] is DBNull ? 0 : Convert.ToInt32(dr["ID"]);
                    emp.Name = dr["Name"] is DBNull ? string.Empty : dr["Name"].ToString();
                    emp.Email = dr["Email"] is DBNull ? string.Empty : dr["Email"].ToString();
                    emp.PhoneNumber = dr["Phone_Number"] is DBNull ? string.Empty : dr["Phone_Number"].ToString();
                    emp.Address = dr["Address"] is DBNull ? string.Empty : dr["Address"].ToString();
                    emp.State = dr["State"] is DBNull ? string.Empty : dr["State"].ToString();
                    emp.City = dr["City"] is DBNull ? string.Empty : dr["City"].ToString();
                    emp.Agree = dr["Agree"] is DBNull ? false : Convert.ToBoolean(dr["Agree"]);
                }
            }
            return emp;
        }
        public int Delete(int Id)
        {
            int i = 0;
            string sqlQuery = "Proc_Delete";
            SqlParameter[] param =
            {
                new SqlParameter("@ID",Id)
            };
            i = _dal.Execute(sqlQuery, param);
            return i;
        }
    }
}
