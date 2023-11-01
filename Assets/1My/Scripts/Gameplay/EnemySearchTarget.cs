using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchTarget : MonoBehaviour
{
    [SerializeField] AgentBob agentBob;
    private HealthUI currentHealth;

    private void OnTriggerStay(Collider other)
    {
        var health = other.GetComponentInChildren<HealthUI>();

        if (currentHealth != null && currentHealth.GetHealth <= 0)
        {
            agentBob.GetPlayer = null;
            agentBob.SetupPositionToStart();
            agentBob.OnEnable();
        }

        if (agentBob.GetPlayer != null || health == null || health.GetHealth <= 0)
        {
            return;
        }

        agentBob.GetPlayer = health.transform;
        currentHealth = health;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == agentBob.GetPlayer) 
        {
            agentBob.GetPlayer = null;
            agentBob.SetupPositionToStart();
            agentBob.OnEnable();
        }
    }
}
