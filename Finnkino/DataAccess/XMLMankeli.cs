using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml;
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

        public Schedule mankeloiMovies(string url)
        {
            getWebResponse(url, new Schedule());
            var result = ser.Deserialize(stream) as Schedule;
            response.Close();
            return result;
        }

        public TheatreAreas mankeloiAreat(string url)
        {
            getWebResponse(url, new TheatreAreas());
            var result = ser.Deserialize(stream) as TheatreAreas;
            response.Close();

            return result;
        }

        public string[] mankeloiSynopsis(string url)
        {
            string[] result = new string[2];
            result[0] = "";
            WebRequest request = WebRequest.Create(url);
            ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36";
            request.Proxy = null;
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            using (XmlReader reader = XmlReader.Create(new StreamReader(stream)))
            {
                while (reader.Read())
                {
                    bool lopeta = false;
                    Debug.WriteLine("SDFASDFASDFASDFASD" + reader.Value.ToString());
                    switch (reader.Name)
                    {
                        case "ShortSynopsis":
                            if (result[0].Equals(""))
                            {
                                reader.Read();
                                result[0] = reader.Value.ToString();
                            }
                            break;
                        case "GalleryImage":
                            reader.Read();
                            reader.Read();
                            reader.Read();
                            reader.Read();
                            reader.Read();
                            result[1] = reader.Value.ToString();
                            lopeta = true;
                            break;
                        default:
                            break;
                    }
                    if (lopeta == true) break;
                }
            }
            response.Close();
            return result;
        }

        public string mankeloiRatings(string url)
        {
            WebRequest request = WebRequest.Create(url);
            ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36";
            request.Proxy = null;
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            using (XmlReader reader = XmlReader.Create(new StreamReader(stream)))
            {
                while (reader.Read())
                {
                    switch(reader.Name)
                    {
                        case "movie":
                            string rating = reader.GetAttribute("imdbRating");
                            response.Close();
                            return rating;
                    }
                   
                }
            }
            response.Close();
            return null;
        }

    }
}
