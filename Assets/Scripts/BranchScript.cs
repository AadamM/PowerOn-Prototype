using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour 
{
    private Transform _transform;
    private BranchSpawner _spawner;
    private BoxCollider2D _collider;

    public BranchSpawner.Direction treeLocation;
    public float speed;
    public float xScale;
    public Vector2 maxScale;

	private void Start() 
    {
        _spawner = GameObject.Find("Branch Spawner").GetComponent<BranchSpawner>();
        _transform = GetComponentInChildren<Transform>();
        _transform.localScale = new Vector2(xScale, 0.75f);
        _collider = GetComponent<BoxCollider2D>();

        if (treeLocation == BranchSpawner.Direction.Right) 
        {
            GetComponent<SpriteRenderer>().flipX = true;
            _collider.offset = new Vector2(-_collider.offset.x, _collider.offset.y);
        }
	}
	
	private void Update() 
    {
        if (_transform.localScale.x < maxScale.x && _spawner.HasSap) 
        {
            _transform.localScale += new Vector3(speed, 0f, 0f);
            _spawner.Sap -= 1;
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            Destroy(this);
        }
	}
}
