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
                SqlCommand cmd = new SqlCommand("UpdateBlogs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", objcust.Title);
                cmd.Parameters.AddWithValue("@Descriptions", objcust.Descriptions);
                cmd.Parameters.AddWithValue("@Detail", objcust.Detail);
                cmd.Parameters.AddWithValue("@Category", objcust.Category);
                cmd.Parameters.AddWithValue("@Publics", objcust.Status);
                cmd.Parameters.AddWithValue("@DataPublic", objcust.DataPublic);
                cmd.Parameters.AddWithValue("@Thumbs", objcust.Thumbs);
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
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
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
                var table = ds.Tables[0];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Blog cobj = new Blog();
                    cobj.ID = Convert.ToInt32(table.Rows[i]["ID"].ToString());
                    cobj.Title = table.Rows[i]["Title"].ToString();
                    cobj.Descriptions = table.Rows[i]["Descriptions"].ToString();
                    cobj.Category = table.Rows[i]["Category"].ToString();
                    cobj.Status = Convert.ToBoolean(table.Rows[i]["Status"].ToString());
                    cobj.Position = table.Rows[i]["Positon"].ToString();
                    var Date = table.Rows[i]["DataPublic"].ToString();
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

        public Blog SelectDatabyID(int ID)   
        {
            SqlConnection con = null;
            DataSet ds = null;
            Blog cobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SelectBlog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Title", null);
                cmd.Parameters.AddWithValue("@Descriptions", null);
                cmd.Parameters.AddWithValue("@Detail", null);
                cmd.Parameters.AddWithValue("@Category", null);
                cmd.Parameters.AddWithValue("@Status", null);
                cmd.Parameters.AddWithValue("@DataPublic", null);
                //cmd.Parameters.AddWithValue("@Positon", null);
                cmd.Parameters.AddWithValue("@Thumbs", null);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                var table = ds.Tables[0];
                for (int i = 0; i <table.Rows.Count; i++)
                {
                    cobj = new Blog();
                    cobj.ID = Convert.ToInt32(table.Rows[i]["ID"].ToString());
                    cobj.Title = table.Rows[i]["Title"].ToString();
                    cobj.Descriptions = table.Rows[i]["Descriptions"].ToString();
                    cobj.Detail = table.Rows[i]["Detail"].ToString();
                    cobj.Category = table.Rows[i]["Category"].ToString();
                    cobj.Status = Convert.ToBoolean(table.Rows[i]["Status"].ToString());
                    var Date = table.Rows[i]["DataPublic"].ToString();
                    cobj.Thumbs = table.Rows[i]["Thumbs"].ToString();

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
                var table = ds.Tables[0];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Categories cobj = new Categories();
                    cobj.ID = Convert.ToInt32(table.Rows[i]["ID"].ToString());
                    cobj.Name =table.Rows[i]["Name"].ToString();
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
                var table = ds.Tables[0];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    PositionCate cobj = new PositionCate();
                    cobj.ID = Convert.ToInt32(table.Rows[i]["ID"].ToString());
                    cobj.Name = table.Rows[i]["Name"].ToString();
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

        public List<Position> SelectPosition(int ID)
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Position> custlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SelectPosition", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Position>();
                var table = ds.Tables[0];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Position cobj = new Position();
                    cobj.ID = Convert.ToInt32(table.Rows[i]["ID"].ToString());
                    cobj.PosCateID = Convert.ToInt32(table.Rows[i]["PosCateID"].ToString());
                    cobj.BlogID = Convert.ToInt32(table.Rows[i]["BlogID"].ToString());
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

        public List<Blog> Search(string Title)
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Blog> custlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("SearchBlog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", Title);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Blog>();
                var table = ds.Tables[0];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Blog cobj = new Blog();
                    cobj.ID = Convert.ToInt32(table.Rows[i]["Id"].ToString());
                    cobj.Title = table.Rows[i]["Title"].ToString();
                    cobj.Descriptions = table.Rows[i]["Descriptions"].ToString();
                    cobj.Detail = table.Rows[i]["Detail"].ToString();
                    cobj.Category = table.Rows[i]["Category"].ToString();
                    var date = table.Rows[i]["DataPublic"].ToString();
                    if (!string.IsNullOrEmpty(date))
                    {
                        cobj.DataPublic = Convert.ToDateTime(date);
                    }
                    cobj.Status = Convert.ToBoolean(table.Rows[i]["Status"].ToString());
                    cobj.Position = table.Rows[i]["Positon"].ToString();
                    cobj.Thumbs = table.Rows[i]["Thumbs"].ToString();

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