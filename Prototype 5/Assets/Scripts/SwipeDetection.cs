using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class SwipeDetection : MonoBehaviour
{
    #region Serialized Field
    [Tooltip("Gets reference to Input Manager Asset")]
    [SerializeField]
    InputManager _inputManager;
    #endregion

    #region Properties
    private bool _isSwiping;

    private TrailRenderer _trail;
    private BoxCollider _box;

    private GameManager _gameManager;

    private Coroutine _coroutine;
    #endregion

    #region Callbacks

    private void Awake()
    {
        _trail = GetComponent<TrailRenderer>();
        _box = GetComponent<BoxCollider>();
        _gameManager = FindObjectOfType<GameManager>();

        _trail.enabled = false;
        _box.enabled = false;
    }

    private void OnEnable()
    {
        _inputManager.OnStartEvent += SwipeStart;
        _inputManager.OnEndEvent += SwipeEnd;
    }

    private void OnDisable()
    {
        _inputManager.OnStartEvent -= SwipeStart;
        _inputManager.OnEndEvent -= SwipeEnd;
    }
    #endregion

    private void SwipeStart()
    {
        if (!_gameManager.isGameActive) return;

        _isSwiping = true;

        UpdateTrail();

        _coroutine = StartCoroutine(UpdatePosition());
    }

    private IEnumerator UpdatePosition()
    {
        while (true)
        {
            transform.position = _inputManager.PrimaryPosition();
            yield return null;
        }
    }

    private void SwipeEnd()
    {
        if (!_gameManager.isGameActive) return;

        _isSwiping = false;

        UpdateTrail();

        StopCoroutine(_coroutine);
    }

    private void UpdateTrail()
    {
        _trail.enabled = _isSwiping;
        _box.enabled = _isSwiping;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Target target = collision.gameObject.GetComponent<Target>();

        if (target)
        {
            target.DestroyObject();
        }
    }
}
