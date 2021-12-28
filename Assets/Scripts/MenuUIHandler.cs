using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{

    public void StartNew()
    {
        if (UIManager.Instance.NameInput != null)
            UIManager.Instance.CurrentPlayerName = UIManager.Instance.NameInput.text;
        SceneManager.LoadScene(1);
    }

    public void HighScore()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
