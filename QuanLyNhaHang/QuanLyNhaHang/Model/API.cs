﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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

        public static string getAllTableWithStatusAndType(string status, string type)
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

    }
}
