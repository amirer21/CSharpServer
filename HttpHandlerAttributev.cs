using System;
using System.Net;
using System.Threading.Tasks;


// �Ӽ��� �����ϱ� ���� �⺻ Attribute Ŭ����
[AttributeUsage(AttributeTargets.Class)]
public class HttpHandlerAttribute : Attribute
{
    public string Path { get; }

    public HttpHandlerAttribute(string path)
    {
        Path = path;
    }
}
