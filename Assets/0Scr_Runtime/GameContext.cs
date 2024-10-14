using System;
using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;
    public AssetContext assetContext;

    public UIContext uiContext;

    public CameraEntity cameraEntity;

    public InputContext inputContext;
    // repo 
    public RoleRepository roleRepository;

    public ParticleRepository particleRepository;

    public PointRepository pointRepository;

    public PlaneRepository planeRepository;
    public GameContext() {

        gameEntity = new GameEntity();

        assetContext = new AssetContext();
        inputContext = new InputContext();
        uiContext = new UIContext();

        // repo
        roleRepository = new RoleRepository();
        particleRepository = new ParticleRepository();
        pointRepository = new PointRepository();
        planeRepository = new PlaneRepository();
    }

    public void Inject(CameraEntity camera) {
        cameraEntity = camera;
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


    public PlaneEntity Plane_GetOwner() {
        bool has = planeRepository.TryGet(gameEntity.planeOwnerID, out PlaneEntity entity);
        if (!has) {
            Debug.LogError("GameContext.Plane_GetOwner: planeOwnerID not found");
            return null;
        }

        return entity;
    }

    public ParticleEntity Particle_GetOwner() {
        bool has = particleRepository.TryGet(gameEntity.particleOwnerID, out ParticleEntity entity);
        if (!has) {
            Debug.LogError("GameContext.Particle_GetOwner: particleOwnerID not found");
            return null;
        }
        return entity;
    }
}