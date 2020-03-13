using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    TriggerDetector triggerDetector;

    bool bool_EndGame = false;

    private void Awake()
    {
        triggerDetector = GetComponentInChildren<TriggerDetector>();
    }

    void Update()
    {
        if (!bool_EndGame)
            if (triggerDetector.InTrigger && triggerDetector.tag_Trigger == "Player")
            {
                GameManager.Instance.Show_Win_EndGame();
                bool_EndGame = true;
            }
    }


}
