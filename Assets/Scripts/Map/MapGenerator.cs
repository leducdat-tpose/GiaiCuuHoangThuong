using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum Drawmode{NoiseMap, ColorMap}

    // public Drawmode DrawMode;
    public int MapWidth;
    public int MapHeight;
    public float NoiseScale;
    public int Octaves;
    [Range(0, 1)]
    public float Persistance;
    public float Lacunarity;

    public int Seed;
    public Vector2 Offset;

    public bool AutoUpdate;

    public GameObject StorageObjectSpawned;
    public GameObject AnimalSpawnPositions;
    private Vector3[] _animalPositions;
    public GameObject[] ObstaclePrefabs;
    [Range(0,1)]
    public float Threshold;
    public GroundType[] GroundTypes;
    public void GenerateMap()
    {
        float [,] noiseMap = Noise.GenerateNoiseMap(MapWidth, MapHeight,Seed, NoiseScale,Octaves,Persistance,Lacunarity,Offset);
        
        // Color[] colorMap = new Color[MapWidth * MapHeight];
        // for(int y = 0; y < MapHeight; y++)
        // {
        //     for(int x = 0; x < MapWidth; x++)
        //     {
        //         float currentHeight = noiseMap[x,y];
        //         for(int i = 0; i < GroundTypes.Length; i++)
        //         {
        //             if(currentHeight <= GroundTypes[i].Height){
        //                 colorMap[y * MapWidth + x] = GroundTypes[i].color;
        //                 break;}
        //         }
        //     }
        // }
        
        // MapDisplay display = FindObjectOfType<MapDisplay>();
        // if(DrawMode == Drawmode.NoiseMap)
        // {
        //     display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        // }
        // else {
        //     display.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, MapWidth, MapHeight));
        // }

        CleanStorage();
        GenerateAnimal();

        for(int y = 0; y < MapHeight; y++)
        {
            for(int x = 0; x < MapWidth; x++)
            {
                float noiseValue = noiseMap[x,y];
                if(noiseValue < Threshold) continue;
                float randomNum = Random.value;
                if(randomNum < noiseValue) continue;
                Vector3 obstacleSpawnPosition = new Vector3(x*10f, 0f, y*10f);
                if(_animalPositions.Contains(obstacleSpawnPosition)) continue;
                GameObject newObstacle = Instantiate(ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)], obstacleSpawnPosition, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
                newObstacle.transform.localScale = new Vector3(5f, 5f, 5f);
                newObstacle.transform.parent = StorageObjectSpawned.transform;
            }
        }
    }

    void OnValidate() {
		if (MapWidth < 1) {
			MapWidth = 1;
		}
		if (MapHeight < 1) {
			MapHeight = 1;
		}
		if (Lacunarity < 1) {
			Lacunarity = 1;
		}
		if (Octaves < 0) {
			Octaves = 0;
		}
	}
    
    [System.Serializable]
    public struct GroundType{
        public string name;
        public float Height;
        public Color color;
    }

    private void CleanStorage()
    {
        if(!StorageObjectSpawned)
        {
            Debug.LogWarning("Not having object to storage spawn object!");
            return;
        }
        foreach(Transform child in StorageObjectSpawned.transform)
        {
            Destroy(child);
        }
    }

    private void GenerateAnimal()
    {
        if(!AnimalSpawnPositions)
        {
            Debug.LogWarning("Not having AnimalSpawnPositions object!");
            return;
        }
        _animalPositions = new Vector3[AnimalSpawnPositions.transform.childCount];
        int i = 0;
        foreach(Transform child in AnimalSpawnPositions.transform)
        {
            AreaSpawnCat script = child.gameObject.GetComponent<AreaSpawnCat>();
            _animalPositions[i] = script.SpawnCat();
            i++;
        }
    }
}
