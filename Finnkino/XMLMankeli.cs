using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Finnkino
{
    public class XMLMankeli
    {

        public WebRequest request { get; set; }
        public WebResponse response { get; set; }
        public Stream stream { get; set; }
        public XmlSerializer ser { get; set; }



        private void getWebResponse(string url, object objekti)
        {
            Type type = objekti.GetType();
            request = WebRequest.Create(url);
            ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36";
            request.Proxy = null;
            response = request.GetResponse();
            stream = response.GetResponseStream();

            ser = new XmlSerializer(type);
        }



        public Schedule mankeloiMovieBox(string url)
        {
            getWebResponse(url, new Schedule());
            var result = ser.Deserialize(stream) as Schedule;
            response.Close();
            return result;
        }

        public TheatreAreas mankeloiAreat(string url)
        {
            getWebResponse(url, new TheatreAreas());
           // XmlRootAttribute xRoot = new XmlRootAttribute();
           // xRoot.ElementName = "TheatreAreas";
            
          // XmlSerializer sertti = new XmlSerializer(new Area().GetType(), xRoot);
            var result = ser.Deserialize(stream) as TheatreAreas;
            response.Close();

            return result;
        }

    }
}
