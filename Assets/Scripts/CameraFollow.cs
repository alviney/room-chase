using System;
using UnityEngine;
using UnityEngine.AI;
using Lean.Touch;

public class CameraFollow : MonoBehaviour
{
    public bool isFollowing = true;
    public Transform playerTransform;
    public float damping;
    private Vector3 offset;
    private new Camera camera;
    private float defaultZoom;
    private NavMeshAgent playerAgent;
    private void Awake()
    {
        offset = transform.position - playerTransform.position;

        playerAgent = playerTransform.GetComponent<NavMeshAgent>();

        camera = GetComponent<Camera>();

        defaultZoom = camera.orthographicSize;
    }

    private void FixedUpdate()
    {
        if (isFollowing)
        {
            float xPos = Mathf.Clamp(playerTransform.position.x, 0, 6);
            float zPos = Mathf.Clamp(playerTransform.position.z - 3, -20, -1);

            Vector3 newPos = new Vector3(xPos, transform.position.y, zPos);

            transform.position = Vector3.Lerp(transform.position, newPos, damping * Time.deltaTime);
        }

    }

    public void StartFollowing()
    {
        GetComponent<LeanCameraZoomSmooth>().Zoom = defaultZoom;
        // camera.orthographicSize = defaultZoom;
        isFollowing = true;
    }

    public void StopFollowing()
    {
        isFollowing = false;
    }
}