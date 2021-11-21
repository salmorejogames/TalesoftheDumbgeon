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
    [NonSerialized] public float angle;
    [NonSerialized] public float relativeAngle;
    [NonSerialized] public float relativePosition;
    [SerializeField] private List<DamageArea> damageAreas;
    private DamageArea _actualDmgArea; 
    public float AttackDuration => _actualDmgArea.fixedAnimationTime / holder.GetSpeedValue();


    // Start is called before the first frame update
    void Start()
    {
        SetOrientation(0);
        //_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(holder.gameObject.CompareTag("Player"))
            _actualDmgArea = damageAreas[(int) BaseWeapon.WeaponType.Area];
        if (weaponInfo == null)
        {
            AreaWeapon weapon = new AreaWeapon();
            weapon.SetWeaponHolder(this);
            weapon.Randomize(1);
            ChangeWeapon(weapon);
        }
        
    }

    public void ChangeWeapon(BaseWeapon newWeapon)
    {
        newWeapon.SetWeaponHolder(this);
        weaponInfo = newWeapon;
        weaponInfo.Equip();
        if (holder.gameObject.CompareTag("Player"))
        {
            _actualDmgArea.gameObject.SetActive(false);
            _actualDmgArea = damageAreas[(int) weaponInfo.AttackType];
        }
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
        //StartCoroutine(nameof(AttackCoroutine));
    }

    public void CastSpell()
    {
        if (spellInfo != null)
        {
            spellInfo.Cast();
            if (holder.gameObject.CompareTag("Player"))
            {
                switch (spellInfo.Element)
                {
                    case Elements.Element.Normal:
                        break;
                    case Elements.Element.Brasa:
                        SingletoneGameController.SoundManager.PlaySound("hechizofuego");
                        break;
                    case Elements.Element.Caos:
                        SingletoneGameController.SoundManager.PlaySound("hechizocaos");
                        break;
                    case Elements.Element.Brisa:
                        SingletoneGameController.SoundManager.PlaySound("hechizoaire");
                        break;
                    case Elements.Element.Copo:
                        SingletoneGameController.SoundManager.PlaySound("hechizohielo");
                        break;
                    case Elements.Element.Guijarro:
                        SingletoneGameController.SoundManager.PlaySound("hechizoroca");
                        break;
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(holder.tag) && (other.gameObject.CompareTag("Enemigo") || other.gameObject.CompareTag("Player")))
        {
            CharacterStats enemy = other.gameObject.GetComponent<CharacterStats>();
            enemy.DoDamage(weaponInfo.Dmg + holder.strength,  gameObject.transform.position, weaponInfo.Element);
        }
    }
    
    ////Activate and Desactivate Elements
    public void ReactivateCollider()
    {
        //_collider.enabled = true;
        //_spriteRenderer.color = Color.yellow;
        //actualDmgArea.gameObject.SetActive(true);
        //Invoke(nameof(DesactivateCollider), time);
        if (holder.gameObject.CompareTag("Player"))
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
        _actualDmgArea.gameObject.SetActive(false);
    }

    private IEnumerator AttackCoroutine()
    {
        float duration = 0f;
        duration = _actualDmgArea.fixedAnimationTime / holder.GetSpeedValue();
        holder.Immobilize(duration);
        yield return new WaitForSeconds(duration*_actualDmgArea.percentStartDmg);
        //sonidos
        switch (weaponInfo.AttackType)
        {
            case BaseWeapon.WeaponType.Area:
                SingletoneGameController.SoundManager.PlaySound("golpeespada");
                break;
            case BaseWeapon.WeaponType.Ranged:
                SingletoneGameController.SoundManager.PlaySound("golpebaston");
                break;
            case BaseWeapon.WeaponType.Smashing:
                SingletoneGameController.SoundManager.PlaySound("golpebaston");
                break;
            case BaseWeapon.WeaponType.Piercing:
                SingletoneGameController.SoundManager.PlaySound("golpelanza");
                break;
            case BaseWeapon.WeaponType.Frisbie:
                SingletoneGameController.SoundManager.PlaySound("golpeespada");
                break;
            case BaseWeapon.WeaponType.Rapier:
                SingletoneGameController.SoundManager.PlaySound("golpelanza");
                break;
        }
        _actualDmgArea.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration*(_actualDmgArea.percentStopDmgg-_actualDmgArea.percentStartDmg));
        _actualDmgArea.gameObject.SetActive(false);

    }
    
}
