﻿using System;
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
        public Schedule mankeloiMovieBox(string url)
        {
            List<MovieBox> movies = new List<MovieBox>();

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            XmlSerializer ser = new XmlSerializer(typeof(Schedule));
            var result = ser.Deserialize(stream) as Schedule;
            response.Close();


            return result;
        }
    }
}
