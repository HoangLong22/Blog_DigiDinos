using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace QL_Blogs.DataAccessLayer
{
    public class DataAccessLayer
    {
        private void GetUserDetails()
        {
            var json = File.ReadAllText(@"F:\DigiDinos\Blog_DigiDinos\json_server_blog\db.json");
            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    Console.WriteLine("ID :" + jObject["id"].ToString());
                    Console.WriteLine("Title :" + jObject["title"].ToString());
                    Console.WriteLine("Des :" + jObject["des"].ToString());
                    Console.WriteLine("Detail :" + jObject["detail"].ToString());
                    Console.WriteLine("Category :" + jObject["category"].ToString());
                    Console.WriteLine("Public :" + jObject["public"].ToString());
                    Console.WriteLine("Data_pubblic :" + jObject["data_pubblic"].ToString());
                    Console.WriteLine("Position :" + jObject["position"].ToString());
                    Console.WriteLine("Thumbs :" + jObject["thumbs"].ToString());
                    JArray experiencesArrary = (JArray)jObject["experiences"];

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}