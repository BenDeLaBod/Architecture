using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHUDScript : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _ammoSizeText; 
    [SerializeField] private TextMeshProUGUI _ammoCountText; 
    


    public void UpdateInfo(/*Sprite weaponIcon,*/ int ammoSize, int ammoCount)
    {
        //icon.sprite = weaponIcon;
        _ammoSizeText.text = ""+ammoSize.ToString();
        _ammoCountText.text = "" + ammoCount.ToString();
        
    }
}
