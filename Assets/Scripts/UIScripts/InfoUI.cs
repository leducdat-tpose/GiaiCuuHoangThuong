using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _speedAttribute;
    public void Initialise() {
        UpdateTextSpeed();
        GameControlMain.Instance.UpgrageSpeedEvent.AddListener(UpdateTextSpeed);
    }
    public void UpdateTextSpeed()
    {
        int speedAttribute = Mathf.RoundToInt(GameControlMain.Instance.GetPlayerSpeed());
        _speedAttribute.text = speedAttribute.ToString();
    }
}
