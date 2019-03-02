using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
    private path path;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        path = GetComponent<path>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.Finish();
        }
    }

    public void PlayerFound()
    {
        path.PlayerFound();
    }
    public void PlayerGone()
    {
        animator.SetTrigger("seek");
    }
    public void PlayerLost()
    {
    }
}
