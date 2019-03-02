using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class path : MonoBehaviour
{
    public float defaultSpeed;
    public float runningSpeed;
    public Vector3[] wayPoints;
    public MeshRenderer meshRenderer;
    private NavMeshAgent agent;
    private int index = 0;
    private Transform player;
    private bool isTrackingPlayer = false;
    private Mob mob;
    private bool runOnce = false;

    private void Start()
    {
        mob = GetComponent<Mob>();
        agent = GetComponent<NavMeshAgent>();

        agent.speed = defaultSpeed;

        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isTrackingPlayer)
            FollowPath(agent);
        else if (!agent.hasPath && !runOnce)
        {
            runOnce = true;
            PlayerGone();
        }
    }

    public void FollowPath(NavMeshAgent agent)
    {
        if (!agent.hasPath)
        {

            agent.SetDestination(wayPoints[index]);

            index = index == wayPoints.Length - 1 ? 0 : index + 1;
        }
    }
    public void PlayerFound()
    {
        isTrackingPlayer = true;

        agent.SetDestination(player.transform.position);
        agent.speed = runningSpeed;

        meshRenderer.material.color = Color.red;
    }
    public void PlayerGone()
    {
        mob.PlayerGone();

        agent.speed = defaultSpeed;
        meshRenderer.material.color = Color.yellow;
    }
    public void PlayerLost()
    {
        mob.PlayerLost();

        meshRenderer.material.color = Color.grey;
    }
}
