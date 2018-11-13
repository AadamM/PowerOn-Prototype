using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour 
{
    private Transform _transform;
    private BranchSpawner _spawner;
    private float _boxColliderXScale;

    public BranchSpawner.Direction treeLocation;
    public float speed;
    public float xScale;
    public Vector2 maxScale;

	private void Start() 
    {
        _spawner = GameObject.Find("Branch Spawner").GetComponent<BranchSpawner>();
        _transform = GetComponentInChildren<Transform>();
        _transform.localScale = new Vector2(xScale, 0.75f);
        _boxColliderXScale = GetComponent<BoxCollider2D>().offset.x;

        if (treeLocation == BranchSpawner.Direction.Right) 
        {
            //GetComponent<SpriteRenderer>().sprite.pivot.Set(1.0f, 0.5f);
            //_transform.Translate(new Vector2(-xScale/2, 0f));
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<BoxCollider2D>().offset = new Vector2(-_boxColliderXScale, GetComponent<BoxCollider2D>().offset.y);
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
