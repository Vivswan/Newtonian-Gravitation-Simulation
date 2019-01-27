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

public class NewtonianGravitation
{
    private const float GravitationalConstant = 6.67f;
    private readonly AstronomicalBody _parent;

    public NewtonianGravitation(AstronomicalBody astronomicalBody)
    {
        _parent = astronomicalBody;
    }

    private static Vector3 CalcGrativationalForce(float mass1, float mass2, Vector3 rPosition)
    {
        return GravitationalConstant * mass1 * mass2 / Mathf.Pow(rPosition.magnitude, 2) * rPosition.normalized;
    }

    private void ApplyGravitationalForce()
    {
        if (!_parent.GravitationalEffect) return;
        var resultantForce = Vector3.zero;

        foreach (var astronomicalBody in AstronomicalBody.All)
        {
            if (!astronomicalBody.GravitationalPull || astronomicalBody == _parent) continue;
            var f = CalcGrativationalForce(_parent.GetMass(), astronomicalBody.GetMass(),
                astronomicalBody.GetPosition() - _parent.GetPosition());
            resultantForce += f;
        }

        _parent.SetForce(resultantForce);
    }

    public void Apply()
    {
        ApplyGravitationalForce();
    }
}