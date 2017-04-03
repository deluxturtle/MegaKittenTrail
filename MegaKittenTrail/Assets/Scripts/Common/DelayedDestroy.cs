using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Destroys gameobject after delay.
/// </summary>
public class DelayedDestroy : MonoBehaviour {

    public float delay = 1f;

	// Use this for initialization
	void Start () {
        Invoke("DestroySelf", delay);
	}
	
    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
