using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using System.IO;
using System.Net;

namespace ArticleProcessorWebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myOutput"];
            Output.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string articleURL = urlInput.Text;
            string searchTerm = searchInput.Text;

            HttpCookie myCookies = Request.Cookies["myOutput"];
            if (myCookies !=  null)
            {
                myCookies["url"] = "";
                myCookies["search"] = "";
                Response.Cookies.Remove("myOutput");
            }

            myCookies = new HttpCookie("myOutput");
            myCookies.Expires = DateTime.Now.AddSeconds(600);

            myCookies["url"] = articleURL;
            myCookies["search"] = searchTerm;
            Response.Cookies.Add(myCookies);

            string relatedURL = @"http://webstrar16.fulton.asu.edu/Page3/Service1.svc/returnedLinks?webURL=" + articleURL;
            string searchURL = @"http://webstrar16.fulton.asu.edu/Page6/Service1.svc/GetData?url=" + articleURL + "&word=" + searchTerm;
            string contentURL = @"http://webstrar16.fulton.asu.edu/Page4/Service1.svc/GetData?url=" + articleURL; ;

            string relatedOut = readerResponse(relatedURL);
            relatedOut = relatedOut.Trim('"');
            string searchOut = readerResponse(searchURL);
            searchOut = searchOut.Trim('"');
            string contentOut = readerResponse(contentURL);
            contentOut = contentOut.Trim('"');

            Cache.Insert("related", relatedOut);
            Cache.Insert("search", searchOut);
            Cache.Insert("content", contentOut);
            

        }

        protected void viewWords_Click(Object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myOutput"];
            dispURL.Text = myCookies["url"];
            myOut.Text = Cache["content"].ToString();
            Output.Visible = true;
        }
        protected void viewSentences_Click(Object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myOutput"];
            dispURL.Text = myCookies["url"];
            myOut.Text = Cache["search"].ToString();
            Output.Visible = true;
        }
        protected void viewLinks_Click(Object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myOutput"];
            dispURL.Text = myCookies["url"];
            myOut.Text = Cache["related"].ToString();
            Output.Visible = true;
        }




        string readerResponse(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            return reader.ReadToEnd().ToString();
        }
    }
}