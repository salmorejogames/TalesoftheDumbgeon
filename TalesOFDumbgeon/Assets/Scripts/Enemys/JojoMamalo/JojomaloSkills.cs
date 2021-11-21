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
    
    [SerializeField] private float movementSpeed = 0.3f;

    [SerializeField] private InGameCard cardPrefab;
    public enum Skills
    {
        LineAttack,
        BowAttack,
        SnakeAttack,
        Tp,
        AreaAttack,
        ExplosionCounter,
        ChangueElement
    }

    public void ActivateSkill(Skills skill, string argument)
    {
        switch (skill)
        {
            case Skills.LineAttack:
            case Skills.BowAttack:
            case Skills.SnakeAttack:
            case Skills.AreaAttack:
                ActivateSkill(skill);
                break;
            case Skills.Tp:
                TeleportInvulnerable(float.Parse(argument));
                break;
            case Skills.ExplosionCounter:
                CounterAttack(float.Parse(argument));
                break;
            case Skills.ChangueElement:
                ChangueElement((Elements.Element) int.Parse(argument));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(skill), skill, null);
        }
    }
    
    public void ActivateSkill(Skills skill)
    {
        switch (skill)
        {
            case Skills.LineAttack:
                StartCoroutine(RangedAttack1());
                break;
            case Skills.BowAttack:
                StartCoroutine(RangedAttack2());
                break;
            case Skills.SnakeAttack:
                StartCoroutine(RangedAttack3());
                break;
            case Skills.Tp:
                TeleportInvulnerable(0);
                break;
            case Skills.AreaAttack:
                AreaAttack();
                break;
            case Skills.ExplosionCounter:
                CounterAttack(5);
                break;
            case Skills.ChangueElement:
                ChangueElement(Elements.Element.Caos);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(skill), skill, null);
        }
    }
    public IEnumerator RangedAttack1()
        {
            
            mind.DisableMovement(weapon.weaponInfo.AttackSpeed*5);
            mind.animationController.SetAttack();
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(weapon.weaponInfo.AttackSpeed);
                
                Vector3 translate = weapon.gameObject.transform.up * Random.Range(-1f, 1f);
                weapon.gameObject.transform.Translate(translate);
                weapon.Atack();
                weapon.gameObject.transform.position = body.position;
                
            }
            weapon.gameObject.transform.position = body.position;
            mind.animationController.SetStop();
        }
        
        public IEnumerator RangedAttack2()
        {
            Debug.Log("Bow Attack");
            float attackRange = 90f;
            for (int i = 0; i < 3; i++)
            {
                Debug.Log("Ronda " + i);
               
                mind.DisableMovement(weapon.weaponInfo.AttackSpeed*3);
                mind.animationController.SetAttack();
                yield return new WaitForSeconds(weapon.weaponInfo.AttackSpeed);
                
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
            float distance = 2f;
            mind.DisableMovement(weapon.weaponInfo.AttackSpeed*numAtaques/2);
            mind.animationController.SetAttack();
            for (int i = 0; i < numAtaques; i++)
            {
                yield return new WaitForSeconds(weapon.weaponInfo.AttackSpeed/2);
                int angle = Random.Range(0, 360);
                body.position = mind.TargetPos +
                                new Vector3(distance * Mathf.Cos(angle), distance * Mathf.Sin(angle), 0);
                mind.UpdateWeaponAngle();
                weapon.Atack();
            }
            mind.animationController.SetStop();
            TeleportInvulnerable(0);
        }
        private void AreaAttack()
        {
            mind.animationController.SetAttack();
            Vector2 playerPos = SingletoneGameController.PlayerActions.player.gameObject.transform
                .position;
            Vector2 isometricPos = IsometricUtils.ScreenCordsToTilesPos(new Vector2(playerPos.x-0.25f, playerPos.y -0.25f), true);
            Debug.Log(isometricPos.ToString());
            Vector3 pos = IsometricUtils.CoordinatesToWorldSpace(isometricPos.x, isometricPos.y);
            AreaTileAtack newArea = Instantiate(areaTile, pos, Quaternion.identity);
            newArea.gameObject.transform.parent = body.parent;
            newArea.gameObject.transform.tag = "SpellDmg";
            newArea.spellDmg.SetSpellDmgStats(4, mind.stats.element, pos, body.tag);
            mind.animationController.SetStop();
        }
        private void CounterAttack(float dmg)
        {
            mind.animationController.SetCharge();
            Vector2 playerPos = gameObject.transform.position;
            Vector2 isometricPos = IsometricUtils.ScreenCordsToTilesPos(new Vector2(playerPos.x-0.25f, playerPos.y -0.25f), true);
            Debug.Log(isometricPos.ToString());
            Vector3 pos = IsometricUtils.CoordinatesToWorldSpace(isometricPos.x, isometricPos.y);
            AreaTileAtack newArea = Instantiate(explosionCounterTile, pos, Quaternion.identity);
            newArea.gameObject.transform.parent = body.parent;
            newArea.gameObject.transform.tag = "SpellDmg";
            newArea.spellDmg.SetSpellDmgStats(dmg, mind.stats.element, pos, body.tag);
            mind.animationController.SetAttack();
            mind.animationController.SetStop();
        }
        private void TeleportInvulnerable(float cantidad)
        {
        
            int ran;
            do
            {
                ran = Random.Range(0, JojoMamaloBehaviour.NumPositions);
            } while (ran == mind.ActualPos);
            mind.UpdatePosition(ran);
            if(cantidad>0)
                mind.stats.Heal( cantidad);
        }

        private void ChangueElement(Elements.Element newElement)
        {
            
            weapon.weaponInfo.Element = newElement;
            InGameCard newCard = Instantiate(cardPrefab, gameObject.transform.position + new Vector3(0, 0.5f, 0),
                Quaternion.identity);
            newCard.card.CardInfo = new WeaponCard(weapon.weaponInfo);
            newCard.PlayAnimaton();
            //TODO->ANIMATION

        }
}
