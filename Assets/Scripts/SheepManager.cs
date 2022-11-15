using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class SheepManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D sheep;
    // [SerializeField] private GameObject sheepParent;
    // [SerializeField] private Renderer renderer;
    // [SerializeField] private Collider2D collider2d;
    
    private readonly float _maxSpeed = 1;
    private Vector3 _movement;
    private float _timeLeft = 1;
    // private Vector3 _intialPosition;
    // private float _deathTime;

    // Start is called before the first frame update
    // void Start()
    // {
    //     // _intialPosition = sheep.transform.localPosition;
    //     _maxSpeed = 1;
    //     _timeLeft = 1;
    //     // _deathTime = 3;
    // }

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
        // if (sheep.gameObject.activeInHierarchy)
        // {
        sheep.AddForce(_movement * _maxSpeed);
        // }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("  Collision  " + col.collider.name);
        if (col.collider.name.StartsWith("laser"))  // !col.collider.name.StartsWith("tank") && !col.collider.name.StartsWith("Sheep")))
        {
            GameManager.NumSheeps--;
            Destroy(sheep);
            sheep.gameObject.SetActive(false);
        }
        
        // if (col.collider.gameObject.name.StartsWith("bullet"))
        // {
            // sheep.transform.SetParent(sheepParent.transform);
            // sheep.gameObject.transform.localPosition = _intialPosition;
            // sheep.gameObject.SetActive(false);
            // renderer.enabled = false;
            // sheep.position = _intialPosition;
        // }

        // if (col.collider.gameObject.name.StartsWith("Tank"))
        // {
        //     collider2d.enabled = false;
        // }
    }

    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     if (other.collider.name.StartsWith("Tank"))
    //     {
    //         collider2d.enabled = true;
    //     }
    // }
}
