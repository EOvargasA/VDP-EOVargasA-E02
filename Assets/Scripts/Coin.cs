using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public int scoreValue = 100;

    private ScoreKeeper scoreKeeper;

    // Use this for initialization
    void Start () {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);
    }
}
