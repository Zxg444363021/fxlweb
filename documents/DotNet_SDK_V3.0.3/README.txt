
====================当前版本信息====================
当前版本：V3.0.3

发布日期：2014-01-20

文件大小：148 K

====================修改历史====================
V3.0.3  2014-01-20, 针对开发商反馈的多线程下有连接主动关闭而导致执行超时返回1901的现象，增大了http的默认连接限制，如果单线程情况下可以考虑将SnsNetWork.cs中的“ServicePointManager.DefaultConnectionLimit = 500;”注释掉。

V3.0.2  2013-05-30, 去掉sdk校验openkey是否为空的逻辑。

V3.0.1  2013-02-28, 重新规范了SDK的返回码，避免和API本身返回码重合。

V3.0.0  2013-01-16, 腾讯开放平台V3版OpenAPI的.NET SDK第一版发布，3.0表示OpenAPI版本，后一位0表示SDK版本。
        本SDK基于V3版OpenAPI，适用于腾讯开放平台上所有应用接入时使用：
        -V3版OpenAPI是老OpenAPI的升级版，支持全平台统一接入，即对于同一功能（例如获取用户信息），第三方应用不再需要根据不同的平台调用不同的接口。
        -V3版OpenAPI采用新的接入协议，请求中必须包含签名值，更加安全。
        -V3版OpenAPI在参数和返回值上尽量和老版本OpenAPI接口兼容，开发者如果想升级到新版本OpenAPI，代码改造工作量较小。
        -开发者可以自由选择是否升级到OpenAPI V3.0。由于OpenAPI V3.0的上述优点，以及后续新开放的接口都将采用OpenAPI。

====================文件结构信息====================
src文件夹：源代码
	App_Code文件夹：
		OpenApi.cs：OpenAPI访问类
		SnsNetWork.cs：发送HTTP网络请求类
		SnsSigCheck.cs：请求参数签名生成类
		SnsStat.cs：统计上报类

	bin文件夹：
		System.Web.Extensions.dll：代码OpenApi.cs中使用了System.Web.Script.Serialization.JavaScriptSerializer这个类，需要添加这个动态库。.NET FRAMEWORK 3.5以上版本则不需要。ps：腾讯云平台CVM虚拟机windows 2008 server系统预安装.NET FRAMEWORK 3.5以上版本，这个动态库在C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.5中。

	testOpenApiV3.aspx：asp.net文件
	testOpenApiV3.aspx.cs：示例代码，包括普通get/post请求和multipart/form-data格式的post请求的示例。
	Web.config：vs新建网站时产生，网站配置文件

OpenApiV3.sln：代码工程，如果装有vs可以直接打开

README.txt：说明文档

本SDk示例代码中并没有列出所有的OpenAPI，腾讯开放平台V3版OpenAPI正在不断增加中，详见API列表：
http://wiki.open.qq.com/wiki/API3.0%E6%96%87%E6%A1%A3
	
====================联系我们====================
腾讯开放平台官网：http://open.qq.com/
您可以访问我们的资料库获得详尽的技术文档：http://wiki.open.qq.com/wiki/%E9%A6%96%E9%A1%B5
您可以使用联调工具集来进行OpenAPI的联调和sig验证：http://open.qq.com/tools
此外，你也可以通过企业QQ（号码：800013811；直接在QQ的“查找联系人”中输入号码即可开始对话）咨询。
