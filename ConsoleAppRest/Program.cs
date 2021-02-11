using System;
using System.Text;
using System.Net;
using System.IO;

namespace ConsoleAppRest
{
    class Program
    {
        static void Main(string[] args)
        {
            //DoConsumiWebRestRequestMockApi_fp();
            DoConsumiWebRestRequestMockApi_fp();
            //DoConsumiWebRestRequest();
            //DoConsumiWebRestClient();
            //DoCondumirPost();
            //DoCondumirPut();
            //DoConsumiWebDelete();
            Console.ReadKey();
        }


        //GET
        //fazendo um get de uma API existente
        public static void DoConsumiWebRestClient()
        {
            WebClient webClient = new WebClient();
            string content = webClient.DownloadString("http://jsonplaceholder.typicode.com/posts");
            Console.Write(content);
        }

        //fazendo um get de uma API existente
        public static void DoConsumiWebRestRequest()
        {
            WebRequest request =  WebRequest.Create("http://jsonplaceholder.typicode.com/posts");
            request.Method = "GET";
            
            var response = request.GetResponse();
            

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader streamReader = new StreamReader(stream);
                        string content = streamReader.ReadToEnd();
                        Console.Write("GET" + content);
                    }
            }
                else
                {
                        Console.Write("GET Fail");
                }                     
        }

        public static void DoConsumiWebRestRequestMockApi_fp()
        {
            string endpoint = "https://600607e63698a80017de12e2.mockapi.io/fp";
            WebRequest request = WebRequest.Create(endpoint);
            request.Method = "GET";
            var response = request.GetResponse();


            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(stream);
                    string content = streamReader.ReadToEnd();
                    Console.Write("GET" + content);
                }
            }
            else
            {
                Console.Write("GET Fail");
            }
        }


        //POST - https://600607e63698a80017de12e2.mockapi.io/fp
        //project https://mockapi.io/projects/600607e63698a80017de12e3
        public static void DoCondumirPost()
        {
            WebRequest request = WebRequest.Create("https://600607e63698a80017de12e2.mockapi.io/fp");
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";
            string json = "{\"nome\":\"fabio\"}";

            var byteArray = Encoding.UTF8.GetBytes(json);
            request.ContentLength = byteArray.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(byteArray, 0, byteArray.Length);
            stream.Close();

            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.Created)
            {
                Console.Write("Post https://600607e63698a80017de12e2.mockapi.io/fp => ok");
            }
            else
            {
                Console.Write("fail Post");
            }
        }


        //PUT - https://600607e63698a80017de12e2.mockapi.io/fp
        // parametro 1
        //project https://mockapi.io/projects/600607e63698a80017de12e3
        public static void DoCondumirPut()
        {
            WebRequest request = WebRequest.Create("https://600607e63698a80017de12e2.mockapi.io/fp/1");
            request.Method = "PUT";
            request.ContentType = "application/json; charset=UTF-8";
            string json = "{\"nome\":\"aaaaaaaaaaaaa\"}";

            var byteArray = Encoding.UTF8.GetBytes(json);
            request.ContentLength = byteArray.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(byteArray, 0, byteArray.Length);
            stream.Close();

            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.Write("PUT => ok");
            }
            else
            {
                Console.Write("fail Post");
            }
        }

        //delete
        //passar parametro
        public static void DoConsumiWebDelete()
        {
            WebRequest request = WebRequest.Create("https://600607e63698a80017de12e2.mockapi.io/fp/1");
            request.Method = "DELETE";
            var response = (HttpWebResponse)request.GetResponse();

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                    Console.Write("PUT OK");
                else
                    Console.Write("falha PUT");
            }
            else
            {
                Console.Write("Falha metodo PUT");
            }

        }
    }
}

