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

public static class Functions
{
    public static Rigidbody GetRigidbody(GameObject gameObject)
    {
        var rigidbody = gameObject.GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }

        return rigidbody;
    }

    public static Vector3 RotateVector(Vector3 vector, float x = 0, float y = 0)
    {
        var x1 = vector.x * Mathf.Cos(y) + vector.z * Mathf.Sin(y);
        var y1 = -vector.z * Mathf.Cos(y) * Mathf.Sin(x) + vector.x * Mathf.Sin(x) * Mathf.Sin(y) +
                 vector.y * Mathf.Cos(x);
        var z1 = vector.z * Mathf.Cos(x) * Mathf.Cos(y) - vector.x * Mathf.Cos(x) * Mathf.Sin(y) +
                 vector.y * Mathf.Sin(x);
        return new Vector3(x1, y1, z1);
    }
}