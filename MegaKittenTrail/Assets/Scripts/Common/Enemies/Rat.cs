using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Author: Andrew Seba
/// Description: Rat Enemy that dies easily and gives 1 food.
/// </summary>
public class Rat : Enemy {
    public GameObject deathSprite;
    public GameObject pop;

	public override void Death()
    {
        Instantiate(deathSprite, transform.position, Quaternion.identity);
        Instantiate(pop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
