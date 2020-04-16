using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform PointCharacter;

    void Start()
    {
        StartCoroutine(CreateEnemy_cor());
    }

    IEnumerator CreateEnemy_cor()
    {
        while (true)
        {
            var prefab = Factory.Instance.Get_prefab(Factory.Type_obj.Enemy_1);
            prefab.transform.position = new Vector3(
                UnityEngine.Random.Range(PointCharacter.position.x - 10, PointCharacter.position.x + 10),
                UnityEngine.Random.Range(PointCharacter.position.y + 2, PointCharacter.position.y + 10),
                0f
                );

            StartCoroutine(CreateEnemy_cor2(prefab));

            yield return new WaitForSeconds(0.5f);
        }

    }

    IEnumerator CreateEnemy_cor2(GameObject prefab)
    {
        yield return new WaitForSeconds(7f);

        Factory.Instance.SendToStore(prefab);

    }

}
