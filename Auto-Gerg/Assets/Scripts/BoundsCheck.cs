using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    private GroundTiles groundTile;
    private DragnDrop dragNdrop;

    //Make sure to assign this in the Inspector window
    public Transform m_NewTransform;        // This is the position of the groundTile
    public Collider m_Collider;                    // Capsule collide on the groundTile
    public Vector3 m_Point;

    // check to see if the object is in the area of the groundTile


    public Transform character;

    void Awake()
    {
        //Fetch the Collider from the GameObject this script is attached to
        m_Collider = GetComponent<CapsuleCollider>();

        // Making the default for the object to be false on isTrigger
        m_Collider.isTrigger = false;

        //Assign the point to be that of the Transform you assign in the Inspector window
        m_Point = m_NewTransform.position;
    }

    void Update()
    {
        /*
        //If the first GameObject's Bounds contains the Transform's position, output a message in the console
        if (dragNdrop._drag != null)
        {
            if (m_Collider.bounds.Contains(dragNdrop._drag.transform.position))
            {
                m_Collider.isTrigger = true;
                Debug.Log("Bounds contain the point : " + m_Point);
            }
        }
        */
    }

    // May not need this part
    /*
    void OnMouseDown()
    {
        //GameObject's Collider is now a trigger Collider when the GameObject is clicked. It now acts as a trigger
        m_Collider.isTrigger = true;

        //Output to console the GameObject’s trigger state
        Debug.Log("Trigger On : " + m_Collider.isTrigger);
    }
    */

} // end of class