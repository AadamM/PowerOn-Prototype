using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour {

    public float speed;

    private float vSpeed;
    private float moveHorizontal;
    private float moveVertical;
    private CharacterController charCon;
    private float gravity = 1.8f;

	// Use this for initialization
	void Start () {
        charCon = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        moveHorizontal = Input.GetAxis("Horizontal") * speed;
        vSpeed -= gravity * Time.deltaTime;

        charCon.Move(new Vector3(moveHorizontal, vSpeed, 0f));
	}
}
