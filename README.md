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
4. 编译项目，并把输出中 **x86目录下的** `LoveKicher.ElectricRail.CoolQ.dll`和json文件复制到酷Q **app** 目录下面。直接复制默认编译输出会导致酷Q不识别。
5. 单文件插件如果没有额外的依赖程序集，即所有引用的程序集全部在GAC中，此时 **支持应用打包** ！可以直接发布cpk打包文件。

>使用模块化开发

1. 直接编译`LoveKicher.ElectricRail.CoolQ.dll`，同上复制处理。
2. 创建新的类库项目，按照上面步骤创建模块。
3. 编译项目，并把除框架dll及json外的所有文件复制到酷Q **app** 目录下面 **LoveKicher.ElectricRail.CoolQ** 目录中。

>注意事项

1. 目前暂不支持模块dll单独的`*.dll.config`文件。如果必需（例如使用EntityFramework），可以有以下替代方案：
    * 把文件重命名为`CQP.exe.config`(或CQA-)并放在酷Q根目录下面 。
    * 自己手工读写配置文件。