using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlavnoeMovePointForCamera : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.localPosition == Vector3.zero) return;

        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, Vector3.zero, Time.deltaTime * 15);


    }
}
