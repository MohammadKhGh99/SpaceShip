using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SheepManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D sheep;
    [SerializeField] private float maxSpeed; 

    // private const float MaxSpeed = 3;
    private Vector3 _movement;
    private float _timeLeft = 1;

    // Update is called once per frame
    void Update()
    {
        _timeLeft -= Time.deltaTime;
        if (sheep.gameObject.activeInHierarchy && _timeLeft <= 0)
        {
            _movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _timeLeft = 1;
        }
    }
    
    void FixedUpdate()
    {
        sheep.AddForce(_movement * maxSpeed);
    }

    // private void OnCollisionEnter2D(Collision2D col)
    // {
    //     if (col.collider.name.Contains("Sheep"))
    //     {
    //         // ScoreManager.instance.Reduce5Points();
    //         GameManager.Score -= 3;
    //     }
    // }
}
