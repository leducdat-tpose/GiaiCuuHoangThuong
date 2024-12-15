using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class TsunamiBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private BoxCollider _collider;

    private void Start() {
        _collider = GetComponent<BoxCollider>();
    }
    
    private void Update() {
        Move();
    }

    public void Move()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag != Constants.PlayerTag) return;
        var playerBehave = other.GetComponent<PlayerBehaviour>();
        playerBehave.SetPlayerGameOver();
    }
}
