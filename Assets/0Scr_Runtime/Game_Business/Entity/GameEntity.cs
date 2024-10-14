using System;
using UnityEngine;


public class GameEntity {

    public int roleOwnerID;

    public int particleOwnerID;

    public int planeOwnerID;


    public float LoginOpenTime;
    public bool isLoginOpen;

    public GameState gameState;
    public GameEntity() {
        roleOwnerID = 0;
        particleOwnerID = 0;

        isLoginOpen = false;
        LoginOpenTime = 0;
        planeOwnerID = 0;
        gameState = GameState.Login;
    }

}