using System.Net;
using System.Threading.Tasks;

namespace CSharpServer
{
    // HTTP 요청을 처리하는 기본 핸들러
    public abstract class BaseHttpRequestHandler
    {
        public abstract Task Handle(HttpListenerRequest request, HttpListenerResponse response);

        protected async Task RespondText(string text, HttpListenerResponse response)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(text);
            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }
    }
}
