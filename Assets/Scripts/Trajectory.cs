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

public class Trajectory
{
    private readonly AstronomicalBody _parent;
    private GameObject _trajectoryGameObject;
    private int _trajectoryIndex;
    private LineRenderer _lineRenderer;
    private readonly Shader _trajectoryShader;


    public Trajectory(AstronomicalBody astronomicalBody, Shader trajectoryShader)
    {
        _trajectoryShader = trajectoryShader;
        _parent = astronomicalBody;
        SetupTrajectory();
    }

    private void SetupTrajectory()
    {
        _trajectoryGameObject = new GameObject();
        _lineRenderer = _trajectoryGameObject.AddComponent<LineRenderer>();
        _lineRenderer.material = new Material(_trajectoryShader);
        _lineRenderer.startColor = _lineRenderer.endColor = Color.clear;
        _trajectoryIndex = 0;
        _lineRenderer.receiveShadows = false;
        ToggleTrajectory(_parent.Trajectory);
    }

    private void DrawTrajectory(Vector3 point)
    {
        if (!_parent.Trajectory) return;

        _trajectoryIndex++;
        _lineRenderer.positionCount = _trajectoryIndex;
        _lineRenderer.SetPosition(_trajectoryIndex - 1, point);
    }

    public void ToggleTrajectory(bool value)
    {
        if (value)
        {
            EnableTrajectory();
        }
        else
        {
            DisableTrajectory();
        }
    }

    private void EnableTrajectory()
    {
        _parent.Trajectory = true;
        _lineRenderer.startColor = _lineRenderer.endColor = _parent.TrajectoryColor;
        _trajectoryIndex = 0;
        _lineRenderer.positionCount = 0;
    }

    private void DisableTrajectory()
    {
        _parent.Trajectory = false;
        _lineRenderer.startColor = _lineRenderer.endColor = Color.clear;
        _trajectoryIndex = 0;
        _lineRenderer.positionCount = 0;
    }

    public void Apply()
    {
        DrawTrajectory(_parent.transform.position);
    }

    public void SetWidth(float value)
    {
        _lineRenderer.startWidth = _lineRenderer.endWidth = value;
    }
}