using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimationController : MonoBehaviour
{

    public Animator animator;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isOpen", false);
        }
    }
}
