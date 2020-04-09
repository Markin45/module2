using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Character : MonoBehaviour
{
    public Transform Visual;
    public float MoveForce;
    public float JumpForce;

    Rigidbody2D rigidBody2D;
    TriggerDetector triggerDetector;
    Animator animator;

    bool goLeft = false;
    bool goRight = false;

    private static readonly int HashSpeed = Animator.StringToHash("speed");

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        triggerDetector = GetComponentInChildren<TriggerDetector>();
        animator = GetComponentInChildren<Animator>();
    }

    public void MoveLeft_start() { goLeft = true; }
    public void MoveLeft_end() { goLeft = false; }
    public void MoveRight_start() { goRight = true; }
    public void MoveRight_end() { goRight = false; }

    public void JumpRight()
    {
        if (triggerDetector.InTrigger)
            rigidBody2D.AddForce(new Vector2(JumpForce, JumpForce), ForceMode2D.Impulse);
    }
    public void JumpLeft()
    {
        if (triggerDetector.InTrigger)
            rigidBody2D.AddForce(new Vector2(-JumpForce, JumpForce), ForceMode2D.Impulse);
    }


    private void Update()
    {
        float vel = rigidBody2D.velocity.x;

        Vector3 scale = Visual.localScale;

        float visualDirection = scale.x;
        if (vel < -0.01f) 
            visualDirection = -1.0f;
        else if (vel > 0.01f)
            visualDirection = 1.0f;
      
        scale.x = visualDirection;
        Visual.localScale = scale;

        animator.SetFloat(HashSpeed, Mathf.Abs(vel));

        if (goLeft)
            if (triggerDetector.InTrigger)
            {
                CameraManager.Instance.FirstStepCharacter();
                rigidBody2D.AddForce(new Vector2(-MoveForce, 0), ForceMode2D.Force);
            }

        if (goRight)
            if (triggerDetector.InTrigger)
            {
                CameraManager.Instance.FirstStepCharacter();
                rigidBody2D.AddForce(new Vector2(MoveForce, 0), ForceMode2D.Force);
            }
    }
}
