using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    [SerializeField] private GameObject flower;
    
    public static AudioSource SheepSound;

    private const float FlowerMoveSpeed = 20;

    void Update()
    {
        flower.transform.position += Vector3.up * (FlowerMoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject temp = col.gameObject;
        if (temp.name.Contains("Sheep"))
        {
            ShipManager.NumBullets--;
            GameManager.NumSheeps--;
            col.gameObject.SetActive(false);
            flower.SetActive(false);
            SheepSound.Play();
        }
        else if (temp.name.Contains("Wall"))
        {
            ShipManager.NumBullets--;
            flower.SetActive(false);
        }
    }
}
