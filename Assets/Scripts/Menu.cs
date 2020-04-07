using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnMenuClick()
    {
        SceneManager.LoadScene("DesertWorld");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
