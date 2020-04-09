using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    TriggerDetector triggerDetector;
    Rigidbody2D rigidBody2D;
    MovingPlatform movingPlatform;

    bool bool_Fall = false;

    private void Awake()
    {
        triggerDetector = GetComponentInChildren<TriggerDetector>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        movingPlatform = GetComponent<MovingPlatform>();
    }


    void Update()
    {
        if (!bool_Fall)
            if (triggerDetector.InTrigger && triggerDetector.tag_Trigger == "Player")
            {
                bool_Fall = true;
                //Invoke("fall", 1f);
                Invoke(nameof(fall), 1f);
            }
    }

    void fall()
    {
        rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
        movingPlatform.bool_moveStop = true;
        gameObject.layer = 8;
    }

}
