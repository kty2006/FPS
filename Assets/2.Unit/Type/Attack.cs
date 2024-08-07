using System;
using UnityEngine;

public class Rifle : IWeapon
{
    public Unit Unit;
    public Func<bool> ConditionFunc;
    public float time { get; set; } = 0.2f;
    public float currentTime { get; set; }

    public bool isCheck = false;
    public Rifle(Unit unit, Func<bool> condition)
    {
        Unit = unit;
        ConditionFunc = condition;
        currentTime = time;

    }


    public void Attack()

    {
        if (ConditionFunc() && currentTime >= time)
        {
            Unit.Inventory.GunData.BulletObj[0].speed = Unit.States.AttackSpeed * Unit.States.MoveSpeed;
            isCheck = true;
            currentTime = 0;
            GameManager.Instantiate(Unit.Inventory.GunData.BulletObj[0],
                Unit.Inventory.GunData.GunObj[((int)Unit.CurrentGunType)].Muzzle.transform.position,
                Unit.Inventory.GunData.GunObj[((int)Unit.CurrentGunType)].Muzzle.transform.rotation);
        }
        if (isCheck)
            currentTime += Time.deltaTime;
    }
}

public class Sniper : IWeapon
{
    public Unit Unit;
    public Func<bool> ConditionFunc;
    public Gun CurrentGun;
    public float time { get; set; } = 0.2f;
    public float currentTime { get; set; }

    public bool isCheck = false;
    public Sniper(Unit unit, Func<bool> condition)
    {
        Unit = unit;
        ConditionFunc = condition;
        currentTime = time;
        CurrentGun = Unit.Inventory.GunData.GunObj[((int)Unit.CurrentGunType)];
    }


    public void Attack()

    {
        if (Input.GetMouseButton(1))
        {
            CurrentGun.transform.SetPositionAndRotation(CurrentGun.Posture.position, CurrentGun.Posture.rotation);
        }
        if (ConditionFunc() && currentTime >= time)
        {
            Unit.Inventory.GunData.BulletObj[0].speed = Unit.States.AttackSpeed * Unit.States.MoveSpeed;
            isCheck = true;
            currentTime = 0;
            GameManager.Instantiate
                (Unit.Inventory.GunData.BulletObj[0],
                CurrentGun.Muzzle.transform.position,
                CurrentGun.Muzzle.transform.rotation);
        }
        if (isCheck)
            currentTime += Time.deltaTime;
    }
}

public class Shotgun : IWeapon
{
    public Unit Unit;
    public Func<bool> ConditionFunc;
    public float time { get; set; } = 0.2f;
    public float currentTime { get; set; }

    public bool isCheck = false;
    public Shotgun(Unit unit, Func<bool> condition)
    {
        Unit = unit;
        ConditionFunc = condition;
        currentTime = time;

    }


    public void Attack()

    {
        if (ConditionFunc() && currentTime >= time)
        {
            Unit.Inventory.GunData.BulletObj[0].speed = Unit.States.AttackSpeed * Unit.States.MoveSpeed;
            isCheck = true;
            currentTime = 0;
            GameManager.Instantiate(Unit.Inventory.GunData.BulletObj[0],
                Unit.Inventory.GunData.GunObj[((int)Unit.CurrentGunType)].Muzzle.transform.position,
                Unit.Inventory.GunData.GunObj[((int)Unit.CurrentGunType)].Muzzle.transform.rotation);
        }
        if (isCheck)
            currentTime += Time.deltaTime;
    }
}

