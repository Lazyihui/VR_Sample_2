using System;
using UnityEngine;



public static class ParticleDomain {

    public static ParticleEntity Spawn(GameContext ctx) {
        bool has = ctx.assetContext.entities.TryGetValue("Entity_Particle", out GameObject prefab);

        if (!has) {
            Debug.LogError("Mo");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        ParticleEntity entity = go.GetComponentInChildren<ParticleEntity>();

        entity.Ctor();
        entity.id = ctx.gameEntity.particleOwnerID;

        ctx.particleRepository.Add(entity);

        return entity;
    }

    public static void UnSpawn(GameContext ctx, ParticleEntity entity) {
        ctx.particleRepository.Remove(entity);
        entity.TearDown();
    }

    public static void Tick(GameContext ctx, ParticleEntity particle, float dt) {

        particle.time += dt;

        if (particle.time < 8) {
            if (particle.time < 4) {
                particle.rotate_way = false;
                particle.rotate_speed += 0.2f;
            } else {
                particle.rotate_way = true;
                particle.rotate_speed -= 0.2f;
            }
        } else {
            particle.time = 0;
            particle.rotate_speed = -1f;
        }

        int level = 10;
        for (int i = 0; i < particle.count; i++) {
            ParticleSingle circle = particle.circles[i];

            float speed = particle.speed;

            if (i % level < 3 || i % level > 6) {
                circle.angel -= particle.rotate_speed * (i * level + 1) * speed;
            } else {
                circle.angel += particle.rotate_speed * (i * level + 1) * speed;
            }
            circle.angel = (circle.angel + 360) % 360;
            circle.CalulatePosition();

            float value = Time.realtimeSinceStartup % 1;
            value -= particle.rotate_speed * circle.radius / 360.0f;

            while (value > 1) {
                value -= 1;
            }
            while (value < 0) {
                value += 1;
            }

            // particleArr[i].startColor = grad.Evaluate(value);

            particle.paArr[i].position = new Vector3(circle.GetX(), circle.GetY(), 0);


            if (i % level > 5) {
                float tmp = particle.rotate_way ? 1 : -1;
                circle.radius += tmp * 0.05f;
            }
            if (i % level <= 6) {
                float tem = particle.rotate_way ? 1 : -1;
                circle.radius += tem * 0.053f;
            }

        }

        particle.particleSys.SetParticles(particle.paArr, particle.paArr.Length);


    }
}