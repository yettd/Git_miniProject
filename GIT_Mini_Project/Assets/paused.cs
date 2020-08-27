using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paused : MonoBehaviour
{
    public static bool gameispaused = false;
    public GameObject pausedmenuui;
    // Start is called before the first frame update
    void Start()
    {
        
        pausedmenuui.SetActive(false);
        print("notactive");


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Paused");
            if (gameispaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }

    }
    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void resume()
    {
        pausedmenuui.SetActive(false);
        Time.timeScale = 1f;
        gameispaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void pause()
    {
        pausedmenuui.SetActive(true);
        Time.timeScale = 0f;
        gameispaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
