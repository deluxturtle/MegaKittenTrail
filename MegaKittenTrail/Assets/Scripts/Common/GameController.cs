﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Andrew Seba
/// Description: Handles the UI updates and end game mechanics.
/// </summary>
public class GameController : MonoBehaviour {

    [Header("UI Hooks")]
    public Slider uiDistSlider;
    public Text uiDistTraveledText;
    public Text uiDistGoalText;
    public GameObject uiLevelCompletePanel;
    [Header("Other Hooks")]
    public GameObject playerObj;
    [Header("BackgroundSettings")]
    public float backgroundSpeed = 1;
    [HideInInspector]
    public List<GameObject> levelBlocks = new List<GameObject>();
    [Header("Levels (XML Info)")]
    public TextAsset Level1;
    public TextAsset Level2;



    private float distanceTraveled = 0;
    private float curGoalDistance = 50; //Meters
    private GameObject currentBackground; //Background contains 32 horizontal Sprites
    private GameObject nextBackground;
    private Vector3 blockRestingPlace = new Vector3(0, 100, 0);
    private bool moveBackground = true;

    void Start()
    {
        #region UIChecks
        if (uiDistSlider == null)
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
        
        if(uiDistGoalText == null)
        {
            Debug.Log("No Dist goal text assigned to the GameController script.");
        }
        else
        {
            uiDistGoalText.text = curGoalDistance.ToString();
        }
#endregion

        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
            playerObj.GetComponent<CharacterController>().StartCatTravel();
        }
        else
        {
            playerObj.GetComponent<CharacterController>().StartCatTravel();

        }

        //Load Map
        Debug.Log("Loading first map.");
        GetComponent<TileLoader>().StartLoad();


    }

    // Update is called once per frame
    void Update ()
    {

        //Move Background
        if(moveBackground)
            MoveBackground();

    }

    /// <summary>
    /// Slides the background across the screen to the left.
    /// </summary>
    void MoveBackground()
    {
        levelBlocks[0].transform.position -= new Vector3(backgroundSpeed, 0) * Time.deltaTime;
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
            moveBackground = false;
            uiLevelCompletePanel.SetActive(true);
            distanceTraveled = curGoalDistance;
            uiDistTraveledText.text = distanceTraveled.ToString("F");
            playerObj.GetComponent<CharacterController>().EndCatTravel();
            distanceTraveled = 0;
        }
    }

    /// <summary>
    /// Button hook to start cat travel again from the AreaInfo screen.
    /// </summary>
    public void _NextDestination()
    {
        //Update travel info
        //Start cat travel
        playerObj.GetComponent<CharacterController>().StartCatTravel();
        moveBackground = true;
    }
}
