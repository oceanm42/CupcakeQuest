using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private ShopManager shopManager;
    private GameManager gameManager;
    private CameraFollow cameraFollow;
    private float moveInput;
    public float movementSpeed;
    public float jumpForce;
    
    [HideInInspector]
    public bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public GameObject cottonCandyPrefab;

    public int ammoValue;
    public int ammoLeft;
    public float addAmmoDelay;
    private bool addingAmmo;
    public int health;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
        ammoLeft = ammoValue;
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        cameraFollow = FindObjectOfType<CameraFollow>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        if (shopManager.inShop == false)
        {
            rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);
        }
        if (shopManager.inShop == true)
        {
            rb.velocity = Vector2.zero;
        }
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        if(ammoLeft < ammoValue)
        {
            if(addingAmmo != true)
            {
                StartCoroutine(AddAmmo());
                addingAmmo = true;
            }
        }
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0 && shopManager.inShop == false)
        {
            rb.velocity = Vector2.up * jumpForce;
            FindObjectOfType<AudioManager>().Play("Jump");
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true && shopManager.inShop == false)
        {
            rb.velocity = Vector2.up * jumpForce;
            FindObjectOfType<AudioManager>().Play("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.R) && ammoLeft > 0 && shopManager.inShop == false)
        {
            Instantiate(cottonCandyPrefab, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Shoot");
            ammoLeft--;
        }
        
        if(transform.position.y < -4 && gameManager.gameHasEnded == false && cameraFollow.inSubRoom == false)
        {
            gameManager.EndGame();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    IEnumerator AddAmmo()
    {
        yield return new WaitForSeconds(addAmmoDelay);
        ammoLeft++;
        addingAmmo = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Donut")
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            shopManager.money++;
            Destroy(collision.gameObject);
        }
    }
}
