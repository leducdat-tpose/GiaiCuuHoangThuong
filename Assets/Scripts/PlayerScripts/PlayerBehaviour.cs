using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;
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
    private PlayerInfo _playerInfo;
    private CapsuleCollider _collider;
    private Rigidbody _rigidbody;
    private Camera _mainCamera;
    private PlayerInput _playerInput;
    private CharacterController _controller;
    [SerializeField]
    [ReadOnlyField]
    private PlayerState _currentState;

    private void Start() {
        _playerInput = GetComponent<PlayerInput>();
        _controller = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
        _playerInfo = GetComponent<PlayerInfo>();

        _currentState = PlayerState.Idle;
    }
    private void Update() {
        MoveThroughJoystick();
    }

    public void MoveThroughJoystick()
    {
        if(_currentState == PlayerState.GameOver) return;
        Vector2 input = _playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        if(move == Vector3.zero) return;
        _controller.SimpleMove(move*_playerInfo.MoveSpeed);
    }

    public void MoveThroughTap()
    {

    }

    public void SetPlayerGameOver()
    {
        _currentState = PlayerState.GameOver;
        Debug.Log("Gameover");
    }
}   
