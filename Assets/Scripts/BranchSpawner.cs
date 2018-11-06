using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawner : MonoBehaviour {
    private Ray mouseRay;
    private RaycastHit mouseRayTarget;
    private GameObject currentBranch;

    public Camera mainCam;
    public GameObject branch;
    public enum Direction { Left, Right };

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        GrowBranchesOnClick();
	}

    private void GrowBranchesOnClick() {
        if (Input.GetMouseButtonDown(0))
        {
            mouseRay = mainCam.ScreenPointToRay(Input.mousePosition);

            // Used code from this forum:
            // https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
            if (Physics.Raycast(mouseRay, out mouseRayTarget))
            {
                float branchSpawnOffset = 0f;

                if (mouseRayTarget.point.x < 0)
                {
                    branchSpawnOffset = -7.5f;
                }
                else
                {
                    branchSpawnOffset = 7.5f;
                }

                Vector3 branchSpawnLocation = new Vector3(branchSpawnOffset, mouseRayTarget.point.y, 0f);

                GameObject currentBranch = Instantiate(branch, branchSpawnLocation, Quaternion.identity);

                BranchScript currentBranchScript = currentBranch.GetComponent<BranchScript>();

                if (currentBranchScript != null)
                {
                    if (mouseRayTarget.collider.name == "Tree Left")
                    {
                        currentBranchScript.treeLocation = Direction.Left;
                    }
                    else
                    {
                        currentBranchScript.treeLocation = Direction.Right;
                    }
                }
            }
        }
    }
}
