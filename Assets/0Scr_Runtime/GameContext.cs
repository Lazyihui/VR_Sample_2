using System;
using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;
    public AssetContext assetContext;

    public UIContext uiContext;

    public CameraCore cameraCore;

    public InputContext inputContext;
    // repo 
    public RoleRepository roleRepository;

    public ParticleRepository particleRepository;

    public GameContext() {

        gameEntity = new GameEntity();

        assetContext = new AssetContext();
        cameraCore = new CameraCore();
        inputContext = new InputContext();
        uiContext = new UIContext();

        // repo
        roleRepository = new RoleRepository();
        particleRepository = new ParticleRepository();
    }

    public void Inject(Camera camera) {
        cameraCore.Inject(camera);
        uiContext.Inject(assetContext);
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