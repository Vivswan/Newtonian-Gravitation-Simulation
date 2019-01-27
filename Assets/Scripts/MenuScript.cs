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
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public AstronomicalBody Sun;
    public AstronomicalBody Earth;
    public AstronomicalBody Moon;
    public GameObject DirectionLights;
    public GameObject InputValues;

    public Toggle LightItToggle;
    public Toggle InputValuesToggle;
    public Toggle SunValuesToggle;
    public Toggle EarthTrajectoryToggle;
    public Toggle EarthValuesToggle;
    public Toggle MoonTracjectoryToggle;
    public Toggle MoonValuesToggle;
    public Button SetButton;
    public Button ResetButton1;
    public Button ResetButton2;
    public Button NonRealButton;
    public Slider TimeScaleSlider;
    public Text TimeScaleValue;
    public Slider LineWidthSlider;
    public Text LineWidthValue;
    public Text CurrentTime;

    public GameObject SunPanel;
    public GameObject EarthPanel;
    public GameObject MoonPanel;

    public VectorCanvas SunPosition;
    public VectorCanvas SunVelocity;
    public VectorCanvas SunAcceration;
    public VectorCanvas SunForce;
    public VectorCanvas EarthPosition;
    public VectorCanvas EarthVelocity;
    public VectorCanvas EarthAcceration;
    public VectorCanvas EarthForce;
    public VectorCanvas EarthPositionRSun;
    public VectorCanvas MoonPosition;
    public VectorCanvas MoonVelocity;
    public VectorCanvas MoonAcceration;
    public VectorCanvas MoonForce;
    public VectorCanvas MoonPositionRSun;
    public VectorCanvas MoonPositionREarth;

    public CanvasInputValues SunInputValues;
    public CanvasInputValues EarthInputValues;
    public CanvasInputValues MoonInputValues;

    public Camera SunCamera;
    public Camera EarthCamera;
    public Button SunCameraButton;
    public Button EarthCameraButton;
    public Pressed UpButton;
    public Pressed DownButton;
    public Pressed LeftButton;
    public Pressed RightButton;
    public Pressed PlusButton;
    public Pressed MinusButton;
    public MoveableCamera EarthMoveableCamera;
    public OverviewMoveableCamera OverviewMoveableCamera;
    public Button SunCameraResetButton;
    public Button EarthCameraResetButton;

    private float _relativeTime;

    private void Start()
    {
        LightItToggle.onValueChanged.AddListener(value => { DirectionLights.SetActive(value); });
        InputValuesToggle.onValueChanged.AddListener(value => { InputValues.SetActive(value); });

        SunValuesToggle.onValueChanged.AddListener(value => { SunPanel.SetActive(value); });

        EarthValuesToggle.onValueChanged.AddListener(value => { EarthPanel.SetActive(value); });
        EarthTrajectoryToggle.onValueChanged.AddListener(value => { Earth.OTrajectory.ToggleTrajectory(value); });

        MoonValuesToggle.onValueChanged.AddListener(value => { MoonPanel.SetActive(value); });
        MoonTracjectoryToggle.onValueChanged.AddListener(value => { Moon.OTrajectory.ToggleTrajectory(value); });

        SetButton.onClick.AddListener(SetValues);
        ResetButton1.onClick.AddListener(Init1);
        ResetButton2.onClick.AddListener(Init2);
        NonRealButton.onClick.AddListener(Init3);
        SunCameraButton.onClick.AddListener(() =>
        {
            SunCamera.enabled = true;
            EarthCamera.enabled = false;
        });
        EarthCameraButton.onClick.AddListener(() =>
        {
            SunCamera.enabled = false;
            EarthCamera.enabled = true;
        });

        TimeScaleSlider.onValueChanged.AddListener(value =>
        {
            TimeScaleValue.text = (value / 10f).ToString(CultureInfo.InvariantCulture);
            Time.timeScale = value / 10f;
        });

        LineWidthSlider.onValueChanged.AddListener(value =>
        {
            LineWidthValue.text = value.ToString(CultureInfo.InvariantCulture);
            Sun.OTrajectory.SetWidth(value);
            Earth.OTrajectory.SetWidth(value);
            Moon.OTrajectory.SetWidth(value);
        });

        UpButton.OnPressed.AddListener(EarthMoveableCamera.UpArrow);
        DownButton.OnPressed.AddListener(EarthMoveableCamera.DownArrow);
        LeftButton.OnPressed.AddListener(EarthMoveableCamera.LeftArrow);
        RightButton.OnPressed.AddListener(EarthMoveableCamera.RightArrow);
        PlusButton.OnPressed.AddListener(EarthMoveableCamera.PlusArrow);
        MinusButton.OnPressed.AddListener(EarthMoveableCamera.MinusArrow);
        UpButton.OnPressed.AddListener(OverviewMoveableCamera.UpArrow);
        DownButton.OnPressed.AddListener(OverviewMoveableCamera.DownArrow);
        LeftButton.OnPressed.AddListener(OverviewMoveableCamera.LeftArrow);
        RightButton.OnPressed.AddListener(OverviewMoveableCamera.RightArrow);
        PlusButton.OnPressed.AddListener(OverviewMoveableCamera.PlusArrow);
        MinusButton.OnPressed.AddListener(OverviewMoveableCamera.MinusArrow);
        SunCameraResetButton.onClick.AddListener(OverviewMoveableCamera.Reset);
        EarthCameraResetButton.onClick.AddListener(EarthMoveableCamera.Reset1);
        Init1();
    }

    private void Init1()
    {
        SunInputValues.SetProperties(new CanvasInputValues.Properties
        {
            Mass = 27071155.3844f,
            Radius = 192.055157198f,
            Position = new Vector3(0, 0, 0),
            Velocity = new Vector3(0, 0, -0.000646573265445f),
            AngularVelocity = new Vector3(Mathf.Sin(0.1265364f), Mathf.Cos(0.1265364f), 0)
        });
        Sun.GravitationalEffect = Sun.GravitationalPull = true;
        EarthInputValues.SetProperties(new CanvasInputValues.Properties
        {
            Mass = 81.2800178349f,
            Radius = 1.75899062328f,
            Position = new Vector3(4056.67402096f, 0, 0),
            Velocity = new Vector3(0, 0, 212.783442035f),
            AngularVelocity = new Vector3(7333.27593274f, 16914.3759147f, 0)
        });
        Earth.GravitationalEffect = Earth.GravitationalPull = true;
        MoonInputValues.SetProperties(new CanvasInputValues.Properties
        {
            Mass = 1,
            Radius = 0.479343629344f,
            Position = new Vector3(4046.67402096f, 0, 0),
            Velocity = new Vector3(0, 7.61180934741f, 212.730694485f),
            AngularVelocity = new Vector3(18.1162453919f, 672.804494625f, 0)
        });
        Moon.GravitationalEffect = Moon.GravitationalPull = true;
        OverviewMoveableCamera.Reset();
        EarthMoveableCamera.Reset1();
        SetValues();
    }

    private void Init2()
    {
        SunInputValues.SetProperties(new CanvasInputValues.Properties
        {
            Mass = 27071155.3844f,
            Radius = 192.055157198f,
            Position = new Vector3(0, 0, 0),
            Velocity = new Vector3(0, 0, -0.000646573265445f),
            AngularVelocity = new Vector3(Mathf.Sin(0.1265364f), Mathf.Cos(0.1265364f), 0)
        });
        Sun.GravitationalEffect = Sun.GravitationalPull = true;
        EarthInputValues.SetProperties(new CanvasInputValues.Properties
        {
            Mass = 81.2800178349f,
            Radius = 1.75899062328f,
            Position = new Vector3(4056.67402096f, 0, 0),
            Velocity = new Vector3(0, 0, 212.783442035f),
            AngularVelocity = new Vector3(7333.27593274f, 16914.3759147f, 0)
        });
        Earth.GravitationalEffect = Earth.GravitationalPull = true;
        MoonInputValues.SetProperties(new CanvasInputValues.Properties
        {
            Mass = 1,
            Radius = 0.479343629344f,
            Position = new Vector3(4046.67402096f, 0, 0),
            Velocity = new Vector3(0, 0, 212.730694485f + 7.61180934741f),
            AngularVelocity = new Vector3(18.1162453919f, 672.804494625f, 0)
        });
        Moon.GravitationalEffect = Moon.GravitationalPull = true;
        OverviewMoveableCamera.Reset();
        EarthMoveableCamera.Reset2();
        SetValues();
    }

    private void Init3()
    {
        SunInputValues.SetProperties(new CanvasInputValues.Properties
        {
            Mass = 5600.6549711f,
            Radius = 40,
            Position = new Vector3(0, 0, 0),
            Velocity = new Vector3(0, 0, 0),
            AngularVelocity = new Vector3(0, 0, 0)
        });
        Sun.GravitationalEffect = false;
        Sun.GravitationalPull = true;
        EarthInputValues.SetProperties(new CanvasInputValues.Properties
        {
            Mass = 650.240142679f,
            Radius = 5f,
            Position = new Vector3(100f, 0, 0),
            Velocity = new Vector3(0, 0, 20.5888586203f),
            AngularVelocity = new Vector3(0, 0, 0)
        });
        Earth.GravitationalEffect = Earth.GravitationalPull = true;
        MoonInputValues.SetProperties(new CanvasInputValues.Properties
        {
            Mass = 1,
            Radius = 3f,
            Position = new Vector3(100f - 10f, 0, 0),
            Velocity = new Vector3(0, 0, 41.9950372163f),
            AngularVelocity = new Vector3(0, 0, 0)
        });
        Moon.GravitationalEffect = Moon.GravitationalPull = true;
        OverviewMoveableCamera.Reset1();
        EarthMoveableCamera.Reset3();
        SunCamera.enabled = true;
        EarthCamera.enabled = false;
        SetValues();
    }


    private void SetValues()
    {
        Sun.SetValues(new AstronomicalBody.Values
        {
            Mass = SunInputValues.GetMass(),
            Radius = SunInputValues.GetRadius(),
            Position = SunInputValues.GetPosition(),
            Velocity = SunInputValues.GetVelocity(),
            AngularVelocity = SunInputValues.GetAngularVelocity()
        });
        Earth.SetValues(new AstronomicalBody.Values
        {
            Mass = EarthInputValues.GetMass(),
            Radius = EarthInputValues.GetRadius(),
            Position = EarthInputValues.GetPosition(),
            Velocity = EarthInputValues.GetVelocity(),
            AngularVelocity = EarthInputValues.GetAngularVelocity()
        });
        Moon.SetValues(new AstronomicalBody.Values
        {
            Mass = MoonInputValues.GetMass(),
            Radius = MoonInputValues.GetRadius(),
            Position = MoonInputValues.GetPosition(),
            Velocity = MoonInputValues.GetVelocity(),
            AngularVelocity = MoonInputValues.GetAngularVelocity()
        });
        DirectionLights.SetActive(LightItToggle.isOn);
        InputValues.SetActive(InputValuesToggle.isOn);
        SunPanel.SetActive(SunValuesToggle.isOn);
        EarthPanel.SetActive(EarthValuesToggle.isOn);
        MoonPanel.SetActive(MoonValuesToggle.isOn);
        Earth.OTrajectory.ToggleTrajectory(EarthTrajectoryToggle.isOn);
        Moon.OTrajectory.ToggleTrajectory(MoonTracjectoryToggle.isOn);
        Time.timeScale = TimeScaleSlider.value / 10f;
        TimeScaleValue.text = Time.timeScale.ToString(CultureInfo.InvariantCulture);
        Sun.OTrajectory.SetWidth(LineWidthSlider.value);
        Earth.OTrajectory.SetWidth(LineWidthSlider.value);
        Moon.OTrajectory.SetWidth(LineWidthSlider.value);
        _relativeTime = Time.fixedTime;
        LineWidthValue.text = LineWidthSlider.value.ToString(CultureInfo.InvariantCulture);
    }

    private void SunValues()
    {
        SunPosition.Display(Sun.GetPosition());
        SunVelocity.Display(Sun.GetVelocity());
        SunAcceration.Display(Sun.GetAcceration());
        SunForce.Display(Sun.GetForce());
    }

    private void EarthValues()
    {
        EarthPosition.Display(Earth.GetPosition());
        EarthVelocity.Display(Earth.GetVelocity());
        EarthAcceration.Display(Earth.GetAcceration());
        EarthForce.Display(Earth.GetForce());
        EarthPositionRSun.Display(Earth.GetPosition() - Sun.GetPosition());
    }

    private void MoonValues()
    {
        MoonPosition.Display(Moon.GetPosition());
        MoonVelocity.Display(Moon.GetVelocity());
        MoonAcceration.Display(Moon.GetAcceration());
        MoonForce.Display(Moon.GetForce());
        MoonPositionRSun.Display(Moon.GetPosition() - Sun.GetPosition());
        MoonPositionREarth.Display(Moon.GetPosition() - Earth.GetPosition());
    }

    private void FixedUpdate()
    {
        CurrentTime.text = Math.Round(Time.fixedTime - _relativeTime, 2).ToString(CultureInfo.InvariantCulture);
        if (SunValuesToggle.isOn)
        {
            SunValues();
        }

        if (EarthValuesToggle.isOn)
        {
            EarthValues();
        }

        if (MoonValuesToggle.isOn)
        {
            MoonValues();
        }
    }
}