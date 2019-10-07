using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Transform startPoint;
    public Transform player;
    public GameObject coinPrefab;
    public GameObject enemyPrefab;
    public GameObject[] coinSpawnPoints;
    public GameObject[] enemySpawnPoints;
    public List<GameObject> activeEnemys = new List<GameObject>();
    public List<GameObject> activeCoins = new List<GameObject>();
    private PlayerMovement playerMovement;
    public bool gameHasEnded = false;
    public int roundsCompleted;
    public Text roundsCompletedText;
    public GameObject gameOverUI;

    private void Start()
    {
        SpawnEverything();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        CheckForNull();
        if(playerMovement.health <= 0 && gameHasEnded == false)
        {
            EndGame();
        }
    }

    public void SpawnEverything()
    {
        player.transform.position = startPoint.transform.position;
        activeEnemys.Clear();
        activeCoins.Clear();
        for (int i = 0; i < coinSpawnPoints.Length; i++)
        {
            GameObject newCoin = Instantiate(coinPrefab, coinSpawnPoints[i].transform.position, Quaternion.identity);
            activeCoins.Add(newCoin);
        }
        for (int i = 0; i < enemySpawnPoints.Length; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, enemySpawnPoints[i].transform.position, Quaternion.identity);
            activeEnemys.Add(newEnemy);
        }
    }

    public void CheckForNull()
    {
        for (int i = 0; i < activeEnemys.Count; i++)
        {
            if(activeEnemys[i] == null)
            {
                activeEnemys.RemoveAt(i);
            }
        }
        for (int i = 0; i < activeCoins.Count; i++)
        {
            if (activeCoins[i] == null)
            {
                activeCoins.RemoveAt(i);
            }
        }
    }

    public void EndGame()
    {
        gameHasEnded = true;
        gameOverUI.SetActive(true);
        roundsCompletedText.text = "Rounds Completed: " + roundsCompleted.ToString();
    }
}
