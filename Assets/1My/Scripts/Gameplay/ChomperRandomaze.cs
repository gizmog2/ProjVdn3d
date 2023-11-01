using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChomperRandomaze : MonoBehaviour
{
    [SerializeField] float minScale;
    [SerializeField] float maxScale;

    [SerializeField] float minDamage;
    [SerializeField] float maxDamage;

    private void Start()
    {
        var randomDamage = Random.Range(minDamage, maxDamage);

        var damageComponent = GetComponentInChildren<DamageToPlayer>();
        if (damageComponent != null)
        {
            damageComponent.DecreaceHealth = randomDamage;
        }

        var deltaDamage = randomDamage - minDamage;
        var deltaDamageBase = maxDamage - minDamage;
        var percentage = deltaDamage / deltaDamageBase;

        var scale = (maxScale - minScale) * percentage;
        transform.localScale = Vector3.one * (minScale + scale);
    }
}
