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
    public GameObject branchObj;
    public enum Direction { Left, Right };

    #region Public Properties

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

    #endregion Public Properties

    private void Start() 
    {
        _sapUI = GameObject.Find("Sap Bar").GetComponent<Slider>();
        _sapUI.maxValue = maxSap;
        this.Sap = maxSap;
    }

    // Update is called once per frame
    private void Update() 
    {
        HandleLeftClicks();
    }

    #region Private Helper Functions

    private void HandleLeftClicks() 
    {
        if (Input.GetMouseButtonDown(0) && this.HasSap) 
        {
            var mouseRayTarget = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (mouseRayTarget.collider != null)
            {
                if (mouseRayTarget.collider.tag == "Tree")
                {
                    GrowNewBranch(mouseRayTarget);
                }
                else if (mouseRayTarget.collider.tag == "Branch")
                {
                    GrowExistingBranch(mouseRayTarget);
                }
            }           
        }
    }

    #region Growing New Branches (Helper Functions)

    private void GrowNewBranch(RaycastHit2D mouseRayTarget)
    {
        var spawnLocation = CalculateBranchSpawnLocation(mouseRayTarget);
        SpawnBranch(spawnLocation);
    }

    private Vector2 CalculateBranchSpawnLocation(RaycastHit2D mouseRayTarget)
    {
        float horizontalSpawnPoint = 0f;
        float verticalSpawnPoint = mouseRayTarget.point.y;

        if (mouseRayTarget.point.x < 0)
        {
            horizontalSpawnPoint = -7.5f;
        }
        else
        {
            horizontalSpawnPoint = 7.5f;
        }

        return new Vector2(horizontalSpawnPoint, verticalSpawnPoint);
    }

    private void SpawnBranch(Vector2 branchSpawnLocation)
    {
        GameObject branch = Instantiate(branchObj, branchSpawnLocation, Quaternion.identity);

        BranchScript branchScript = branch.GetComponent<BranchScript>();

        if (branchSpawnLocation.x <= 0f)
        {
            branchScript.treeLocation = Direction.Left;
        }
        else 
        {
            branchScript.treeLocation = Direction.Right;
        }
        branchScript.IsGrowing = true;
    }

    #endregion Growing New Branches

    #region Growing Existing Branches (Helper Functions)

    private void GrowExistingBranch(RaycastHit2D mouseRayTarget)
    {
        var branchScript = mouseRayTarget.collider.GetComponent<BranchScript>();
        branchScript.IsGrowing = true;
    }

    #endregion Growing Existing Branches

    #endregion Private Helper Functions
}
