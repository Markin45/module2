using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateEnemy : MonoBehaviour
{
    [SerializeField] GameObject pref_emeny;


    void Start()
    {
        StartCoroutine(CreateEnemy_cor());
    }



    IEnumerator CreateEnemy_cor()
    {
        while (true)
        {
            var clon = Instantiate(pref_emeny, new Vector3(Random.Range(-13, 18), Random.Range(0, 13), 0f), Quaternion.identity);

            Destroy(clon, 7);

            yield return new WaitForSeconds(0.5f);
        }

    }


}
