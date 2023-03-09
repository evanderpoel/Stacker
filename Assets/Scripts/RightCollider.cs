using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject leftCollider;
    [SerializeField]
    private GameObject rightCollider;

    public GameObject centerColumn;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        rightCollider.SetActive(false);
        leftCollider.SetActive(true);
    }
    
    // Update is called once per frame
    void Update()
    {
        centerColumn.transform.Translate(0.01f, 0, 0);
    }
}
