using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] GameObject _titleScreen;
    [SerializeField] int _difficulty;

    private Button _button;
    private GameManager _gameManager;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);

        _gameManager = FindObjectOfType<GameManager>();
    }

    private void SetDifficulty()
    {
        Debug.Log($"{gameObject.name} was clicked");
        _titleScreen.SetActive(false);
        _gameManager.StartGame(_difficulty);
    }
}
