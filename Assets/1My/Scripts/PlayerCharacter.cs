using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rb;
    [SerializeField] float jumpPower = 12f;
    [SerializeField] float groundCheckDistance = 0.3f;

    private bool isGrounded;
    private float groundCheckDistanceSaved;
    private float turnAmount;
    private float forwardAmount;

    // Start is called before the first frame update
    void Start()
    {
        groundCheckDistanceSaved = groundCheckDistance;
    }

    public void Move(Vector3 move, bool jump)
    {
        move = transform.InverseTransformDirection(move);
        move = Vector3.ProjectOnPlane(move, Vector3.up);
        turnAmount = Mathf.Atan2(move.x, move.z);
        forwardAmount = move.z;

        isGrounded = Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out _, groundCheckDistance);

        if (isGrounded)
        {
            HandleGroundedMovement(jump);
        }
        else
        {
            HandleAirborneMovement();
        }

        ApplyExtraTurnRotation();
        UpdateAnimator();
    }


    void UpdateAnimator()
    {
        animator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
        animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
        animator.SetBool("OnGround", isGrounded);
        animator.SetFloat("Jump", rb.velocity.y);
    }
    private void HandleAirborneMovement()
    {
        rb.AddForce(Physics.gravity);
        groundCheckDistance = rb.velocity.y < 0 ? groundCheckDistanceSaved : 0.01f;
    }
    private void HandleGroundedMovement(bool jump)
    {
        if (!jump || !isGrounded)
        {
            return;
        }

        rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
        isGrounded = false;
        groundCheckDistance = 0.1f;
    }
    private void ApplyExtraTurnRotation()
    {
       var turnSpeed = Mathf.Lerp(180, 360, forwardAmount);
       transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
    }

    public void OnAnimatorMove()
    {
        if (!isGrounded || Time.deltaTime < 0.001f)
        {
            return;
        }

        var velocity = (animator.deltaPosition) / Time.deltaTime;

        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
}
