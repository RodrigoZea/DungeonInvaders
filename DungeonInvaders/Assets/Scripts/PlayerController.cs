using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    public float speed;
    public float jumpForce = 5f;
    private Rigidbody2D prb;
    private Vector2 movSpeed;
    private BoxCollider2D boxCollider2d;

    // Start is called before the first frame update
    void Start()
    {
        prb = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 mov = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += mov * Time.deltaTime * speed;
    }

    void Jump() {
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            prb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    bool IsGrounded() {
       float extraHeight = 0.5f;
       RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeight, platformLayerMask);

        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else {
            rayColor = Color.red;
        }

        Debug.DrawRay(boxCollider2d.bounds.center, Vector2.down * (boxCollider2d.bounds.extents.y + extraHeight), rayColor);
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }
}
