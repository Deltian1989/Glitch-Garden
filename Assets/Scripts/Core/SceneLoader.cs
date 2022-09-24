using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float secondsOfDelay = 5;

    int currentSceneIndex;

    MusicPlayer musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
        else if (currentSceneIndex == 1 || currentSceneIndex == 2) { 
            musicPlayer.TurnOnMusic();
        }
        else
        {
            musicPlayer.StopMusic();
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(secondsOfDelay);

        LoadNextScene();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(3);
    }

    public void RestertScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(5);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
