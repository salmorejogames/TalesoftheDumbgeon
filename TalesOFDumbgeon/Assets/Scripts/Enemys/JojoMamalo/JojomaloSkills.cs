using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class JojomaloSkills : MonoBehaviour
{
    [SerializeField] private Transform body;
    [SerializeField] private JojoMamaloBehaviour mind;
    [SerializeField] private Weapon weapon;

    [SerializeField] private AreaTileAtack areaTile;
    [SerializeField] private AreaTileAtack explosionCounterTile;
    [SerializeField] private AreaTileAtack circleAreaTile;

    [SerializeField] private InGameCard cardPrefab;
    [SerializeField] private JojoSounds sounds;

    [SerializeField] private DamageNumber numbers;

    private int _healthTPs = 2;

    public void ActivateSkill(Actions.JojoActions skill)
    {
        //skill = Actions.JojoActions.AreaAttackAndTeleport;
        switch (skill)
        {
            case Actions.JojoActions.Presentacion:
                mind.Objetive = JojoMamaloBehaviour.Objetives.None;
                Invoke(nameof(EndAction), 1f);
                break;
            case Actions.JojoActions.MantenerDistancia:
                mind.Objetive = JojoMamaloBehaviour.Objetives.Mid;
                break;
            case Actions.JojoActions.Acercarse:
                mind.Objetive = JojoMamaloBehaviour.Objetives.Near;
                break;
            case Actions.JojoActions.Alejarse:
                mind.Objetive = JojoMamaloBehaviour.Objetives.Far;
                break;
            case Actions.JojoActions.Atacar:
                break;
            case Actions.JojoActions.RecibirDmg:
                break;
            case Actions.JojoActions.CaC:
                Debug.Log("Ataque Cuerpo a Cuerpo");
                EndAction();
                break;
            case Actions.JojoActions.Arco:
                StartCoroutine(RangedAttack2());
                break;
            case Actions.JojoActions.Linea:
                StartCoroutine(RangedAttack1());
                break;
            case Actions.JojoActions.Circular:
                StartCoroutine(RangedAttack3());
                break;
            case Actions.JojoActions.TeletransporteDisparo:
                StartCoroutine(RangedAttack4());
                //EndAction();
                break;
            case Actions.JojoActions.CirculoDeRunas:
                //Debug.Log("Circulo de runas");
                CircleAreaAttack();
                //EndAction();
                break;
            case Actions.JojoActions.DescargaRunica:
                AreaAttack();
                break;
            case Actions.JojoActions.TeletransporteDisparoFuerte:
                Debug.Log("Teletransporte con disparo fuerte");
                //Inventarse algo xdxdxd
                EndAction();
                break;
            case Actions.JojoActions.InvocarEnemigo:
                Debug.Log("Invocar enemigo");
                EndAction();
                break;
            case Actions.JojoActions.AtaqueDefinitivo:
                //Marcar jugador y ataque en circulo
                //Debug.Log("Ataque definitivo");
                StartCoroutine(DefinitiveAttack());
                //EndAction();
                break;
            case Actions.JojoActions.Curacion:
                //Debug.Log("Curacion");
                //EndAction();
                RestoreHealth();
                break;
            case Actions.JojoActions.TeleportHealh:
                TeleportInvulnerable(100);
                break;
            case Actions.JojoActions.Explosion:
                CounterAttack(5);
                break;
            case Actions.JojoActions.ExplosionAcumulada:
                CounterAttack(mind.DamageAcumulated);
                mind.DamageAcumulated = 0;
                break;
            case Actions.JojoActions.ElementChange:
                Debug.Log("Cambio de Elemento");
                EndAction();
                break;
            case Actions.JojoActions.AreaAttackAndTeleport:
                AreaAndTeleportAttack();
                break;
            case Actions.JojoActions.Teleport:
                TeleportInvulnerable(0);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(skill), skill, null);
        }
    }

    private void EndAction()
    {
        mind.masterMind.EndAction();
    }
    public IEnumerator RangedAttack1()
    {

        mind.DisableMovement(weapon.weaponInfo.AttackSpeed * 5);
        mind.animationController.SetAttack();
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(weapon.weaponInfo.AttackSpeed);
            mind.StasisActionUpdate(BaseEnemy.StasisActions.Attack, 0.05f);
            Vector3 translate = weapon.gameObject.transform.up * Random.Range(-1f, 1f);
            weapon.gameObject.transform.Translate(translate);
            weapon.Atack();
            sounds.LaunchSound(JojoSounds.JojoSoundList.Disparo);
            weapon.gameObject.transform.position = body.position;

        }
        weapon.gameObject.transform.position = body.position;
        mind.animationController.SetStop();
        EndAction();
    }

    public IEnumerator RangedAttack2()
    {
        Debug.Log("Bow Attack");
        float attackRange = 90f;
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Ronda " + i);
            mind.StasisActionUpdate(BaseEnemy.StasisActions.Attack, 0.05f);
            mind.DisableMovement(weapon.weaponInfo.AttackSpeed * 3);
            mind.animationController.SetAttack();
            yield return new WaitForSeconds(weapon.weaponInfo.AttackSpeed);
            sounds.LaunchSound(JojoSounds.JojoSoundList.Disparo);
            float originalAngle = weapon.angle;
            for (float j = -attackRange / 2; j <= attackRange / 2; j += attackRange / 4)
            {
                //Debug.Log(weapon.angle + " " + j);
                weapon.SetOrientation(originalAngle + j);
                weapon.Atack();
            }
            weapon.SetOrientation(originalAngle);
            mind.animationController.SetStop();
        }
        EndAction();
    }
    /*
    public IEnumerator RangedAttack3()
    {
        Vector3 oldPos = body.position;
        bool vertical = !(mind.ActualPos == 0 || mind.ActualPos == 1);
        float distance = 3f;
        float step = distance / 5f;
        yield return new WaitForSeconds(weapon.weaponInfo.AttackDuration);
        float i = 0;
        for (;i < distance; i+=step)
        {
            if (vertical)
                body.position = oldPos + (Vector3) IsometricUtils.CartesianToIsometric(new Vector2(i,0));
            else
                body.position = oldPos + (Vector3) IsometricUtils.CartesianToIsometric(new Vector2(0,i));
            weapon.Atack();
            yield return new WaitForSeconds(movementSpeed);
        }
        yield return new WaitForSeconds(weapon.weaponInfo.AttackDuration);
        for (;i >= 0; i-=step)
        {
            if (vertical)
                body.position = oldPos + (Vector3) IsometricUtils.CartesianToIsometric(new Vector2(i,0));
            else
                body.position = oldPos + (Vector3) IsometricUtils.CartesianToIsometric(new Vector2(0,i));
            weapon.Atack();
            yield return new WaitForSeconds(movementSpeed);
        }
        yield return new WaitForSeconds(weapon.weaponInfo.AttackDuration);
        for (;i > -distance; i-=step)
        {
            if (vertical)
                body.position = oldPos + (Vector3) IsometricUtils.CartesianToIsometric(new Vector2(i,0));
            else
                body.position = oldPos + (Vector3) IsometricUtils.CartesianToIsometric(new Vector2(0,i));
            weapon.Atack();
            yield return new WaitForSeconds(movementSpeed);
        }
        yield return new WaitForSeconds(weapon.weaponInfo.AttackDuration);
        for (;i <= 0; i+=step)
        {
            if (vertical)
                body.position = oldPos + (Vector3) IsometricUtils.CartesianToIsometric(new Vector2(i,0));
            else
                body.position = oldPos + (Vector3) IsometricUtils.CartesianToIsometric(new Vector2(0,i));
            weapon.Atack();
            yield return new WaitForSeconds(movementSpeed);
        }
        body.position = oldPos;
    }
*/
    public IEnumerator RangedAttack3()
    {
        int numAtaques = 10;
        float distance = 3f;
        mind.DisableMovement(weapon.weaponInfo.AttackSpeed * numAtaques / 2);
        mind.animationController.SetAttack();
        for (int i = 0; i < numAtaques; i++)
        {
            yield return new WaitForSeconds(weapon.weaponInfo.AttackSpeed / 2);
            sounds.LaunchSound(JojoSounds.JojoSoundList.Disparo);
            mind.StasisActionUpdate(BaseEnemy.StasisActions.Attack, 0.05f / numAtaques);
            int angle = Random.Range(0, 360);
            body.position = mind.TargetPos +
                            new Vector3(distance * Mathf.Cos(angle), distance * Mathf.Sin(angle), 0);
            mind.UpdateWeaponAngle();
            weapon.Atack();
        }
        mind.animationController.SetStop();
        TeleportInvulnerable(0);
        EndAction();
    }

    public IEnumerator RangedAttack4()
    {

        int numAtaques = 1;
        float distance = 2f;

        mind.DisableMovement(weapon.weaponInfo.AttackSpeed);
        mind.animationController.SetAttack();
        yield return new WaitForSeconds(weapon.weaponInfo.AttackSpeed);
        

        sounds.LaunchSound(JojoSounds.JojoSoundList.Disparo);
        mind.StasisActionUpdate(BaseEnemy.StasisActions.Attack, 0.05f / numAtaques);
        /*int angle = Random.Range(0, 360);
        body.position = mind.TargetPos +
                        new Vector3(distance * Mathf.Cos(angle), distance * Mathf.Sin(angle), 0);
        mind.UpdateWeaponAngle();*/
        weapon.Atack();
        //yield return new WaitForSeconds(weapon.weaponInfo.AttackSpeed / 4);

        mind.animationController.SetStop();

        yield return new WaitForSeconds(weapon.weaponInfo.AttackSpeed);
        TeleportInvulnerable(0);
        //EndAction();
    }

    private void AreaAttack()
    {
        sounds.LaunchSound(JojoSounds.JojoSoundList.Area);
        mind.animationController.SetAttack();
        mind.StasisActionUpdate(BaseEnemy.StasisActions.Attack, 0.05f);
        Vector2 playerPos = SingletoneGameController.PlayerActions.player.gameObject.transform
            .position;
        Vector2 isometricPos = IsometricUtils.ScreenCordsToTilesPos(new Vector2(playerPos.x - 0.25f, playerPos.y - 0.25f), true);
        //Debug.Log(isometricPos.ToString());
        Vector3 pos = IsometricUtils.CoordinatesToWorldSpace(isometricPos.x, isometricPos.y);
        AreaTileAtack newArea = Instantiate(areaTile, pos, Quaternion.identity);
        newArea.gameObject.transform.parent = body.parent;
        newArea.gameObject.transform.tag = "SpellDmg";
        newArea.spellDmg.SetSpellDmgStats(4, mind.stats.element, pos, body.tag);
        newArea.spellDmg.OnDamage = () => mind.StasisActionUpdate(BaseEnemy.StasisActions.Impact, 4);
        mind.animationController.SetStop();
        EndAction();
    }

    private void CircleAreaAttack()
    {
        sounds.LaunchSound(JojoSounds.JojoSoundList.Area);
        mind.animationController.SetAttack();
        mind.StasisActionUpdate(BaseEnemy.StasisActions.Attack, 0.05f);
        Vector2 playerPos = SingletoneGameController.PlayerActions.player.gameObject.transform
            .position;
        Vector2 isometricPos = IsometricUtils.ScreenCordsToTilesPos(new Vector2(playerPos.x - 0.25f, playerPos.y - 0.25f), true);
        //Debug.Log(isometricPos.ToString());
        Vector3 pos = IsometricUtils.CoordinatesToWorldSpace(isometricPos.x, isometricPos.y);
        AreaTileAtack newArea = Instantiate(circleAreaTile, pos, Quaternion.identity);
        newArea.gameObject.transform.parent = body.parent;
        newArea.gameObject.transform.tag = "SpellDmg";
        newArea.spellDmg.SetSpellDmgStats(4, mind.stats.element, pos, body.tag);
        newArea.spellDmg.OnDamage = () => mind.StasisActionUpdate(BaseEnemy.StasisActions.Impact, 4);
        mind.animationController.SetStop();
        EndAction();
    }

    private void CounterAttack(float dmg)
    {
        sounds.LaunchSound(JojoSounds.JojoSoundList.Area);
        mind.animationController.SetCharge();
        mind.StasisActionUpdate(BaseEnemy.StasisActions.Attack, 0.1f);
        Vector2 playerPos = gameObject.transform.position;
        Vector2 isometricPos = IsometricUtils.ScreenCordsToTilesPos(new Vector2(playerPos.x - 0.25f, playerPos.y - 0.25f), true);
        //Debug.Log(isometricPos.ToString());
        Vector3 pos = IsometricUtils.CoordinatesToWorldSpace(isometricPos.x, isometricPos.y);
        AreaTileAtack newArea = Instantiate(explosionCounterTile, pos, Quaternion.identity);
        newArea.gameObject.transform.parent = body.parent;
        newArea.gameObject.transform.tag = "SpellDmg";
        newArea.spellDmg.SetSpellDmgStats(dmg, mind.stats.element, pos, body.tag);
        newArea.spellDmg.OnDamage = () => mind.StasisActionUpdate(BaseEnemy.StasisActions.Impact, dmg);
        mind.animationController.SetAttack();
        mind.animationController.SetStop();
        EndAction();
    }

    public IEnumerator DefinitiveAttack()
    {
        int numAtaques = 10;
        float distance = 2f;

        sounds.LaunchSound(JojoSounds.JojoSoundList.Area);
        mind.animationController.SetAttack();
        mind.StasisActionUpdate(BaseEnemy.StasisActions.Attack, 0.05f);
        Vector2 playerPos = SingletoneGameController.PlayerActions.player.gameObject.transform.position;
        Vector2 isometricPos = IsometricUtils.ScreenCordsToTilesPos(new Vector2(playerPos.x - 0.25f, playerPos.y - 0.25f), true);
        //Debug.Log(isometricPos.ToString());
        Vector3 pos = IsometricUtils.CoordinatesToWorldSpace(isometricPos.x, isometricPos.y);
        AreaTileAtack newArea = Instantiate(circleAreaTile, pos, Quaternion.identity);
        newArea.gameObject.transform.parent = body.parent;
        newArea.gameObject.transform.tag = "SpellDmg";
        newArea.spellDmg.SetSpellDmgStats(4, mind.stats.element, pos, body.tag);
        newArea.spellDmg.OnDamage = () => mind.StasisActionUpdate(BaseEnemy.StasisActions.Impact, 4);

        mind.DisableMovement(weapon.weaponInfo.AttackSpeed * numAtaques / 2);
        for (int i = 0; i < numAtaques; i++)
        {
            yield return new WaitForSeconds(weapon.weaponInfo.AttackSpeed / 2);
            sounds.LaunchSound(JojoSounds.JojoSoundList.Disparo);
            mind.StasisActionUpdate(BaseEnemy.StasisActions.Attack, 0.05f / numAtaques);
            int angle = Random.Range(0, 360);
            body.position = mind.TargetPos +
                            new Vector3(distance * Mathf.Cos(angle), distance * Mathf.Sin(angle), 0);
            mind.UpdateWeaponAngle();
            weapon.Atack();
        }
        mind.animationController.SetStop();
        TeleportInvulnerable(0);

        EndAction();
    }

    private void RestoreHealth()
    {
        float cantidad = Random.Range(5, 15);
        InGameCard newCard = Instantiate(cardPrefab, gameObject.transform.position + new Vector3(0, 0.5f, 0),
            Quaternion.identity);
        newCard.card.CardInfo = new WeaponCard(weapon.weaponInfo);
        newCard.PlayAnimaton();
        mind.stats.Heal(cantidad);
        DamageNumber dmgN = Instantiate(numbers, transform.position, Quaternion.identity);
        dmgN.Inicializar(cantidad, transform);
        dmgN.number.color = Color.green;
        EndAction();
    }

    private void TeleportInvulnerable(float cantidad)
    {
        sounds.LaunchSound(JojoSounds.JojoSoundList.Tp);
        int ran;
        do
        {
            ran = Random.Range(0, JojoMamaloBehaviour.NumPositions);
        } while (ran == mind.ActualPos);
        mind.UpdatePosition(ran);
        if (cantidad > 0.001f)
        {
            mind.stats.Heal(cantidad);
            _healthTPs--;
            if (_healthTPs <= 0)
                mind.invincible = false;
        }
        EndAction();
    }

    private void ChangueElement(Elements.Element newElement)
    {

        weapon.weaponInfo.Element = newElement;
        InGameCard newCard = Instantiate(cardPrefab, gameObject.transform.position + new Vector3(0, 0.5f, 0),
            Quaternion.identity);
        newCard.card.CardInfo = new WeaponCard(weapon.weaponInfo);
        newCard.PlayAnimaton();
        //TODO->ANIMATION
        EndAction();

    }

    private void AreaAndTeleportAttack()
    {
        sounds.LaunchSound(JojoSounds.JojoSoundList.Area);
        mind.animationController.SetAttack();
        mind.StasisActionUpdate(BaseEnemy.StasisActions.Attack, 0.05f);
        Vector2 playerPos = SingletoneGameController.PlayerActions.player.gameObject.transform
            .position;
        Vector2 isometricPos = IsometricUtils.ScreenCordsToTilesPos(new Vector2(playerPos.x - 0.25f, playerPos.y - 0.25f), true);
        //Debug.Log(isometricPos.ToString());
        Vector3 pos = IsometricUtils.CoordinatesToWorldSpace(isometricPos.x, isometricPos.y);
        AreaTileAtack newArea = Instantiate(areaTile, pos, Quaternion.identity);
        newArea.gameObject.transform.parent = body.parent;
        newArea.gameObject.transform.tag = "SpellDmg";
        newArea.spellDmg.SetSpellDmgStats(4, mind.stats.element, pos, body.tag);
        newArea.spellDmg.OnDamage = () => mind.StasisActionUpdate(BaseEnemy.StasisActions.Impact, 4);
        mind.animationController.SetStop();

        TeleportInvulnerable(0);
    }
}
