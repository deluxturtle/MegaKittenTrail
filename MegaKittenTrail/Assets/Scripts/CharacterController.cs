using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Handles player input.
/// </summary>
public class CharacterController : MonoBehaviour {
    
    #region TouchVars
    [Tooltip("Will print out debugs of touch positions.")]
    public bool debugTouch = false;
    [Tooltip("Distance of finger slide for swipe to activate")]
    public int i_comfort = 3;
    private Vector2 tch_previous;
    private Vector2 tch_current;
    private float touch_delta;
    #endregion

    
	
	// Update is called once per frame
	void Update () {

#if UNITY_EDITOR
#endif
        if (Input.GetButtonDown("Fire1"))
        {

        }
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
                        if (debugTouch) Debug.Log("Tap");
                        RaycastHit2D hit;

                        //hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
                        hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), 30);

                        if (hit)
                        {
                            SwipeAttack(hit);
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
        
    }

    /// <summary>
    /// Basic Attack
    /// </summary>
    /// <param name="pHit">Object that was hit.</param>
    void SwipeAttack(RaycastHit2D pHit)
    {
        Debug.Log(pHit.collider.gameObject);
        if(pHit.collider.tag == "Rat")
        {
            Rat clickedRat = pHit.collider.gameObject.GetComponent<Rat>();
            clickedRat.Damage(1);
        }
    }
    
}
