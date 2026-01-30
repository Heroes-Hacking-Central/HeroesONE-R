# HeroesONE-R

HeroesONE-R is a C# library that can read/write .ONE files from Sonic Heroes (2003/2004) and Shadow The Hedgehog (2005).
This version uses [prs-rs](https://github.com/Sewer56/prs-rs) for PRS decompression/compression and should be used over the other releases in most cases.

## Usage Example

```csharp
var oneFile = "example.one"; // path to a .one file
ONEArchiveType archiveType = ONEArchiveTester.GetArchiveType(ref oneData);
var oneDataContent = Archive.FromONEFile(ref oneData);
// ...
// edit content, in this case replacing the data of the first file in the .one, but persisting the internal name and RW metadata
datOneDataContent.Files[0].CompressedData = Prs.CompressData(contentEdited).ToArray();
// ...
var updatedDatOneData = datOneDataContent.BuildShadowONEArchive(archiveType == ONEArchiveType.Shadow060);
File.WriteAllBytes("example-edited.one", updatedDatOneData.ToArray());
```

## Example Projects

This library was primarily written for [HeroesONE-Reloaded](https://github.com/Sewer56/HeroesONE-Reloaded), a WinForms GUI frontend for editing ONE archives.
That repo contains the history of the prior HeroesONE project, and also houses the .NET Framework version of this library using csharp-prs.

[ShadowRando](https://github.com/ShadowTheHedgehogHacking/ShadowRando) - A Shadow the Hedgehog Randomizer, leverages this library to read .ONE files to replace spline data.
[HeroesPowerPlant](github.com/igorseabra4/HeroesPowerPlant) - A full level editor for Sonic Heroes and Shadow the Hedgehog, leverages this library for getting and editing game assets such as geometry, collision, models, and more.