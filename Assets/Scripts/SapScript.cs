using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapScript : MonoBehaviour {
    public float refillPercentage;

    private BranchSpawner spawner;

    private void Start() {
        spawner = GameObject.Find("Branch Spawner").GetComponent<BranchSpawner>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        RefillSap();
        Destroy(gameObject);
    }

    private void RefillSap() {
        spawner.Sap += (spawner.maxSap * refillPercentage);
        if (spawner.Sap > spawner.maxSap) {
            spawner.Sap = spawner.maxSap;
        }
    }
}
