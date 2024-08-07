using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class States
{
    public float MaxHp;
    public float Hp;
    public float Power;
    public float JumpPower;
    public int AttackSpeed;
    public int MoveSpeed;
    public int RotateSpeed;
}

[Serializable]
public class GunData
{
    public List<Gun> GunObj;
    public List<Bullet> BulletObj;
}

[Serializable]
public class Inventory
{
    public GunData GunData = new();
}
public enum GunType { Rifle, Sniper, Shotgun }
[Serializable]
public class Unit : MonoBehaviour, IUnit
{
    public States States = new();
    public Inventory Inventory = new();
    public Dictionary<GunType, IWeapon> WeaponList;
    public GunType CurrentGunType { get; set; }
    public IWeapon Weapon;
    public ISKill SkillType;
    public IMove MoveType;
    public IJump JumpType;
    public ISliding SlidingType;
    public Transform UnitTransform;
    public Rigidbody Rigidbody;
    public virtual void Awake()
    {
        WeaponList = new Dictionary<GunType, IWeapon>()
        {
            { GunType.Rifle,new Rifle(this, () => ShoutGunCondition()) },
            { GunType.Sniper,new Sniper(this, () => ShoutGunCondition()) },
            { GunType.Shotgun,new Shotgun(this, () => ShoutGunCondition()) },
        };
    }
    public void ChangeType(IWeapon type)
    {
        Weapon = type;
    }
    public void ChangeType(ISKill type)
    {
        SkillType = type;
    }
    public void ChangeType(IMove type)
    {
        MoveType = type;
    }
    public void ChangeType(IJump type)
    {
        JumpType = type;
    }
    public void ChangeType(ISliding type)
    {
        SlidingType = type;
    }

    public States GetStates()
    {
        return States;
    }

    public Transform GetTransform()
    {
        return UnitTransform;
    }

    public Rigidbody GetRigidbody()
    {
        return Rigidbody;
    }

    public virtual bool ShoutGunCondition()
    {
        return false;
    }

    public void ChangeWeapon(int index)
    {
        Gun ChangeGun = Inventory.GunData.GunObj[index];
        Inventory.GunData.GunObj[(int)CurrentGunType].gameObject.SetActive(false);
        ChangeGun.gameObject.SetActive(true);
        CurrentGunType = ChangeGun.GunType;
        ChangeType(WeaponList[CurrentGunType]);
    }
}
