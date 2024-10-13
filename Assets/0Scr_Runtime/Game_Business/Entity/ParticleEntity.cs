using System;
using UnityEngine;


public class ParticleEntity : MonoBehaviour {

    public int id;

    public ParticleSystem particleSys;

    public ParticleSystem.Particle[] paArr;

    public ParticleSingle[] circles;

    public Gradient grad;//颜色渐变


    public int count = 1000;

    public float size = 1f;

    public float minRadius = 3f;

    public float maxRadius = 6f;

    public float speed = 0.1f;

    public float pingPong = 0.02f;

    public float rotate_speed = -1f;

    public bool rotate_way = false;


    public float time = 0;


    public void Ctor() {
        paArr = new ParticleSystem.Particle[count];
        circles = new ParticleSingle[count];

        particleSys = this.GetComponent<ParticleSystem>();

        var m = particleSys.main;

        m.startSpeed = 0;
        m.startSize = size;
        m.loop = false;
        m.maxParticles = count;
        particleSys.Emit(count);
        particleSys.GetParticles(paArr);

        Init();
    }


    void Init() {
        for (int i = 0; i < count; i++) {
            float midRadius = (maxRadius + minRadius) / 2;
            float minRate = UnityEngine.Random.Range(1.0f, midRadius / minRadius);
            float maxRate = UnityEngine.Random.Range(midRadius / maxRadius, 1.0f);

            float radius = UnityEngine.Random.Range(minRadius * minRate, maxRate * maxRadius);

            float angel = UnityEngine.Random.Range(0.0f, 360);

            circles[i] = new ParticleSingle(angel, radius);
            circles[i].CalulatePosition();

            paArr[i].position = new Vector3(circles[i].GetX(), circles[i].GetY(), 0);

        }

        particleSys.SetParticles(paArr, paArr.Length);
    }

    public void TearDown() {
        Destroy(gameObject);

    }
}