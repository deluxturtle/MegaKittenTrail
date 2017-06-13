using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Base class for cats.
/// </summary>
public class Feline {

    private int age; //Weeks
    private string catName;
    private float hunger = 0.50f; //%


    public Feline(string pName)
    {
        catName = pName;
        age = 4;
    }

    public Feline(string pName, int pAge)
    {
        catName = pName;
    }

    public int Age { get { return age; } set { age = value; } }
    public float Hunger { get { return hunger; } set { hunger = value; } }
    public string CatName { get { return catName; } set { catName = value; } }
	
}
