using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QL_Blogs.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace QL_Blogs.DataAccess
{
    public class DataAccessLayer
    {
        public int InsertData(BlogPosition objcust)
        {
            SqlConnection con = null;

            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("InserBlogs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", objcust.Title);
                cmd.Parameters.AddWithValue("@Descriptions", objcust.Descriptions);
                cmd.Parameters.AddWithValue("@Detail", objcust.Detail);
                cmd.Parameters.AddWithValue("@Category", objcust.Category);
                cmd.Parameters.AddWithValue("@Status", objcust.Status);
                cmd.Parameters.AddWithValue("@DataPublic", objcust.DataPublic);
                cmd.Parameters.AddWithValue("@Thumbs", objcust.Thumbs);
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
        public string InsertPosition(int blogid, int poscateid)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("InsertPosition", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogID", blogid);
                cmd.Parameters.AddWithValue("@PosCateID", poscateid);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
        public string UpdateData(Blog objcust)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blogs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objcust.ID);
                cmd.Parameters.AddWithValue("@Title", objcust.Title);
                cmd.Parameters.AddWithValue("@Description", objcust.Descriptions);
                cmd.Parameters.AddWithValue("@Detail", objcust.Detail);
                cmd.Parameters.AddWithValue("@Category", objcust.Category);
                cmd.Parameters.AddWithValue("@Publics", objcust.Status);
                cmd.Parameters.AddWithValue("@DataPublic", objcust.DataPublic);
                //cmd.Parameters.AddWithValue("@Position", objcust.Position);
                cmd.Parameters.AddWithValue("@Thumbs", objcust.Thumbs);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
        public int DeleteData(String ID)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("DeleteBlog", con);              
                con.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Blog> Selectalldata()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Blog> custlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("ListBlogs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Blog>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Blog cobj = new Blog();
                    cobj.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    cobj.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    cobj.Descriptions = ds.Tables[0].Rows[i]["Descriptions"].ToString();
                    cobj.Category = ds.Tables[0].Rows[i]["Category"].ToString();
                    cobj.Status = Convert.ToBoolean(ds.Tables[0].Rows[i]["Status"].ToString());
                    cobj.Position = ds.Tables[0].Rows[i]["Positon"].ToString();
                    var Date = ds.Tables[0].Rows[i]["DataPublic"].ToString();
                        if(Date != null)
                    {
                        cobj.DataPublic = Convert.ToDateTime(Date);
                    }
                   
    
                    custlist.Add(cobj);
                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }

        public Blog SelectDatabyID(string ID)
        {
            SqlConnection con = null;
            DataSet ds = null;
            Blog cobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blogs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Title", null);
                cmd.Parameters.AddWithValue("@Description", null);
                cmd.Parameters.AddWithValue("@Detail", null);
                cmd.Parameters.AddWithValue("@Category", null);
                cmd.Parameters.AddWithValue("@Publics", null);
                cmd.Parameters.AddWithValue("@DataPublic", null);
                cmd.Parameters.AddWithValue("@Position", null);
                cmd.Parameters.AddWithValue("@Thumbs", null);
                cmd.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new Blog();
                    cobj.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    cobj.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    cobj.Category = ds.Tables[0].Rows[i]["Category"].ToString();
                    cobj.Status = Convert.ToBoolean(ds.Tables[0].Rows[i]["Status"].ToString());
                    cobj.DataPublic = Convert.ToDateTime(ds.Tables[0].Rows[i]["DataPublic"].ToString());

                }
                return cobj;
            }
            catch
            {
                return cobj;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Categories> SelectCategory()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Categories> custlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("ShowCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Categories>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Categories cobj = new Categories();
                    cobj.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    cobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    custlist.Add(cobj);
                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }

        public List<PositionCate> SelectPositionCate()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<PositionCate> custlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("ShowPositionCate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<PositionCate>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    PositionCate cobj = new PositionCate();
                    cobj.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    cobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    custlist.Add(cobj);
                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }
    }
}