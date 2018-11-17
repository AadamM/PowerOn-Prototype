﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour 
{
    private Transform _transform;
    private ForestController _controller;
    private BoxCollider2D _collider;
    private bool _isFading;
    private float _storedSap;
    private Vector3 _staringScale;

    public float speed;
    public float xScale;
    public Vector2 maxScale;
    public bool isStatic = false;

    private bool _isGrowing;

    #region Public Properties

    public bool IsGrowing
    {
        get { return _isGrowing; }
        set { _isGrowing = value; }
    }

    public bool IsMaxLength
    {
        get { return _transform.localScale.x >= maxScale.x; }
    }

    #endregion Public Properties

    public void FadeAndDestroy()
    {
        if (!isStatic)
        {
            _isFading = true;
        }
    }

    private void Start() 
    {
        _controller = GameObject.Find("Forest Controller").GetComponent<ForestController>();
        _transform = GetComponentInChildren<Transform>();
        if (isStatic)
        {
            maxScale = _transform.localScale;
            xScale = _transform.localScale.x/4f;
        }
        _transform.localScale = new Vector2(xScale, 0.75f);
        _collider = GetComponent<BoxCollider2D>();

        // If the branch is on the right tree, flip its sprite and collider.
        if (_transform.position.x > 0f && !isStatic)
        {
                GetComponent<SpriteRenderer>().flipX = true;
                _collider.offset = new Vector2(-_collider.offset.x, _collider.offset.y);
            
        }

        IsGrowing = true;
        _isFading = false;
        _storedSap = 0;
	}
	
	private void Update() 
    {
        //if (!isStatic)
        //{
            Grow();
        //}
        HandleFading();
	}

    #region Private Helper Functions

    private void Grow()
    {
        if (!IsMaxLength && _controller.HasSap && IsGrowing)
        {

            _transform.localScale += new Vector3(speed, 0f, 0f);
            
            if (!isStatic)
            {
                _controller.Sap--;
            }
            _storedSap++;
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsGrowing = false;
        }
    }

    private void HandleFading()
    {
        if (_isFading)
        {
            var sprite = GetComponent<SpriteRenderer>();
            
            var newColor = sprite.color;

            var alpha = sprite.color.a;
            alpha -= 0.03f;

            newColor.a = alpha;
            sprite.color = newColor;

            if (alpha <= 0f)
            {
                _controller.Sap += _storedSap;
                Destroy(gameObject);
            }
        }
    }

    #endregion

}
