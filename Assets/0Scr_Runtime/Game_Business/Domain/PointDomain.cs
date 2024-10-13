using System;
using UnityEngine;

public static class PointDomain {

    public static PointEntity Spawn(GameContext ctx) {

        bool has = ctx.assetContext.entities.TryGetValue("Entity_Point", out GameObject prefab);

        if (!has) {
            Debug.LogError("no");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        PointEntity entity = go.GetComponent<PointEntity>();


        entity.Ctor();
        ctx.pointRepository.Add(entity);
        return entity;
    }

}