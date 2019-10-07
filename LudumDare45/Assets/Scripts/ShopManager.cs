using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public Animator shopAnimator;
    public bool inShop = false;
    private PlayerMovement playerMovement;
    public float cottonCandyDamage;
    public int money;
    public Text moneyText;
    private GameManager gameManager;

    [Header("Shop Prices")]
    [Range(0, 100)]
    public int sugarPrice;
    [Range(0, 100)]
    public int cottonCandyPrice;
    [Range(0, 100)]
    public int sprinklesPrice;
    [Range(0, 100)]
    public int jellyPrice;
    [Range(0, 100)]
    public int butterPrice;

    [Header("Purchase Values")]
    [Range(0, 100)]
    public int sugarValue; 
    [Range(0, 100)]
    public float cottonCandyValue;
    [Range(0, 100)]
    public int sprinklesValue;
    [Range(0, 100)]
    public float jellyValue;
    [Range(0, 100)]
    public int butterValue;

    [Header("Shop Descriptions")]
    public string currency;
    [Space(10)]
    public Text sugarDescriptionText;
    public Text cottonCandyDescriptionText;
    public Text sprinkleDescriptionText;
    public Text jellyDescriptionText;
    public Text butterDescriptionText;
    [Space(10)]
    public string sugarDescription;
    public string cottonCandyDescription;
    public string sprinkleDescription;
    public string jellyDescription;
    public string butterDescription;

    public Button sugarButton;
    public Button cottonCandyButton;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(playerMovement.health == 3)
        {
            sugarButton.interactable = false;
        }
        else
        {
            sugarButton.interactable = true;
        }
        if(playerMovement.addAmmoDelay <= .5)
        {
            cottonCandyButton.interactable = false;
        }
        ManageText();
    }

    public void PurchaseSugar() // Increase health
    {
        if(money >= sugarPrice)
        {
            FindObjectOfType<AudioManager>().Play("Upgrade");
            money -= sugarPrice;
            playerMovement.health += sugarValue;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void PurchaseCottonCandy() // Increase cotton candy regeneration
    {
        if(money >= cottonCandyPrice)
        {
            FindObjectOfType<AudioManager>().Play("Upgrade");
            money -= cottonCandyPrice;
            playerMovement.addAmmoDelay -= cottonCandyValue;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void PurchaseSprinkes() // Increase damage count
    {
        if(money >= sprinklesPrice)
        {
            FindObjectOfType<AudioManager>().Play("Upgrade");
            money -= sprinklesPrice;
            cottonCandyDamage += sprinklesValue;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void PurchaseJelly() // Increase extrajumps
    {
        if(money >= jellyPrice)
        {
            FindObjectOfType<AudioManager>().Play("Upgrade");
            money -= jellyPrice;
            playerMovement.jumpForce += jellyValue;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void PurchaseButter() // Increase speed
    {
        if(money >= butterPrice)
        {
            FindObjectOfType<AudioManager>().Play("Upgrade");
            money -= butterPrice;
            playerMovement.movementSpeed += butterValue;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    private void ManageText()
    {
        moneyText.text = "Currency: " + money.ToString();
        sugarDescriptionText.text = sugarDescription + " " + sugarPrice.ToString() + currency;
        cottonCandyDescriptionText.text = cottonCandyDescription + " " + cottonCandyPrice.ToString() + currency;
        sprinkleDescriptionText.text = sprinkleDescription + " " + sprinklesPrice.ToString() + currency;
        jellyDescriptionText.text = jellyDescription + " " + jellyPrice.ToString() + currency;
        butterDescriptionText.text = butterDescription + " " + butterPrice.ToString() + currency;
    }

    public void Shop()
    {
        if (inShop == false)
        {
            shopAnimator.SetBool("InShop", true);
            inShop = true;
        }
        else if (inShop == true)
        {
            shopAnimator.SetBool("InShop", false);
            inShop = false;
            gameManager.SpawnEverything();
        }
    }
}
