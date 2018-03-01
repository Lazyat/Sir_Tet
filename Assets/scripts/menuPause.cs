using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPause : MonoBehaviour
{

    private bool isPaused = false;
    private GameObject canvas;

    void Run()
    {
        canvas = GameObject.Find("Menu");

        Debug.Log(GameObject.Find("Menu").ToString());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            onGui();
        }
        else
            Time.timeScale = 1f;
    }

    public void Resume()
    {
        isPaused = !isPaused;
    }

    public void Restart()
    {
        SceneManager.LoadScene("sceneTest");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
