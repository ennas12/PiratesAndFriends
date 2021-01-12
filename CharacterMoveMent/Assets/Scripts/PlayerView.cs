﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerModel playerModel;

    Vector3 right = Vector3.right;
    Vector3 up = Vector3.up;

    Rigidbody playerRigidbody;

    Vector3 beforePosition;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerModel = GetComponent<PlayerModel>();
        playerRigidbody = GetComponent<Rigidbody>();
        beforePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       

        ViewDirection();
        Move();
    }

    void LateUpdate()
    {
        // 위치 변화를 측정하여 현재 속도를 측정한다.

        Vector3 positionChange = transform.position - beforePosition;
        positionChange /= Time.deltaTime;

        beforePosition = transform.position;
        playerModel.playerVelocity = positionChange;
    }

    void Move()
    {
        Vector3 movedirection = right * playerInput.move * playerModel.speed * Time.deltaTime;

        playerRigidbody.MovePosition(playerRigidbody.position + movedirection);
    }

    void Jump()
    {
        if(playerInput.jump) // 점프키를 누른 순간
            playerModel.isJump = true;

        if(playerInput.jumpoff) // 점프키를 뗀 순간
            playerModel.isJump = false;

        //isJump의 상태 변화에 따라 점프 상태변화를 수행한다.


    }

    void ViewDirection()
    {
        if (playerInput.move < 0)
            playerModel.isLookRight = false;
        else if (playerInput.move > 0)
            playerModel.isLookRight = true;

        /*
         * isLookRight 에 따라 보는 방향 전환;
         */
    }
}