using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {
    public GameObject prefab1, prefab2, prefab3;

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
            whatToSpawn = Random.Range(1, 4);

            switch(whatToSpawn) {
                case 1:
                    Instantiate(prefab1, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(prefab2, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(prefab3, transform.position, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }
	}
}
