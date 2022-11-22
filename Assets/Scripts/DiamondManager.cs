using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondManager : MonoBehaviour
{
    private float _scale = 2f;
    private bool _scaling;
    
    // Start is called before the first frame update
    void Start()
    {
        _scaling = false;
        transform.localScale = new Vector3(_scale, _scale, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_scale >= 2 && !_scaling)
        {
            _scaling = true;
        }else if (_scale <= 1 && _scaling)
        {
            _scaling = false;
        }

        if (_scaling)
        {
            _scale -= 0.01f;
        }
        else
        {
            _scale += 0.01f;
        }

        transform.localScale = new Vector3(_scale, _scale, 0);
        // Rotating
        // transform.Rotate (0, _speed * _direction * Time.deltaTime, 0);
    }
}
