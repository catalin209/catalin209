using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;

public class skeletonMovement : MonoBehaviour {

	public Transform player;
    static Animator anim;
    public Vector3 skeletonDefaultPosition;

	void Start () {
        anim = GetComponent<Animator>();
        skeletonDefaultPosition = this.transform.position;
	}

	void Update () {
        if (Vector3.Distance(player.position, this.transform.position) < 9)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 1)
            {
                this.transform.Translate(0, 0, 0.03f);
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
                Vector3 direction = skeletonDefaultPosition - this.transform.position;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), 0.1f);
                if (direction.magnitude > 2) this.transform.Translate(0, 0, 0.05f);
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

