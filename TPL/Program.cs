using System;
using System.Net;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            var uriString = "https://www.google.de";
            var client = new WebClient();
            var contentString = client.DownloadStringTaskAsync(new Uri(uriString));
            contentString.ContinueWith(OnDownloadStringCompleted);

            Console.WriteLine("Download content from: " + uriString);
            Console.ReadLine();
        }

        private static void OnDownloadStringCompleted(Task<string> task)
        {
            if (task.IsFaulted ||
                task.IsCanceled)
            {
                return;
            }

            Console.WriteLine(task.Result);
        }
    }
}
