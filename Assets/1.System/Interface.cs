using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public void Attack();
}

public interface ISKill
{
    public void Skill();
}

public interface IMove
{
    public void Move();
}


public interface IJump
{
    public void Jump();
}

public interface ISliding
{
    public void Sliding();
}
public interface IUnit
{
    public States GetStates();
    public Transform GetTransform();

}

public interface IPlayer
{

}

public interface IEnemy
{

}