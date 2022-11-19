using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject shipParent;
    [SerializeField] private GameObject sheepParent;
    [SerializeField] private CinemachineVirtualCamera followingCamera;
    [SerializeField] private int maxSheeps;
    [SerializeField] private int maxDiamonds;

    private GameObject[] _sheeps;
    private GameObject[] _diamonds;

    private int _sheepPrefabs = 4;
    private int _diamondPrefabs = 3;

    private int _fpsCounter;
    private float _fpsTime;

    private Vector3 _flowerOriginalPosition;
    private float _sheepsDeathTime;
    private float _diamondCoolTime;

    public static int NumSheeps;
    public static int NumDiamonds;
    public static int Score = 0;
    
    private readonly Vector3 _minPosition = new(-39.75f, -8.9f, 0);
    private readonly Vector3 _maxPosition = new(39.75f, 8.9f, 0);
    private readonly string[] _sheepsTypes = { "WhiteSheep", "BlackHeadSheep", "BlackSheep", "EvilSheep" };
    private readonly string[] _diamondsTypes = { "Yellow_1p", "Blue_2p", "Red_3p" };

    // Start is called before the first frame update
    void Start()
    {
        _sheeps = new GameObject[maxSheeps];
        _diamonds = new GameObject[maxDiamonds];

        GameObject ship = Instantiate(Resources.Load("spaceship"), parent: shipParent.transform) as GameObject;
        followingCamera.Follow = ship.transform;
        
        int maxLen = Math.Max(maxDiamonds, maxSheeps);
        for (int i = 0; i < maxLen; i++)
        {
            Vector3 randomPos;
            // making our first sheeps to have on screen
            if (i < maxSheeps)
            {
                NumSheeps++;
                randomPos = new(Random.Range(_minPosition.x, _maxPosition.x),
                    Random.Range(_minPosition.y, _maxPosition.y),
                    Random.Range(_minPosition.z, _maxPosition.z));

                string sheepType = _sheepsTypes[Random.Range(0, _sheepPrefabs)];

                GameObject tempSheep =
                    Instantiate(Resources.Load(sheepType), randomPos, Quaternion.identity, sheepParent.transform) as
                        GameObject;
                if (sheepType.StartsWith("Evil"))
                {
                    tempSheep.transform.localScale = new Vector3(1, 1, 0);
                }
                _sheeps[i] = tempSheep;
            }

            // Making Initial Diamonds
            if (i < maxDiamonds)
            {
                NumDiamonds++;
                randomPos = new Vector3(Random.Range(_minPosition.x, _maxPosition.x),
                    Random.Range(_minPosition.y, _maxPosition.y),
                    Random.Range(_minPosition.z, _maxPosition.z));
                string diamondType = _diamondsTypes[Random.Range(0, _diamondPrefabs)];
                // print(diamondType);
                GameObject tempDiamond =
                    Instantiate(Resources.Load(diamondType), randomPos, Quaternion.identity) as GameObject;
                _diamonds[i] = tempDiamond;
            }
        }

        _fpsCounter = 0;
        _fpsTime = 1;
        _sheepsDeathTime = 3;
        _diamondCoolTime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // Showing fps value
        _fpsCounter++;
        _fpsTime -= Time.deltaTime;

        if (_fpsTime <= 0)
        {
            Debug.Log("FPS is: " + _fpsCounter);
            _fpsCounter = 0;
            _fpsTime = 1;
        }

        // reshow hidden sheeps after a certain time
        if (NumSheeps < maxSheeps)
        {
            _sheepsDeathTime -= Time.deltaTime;
            if (_sheepsDeathTime <= 0)
            {
                foreach (GameObject sheep in _sheeps)
                {
                    if (sheep.gameObject.activeInHierarchy) continue;
                    Vector3 randomPos = new(Random.Range(_minPosition.x, _maxPosition.x),
                        Random.Range(_minPosition.y, _maxPosition.y),
                        Random.Range(_minPosition.z, _maxPosition.z));
                    sheep.transform.SetPositionAndRotation(randomPos, Quaternion.identity);
                    NumSheeps++;
                    sheep.gameObject.SetActive(true);
                    _sheepsDeathTime = 3;
                    break;
                }
            }
        }

        // Reshowing disappeared diamonds
        if (NumDiamonds >= maxDiamonds) return;
        _diamondCoolTime -= Time.deltaTime;
        if (_diamondCoolTime > 0) return;
        foreach (GameObject diamond in _diamonds)
        {
            if (diamond.gameObject.activeSelf) continue;
            Vector3 randomPos = new(Random.Range(_minPosition.x, _maxPosition.x),
                Random.Range(_minPosition.y, _maxPosition.y),
                Random.Range(_minPosition.z, _maxPosition.z));
            diamond.transform.SetPositionAndRotation(randomPos, Quaternion.identity);
            NumDiamonds++;
            diamond.gameObject.SetActive(true);
            _diamondCoolTime = 3;
            break;
        }
    }
}