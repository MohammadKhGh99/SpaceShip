using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // [SerializeField] private GameObject bullet1;
    // [SerializeField] private GameObject bullet2;
    // [SerializeField] private GameObject bullet3;
    // [SerializeField] private GameObject bullet4;
    [SerializeField] private GameObject flower;
    [SerializeField] private GameObject ship;

    // [SerializeField] private GameObject tankTop;
    [SerializeField] private float flowerMoveSpeed;

    // [SerializeField] private Rigidbody2D sheep1;
    // [SerializeField] private Rigidbody2D sheep2;
    //
    // [SerializeField] private Rigidbody2D sheep3;

    // [SerializeField] private Rigidbody2D sheep4;
    [SerializeField] private Rigidbody2D sheep;
    [SerializeField] private GameObject sheepParent;

    private Rigidbody2D[] _sheeps;

    private GameObject[] _bullets = new GameObject[4];

    private Vector3 _flowerOriginalPosition;

    private float _bulletCoolDown;
    private readonly Vector3 _initialScale = new(1.480263f, 2.152627f, 1.0f);
    private int _fpsCounter;
    private float _fpsTime;

    private Vector3[] _cannonDirections = new Vector3[4];
    private float[] _sheepsDeathTimes = { 3, 3, 3 };
    public static int NumBullets = 0;

    private float _sheepsDeathTime;
    public static int NumSheeps = 0;
    private Vector3 _minPosition = new(-39.75f, -11.1f, 0);
    private Vector3 _maxPosition = new(39.75f, 14.6f, 0);

    private Vector3[] _sheepsInitialPositions = { new(32, -8, 0), new(4, -8, 0), new(18, 10, 0) };

    // Start is called before the first frame update
    void Start()
    {
        // _numBullets = 0;
        _flowerOriginalPosition = flower.transform.localPosition;
        flower.SetActive(false);

        for (int i = 0; i < 3; i++)
        {
            NumSheeps++;
            Vector3 randomPos = new(Random.Range(_minPosition.x, _maxPosition.x),
                Random.Range(_minPosition.y, _maxPosition.y),
                Random.Range(_minPosition.z, _maxPosition.z));
            Rigidbody2D tempSheep = Instantiate(sheep, randomPos, Quaternion.identity, sheepParent.transform);
            tempSheep.gameObject.SetActive(true);
        }

        // _bullets = new[] { bullet1, bullet2, bullet3, bullet4 };
        // foreach (var bullet in _bullets)
        // {
        //     bullet.SetActive(false);
        //     // bullet.transform.SetParent(tankTop.transform);
        // }
        //
        // _sheeps = new[] { sheep1, sheep2, sheep3 };

        _bulletCoolDown = 1;
        _fpsCounter = 0;
        _fpsTime = 1;
        _sheepsDeathTime = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Showing fps value
        // _fpsCounter++;
        // _fpsTime -= Time.deltaTime;
        //
        // if (_fpsTime <= 0)
        // {
        //     Debug.Log("FPS is: " + _fpsCounter);
        //     _fpsCounter = 0;
        //     _fpsTime = 1;
        // }

        // moving bullets
        // for (var i = 0; i < _bullets.Length; i++)
        // {
        //     if (_bullets[i].activeInHierarchy)
        //     {
        //         _bullets[i].transform.position += _cannonDirections[i] * (flowerMoveSpeed * Time.deltaTime);
        //     }
        // }

        if (NumSheeps < 3)
        {
            _sheepsDeathTime -= Time.deltaTime;
            if (_sheepsDeathTime <= 0)
            {
                NumSheeps++;
                Vector3 randomPos = new(Random.Range(_minPosition.x, _maxPosition.x),
                    Random.Range(_minPosition.y, _maxPosition.y),
                    Random.Range(_minPosition.z, _maxPosition.z));
                
                Rigidbody2D tempSheep = Instantiate(sheep, randomPos, Quaternion.identity, sheepParent.transform);
                tempSheep.gameObject.SetActive(true);
                _sheepsDeathTime = 3;
            }
        }
        
        // shooting bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (NumBullets < 4)
            {
                if (_bulletCoolDown <= 0)
                {
                    _bulletCoolDown = 1;
                    // flower.SetActive(true);
                    GameObject tempBullet = Instantiate(flower);
                    tempBullet.transform.position = ship.transform.position;
                    tempBullet.SetActive(true);
                    NumBullets++;
                    // for (var i = 0; i < _bullets.Length; i++)
                    // {
                    //     if (!_bullets[i].activeInHierarchy)
                    //     {
                    //         _bullets[i].transform.localPosition = _flowerOriginalPosition;
                    //         _cannonDirections[i] = tankTop.transform.up;
                    //         // _bullets[i].transform.SetParent(null);
                    //
                    //         _bullets[i].SetActive(true);
                    //         _bullets[i].transform.localScale = _initialScale;
                    //         _bullets[i].transform.rotation = tankTop.transform.rotation;
                    //         break;
                    //     }
                    // }
                }
            }
            else
            {
                
            }
        }

        _bulletCoolDown -= Time.deltaTime;

        // reactivate sheeps
        // for (int i = 0; i < _sheeps.Length; i++)
        // {
        //     if (!_sheeps[i].gameObject.activeInHierarchy)
        //     {
        //         _sheepsDeathTimes[i] -= Time.deltaTime;
        //         if (_sheepsDeathTimes[i] <= 0)
        //         {
        //             _sheepsDeathTimes[i] = 3;
        //             _sheeps[i].gameObject.transform.localPosition = _sheepsInitialPositions[i];
        //             _sheeps[i].gameObject.SetActive(true);
        //         }
        //     }
        // }
    }
}