using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShipManager : MonoBehaviour
{
    [SerializeField] private float shipMoveSpeed;
    [SerializeField] private Rigidbody2D shipRb;
    [SerializeField] private GameObject bulletsParent;
    [SerializeField] private int maxBullets;
    
    public static int NumBullets;
    private float _bulletCoolDown = 0.5f;
    private bool _firstShooting = true;
    private int _initialBulletsNum;
    private GameObject[] _bullets;
    private ScoreManager _manager;

    // Start is called before the first frame update
    void Start()
    {
        _bullets = new GameObject[maxBullets];
        _manager = ScoreManager.Instance;
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
        
        _bulletCoolDown = 0.5f;
        Vector3 tempPos = shipRb.transform.position;
        Vector3 toPos = new Vector3(tempPos.x, tempPos.y + 3.5f, tempPos.z);
        if (_firstShooting)
        {
            GameObject tempBullet = Instantiate(Resources.Load("LaserBeam"), parent: bulletsParent.transform) as GameObject;
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
                bullet.transform.position = toPos;
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
            _manager.UpdateScore();
        }
        if (col.gameObject.name.StartsWith("Blue"))
        {
            GameManager.NumDiamonds--;
            col.gameObject.SetActive(false);
            GameManager.Score += 2;
            _manager.UpdateScore();
        }
        if (col.gameObject.name.StartsWith("Red"))
        {
            GameManager.NumDiamonds--;
            col.gameObject.SetActive(false);
            GameManager.Score += 3;
            _manager.UpdateScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.StartsWith("Evil"))
        {
            GameManager.Score -= 3;
            _manager.UpdateScore();
        }
    }
}