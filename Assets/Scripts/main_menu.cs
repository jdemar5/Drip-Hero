using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class main_menu : MonoBehaviour
{
    
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
    
    public void quit()
    {
        Application.Quit();
    }
    
    public void level_one()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void level_two()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void level_three()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }

    public void level_four()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1f;
    }
}
