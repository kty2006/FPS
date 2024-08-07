using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : ISliding
{
    public Unit Unit;
    public GunStatesType GunStatesPos;
    public float time { get; set; } = 1f;
    public float currentTime { get; set; }
    public bool isCheck = false;

    public Sliding(Unit unit, GunStatesType gunStatesPos)
    {
        Unit = unit;
        currentTime = 1;
        GunStatesPos = gunStatesPos;
    }

    void ISliding.Sliding()
    {
        if (currentTime >= time)
        {
            isCheck = false;
            Unit.GetTransform().localScale = Vector3.one;
            Unit.Inventory.GunData.GunObj[0].transform.SetPositionAndRotation(GunStatesPos.Idle.position, GunStatesPos.Idle.rotation);
            Unit.Inventory.GunData.GunObj[0].transform.localScale = GunStatesPos.Idle.localScale;
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                currentTime = 0;
                Unit.GetTransform().localScale = new Vector3(1, 0.5f, 1);
                Unit.Inventory.GunData.GunObj[0].transform.SetPositionAndRotation(GunStatesPos.Slide.position, GunStatesPos.Slide.rotation);
                Unit.Inventory.GunData.GunObj[0].transform.localScale = GunStatesPos.Slide.localScale;
                Unit.GetRigidbody().AddForce(Vector3.down * Unit.GetStates().JumpPower, ForceMode.Impulse);
                Unit.GetRigidbody().AddForce(Unit.GetRigidbody().velocity * Unit.GetStates().JumpPower, ForceMode.Impulse);
                isCheck = true;
            }
        }
        if (isCheck)
            currentTime += Time.deltaTime;
    }
}
