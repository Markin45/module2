using System;
using UnityEngine;
using Object = UnityEngine.Object;


public sealed class AdditionalObjectFactory
{
    private GameObject _saw;
    private GameObject _aidKit;
    private GameObject _coin;

    public GameObject GetAdditionalObject(AdditionalObjectType type)
    {
        GameObject prefab;
        switch (type)
        {
            case AdditionalObjectType.Saw:
                prefab = GetSaw();
                break;
            case AdditionalObjectType.AidKit:
                prefab = GetAidKit();
                break;
            case AdditionalObjectType.Coin:
                prefab = GetCoin();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        return Object.Instantiate(prefab);
    }

    private GameObject GetCoin()
    {
        if (!_coin)
        {
            _coin =
                Resources.Load<GameObject>
                    (AssetsPath.AdditionalObjects[AdditionalObjectType.Coin]);
        }

        return _coin;
    }

    private GameObject GetAidKit()
    {
        if (!_aidKit)
        {
            _aidKit =
                Resources.Load<GameObject>
                    (AssetsPath.AdditionalObjects[AdditionalObjectType.AidKit]);
        }

        return _aidKit;
    }

    private GameObject GetSaw()
    {
        if (!_saw)
        {
            _saw =
                Resources.Load<GameObject>
                    (AssetsPath.AdditionalObjects[AdditionalObjectType.Saw]);
        }

        return _saw;
    }
}
