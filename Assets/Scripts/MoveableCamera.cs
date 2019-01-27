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

public class MoveableCamera : MonoBehaviour
{
    public AstronomicalBody Body;
    private float _d = 2;
    private float _theta = Mathf.PI / 2;
    private float _phi;

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
        var direction = new Vector3(
            Mathf.Sin(_theta) * Mathf.Cos(_phi),
            Mathf.Cos(_theta),
            Mathf.Sin(_theta) * Mathf.Sin(_phi)
        );
        transform.position = Body.GetPosition() + (Body.GetVelocity() * Time.fixedDeltaTime) + direction * _d;
        transform.rotation = Quaternion.LookRotation(-direction);
    }

    public void UpArrow()
    {
        if (!GetComponent<Camera>().enabled) return;
        _theta -= 0.01f;
        if (_theta < 0)
        {
            _theta = 0.0001f;
        }
    }

    public void DownArrow()
    {
        if (!GetComponent<Camera>().enabled) return;
        _theta += 0.01f;
        if (_theta > Mathf.PI)
        {
            _theta = Mathf.PI - 0.0001f;
        }
    }

    public void LeftArrow()
    {
        if (!GetComponent<Camera>().enabled) return;
        _phi -= 0.01f;
        if (_phi < -Mathf.PI)
        {
            _phi = Mathf.PI;
        }
    }

    public void RightArrow()
    {
        if (!GetComponent<Camera>().enabled) return;
        _phi += 0.01f;
        if (_phi > Mathf.PI)
        {
            _phi = -Mathf.PI;
        }
    }

    public void PlusArrow()
    {
        if (!GetComponent<Camera>().enabled) return;
        _d -= 0.1f;
        if (_d <= 10)
        {
            _d = 10;
        }
    }

    public void MinusArrow()
    {
        if (!GetComponent<Camera>().enabled) return;
        _d += 0.1f;
        if (_d >= 100)
        {
            _d = 100;
        }
    }

    public void Reset1()
    {
        _theta = Mathf.PI / 2;
        _phi = Mathf.PI / 2;
        _d = 30;
    }

    public void Reset2()
    {
        Reset1();
        _theta = 0.0001f;
    }

    public void Reset3()
    {
        Reset1();
        _d = 2;
    }
}