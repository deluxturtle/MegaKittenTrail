using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Handles player input.
/// </summary>
public class CharacterController : MonoBehaviour {

    public float speed = 1;
    public float speedMulti = 100;

    #region TouchVars
    public bool debugTouch = false;
    public int i_comfort = 3;
    private Vector2 tch_previous;
    private Vector2 tch_current;
    private float touch_delta;
    #endregion
    bool canTravel = true;

    GameController gameControl;

    // Use this for initialization
    void Start () {
        gameControl = FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        #region TouchControls
        if(Input.touchCount == 1)
        {
            //Begin touch phase
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                tch_previous = Input.GetTouch(0).position;
            }

            //On touch End
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                tch_current = Input.GetTouch(0).position;
                touch_delta = tch_current.magnitude - tch_previous.magnitude;
                
                if(Mathf.Abs(touch_delta) > i_comfort)
                {
                    if(debugTouch)Debug.Log("Swipe");
                    //Handle Left or Down Swipe
                    if(touch_delta < 0)
                    {
                        if(Mathf.Abs(tch_current.x - tch_previous.x) > Mathf.Abs(tch_current.y - tch_previous.y))
                        {
                            if (debugTouch) Debug.Log("Right");
                        }
                        else
                        {
                            if (debugTouch) Debug.Log("Down");
                        }

                    }
                    else
                    {
                        if(Mathf.Abs(tch_current.x - tch_previous.x) > Mathf.Abs(tch_current.y - tch_previous.y))
                        {
                            if (debugTouch) Debug.Log("Right");
                        }
                        else
                        {
                            if (debugTouch) Debug.Log("Up");
                        }
                    }
                }
                else
                {
                    //Single Tap
                    if(Input.GetTouch(0).tapCount == 1)
                    {
                        RaycastHit hit;
                        Ray ray;
                        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                        if(Physics.Raycast(ray, out hit, 100.0f))
                        {
                            
                        }
                    }
                    //DoubleTap
                    else if(Input.GetTouch(0).tapCount == 2)
                    {

                    }
                }

            }
        }
        #endregion

        if (canTravel)
        {
            gameControl.AddTravel(speed * speedMulti * Time.deltaTime);
        }
    }
}
