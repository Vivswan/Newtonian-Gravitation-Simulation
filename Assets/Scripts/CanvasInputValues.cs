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
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInputValues : MonoBehaviour
{
    public struct Properties
    {
        public float Mass;
        public float Radius;
        public Vector3 Position;
        public Vector3 Velocity;
        public Vector3 AngularVelocity;
    }
    public Button Button;
    public GameObject Values;
    public InputField Mass;
    public InputField Radius;
    public InputField PositionX;
    public InputField PositionY;
    public InputField PositionZ;
    public InputField VelocityX;
    public InputField VelocityY;
    public InputField VelocityZ;
    public InputField AngularVelocityX;
    public InputField AngularVelocityY;
    public InputField AngularVelocityZ;

    public Button GetButton()
    {
        return Button;
    }

    public void Visible(bool b)
    {
        Values.SetActive(b);
        if (b)
            transform.SetAsLastSibling();
    }

    public float GetMass()
    {
        return float.Parse(Mass.text);
    }

    public float GetRadius()
    {
        return float.Parse(Radius.text);
    }

    public Vector3 GetPosition()
    {
        return new Vector3(float.Parse(PositionX.text), float.Parse(PositionY.text), float.Parse(PositionZ.text));
    }

    public Vector3 GetVelocity()
    {
        return new Vector3(float.Parse(VelocityX.text), float.Parse(VelocityY.text), float.Parse(VelocityZ.text));
    }

    public Vector3 GetAngularVelocity()
    {
        return new Vector3(float.Parse(AngularVelocityX.text), float.Parse(AngularVelocityY.text),
            float.Parse(AngularVelocityZ.text));
    }

    public void SetMass(float mass)
    {
        Mass.text = mass.ToString(CultureInfo.InvariantCulture);
    }

    public void SetRadius(float radius)
    {
        Radius.text = radius.ToString(CultureInfo.InvariantCulture);
    }

    public void SetPosition(Vector3 position)
    {
        PositionX.text = position.x.ToString(CultureInfo.InvariantCulture);
        PositionY.text = position.y.ToString(CultureInfo.InvariantCulture);
        PositionZ.text = position.z.ToString(CultureInfo.InvariantCulture);
    }

    public void SetVelocity(Vector3 velocity)
    {
        VelocityX.text = velocity.x.ToString(CultureInfo.InvariantCulture);
        VelocityY.text = velocity.y.ToString(CultureInfo.InvariantCulture);
        VelocityZ.text = velocity.z.ToString(CultureInfo.InvariantCulture);
    }

    public void SetAngularVelocity(Vector3 angularVelocity)
    {
        AngularVelocityX.text = angularVelocity.x.ToString(CultureInfo.InvariantCulture);
        AngularVelocityY.text = angularVelocity.y.ToString(CultureInfo.InvariantCulture);
        AngularVelocityZ.text = angularVelocity.z.ToString(CultureInfo.InvariantCulture);
    }

    public void SetProperties(Properties properties)
    {
        SetMass(properties.Mass);
        SetRadius(properties.Radius);
        SetPosition(properties.Position);
        SetVelocity(properties.Velocity);
        SetAngularVelocity(properties.AngularVelocity);
    }
}