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
            // 클라이언트의 요청 로그 출력
            LogRequest(request);

            // 응답 전송
            await RespondText("Server Response: Ping received", response);
        }

        private void LogRequest(HttpListenerRequest request)
        {
            Console.WriteLine("Received a request:");
            Console.WriteLine($"HTTP Method: {request.HttpMethod}");
            Console.WriteLine($"URL: {request.Url}");
            Console.WriteLine($"Headers: {string.Join("; ", request.Headers.AllKeys)}");
            Console.WriteLine($"Client IP: {request.RemoteEndPoint?.Address}");

            // 요청 본문이 있을 경우 본문도 출력 (예를 들어 POST 요청에서)
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
