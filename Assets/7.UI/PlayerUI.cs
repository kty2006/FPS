using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Player Player;
    public Image[] GunImages;
    int WheelIndex;
    float WheelInput;
    public void Update()
    {
        GunUI();
    }

    public void GunUI()
    {
        WheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (WheelInput > 0)
        {
            ChangeWeaponUI(true);
        }
        else if (WheelInput < 0)
        {
            ChangeWeaponUI(false);
        }
    }

    public void ChangeWeaponUI(bool isSign)
    {
        int num = (isSign) ? 1 : -1;
        GunImages[WheelIndex].gameObject.SetActive(false);
        WheelIndex = Mathf.Clamp(WheelIndex += num, 0, GunImages.Length - 1);
        GunImages[WheelIndex].gameObject.SetActive(true);
        Player.ChangeWeapon(WheelIndex);
    }
}
