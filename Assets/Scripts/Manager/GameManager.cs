using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector]
    public bool isGameOver = false;
    private Transform _transform;
    private Vector3 startPos;
    [SerializeField] GameObject SuccessPanel;
    private void OnEnable()
    {
        PlayerController.OnGameOver += RestartGame;
    }

    private void OnDisable()
    {
        PlayerController.OnGameOver -= RestartGame;
    }
    private void Awake()
    {
        _transform = transform;
        startPos = _transform.position;
    }
    private void Update()
    {
        if (!isGameOver)
            _transform.Translate(Vector3.left * 20f * Time.deltaTime);
    }

    public void RestartGame()
    {
        _transform.position = startPos;
        isGameOver = false;
    }

    public void LevelSuccess()
    {
        SuccessPanel.SetActive(true);
    }
}
