﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour {

	Animator anim;

    public float health;

	// Use this for initialization
	void Start () {
        health = 10.0f;
   
		anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Menu.killCount += 1;
            if (Menu.killCount >= 4)
                Menu.winState = true;

            Destroy(gameObject);         
        }     
	}
}
