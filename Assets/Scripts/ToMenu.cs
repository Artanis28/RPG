﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
