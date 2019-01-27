//MIT License
//
//Copyright (c) 2018 Vivswan Shah
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
using UnityEngine;

public class OverviewMoveableCamera : MonoBehaviour
{
    private Vector3 _iPosition;
    private float _d;
    private float _x;
    private float _z;
    private float _iSize;
    private float _maxXy = 5000;
    private float _maxZ = 4990;
    private float _deltaXy;
    private float _deltaZ = 20;

    private void Start()
    {
        _iPosition = transform.position;
        _iSize = GetComponent<Camera>().orthographicSize;
    }

    private void Update()
    {
        if (!GetComponent<Camera>().enabled) return;

        if (Input.GetKey(KeyCode.KeypadPlus) || Input.GetKey(KeyCode.Plus))
        {
            PlusArrow();
        }

        if (Input.GetKey(KeyCode.KeypadMinus) || Input.GetKey(KeyCode.Minus))
        {
            MinusArrow();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            UpArrow();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            DownArrow();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            LeftArrow();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            RightArrow();
        }
    }

    private void FixedUpdate()
    {
        _deltaXy = (_iSize + _d) / 100;
        transform.position = new Vector3(_iPosition.x + _x, _iPosition.y, _iPosition.z + _z);
        GetComponent<Camera>().orthographicSize = _iSize + _d;
    }

    public void UpArrow()
    {
        if (!GetComponent<Camera>().enabled) return;
        _z += _deltaXy;
        if (_z > _maxXy)
        {
            _z = _maxXy;
        }
    }

    public void DownArrow()
    {
        if (!GetComponent<Camera>().enabled) return;
        _z -= _deltaXy;
        if (_z < -_maxXy)
        {
            _z = -_maxXy;
        }
    }

    public void LeftArrow()
    {
        if (!GetComponent<Camera>().enabled) return;
        _x -= _deltaXy;
        if (_x < -_maxXy)
        {
            _x = -_maxXy;
        }
    }

    public void RightArrow()
    {
        if (!GetComponent<Camera>().enabled) return;
        _x += _deltaXy;
        if (_x > _maxXy)
        {
            _x = _maxXy;
        }
    }

    public void PlusArrow()
    {
        if (!GetComponent<Camera>().enabled) return;
        _d -= _deltaZ;
        if (_d <= -_maxZ)
        {
            _d = -_maxZ;
        }
    }

    public void MinusArrow()
    {
        if (!GetComponent<Camera>().enabled) return;
        _d += _deltaZ;
        if (_d >= 0)
        {
            _d = 0;
        }
    }

    public void Reset()
    {
        _x = 0;
        _z = 0;
        _d = 0;
        _maxXy = 5000;
        _maxZ = 4990;
        _deltaZ = 20;
    }

    public void Reset1()
    {
        Reset();
        _d = -4850;
    }
}