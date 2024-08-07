using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleTone<GameManager>
{

    public override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
