using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace GeometryDash.StateMachineSystem
{
    public class GameOverState : IState
    {
        private PlayerController _controller;
        private float _counter;
        private float _waitTime = 2f;
        private Action _onGameOver;
        private SpriteRenderer playerSprite;
        private Transform _transform;
        public GameOverState(Action OnGameOver, PlayerController controller)
        {
            _controller = controller;
            _transform = _controller.transform;
            _onGameOver = OnGameOver;
            playerSprite = _controller.GetComponentInChildren<SpriteRenderer>();
        }
        public void OnEnter()
        {
            _counter = 0f;
            playerSprite.enabled = false;
        }

        public void OnUpdate()
        {
            _counter += Time.deltaTime;

            if (_counter >= _waitTime)
                _onGameOver?.Invoke();
        }

        public void OnExit()
        {
            _counter = 0f;
            playerSprite.enabled = true;
            _transform.position = _controller.startPos;
        
        }
    }
}

