using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPlatform : MonoBehaviour
{
    SliderJoint2D joint;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<SliderJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Тут захардкожено для примера. В реальных проектах так делать не надо.
        Vector3 pos = transform.position;
        JointMotor2D motor = joint.motor;
        if (pos.x < -6.8)
            motor.motorSpeed = 1;
        else if (pos.x > -3)
            motor.motorSpeed = -1;
        joint.motor = motor;
    }
}
