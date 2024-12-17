using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlMain : MonoBehaviour
{
    [SerializeField]
    private MapGenerator _mapGenerator;

    private void Start() {
        _mapGenerator = GetComponent<MapGenerator>();
        _mapGenerator.GenerateMap();
    }
}
