﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Andrew Seba
/// Description: Handles the UI updates, traveling and end game mechanics.
/// C:\Users\Andrew\AppData\Local\Android\sdk
/// </summary>
public class GameController : MonoBehaviour {
    [Header("Cat Move Settings")]
    [Tooltip("How much distance is added per update.")]
    public float speed = 1;
    [Tooltip("Multiplaies the speed addition per update.")]
    public float speedMulti = 1;

    [Header("UI Hooks")]
    public Slider uiDistSlider;
    public Text uiDistTraveledText;
    public Text uiDistGoalText;
    public GameObject uiLevelCompletePanel;
    public GameObject eventDialogWindow;
    public GameObject oKButton; //Going to assign dynamic functions to this.
    [Header("Other Hooks")]
    public GameObject playerObj;
    [Header("BackgroundSettings")]
    public float backgroundSpeed = 1;
    [HideInInspector]
    public List<GameObject> levelBlocks = new List<GameObject>();
    [Header("Levels (XML Info)")]
    [Tooltip("First level the game will load.")]
    public TextAsset level1;
    [Tooltip("Second Level the game will load.")]
    public TextAsset level2;

    [HideInInspector]
    public bool canTravel = true;//Allows the player to update the distance being traveled

    private uint levelNumber = 1;
    private float distanceTraveled = 0;
    private float curGoalDistance = 1000; //Meters
    private GameObject currentBackground; //Background contains 32 horizontal Sprites
    private GameObject nextBackground;
    private CatManager catManager;
    private EventDialog dialogWindowRef;
    private UnityEngine.Events.UnityAction unPauseAction;

    void Start()
    {
        #region Learning and Test
        //Created a unityaction to assign to the button and remove when needed.
        unPauseAction = () => { _Unpause(); };
        //First attempt at making the dialog box function
        dialogWindowRef = eventDialogWindow.GetComponent<EventDialog>();
        #endregion

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

        #region ScriptReferences
        catManager = GetComponent<CatManager>();
        #endregion

        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
            canTravel = true;
        }
        else
        {
            canTravel = true;

        }

        //Load Map
        Debug.Log("Loading first map.");
        GetComponent<TileLoader>().LoadMap(level1);

        //Initialize Cats

        catManager.InitializeCaravan("Papa", "Mama");

    }

    // Update is called once per frame
    void Update ()
    {
        if(canTravel)
            AddTravel(speed * speedMulti * Time.deltaTime);
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
        //If complete Reset everything
        if (distanceTraveled >= curGoalDistance)
        {
            Debug.Log("Reached Goal!");
            uiLevelCompletePanel.SetActive(true);
            distanceTraveled = curGoalDistance;
            uiDistTraveledText.text = distanceTraveled.ToString("F");
            canTravel = false;
            distanceTraveled = 0;
        }
        else
        {
            distanceTraveled += distance;
            uiDistSlider.value = distanceTraveled;
            uiDistTraveledText.text = distanceTraveled.ToString("F");
            MoveBackground();
        }
    }

    /// <summary>
    /// Only used in game to pause the travel from the pause button.
    /// </summary>
    public void _StopTravel()
    {
        dialogWindowRef.textBig.text = "Paused";
        dialogWindowRef.buttonOk.GetComponentInChildren<Text>().text = "Unpause";
        canTravel = false;
        if (oKButton != false)
        {
            oKButton.GetComponent<Button>().onClick.AddListener(unPauseAction);
        }
        else
        {
            Debug.LogWarning("Default ok button on dialog box went missing!");
        }
    }

    /// <summary>
    /// Will be assigned to the ok button dynamicly when pausing the game.
    /// </summary>
    public void _Unpause()
    {
        canTravel = true;
        oKButton.GetComponent<Button>().onClick.RemoveListener(unPauseAction);
        Debug.Log("removed listener");
    }

    /// <summary>
    /// Button hook to start cat travel again from the AreaInfo screen.
    /// </summary>
    public void _NextDestination()
    {
        //Load new tile sheet
        switch (levelNumber)
        {
            case 1:
                GetComponent<TileLoader>().LoadMap(level2);
                break;
            default:
                Debug.LogWarning("No more levels to load");
                break;
        }
        //Update travel info
        //Start cat travel
        canTravel = true;
    }
    
}
