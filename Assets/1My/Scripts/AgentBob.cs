using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBob : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 endPosition;

    private NavMeshAgent agent;

    private Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentPosition = startPosition;
        agent.SetDestination(currentPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }

        if(Vector3.Distance(transform.position, currentPosition) > 1)
        {
            return;
        }

        if (currentPosition == startPosition)
        {
            currentPosition = endPosition;
        }
        else
        {
            currentPosition = startPosition;
        }

        agent.SetDestination(currentPosition);
    }
}