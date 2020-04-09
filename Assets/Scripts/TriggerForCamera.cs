using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForCamera : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        CameraManager.Instance.Add_obj_to_group(gameObject);
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        CameraManager.Instance.Del_obj_to_group(gameObject);
    }

}
