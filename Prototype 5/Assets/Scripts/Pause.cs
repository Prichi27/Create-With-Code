using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject _pauseScreen;
    [SerializeField] AudioSource _audio;

    public bool IsGamePaused { get; set; } = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) PauseGame();
    }
    private void PauseGame()
    {
        IsGamePaused = !IsGamePaused;

        if (IsGamePaused)
        {
            Time.timeScale = 0;
            _audio.Pause();
            _pauseScreen.SetActive(true);
        }

        else
        {
            Time.timeScale = 1;
            _audio.Play();
            _pauseScreen.SetActive(false);
        }
    }
}
