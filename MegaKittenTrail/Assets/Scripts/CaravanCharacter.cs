using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Author: Andrew Seba
/// Description: Base Class for Caravan Characters
/// </summary>
public class CaravanCharacter : MonoBehaviour {

    public Feline felineData;

    public void SetFelineData(Feline pFeline)
    {
        felineData = pFeline;
    }
}
