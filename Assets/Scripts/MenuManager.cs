using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadLVL1()
    {
        SceneManager.LoadScene(1);

    }
    public void LoadReplay()
    {
        SceneManager.LoadScene(2);

    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);

    }


}
