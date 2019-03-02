using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translater : MonoBehaviour
{
    public float timeToMove;
    public Vector3 destination;
    private Vector3 startPos;
    private bool isForwards = true;

    private void Start()
    {
        startPos = transform.localPosition;
    }
    public void Move()
    {

        StartCoroutine(MoveToPosition());
    }

    public IEnumerator MoveToPosition()
    {
        var start = startPos;
        var end = destination;

        if (destination == transform.localPosition)
        {
            start = destination;
            end = startPos;
        }

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.localPosition = Vector3.Lerp(start, end, t);
            yield return null;
        }
    }
}
