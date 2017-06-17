using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour 
{
	public GameObject[] tilePrefabs;

	private Transform playerTransform;
	private float spawnZ = -6.0f;
	private float tileLength = 9.0f;
	private float safeZone = 15.0f;
	private int amnTileOnScreen = 7;
	private int lastPrefabIndex = 0;

	private List<GameObject> activeTiles;

	// Use this for initialization
	private void Start () {
		activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
	
		for (int i = 0; i < amnTileOnScreen; i++) 
		{
			SpawnTile ();
		}
	}
	
	// Update is called once per frame
	private void Update () {
		if (playerTransform != null) {
			if (playerTransform.position.z - safeZone > (spawnZ - amnTileOnScreen * tileLength)) {
				SpawnTile ();
				DeleteTile ();
			}
		} else {

		}

	}

	private void SpawnTile(int prefabIndex = -1)
	{
		GameObject go;
		go = Instantiate (tilePrefabs [RandomPrefabIndex()]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add (go);
	}

	private void DeleteTile()
	{
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);
	}

	private int RandomPrefabIndex()
	{
		if (tilePrefabs.Length <= 1)
			return 0;

		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex) 
		{
			randomIndex = Random.Range (0, tilePrefabs.Length);
		}

		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
}
