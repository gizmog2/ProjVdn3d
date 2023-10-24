using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] PlayerCharacter character;
    [SerializeField] Transform playerCamera;

    private void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var jump = Input.GetButtonDown("Jump");

        if (playerCamera == null)
        {
            return;
        }

        var camForward = Vector3.Scale(playerCamera.forward, new Vector3(1, 0 , 1)).normalized;
        var move = v * camForward + h * playerCamera.right;

        character.Move(move, jump);
        if (jump)
        {
            Debug.Log("Jump");
        }
    }
}
