using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Factory : SingletonMonoBehaviour<Factory>
{

    struct Struct_obj
    {
        public string AssetPath;
        public GameObject prefab;
        /* группа и т д*/
    }

    public enum Type_obj
    {
        not,
        Platf_1,
        Platf_2,
        Saw,
        AidKit,
        Coin,
    }

    readonly Dictionary<Type_obj, Struct_obj> Dictionary_obj = new Dictionary<Type_obj, Struct_obj>
    {
        {Type_obj.Platf_1, new Struct_obj{ AssetPath = "Platf/Platf_1"} },
        {Type_obj.Platf_2, new Struct_obj{ AssetPath = "Platf/Platf_2"} },
        {Type_obj.Saw, new Struct_obj{ AssetPath = "Traps/Traps_Saw"} },
        {Type_obj.AidKit, new Struct_obj{ AssetPath = "Bonuses/Bonuses_AidKit"} },
        {Type_obj.Coin, new Struct_obj{ AssetPath = "Bonuses/Bonuses_Coin"} },
    };



    public GameObject Get_prefab(Type_obj type_Obj)
    {
        var struct_obj = Dictionary_obj[type_Obj];

        if (struct_obj.prefab == null)
            struct_obj.prefab = Resources.Load<GameObject>(struct_obj.AssetPath);

        return Instantiate(struct_obj.prefab);
    }

}
