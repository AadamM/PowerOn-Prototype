using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapScript : MonoBehaviour 
{
    public float sapRefillPercentage;

    private BranchSpawner _spawner;

    private void Start() 
    {
        _spawner = GameObject.Find("Branch Spawner").GetComponent<BranchSpawner>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        RefillSap();
        Destroy(gameObject);
    }

    private void RefillSap() 
    {
        _spawner.Sap += (_spawner.maxSap * sapRefillPercentage);
        if (_spawner.Sap > _spawner.maxSap) 
        {
            _spawner.Sap = _spawner.maxSap;
        }
    }
}
