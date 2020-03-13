using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public bool InTrigger;
    public string tag_Trigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InTrigger = true;
        tag_Trigger = collision.tag;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        InTrigger = true;
        tag_Trigger = collision.tag;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InTrigger = false;
    }
}
