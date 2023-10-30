using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGet : MonoBehaviour
{
    [SerializeField] Behaviour[] components;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] Light PointLight;
    [SerializeField] float DefaultTimer;

    private float currentTimer;

    private bool pause;

    private void Update()
    {
        if (!pause)
        {
            return;
        }

        if (currentTimer <= 0)
        {
            Activate();
        }

        currentTimer -= Time.deltaTime;

        if (PointLight.intensity > 0)
        {
            PointLight.intensity -= 0.1f;
        }
    }

    public void Pause()
    {
        SetActiveComponents(false);
        particleSystem.Stop(true);
        currentTimer = DefaultTimer;
        pause = true;
    }
    private void Activate()
    {
        SetActiveComponents(true);
        particleSystem.Play(true);
        PointLight.intensity = 1f;
        pause = false;
    }

    private void SetActiveComponents(bool state)
    {
        foreach (var component in components)
        {
            component.enabled = state;
        }
    }
}
