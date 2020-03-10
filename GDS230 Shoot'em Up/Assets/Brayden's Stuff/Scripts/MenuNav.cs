using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    // Handles Scene Changes
    public void Menu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Options()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Customize()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void Shop()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void Game()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    public void Credits()
    {
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }
}
