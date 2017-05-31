using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Base class for cats.
/// </summary>
public class Feline : MonoBehaviour {

    private int age;
    private string catName;
    private float hunger = 0.50f; //%

    public float Hunger
    {
        get
        {
            return hunger;
        }
        set
        {
            hunger = value;
        }
    }
	
}
