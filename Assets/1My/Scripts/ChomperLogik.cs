using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperLogik : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string walkParameterName;
    [SerializeField] string attackParameterName;
    [SerializeField] HealthUI playerHealth;
    private Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.Distance(transform.position, oldPosition);
        speed = Mathf.Abs(speed);
        animator.SetFloat(walkParameterName, speed);
        animator.SetBool(attackParameterName, speed < 0.01f && playerHealth.GetHealth > 0);

        oldPosition = transform.position;
    }
}
