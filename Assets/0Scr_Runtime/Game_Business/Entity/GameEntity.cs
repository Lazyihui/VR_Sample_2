using System;
using UnityEngine;


public class GameEntity {

    public int roleOwnerID;

    public int particleOwnerID;


    public float LoginOpenTime;
    public bool isLoginOpen;
    public GameEntity() {
        roleOwnerID = 0;
        particleOwnerID = 0;

        isLoginOpen = false;
        LoginOpenTime = 0;
    }

}