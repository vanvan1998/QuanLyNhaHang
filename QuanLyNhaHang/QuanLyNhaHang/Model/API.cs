using System.IO;
using System.Net;
using System.Windows;

namespace QuanLyNhaHang.Model
{
    public class API
    {
        public static string SERVER = "http://localhost:3000/api";

        public static string login(string username, string password)
        {
            string json = "{\"username\": \"" + username + "\", \"password\": \"" + password + "\"}";
            string url = SERVER + "/login";

            try
            {
                return POST(url, json);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server");
                return "";
            }
        }

        #region User API

        public static string CreateNewUser(string username, string password, string role)
        {
            string url = SERVER + "/users";
            string json = "{\"username\": \"" + username + "\", \"password\": \"" + password + "\", \"role\": \"" + role +"\"}";
            try
            {
                return POST(url, json);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server");
                return "";
            }
        }

        public static string UpdateUser(string ID, string password, string role)
        {
            string url = SERVER + "/users/" + ID;
            string json = "{\"password\": \"" + password + "\", \"role\": \"" + role + "\"}";
            try
            {
                return PUT(url, json);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server");
                return "";
            }
        }

        public static string DeleteUser(string ID)
        {
            string url = SERVER + "/users/" + ID;
            try
            {
                return DELETE(url);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server");
                return "";
            }
        }

        #endregion

        #region Table API

        public static string GetAllTableWithStatusAndType(string status, string type)
        {
            string url = SERVER + "/tables/" + status + "/" + type;

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server");
                return "";
            }
        }

        public static string CreateTable(Model.Table table)
        {
            string url = SERVER + "/tables";
            string json = "{\"number\": \"" + table.number +
                            "\", \"note\": \"" + table.note +
                            "\", \"numberOfSeat\": \"" + table.numberOfSeat +
                            "\", \"status\": \"" + table.status +
                            "\", \"type\": \"" + table.type +
                            "\", \"IDCustomer\": \"" + table.IDCustomer +
                            "\", \"time\": \"" + table.time + "\"}";
            try
            {
                return POST(url, json);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server");
                return "";
            }
        }

        public static string UpdateTable(string ID, Model.Table table)
        {
            string url = SERVER + "/tables/" + ID;
            string json = "{\"number\": \"" + table.number + 
                            "\", \"note\": \"" + table.note + 
                            "\", \"numberOfSeat\": \"" + table.numberOfSeat + 
                            "\", \"status\": \"" + table.status +
                            "\", \"type\": \"" + table.type +
                            "\", \"IDCustomer\": \"" + table.IDCustomer +
                            "\", \"time\": \"" + table.time + "\"}";
            try
            {
                return PUT(url, json);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server");
                return "";
            }
        }

        public static string DeleteTable(string ID)
        {
            string url = SERVER + "/tables/" + ID;

            try
            {
                return DELETE(url);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server");
                return "";
            }
        }


        #endregion

        #region Customer API

        public static string GetCustomer(string ID)
        {
            string url = SERVER + "/customers/" + ID;

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server");
                return "";
            }
        }

        public static string CreateNewCustomer(string fullName, string phone)
        {
            string url = SERVER + "/customers";
            string json = "{\"fullName\": \"" + fullName + "\", \"phone\": \"" + phone + "\"}";
            try
            {
                return POST(url, json);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server");
                return "";
            }
        }

        public static string UpdateCustomer(string ID, string fullName, string phone)
        {
            string url = SERVER + "/customers/" + ID;
            string json = "{\"fullName\": \"" + fullName + "\", \"phone\": \"" + phone + "\"}";
            try
            {
                return PUT(url, json);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server");
                return "";
            }
        }

        public static string DeleteCustomer(string ID)
        {
            string url = SERVER + "/customers/" + ID;
            
            try
            {
                return DELETE(url);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server");
                return "";
            }
        }

        #endregion

        #region Http method

        private static string GET(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static string POST(string uri, string json)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "POST";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Write("\n");
                streamWriter.Flush();
                streamWriter.Close();
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static string PUT(string uri, string json)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "PUT";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Write("\n");
                streamWriter.Flush();
                streamWriter.Close();
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static string DELETE(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "DELETE";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        #endregion  
    }
}
