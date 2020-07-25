
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public float moveinput;
    
        private Rigidbody2D rb;
    private bool facingright = true;
    public bool isgrounded;

    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatisground;

    private int extrajump;
    


    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatisground);
        moveinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);
           
            if(facingright==false && moveinput>0)
            {
                flip();
            }
            else if(facingright==true && moveinput<0 )
            {
                flip();
            }
    }

    void Update()
    {
        if (isgrounded == true)
        {
          

            if (Input.GetKeyDown(KeyCode.UpArrow)==true)
            {
                rb.velocity = Vector2.up * jumpforce;
                isgrounded = false;
            }

        }
    }
    
    void flip()
    {
        facingright = !facingright;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
