using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawner : MonoBehaviour {

    private Ray mouseRay;
    private RaycastHit mouseRayTarget;
    private GameObject currentBranch;

    public Camera mainCam;
    public GameObject branch;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)){
            mouseRay = mainCam.ScreenPointToRay(Input.mousePosition);

            // Used code from this forum:
            // https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
            if (Physics.Raycast(mouseRay, out mouseRayTarget)) {
                float branchSpawnOffset = 0f;

                if (mouseRayTarget.point.x < 0) {
                    branchSpawnOffset = -7.5f;
                } else {
                    branchSpawnOffset = 7.5f;
                }
                Vector3 branchSpawn = new Vector3(branchSpawnOffset, mouseRayTarget.point.y, 0f);
                GameObject currentBranch = Instantiate(branch, branchSpawn, Quaternion.identity);
                BranchScript currentBranchScript = currentBranch.GetComponent<BranchScript>();
                if (currentBranchScript != null) {
                    if (mouseRayTarget.collider.name == "Tree Left") {
                        currentBranchScript.leftBranch = true;
                    } else {
                        currentBranchScript.leftBranch = false;
                    }
                }
            }
        }
	}
}
