using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawnCat : MonoBehaviour
{
    [SerializeField]
    private float _radius;
    [SerializeField]
    private GameObject _prefab;
    private void Start() {
        
    }
    private void Update() {
        
    }

    public Vector3 PositionSpawn()
    {
        return transform.position + new Vector3(Random.Range(-_radius, _radius), 0, Random.Range(-_radius, _radius));
    }
}
