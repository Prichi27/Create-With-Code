using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public Button _restart;

    public bool isGameActive;


    [SerializeField] private int _lives = 1;
    [SerializeField] private Slider _volumeSlider;

    private float _spawnRate = 1f;
    private int _score = 0;

    private AudioSource _audioSource;

    private void Start()
    {
        livesText.text = $"Lives: {_lives}";
        _audioSource = GetComponent<AudioSource>();
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = "Score: " + _score;
    }

    public void UpdateLives()
    {
        if (!isGameActive) return;
        _lives--;
        livesText.text = $"Lives: {_lives}";
        if (_lives == 0) GameOver();
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        _restart.gameObject.SetActive(true);
        isGameActive = false;   
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;

        _score = 0;
        scoreText.text = "Score: " + _score;

        _spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
    }

    public void AdjustVolume(float value)
    {
        _audioSource.volume = value;
    }
}
