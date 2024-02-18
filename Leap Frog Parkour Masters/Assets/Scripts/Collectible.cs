using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static int playerOneCollectibles = 0;
    public static int playerTwoCollectibles = 0;

    public static event Action OnCollected;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player One")
        {
            OnCollected?.Invoke();
            gameObject.SetActive(false);
            playerOneCollectibles++;

            Debug.Log("Player One Collect: " + playerOneCollectibles);
        }
        else if (other.gameObject.name == "Player Two")
        {
            OnCollected?.Invoke();
            gameObject.SetActive(false);
            playerTwoCollectibles++;

            Debug.Log("Player Two Collect: " + playerTwoCollectibles);
        }
    }

    public int GetPlayerOneCollectibles()
    {
        return playerOneCollectibles;
    }

    public int GetPlayerTwoCollectibles()
    {
        return playerTwoCollectibles;
    }
}
