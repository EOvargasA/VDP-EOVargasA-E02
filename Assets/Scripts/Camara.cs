using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

    public Transform objetivo;
    public float suavizado = 5f;
    Vector3 desface;

    // Use this for initialization
    void Start () {
        desface = transform.position - objetivo.position;
	}

    void FixedUpdate()
    {
        Vector3 ObjPosition = objetivo.position + desface;
        transform.position = Vector3.Lerp(transform.position, ObjPosition, suavizado * Time.deltaTime);
    }
}