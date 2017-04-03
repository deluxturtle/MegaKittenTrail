using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Base class for enemies.
/// </summary>
public class Enemy : MonoBehaviour {

    int health = 1;

	//// Use this for initialization
	//void Start (){
		
	//}
	
	//// Update is called once per frame
	//void Update (){
		
	//}

    public void Damage(int dmg)
    {
        if(dmg < 0)
        {
            Debug.LogWarning("Negative damage trying to be applied.");
        }
        health -= dmg;
        if(health < 1)
        {
            Death();
        }

    }

    /// <summary>
    /// This is the function to override to do custom death things.
    /// </summary>
    public virtual void Death()
    {
        Debug.Log("Basic Death");
    }
}
