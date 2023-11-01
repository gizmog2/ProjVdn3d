using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperGenerator : MonoBehaviour
{
    [SerializeField] GameObject chomperTemplate;
    [SerializeField] float spawnTimer = 10f;
    [SerializeField] Transform spawnPosition;
    [SerializeField] int count = 10;


    private float currentTimer;

    // Update is called once per frame
    void Update()
    {
        if (count <=0)
        {
            return;
        }

        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
            return;
        }

        count--;
        currentTimer = spawnTimer;
        CreateCharacter();
    }

    private void CreateCharacter()
    {
        var character = Instantiate(chomperTemplate, transform.position, Quaternion.identity);
        character.SetActive(true);
    }


}
