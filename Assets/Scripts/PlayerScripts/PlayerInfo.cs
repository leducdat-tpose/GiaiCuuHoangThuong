using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float MoveSpeed => _moveSpeed;
    [SerializeField]
    private float _moveSpeed;
    private int Strength => _strength;
    [SerializeField]
    private int _strength;
    private int Income => _income;
    [SerializeField]
    private int _income;

    public void UpgradeMoveSpeed()
    {

    }
    public void UpgradeStrength()
    {

    }
    public void UpgradeIncome()
    {
        
    }
}
