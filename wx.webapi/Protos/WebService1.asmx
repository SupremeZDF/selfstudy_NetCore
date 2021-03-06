

<html>

    <head><link rel="alternate" type="text/xml" href="/WebService1.asmx?disco" />

    <style type="text/css">
    
		BODY { color: #000000; background-color: white; font-family: Verdana; margin-left: 0px; margin-top: 0px; }
		#content { margin-left: 30px; font-size: .70em; padding-bottom: 2em; }
		A:link { color: #336699; font-weight: bold; text-decoration: underline; }
		A:visited { color: #6699cc; font-weight: bold; text-decoration: underline; }
		A:active { color: #336699; font-weight: bold; text-decoration: underline; }
		A:hover { color: cc3300; font-weight: bold; text-decoration: underline; }
		P { color: #000000; margin-top: 0px; margin-bottom: 12px; font-family: Verdana; }
		pre { background-color: #e5e5cc; padding: 5px; font-family: Courier New; font-size: x-small; margin-top: -5px; border: 1px #f0f0e0 solid; }
		td { color: #000000; font-family: Verdana; font-size: .7em; }
		h2 { font-size: 1.5em; font-weight: bold; margin-top: 25px; margin-bottom: 10px; border-top: 1px solid #003366; margin-left: -15px; color: #003366; }
		h3 { font-size: 1.1em; color: #000000; margin-left: -15px; margin-top: 10px; margin-bottom: 10px; }
		ul { margin-top: 10px; margin-left: 20px; }
		ol { margin-top: 10px; margin-left: 20px; }
		li { margin-top: 10px; color: #000000; }
		font.value { color: darkblue; font: bold; }
		font.key { color: darkgreen; font: bold; }
		font.error { color: darkred; font: bold; }
		.heading1 { color: #ffffff; font-family: Tahoma; font-size: 26px; font-weight: normal; background-color: #003366; margin-top: 0px; margin-bottom: 0px; margin-left: -30px; padding-top: 10px; padding-bottom: 3px; padding-left: 15px; width: 105%; }
		.button { background-color: #dcdcdc; font-family: Verdana; font-size: 1em; border-top: #cccccc 1px solid; border-bottom: #666666 1px solid; border-left: #cccccc 1px solid; border-right: #666666 1px solid; }
		.frmheader { color: #000000; background: #dcdcdc; font-family: Verdana; font-size: .7em; font-weight: normal; border-bottom: 1px solid #dcdcdc; padding-top: 2px; padding-bottom: 2px; }
		.frmtext { font-family: Verdana; font-size: .7em; margin-top: 8px; margin-bottom: 0px; margin-left: 32px; }
		.frmInput { font-family: Verdana; font-size: 1em; }
		.intro { margin-left: -15px; }
           
    </style>

    <title>
	WebService1 Web 服务
</title></head>

  <body>

    <div id="content">

      <p class="heading1">WebService1</p><br>

      

      <span>

          <p class="intro">支持下列操作。有关正式定义，请查看<a href="WebService1.asmx?WSDL">服务说明</a>。 </p>
          
          
              <ul>
            
              <li>
                <a href="WebService1.asmx?op=Add">Add</a>
                
                
              </li>
              <p>
            
              <li>
                <a href="WebService1.asmx?op=HelloWorld">HelloWorld</a>
                
                
              </li>
              <p>
            
              <li>
                <a href="WebService1.asmx?op=Jian">Jian</a>
                
                
              </li>
              <p>
            
              </ul>
            
      </span>

      
      

    <span>
        
    </span>
    
      <span>
          <hr>
          <h3>此 Web 服务使用 http://tempuri.org/ 作为默认命名空间。</h3>
          <h3>建议: 公开 XML Web services 之前，请更改默认命名空间。</h3>
          <p class="intro">每个 XML Web services 都需要一个唯一的命名空间，以便客户端应用程序能够将它与 Web 上的其他服务区分开。http://tempuri.org/ 可用于处于开发阶段的 XML Web services，而已发布的 XML Web services 应使用更为永久的命名空间。</p>
          <p class="intro">应使用您控制的命名空间来标识 XML Web services。例如，可以使用公司的 Internet 域名作为命名空间的一部分。尽管有许多 XML Web services 命名空间看似 URL，但它们不必指向 Web 上的实际资源。(XML Web services 命名空间为 URI。)</p>
          <p class="intro">使用 ASP.NET 创建 XML Web services 时，可以使用 WebService 特性的 Namespace 属性更改默认命名空间。WebService 特性适用于包含 XML Web services 方法的类。下面的代码实例将命名空间设置为“http://microsoft.com/webservices/”:</p>
          <p class="intro">C#</p>
          <pre>[WebService(Namespace="http://microsoft.com/webservices/")]
public class MyWebService {
    // 实现
}</pre>
          <p class="intro">Visual Basic</p>
          <pre>&lt;WebService(Namespace:="http://microsoft.com/webservices/")&gt; Public Class MyWebService
    ' 实现
End Class</pre>

          <p class="intro">C++</p>
          <pre>[WebService(Namespace="http://microsoft.com/webservices/")]
public ref class MyWebService {
    // 实现
};</pre>
          <p class="intro">有关 XML 命名空间的更多详细信息，请参阅 <a href="http://www.w3.org/TR/REC-xml-names/">Namespaces in XML (XML 命名空间)</A>上的 W3C 建议。</p>
          <p class="intro">有关 WSDL 的更多详细信息，请参阅 <a href="http://www.w3.org/TR/wsdl">WSDL Specification (WSDL 规范)</a>。</p>
          <p class="intro">有关 URI 的更多详细信息，请参阅 <a href="http://www.ietf.org/rfc/rfc2396.txt">RFC 2396</a>。</p>
      </span>

      

    
  
<!-- Visual Studio Browser Link -->
<script type="text/javascript" src="https://localhost:44399/0a1e07632ff7448caee1f7fb0b33ed87/browserLink" async="async" id="__browserLink_initializationData" data-requestId="733fd39d4a3549168c97330036c2ba95" data-appName="Unknown"></script>
<!-- End Browser Link -->

</body>
</html>
