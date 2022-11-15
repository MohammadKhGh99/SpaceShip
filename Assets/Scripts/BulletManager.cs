using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private GameObject flower;
    // [SerializeField] private GameObject tankTop;
    [SerializeField] private GameObject ship;
    [SerializeField] private float flowerMoveSpeed;
    [SerializeField] private Collider2D shipCollider;
    [SerializeField] private Collider2D bulletCollider;
    
    // private Vector3 _flowerOriginalPosition;
    private Vector3 _direction;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _direction = ship.transform.up;
        Physics2D.IgnoreCollision(shipCollider, bulletCollider);
        // flower.SetActive(true);
        // _flowerOriginalPosition = flower.transform.localPosition;
    }

    void Update()
    {
        flower.transform.position += _direction * (flowerMoveSpeed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("   BulletCollision   " + col.collider.name);
        if (!col.collider.name.StartsWith("tank"))
        {
            GameManager.NumBullets--;
            flower.SetActive(false);
            Destroy(flower);
        }
        // renderer.enabled = false;
        // flower.transform.SetParent(tankTop.transform);
        // flower.transform.localPosition = _flowerOriginalPosition;
        // flower.SetActive(false);
        // }
        // if (col.collider.name.StartsWith("Sheep"))
        // {
        //     col.gameObject.SetActive(false);
        // }
    }
}
