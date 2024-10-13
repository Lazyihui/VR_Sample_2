using System;
using UnityEngine;



public class ParticleSingle {

    public float angel;

    public float radius;

    public float x = 0.0f;
    public float y = 0.0f;

    public void CalulatePosition() {
        float temp = angel / 180.0f * Mathf.PI;

        x = radius * Mathf.Cos(temp);
        y = radius * Mathf.Sin(temp);
    }

    public ParticleSingle(float angel, float radius) {
        this.angel = angel;
        this.radius = radius;
    }

    public float GetX() {
        return x;
    }

    public float GetY() {
        return y;
    }

}