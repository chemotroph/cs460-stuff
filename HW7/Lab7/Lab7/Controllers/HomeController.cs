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
           // Debug.WriteLine(uri);


            //GET USER DATA
            string data = SendRequest(uri, credential, username);
            JObject obj=null;
            try 
            { obj = JObject.Parse(data);}
            catch(ArgumentNullException e)
            { Debug.WriteLine("Returned JSON for user data was null"); }

            string user = (string)obj["login"];
            string url = (string)obj["url"];
            string avatarurl = (string)obj["avatar_url"];
            string reposurl = (string)obj["repos_url"];
            string bio = (string)obj["bio"];
            int numPublicRepos = (int)obj["public_repos"];

            //GET REPO DATA
            string repoJsonString = SendRequest(reposurl, credential, username);
            Debug.WriteLine(repoJsonString);
            JArray repoJson = null;
            try
            { repoJson = JArray.Parse(repoJsonString); }
            catch (ArgumentNullException e)
            { Debug.WriteLine("Returned JSON for repo List data was null"); }

            List<string> repoNameList = new List<string>();
            List<string> repoCommitsUrlList = new List<string>();
            
            //Debug.WriteLine("peepeepoopoo");
            // Debug.WriteLine(repoJson);
            foreach ( JObject x in repoJson)
            {
                repoNameList.Add((string)x["name"]);
                repoCommitsUrlList.Add((string)x["commits_url"]);
            }
            
            

            var jsonData = new { user, url, avatarurl, reposurl, bio, numPublicRepos, repoNameList, repoCommitsUrlList };
            Debug.WriteLine(obj["login"]);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
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
           // Debug.WriteLine(credential);
            return credential;
        }
    }
}