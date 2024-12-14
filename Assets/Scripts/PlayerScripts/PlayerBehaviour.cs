using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using Watermelon;

public class PlayerBehaviour : MonoBehaviour
{
    private PlayerInfo _playerInfo;
    private CapsuleCollider _collider;
    private Rigidbody _rigidbody;
    private Camera _mainCamera;
    private PlayerInput _playerInput;
    private CharacterController _controller;

    private void Start() {
        _playerInput = GetComponent<PlayerInput>();
        _controller = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
        _playerInfo = GetComponent<PlayerInfo>();
    }
    private void Update() {
        Vector2 input = _playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(move == Vector3.zero) return;
        Debug.Log(move);
        _controller.SimpleMove(move*_playerInfo.MoveSpeed);
    }
}
