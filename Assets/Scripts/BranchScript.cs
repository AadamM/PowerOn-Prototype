using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour 
{
    private Transform _transform;
    private BranchSpawner _spawner;

    public BranchSpawner.Direction treeLocation;
    public float speed;
    public float xScale;
    public Vector2 maxScale;

	private void Start() 
    {
        _spawner = GameObject.Find("Branch Spawner").GetComponent<BranchSpawner>();
        _transform = GetComponentInChildren<Transform>();
        _transform.localScale = new Vector2(xScale, 0.75f);

        if (treeLocation == BranchSpawner.Direction.Left) 
        {
            _transform.Translate(new Vector2(xScale/2, 0f));
        } 
        else 
        {
            _transform.Translate(new Vector2(-xScale/2, 0f));
        }
	}
	
	private void Update() 
    {
        if (_transform.localScale.x < maxScale.x && _spawner.HasSap) 
        {
            if (treeLocation == BranchSpawner.Direction.Left) 
            {
                _transform.Translate(new Vector2(.5f*speed, 0f));
            } 
            else 
            {
                _transform.Translate(new Vector2(-.5f*speed, 0f));
            }
            _transform.localScale += new Vector3(speed, 0f, 0f);
            _spawner.Sap -= 1;
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            Destroy(this);
        }
	}
}
