using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawnCat : MonoBehaviour
{
    [SerializeField]
    private float _radius;
    [SerializeField]
    private GameObject[] _prefab;

    private float _scale = 5f;
    private void Start() {
        
    }
    private void Update() {
        
    }

    public Vector3 SpawnCat()
    {
        GameObject prefab = Instantiate(_prefab[Random.Range(0, _prefab.Length)],PositionSpawn(), Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
        prefab.transform.localScale = new Vector3(_scale, _scale, _scale);
        prefab.transform.parent = this.transform;
        return prefab.transform.position;
    }

    public Vector3 PositionSpawn()
    {
        return transform.position + new Vector3(Random.Range(-_radius, _radius), 0, Random.Range(-_radius, _radius));
    }
}
