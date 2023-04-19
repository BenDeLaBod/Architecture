using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIScript : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI ammoSizeText; 
    [SerializeField] private TextMeshProUGUI ammoCountText; 
    


    public void UpdateInfo(/*Sprite weaponIcon,*/ int ammoSize, int ammoCount)
    {
        //icon.sprite = weaponIcon;
        ammoSizeText.text = ""+ammoSize.ToString();
        ammoCountText.text = "" + ammoCount.ToString();
        
    }
}
