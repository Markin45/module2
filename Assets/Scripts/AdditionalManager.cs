using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalManager : SingletonMonoBehaviour<AdditionalManager>
{
    [SerializeField] Transform PointCharacter;

    List<Factory.Type_obj> List_Objs;
    List<GameObject> ActivAdditional;

    protected override void Awake()
    {
        base.Awake();

        List_Objs = Factory.Instance.Get_allObj_in_group(Factory.Type_group.Additional);
        ActivAdditional = new List<GameObject>();
    }


    private void Start()
    {
        StartCoroutine(AdditionalManager_cor());
    }

    IEnumerator AdditionalManager_cor()
    {
        while (true)
        {

            /// удаляем старые Additional если игрок ушёл на 15 футов
            for (var i = ActivAdditional.Count - 1; i >= 0; i--) 
                if (ActivAdditional[i].transform.position.x < PointCharacter.position.x - 15)
                {
                    Factory.Instance.SendToStore(ActivAdditional[i]);
                    ActivAdditional.RemoveAt(i);
                }

            yield return new WaitForSeconds(2.0f);
        }
    }


    public void Add_Additional(Vector3 pos)
    {
        var prefab = Factory.Instance.Get_prefab(List_Objs[Random.Range(0, List_Objs.Count)]);
        prefab.transform.localPosition = pos;
        ActivAdditional.Add(prefab);
    }


}
