using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad=4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    MusicPlayer musicPlayer;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        musicPlayer=FindObjectOfType<MusicPlayer>();
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        loseLabel.GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
    }

    public void SetTimeScale(int timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        FindObjectOfType<AttackerSpawner>().StopSpawning();
    }
}
