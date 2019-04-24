using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDebug : MonoBehaviour {

    public float speed = 3;

	void Update ()
    {
        Move();
	}

    void Move()
    {
        float axis = Input.GetAxis("Horizontal");

        transform.Translate(axis * speed, 0, 0);
    }
}
