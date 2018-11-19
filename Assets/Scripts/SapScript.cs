using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapScript : MonoBehaviour 
{
    public float sapRefillPercentage;

    private ForestController _controller;
    private ForestController1 _controller1;
    private ForestController2 _controller2;

    private void Start() 
    {
        _controller = GameObject.Find("Forest Controller").GetComponent<ForestController>();
        _controller1 = GameObject.Find("Forest Controller1").GetComponent<ForestController1>();
        _controller2 = GameObject.Find("Forest Controller2").GetComponent<ForestController2>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        RefillSap();
        Destroy(gameObject);
    }

    private void RefillSap() 
    {
        _controller.Sap += (_controller.maxSap * sapRefillPercentage);
        _controller1.Sap += (_controller.maxSap * sapRefillPercentage);
        _controller2.Sap += (_controller.maxSap * sapRefillPercentage);
        if (_controller.Sap > _controller.maxSap) 
        {
            _controller.Sap = _controller.maxSap;
        }

        if (_controller1.Sap > _controller1.maxSap)
        {
            _controller1.Sap = _controller1.maxSap;
        }

        if (_controller2.Sap > _controller2.maxSap)
        {
            _controller2.Sap = _controller2.maxSap;
        }
    }
}
