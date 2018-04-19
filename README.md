# MBGParser
CrazyStrom 1.03 Data Parser

## 使用

```csharp
var mbgContent = System.IO.File.ReadAllText("东方蝶梦志真好玩.mbg");
var mbgData = MBGData.Parse(mbgContent);
```

## 示例MBG和其他的版本问题
某些较旧版本的解析可能出现问题，比如CS里自带的示例MBG文件（Example文件夹下）
解决方法是使用更新版本的CS打开并保存，再次进行解析即可解决。
本库所带的示例（Example文件夹下）为原CS自带的Example使用CS1.03I打开后再次保存的结果，如果直接去解析这些MBG，则会出现一些问题。


## 版本兼容
目前兼容的CS版本如下：
1.03 d
1.03 i

以上两个版本的MBG，版本号标签均为：
Crazy Storm Data 1.01

## 测试样例说明
测试样例来自于CrazyStorm自带的样例，对其使用1.03i版本重新保存的版本。
这些测试样例不属于本软件的一部分，不遵守本软件所使用的协议。
测试样例的著作权归其原作者所有，你在使用本库时不应该将其包含进去。

## 本库的其他版本
[Lua版本](https://github.com/Xrysnow/MBGParser) 作者：[Xrysnow](https://github.com/Xrysnow)

[Java版本](https://github.com/cn-s3bit/TH902/tree/master/MBGParser) 作者：[strongrex2001](https://github.com/strongrex2001)

感谢以上作者的辛勤付出。
