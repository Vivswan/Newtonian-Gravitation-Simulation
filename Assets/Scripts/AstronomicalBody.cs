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
using System.Collections.Generic;
using UnityEngine;

public class AstronomicalBody : MonoBehaviour
{
    public struct Values
    {
        public float Mass;
        public float Radius;
        public Vector3 Position;
        public Vector3 Velocity;
        public Vector3 AngularVelocity;
    }

    public bool GravitationalEffect = true;
    public bool GravitationalPull = true;
    public float Mass = 1;
    public Vector3 Velocity = Vector3.zero;
    public Vector3 AngularVelocity = Vector3.zero;
    public bool Trajectory;
    public Color TrajectoryColor = Color.white;
    public Shader TrajectoryShader;

    internal static readonly List<AstronomicalBody> All = new List<AstronomicalBody>();
    private Rigidbody _rb;
    private NewtonianGravitation _gravitation;
    internal Trajectory OTrajectory;
    private Vector3 _force;


    public float GetMass()
    {
        return _rb.mass;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetVelocity()
    {
        return _rb.velocity;
    }

    public Vector3 GetAcceration()
    {
        return _force / _rb.mass;
    }

    public Vector3 GetForce()
    {
        return _force;
    }

    public void SetForce(Vector3 resultantForce)
    {
        _force = resultantForce;
        _rb.AddForce(resultantForce);
    }

    public void SetValues(Values values)
    {
        Mass = values.Mass;
        transform.localScale = Vector3.one * values.Radius;
        transform.position = values.Position;
        Velocity = values.Velocity;
        AngularVelocity = values.AngularVelocity;
        SetUp();
    }

    private void SetUp()
    {
        _rb = Functions.GetRigidbody(gameObject);
        _rb.useGravity = false;
        _rb.angularDrag = 0.0f;
        _rb.mass = Mass;
        _rb.velocity = Velocity;
        _rb.angularVelocity = AngularVelocity;
    }

    private void OnEnable()
    {
        All.Add(this);
    }

    private void OnDisable()
    {
        All.Remove(this);
    }

    private void Start()
    {
        SetUp();
        OTrajectory = new Trajectory(this, TrajectoryShader);
        _gravitation = new NewtonianGravitation(this);
    }

    private void FixedUpdate()
    {
        OTrajectory.Apply();
        _gravitation.Apply();
    }
}