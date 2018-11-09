using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BranchSpawner : MonoBehaviour 
{
    private Slider _sapUI;
    private float _sap;

    public float maxSap;
    public Camera mainCam;
    public GameObject branch;
    public enum Direction { Left, Right };

    public bool HasSap 
    {
        get { return _sap > 0; }
    }

    public float Sap 
    {
        get { return _sap;  }
        set 
        {
            _sap = value;
            _sapUI.value = _sap;
        }
    }

    private void Start() 
    {
        _sapUI = GameObject.Find("Sap Bar").GetComponent<Slider>();
        _sapUI.maxValue = maxSap;
        Sap = maxSap;
    }

    // Update is called once per frame
    private void Update() 
    {
        GrowBranchesOnClick();
	}

    private void GrowBranchesOnClick() 
    {
        if (Input.GetMouseButtonDown(0) && this.HasSap) 
        {
            RaycastHit2D mouseRayTarget = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // Used code from this forum:
            // https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
            if (mouseRayTarget == true) 
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

                Vector2 branchSpawnLocation = new Vector2(branchSpawnOffset, mouseRayTarget.point.y);
                GameObject currentBranch = Instantiate(branch, branchSpawnLocation, Quaternion.identity);

                BranchScript currentBranchScript = currentBranch.GetComponent<BranchScript>();

                if (currentBranchScript != null) 
                {
                    if (mouseRayTarget.collider.transform.position.x <= 0f) 
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
