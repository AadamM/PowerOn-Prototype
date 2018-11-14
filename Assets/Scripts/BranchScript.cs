using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour 
{
    private Transform _transform;
    private ForestController _controller;
    private BoxCollider2D _collider;

    public ForestController.Direction treeLocation;
    public float speed;
    public float xScale;
    public Vector2 maxScale;

    private bool _isGrowing;

    #region Public Properties

    public bool IsGrowing
    {
        get { return _isGrowing; }
        set { _isGrowing = value; }
    }

    #endregion Public Properties

    private void Start() 
    {
        _controller = GameObject.Find("Forest Controller").GetComponent<ForestController>();
        _transform = GetComponentInChildren<Transform>();
        _transform.localScale = new Vector2(xScale, 0.75f);
        _collider = GetComponent<BoxCollider2D>();

        if (treeLocation == ForestController.Direction.Right) 
        {
            GetComponent<SpriteRenderer>().flipX = true;
            _collider.offset = new Vector2(-_collider.offset.x, _collider.offset.y);
        }
	}
	
	private void Update() 
    {
        GrowBranchUntilMaxScale();
	}

    #region Private Helper Functions

    private void GrowBranchUntilMaxScale()
    {
        if (_transform.localScale.x < maxScale.x && _controller.HasSap && this.IsGrowing)
        {
            _transform.localScale += new Vector3(speed, 0f, 0f);
            _controller.Sap -= 1;
        }

        if (Input.GetMouseButtonUp(0))
        {
            this.IsGrowing = false;
        }
    }

    #endregion

}
