using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Factory : SingletonMonoBehaviour<Factory>
{
    public enum Type_group
    {
        not,
        Platform,
        Additional,
        emeny,
    }

    struct Struct_obj
    {
        public string AssetPath;
        public GameObject prefab;
        public Type_group type_Group;
        public List<GameObject> store_prefab;

        public Struct_obj(string AssetPath, Type_group type_Group)
        {
            this.AssetPath = AssetPath;
            this.type_Group = type_Group;
            prefab = null;
            store_prefab = new List<GameObject>();
        }
    }

    public enum Type_obj
    {
        not,
        Platf_1,
        Platf_2,
        Platf_3,
        Platf_4,
        Platf_5,
        Saw,
        AidKit,
        Coin,
    }

    readonly Dictionary<Type_obj, Struct_obj> Dictionary_obj = new Dictionary<Type_obj, Struct_obj>
    {
        {Type_obj.Platf_1, new Struct_obj("Platf/Platf_1", Type_group.Platform) },
        {Type_obj.Platf_2, new Struct_obj("Platf/Platf_2", Type_group.Platform) },
        {Type_obj.Platf_3, new Struct_obj("Platf/Platf_3", Type_group.Platform) },
        {Type_obj.Platf_4, new Struct_obj("Platf/Platf_4", Type_group.Platform) },
        {Type_obj.Platf_5, new Struct_obj("Platf/Platf_5", Type_group.Platform) },

        {Type_obj.Saw, new Struct_obj("Traps/Traps_Saw", Type_group.Additional) },
        {Type_obj.AidKit, new Struct_obj("Bonuses/Bonuses_AidKit", Type_group.Additional) },
        {Type_obj.Coin, new Struct_obj("Bonuses/Bonuses_Coin", Type_group.Additional) },
    };



    public GameObject Get_prefab(Type_obj type_Obj)
    {
        var struct_obj = Dictionary_obj[type_Obj];

        /// либа из стора
        if (struct_obj.store_prefab.Count > 0)
        {
            var clon_prefab = struct_obj.store_prefab[struct_obj.store_prefab.Count - 1];
            struct_obj.store_prefab.RemoveAt(struct_obj.store_prefab.Count - 1);
            clon_prefab.SetActive(true);

            return clon_prefab;
        };

        // если нет в кэши создаем
        if (struct_obj.prefab == null)
            struct_obj.prefab = Resources.Load<GameObject>(struct_obj.AssetPath);

        // ставим месту что за тип
        var clon_prefab2 = Instantiate(struct_obj.prefab);
        var factoryMetka = clon_prefab2.AddComponent<FactoryMetka>();
        factoryMetka.type_Obj = type_Obj;

        return clon_prefab2;
    }

    /// <summary>
    /// возвращаем все типы объектов из некой группы
    /// </summary>
    public List<Type_obj> Get_allObj_in_group(Type_group type_Group)
    {
        var list = new List<Type_obj>();

        foreach(var obj in Dictionary_obj)
            if (obj.Value.type_Group == type_Group)
                list.Add(obj.Key);

        return list;
    }


    /// <summary>
    /// Отправляем Клон на Склад
    /// </summary>
    public void SendToStore(GameObject clon)
    {
        clon.SetActive(false);

        var factoryMetka = clon.GetComponent<FactoryMetka>();
        var struct_obj = Dictionary_obj[factoryMetka.type_Obj];
        struct_obj.store_prefab.Add(clon);
    }


}
