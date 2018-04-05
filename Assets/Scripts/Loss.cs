using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Loss : MonoBehaviour {

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject;
        if (player.layer == 8)
        {
            SceneManager.LoadScene("Loss");
        }
    }
}
