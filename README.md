# MBGParser
CrazyStrom 1.03 Data Parser

## Usage

```csharp
var mbgContent = System.IO.File.ReadAllText("东方蝶梦志真好玩.mbg");
var mbgData = MBGData.Parse(mbgContent);
```
