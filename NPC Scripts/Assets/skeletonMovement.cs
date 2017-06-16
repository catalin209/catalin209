using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using UnityEngine.AI;

public class skeletonMovement : MonoBehaviour {

	public Transform player;
    Animator anim;
    private Vector3 skeletonDefaultPosition;
    NavMeshAgent nav;

    void Start () {
        anim = GetComponent<Animator>();
        skeletonDefaultPosition = this.transform.position;
        nav = GetComponent<NavMeshAgent>();
    }

	void Update () {
        if (Vector3.Distance(player.position, this.transform.position) < 9)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
            if (Vector3.Distance(player.position, this.transform.position) > 1)
            {
                nav.speed = 2f;
                nav.SetDestination(player.position);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", true);
            }
        }
        else
        {
            if (Vector3.Distance(skeletonDefaultPosition, this.transform.position) > 2)
            {
                anim.SetBool("isIdle", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isRunning", true);
                nav.speed = 3f;
                nav.SetDestination(skeletonDefaultPosition);
            }
            else
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isRunning", false);
            }
        }
    }

}

