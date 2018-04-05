using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LifeTracer : MonoBehaviour {

    public int Hits = 0;
    public Transform[] waypoints;


    // Use this for initialization
    void Start () {
        waypoints = new Transform[transform.childCount];

        int i = 0;

        foreach (Transform t in transform)
        {
            waypoints[i++] = t;
        }
    }

    public void Hit() {
        Destroy(waypoints[Hits].gameObject);
        Hits++;
        if (Hits >= 3)
        {
            SceneManager.LoadScene("Loss");
        }
    }
}
