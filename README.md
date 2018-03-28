# LoveKicher.ElectricRail.CoolQ

The sub module of LoveKicher.ElectricRail for CoolQ.

这是一个非常简单的酷Q C#/.NET开发框架，同时支持源码上的单DLL编译与大型模块化开发。

## Usage

>必备工作

* 添加DllExport1.6.0的引用，可以使用nuget包。安装之后执行`DllExport_Configure.bat`以完成配置。如果是nuget安装，记得完成之后卸载此包以避免报错。

>使用单文件编译

1. 创建新的类继承`ICoolQModule`接口，并实现相应的方法。

2. 为类添加`[Export(typeof(ICoolQModule))]`声明，标记该类为酷Q模块。

3. 为`PluginContext`类提供的`CoolQPlugin`实例添加相应的事件处理。

4. 编译项目，并把输出中 **x86目录下的** `LoveKicher.ElectricRail.CoolQ.dll`和json文件复制到酷Q *app* 目录下面。直接复制默认编译输出会导致酷Q不识别。

>使用单独的模块

1. 直接编译`LoveKicher.ElectricRail.CoolQ.dll`，同上复制处理。

2. 创建新的项目，按照上面步骤新建模块。

3. 编译项目，并把除上述之外的所有文件复制到酷Q *app* 目录下面 **LoveKicher.ElectricRail.CoolQ** 目录中。