using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void Quit()
    {
        Application.Quit();
    }

    // Handles Scene Changes
    public void Menu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadingScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadPreviousLevel()
    {
        StartCoroutine(LoadingScene(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void LoadPlayLevel()
    {
        StartCoroutine(LoadingScene(SceneManager.GetActiveScene().buildIndex + 4));
    }

    public void LoadInventory()
    {
        StartCoroutine(LoadingScene(SceneManager.GetActiveScene().buildIndex + 7));
    }

    public void BackCredits()
    {
        StartCoroutine(LoadingScene(SceneManager.GetActiveScene().buildIndex - 4));
    }

    public void LoadCredits()
    {
        StartCoroutine(LoadingScene(SceneManager.GetActiveScene().buildIndex + 4));
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadingScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadStore()
    {
        StartCoroutine(LoadingScene(SceneManager.GetActiveScene().buildIndex + 3));
    }

    IEnumerator LoadingScene(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}
