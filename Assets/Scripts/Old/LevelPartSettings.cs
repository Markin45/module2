using UnityEngine;
using Random = UnityEngine.Random;


[CreateAssetMenu(fileName = "LevelPartSettingsData",
    menuName = "Data/LevelSettings/LevelPartSettingsData")]
public sealed class LevelPartSettings : ScriptableObject
{
    [SerializeField] [Range(1, 100)] private int _countPlatform;
    [SerializeField] private bool _isGenerateLastPlatform;
    [SerializeField] private PlatformData _firstPlatform;
    [SerializeField] private PlatformData[] _platforms;
    private PlatformFactory _platformFactory;
    private AdditionalObjectFactory _additionalObjectFactory;
    private Vector3 _position;
    private Transform _root;

    private void OnEnable()
    {
        _platformFactory = new PlatformFactory();
        _additionalObjectFactory = new AdditionalObjectFactory();
        _position = Vector3.zero;
    }

    public void Generate()
    {
        _root = new GameObject("Root").transform;
        GeneratePlatform(_firstPlatform);
        for (var i = 1; i <= _countPlatform; i++)
        {
            PlatformData platform = _platforms[Random.Range(0, _platforms.Length)];
            GeneratePlatform(platform);
        }

        if (_isGenerateLastPlatform)
        {
            PlatformBehaviour child = _root.GetChild(_root.childCount - 1).GetComponent<PlatformBehaviour>();
            child.GenerateNewPart();
        }
    }

    private void GeneratePlatform(PlatformData platformData)
    {
        var platform = _platformFactory.GetPlatform(platformData.Type);
        platform.transform.position = _position;
        _position = new Vector3(_position.x + platform.GetBorder() +
                                Random.Range(platformData.RandomMargin.Min, platformData.RandomMargin.Min),
            Random.Range(platformData.RandomHeight.x, platformData.RandomHeight.y));
        platform.transform.parent = _root;

        if (platformData.AdditionalObjectData.CreationProbability > Random.Range(0, 100))
        {
            GameObject additionalObject = _additionalObjectFactory.GetAdditionalObject(platformData.AdditionalObjectData.Type);
            additionalObject.transform.position = platform.GetPointSpawnAdditionalObject();
            additionalObject.transform.parent = platform.transform;
        }
    }
}
