using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSwitcher : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    //public void playGame()//из стартового меню в игру
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//к текущему адресы сцены +1, и загружаем следующую сцену
    //}
    public void pauseGame()//остановить игру
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void resumeGame()//продолжить игру
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void openGame()//вернуться в стартовое меню
    {
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void quitGame()
    {
        Application.Quit();
    }

}
