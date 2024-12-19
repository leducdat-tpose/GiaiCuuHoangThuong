using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPosition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag != Constants.PlayerTag) return;
        GameControlMain.Instance.SetGameState(GameState.Victory);
        this.gameObject.SetActive(false);
    }
}
