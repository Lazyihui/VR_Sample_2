using System;
using UnityEngine;


public static class RoleDomain {
    public static RoleEntity Spawn(GameContext ctx) {
        bool has = ctx.assetContext.entities.TryGetValue("Entity_Role", out GameObject prefab);

        if (!has) {
            Debug.LogError("no");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        RoleEntity entity = go.GetComponent<RoleEntity>();


        entity.Ctor();

        ctx.roleRepository.Add(entity);

        return entity;
    }

    public static void HandHit(GameContext ctx, RoleEntity role) {
        role.HitHead();
    }

    // 头旋转
    public static void RoleHeadRotate(GameContext ctx, RoleEntity role, float dt) {
        Vector3 rotateDir = ctx.inputContext.head.rotate * Vector3.forward;
        role.head.transform.rotation = Quaternion.LookRotation(rotateDir);
    }
    // 整个移动
    public static void Move(GameContext ctx, RoleEntity role, Vector2 moveAxis, float dt) {
        Vector3 moveDir = new Vector3(moveAxis.x, 0, moveAxis.y);
        moveDir.Normalize();

        moveDir = role.transform.rotation * moveDir;
        moveDir = moveDir * role.speed * dt;
        role.transform.position += moveDir;

    }



    public static void SetPosToZero(GameContext ctx, RoleEntity role) {
        role.SetPos();
    }

    // 射线
    public static void Ray(GameContext ctx, RoleEntity role, Vector3 dir) {
        // RaycastHit hit;

        Vector3 rayOriginLeft = role.leftHand.transform.position;

        Ray rayLeft = new Ray(rayOriginLeft, role.leftHand.transform.forward);

        bool lefthit = Physics.Raycast(rayLeft, out RaycastHit lefthitInfo, 7000f, 1 << 8);

        Debug.DrawRay(rayOriginLeft, role.leftHand.transform.forward * 7000f, Color.green);

        if (lefthitInfo.collider == null) {
            return;
        }

        ParticleEntity particle = lefthitInfo.collider.GetComponentInParent<ParticleEntity>();

        if (lefthit) {
            Debug.DrawLine(rayOriginLeft, lefthitInfo.point, Color.red);
            Debug.Log("hit");
        } else {
        }





        // if (Physics.Raycast(role.head.transform.position, dir, out hit, 100)) {
        //     Debug.DrawLine(role.head.transform.position, hit.point, Color.red);
        // }


    }
}