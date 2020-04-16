using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfManager : SingletonMonoBehaviour<PlatfManager>
{
    [SerializeField] Transform PointNextPlatform;
    [SerializeField] Transform PointCharacter;

    List<Factory.Type_obj> List_Objs;

    List<GameObject> ActivPlatformS;

    protected override void Awake()
    {
        base.Awake();

        List_Objs = Factory.Instance.Get_allObj_in_group(Factory.Type_group.Platform);
        ActivPlatformS = new List<GameObject>();
    }

    private void Start()
    {
        StartCoroutine(PlatfManager_cor());
    }

    IEnumerator PlatfManager_cor()
    {
        while (true)
        {
            /// добавляем новые платформы если игрок подошёл на 15 футов
            while (PointCharacter.position.x + 15 > PointNextPlatform.position.x)
                CreatPlatform();

            /// удаляем старые платформы если игрок ушёл на 15 футов
            for(var i = ActivPlatformS.Count - 1; i >= 0; i--) // придумал вариант что если идти в обратном направление то можно прям из цикла удалять ненужные объекты
                if (ActivPlatformS[i].transform.position.x < PointCharacter.position.x - 15)
                {
                    Factory.Instance.SendToStore(ActivPlatformS[i]);
                    ActivPlatformS.RemoveAt(i);
                }
            

            yield return new WaitForSeconds(1.0f);
        }
    }



    public void CreatPlatform()
    {
        var prefab = Factory.Instance.Get_prefab(List_Objs[Random.Range(0, List_Objs.Count)]);
        prefab.transform.localPosition = PointNextPlatform.localPosition;
        ActivPlatformS.Add(prefab);


        /// добавим случайную Additional
        if (Random.Range(0, 2) == 0)
            AdditionalManager.Instance.Add_Additional(new Vector3(PointNextPlatform.localPosition.x, PointNextPlatform.localPosition.y + 1, 0));


        /// определим куда нужно передвинуть точку PointNextPlatform
        GameObject Right_gameObject = null;
        float xMax = -1000f;
        for (int i = 0; i < prefab.transform.childCount; i++)
        {
            var child = prefab.transform.GetChild(i).gameObject;
            if (xMax < child.transform.position.x)
            {
                xMax = child.transform.position.x;
                Right_gameObject = child;
            }
        }

        if (Right_gameObject == null) return;

        float offsetX = 0;

        var Renderer = Right_gameObject.GetComponent<Renderer>();
        if (Renderer != null)
            offsetX = Renderer.bounds.extents.x;

        PointNextPlatform.position = new Vector3(Right_gameObject.transform.position.x + offsetX, Right_gameObject.transform.position.y, 0f);

    }


}

