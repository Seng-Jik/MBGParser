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

## 协议特殊说明

仅在以下情况下，本程序库的使用遵循MIT协议：
嵌入至STG游戏

在遵循此协议发布的游戏中应当包含MIT协议的License文件。

其他任何情况均遵守GPL-2.0协议。

