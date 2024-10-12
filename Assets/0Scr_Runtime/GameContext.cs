using System;
using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;
    public AssetContext assetContext;

    public CameraCore cameraCore;

    // repo 
    public RoleRepository roleRepository;

    public GameContext() {

        gameEntity = new GameEntity();

        assetContext = new AssetContext();
        cameraCore = new CameraCore();

        // repo
        roleRepository = new RoleRepository();
    }

    public void Inject(Camera camera) {
        cameraCore.Inject(camera);
    }

    public RoleEntity Role_GetOwner() {
        bool has = roleRepository.TryGet(gameEntity.roleOwnerID, out RoleEntity entity);
        if (!has) {
            Debug.LogError("GameContext.Role_GetOwner: roleOwnerID not found");
            return null;
        }
        return entity;
    }
}