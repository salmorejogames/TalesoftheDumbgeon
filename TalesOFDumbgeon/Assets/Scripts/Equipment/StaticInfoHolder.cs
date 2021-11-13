using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInfoHolder : MonoBehaviour
{
    [SerializeField] public Sprite areaWeapon;
    [SerializeField] public Sprite rangedWeapon;
    [SerializeField] public Sprite smashingWeapon;
    [SerializeField] public Sprite piercingWeapon;
    
    [SerializeField] public Sprite areaWeaponArtwork;
    [SerializeField] public Sprite rangedWeaponArtwork;
    [SerializeField] public Sprite smashingWeaponArtwork;
    [SerializeField] public Sprite piercingWeaponArtwork;
    
    [SerializeField] public Sprite cartaArma;
    [SerializeField] public Sprite cartaArmadura;
    [SerializeField] public Sprite cartaBendicion;
    [SerializeField] public Sprite cartaMaldicion;
    [SerializeField] public Sprite cartaHechizo;

    public static string Normal = "Normal";
    public static string Warrior = "Warrior";
    public static string Wizard = "Wizard";
    public static string Rogue = "Rogue";
    

    [SerializeField] public Sprite ammoSprite;
    
    
    [SerializeField] private List<Color> colors;
    
    public static string[] LoadName(BaseWeapon.WeaponType weaponType, Elements.Element element)
    {
        string[] info = new string[2];
        switch (weaponType)
        {
            case BaseWeapon.WeaponType.Area:
                switch (element)
                {
                    case Elements.Element.Normal:
                        info[0] = "Espada de Fe";
                        info[1] = "Es una espada de hierro normal y corriente, no te emociones";
                        break;
                    case Elements.Element.Caos:
                        info[0] = "Caortana";
                        info[1] = "Corta y resuelve tus preguntas más locas, pero sobre todo corta";
                        break;
                    case Elements.Element.Brisa:
                        info[0] = "Tifona";
                        info[1] = "¡Suenan vientos de conquista!";
                        break;
                    case Elements.Element.Copo:
                        info[0] = "Corte en frío";
                        info[1] = "Ideal para refrescar a tus enemigos, hasta la muerte...";
                        break;
                    case Elements.Element.Guijarro:
                        info[0] = "Geoladius";
                        info[1] = "Fabricada con los cantos rodados de las carreteras más selectas";
                        break;
                    case Elements.Element.Brasa:
                        info[0] = "Al rojo vivo";
                        info[1] = "Recién sacada de la forja para acabar con cualquier monstruo que se encuentre";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(element), element, null);
                }
                break;
            case BaseWeapon.WeaponType.Ranged:
                switch (element)
                {
                    case Elements.Element.Normal:
                        info[0] = "Pistola de Gomas";
                        info[1] = "Vuelve a tu infancia y atiza a tus amigos (o enemigos) con un daño elaaaaaaastico";
                        break;
                    case Elements.Element.Caos:
                        info[0] = "La mano disparo";
                        info[1] = "Putrefacta mano vudú para destruir a tus enemigos de formas menos sutiles";
                        break;
                    case Elements.Element.Brisa:
                        info[0] = "Aire.zip";
                        info[1] = "Aire ultra mega mazo comprimido";
                        break;
                    case Elements.Element.Copo:
                        info[0] = "Chorrimanguera";
                        info[1] = "Especialmente recomendable cuando tu adversario lleva ropa y riega tu playa";
                        break;
                    case Elements.Element.Guijarro:
                        info[0] = "Tirachinas Plus";
                        info[1] = "Refinado diseño, ¡ahora disparando piedras y no inocentes personas asiáticas!";
                        break;
                    case Elements.Element.Brasa:
                        info[0] = "Makarov";
                        info[1] = "Pura magia sovietica";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(element), element, null);
                }
                break;
            case BaseWeapon.WeaponType.Smashing:
                break;
            case BaseWeapon.WeaponType.Piercing:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(weaponType), weaponType, null);
        }
        return info;
    }

    public Color LoadColor(Elements.Element element)
    {
        return colors[((int) element) + 1];
    }
}
