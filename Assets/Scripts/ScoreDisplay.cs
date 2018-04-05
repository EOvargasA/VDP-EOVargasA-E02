using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text scoreText = GetComponent<Text> ();
		scoreText.text = ScoreKeeper.score.ToString ();
        //ScoreKeeper.Reset();
    }
}
