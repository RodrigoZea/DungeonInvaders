using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce = 5f;
    private Rigidbody2D prb;
    private Vector2 movSpeed;

    // Start is called before the first frame update
    void Start()
    {
        prb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 mov = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += mov * Time.deltaTime * speed;
    }

    void Jump() {
        if (Input.GetButtonDown("Jump")) {
            prb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
