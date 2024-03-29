﻿using System.IO;
using System.Net;
using System.Windows;

namespace QuanLyNhaHang.Model
{
    public class API
    {
        private static string SERVER = "http://localhost:3000/api";

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
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        #region Employee API
        public static string GetAllEmployee()
        {
            string url = SERVER + "/employees";

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }
        //todo server
        public static string CreateEmployee(Employee employeeNew)
        {
            string url = SERVER + "/employees";
            string json = "{\"username\": \""
                + employeeNew.username + "\", \"password\": \""
                + employeeNew.password + "\", \"displayName\": \""
                + employeeNew.displayName + "\", \"role\": \""
                + employeeNew.role + "\", \"dateOfBirth\": \""
                + employeeNew.dateOfBirth + "\", \"identityNumber\": \""
                + employeeNew.identityNumber + "\", \"phone\": \""
                + employeeNew.phone + "\"}";
            try
            {
                return POST(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }
        //todo server
        public static string UpdateEmployee(Employee employee)
        {
            string url = SERVER + "/employees/" + employee.id;
            string json = "{\"username\": \""
                            + employee.username + "\", \"password\": \""
                            + employee.password + "\", \"displayName\": \""
                            + employee.displayName + "\", \"role\": \""
                            + employee.role + "\", \"dateOfBirth\": \""
                            + employee.dateOfBirth + "\", \"identityNumber\": \""
                            + employee.identityNumber + "\", \"phone\": \""
                            + employee.phone + "\"}";
            try
            {
                return PUT(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string UpdatePassword(Employee employee)
        {
            string url = SERVER + "/employees/password/" + employee.id;
            string json = "{\"username\": \""
                            + employee.username + "\", \"password\": \""
                            + employee.password + "\", \"displayName\": \""
                            + employee.displayName + "\", \"role\": \""
                            + employee.role + "\", \"dateOfBirth\": \""
                            + employee.dateOfBirth + "\", \"identityNumber\": \""
                            + employee.identityNumber + "\", \"phone\": \""
                            + employee.phone + "\"}";
            try
            {
                return PUT(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string DeleteEmployee(string ID)
        {
            string url = SERVER + "/employees/" + ID;
            try
            {
                return DELETE(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        #endregion

        #region Table API
        public static string GetAllTable()
        {
            string url = SERVER + "/tables";

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string CountTableUsing()
        {
            string url = SERVER + "/tables/using";

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string CountTableEmpty()
        {
            string url = SERVER + "/tables/empty";

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string GetAllTableWithStatusAndType(string status, string type)
        {
            string url = SERVER + "/tables/" + status + "/" + type;

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string GetAllTableWithCustomer(string customer)
        {
            string url = SERVER + "/tables/findCustomer";
            string json = "{\"fullName\": \"" + customer + "\"}";
            try
            {
                return POST(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string FindOneTable(string number)
        {
            string url = SERVER + "/tables/" + number;

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
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
                            "\", \"customer\": { \"fullName\": \"" + table.customer.fullName +
                            "\", \"phone\": \"" + table.customer.phone + "\"}}";
            try
            {
                return POST(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string UpdateTable(Model.Table table)
        {
            string url = SERVER + "/tables/" + table.id;
            string json = "{\"number\": \"" + table.number +
                            "\", \"note\": \"" + table.note +
                            "\", \"numberOfSeat\": \"" + table.numberOfSeat +
                            "\", \"status\": \"" + table.status +
                            "\", \"type\": \"" + table.type +
                            "\", \"customer\": { \"fullName\": \"" + table.customer.fullName +
                            "\", \"phone\": \"" + table.customer.phone + "\"}}";
            try
            {
                return PUT(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string BookTable(Model.Table table,string employeeName)
        {
            string url = SERVER + "/tables/Book/" + table.number;
            string json = "{\"employeeName\": \"" + employeeName +
                            "\", \"number\": \"" + table.number +
                            "\", \"note\": \"" + table.note +
                            "\", \"status\": \"" + table.status +
                            "\", \"customer\": { \"fullName\": \"" + table.customer.fullName +
                            "\", \"phone\": \"" + table.customer.phone + "\"}}";

            string url1 = SERVER + "/bills";
            string json1 = "{\"employeeName\": \"" + employeeName +
                            "\", \"number\": \"" + table.number +
                            "\", \"numberOfSeat\": \"" + table.numberOfSeat.ToString() +
                            "\", \"type\": \"" + table.type +
                            "\", \"customer\": { \"fullName\": \"" + table.customer.fullName +
                            "\", \"phone\": \"" + table.customer.phone + "\"}}";
            try
            {
                POST(url1, json1);
                return PUT(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
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
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
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

        #region Food API
        public static string GetAllFood()
        {
            string url = SERVER + "/foods";

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string CreateFood(Food foodNew)
        {
            string url = SERVER + "/foods";
            string json = "{\"name\": \""
                + foodNew.name + "\", \"price\": \""
                + foodNew.price + "\", \"ingredients\": \""
                + foodNew.ingredients + "\", \"type\": \""
                + foodNew.type + "\", \"note\": \""
                + foodNew.note + "\"}";
            try
            {
                return POST(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }
        
        public static string UpdateFood(string ID, Food foodNew)
        {
            string url = SERVER + "/foods/" + ID;
            string json = "{\"name\": \""
                + foodNew.name + "\", \"price\": \""
                + foodNew.price + "\", \"ingredients\": \""
                + foodNew.ingredients + "\", \"type\": \""
                + foodNew.type + "\", \"note\": \""
                + foodNew.note + "\"}";
            try
            {
                return PUT(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string DeleteFood(string ID)
        {
            string url = SERVER + "/foods/" + ID;
            try
            {
                return DELETE(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        #endregion

        #region Bill API
        public static string GetAllBill()
        {
            string url = SERVER + "/bills";

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string AddFoodInBill(string TableNumber, Food foodNew)
        {
            string url = SERVER + "/bills/addFoodInBill";
            string json = "{\"tableNumber\": \""
                + TableNumber + "\", \"foodId\": \""
                + foodNew.id + "\", \"name\": \""
                + foodNew.name + "\", \"price\": \""
                + foodNew.price + "\", \"ingredients\": \""
                + foodNew.ingredients + "\", \"type\": \""
                + foodNew.type + "\", \"note\": \""
                + foodNew.note + "\"}";
            try
            {
                return PUT(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string IncreaseAmountFood(string TableNumber, Food foodNew)
        {
            string url = SERVER + "/bills/increaseAmountFood";
            string json = "{\"tableNumber\": \""
                + TableNumber + "\", \"foodId\": \""
                + foodNew.id + "\", \"name\": \""
                + foodNew.name + "\", \"price\": \""
                + foodNew.price + "\", \"ingredients\": \""
                + foodNew.ingredients + "\", \"type\": \""
                + foodNew.type + "\", \"note\": \""
                + foodNew.note + "\"}";
            try
            {
                return PUT(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string DecreaseAmountFood(string TableNumber, Food foodNew)
        {
            string url = SERVER + "/bills/decreaseAmountFood";
            string json = "{\"tableNumber\": \""
                + TableNumber + "\", \"foodId\": \""
                + foodNew.id + "\", \"name\": \""
                + foodNew.name + "\", \"price\": \""
                + foodNew.price + "\", \"ingredients\": \""
                + foodNew.ingredients + "\", \"type\": \""
                + foodNew.type + "\", \"note\": \""
                + foodNew.note + "\"}";
            try
            {
                return PUT(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        
            public static string GetFoodInBillByBill(string number)
        {
            string url = SERVER + "/bills/foodInbill/" + number;

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }
        public static string GetFoodInBill(string number)
        {
            string url = SERVER + "/bills/" + number;

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string GetTotalInBill(string number)
        {
            string url = SERVER + "/getTotalOfBill/" + number;

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string Pay(string tableNumber, string promotion, string total)
        {
            string url = SERVER + "/bills/pay";
            string json = "{\"tableNumber\": \""
                + tableNumber + "\", \"promotion\": \""
                + promotion + "\", \"total\": \""
                + total + "\"}";
            try
            {
                return POST(url,json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
            
        }

        public static string Filter(string startTime,string endTime)
        {
            string url = SERVER + "/bills/filter";
            string json = "{\"startTime\": \""
                + startTime + "\", \"endTime\": \""
                + endTime + "\"}";

            try
            {
                return POST(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
            
        }

        public static string FindOneBill(string number)
        {
            string url = SERVER + "/bills/bill/" + number;

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string GetAllBillWithCustomer(string customer)
        {
            string url = SERVER + "/bills/findCustomer";
            string json = "{\"fullName\": \"" + customer + "\"}";
            try
            {
                return POST(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }
        #endregion

        #region Promotions API
        public static string GetPromotions()
        {
            string url = SERVER + "/promotions";

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string GetAllPromotion()
        {
            string url = SERVER + "/promotions";

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string CreatePromotion(Promotion PromotionNew)
        {
            string url = SERVER + "/promotions";
            string json = "{\"code\": \""
                + PromotionNew.code + "\", \"type\": \""
                + PromotionNew.type + "\", \"value\": \""
                + PromotionNew.value + "\", \"rule\": \""
                + PromotionNew.rule + "\", \"active\": \""
                + PromotionNew.active + "\"}";
            try
            {
                return POST(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }
        
        public static string UpdatePromotion(string ID, Promotion PromotionNew)
        {
            string url = SERVER + "/promotions/update/" + ID;
            string json = "{\"code\": \""
               + PromotionNew.code + "\", \"type\": \""
               + PromotionNew.type + "\", \"value\": \""
               + PromotionNew.value + "\", \"rule\": \""
               + PromotionNew.rule + "\", \"active\": \""
               + PromotionNew.active + "\"}";
            try
            {
                return PUT(url, json);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        public static string DeletePromotion(string ID)
        {
            string url = SERVER + "/promotions/delete/" + ID;
            try
            {
                return DELETE(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }
        #endregion

        #region Fee API
        public static string GetFee(string type)
        {
            string url = SERVER + "/servicefees/" + type;

            try
            {
                return GET(url);
            }
            catch
            {
                MessageBox.Show("Kết nối không ổn định. Xin thử lại.");
                return "";
            }
        }

        #endregion
    }
}