﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private Vector3 _cameraStartingPosition;
    private PlayerMovement _playerController;

    public GameObject player;

	// Use this for initialization.
	void Start () {
        _cameraStartingPosition = transform.position;
        _playerController = player.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame.
	void FixedUpdate () {
        if (player.transform.position.y > (transform.position.y + (GetComponent<Camera>().orthographicSize / 4)))
        {
            transform.Translate(0f, _playerController.playerRigidbody.velocity.y * Time.fixedDeltaTime, 0f);
            //transform.position = new Vector3(0, (player.transform.position.y - _playerStartingHeight), -10f);
        }
        else if(player.transform.position.y < (transform.position.y - (GetComponent<Camera>().orthographicSize / 4)) && (_playerController.playerRigidbody.velocity.y < 0))
        {
            transform.Translate(0f, _playerController.playerRigidbody.velocity.y * Time.fixedDeltaTime, 0f);
        }

        if (transform.position.y < _cameraStartingPosition.y)
        {
            transform.position = _cameraStartingPosition;
        }
	}
}
