using Gamekit3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    [SerializeField] float decreaceHealth;

    public float DecreaceHealth { get => decreaceHealth; set =>decreaceHealth = value; }

    private void OnTriggerStay(Collider other)
    {
        if (!enabled)
        {
            return;
        }

        var health = other.GetComponentInChildren<HealthUI>();

        if (health == null)
        {
            return;
        }

        health.DecreaceHealth(decreaceHealth);
    }
}
