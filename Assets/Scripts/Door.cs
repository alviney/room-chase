using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public mover mover;
    public bool isOpen = true;
    public GameObject trigger;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();

        if (isOpen)
        {
            animator.SetTrigger("open_door");
        }
        else
        {
            animator.SetTrigger("close_door");
        }
    }
    public void ToggleDoor()
    {
        isOpen = !isOpen;
        OpenDoors();
    }

    public void DisableTrigger()
    {
        trigger.SetActive(false);
    }

    public void EnableTrigger()
    {
        trigger.SetActive(true);
    }

    private void OpenDoors()
    {
        animator.SetTrigger("toggle_door");

        StartCoroutine(WaitToRecalculate());
    }

    private IEnumerator WaitToRecalculate()
    {
        yield return new WaitForSeconds(.4f);

        AgentsManager.instance.RecalculateAgentPaths();
    }

}
