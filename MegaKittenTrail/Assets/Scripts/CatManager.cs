using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Handles functions to deploy on the cat group.
/// </summary>
public class CatManager : MonoBehaviour {

    [Tooltip("Cat prefab object to spawn on screen.")]
    public GameObject catPrefab;
    [Tooltip("Position cats will spawn at.")]
    public Transform catSpawn;
    [Tooltip("How far away the cats will be from eachother at spawn.")]
    public float catSpawnDistance = 3f;

    [HideInInspector]
    public int foodValue = 0;//Amount of food caravan has to live off of.
    private List<Feline> cats = new List<Feline>();
    private bool initialized = false;//ForLoading
    

    /// <summary>
    /// Probably needs to get called when Creating Carvan during setup.
    /// </summary>
    /// <param name="papaName">Name of Leader</param>
    /// <param name="mamaName">Name of Second in command</param>
    public void InitializeCaravan(string papaName,string mamaName)
    {
        Feline papa = new Feline(papaName);
        Feline moma = new Feline(mamaName);
        Feline kid1 = new Feline("Derp1");
        Feline kid2 = new Feline("Derp2");
        cats.Add(papa);
        cats.Add(moma);
        cats.Add(kid1);
        cats.Add(kid2);

        //Initialize starting values.
        foodValue = 5;

        initialized = true;
        SpawnCats();
    }

    /// <summary>
    /// Sets up caravan characters and puts cats on screen!
    /// Cats line up every 2 units from the leader
    /// </summary>
    void SpawnCats()
    {
        GameObject previousCat = null;
        foreach(Feline cat in cats)
        {
            GameObject tempCat = Instantiate(catPrefab);
            if (previousCat == null)
            {
                tempCat.transform.position = catSpawn.transform.position;
            }
            else
            {
                tempCat.transform.position = previousCat.transform.position + new Vector3(catSpawnDistance, 0);
            }
            CaravanCharacter tempCaravan = tempCat.AddComponent<CaravanCharacter>();
            tempCaravan.SetFelineData(cat);
            //Debug.Log(tempCat.GetComponent<CaravanCharacter>().felineData.CatName);

            previousCat = tempCat;
        }
    }

    /// <summary>
    /// Function when the day ends to deduct food.
    /// </summary>
    void DayEnd()
    {
        foodValue -= 1;
        if(foodValue <= 0)
        {
            if(foodValue < 3)
            {
                Debug.Log("It's been 3 days without food you all parish.");
            }
        }
    }
	
}
