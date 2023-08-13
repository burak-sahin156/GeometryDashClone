using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeometryDash.Inputs;


namespace GeometryDash.StateMachineSystem
{
    public class HoldingState : IState
    {
        private IInputReader _reader;
        private PlayerController _controller;
        private Transform _transform;
        private Rigidbody2D rb;
        public HoldingState(IInputReader reader, PlayerController controller)
        {
            _reader = reader;
            _controller = controller;
            _transform = _controller.transform;
            rb = _transform.GetComponent<Rigidbody2D>();
        }
        public void OnEnter()
        {
             // sprite initialize
        }

        public void OnUpdate()
        {
            _transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 2);
            if (_reader.Hold)
            {
                rb.gravityScale = _controller.HoldStats.Gravity * -1;
            }
            else
            {
                rb.gravityScale = _controller.HoldStats.Gravity;
            }
        }

        public void OnExit()
        {
            rb.gravityScale = 12.41067f;
            _transform.rotation = Quaternion.identity;
        }


    }
}

