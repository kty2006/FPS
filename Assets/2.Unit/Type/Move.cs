using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : IMove
{
    public Unit Unit;
    public float X;
    public float Z;
    public Vector3 dir = Vector3.zero;
    public float time { get; set; } = 0.5f;
    public int speedUp = 1;
    public PlayerMove(Unit unit)
    {
        Unit = unit;
    }

    public void Move()
    {
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");
        if (X != 0 || Z != 0)
        {
            Unit.GetTransform().position += Unit.GetTransform().forward * Z * Unit.GetStates().MoveSpeed * speedUp * Time.deltaTime;
            Unit.GetTransform().position += Unit.GetTransform().right * X * Unit.GetStates().MoveSpeed * speedUp * Time.deltaTime;
            Unit.GetRigidbody().MovePosition(Unit.GetTransform().position);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedUp = 2;
            Debug.Log("´Þ¸®±â");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedUp = 1;
            Debug.Log("°È±â");
        }

    }
}
