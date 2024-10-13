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
        ParticleEntity entity = go.GetComponent<ParticleEntity>();

        entity.Ctor();
        entity.id = ctx.gameEntity.particleRecoredID;

        ctx.particleRepository.Add(entity);

        return entity;
    }

    public static void UnSpawn(GameContext ctx, ParticleEntity entity) {
        ctx.particleRepository.Remove(entity);
        entity.TearDown();
    }

    public static void Tick(GameContext ctx, ParticleEntity entity) {

    }
}