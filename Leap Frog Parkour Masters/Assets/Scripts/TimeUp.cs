using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUp : MonoBehaviour
{
    private float timeRemaining = 240; // 4 minutes in seconds

    private JumpOverTally jumpOverTally;
    private Collectible collectible;

    void Start()
    {
        jumpOverTally = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpOverTally>();
        collectible = GameObject.FindGameObjectWithTag("Collect").GetComponent<Collectible>();

        if (jumpOverTally == null || collectible == null)
        {
            Debug.LogError("JumpOverTally or Collectible script not found!");
            return;
        } 

        StartCoroutine(CountdownToTimeUp());
    }

    IEnumerator CountdownToTimeUp()
    {
        while (timeRemaining > 0)
        {
            yield return null; // wait for the next frame
            timeRemaining -= Time.deltaTime; // decrease the time remaining
        }

        //freeze the game
        Time.timeScale = 0;

        // Time is up, calculate the totals
        int total = jumpOverTally.GetPlayerOneJumps() + collectible.GetPlayerOneCollectibles();
        int total2 = jumpOverTally.GetPlayerTwoJumps() + collectible.GetPlayerTwoCollectibles();

        Debug.Log("Time is up!");
        Debug.Log("Player One's total: " + total);
        Debug.Log("Player Two's total: " + total2);

            // Compare totals
            if (total > total2)
            {
                Debug.Log("Player One wins!");
            }
            else if (total2 > total)
            {
                Debug.Log("Player Two wins!");
            }
            else
            {
                Debug.Log("It's a draw!");
            }
        }
}
