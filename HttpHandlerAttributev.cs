using System;
using System.Net;
using System.Threading.Tasks;


// 속성을 정의하기 위한 기본 Attribute 클래스
[AttributeUsage(AttributeTargets.Class)]
public class HttpHandlerAttribute : Attribute
{
    public string Path { get; }

    public HttpHandlerAttribute(string path)
    {
        Path = path;
    }
}
