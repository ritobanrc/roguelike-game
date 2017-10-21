﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Coord PlayerPosition { get; protected set; }

    public float speed = 6f;
    public float waitAfterMove = 0.01f;

    private Rigidbody2D rb;
    private bool currentlyMoving;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerPosition = new Coord(0, 0);
    }

    private void FixedUpdate()
    {
        int h = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        int v = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        if (currentlyMoving == false && (Mathf.Abs(h) + Mathf.Abs(v)) == 1)
            StartCoroutine(Move(h, v));
    }

    private IEnumerator Move(int h, int v)
    {
        PlayerPosition += new Coord(h, v);
        CheckValidPosition(PlayerPosition);
        currentlyMoving = true;
        Debug.Log("Started Move to Position: " + PlayerPosition.ToString());
        while((PlayerPosition.AsV2 - rb.position).sqrMagnitude > 0.02)
        {
            rb.MovePosition(rb.position + new Vector2(h, v) * speed * Time.deltaTime);
            yield return null;
        }
        rb.MovePosition(PlayerPosition.AsV2);
        Debug.Log("Move Completed. PlayerPosition: " + PlayerPosition.ToString());
        yield return new WaitForSeconds(waitAfterMove);
        currentlyMoving = false;
    }

    private void CheckValidPosition(Coord playerPosition)
    {
        // Do stuff here. 

    }
}
