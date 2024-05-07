using System;
using System.Net;
using System.Threading.Tasks;

namespace CSharpServer
{
    [HttpHandler("/Ping")]
    public class GetPing : BaseHttpRequestHandler
    {
        public override async Task Handle(HttpListenerRequest request, HttpListenerResponse response)
        {
            // Ŭ���̾�Ʈ�� ��û �α� ���
            LogRequest(request);

            // ���� ����
            await RespondText("Server Response: Ping received", response);
        }

        private void LogRequest(HttpListenerRequest request)
        {
            Console.WriteLine("Received a request:");
            Console.WriteLine($"HTTP Method: {request.HttpMethod}");
            Console.WriteLine($"URL: {request.Url}");
            Console.WriteLine($"Headers: {string.Join("; ", request.Headers.AllKeys)}");
            Console.WriteLine($"Client IP: {request.RemoteEndPoint?.Address}");

            // ��û ������ ���� ��� ������ ��� (���� ��� POST ��û����)
            if (request.HasEntityBody)
            {
                using (var body = request.InputStream)
                using (var reader = new System.IO.StreamReader(body, request.ContentEncoding))
                {
                    Console.WriteLine("Request Body:");
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}
