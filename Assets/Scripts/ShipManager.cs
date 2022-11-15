using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ShipManager : MonoBehaviour
{
    [SerializeField] private float shipMoveSpeed;
    // [SerializeField] private float tankRotationSpeed;
    // [SerializeField] private float tankTopRotationSpeed;
    [SerializeField] private float flowerMoveSpeed;
    [SerializeField] private GameObject shipBody;
    // [SerializeField] private GameObject tankTop;
    [SerializeField] private GameObject flower;

    // [SerializeField] private int tankId;
    // [SerializeField] private float delayParam1;
    [SerializeField] private Rigidbody2D shipRb;
    // [SerializeField] private Rigidbody2D sheep1;
    // [SerializeField] private Rigidbody2D sheep2;
    // [SerializeField] private Rigidbody2D sheep3;
    // [SerializeField] private Rigidbody2D sheep4;
    


    private Vector3 _flowerOriginalPosition;

    // private Vector3 _cannonDirection;

    // private Quaternion _cannonRotate;

    // private GameObject[] _bullets;
    // public static Vector3[] CannonDirections;
    // private int _fpsCounter;
    // private float _fpsTime;
    // private Vector3 _initialScale;
    // private float _counter;
    // private static float[] _sheepsDeathTimes = { 3, 3, 3 };

    // Start is called before the first frame update
    void Start()
    {
        // flower.SetActive(false);
        // _counter = 1;
        // _flowerOriginalPosition = flower.transform.localPosition;

        // _fpsCounter = 0;
        // _fpsTime = 1;

        // _bullets = new[]{bullet1, bullet2, bullet3, bullet4};
        // foreach (var bullet in _bullets)
        // {
            // bullet.SetActive(false);
            // bullet.transform.SetParent(tankTop.transform);
        // }
        // CannonDirections = new Vector3[4];

        // _bullets[0] = flower;
        // for (int i = 0; i < _bullets.Length; i++)
        // {
        //     if (i > 0)
        //     {
        //         _bullets[i] = Instantiate(flower);
        //     }
        //
        //     _bullets[i].transform.SetParent(tankTop.transform);
        // }
        
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     
    //     //
    //     // for (int index1 = 0; index1 < delayParam1; index1++)
    //     // {
    //     //     for (int index2 = 0; index2 < 1000; index2++)
    //     //     {
    //     //         int a = 2;
    //     //         var b = DateTime.Now;
    //     //     }
    //     // }
    //
    //     // for (var i = 0; i < _sheeps.Length; i++)
    //     // {
    //     //     if (!_sheeps[i].gameObject.activeInHierarchy)
    //     //     {
    //     //         _sheepsDeathTimes[i] -= Time.deltaTime;
    //     //         if (_sheepsDeathTimes[i] <= 0)
    //     //         {
    //     //             _sheeps[i].gameObject.SetActive(true);
    //     //             _sheepsDeathTimes[i] = 3;
    //     //         }
    //     //     }
    //     // }
    //
    //     // for (var i = 0; i < _bullets.Length; i++)
    //     // {
    //     //     if (_bullets[i].activeInHierarchy)
    //     //     {
    //     //         _bullets[i].transform.position += _cannonDirections[i] * (flowerMoveSpeed * Time.deltaTime);
    //     //     }
    //     // }
    //
    //     if (Input.GetKey(KeyCode.UpArrow))
    //     {
    //         shipBody.transform.position += shipBody.transform.up * (shipMoveSpeed * Time.deltaTime);
    //     }
    //
    //     if (Input.GetKey(KeyCode.DownArrow))
    //     {
    //         shipBody.transform.position -= shipBody.transform.up * (shipMoveSpeed * Time.deltaTime);
    //     }
    //
    //     if (Input.GetKey(KeyCode.LeftArrow))
    //     {
    //         shipBody.transform.position += shipBody.transform * (shipMoveSpeed * Time.deltaTime);
    //         // if (Input.GetKey(KeyCode.DownArrow))
    //         // {
    //         //     shipBody.transform.localEulerAngles -= Vector3.forward * tankRotationSpeed;
    //         // }
    //         // else
    //         // {
    //         //     shipBody.transform.localEulerAngles += Vector3.forward * tankRotationSpeed;
    //         // }
    //     }
    //     
    //     if (Input.GetKey(KeyCode.RightArrow))
    //     {
    //         shipBody.transform.position -= shipBody.transform.forward * (shipMoveSpeed * Time.deltaTime);
    //         // if (Input.GetKey(KeyCode.DownArrow))
    //         // {
    //         //     shipBody.transform.localEulerAngles += Vector3.forward * tankRotationSpeed;
    //         // }
    //         // else
    //         // {
    //         //     shipBody.transform.localEulerAngles -= Vector3.forward * tankRotationSpeed;
    //         // }
    //     }
    //
    //     // if (Input.GetKey(KeyCode.A))
    //     // {
    //     //     tankTop.transform.localEulerAngles += Vector3.forward * tankTopRotationSpeed;
    //     // }
    //     //
    //     // if (Input.GetKey(KeyCode.S))
    //     // {
    //     //     tankTop.transform.localEulerAngles -= Vector3.forward * tankTopRotationSpeed;
    //     // }
    //
    //     // if (Input.GetKeyDown(KeyCode.Space))
    //     // {
    //     //     if (_counter <= 0)
    //     //     {
    //     //         _counter = 1;
    //     //         for (var i = 0; i < _bullets.Length; i++)
    //     //         {
    //     //             if (!_bullets[i].activeInHierarchy)
    //     //             {
    //     //                 _bullets[i].transform.localPosition = _flowerOriginalPosition;
    //     //                 CannonDirections[i] = tankTop.transform.up;
    //     //                 _bullets[i].transform.SetParent(null);
    //     //
    //     //                 _bullets[i].SetActive(true);
    //     //                 _bullets[i].transform.localScale = new Vector3(1.480263f, 2.152627f, 1.0f);
    //     //                 _bullets[i].transform.rotation = tankTop.transform.rotation;
    //     //                 break;
    //     //             }
    //     //         }
    //     //         // _flower.transform.localPosition = _flowerOriginalPosition;
    //     //         // _cannonDirection = _tankTop.transform.up;
    //     //         // _cannonRotate = _tankTop.transform.rotation;
    //     //         // _flower.transform.SetParent(null);
    //     //
    //     //         // Start the fire
    //     //         // GameObject _new = Instantiate(_flower);
    //     //         // _new.SetActive(true);
    //     //         // _new.transform.localScale = new Vector3(1.480263f, 2.152627f, 1.0f);
    //     //         // _new.transform.rotation = _cannonRotate;
    //     //         // _bullets.Add(_new);
    //     //
    //     //         // _flower.SetActive(true);
    //     //         // _flower.transform.localScale = new Vector3(1.480263f, 2.152627f, 1.0f);
    //     //         // _flower.transform.rotation = _cannonRotate;
    //     //     }
    //     // }
    //     // _counter -= Time.deltaTime;
    // }


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
            // if (Input.GetKey(KeyCode.DownArrow))
            // {
            //     shipBody.transform.localEulerAngles -= Vector3.forward * tankRotationSpeed;
            // }
            // else
            // {
            //     shipBody.transform.localEulerAngles += Vector3.forward * tankRotationSpeed;
            // }
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            shipRb.AddForce(Vector2.right * shipMoveSpeed);

            // shipBody.transform.position -= shipBody.transform.forward * (shipMoveSpeed * Time.deltaTime);
            // if (Input.GetKey(KeyCode.DownArrow))
            // {
            //     shipBody.transform.localEulerAngles += Vector3.forward * tankRotationSpeed;
            // }
            // else
            // {
            //     shipBody.transform.localEulerAngles -= Vector3.forward * tankRotationSpeed;
            // }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("Collision!!" + col.collider.name);
        // if (col.collider.name.Equals("Sheep"))
        // {
        //     
        //     col.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        // }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // other.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        // Debug.Log("Noo Collision!! " + other.collider.name);
    }
}