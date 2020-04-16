using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D rigidBody2D;
    [SerializeField] TriggerDetector triggerDetector_left;
    [SerializeField] TriggerDetector triggerDetector_right;

    public float MoveForce;

    bool is_goRight = true;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (is_goRight && !triggerDetector_right.InTrigger) is_goRight = !is_goRight;
        if (!is_goRight && !triggerDetector_left.InTrigger) is_goRight = !is_goRight;


        if (is_goRight)
            rigidBody2D.AddForce(new Vector2(MoveForce, 0), ForceMode2D.Force);
        else
            rigidBody2D.AddForce(new Vector2(-MoveForce, 0), ForceMode2D.Force);

    }


}
