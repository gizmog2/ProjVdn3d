using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperHealth : MonoBehaviour
{
    [SerializeField] float decreaceHealth;
    [SerializeField] HealthUI healthUI;

    public void DecreaceHealth()
    {
        healthUI.DecreaceHealth(decreaceHealth);
    }
}
