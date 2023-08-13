using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeometryDash.StateMachineSystem;
using GeometryDash.Inputs;
using System;

public class PlayerController : MonoBehaviour
{
    public StateMachine stateMachine;
    public IState jumpingPlayMode;
    public IState holdingPlayMode;
    public IState gameOverState;
    public PlayerJumpStats JumpStats;
    public PlayerHoldStats HoldStats;
    public IInputReader reader;
    public Transform GroundCheck;
    public Transform platform;
    private bool canJump;

    public Action HasLanded;
    public static event Action OnGameOver;
    [HideInInspector]
    public Vector3 startPos;
    private void Start()
    {
        reader = new InputReader();
        stateMachine = new StateMachine();
        jumpingPlayMode = new JumpingState(reader, this);
        holdingPlayMode = new HoldingState(reader, this);
        gameOverState = new GameOverState(OnGameOver, this);

        canJump = true;

        stateMachine.AddStateTransition(jumpingPlayMode, holdingPlayMode, () => canJump == false);
        stateMachine.AddStateTransition(holdingPlayMode, jumpingPlayMode, () => canJump == true);
        stateMachine.AddStateTransition(gameOverState, jumpingPlayMode, () => !GameManager.Instance.isGameOver && canJump);
        stateMachine.AddAnyStateTransition(gameOverState, () => GameManager.Instance.isGameOver);

        stateMachine.Initialize(jumpingPlayMode);

        startPos = transform.position;
    }

    private void Update()
    {
        reader.ReadInput();
        stateMachine.RunMachine();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Obstacles"))
        {
            GameManager.Instance.isGameOver = true;
            canJump = true;
        }

        if (other.transform.CompareTag("FinishLine"))
        {
            GameManager.Instance.LevelSuccess();
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayModeChanger"))
        {
            canJump = !canJump;
        }
    }
}
