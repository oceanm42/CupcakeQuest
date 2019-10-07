using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject[] sugar;
    public GameObject[] cottonCandy;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        for (int i = 0; i < cottonCandy.Length; i++)
        {
            if(playerMovement.ammoLeft > i)
            {
                cottonCandy[i].SetActive(true);
            }
            else
            {
                cottonCandy[i].SetActive(false);
            }
        }

        for (int i = 0; i < sugar.Length; i++)
        {
            if(playerMovement.health > i)
            {
                sugar[i].SetActive(true);
            }
            else
            {
                sugar[i].SetActive(false);
            }
        }
    }
}
