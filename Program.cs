using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSharpServer
{
    class Program
    {
        static HttpListener listener;

        static async Task Main(string[] args)
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            Console.WriteLine("Server is listening...");

            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                Task.Run(() => ProcessRequest(context));
            }
        }

        static async void ProcessRequest(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            string path = request.Url.AbsolutePath;
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                var attributes = type.GetCustomAttributes(typeof(HttpHandlerAttribute), true);
                if (attributes.Length > 0 && ((HttpHandlerAttribute)attributes[0]).Path == path && Activator.CreateInstance(type) is BaseHttpRequestHandler handler)
                {
                    await handler.Handle(request, response);
                    return;
                }
            }

            response.StatusCode = 404;
            await response.OutputStream.WriteAsync(System.Text.Encoding.UTF8.GetBytes("Not Found"));
            response.OutputStream.Close();
        }
    }
}