using UnityEngine;
using System.Collections;

public class CharacterAnimator : MonoBehaviour {

    Animator animator;
    bool walking, touchingGround = false;

    public bool Walking {
        set { walking = value; }
    }

    public bool TouchingGround {
        set { touchingGround = value; }
    }

    public void Jump() {
        animator.SetTrigger("jumped");
    }

    void Start() {
        animator = GetComponent<Animator>();
    }

	void Update () {
	    animator.SetBool("touchingGround", touchingGround);
        animator.SetBool("walking", walking);
	}
}
