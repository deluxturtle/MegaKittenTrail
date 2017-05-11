using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Author: Andrew Seba
/// Description: Handles main menu buttons
/// </summary>
public class MainMenuButtons : MonoBehaviour {

    /// <summary>
    /// Temporary start game to load the main gameplay scene.
    /// </summary>
	public void _StartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
