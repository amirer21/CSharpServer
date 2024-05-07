# CSharpServer

CSharpServer�� C#�� ����Ͽ� ������ ������ HTTP �����Դϴ�. �� ������ Text, JSON �����͸� �ް� �����ϴ� ����� �����ϸ�, `System.Net.HttpListener`�� ����Ͽ� HTTP ��û�� ó���մϴ�.

## HTTP Handler

- /Ping : ������ ���������� �����ϴ��� Ȯ���ϱ� ���� �ڵ鷯�Դϴ�.
- /GetJson : Ŭ���̾�Ʈ�κ��� JSON �����͸� �޾� �����ϴ� �ڵ鷯�Դϴ�.


## �ֿ� ���

- **Text ��û ó��**: GET ��û�� ���� �ؽ�Ʈ �����͸� �ް� �����մϴ�.
- **JSON ��û ó��**: POST ��û�� ���� JSON �����͸� �ް� ó���մϴ�.
- **JSON ����**: Ŭ���̾�Ʈ���� JSON �������� �����͸� �����մϴ�.
- **��û �α�**: ������ ���ŵ� ��� ��û�� ���� ������ �ֿܼ� �α��մϴ�.

## ��ġ ���

�� ������Ʈ�� �����ϱ� ���� �ʿ��� �ֿ� �ܰ�� ������ �����ϴ�:

1. **.NET ���� ȯ��**: .NET SDK�� ��ġ�Ǿ� �־�� �մϴ�. [.NET ���� ������](https://dotnet.microsoft.com/download)���� SDK�� �ٿ�ε��� �� �ֽ��ϴ�.
2. **Newtonsoft.Json ���̺귯��**: JSON �����͸� ó���ϱ� ���� `Newtonsoft.Json` ���̺귯���� �ʿ��մϴ�. NuGet ��Ű�� �Ŵ����� ���� ��ġ�� �� �ֽ��ϴ�.

   ```bash
   dotnet add package Newtonsoft.Json
   ```

3. **maccatalyst ��ũ�ε� ��ġ**: maccatalyst ��ũ�ε带 ��ġ�ؾ� �մϴ�.
   ```bash
   dotnet workload install maccatalyst
   ```

   Mac Catalyst
   maccatalyst�� macOS�� iOS ���� ���� .NET ������ �����մϴ�. �� ��ũ�ε带 ��ġ�ϴ� ���� �ַ� macOS���� iOS �Ǵ� macOS Catalyst ���ø����̼��� �����Ϸ��� ��� �ʿ��մϴ�. ���� �ش� ������Ʈ�� macOS Catalyst ���� ������Ʈ�� �ƴ϶��, ������Ʈ ������ �����Ͽ� �� �� ��ũ�ε尡 �䱸�Ǵ��� Ȯ���ؾ� �մϴ�.



## �׽�Ʈ �ڵ� 

�� �ڵ鷯�� ���� �׽�Ʈ �ڵ�� `ClientTest` ������Ʈ�� �����Ǿ� �ֽ��ϴ�. �� ������Ʈ�� Python�� ����Ͽ� ������ ��û�� ������ ������ Ȯ���ϴ� ����� �����մϴ�.
���̽� �ڵ�� ���� ��ũ���� Ȯ���� �� �ֽ��ϴ�.

https://github.com/amirer21/PythonAPIServer/tree/master/client_test