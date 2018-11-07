using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour {
    private Vector3 startScale;
    private Transform branchTransform;

    public BranchSpawner.Direction treeLocation;
    public float speed;
    public float xScale;
    public Vector3 maxScale;

	// Use this for initialization
	void Start () {
        branchTransform = GetComponentInChildren<Transform>();
        branchTransform.localScale = new Vector3(xScale, 1f, 1f);

        if (treeLocation == BranchSpawner.Direction.Left) {
            branchTransform.Translate(xScale/2, 0f, 0f);
        } else {
            branchTransform.Translate(-xScale/2, 0f, 0f);
        }

        startScale = branchTransform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (branchTransform.localScale.x < maxScale.x) {
            if (treeLocation == BranchSpawner.Direction.Left) {
                branchTransform.Translate(5f*speed, 0f, 0f);
            } else {
                branchTransform.Translate(-5f*speed, 0f, 0f);
            }
            branchTransform.localScale += new Vector3(speed, 0f, 0f);
        }

        if (Input.GetMouseButtonUp(0)) {
            Destroy(this);
        }
	}
}
