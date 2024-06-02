using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    private GameObject playerObject;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Find the player GameObject with the tag "Player"
        playerObject = GameObject.FindWithTag("Player");
        if (playerObject == null)
        {
            Debug.LogError("Player object not found. Make sure it has the 'Player' tag assigned.");
            return;
        }

        // Get the SpriteRenderer component of this object
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerObject != null)
        {
            // Check if the player is above or below the object
            if (playerObject.transform.position.y > transform.position.y)
            {
                // Player is above the object
                // Set sorting order of the object's SpriteRenderer lower than the player's
                spriteRenderer.sortingOrder = playerObject.GetComponent<SpriteRenderer>().sortingOrder - 1;
                Debug.Log("---");
            }
            else
            {
                // Player is below the object
                // Set sorting order of the object's SpriteRenderer higher than the player's
                spriteRenderer.sortingOrder = playerObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
                Debug.Log("+++");
            }

        }
    }
}
