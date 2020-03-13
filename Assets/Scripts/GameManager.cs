using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    [SerializeField] GameObject Win_EndGame;


    public void Show_Win_EndGame()
    {
        Win_EndGame.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }


}
