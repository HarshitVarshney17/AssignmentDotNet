using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Assignment.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.DAL
{
    public class InsuranceDAL
    {
      string connectionString = "Server=BHAVNAWKS339;Database=Assignment;Trusted_Connection=True";  

       public bool AddInsurance(Property insur)
        {
            try
            {
                //int i = 0; int @out = 0;
                int res=0;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("pr_insert_Contract", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerName",insur.CustomerName);
                    cmd.Parameters.AddWithValue("@CustomerAddress", insur.Address);
                    cmd.Parameters.AddWithValue("@CustomerGender", insur.Gender);
                    cmd.Parameters.AddWithValue("@CustomerCountry",insur.CustomerCountry);
                    cmd.Parameters.AddWithValue("@CustomerDateofBirth", insur.DateofBirth);
                    cmd.Parameters.AddWithValue("@SaleDate", insur.SaleDate);
                    //cmd.Parameters.Add("@Out", SqlDbType.Char, 30);
                    //cmd.Parameters["@Out"].Direction = ParameterDirection.Output;
                    con.Open();
                   res= cmd.ExecuteNonQuery();
                  // @out = Convert.ToInt32(cmd.Parameters["@Out"].Value);

                }
                if (res > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
       public int DeleteInsurance(int id)
        {
            try
            {
                int i = 0;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("pr_delete_Contract", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    i = cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (i > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public  ActionResult<IEnumerable<ReturnInsuranceProperty>> GetAllInsurance()
        {
            try
            {
                List<ReturnInsuranceProperty> lstInsurance= new List<ReturnInsuranceProperty>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("pr_get_Contract", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ReturnInsuranceProperty property = new ReturnInsuranceProperty();

                        property.CustomerName = rdr["CustomerName"].ToString();
                        property.Address = rdr["CustomerAddress"].ToString();
                        property.DateofBirth = Convert.ToDateTime(rdr["CustomerDateofBirth"]);
                        property.Gender = rdr["CustomerGender"].ToString();
                        property.SaleDate = Convert.ToDateTime(rdr["SaleDate"]);
                        property.CustomerCountry = rdr["CustomerCountry"].ToString();
                        property.CoveragePlan = rdr["CoveragePlan"].ToString();
                        property.NetPrice = Convert.ToDouble(rdr["NetPrice"]);
                        lstInsurance.Add(property);
                    }
                    con.Close();
                }
                return lstInsurance;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
public bool UpdateInsurance(int id,Property insur)
        {
            try
            {
                int i = 0;//int @out = 0;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("pr_update_Contract", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IContracts", id);
                    cmd.Parameters.AddWithValue("@CustomerName", insur.CustomerName);
                    cmd.Parameters.AddWithValue("@CustomerAddress", insur.Address);
                    cmd.Parameters.AddWithValue("@CustomerGender", insur.Gender);
                    cmd.Parameters.AddWithValue("@CustomerCountry", insur.CustomerCountry);
                    cmd.Parameters.AddWithValue("@CustomerDateofBirth", insur.DateofBirth);
                    cmd.Parameters.AddWithValue("@SaleDate", insur.SaleDate);
                    //cmd.Parameters.Add("@Out", SqlDbType.Char, 30);
                    //cmd.Parameters["@Out"].Direction = ParameterDirection.Output;
                    con.Open();
                  i=cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (i > 0)
                {
                    return true;
                }
                else
                { return false; }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}