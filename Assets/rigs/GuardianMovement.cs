using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class GuardianMovement : MonoBehaviour
{

    public float walkSpeed = 5;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");

        float animationVar = v * walkSpeed;

        transform.position += transform.forward * animationVar * Time.deltaTime;
        // movement equals forward * direction from player * walk speed * time (so its not per tick but per second)

        animator.SetFloat("walkSpeed", Mathf.Abs(animationVar));

    }
}
