using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondManager : MonoBehaviour
{
    private float _direction = 1;
    private float _speed = 25;
    private float _scale = 2f;
    private bool _inscale;
    
    // Start is called before the first frame update
    void Start()
    {
        _inscale = false;
        transform.localScale = new Vector3(_scale, _scale, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_scale >= 2 && !_inscale)
        {
            _inscale = true;
        }else if (_scale <= 1 && _inscale)
        {
            _inscale = false;
        }

        if (_inscale)
        {
            _scale -= 0.01f;
        }
        else
        {
            _scale += 0.01f;
        }

        transform.localScale = new Vector3(_scale, _scale, 0);
        // transform.Rotate (0, _speed * _direction * Time.deltaTime, 0);
    }
}
