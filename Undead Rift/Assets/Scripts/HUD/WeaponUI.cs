using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] public Image icon;
    [SerializeField] public Text magazineSizeText;
    [SerializeField] public Text magazineCountText;

    public void UpdateInfo(Sprite weaponIcon, int magazineSize, int magazineCount)
    {
        icon.sprite = weaponIcon;
        magazineSizeText.text = magazineSize.ToString();
        magazineCountText.text = magazineCount.ToString();
    }
}
