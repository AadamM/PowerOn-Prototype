using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private Vector2 _cameraOffset;
    private float _playerStartingHeight;

    public GameObject player;

	// Use this for initialization.
	void Start () {
        _playerStartingHeight = player.transform.position.y;
        _cameraOffset = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
	}
	
	// Update is called once per frame.
	void Update () {
        transform.position = new Vector3(0, (player.transform.position.y-_playerStartingHeight), -10f);
	}
}
