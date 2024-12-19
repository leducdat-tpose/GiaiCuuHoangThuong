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
        GameControlMain.Instance.StartPlayGame.AddListener(StartTsunami);
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
        GameControlMain.Instance.SetGameState(GameState.GameOver);
        _moveSpeed = 0;
    }

    public void StartTsunami()
    {
        StartCoroutine("SimulatorTsunami");
    }

    public void SetMoveSpeed(float speed)
    {
        _moveSpeed = speed;
    }

    IEnumerator SimulatorTsunami()
    {
        yield return new WaitForSeconds(Constants.TsunamiTimet0);
        SetMoveSpeed(Constants.TsunamSpeedv1);
        yield return new WaitForSeconds(Constants.TsunamiTimet1);
        SetMoveSpeed(Constants.TsunamSpeedv2);
        yield return null;
    }
}
