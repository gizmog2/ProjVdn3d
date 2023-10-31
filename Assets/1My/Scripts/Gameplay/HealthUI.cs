using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Behaviour[] components;

    [SerializeField] Image HealthImage;
    [SerializeField] float HealthCount;

    [SerializeField] Animator Animator;
    [SerializeField] string DeathParameterName;
    

    private void Start()
    {
        UpdateUI();       
    }

    public float GetHealth { get => HealthCount; }

    public void DecreaceHealth(float deltaHealth)
    {
        if (HealthCount <= 0)
        {          
            return;
        }

        HealthCount -= deltaHealth;
        UpdateUI();

        if (HealthCount <= 0)
        {
            DeathProcess();         
        }
    }

    private void DeathProcess()
    {
        Animator.SetBool(DeathParameterName, true);

        foreach (var component in components)
        {
            component.enabled = false;
        }

        var componentCollider = GetComponent<CapsuleCollider>();

        if (componentCollider != null)
        {
            componentCollider.center = new Vector3(0, 1.52f, 0);
        }

        
    }

    private void UpdateUI()
    {
        HealthImage.fillAmount = HealthCount / 100f;
    }
}
