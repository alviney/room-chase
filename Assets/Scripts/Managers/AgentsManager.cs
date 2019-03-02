using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentsManager : MonoBehaviour
{
    public Object[] agents;

    #region 
    public static AgentsManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private void Start()
    {
        agents = FindObjectsOfType(typeof(NavMeshAgent));
    }

    public void RecalculateAgentPaths()
    {
        foreach (NavMeshAgent agent in agents)
        {
            Vector3 destination = agent.destination;

            agent.ResetPath();

            agent.SetDestination(destination);
        }
    }
}
