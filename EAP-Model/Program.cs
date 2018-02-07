using System;
using System.Net;

namespace EAP_Model
{
    class Program
    {
        static void Main(string[] args)
        {
            var uriString = "https://www.google.de";
            var webclient = new WebClient();
            webclient.DownloadStringCompleted += OnStringDownloadCompelted;
            webclient.DownloadStringAsync(new Uri(uriString));

            Console.WriteLine("End of Main method.");
            Console.ReadLine();
        }

        private static void OnStringDownloadCompelted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
                Console.WriteLine("Error during download: " + e.Error.ToString());

            if (e.Cancelled)
                return;

            Console.WriteLine(e.Result);
        }
    }
}
