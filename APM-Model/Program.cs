using System;
using System.IO;
using System.Net;

namespace APM_Model
{
    class Program
    {
        static void Main(string[] args)
        {
            var uriString = "http://www.google.de";
            var request = HttpWebRequest.Create(uriString);
            request.Method = "GET";
            request.BeginGetResponse(OnResponse, request);
            Console.WriteLine("Request data from " + uriString);
            Console.ReadLine();
        }

        private static void OnResponse(IAsyncResult ar)
        {
            var request = ar.AsyncState as WebRequest;
            var stream  = request.EndGetResponse(ar).GetResponseStream();

            Console.WriteLine(new StreamReader(stream).ReadToEnd());
        }
    }
}
