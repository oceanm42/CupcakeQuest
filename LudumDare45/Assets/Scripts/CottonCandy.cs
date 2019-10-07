using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CottonCandy : MonoBehaviour {

    private Rigidbody2D rb;
    private PlayerMovement playerMovement;
    private ShopManager shopManager;
    private bool facingRight;
    public float speed;
    public float destroyTime;
    private SpriteRenderer sr;
    public float damage;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
        damage = shopManager.cottonCandyDamage;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        facingRight = playerMovement.facingRight;
        StartCoroutine(DestroyObject());
        if (facingRight == true)
        {
            return;
        }
        else
        {
            sr.flipX = true;
            speed *= -1;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Surface")
        {
            Destroy(gameObject);
        }
    }
}
