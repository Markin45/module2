using System;
using UnityEngine;
using Object = UnityEngine.Object;


public sealed class PlatformFactory
{
    private PlatformBehaviour _mainPlatform;
    private PlatformBehaviour _shortPlatform;

    public PlatformBehaviour GetPlatform(PlatformType type)
    {
        PlatformBehaviour prefab;
        switch (type)
        {
            case PlatformType.Main:
                prefab = GetMainPlatform();
                break;
            case PlatformType.Short:
                prefab = GetShortPlatform();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        return Object.Instantiate(prefab);
    }


    private PlatformBehaviour GetShortPlatform()
    {
        if (!_shortPlatform)
        {
            _shortPlatform =
                Resources.Load<PlatformBehaviour>
                    (AssetsPath.Platforms[PlatformType.Short]);
        }

        return _shortPlatform;
    }


    private PlatformBehaviour GetMainPlatform()
    {
        if (!_mainPlatform)
        {
            _mainPlatform =
                Resources.Load<PlatformBehaviour>
                    (AssetsPath.Platforms[PlatformType.Main]);
        }

        return _mainPlatform;
    }
}
