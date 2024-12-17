using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;

public class CheckingColliderAnimal : MonoBehaviour
{
    [SerializeField]
    private BoxCollider _collider;

    private PlayerInfo _playerInfo;
    private void Start() {
        _collider = GetComponent<BoxCollider>();
        _playerInfo = transform.root.GetComponent<PlayerInfo>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag != Constants.AnimalTag) return;
        AnimalBehaviour behaviour = other.transform.GetComponent<AnimalBehaviour>();
        behaviour.FollowPlayer(_playerInfo);
    }
}
