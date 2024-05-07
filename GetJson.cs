using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSharpServer
{
    [HttpHandler("/GetJson")]
    public class GetJson : BaseHttpRequestHandler
    {
        public override async Task Handle(HttpListenerRequest request, HttpListenerResponse response)
        {
            // 클라이언트의 요청 로그 출력
            LogRequest(request);

            if (request.HttpMethod == "POST" && request.ContentType == "application/json")
            {
                try
                {
                    // JSON 요청 본문을 읽고 파싱
                    using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        string requestBody = await reader.ReadToEndAsync();
                        dynamic jsonData = JsonConvert.DeserializeObject(requestBody);

                        // 응답 데이터 생성 및 전송
                        var responseData = new
                        {
                            Success = true,
                            Message = "JSON data received successfully.",
                            ReceivedData = jsonData
                        };

                        await BaseHttpRequestHandler.RespondWithJson(response, responseData);
                        //분리
                        /*string responseText = JsonConvert.SerializeObject(responseData);
                        byte[] buffer = Encoding.UTF8.GetBytes(responseText);
                        response.ContentLength64 = buffer.Length;
                        response.ContentType = "application/json";
                        using (var output = response.OutputStream)
                        {
                            await output.WriteAsync(buffer, 0, buffer.Length);
                        }*/
                    }
                }
                catch (Exception ex)
                {
                    /*response.StatusCode = 500; // Internal Server Error
                    string responseText = $"Error processing JSON data: {ex.Message}";
                    byte[] buffer = Encoding.UTF8.GetBytes(responseText);
                    response.ContentLength64 = buffer.Length;
                    using (var output = response.OutputStream)
                    {
                        await output.WriteAsync(buffer, 0, buffer.Length);
                    }*/
                    var errorResponse = new { Success = false, ErrorMessage = ex.Message };
                    await BaseHttpRequestHandler.RespondWithJson(response, errorResponse, 500);
                }
            }
            else
            {
                // 올바르지 않은 요청 처리
                /*response.StatusCode = 400; // Bad Request
                string responseText = "This service requires a JSON POST request.";
                byte[] buffer = Encoding.UTF8.GetBytes(responseText);
                response.ContentLength64 = buffer.Length;
                using (var output = response.OutputStream)
                {
                    await output.WriteAsync(buffer, 0, buffer.Length);
                }*/
                var errorResponse = new { Success = false, ErrorMessage = "Invalid request method or content type" };
                await BaseHttpRequestHandler.RespondWithJson(response, errorResponse, 400);
            }
        }

        private void LogRequest(HttpListenerRequest request)
        {
            Console.WriteLine("Received a JSON request:");
            Console.WriteLine($"HTTP Method: {request.HttpMethod}");
            Console.WriteLine($"URL: {request.Url}");
            Console.WriteLine($"Headers: {string.Join("; ", request.Headers.AllKeys)}");
            Console.WriteLine($"Content Type: {request.ContentType}");
            Console.WriteLine($"Client IP: {request.RemoteEndPoint?.Address}");
        }
    }
}
