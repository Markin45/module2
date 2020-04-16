using System.Collections.Generic;

public static class AssetsPath
{
    public static readonly Dictionary<PlatformType, string> Platforms =
        new Dictionary<PlatformType, string>
    {
        {PlatformType.Main, "Platforms/Platforms_Main"},
        {PlatformType.Short, "Platforms/Platforms_Short"},
    };

    public static readonly Dictionary<AdditionalObjectType, string> AdditionalObjects =
        new Dictionary<AdditionalObjectType, string>
        {
            {AdditionalObjectType.Saw, "Traps/Traps_Saw"},
            {AdditionalObjectType.AidKit, "Bonuses/Bonuses_AidKit"},
            {AdditionalObjectType.Coin, "Bonuses/Bonuses_Coin"},
        };
}
