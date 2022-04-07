using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class scorpMovement : MonoBehaviour
{

    public float speed = 2;

    public float walkFootSpeed = 2;

    private CharacterController pawn;

    public float gravity = 50;
    public float jumpImpulse = 50;
    public float velocityY = 0;

    private Camera cam;

    void Start()
    {
        pawn = GetComponent<CharacterController>();
    }


    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 move = transform.forward * v + transform.right * h;
        if (move.sqrMagnitude > 1) move.Normalize();

        pawn.SimpleMove(move * speed);

        AnimateWalk();
    }

    void AnimateWalk()
    {
 
    }
}
