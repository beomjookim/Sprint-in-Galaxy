﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movedownleft : MonoBehaviour {

    public float speed = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += Vector3.left * speed * Time.deltaTime * 2 + Vector3.down * speed * Time.deltaTime;


    }
}
