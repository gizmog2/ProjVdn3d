using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string stateAttack;

    private bool attack;

    
    // Update is called once per frame
    void Update()
    {
        if (!attack && Input.GetMouseButton(0))
        {
            attack = true;
            animator.SetBool(stateAttack, true);
        }

        if (attack && !Input.GetMouseButton(0))
        {
            attack = false;
            animator.SetBool(stateAttack, false);
        }
    }
}
