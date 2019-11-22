using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Text;


namespace Lab7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult repos()
        {
            string credential=getCredential();
            string username="chemotroph";

            string uri = "https://api.github.com/user";
            Debug.WriteLine(uri);
            string data = SendRequest(uri, credential, username);
            Object obj=null;
            try 
            { obj = JObject.Parse(data);}
            catch(ArgumentNullException e)
            { Debug.WriteLine("Returned JSON was null"); }
            
            Debug.WriteLine(obj);
            return Json(obj);
        }

        private string SendRequest(string uri, string credentials, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + credentials);
            request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
            request.Accept = "application/json";

            string jsonString = null;
            // TODO: You should handle exceptions here
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    jsonString = reader.ReadToEnd();
                    reader.Close();
                    stream.Close();
                }
            }
            catch(WebException e)
            {
                Debug.WriteLine("Failed to connect to API");
            }
            return jsonString;
        }

        private string getCredential()
        {
            string credential=null;
            string path = @"F:/PROGRAMMING PROJECTS/Credential.txt";
            try
            {
                credential = System.IO.File.ReadAllText(path);
            }
            catch(FileNotFoundException e)
            {
                Debug.WriteLine("Credential File not found");
            }
            Debug.WriteLine(credential);
            return credential;
        }
    }
}