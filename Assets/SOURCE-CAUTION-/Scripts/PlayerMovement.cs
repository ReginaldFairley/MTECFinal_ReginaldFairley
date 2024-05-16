using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int playerID;
    public Transform headSpot;
    public float speed = 15;
    public float jumpPower = 10;
    public KeyCode fireButton;
    private Rigidbody2D rb;
    public GameObject objectOnMyHead;

    bool jumpFlag = false;
    float xMove;

    public float rayLength = 5;
    public float rayWidth = 5;
    public LayerMask ground;
    public LayerMask objects;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //objectOnMyHead = ;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(GroundCheck());

        if (playerID == 1)
        {
            xMove = Input.GetAxisRaw("HorP1");

        }
        else
        {
            xMove = Input.GetAxisRaw("HorP2");
        }

        //xMove = Input.GetAxisRaw("HorP1");
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T");
        }

        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            jumpFlag = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && ObjectCheck())
        {
            jumpFlag = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    private bool GroundCheck()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, rayLength + rayWidth, ground);
    }

    private bool ObjectCheck()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, rayLength + rayWidth, objects);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xMove * speed * Time.deltaTime, rb.velocity.y);

        if (jumpFlag)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpFlag = false;
        }
    }
}
