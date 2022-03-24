using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class goonMovement : MonoBehaviour
{
    public footRayCast footLeft;
    public footRayCast footRight;

    public float speed = 2;

    public float walkSpreadX = .2f;
    public float walkSpreadY = .4f;
    public float walkSpreadZ = .4f;

    public float walkFootSpeed = 2;

    private CharacterController pawn;

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

    delegate void MoveFoot(float time, float x, footRayCast foot);

    void AnimateWalk()
    {
        //DRY - Don't Repeat Yourself (dont repeat code)

        MoveFoot moveFoot = (t, x, foot) => 
        {

            float y = Mathf.Cos(t) * walkSpreadY; 
            float z = Mathf.Sin(t) * walkSpreadZ;

            if (y < 0) y = 0;
            y += .178f;

            foot.transform.localPosition = new Vector3(x, y, z);
        };

        float t = Time.time * walkFootSpeed;

        moveFoot.Invoke(t, -walkSpreadX, footLeft);
        moveFoot.Invoke(t + Mathf.PI, walkSpreadX, footRight);
    }

}
