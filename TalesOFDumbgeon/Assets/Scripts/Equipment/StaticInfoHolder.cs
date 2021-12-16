using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInfoHolder : MonoBehaviour
{

    [Header("Weapons Artwork")]
    [SerializeField] public Sprite areaWeaponArtwork;
    [SerializeField] public Sprite rangedWeaponArtwork;
    [SerializeField] public Sprite smashingWeaponArtwork;
    [SerializeField] public Sprite piercingWeaponArtwork;
    [SerializeField] public Sprite boomerangWeaponArtwork;
    [SerializeField] public Sprite rapierWeaponArtwork;

    [Header("Cards")]
    [SerializeField] public Sprite cartaArma;
    [SerializeField] public Sprite cartaArmadura;
    [SerializeField] public Sprite cartaBendicion;
    [SerializeField] public Sprite cartaMaldicion;
    [SerializeField] public Sprite cartaHechizo;

    public static string Normal = "Normal";
    public static string Warrior = "Warrior";
    public static string Wizard = "Wizard";
    public static string Rogue = "Rogue";

    [Header("Armor Artwork")] 
    [SerializeField] public List<Sprite> warrior;
    [SerializeField] public List<Sprite> wizard;
    [SerializeField] public List<Sprite> rogue;
    
    [Header("Spells")]
    [SerializeField] public List<Sprite> dmgSpellSprites;
    [SerializeField] public List<Sprite> dmgSpellArtworks;
    
    [Header("Blessings")]
    [SerializeField] public Sprite ChupitoDeLeche;
    [SerializeField] public Sprite GalletasDeDragon;
    [SerializeField] public Sprite Queso;
    [SerializeField] public Sprite TortillaDePatatas;
    [SerializeField] public Sprite PowerUp;
    
    [Header("Other sprites")]
    [SerializeField] public Sprite ammoSprite;
    [SerializeField] public GameObject hechizo;
    
    
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
                switch (element)
                {
                    case Elements.Element.Normal:
                        info[0] = "Bastón de Yayo";
                        info[1] = "Eres lento pero darás garrotazos tremendos";
                        break;
                    case Elements.Element.Caos:
                        info[0] = "Vara Kedavra";
                        info[1] = "Ni hechizos ni leches, ¡dale en la cabeza!";
                        break;
                    case Elements.Element.Brisa:
                        info[0] = "Martillo de Marca Registrada";
                        info[1] = "Portada por alguien que no era nórdico, ni un dios y con ninguna relación con los truenos";
                        break;
                    case Elements.Element.Copo:
                        info[0] = "Mazo de Troll";
                        info[1] = "Esta tan frío que a lo mejor ni lo sientes";
                        break;
                    case Elements.Element.Guijarro:
                        info[0] = "Pisapapeles";
                        info[1] = "La única ocasión en la que la piedra vencerá al papel";
                        break;
                    case Elements.Element.Brasa:
                        info[0] = "Antorcha senil";
                        info[1] = "Para aquellos que fumen, usen magia de fuego o ambas cosas a la vez";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(element), element, null);
                }
                break;
            case BaseWeapon.WeaponType.Piercing:
                switch (element)
                {
                    case Elements.Element.Normal:
                        info[0] = "Palo largo afilado";
                        info[1] = "El nombre es bastante descriptivo";
                        break;
                    case Elements.Element.Caos:
                        info[0] = "Nagi-Nata";
                        info[1] = "Naginata emponzoñada con un veneno que convierte la sangre de sus víctimas en horchata";
                        break;
                    case Elements.Element.Brisa:
                        info[0] = "Pararrayos";
                        info[1] = "Ha absorbido tanta electricidad que ahora puede dar descargas";
                        break;
                    case Elements.Element.Copo:
                        info[0] = "Tridente Mellado";
                        info[1] = "Solo le queda una punta, pero sirve igual para darle la del pulpo a los monstruos";
                        break;
                    case Elements.Element.Guijarro:
                        info[0] = "Picapiedras";
                        info[1] = "Perfecta para atravesar calizas, cráneos, volcánicas, corazones, metamórficas...";
                        break;
                    case Elements.Element.Brasa:
                        info[0] = "Lanzazteca ";
                        info[1] = "Confeccionada con una punta de obsidiana que aún arde con fuerza";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(element), element, null);
                }
                break;
            case BaseWeapon.WeaponType.Frisbie:
                switch (element)
                {
                    case Elements.Element.Normal:
                        info[0] = "Frisbye";
                        info[1] = "Despídete de aquel al que le dé";
                        break;
                    case Elements.Element.Caos:
                        info[0] = "Doomerang";
                        info[1] = "Con esta arma, lo único a lo que temerán... es a ti";
                        break;
                    case Elements.Element.Brisa:
                        info[0] = "Discolega";
                        info[1] = "¿Alguien ha visto la película Tron?";
                        break;
                    case Elements.Element.Copo:
                        info[0] = "Placa de hielo";
                        info[1] = "Para mantener fríos tu almuerzo de mañana o los cadáveres de tu contrincantes";
                        break;
                    case Elements.Element.Guijarro:
                        info[0] = "Tazo gigantesco roñoso";
                        info[1] = "Un arma más simple, como los tiempos de los que viene";
                        break;
                    case Elements.Element.Brasa:
                        info[0] = "Anillo de Fuego";
                        info[1] = "No tan pacífico como te quieren hacer creer los geólogos...";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(element), element, null);
                }
                break;
            case BaseWeapon.WeaponType.Rapier:
                switch (element)
                {
                    case Elements.Element.Normal:
                        info[0] = "Florete de 5 puntas";
                        info[1] = "Solo tiene 1, pero corta como si fueran 5";
                        break;
                    case Elements.Element.Caos:
                        info[0] = "Sai-yonara";
                        info[1] = "Hasta la vista baby";
                        break;
                    case Elements.Element.Brisa:
                        info[0] = "Estoque de Protones";
                        info[1] = "Un arma eléctrica, para mazmorras más civilizadas";
                        break;
                    case Elements.Element.Copo:
                        info[0] = "Carámbano Frío del Carajo";
                        info[1] = "Aplicale las leyes de la termodinámica a las entrañas de tus víctimas";
                        break;
                    case Elements.Element.Guijarro:
                        info[0] = "Aguja de punto de tu abuela";
                        info[1] = "Teje una bufanda con lo instentinos de tus enemigos";
                        break;
                    case Elements.Element.Brasa:
                        info[0] = "Aguja Esterilizada";
                        info[1] = "Las heridas que inflinja no se infectarán pero quemarán como el mismísimo infierno";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(element), element, null);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(weaponType), weaponType, null);
        }
        return info;
    }

    public static string[] LoadName(BaseBlessing.BlessingType blessType, int subIndex)
    {
        string[] info = new string[2];
        switch (blessType)
        {
            case BaseBlessing.BlessingType.Heal:
                switch ((HealBlessing.HealingItems) subIndex)
                {
                    case HealBlessing.HealingItems.Chupito:
                        info[0] = "Chupito de Leche";
                        info[1] = "Traguito rico en calcio y puntos de vida";
                        break;
                    case HealBlessing.HealingItems.Dragon:
                        info[0] = "Galletas de Dragón";
                        info[1] = "Los niños comen galletas con forma de dragón y los dragones niños con forma de niños, es el ciclo vital";
                        break;
                    case HealBlessing.HealingItems.Queso:
                        info[0] = "Cuña de Queso";
                        info[1] = "Tan, pero tan curado, que te cura";
                        break;
                    case HealBlessing.HealingItems.Tortilla:
                        info[0] = "Tortilla de patatas";
                        info[1] = "El alimento primigenio, el manjar de los dioses, el fruto de la vida eterna...";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(subIndex), subIndex, null);
                }
                break;
            case BaseBlessing.BlessingType.PowerUp:
                info[0] = "Power Up";
                info[1] = "Aumenta temporalmente tu fuerza, defensa y velocidad de manera inversamente proporcional a tu salud";
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(blessType), blessType, null);
        }
        return info;
    }
    public static string[] LoadName(BaseArmor.BodyPart armorType, BaseArmor.ArmorPart armorKind, Elements.Element element)
    {
        string[] info = new string[2];
        switch (armorKind)
        {
            case BaseArmor.ArmorPart.Wizard:
                switch (armorType)
                {
                    case BaseArmor.BodyPart.Head:
                        switch (element)
                        {
                            case Elements.Element.Normal:
                                info[0] = "Gorro de mago sin ala";
                                info[1] = "No teniamos presupuesto para más";
                                break;
                            case Elements.Element.Caos:
                                info[0] = "GitHab";
                                info[1] = "Prenda que te cubre el rostro para ocultar la desesperación que te produce llevarlo";
                                break;
                            case Elements.Element.Brisa:
                                info[0] = "Paracaídas capilar";
                                info[1] = "Tela que atrapa los vientos alisios para cuidar tu cabello sin renunciar a una buena defensa";
                                break;
                            case Elements.Element.Copo:
                                info[0] = "Capucha con pelito";
                                info[1] = "No permitirá que tus orejas se queden frias, eso sería un delito";
                                break;
                            case Elements.Element.Guijarro:
                                info[0] = "Gorro de Trekking";
                                info[1] = "¿Es un gorro? ¿Es una capucha? Quien sabe...";
                                break;
                            case Elements.Element.Brasa:
                                info[0] = "Caperuza Cenicera";
                                info[1] = "Para aquellos que fumen, usen magia de fuego o ambas cosas a la vez";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(element), element, null);
                        }
                        break;
                    case BaseArmor.BodyPart.Body:
                        switch (element)
                        {
                            case Elements.Element.Normal:
                                info[0] = "Sayo de Saya";
                                info[1] = "Una capa tan elegante y sútil como la referencia que hace a uno de los desarrolladores.";
                                break;
                            case Elements.Element.Caos:
                                info[0] = "Capa de Imbecibilidad";
                                info[1] = "Te pone al nivel intelectual de las criaturas de la mazmorra, protegiendote de sus locuras";
                                break;
                            case Elements.Element.Brisa:
                                info[0] = "Manto Aislante";
                                info[1] = "Capa usada por los electricistas. Un momento, ¿en este mundo hay electricidad?";
                                break;
                            case Elements.Element.Copo:
                                info[0] = "Rebequita";
                                info[1] = "Pieles de una pobre mujer llamada Rebeca que murió de hipotermia";
                                break;
                            case Elements.Element.Guijarro:
                                info[0] = "Túnica de Esmeralda";
                                info[1] = "No esta hecha de esmeralda, es de tela pero queda mazo bien el nombre";
                                break;
                            case Elements.Element.Brasa:
                                info[0] = "Chilaba del Desierto";
                                info[1] = "Esta prenda oriental no dejara que el calor del desierto te haga daño";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(element), element, null);
                        }
                        break;
                    case BaseArmor.BodyPart.Legs:
                        switch (element)
                        {
                            case Elements.Element.Normal:
                                info[0] = "Zapatillas normales";
                                info[1] = "¿Qué? ¿Te pensabas que todo iba a ser mágico?.";
                                break;
                            case Elements.Element.Caos:
                                info[0] = "Deportivas Muggle";
                                info[1] = "No son magicas, pero si bastante resistentes";
                                break;
                            case Elements.Element.Brisa:
                                info[0] = "Paso relampageante";
                                info[1] = "¡Kachau!";
                                break;
                            case Elements.Element.Copo:
                                info[0] = "Desliz Helado";
                                info[1] = "Si miras cuidadosamente, no son botas, es que se te han congelado los pies";
                                break;
                            case Elements.Element.Guijarro:
                                info[0] = "Terre Motor";
                                info[1] = "Equipadas con un motor de vapor para marchar con una fuerza verdaderamente revolucionaria";
                                break;
                            case Elements.Element.Brasa:
                                info[0] = "Sandalias Negras";
                                info[1] = "Ten cuidado de que no se te derritan mientras caminas con ellas a 45 grados en la playa";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(element), element, null);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(armorType), armorType, null);
                }
                break;
            case BaseArmor.ArmorPart.Warrior:
                switch (armorType)
                {
                    case BaseArmor.BodyPart.Head:
                        switch (element)
                        {
                            case Elements.Element.Normal:
                                info[0] = "Yelmo de tu yerno";
                                info[1] = "Proteger, protege, pero apesta a alcohol…";
                                break;
                            case Elements.Element.Caos:
                                info[0] = "Casco de Metal Man";
                                info[1] = "Una mala copia del verdadero";
                                break;
                            case Elements.Element.Brisa:
                                info[0] = "Sombrero de aluminio";
                                info[1] = "Resguardate de los controles mentales y de cualquier ataque electromagnético";
                                break;
                            case Elements.Element.Copo:
                                info[0] = "Mente fria";
                                info[1] = "Merengue merengue";
                                break;
                            case Elements.Element.Guijarro:
                                info[0] = "Casco de obra";
                                info[1] = "Una armadura legendaria que aparece en los míticos códigos de seguridad laboral de los aventureros, pero que hasta ahora nadie creía real";
                                break;
                            case Elements.Element.Brasa:
                                info[0] = "Estufa portatil";
                                info[1] = "Efectos secundarios: Calvicie, Quemaduras de tercer grado, Muerte";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(element), element, null);
                        }
                        break;
                    case BaseArmor.BodyPart.Body:
                        switch (element)
                        {
                            case Elements.Element.Normal:
                                info[0] = "Plancha de metal";
                                info[1] = "De un bala seguro que no te protege pero es mejor que nada";
                                break;
                            case Elements.Element.Caos:
                                info[0] = "Armadura de Espinas";
                                info[1] = "Era una gran idea, pero las espinas están del lado interior";
                                break;
                            case Elements.Element.Brisa:
                                info[0] = "Cota de Pegaso";
                                info[1] = "¡Armadura usada por el legendario Saint! ¿O se llamaba Seiya? A saber, nunca vi Evangelion...";
                                break;
                            case Elements.Element.Copo:
                                info[0] = "Armadura Carambo";
                                info[1] = "¡Caramba, que armadura!";
                                break;
                            case Elements.Element.Guijarro:
                                info[0] = "Pechera Pétrea";
                                info[1] = "Esculpida en mármol para guerreros con el físico de una estatua griega";
                                break;
                            case Elements.Element.Brasa:
                                info[0] = "Dracoarmadracura";
                                info[1] = "Armadura hecha con las escamas de un dragón que llevaba una armadura hecha con más escamas de dragón...";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(element), element, null);
                        }
                        break;
                    case BaseArmor.BodyPart.Legs:
                        switch (element)
                        {
                            case Elements.Element.Normal:
                                info[0] = "Escarpines de acero";
                                info[1] = "¿Es esto una pieza de armadura de verdad?";
                                break;
                            case Elements.Element.Caos:
                                info[0] = "Manoplas";
                                info[1] = "Tienen 5 dedos también, debería funcionar";
                                break;
                            case Elements.Element.Brisa:
                                info[0] = "Babuchas de Bruce Ali";
                                info[1] = "Flota como una abeja, golpea como una mariposa";
                                break;
                            case Elements.Element.Copo:
                                info[0] = "Zapas Fresquisimas";
                                info[1] = "Pertenecian al pana Miguel, ¿como han acabado aqui?";
                                break;
                            case Elements.Element.Guijarro:
                                info[0] = "Alpargatas gastadas";
                                info[1] = "Esculpida en mármol para guerreros con el físico de una estatua griega";
                                break;
                            case Elements.Element.Brasa:
                                info[0] = "Botas quemadas";
                                info[1] = "Parecen los chistes de este juego";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(element), element, null);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(armorType), armorType, null);
                }
                break;
            case BaseArmor.ArmorPart.Rogue:
                switch (armorType)
                {
                    case BaseArmor.BodyPart.Head:
                        switch (element)
                        {
                            case Elements.Element.Normal:
                                info[0] = "Gorro con agujeros";
                                info[1] = "Que casualidad que los agujeros esten justo donde tus ojos, de lujo.";
                                break;
                            case Elements.Element.Caos:
                                info[0] = "Máscara de Majorca";
                                info[1] = "Una locura de artefacto usada para toda clase de rituales lunares, una función poco útil en interiores...";
                                break;
                            case Elements.Element.Brisa:
                                info[0] = "Chulloftur";
                                info[1] = "Dicen que el antiguo portador de este gorro era capaz de lanzar tornados e incluso tocar el tambor";
                                break;
                            case Elements.Element.Copo:
                                info[0] = "Tocado y Hundido";
                                info[1] = "Tocado usado por la burguesía atlante antes de que... bueno, pasará eso, ya sabes...";
                                break;
                            case Elements.Element.Guijarro:
                                info[0] = "Pasamontañas";
                                info[1] = "Usado por los traficantes de formaciones geológicas para poder transportar cordilleras y valles";
                                break;
                            case Elements.Element.Brasa:
                                info[0] = "Calientacaretos";
                                info[1] = "¿Para que sufrir el calor del fuego enemigo cuando puedes infligrte ese dolor tú mismo?";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(element), element, null);
                        }
                        break;
                    case BaseArmor.BodyPart.Body:
                        switch (element)
                        {
                            case Elements.Element.Normal:
                                info[0] = "Chaleco Pijo";
                                info[1] = "Innecesariamente elegante y dejando el pecho desprotegido, ¿puede haber una armadura mejor?";
                                break;
                            case Elements.Element.Caos:
                                info[0] = "Chaleco Tactico";
                                info[1] = "Utilizado por los mejores ninjas de una villa que cuyo nombre no quiero acordarme.";
                                break;
                            case Elements.Element.Brisa:
                                info[0] = "Vestido de hippie";
                                info[1] = "Una prenda tan libre como tu pensamiento... Maldito hippie";
                                break;
                            case Elements.Element.Copo:
                                info[0] = "Abrigo de esquimal";
                                info[1] = "Ya sabes, los esquimales van con el pecho al aire, ellos no tienen frio... estan acostrumbrados";
                                break;
                            case Elements.Element.Guijarro:
                                info[0] = "Manto Minero";
                                info[1] = "No vale su peso en oro, pero te dará la fuerza para conseguir los minerales que te propongas";
                                break;
                            case Elements.Element.Brasa:
                                info[0] = "Sueter de tu abuela";
                                info[1] = "Tu abuela no dejara que pases frio en el interior de la Dumbgeon. No vaya a ser que te costipes.";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(element), element, null);
                        }
                        break;
                    case BaseArmor.BodyPart.Legs:
                        switch (element)
                        {
                            case Elements.Element.Normal:
                                info[0] = "Deportivas Decentes";
                                info[1] = "Buenas, bonitas y baratas. El calzado más estándar para los pies más refinados";
                                break;
                            case Elements.Element.Caos:
                                info[0] = "Chanclas de Turista";
                                info[1] = "Desafía los límites del sinsentido y lo hortera de una manera internacionalmente aceptada";
                                break;
                            case Elements.Element.Brisa:
                                info[0] = "Maratacón";
                                info[1] = "Con su tacón de aguja hará que realices cada pisada a la velocidad del rayo, si no te tropiezas claro...";
                                break;
                            case Elements.Element.Copo:
                                info[0] = "Patines Carchados";
                                info[1] = "Aislan el frío y la fricción con el suelo para que cada combate se sienta tan fresco como el primero";
                                break;
                            case Elements.Element.Guijarro:
                                info[0] = "Botas sin suela";
                                info[1] = "Resistentes como ninguna perfectas para sentir el suelo directamente.";
                                break;
                            case Elements.Element.Brasa:
                                info[0] = "Pies en Polvorosa";
                                info[1] = "Quema suela y huye de la justicia con el poder ígneo de estas botas.";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(element), element, null);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(armorType), armorType, null);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(armorKind), armorKind, null);
        }
        return info;
    }

    public Color LoadColor(Elements.Element element)
    {
        return colors[((int) element) + 1];
    }

    public static string[] LoadName(BaseSpell.SpellType spellKind, Elements.Element spellElement)
    {
        string[] info = new string[2];
        switch (spellKind)
        {
            case BaseSpell.SpellType.Damage:
                switch (spellElement)
                {
                    case Elements.Element.Normal:
                        info[0] = "Bola de papel";
                        info[1] = "Un trozo de papel que llevabas en los bolsillos. Esta afilado";
                        break;
                    case Elements.Element.Caos:
                        info[0] = "Tiromancia suprema";
                        info[1] = "Convierte a tus enemigos en deliciosas cuñas de queso curado de oveja. Que hambre, ¿no?";
                        break;
                    case Elements.Element.Brisa:
                        info[0] = "Poder limitado";
                        info[1] = "Dispara rayos por tus manos y trae la paz, libertad, justicia y seguridad a tu barrio";
                        break;
                    case Elements.Element.Copo:
                        info[0] = "Frío burgalés";
                        info[1] = "Lanza una brisa capaz de congelar hasta el mismo sol";
                        break;
                    case Elements.Element.Guijarro:
                        info[0] = "Petrotari";
                        info[1] = "Envía una pelota dura como una montaña que los enemigos no verán venir";
                        break;
                    case Elements.Element.Brasa:
                        info[0] = "Saeta de fuego";
                        info[1] = "Entona una canción con una pasión tan ardiente que abrasa lo que se encuentra delante";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(spellElement), spellElement, null);
                }
                break;
            case BaseSpell.SpellType.Hability:
                break;
            case BaseSpell.SpellType.EspecialDmg:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(spellKind), spellKind, null);
        }
        return info;
    }
}
