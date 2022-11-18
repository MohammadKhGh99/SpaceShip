using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ShipManager : MonoBehaviour
{
    [SerializeField] private float shipMoveSpeed;
    // [SerializeField] private int tankId;
    // [SerializeField] private float delayParam1;
    [SerializeField] private Rigidbody2D shipRb;
    [SerializeField] private GameObject bulletsParent;
    [SerializeField] private int maxBullets;
    
    public static int NumBullets;
    private float _bulletCoolDown = 1;
    private bool _firstShooting = true;
    private int _initialBulletsNum;
    private GameObject[] _bullets;

    // Start is called before the first frame update
    void Start()
    {
        _bullets = new GameObject[maxBullets];
        // NumBullets = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_initialBulletsNum == maxBullets)
        {
            _firstShooting = false;
        }

        _bulletCoolDown -= Time.deltaTime;

        if (!Input.GetKeyDown(KeyCode.Space) || NumBullets >= maxBullets || _bulletCoolDown > 0) return;
        
        _bulletCoolDown = 1;
        
        if (_firstShooting)
        {
            var tempBullet = Instantiate(Resources.Load("LaserBeam"), parent: bulletsParent.transform) as GameObject;
            // print(NumBullets);
            _bullets[_initialBulletsNum] = tempBullet;
            _initialBulletsNum++;
            NumBullets++;
        }
        else
        {
            foreach (var bullet in _bullets)
            {
                if (bullet.activeInHierarchy) continue;
                NumBullets++;
                Vector3 tempPos = shipRb.transform.position;
                bullet.transform.position = new Vector3(tempPos.x, tempPos.y + 1.5f, tempPos.z);
                bullet.SetActive(true);
                break;
            }
        }
    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            shipRb.AddForce(Vector2.up * shipMoveSpeed);
            // shipBody.transform.position += shipBody.transform.up * (shipMoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            shipRb.AddForce(Vector2.down * shipMoveSpeed);
            // shipBody.transform.position -= shipBody.transform.up * (shipMoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            shipRb.AddForce(Vector2.left * shipMoveSpeed);
            // shipBody.transform.position += shipBody.transform * (shipMoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            shipRb.AddForce(Vector2.right * shipMoveSpeed);
            // shipBody.transform.position -= shipBody.transform.forward * (shipMoveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.StartsWith("Yellow"))
        {
            GameManager.NumDiamonds--;
            col.gameObject.SetActive(false);
            GameManager.Score++;
        }
        if (col.gameObject.name.StartsWith("Blue"))
        {
            GameManager.NumDiamonds--;
            col.gameObject.SetActive(false);
            GameManager.Score += 2;
        }
        if (col.gameObject.name.StartsWith("Red"))
        {
            GameManager.NumDiamonds--;
            col.gameObject.SetActive(false);
            GameManager.Score += 3;
        }
    }
}