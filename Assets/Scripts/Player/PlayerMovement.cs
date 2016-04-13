using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    XInput xinput;
    Rigidbody2D rb;

    [SerializeField]
    float maxWalkSpeed, jumpHeight = 5;

    public float MaxWalkSpeed {
        get { return maxWalkSpeed; }
        set { maxWalkSpeed = value; }
    }

    [SerializeField, Tooltip("Leave this be unless you know what you're doing with it.")]
    float maxVel = 10;

    [SerializeField, Tooltip("Leave this be unless you know what you're doing with it.")]
    float speedDivider, jumpDivider = 30;

    [SerializeField]    
    LayerMask ground;

    bool touchingGround = false;

    float yVel = 0;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 9) {
            touchingGround = true;
            xinput.BurstVib(0.2f, 0.4f * yVel);
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.layer == 9) {
            touchingGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == 9) {
            touchingGround = false;
        }
    }

    void Start() {
        xinput = GetComponent<XInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        yVel = rb.velocity.y;

        float hor = xinput.LeftStickPos.x;
        float ver = xinput.LeftStickPos.y;
        float speed = maxWalkSpeed / speedDivider;

        hor *= speed;

        if (ver < 0) {
            if (!touchingGround) {
                rb.velocity = new Vector3(rb.velocity.x, 0);
                ver = -speed * 2;
            } else {
                ver = 0;
            }
        } else {
            ver = 0;
        }

        if (rb.velocity.y > maxVel) {
            rb.velocity = new Vector3(rb.velocity.x, maxVel);
        }

        transform.position += new Vector3(hor, ver);

        if (xinput.AButton) {
            if (touchingGround) {
                rb.AddForce(transform.up * (jumpHeight / jumpDivider), ForceMode2D.Impulse);
            }
        }
    }
}
