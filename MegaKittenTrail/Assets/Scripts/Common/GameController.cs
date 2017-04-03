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
    public GameObject uiLevelCompletePanel;
    public GameObject playerObj;

    private float distanceTraveled = 0;
    private float curGoalDistance = 100; //Meters

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

        if(uiLevelCompletePanel == null)
        {
            Debug.LogWarning("No LevelComplete Panel Assigned to GameController Script!");
        }

        if(playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
            playerObj.GetComponent<CharacterController>().StartCatTravel();
        }
        else
        {
            playerObj.GetComponent<CharacterController>().StartCatTravel();

        }
    }

    // Update is called once per frame
    void Update () {
        



    }

    /// <summary>
    /// Adds distance to the amount we have traveled.
    /// </summary>
    /// <param name="distance">How much distance to add to traveled.</param>
    public void AddTravel(float distance)
    {

        distanceTraveled += distance;
        uiDistSlider.value = distanceTraveled;
        uiDistTraveledText.text = distanceTraveled.ToString("F");
        if (distanceTraveled >= curGoalDistance)
        {
            Debug.Log("Reached Goal!");
            uiLevelCompletePanel.SetActive(true);
            distanceTraveled = curGoalDistance;
            uiDistTraveledText.text = distanceTraveled.ToString("F");
            playerObj.GetComponent<CharacterController>().EndCatTravel();
            distanceTraveled = 0;
        }
    }

    public void _NextDestination()
    {
        //Update travel info
        //Start cat travel
        playerObj.GetComponent<CharacterController>().StartCatTravel();
    }
}
