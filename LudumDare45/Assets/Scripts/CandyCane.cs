using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCane : MonoBehaviour {

    private ShopManager shopManager;
    private GameManager gameManager;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Cupcake" && shopManager.inShop == false)
        {
            gameManager.roundsCompleted++;
            shopManager.Shop();
        }
    }
}
