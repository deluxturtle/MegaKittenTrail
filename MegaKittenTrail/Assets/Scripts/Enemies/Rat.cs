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
    public float speed = 1;
    [HideInInspector]
    public bool spawnable = true;

    
    /// <summary>
    /// The initialization of the rat after being recycled.
    /// </summary>
    public void MoveAcrossScreen()
    {
        StopCoroutine(AliveAndMoving());
        StartCoroutine(AliveAndMoving());
    }

    /// <summary>
    /// This is the moving loop so the update call doesnt run when the rat is dead.
    /// </summary>
    /// <returns>null</returns>
    IEnumerator AliveAndMoving()
    {
        spawnable = false;
        while (true)
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            if (transform.position.x < Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x)
            {
                SetSpawnable();
                break;
            }
            yield return null;
        }
    }

    /// <summary>
    /// Spawns a dead mouse and a "pop" sprite.
    /// </summary>
	public override void Death()
    {
        StopCoroutine(AliveAndMoving());
        Instantiate(deathSprite, transform.position, Quaternion.identity);
        Instantiate(pop, transform.position, Quaternion.identity);
        SetSpawnable();
        //Destroy(gameObject);
    }

    void SetSpawnable()
    {
        transform.position = new Vector3(0, 20, -20);
        spawnable = true;
    }
}
