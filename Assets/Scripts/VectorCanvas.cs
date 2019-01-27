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
using System;
using System.Globalization;
using UnityEngine;

public class VectorCanvas : MonoBehaviour
{
    public string Title;
    public UnityEngine.UI.Text Name;
    public UnityEngine.UI.Text X;
    public UnityEngine.UI.Text Y;
    public UnityEngine.UI.Text Z;
    public UnityEngine.UI.Text Magnitude;


    public void Display(Vector3 vector)
    {
        Name.text = Title;
        Magnitude.text = Math.Round(vector.magnitude, 3).ToString(CultureInfo.InvariantCulture);
        X.text = Math.Round(vector.x, 3).ToString(CultureInfo.InvariantCulture);
        Y.text = Math.Round(vector.y, 3).ToString(CultureInfo.InvariantCulture);
        Z.text = Math.Round(vector.z, 3).ToString(CultureInfo.InvariantCulture);
    }
}