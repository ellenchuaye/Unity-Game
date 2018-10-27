using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private float speedStore;
    public float jumpforce;
    private float moveInput;


    private Rigidbody2D rb;

    private bool facingLeft = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpvalue;

    public CameraController cameraControl;
    public GameManager theGameManager;
    public PlatformGenerator thePlatformGenerator;

    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource inGame;



    // Use this for initialization
    void Start () {
        extraJumps = extraJumpvalue;
        rb = GetComponent<Rigidbody2D>();
        
	}
	
	
	void FixedUpdate () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal"); //GetAxisRaw
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingLeft == false && moveInput < 0)
        {
            flip();
        }
        else if (facingLeft == true && moveInput > 0)
        {
            flip();
        }
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpvalue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) 
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJumps--;
            jumpSound.Play();
        } else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
            jumpSound.Play();
        }
    }

    void flip()
    {
        facingLeft = !facingLeft;
        Vector3 Scaler = transform.localScale;//players x,y,z scale value
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void OnCollisionEnter2D(Collision2D other) //Unity function. 
    {
        if (other.gameObject.tag == "killbox") //tag!
        {
            deathSound.Play();
            inGame.Stop();
            cameraControl.stop();
            theGameManager.RestartGame();

        }
    }

    public void ifBoosted()
    {
        StartCoroutine("ifBoostedCo");
    }

    public IEnumerator ifBoostedCo()
    {
        // gameObject.SetActive(false);
        speedStore = speed;
        transform.position = thePlatformGenerator.getPlayerTeleport();
        //Time.timeScale = 0.1f;
        speed = 0;
        yield return new WaitForSeconds(0.6f);
        speed = speedStore;
        
        //gameObject.SetActive(true);
        
        
        
        
    }
   /* public void ifBoosted(int jumpForce)
    {
            gameObject.GetComponent<Collider2D>().enabled = false;
            extraJumps = 0;
            rb.velocity = Vector2.up * jumpForce;
            jumpSound.Play();
            
    }*/
}
