using System.Net;
using System.Threading.Tasks;

namespace CSharpServer
{
    [HttpHandler("/Ping")]
    public class GetPing : BaseHttpRequestHandler
    {
        public override async Task Handle(HttpListenerRequest request, HttpListenerResponse response)
        {
            await RespondText("WPF", response);
        }
    }
}
