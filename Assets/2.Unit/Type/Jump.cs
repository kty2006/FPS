using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : IJump
{
    public Unit Unit;
    public float time { get; set; } = 1f;
    public float currentTime { get; set; }
    public bool isCheck = false;

    public Jump(Unit unit)
    {
        Unit = unit;
        currentTime = 1;
    }

    void IJump.Jump()
    {
        if (currentTime >= time)
        {
            isCheck = false;
            if (Input.GetKeyDown(KeyCode.Space) && currentTime >= time)
            {
                currentTime = 0;
                Unit.GetRigidbody().AddForce(Vector3.up * Unit.GetStates().JumpPower, ForceMode.Impulse);
                isCheck = true;
            }
        }
        if (isCheck)
            currentTime += Time.deltaTime;
    }
}
