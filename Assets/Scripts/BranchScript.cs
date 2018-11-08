using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour {
    private Vector2 startScale;
    private Transform branchTransform;

    public BranchSpawner.Direction treeLocation;
    public float speed;
    public float xScale;
    public Vector2 maxScale;

	// Use this for initialization
	void Start () {
        branchTransform = GetComponentInChildren<Transform>();
        branchTransform.localScale = new Vector2(xScale, 1f);

        if (treeLocation == BranchSpawner.Direction.Left) {
            branchTransform.Translate(new Vector2(xScale/2, 0f));
        } else {
            branchTransform.Translate(new Vector2(-xScale/2, 0f));
        }

        startScale = branchTransform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (branchTransform.localScale.x < maxScale.x) {
            if (treeLocation == BranchSpawner.Direction.Left) {
                branchTransform.Translate(new Vector2(2.5f*speed, 0f));
            } else {
                branchTransform.Translate(new Vector2(-2.5f*speed, 0f));
            }
            branchTransform.localScale += new Vector3(speed, 0f, 0f);
        }

        if (Input.GetMouseButtonUp(0)) {
            Destroy(this);
        }
	}
}
