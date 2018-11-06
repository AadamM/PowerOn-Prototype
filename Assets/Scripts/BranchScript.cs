using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour {

    private Vector3 startScale;
    private Transform branchForm;
    private bool isClicked;

    public bool leftBranch;
    public float speed;
    public float xScale;
    public Vector3 maxScale;

    //public bool isClicked;

	// Use this for initialization
	void Start () {
        isClicked = true;
        branchForm = GetComponentInChildren<Transform>();
        branchForm.localScale = new Vector3(xScale, 1f, 1f);

        if (leftBranch) {
            //branchForm.localPosition += new Vector3(5f, 0f, 0f);
            branchForm.Translate(xScale/2, 0f, 0f);
        } else {
            //branchForm.localPosition -= new Vector3(5f, 0f, 0f);
            branchForm.Translate(-xScale/2, 0f, 0f);
        }

        startScale = branchForm.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if ((branchForm.localScale.x < maxScale.x) && Input.GetMouseButton(0) && isClicked) {
            //branchForm.localPosition += new Vector3(-(branchForm.localScale.x/2), 0f, 0f);
            if (leftBranch) {
                branchForm.Translate(5f*speed, 0f, 0f);
            } else {
                branchForm.Translate(-5f*speed, 0f, 0f);
            }
            branchForm.localScale += new Vector3(speed, 0f, 0f);
        }

        if (Input.GetMouseButtonUp(0)) {
            isClicked = false;
        }
	}
}
