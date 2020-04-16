using UnityEngine;


public sealed class GameController : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private Transform _pointSpawnCharacter;
    [SerializeField] private LevelPartSettings _levelPartSettings;

    private void Start()
    {
        _levelPartSettings.Generate();

        Instantiate(_characterPrefab, _pointSpawnCharacter.position, Quaternion.identity);
    }
}
