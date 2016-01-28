﻿using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    private Rigidbody2D physics;
    private GameObject player;

    private float timer = 5f;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Spaceman");
        PlayerController controller = player.GetComponent<PlayerController>();  

        physics = GetComponent<Rigidbody2D>();

        if (controller.isFacingRight)
        {
            physics.AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
        }
        else
        {
            physics.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);
        }
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
	}
}
