using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    [SerializeField] float shootDelay = 0.1f;
    [SerializeField] float shootDistance = 1000;
    [SerializeField] Transform shootPoint;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Light pointLight;
    [SerializeField] GameObject shootEffect;

    private float shootDelayCurrent;
    private Material shootMaterial;

    private void Start()
    {
        lineRenderer.positionCount = 2;
        shootMaterial = lineRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ShootProcess();
        }

        var tempColor = shootMaterial.color;
        if(tempColor.a > 0)
        {
        tempColor.a -= 0.1f;
        shootMaterial.color = tempColor;
        }

        pointLight.intensity -= 0.1f;
    }

    private void ShootProcess()
    {
        if(shootDelayCurrent > 0)
        {
            shootDelayCurrent -= Time.deltaTime;
            return;
        }

        CreateRay();

        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);

        shootDelayCurrent = shootDelay;
    }

    private void CreateRay()
    {
        RaycastHit ray;

        if (Physics.Raycast(shootPoint.position, shootPoint.TransformDirection(Vector3.forward), out ray, shootDistance))
        {
            DrawLine(shootPoint.position, ray.point);
            if (ray.collider.GetComponent<EnemyGet>())
            {
                ray.collider.GetComponent<EnemyGet>().Pause();
            }

            if (ray.collider.GetComponent<ChomperHealth>())
            {
                ray.collider.GetComponent<ChomperHealth>().DecreaceHealth();
            }
        }
        else
        {
            DrawLine(shootPoint.position, shootPoint.TransformDirection(Vector3.forward) * shootDistance);

        }
    }

    private void DrawLine(Vector3 positionFrom, Vector3 positionTo)
    {
        var tempColor = shootMaterial.color;
        tempColor.a = 1f;
        shootMaterial.color = tempColor;
        lineRenderer.SetPosition(0, positionFrom);
        lineRenderer.SetPosition(1, positionTo);
        pointLight.intensity = 3f;

        var effect = Instantiate(shootEffect, positionTo, Quaternion.identity);
        effect.SetActive(true);
        Destroy(effect, 0.2f);
    }
}
