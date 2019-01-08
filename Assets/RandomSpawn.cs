using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {
    public GameObject[] prefabs;

    public float spawnRate = 2f;

    float nextSpawn = 0f;

    int whatToSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[whatToSpawn], transform.position, Quaternion.identity);
            nextSpawn = Time.time + spawnRate;
        }
	}
}
