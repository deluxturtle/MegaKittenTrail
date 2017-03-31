using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Andrew Seba
/// </summary>
public class GameController : MonoBehaviour {

    public Slider uiDistSlider;
    public Text uiDistTraveledText;

    private float distanceTraveled = 0;
    private float curGoalDistance = 1000;

    void Start()
    {
        if(uiDistSlider == null)
        {
            Debug.LogWarning("No Slider Assigned on GameController");
        }
        else
        {
            uiDistSlider.maxValue = curGoalDistance;
        }
    }

    // Update is called once per frame
    void Update () {
        



    }

    public void AddTravel(float distance)
    {

        distanceTraveled += distance;
        uiDistSlider.value = distanceTraveled;
        uiDistTraveledText.text = distanceTraveled.ToString();
        if (distanceTraveled >= curGoalDistance)
        {
            distanceTraveled = 0;
            Debug.Log("Reached Goal!");
        }
    }
}
