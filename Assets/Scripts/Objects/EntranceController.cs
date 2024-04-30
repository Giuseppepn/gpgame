using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceController : MonoBehaviour
{
    [SerializeField] private string transitionName;
    [SerializeField] GameObject playerPrefab;
    private void Start()
    {
        if (transitionName == SceneController.Instance.SceneTransitionName)
        {
            SpawnPlayer();
        }
    }

    private void SpawnPlayer()
    {
        if (playerPrefab != null)
        {
            GameObject player = Instantiate(playerPrefab);
            player.transform.position = this.transform.position;
        }
    }
}
