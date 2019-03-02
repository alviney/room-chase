using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Lean.Touch;
public class mover : MonoBehaviour
{
    [Tooltip("The conversion method used to find a world point from a screen point")]
    public LeanScreenDepth ScreenDepth;
    [Tooltip("The camera the translation will be calculated using (default = MainCamera)")]
    public Camera Camera;
    public GameObject marker;
    public float defaultSpeed;
    private NavMeshAgent agent;
    private LineRenderer lr;
    private Vector3 destination = default(Vector3);
    private bool notDrawn = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        lr = GetComponent<LineRenderer>();

        agent.speed = defaultSpeed;
        Camera.GetComponent<CameraFollow>().StartFollowing();
    }

    public void Move(LeanFinger finger)
    {
        print("Move");
        // var worldPoint = default(Vector3);

        var ray = Camera.ScreenPointToRay(finger.ScreenPosition);
        var hit = default(RaycastHit);

        if (Physics.Raycast(ray, out hit, float.PositiveInfinity) == true)
        {
            if (hit.transform.CompareTag("Ground"))
            {
                destination = hit.point;

                agent.SetDestination(destination);

                marker.transform.position = new Vector3(destination.x, marker.transform.position.y, destination.z);
            }
        }
    }

    public void Check()
    {
        if (agent.hasPath)
        {
            Camera.GetComponent<CameraFollow>().StartFollowing();
        }
        else
        {
            Camera.GetComponent<CameraFollow>().StopFollowing();
        }
    }
}
