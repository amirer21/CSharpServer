# CSharpServer

CSharpServer는 C#을 사용하여 구현된 간단한 HTTP 서버입니다. 이 서버는 Text, JSON 데이터를 받고 응답하는 기능을 제공하며, `System.Net.HttpListener`를 사용하여 HTTP 요청을 처리합니다.

## HTTP Handler

- /Ping : 서버가 정상적으로 동작하는지 확인하기 위한 핸들러입니다.
- /GetJson : 클라이언트로부터 JSON 데이터를 받아 응답하는 핸들러입니다.


## 주요 기능

- **Text 요청 처리**: GET 요청을 통해 텍스트 데이터를 받고 응답합니다.
- **JSON 요청 처리**: POST 요청을 통해 JSON 데이터를 받고 처리합니다.
- **JSON 응답**: 클라이언트에게 JSON 형식으로 데이터를 응답합니다.
- **요청 로깅**: 서버는 수신된 모든 요청의 세부 정보를 콘솔에 로깅합니다.

## 설치 방법

이 프로젝트를 실행하기 위해 필요한 주요 단계는 다음과 같습니다:

1. **.NET 개발 환경**: .NET SDK가 설치되어 있어야 합니다. [.NET 공식 페이지](https://dotnet.microsoft.com/download)에서 SDK를 다운로드할 수 있습니다.
2. **Newtonsoft.Json 라이브러리**: JSON 데이터를 처리하기 위해 `Newtonsoft.Json` 라이브러리가 필요합니다. NuGet 패키지 매니저를 통해 설치할 수 있습니다.

   ```bash
   dotnet add package Newtonsoft.Json
   ```

3. **maccatalyst 워크로드 설치**: maccatalyst 워크로드를 설치해야 합니다.
   ```bash
   dotnet workload install maccatalyst
   ```

   Mac Catalyst
   maccatalyst는 macOS와 iOS 앱을 위한 .NET 지원을 제공합니다. 이 워크로드를 설치하는 것은 주로 macOS에서 iOS 또는 macOS Catalyst 애플리케이션을 개발하려는 경우 필요합니다. 만약 해당 프로젝트가 macOS Catalyst 관련 프로젝트가 아니라면, 프로젝트 설정을 검토하여 왜 이 워크로드가 요구되는지 확인해야 합니다.



## 테스트 코드 

각 핸들러에 대한 테스트 코드는 `ClientTest` 프로젝트에 구현되어 있습니다. 이 프로젝트는 Python을 사용하여 서버에 요청을 보내고 응답을 확인하는 기능을 제공합니다.
파이썬 코드는 다음 링크에서 확인할 수 있습니다.

https://github.com/amirer21/PythonAPIServer/tree/master/client_test