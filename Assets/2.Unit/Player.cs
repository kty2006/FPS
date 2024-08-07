using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GunStatesType
{
    public Transform Idle;
    public Transform Slide;
}

public class Player : Unit, IPlayer
{
    [Header("Unit")]
    //[Space]
    //public Unit Unit = new();

    [Header("Posture")]
    [Space]
    public GunStatesType GunStatesPos = new();

    [Header("Rotate")]
    [Space]
    public float RotateMinX;
    public float RotateMaxX;
    public float RotateMinY;
    public float RotateMaxY;
    public float RotateX;
    public float RotateY;
    public Camera MainCamera;
    public Camera SniperLens;
    public override void Awake()
    {
        base.Awake();
        ChangeType(new PlayerMove(this));
        ChangeType(new Jump(this));
        ChangeType(new Sliding(this, GunStatesPos));
        ChangeType(WeaponList[GunType.Rifle]);
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        MoveType.Move();
        Weapon.Attack();
        JumpType.Jump();
        SlidingType.Sliding();
    }

    public void LateUpdate()
    {
        PlayerRotate();
    }

    private void PlayerRotate()
    {
        RotateX = Mathf.Clamp(RotateX += (-Input.GetAxis("Mouse Y") * States.RotateSpeed), RotateMinX, RotateMaxX);
        RotateY = Mathf.Clamp(RotateY += (Input.GetAxis("Mouse X") * States.RotateSpeed), RotateMinY, RotateMaxY);
        transform.rotation = Quaternion.Euler(0, RotateY, 0);
        MainCamera.transform.rotation = Quaternion.Euler(RotateX, transform.eulerAngles.y, 0);
        SniperLens.transform.rotation = Quaternion.Euler(RotateX, transform.eulerAngles.y, 0);
    }

    public override bool ShoutGunCondition()
    {
        if (Input.GetMouseButton(0))
            return true;
        return false;
    }


}
