using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footRayCast : MonoBehaviour
{
    public float distanceBtwGroundIK = 0;
    public float raycastLength = 2;
    private Quaternion startingRot;

    /// <summary>
    /// The world-space position of the ground above/below the foot IK
    /// </summary>
    private Vector3 groundPosition;

    /// <summary>
    /// The world-space rotation for the foot to be aligned with the ground
    /// </summary>
    private Quaternion groundRotation;
    
    void Start()
    {
        startingRot = transform.rotation; 
        distanceBtwGroundIK = transform.localPosition.y;
    }

    void Update()
    {
        //FindGround();
    }

    private void FindGround()
    {
        Vector3 origin = transform.position + Vector3.up * raycastLength / 2;
        Vector3 direction = Vector3.down;

        // draws the ray so we can see it for debug/info
        Debug.DrawRay(origin, direction * raycastLength, Color.red);

        //checks for collisions on the ray
        if (Physics.Raycast(origin, direction, out RaycastHit hitInfo, raycastLength))
        {
            //finds the ground's position
            groundPosition = hitInfo.point + Vector3.up * distanceBtwGroundIK;

            Quaternion worldNeut = transform.parent.rotation * startingRot; //puts the foot in the correct direction (converts the starting rotation from world to local)

            groundRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal) * worldNeut; //rotates the foot to align with the surface
        }
    }
}
