﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BranchSpawner : MonoBehaviour 
{
    private Slider _sapUI;
    private float _sap;

    public float maxSap;
    public float spawnLocationOffset;
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
        this.Sap = maxSap;
    }

    // Update is called once per frame.
    private void Update() 
    {
        GrowBranchesOnClick();
    }

    private void GrowBranchesOnClick() 
    {
        if (Input.GetMouseButtonDown(0) && this.HasSap) 
        {
            // I used used code similar to mrsquare's response to troubleshoot 2D raycasts:
            // https://forum.unity.com/threads/unity-2d-raycast-from-mouse-to-screen.211708/
            RaycastHit2D mouseRayTarget = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (mouseRayTarget == true) 
            {
                float branchSpawnOffset = 0f;

                if (mouseRayTarget.point.x < 0) 
                {
                    branchSpawnOffset = -spawnLocationOffset;
                }
                else 
                {
                    branchSpawnOffset = spawnLocationOffset;
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
