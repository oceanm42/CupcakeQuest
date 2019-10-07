using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meringue : MonoBehaviour {

    private Rigidbody2D rb;
    private ShopManager shopManager;
    private PlayerMovement playerMovement;
    private CottonCandy cottonCandy;
    public float speed;
    private bool moveRight;
    public float health;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        shopManager = FindObjectOfType<ShopManager>();
    }

    private void Update()
    {
        if(moveRight == true)
        {
            rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MeringueTurn" && moveRight == true || collision.tag == "Meringue" && moveRight == true)
        {
            moveRight = false;
        }
        else if (collision.tag == "MeringueTurn" && moveRight == false || collision.tag == "Meringue" && moveRight == false)
        {
            moveRight = true;
        }
        else if (collision.tag == "CottonCandy")
        {
            FindObjectOfType<AudioManager>().Play("EnemyDamage");
            cottonCandy = collision.GetComponent<CottonCandy>();
            health -= cottonCandy.damage;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                FindObjectOfType<AudioManager>().Play("Coin");
                shopManager.money++;
                Destroy(gameObject);
            }
        }
        else if (collision.tag == "Cupcake")
        {
            FindObjectOfType<AudioManager>().Play("CupcakeDamage");
            playerMovement.health--;
            Destroy(gameObject);
        }
    }
}
