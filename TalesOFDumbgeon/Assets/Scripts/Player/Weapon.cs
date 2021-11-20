using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public BaseWeapon weaponInfo;
    public BaseSpell spellInfo;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public CharacterStats holder;
    private Collider2D _collider;
    [NonSerialized] public float angle;
    [NonSerialized] public float relativeAngle;
    [NonSerialized] public float relativePosition;
    [SerializeField] private List<DamageArea> damageAreas;
    private DamageArea actualDmgArea;
    public float AttackDuration => actualDmgArea.fixedAnimationTime / holder.GetSpeedValue();


    // Start is called before the first frame update
    void Awake()
    {
        SetOrientation(270);
        //_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        AreaWeapon weapon = new AreaWeapon();
        actualDmgArea = damageAreas[(int) BaseWeapon.WeaponType.Area];
        weapon.SetWeaponHolder(this);
        weapon.Randomize(1);
        ChangeWeapon(weapon);
    }
    
    public void ChangeWeapon(BaseWeapon newWeapon)
    {
        //Reset Collider
        if(_collider!= null)
            Destroy(_collider);
        newWeapon.SetWeaponHolder(this);
        weaponInfo = newWeapon;
        weaponInfo.Equip();
        actualDmgArea.gameObject.SetActive(false);
        actualDmgArea = damageAreas[(int) weaponInfo.AttackType];
        //_spriteRenderer.sprite = weaponInfo.WeaponSprite;
        /*
        _collider = gameObject.AddComponent<PolygonCollider2D>();
        _collider.enabled = false;
        _collider.isTrigger = true;*/
        //_spriteRenderer.color = SingletoneGameController.InfoHolder.LoadColor(weaponInfo.Element);
    }
    
    public void ChangeSpell(BaseSpell newSpell)
    {
        newSpell.SetWeaponHolder(this);
        spellInfo = newSpell;
        spellInfo.Equip();
    }
    
    public void SetOrientation(float newAngle)
    {
        angle = newAngle; 
        gameObject.transform.rotation =Quaternion.Euler(
            new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle+relativeAngle));
    }

    public void Atack()
    {
        //Debug.Log("Im atacking");
        weaponInfo.Atacar();
        StartCoroutine(nameof(AttackCoroutine));
    }

    public void CastSpell()
    {
        if (spellInfo != null)
        {
            spellInfo.Cast();
        }
    }
    
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(holder.tag) && (other.gameObject.CompareTag("Enemigo") || other.gameObject.CompareTag("Player")))
        {
            CharacterStats enemy = other.gameObject.GetComponent<CharacterStats>();
            enemy.DoDamage(weaponInfo.Dmg + holder.strength,  gameObject.transform.position, weaponInfo.Element);
        }
    }
    */
    ////Activate and Desactivate Elements
    public void ReactivateCollider()
    {
        //_collider.enabled = true;
        //_spriteRenderer.color = Color.yellow;
        //actualDmgArea.gameObject.SetActive(true);
        //Invoke(nameof(DesactivateCollider), time);
        StartCoroutine(nameof(AttackCoroutine));
    }

    public void UpdatePosition(Vector3 newCenter)
    {
        gameObject.transform.position = newCenter;
        gameObject.transform.position += gameObject.transform.right * relativePosition;
    }

    public void DesactivateCollider()
    {
        //_spriteRenderer.color = SingletoneGameController.InfoHolder.LoadColor(weaponInfo.Element);
        //_collider.enabled = false;
        actualDmgArea.gameObject.SetActive(false);
    }

    private IEnumerator AttackCoroutine()
    {
        float duration = actualDmgArea.fixedAnimationTime / holder.GetSpeedValue();
        holder.Immobilize(duration);
        yield return new WaitForSeconds(duration*actualDmgArea.percentStartDmg);
        actualDmgArea.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration*actualDmgArea.percentStopDmgg-actualDmgArea.percentStartDmg);
        actualDmgArea.gameObject.SetActive(false);
    }
    
}
