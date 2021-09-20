using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Message : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Okay");
    }

    public void Exit()
    {
        Application.Quit();
    }


}
