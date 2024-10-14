using System;
using UnityEngine;


public static class PlaneDomain {


    public static PlaneEntity PlaneSpawn(GameContext ctx) {
        bool has = ctx.assetContext.entities.TryGetValue("Entity_Plane", out GameObject prefab);
        if(!has) {
            Debug.LogError("no");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        PlaneEntity entity = go.GetComponent<PlaneEntity>();

        entity.Ctor();

        entity.id = ctx.gameEntity.planeOwnerID;

        ctx.planeRepository.Add(entity);

        return entity;
    }
}