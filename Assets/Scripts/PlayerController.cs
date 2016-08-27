using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 3;
    [Range(1, 50)] public float jumpForce = 5;
    public GameObject cannonBall;
    float tension = 0;
    float maxTension = 2;

    bool isGrounded = true;
    SpriteRenderer m_Renderer;
    Rigidbody2D m_rb;
    Animator m_anim;
    GameObject m_Meter;

    void Start()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        m_Meter = GameObject.Find("Meter");
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") < -0.1f)
        {
            m_Renderer.flipX = true;
        } else if (Input.GetAxis("Horizontal") > 0.1f)
        {
            m_Renderer.flipX = false;
        }

        //m_Meter.transform.position = transform.position + new Vector3(dir() * 1, 11f);

        if (Input.GetButtonDown("Jump"))
        {
            RaycastHit2D down = Physics2D.Raycast(transform.position - (Vector3.up * 8.2f), -Vector2.up * 5);
            if (down.collider != null)
            {
                if (down.distance < 0.2f)
                {
                    isGrounded = true;
                }
                else
                {
                    isGrounded = false;
                }
            }

            RaycastHit2D right = Physics2D.Raycast(transform.position - (Vector3.right * 8.2f), -Vector2.right * 5);
            RaycastHit2D left = Physics2D.Raycast(transform.position + (Vector3.right * 8.2f), Vector2.right * 5);

            if (right.collider != null || left.collider != null)
            {
                if (right.rigidbody != m_rb && left.rigidbody != m_rb)
                {
                    //isGrounded = true;

                if(right.distance < 0.2f || left.distance < 0.2f)
                    {
                        isGrounded = true;
                    }
                }
            }
            Jump();
        }

        if(Input.GetButtonUp("Fire1"))
        {
            Shoot();
        }

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetAxis("Horizontal") != 0)
        {
            float x = Input.GetAxis("Horizontal");
            Move(x);
        }
        if (Input.GetButton("Fire1"))
        {

            if (tension < maxTension)
            {
                tension += 0.05f;
            }
        }
        m_Meter.transform.localScale = new Vector3(tension/2, 1, 1);
    }

    void Move(float x)
    {
        //transform.Translate(new Vector3(x * movementSpeed, 0, 0));
        m_rb.AddForce(new Vector3(x * movementSpeed * 300, 0, 0));
    }

    void Jump()
    {
        if (isGrounded)
        {
            m_rb.AddForce(Vector2.up * jumpForce * 100, ForceMode2D.Impulse);
        }
    }

    void Shoot()
    {
        m_anim.SetBool("isFiring", true);

        GameObject clone = Instantiate(cannonBall, transform.position + (new Vector3(transform.forward.x, 10) * 2), Quaternion.identity) as GameObject;
        clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir() + m_rb.velocity.magnitude / 50 * dir() + (dir() * 2f), 2f) * tension * 280, ForceMode2D.Impulse);
        tension = 0;
    }

    void stopShooting()
    {
        m_anim.SetBool("isFiring", false);
    }

    int dir()
    {
        int myDir;

        if (m_Renderer.flipX == true)
        {
            myDir = -1;
        }
        else
        {
            myDir = 1;
        }
        return myDir;
    }
}
