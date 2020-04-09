using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : SingletonMonoBehaviour<CameraManager>
{

    enum TipeCam
    {
        begin,
        main,
        group,
    }

    TipeCam ActivCam;

    [SerializeField] CinemachineBrain _cinemachineBrain;

    [SerializeField] CinemachineVirtualCameraBase Camera_begin;
    [SerializeField] CinemachineVirtualCameraBase Camera_main;
    [SerializeField] CinemachineVirtualCameraBase Camera_group;


    CinemachineTargetGroup targetGroup;

    [SerializeField] GameObject TargetS_group_parent;
    [SerializeField] GameObject[] TargetS_group;
    int n_TargetS_group = 0;


    protected override void Awake()
    {
        base.Awake();

        Set_ActivCamera(TipeCam.begin);

        targetGroup = Camera_group.GetComponentInChildren<CinemachineTargetGroup>();

    }


    public void FirstStepCharacter()
    {
        if (ActivCam != TipeCam.begin) return;

        Set_ActivCamera(TipeCam.main);
    }

    public void Add_obj_to_group(GameObject target_gameObject)
    {
        if (ActivCam == TipeCam.begin) return;

        if (ActivCam != TipeCam.group)
            Set_ActivCamera(TipeCam.group);

        n_TargetS_group++;
        if (n_TargetS_group >= TargetS_group.Length)
            n_TargetS_group = 0;

        TargetS_group[n_TargetS_group].transform.parent = target_gameObject.transform;
        //TargetS_group[n_TargetS_group].transform.localPosition = Vector3.zero;

        //var target = new CinemachineTargetGroup.Target() { radius = 1f, weight = 1f, target = target_gameObject.transform };
        //targetGroup.m_Targets.Add(target);

    }

    public void Del_obj_to_group(GameObject target_gameObject)
    {
        bool is_allTargerInPlayer = true;

        foreach(var Target_group in TargetS_group)
        {
            if (Target_group.transform.parent == target_gameObject.transform)
            {
                Target_group.transform.parent = TargetS_group_parent.transform;
                //Target_group.transform.localPosition = Vector3.zero;
            }

            if (Target_group.transform.parent != TargetS_group_parent.transform) is_allTargerInPlayer = false;

        }

        if (is_allTargerInPlayer)
            Set_ActivCamera(TipeCam.main);

    }




    void Set_ActivCamera(TipeCam tipeCam)
    {
        Camera_begin.gameObject.SetActive(tipeCam == TipeCam.begin);
        Camera_main.gameObject.SetActive(tipeCam == TipeCam.main);
        Camera_group.gameObject.SetActive(tipeCam == TipeCam.group);

        ActivCam = tipeCam;
    }


}
