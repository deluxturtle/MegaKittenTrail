using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Spawns rats off screen for you to catch!
/// </summary>
public class RatSpawner : MonoBehaviour {

    public float spawnChance;//Chance every repeate rate to spawn.
    [Tooltip("In seconds the delay between trying to spawn.")]
    public float repeatRate;//Everytime we will call the spawn chancer.
    [Tooltip("In seconds the delay between spawns.")]
    public float cooldown;//After spawning this will be a buffer between spawns.
    public GameObject rat;//Make it a list if there will be multiple rats.
    public Transform spawnPoint;//Place off screen to spawn rats

	// Use this for initialization
	void Start ()
    {
        StartSpawn();
    }

    /// <summary>
    /// Starts the repeating chance thing!
    /// </summary>
    void StartSpawn()
    {
        InvokeRepeating("ChanceToSpawn", 0, repeatRate);
    }

    /// <summary>
    /// Based on the spawn chance will spawn a rat then a cooldown takes place
    /// that will then restart the process every repeate rate.
    /// </summary>
    void ChanceToSpawn()
    {
        if (rat.GetComponent<Rat>().spawnable)
        {
            float rand = Random.Range(0, 100) / 100f;
        
            if(rand <= spawnChance)
            {
                Debug.Log("Spawned Rat!");
                rat.transform.position = spawnPoint.position + (Vector3)Random.insideUnitCircle;
                rat.GetComponent<Rat>().MoveAcrossScreen();
                CancelInvoke("ChanceToSpawn");
                Invoke("StartSpawn", cooldown);//CoolDown after spawn
            }
        }
    }
	
}
