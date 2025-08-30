using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGUIManager : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("SpaceInvaders");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
