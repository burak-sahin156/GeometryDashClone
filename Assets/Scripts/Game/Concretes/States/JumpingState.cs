using System.Collections;
using System.Collections.Generic;
using GeometryDash.Inputs;
using UnityEngine;


namespace GeometryDash.StateMachineSystem
{
    public class JumpingState : IState
    {
        private PlayerController _controller;
        private IInputReader _reader;
        private Transform _transform;
        private Transform playerSprite;

        private bool isGrounded;
        private Rigidbody2D rb;

        public JumpingState(IInputReader reader, PlayerController controller)
        {
            _reader = reader;
            _controller = controller;
            _transform = _controller.transform;
            rb = _transform.GetComponent<Rigidbody2D>();
            playerSprite = _transform.FindDeepChild("Sprite");
        }
        public void OnEnter()
        {

        }

        public void OnUpdate()
        {
            isGrounded = Physics2D.OverlapCapsule(
                _controller.GroundCheck.position,
                new Vector2(1.6f, 0.4f),
                CapsuleDirection2D.Horizontal,
                0,
                _controller.JumpStats.GroundLayer
            );

            if (isGrounded)
            {
                Vector3 rotation = playerSprite.rotation.eulerAngles;
                rotation.z = Mathf.Round(rotation.z / 90) * 90;
                playerSprite.rotation = Quaternion.Euler(rotation);

                if (_reader.Click)
                {
                    rb.velocity = Vector2.zero;
                    rb.AddForce(Vector2.up * 26.6581f * 1.5f, ForceMode2D.Impulse);
                }

                _controller.HasLanded?.Invoke();
            }
            else
            {
                playerSprite.Rotate(Vector3.back , 452.4152186f * 1.5f * Time.deltaTime);
            }
        }

        public void OnExit()
        {

        }
    }
}

