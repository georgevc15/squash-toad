using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour {

    public GameObject prefab;

    public float spawnIntervalMin = 2;
    public float spawnIntervalMax = 10;
    float nextSpwanTime = 0;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpwanTime)
        {
            Spawn();
            nextSpwanTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
	}


    void Spawn()
    {
        var instance = Instantiate(prefab, transform.position, transform.rotation, transform);
    }

}
