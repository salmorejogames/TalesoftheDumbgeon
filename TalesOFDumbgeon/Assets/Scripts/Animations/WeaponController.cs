using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject activeWeapon;
    [SerializeField] private GameObject sword;
    [SerializeField] private SpriteRenderer swordColor;
    [SerializeField] private GameObject baston;
    [SerializeField] private SpriteRenderer bastonColor;
    [SerializeField] private SpriteRenderer frisbie;
    [SerializeField] private SpriteRenderer gun;
    [SerializeField] private SpriteRenderer rapier;
    [SerializeField] private SpriteRenderer spear;

    private void Start()
    {
        activeWeapon.SetActive(true);
    }

    public void ChangeActiveWeapon(BaseWeapon.WeaponType weaponType, Elements.Element element)
    {
        Color newColor = SingletoneGameController.InfoHolder.LoadColor(element);
        switch (weaponType)
        {
            case BaseWeapon.WeaponType.Area:
                activeWeapon.SetActive(false);
                sword.SetActive(true);
                swordColor.color = newColor;
                activeWeapon = sword;
                break;
            case BaseWeapon.WeaponType.Ranged:
                activeWeapon.SetActive(false);
                gun.gameObject.SetActive(true);
                gun.color = newColor;
                activeWeapon = gun.gameObject;
                break;
            case BaseWeapon.WeaponType.Smashing:
                activeWeapon.SetActive(false);
                baston.SetActive(true);
                bastonColor.color = newColor;
                activeWeapon = baston;
                break;
            case BaseWeapon.WeaponType.Piercing:
                activeWeapon.SetActive(false);
                spear.gameObject.SetActive(true);
                spear.color = newColor;
                activeWeapon = spear.gameObject;
                break;
            case BaseWeapon.WeaponType.Frisbie:
                activeWeapon.SetActive(false);
                frisbie.gameObject.SetActive(true);
                frisbie.color = newColor;
                activeWeapon = frisbie.gameObject;
                break;
            case BaseWeapon.WeaponType.Rapier:
                activeWeapon.SetActive(false);
                rapier.gameObject.SetActive(true);
                rapier.color = newColor;
                activeWeapon = rapier.gameObject;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(weaponType), weaponType, null);
        }
    }
}
