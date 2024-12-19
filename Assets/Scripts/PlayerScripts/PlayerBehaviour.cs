using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Watermelon;

public enum PlayerState{
    Idle,
    Walk,
    Run,
    GameOver
}

public class PlayerBehaviour : MonoBehaviour
{
    public static readonly int RUN_HASH = Animator.StringToHash("Run");
    public static readonly int MOVEMENT_MULTIPLIER_HASH = Animator.StringToHash("Movement Multiplier");
    private PlayerInfo _playerInfo;
    private PlayerInput _playerInput;
    private CharacterController _controller;
    private NavMeshAgent _agent;
    private Animator _animator;

    [SerializeField]
    private float _rotationFactorPerFrame;

    [SerializeField]
    [ReadOnlyField]
    private PlayerState _currentState;

    private void Start() {
        _playerInput = GetComponent<PlayerInput>();
        _agent = GetComponent<NavMeshAgent>();
        _controller = GetComponent<CharacterController>();
        _playerInfo = GetComponent<PlayerInfo>();
        _animator = GetComponentInChildren<Animator>();
        _currentState = PlayerState.Idle;
    }

    private Vector2 GetInputValue() 
    => _playerInput.actions["Move"].ReadValue<Vector2>().normalized;

    private void Update() {
        StateManager();
        MoveThroughJoystick();
        ControlRotate();
        ControlAnimator();
    }

    public void MoveThroughJoystick()
    {
        if(_currentState != PlayerState.Run) return;
        Vector2 input = GetInputValue();
        Vector3 movementVector = new Vector3(input.x, 0, input.y);
        _controller.SimpleMove(movementVector*_playerInfo.MoveSpeed);
    }
    public void MoveThroughTap()
    {

    }

    private void StateManager()
    {
        if(_currentState == PlayerState.GameOver) return;
        if(GetInputValue() == Vector2.zero) _currentState = PlayerState.Idle;
        else _currentState = PlayerState.Run;
    }

    private void ControlAnimator()
    {
        if(_currentState == PlayerState.Run)
            _animator.SetBool(RUN_HASH, true);
        else _animator.SetBool(RUN_HASH, false);
        Vector2 input = GetInputValue();
        _animator.SetFloat(MOVEMENT_MULTIPLIER_HASH, Mathf.Max(Mathf.Abs(input.x), Mathf.Abs(input.y)));
    }

    private void ControlRotate()
    {
        if(_currentState != PlayerState.Run) return;
        Vector2 input = GetInputValue();
        Vector3 positionToLookAt = new Vector3(input.x, 0f, input.y);
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
        transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame);
    }

    public void SetPlayerGameOver()
    {
        _currentState = PlayerState.GameOver;
        Debug.Log("Gameover");
    }
}   
