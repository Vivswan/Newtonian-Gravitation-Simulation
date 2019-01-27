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
using System.IO;
using UnityEngine;

public class DataLog : MonoBehaviour
{
    public bool Enable;
    public AstronomicalBody Sun;
    public AstronomicalBody Earth;
    public AstronomicalBody Moon;
    private StreamWriter _file;
    private const string Loggerfile = "Assets/Logger/Data.csv";
    private bool _stop;

    private void Start()
    {
        if (!Enable) return;
        _file = new StreamWriter(Loggerfile, false);
        _file.WriteLine("\"Time\"," +
                        "\"Sun Mass\"," +
                        "\"Sun Position X\"," +
                        "\"Sun Position Y\"," +
                        "\"Sun Position Z\"," +
                        "\"Sun Velocity X\"," +
                        "\"Sun Velocity Y\"," +
                        "\"Sun Velocity Z\"," +
                        "\"Sun Acceleration X\"," +
                        "\"Sun Acceleration Y\"," +
                        "\"Sun Acceleration Z\"," +
                        "\"Sun Force X\"," +
                        "\"Sun Force Y\"," +
                        "\"Sun Force Z\"," +
                        "\"Earth Mass\"," +
                        "\"Earth Position X\"," +
                        "\"Earth Position Y\"," +
                        "\"Earth Position Z\"," +
                        "\"Earth Velocity X\"," +
                        "\"Earth Velocity Y\"," +
                        "\"Earth Velocity Z\"," +
                        "\"Earth Acceleration X\"," +
                        "\"Earth Acceleration Y\"," +
                        "\"Earth Acceleration Z\"," +
                        "\"Earth Force X\"," +
                        "\"Earth Force Y\"," +
                        "\"Earth Force Z\"," +
                        "\"Moon Mass\"," +
                        "\"Moon Position X\"," +
                        "\"Moon Position Y\"," +
                        "\"Moon Position Z\"," +
                        "\"Moon Velocity X\"," +
                        "\"Moon Velocity Y\"," +
                        "\"Moon Velocity Z\"," +
                        "\"Moon Acceleration X\"," +
                        "\"Moon Acceleration Y\"," +
                        "\"Moon Acceleration Z\"," +
                        "\"Moon Force X\"," +
                        "\"Moon Force Y\"," +
                        "\"Moon Force Z\"");
    }

    private void FixedUpdate()
    {
        if (!Enable) return;
        _file.WriteLine("\"" + Time.fixedTime + "\"," +
                        "\"" + Sun.GetMass() + "\"," +
                        "\"" + Sun.GetPosition().x + "\"," +
                        "\"" + Sun.GetPosition().y + "\"," +
                        "\"" + Sun.GetPosition().z + "\"," +
                        "\"" + Sun.GetVelocity().x + "\"," +
                        "\"" + Sun.GetVelocity().y + "\"," +
                        "\"" + Sun.GetVelocity().z + "\"," +
                        "\"" + Sun.GetAcceration().x + "\"," +
                        "\"" + Sun.GetAcceration().y + "\"," +
                        "\"" + Sun.GetAcceration().z + "\"," +
                        "\"" + Sun.GetForce().x + "\"," +
                        "\"" + Sun.GetForce().y + "\"," +
                        "\"" + Sun.GetForce().z + "\"," +
                        "\"" + Earth.GetMass() + "\"," +
                        "\"" + Earth.GetPosition().x + "\"," +
                        "\"" + Earth.GetPosition().y + "\"," +
                        "\"" + Earth.GetPosition().z + "\"," +
                        "\"" + Earth.GetVelocity().x + "\"," +
                        "\"" + Earth.GetVelocity().y + "\"," +
                        "\"" + Earth.GetVelocity().z + "\"," +
                        "\"" + Earth.GetAcceration().x + "\"," +
                        "\"" + Earth.GetAcceration().y + "\"," +
                        "\"" + Earth.GetAcceration().z + "\"," +
                        "\"" + Earth.GetForce().x + "\"," +
                        "\"" + Earth.GetForce().y + "\"," +
                        "\"" + Earth.GetForce().z + "\"," +
                        "\"" + Moon.GetMass() + "\"," +
                        "\"" + Moon.GetPosition().x + "\"," +
                        "\"" + Moon.GetPosition().y + "\"," +
                        "\"" + Moon.GetPosition().z + "\"," +
                        "\"" + Moon.GetVelocity().x + "\"," +
                        "\"" + Moon.GetVelocity().y + "\"," +
                        "\"" + Moon.GetVelocity().z + "\"," +
                        "\"" + Moon.GetAcceration().x + "\"," +
                        "\"" + Moon.GetAcceration().y + "\"," +
                        "\"" + Moon.GetAcceration().z + "\"," +
                        "\"" + Moon.GetForce().x + "\"," +
                        "\"" + Moon.GetForce().y + "\"," +
                        "\"" + Moon.GetForce().z + "\"");
        _file.Flush();
    }
}