using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverBulletCount : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _image;
    private WeaponHUDScript _weaponHUD;
    public int currentAmmoCount;
    bool shot;
    [SerializeField] Gun _gunScript;
    void Start()
    {
        _weaponHUD = GameObject.Find("Ammo HUD").GetComponent<WeaponHUDScript>();
        currentAmmoCount = 6;
    }

    // Update is called once per frame
    void Update()
    {
        currentAmmoCount = _gunScript.bulletsInMag;
        ChangeRevolverImage(currentAmmoCount);
        _weaponHUD.UpdateInfo(6, currentAmmoCount);
    }
    public void ChangeRevolverImage(int newAmmoCount)
    {
        _image.sprite = _sprites[newAmmoCount];
    }

    public void FullAmmo()
    {
        _image.sprite = _sprites[6];
        currentAmmoCount = 6;
    }

}
