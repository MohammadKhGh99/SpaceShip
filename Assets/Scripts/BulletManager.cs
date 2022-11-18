using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private GameObject flower;
    [SerializeField] private GameObject ship;
    [SerializeField] private float flowerMoveSpeed;
    
    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        _direction = ship.transform.up;
    }

    void Update()
    {
        flower.transform.position += _direction * (flowerMoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Sheep"))
        {
            ShipManager.NumBullets--;
            GameManager.NumSheeps--;
            col.gameObject.SetActive(false);
            flower.SetActive(false);
        }
        else if (col.gameObject.name.Contains("Wall"))
        {
            ShipManager.NumBullets--;
            flower.SetActive(false);
        }
    }
}
