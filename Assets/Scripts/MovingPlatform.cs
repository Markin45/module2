using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] pointS;
    Transform start;
    Transform end;

    public bool bool_moveStop = false;

    public float speed;

    int n_point = 0;
    int tuda_obratno = 0; // 0-туда; 1-обратно

    private float current;  // от 0.0 до 1.0

    // Start is called before the first frame update
    void Start()
    {
        current = 0.0f;

        start = pointS[0];
        end = pointS[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (bool_moveStop) return;

        current += speed * Time.deltaTime;

        if (current >= 1f) // подошли к точки
        {
            current = 0f;

            if (tuda_obratno == 0) // идем туда
            {
                n_point++;
                if (n_point >= pointS.Length - 1) tuda_obratno = 1; // меняем
            }
            else // Идем обратно
            {
                n_point--;
                if (n_point <= 0) tuda_obratno = 0; // меняем
            }

            if (tuda_obratno == 0) // идем туда
            {
                start = pointS[n_point];
                end = pointS[n_point+1];
            }
            else // Идем обратно
            {
                start = pointS[n_point];
                end = pointS[n_point - 1];
            }

        }

        transform.position = Vector3.Lerp(start.position, end.position, current);
    }
}
