using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JojomamaloDmg : Mind
{
    [NonSerialized] public JojoMamaloMind Mind;
    
    public Weapon weapon;
    public float timerActions;
    public float closePlayerDistance;
    
    private float _elapsedTime;
    private int _invincibleTpCount;
    private Transform _player;
    
    [SerializeField] private ImageCanvas imageCanvas;
    [SerializeField] private Sprite fase2;
    [SerializeField] private Sprite fase3;
    private void Start()
    {
        _player = SingletoneGameController.PlayerActions.player.gameObject.transform;
        _invincibleTpCount = 2;
        _elapsedTime = 0f;
    }

    private void FixedUpdate()
    {
        _elapsedTime += Time.fixedDeltaTime;
    }

    public override int GetAction()
    {
        if (_invincibleTpCount > 0)
        {
            _invincibleTpCount--;
            return (int) Actions.JojoActions.TeleportHealh;
        }
        if (Mind.Stage < JojoMamaloMind.Stages && body.stats.GetActualHealth() < Mind.HealthStages[Mind.Stage])
        {
            Debug.LogWarning("FASE CHANGED");
            Mind.Stage++;
            if (Mind.Stage == 1)
            {
                ImageCanvas newCanvas = Instantiate(imageCanvas, gameObject.transform.position, Quaternion.identity, this.transform);
                newCanvas.Inicializar(fase2, gameObject.transform);
            }
            if (Mind.Stage == 2)
            {
                ImageCanvas newCanvas = Instantiate(imageCanvas, gameObject.transform.position, Quaternion.identity, this.transform);
                newCanvas.Inicializar(fase3, gameObject.transform);
            }
            
            return (int) Actions.JojoActions.Explosion;
        }

        if (_elapsedTime >= timerActions)
        {
            _elapsedTime = 0;
            if (Mind.Stage >= 1)
            {
                if (Vector3.Distance(_player.position, body.gameObject.transform.position) <= closePlayerDistance)
                {
                    return (int) Actions.JojoActions.ExplosionAcumulada;
                }

                if (Elements.GetElementMultiplier(weapon.weaponInfo.Stats.element,
                    SingletoneGameController.PlayerActions.player.Stats.element) < 1.9999f)
                {
                    return (int) Actions.JojoActions.ElementChange;
                }

                return (int) Actions.JojoActions.AreaAttackAndTeleport;
            }

            return (int) Actions.JojoActions.Teleport;
        }
        return Mind.EndAction();
    }
}
