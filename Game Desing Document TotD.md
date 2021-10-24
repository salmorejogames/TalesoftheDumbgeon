# Tales of the Dumbgeon

### Versión 1.0
  
![](https://lh3.googleusercontent.com/mLMP4BdUqcm7uP73JZUohcNDXER_u9__SGyA5ftn2UrqcBRD3bcmJ2dJfbkcmNA6M4ouFddkDlnJvenXtwpxyJBPq6LL38vIebKcZ2phJ9jtgO9ILanga0HLwY7M8w=s1600)

*Tales of the Dumbgeon* es un videojuego web de tipo roguelike basado en la obtención de cartas como equipamiento y mecánica principal.

  
![](https://lh5.googleusercontent.com/vmTz35sC8A-dmT_HPU_sdsrVpXHFLMx0z3mTbWqRPJXfYD-vzibhOxPiplkObWB9cwBAMciZyGaTvTDzcH6GeZoULoPOTv81ZqNs34dbyIOW06NcOYmiSivLpuanHQ=s1600)  
  

## SALMOREJO GAMES

- Alejandro Antón Berenguer
- Ismael Jiménez Martínez
- Alejandro Moya Gómez
- Manuel Abarca Crespo
- Elena Pontijas Martín
- Enrique Rico González
- David Sayalero Azaustre

## Índice
**1. Introducción**

	1.1 Descripción breve del concepto 

	1.2 Descripción breve de la historia y personajes

	1.3 Propósito, público objetivo y plataformas 

	1.4 Características principales  

	1.5 Jugabilidad 

	1.5 Estilo Visual 

	1.6 Alcance

**2. Monetización**

	2.1 Tipo de modelo de monetización

	2.2 Tablas de productos y precios

**3. Planificación y Costes**

	3.1 El equipo humano

	3.2 Estimación temporal del desarrollo

	3.3 Costes asociados

**4. Mecánicas de Juego y Elemento de Juego**

	4.1 Jugabilidad

	4.2 Controles y reglas de juego

	4.3 Niveles y misiones

	4.4 Objetos, armas y power ups
	
	4.5 Planificación del modelo de juego para móvil

**5. Trasfondo**

	5.1 Descripción detallada de la historia  y la trama

	5.2 Personajes 

	5.3 Entornos y lugares

**6. Arte**

	6.1 Estética general del juego

	6.2 Apartado visual

	6.3 Música

	6.4 Ambiente Sonoro

**7. Interfaz**

	7.1 Diseños básicos de los menús

	7.2 Diagrama de flujo

**8. Hoja de ruta del desarrollo**

	8.1 Hito 1

	8.2 Hito 2
	
	8.3 Hito 3

	8.4 Fecha de lanzamiento

# 1. Introducción
Este es el documento de diseño de juego de “*Tales of the Dumbgeon*”. Un juego para web que pretende explorar un roguelike frenético y desenfadado de corte fantástico, con toques de humor absurdo, armas, monstruos y un maléfico hechicero.

## 1.1 Descripción breve del concepto     
*Tales of the Dumbgeon* es un videojuego de acción tipo roguelike basado en la obtención de cartas como equipamiento y habilidades, que será la mecánica principal gracias a la cual el jugador podrá llegar hasta el final de la *Dumbgeon*.

Mediante estas mecánicas el jugador podrá crear a lo largo de las partidas personajes únicos con sus virtudes y defectos, armas y armaduras legendarias y con algún que otra maldición.

Se inspira en juegos como *Enter the Gungeon*, *Dead Cells*, *Hades* y *The Binding of Isaac*.

## 1.2 Descripción breve de la historia y personajes
    

“El *Pueblo Boñiga* ha sido asaltado durante siglos por los monstruos y criaturas originadas en el interior de la maldita *Dumbgeon*. Es por eso que cada 69 años se celebra una votación amañada para elegir al héroe (carnada) que entrará en el interior de esta para liberar al pueblo de su yugo. En su interior las cartas ancestrales creadas por *El Mago Jose Joaquin Martín Martinez López*, más conocido como *Jojomamalo*, harán que el héroe se convierta en lo que quiera ser… literalmente y derrotar a los engendros de la *Dumbgeon*.

La familia *Stadtnarr* ha sido siempre el hazme reír del pueblo, los parias a los que nadie quiere. Es por eso que el pueblo los elige a ellos siempre, a lo largo de los años, para internar en la mazmorra a padres, hijos, nietos y abuelos.

¿Conseguirán los *Stadtnarr* llegar hasta el final de la *Dumbgeon*? ¿Descubrirán el secreto que encierra esta misteriosa mazmorra? ¿Habrá un secreto siquiera? Eso es algo que solo se podrá descubrir llegando… al corazón de la *Dumbgeon*. “

## 1.3 Propósito, público objetivo y plataformas
    

El propósito de detrás de la creación de *Tales of the Dumbgeon* es es la de crear un juego divertido y desenfadado de fácil acceso que permita a jugadores de todo el mundo divertirse durante esos ratos muertos frente al ordenador entre actividades más importantes.

*Tales of the Dumbgeon* está dirigido a un amplio abanico de edades aunque el mejor intervalo es entre 18 a 30 años ya que se utilizará humor negro y absurdo. Al ser un videojuego rejugable y desenfadado con una trama simple pero interesante es fácil que entre en el nicho de juegos casuales, un sector cada vez más nutrido de jugadores.

## 1.4 Características principales
    

El videojuego se basa en los siguientes puntos:

-   **Generación aleatoria del mundo y sus mazmorras:** para evitar la repetitividad de escenarios se implementará una generación aleatoria de los mismos, consiguiendo así que cada partida sea diferente y logrando que el juego no se haga pesado a pesar de tener que empezar de cero al morir.
 
-   **Recolección de cartas que generan habilidades y equipo:** por toda la mazmorra el jugador podrá conseguir una gran variedad de cartas, cada una representando una utilidad diferente. De esa forma habrá cartas que funcionarán como equipamiento para el personaje, nuevas habilidades o hasta maldiciones que dificulten la partida, todas ellas cargadas con un toque de humor.
    
-   **Combate rápido cuerpo a cuerpo con habilidades y hechizos**: la *Dumbgeon* estará repleta de enemigos contra los que el jugador deberá enfrentarse usando las habilidades que haya obtenido de las cartas.
    
-  **Jefes finales con memoria:** los distintos enemigos finales de cada zona recordarán los anteriores encuentros que han tenido con el jugador, pudiendo hacer comentarios de diversa índole en función del ratio de victorias y derrotas del jugador.
    
-   **Herencia de habilidades:** al ser cada partida una incursión de un miembro de la familia *Stadtnarr* se incluirá una mecánica que permita la herencia de una de las cartas de antecesor al nuevo personaje.
    
-   **Humor absurdo:** uno de los puntos más característicos del juego será su humor que le dará una aire menos serio al conjunto del título y que buscará hacer reír al jugador en cada ocasión, tomando como referente principal al juego de rol y mesa Munchkin.
    

  

## 1.4 Jugabilidad
    

La jugabilidad de *Tales of the Dumbgeon* se basa en la creación de un personaje con habilidades y equipación aleatorias gracias a cartas que se encontrarán a lo largo de la mazmorra en cofres o que aparecerán después de eliminar enemigos.

Los jugadores se podrán mover en un espacio isométrico en el pelearan cuerpo a cuerpo con sus armas y utilizaran sus habilidades para ir superando los pisos de la mazmorra.

En resumen, la jugabilidad se basa en:

-   Movimiento bidimensional isométrico
-   Combate cuerpo a cuerpo
-   Cartas que otorgan habilidades
	- Armaduras
	- Armas
	-  Ataques a distancia
	- Hechizos
	-   Transformaciones
	- Bendiciones
	- Maldiciones
	-   Cambio de raza, clase y sexo
-   Mejoras de armas
    

  
  

## 1.5 Estilo Visual

El estilo visual que proponemos para *Tales of the Dumbgeon* está inspirado en los juegos con vista isométrica como *Hades* o *Bastion* pero fusionado a un arte más desenfadado y cartoon inspirados en series animadas como *Hora de Aventuras*.

![](https://lh3.googleusercontent.com/RMYApsnRESNI-VLSSgRE5KlxG3vKDg0vjTZ4yYHepeMmhitkjtZb7-3uID5HGnaKNQtiQzt6vXq8Ug1ZbHr1lBoOngivwyY3U1hLbDXuZEcYoqbgZix1tbjVokxQFg=s1600)

![](https://lh3.googleusercontent.com/6RAqxilDy6gRlsVMUV_FksFgOGzkYXPKYbSOy52Ve6FtzBKy3ykzbSe9BcIXGpiONuWJEx-vdt92ak4rbHhA1YM2-yQl64ydPpRWEsuNZfeYATspzgSotqu9NZXD8w=s1600)

![](https://lh6.googleusercontent.com/JL8ytmEYs2MTb4p-tXvZrJsRg6fqU_F260CknLUlgnxLXMpGMvoqoxniIAuJhEl5cMbPFPDQSyBsZdvLiO7uddewaVfuNBdPq3sAEPQ1aL5hEkznuvxP4SADsP_jkA=s1600)

  
## 1.6 Alcance
    

El objetivo principal es desarrollar un juego sencillo pero sólido al que podamos introducir nuevas cartas con armas, armaduras, hechizos, transformaciones y maldiciones de forma constante así como nuevos monstruos o bosses optativos.

Todo esto enmarcado en un juego web con una rejugabilidad alta, en la que cada partida se nota diferente.

# 2. Monetización
  
## 2.1 Tipo de modelo de monetización
       

## 2.2 Tablas de productos y precios


# 3. Planificación y Costes
 ## 3.1 El equipo humano
    
En este apartado se especificará como esta organizado el equipo de desarrollo: ![](https://lh4.googleusercontent.com/VwQvVz3g-nQ35B8WG8IE9GcVboM6WIImdtuAR7Xhp3liWYY4EEYPLDd6TtzaDKszB8Of4A2omb-OEMzohnLdSgncKUnkS0YRCBi2XATMQjwWjgNn5tqvOLYnaPmtyw=s1600)

Existen diversos departamentos para la gestión y el desarrollo de las tareas necesarias para la realización del proyecto. Cada departamento está formado por una o más personas y está dirigido por un líder. Una persona puede estar en más de un departamento.

El jefe de cada departamento está encargado de la asignación y evaluación de las tareas dentro de su equipo. Los problemas que surgen dentro de un departamento se llevan al líder del mismo. Si el problema que surge es un problema mayor o que necesita de otros departamentos el líder debe encargarse de contactar con el equipo de Dirección para formalizar una reunión grupal que pueda solucionarlo.

El equipo de dirección es un equipo especial, que se encargará de la organización de los departamentos, la resolución de problemas entre las personas y la gestión general del proyecto.


Las reuniones se realizan mediante *Microsoft Teams*.

### Uso de Trello

Para el desarrollo del proyecto se usará la metodología Kanban. Para ello se usará un tablero en Trello donde se establecerán 4 columnas principales:

 - **To do**: Tiene las tareas definidas que hay que realizar . 
 - **En proceso**: Tareas que están actualmente en desarrollo. Cada persona puede tener mucho como 2 tareas asignadas en este columna simultáneamente.
- **En revisión**: Tareas que se han completado, pero que están a la espera de ser revisadas por el equipo.
- **Finalizado**: Tareas que han sido revisadas y aprobadas como completadas.

Una **tarea** será representada como una tarjeta en la aplicación. Una tarea estará formada por un subconjunto de puntos a realizar (indicados como una checklist), debe ser lo suficientemente relevante como para ser una tarea individual, pero no puede ser suficientemente general como para no poder ser completada en una iteración o absorber todas las tareas a realizar de un departamento.

Los jefes de cada departamento serán encargados de supervisar la definición de las tareas y sus puntos. Además, son los que tienen que autorizar el paso de una tarea de la columna **en proceso** a **en revisión**.

Para que una persona tenga asignada una tarea sólo tiene que arrastrarla de la columna de **to do** a **en proceso**. Todos los miembros pueden definir tareas en to do y los puntos para estas, pero este proceso tiene que ser aprobado por su líder de departamento.

Para que todo el equipo esté al tanto del avance del proyecto en general, las revisiones serán realizadas en reuniones convocadas por el equipo de dirección. En estas revisiones, se comprobará que cada tarea en la columna **en revisión** cumple con los requisitos necesarios y serán enviadas a la columna **finalizado** de ser así. Si no se cumplen, se editaran los puntos necesarios de la tarea y se moverá de vuelta a **to do**.

Cada tarea tendrá un color asignado correspondiente al departamento del que forma parte. En la columna **to do** se encontraran cabeceras que corresponden a cada departamento bajo las que se encontraran las tarjetas correspondientes a este.

### Uso de GitHub

Todos los archivos del proyecto deben encontrarse en el repositorio de GitHub del proyecto. Cada vez que se quiera realizar un cambio en el proyecto se tendrá que generar este en una rama **(branch)** del proyecto principal. Una vez se complete este cambio se introduce en la rama principal.

Este cambio generalmente estará asociado a una tarea. Cada tarea deberá ser realizada en una rama y los puntos de la tarea pueden realizarse directamente en esta o en ramas anidadas. Una vez que la tarea pase a revisión, se hará un **merge** de la rama en la rama principal.

Estos principios deben seguirse siempre, con excepción de cambios ínfimos, como un cambio en los valores del atributo de velocidad de personaje, nunca se deben realizar cambios en la rama principal.

### Revisiones

Las revisiones a lo largo del desarrollo se ejecutarán los domingos por la mañana. En esta reunión se revisará el estado general del equipo y del desarrollo. Se utilizará la herramienta de trello para observar todas las tareas que están **en revisión** para revisarlas con el jefe de departamento y de proyecto Además se organizaron más revisiones si algún departamento en concreto los necesita para pedir ayuda u opinión del jefe de proyecto o de otro desarrollador.

## 3.2 Estimación temporal del desarrollo
    

La duración estimada del proyecto es de 3 meses, empezando el día 5 de octubre de 2021. Aquí se presentan los diferentes hitos que se tendrán que ir logrando por el equipo de desarrollo.

  

**1.  Entrega de documentos necesarios para la planificación del proyecto GDD** → 10 de octubre de 2021
    
**2.  Versión Alpha del videojuego** → 31 de octubre de 2021
    
**3.  Versión Beta** → 21 de noviembre de 2021
    
**4.  Pruebas Beta** → 26 de noviembre de 2021
    
**5.  Versión Gold Master**→ 12 de diciembre de 2021
    
 ## 3.3 Costes asociados
    
Al empezar sin ningún tipo de presupuesto no hay ningún coste monetario. Sin embargo, sí existe un coste temporal en el que los desarrolladores tendrán que trabajar en el proyecto.

# 4. Mecánicas de Juego y Elemento de Juego

En este apartado se profundizará en las diferentes mecánicas que componen a *Tales of the Dumbgeon* ahondando en los diversos fundamentos de su jugabilidad y explicando el rango de acciones de los jugadores.

## 4.1 Jugabilidad

*Tales of the Dumbgeon* es un juego de género roguelike con recolección de ítems en forma de cartas, combates de acción y exploración de un escenario generado aleatoriamente. El jugador deberá tratar de llegar hasta el final de la mazmorra para completar el juego pudiendo morir en el proceso y en consecuencia teniendo que empezar desde el principio, pudiendo probar una nueva combinación de cartas que le suma valor a la rejugabilidad.

El esquema jugable de *Tales of the Dumbgeon* se basa en la recolección de las cartas del mago Jojomamalo. Estas cartas funcionan como el corazón de la jugabilidad pudiendo actuar como equipamiento para el personaje, habilidades extra para la aventura o maldiciones que dificulten el transcurso de la partida.

- **Cartas**: Recolección de cartas que generan habilidades y equipo

	Para poder hacerse con estos ítems el jugador deberá abrirse camino por la mazmorra, explorando distintas salas generadas de forma aleatoria y enfrentándose a diferentes 	enemigos utilizando esas mismas cartas, generando así un bucle de mejora constante mientras se avanza en el juego. 
	
	En las salas seguras, como ya se explicará en el apartado de **Generación aleatoria del mundo y sus mazmorras**, aparecerá de vez en cuando un *NPC* llamado “*El Cartero*”. 	Este *NPC* cumplirá dos funciones:
	
	- Tendrá unas cuantas cartas, de modo que puedas cambiar la carta de tu mano que quieras por una aleatoria de las que él tiene.
	- Tendrá un álbum en el que puedes guardar cartas que tienes en la mano para recogerlas más adelante, cuando vuelvas a encontrarte con él. Las cartas del álbum se eliminarán si mueres. No estarán disponibles cuando vuelvas a entrar a la *Dumbgeon*.
	
	A lo largo del juego se podrán encontrar los siguientes tipos de carta:
	
	- **Armas:** Se equipan para usarse en combate y para incrementar los stats del personaje tales como su daño, defensa y velocidad. Cada una de ellas posee un elemento que las caracteriza. (Ejemplo: *Espada de Fe*)
	
		**![](https://lh5.googleusercontent.com/sWVmQnqZqAyYRArILtS8Xian7OBj-S4egwgiykisGWYUR4BgAGOhJcECwhFblz8zZf8rwXfrlQb4I1hCceNcJsJmaaHEhiESVDwNJLE9PCS5Y6MTfAJBHkPaw0-4=s1600)**
	
	- **Armadura:** Se equipan para incrementar los stats del personaje tales como su daño, defensa y velocidad. Cada una de ellas posee un elemento que las caracteriza. (Ejemplo: *Ki-Mono*)
	
	![]()
	
	- **Hechizos:** Se equipa como habilidad para usarse en combate. (Ejemplo: *Saeta de fuego*)
	
		**![](https://lh3.googleusercontent.com/hjMRBRkWB1QpDalhjD8k46QlYyWIlypId38colLCghIEyHAD_b1gPMTYuEV3oW7gug23s-TAT0XTPaQVG0RpneOUoDU2WFS-wpVmi0s8yIDbkpAFBMb8M35qVJ6C=s1600)**
	
	- **Maldiciones:** Efectos adversos sobre el personaje. Se aplican instantáneamente al ser recogidas. (Ejemplo: *Analfabetismo*)
	
		**![](https://lh4.googleusercontent.com/pts37zA4_zCKe23nFgI7zof7oEUKbSsffSVzGSAeuZpZQAQQu3JDJoKtChMyRDQLo8TZdp0Zn1ChO7fYncnh7ZwC_n6roLXZ9e5PsBI4V29UELU09kF-aM7R4cF8=s1600)**
	
	- **Bendiciones:** Cartas que guardan en la mano del jugador para que este pueda usarlas cuando desee. Al activarlas ofrecen un efecto positivo al jugador y se consumen. (Ejemplo: *Power Up*)

	
	![]()
	
	Cuando el jugador muera en las partidas, podrá  elegir una de las cartas que tenía para dejar de herencia al siguiente personaje y empezar desde el inicio con ella, creando una herencia de equipo, hechizos y maldiciones que puedan ser útiles en las partidas posteriores.
	
	**Calidad de Carta**
	
	Por otro lado, cada carta puede enmarcarse en tipo de calidad:
		- **Normal:** La carta se encuentra en un estado estándar, así como sus atributos.
		- **Especial:** La carta está mejorada lo que hace que un atributo de la carta se duplique.
		- **Legendaria:** La carta está mejorada lo que hace que un atributo de la carta se cuadruplique.

	Para mejorar la calidad de las cartas es necesario *Cuartos de Carta*, una moneda interna del juego. Esta se recoge de las recompensas que sueltan los enemigos al morir y se puede utilizar en la tienda del *Cuervillo*. El *NPC* pedirá un número determinado de *Cuartos de Carta* para poder subir de calidad la carta que quiera el jugador.
	
	**Elementos**
	
	Tanto las cartas como los enemigos pueden tener asignado uno o varios elementos, en este caso nos centraremos en los elementos y su utilidad como mecánica. Los elementos afectan al tipo de daño que produce un arma/hechizo en el objetivo y en las armaduras proporcionan una defensa extra contra ataques de su mismo tipo elemental. Esto mismo se aplica en los enemigos, donde su elemento de ataque y de defensa sería el mismo.
	
	Los elementos que aparecen en el juego son: *Brisa*, *Copo*, *Guijarro*, *Brasa* y *Caos*. La eficacia que producen estos elementos contra otros viene determinado por el diagrama que aparece abajo. Con esto podemos ver:
	
	- Los ataques de *Copo* son muy eficaces contra enemigos de *Brasa*
	- Los ataques de *Brasa* son muy eficaces contra enemigos de *Brisa*
	- Los ataques de *Brisa* son muy eficaces contra enemigos de *Guijarro*
	- Los ataques de *Guijarro* son muy eficaces contra enemigos de *Caos*
	- Los ataques de *Caos* son muy eficaces contra enemigos de *Copo*
	- Los ataques de un elemento son poco eficaces contra si mismos

		**![](https://lh3.googleusercontent.com/CAck00h4s0s1hczdFRtKAh4eYjEgT0EaYl-RSGphGWgY2Knzd1hqOgnyy4lei157WxVPLge2F615DF8wtdreYFj3ohlKyzGJ4f2AHHhvrd1JPdb6GRm3jwE8um-o=s1600)**
	
- **Combate:** Combate rápido cuerpo a cuerpo con habilidades y hechizos

	El combate será de acción y en tiempo real con perspectiva isométrica. El jugador tendrá que posicionarse dentro de las salas donde crea más conveniente, medir los tiempos en los que atacar o tratar de esquivar los envites enemigos, aprovechar al máximo las habilidades de las que dispone.

	En la mano de combate el jugador solo puede tener cinco cartas. Si se consigue una nueva se tendrá que decidir si quedársela, eliminando una que tengas o dejarla donde la has visto y perderla.
	
	En la sección de equipamiento solo se puede llevar 3 piezas de armadura (cabeza, pecho y piernas).
	
	**![](https://lh3.googleusercontent.com/Kg1fRphJTC7OHa5SvYycS9TEhbsGbIho9LtMNxhzmJXcnT746xjuwMI0pPx2s8Wty657VhGVsjUH76HuSyhYSK_eTWrlcbU39dXCLvkGmAbkLeOI5Dm54XNjNRoQ=s1600)**
	
	Por otro lado, existe una sección de maldiciones donde se irán acumulando las que el jugador vaya encontrando a lo largo de la partida.
	
	**![](https://lh6.googleusercontent.com/YTEBj8NzKpaKdmCAER1L0uMj74SFVkA1SnqhKMZNgvxDWCkUbygQBhw51wayRN0T5Eq25zZjStS3Q2pWupFamprSjSexkzj2xFsjYhRdIu9qTMiN-LAjp7TIFkVK=s1600)**
	
	Por último, en la sección de habilidades se pueden poner 1 arma (espada, arco, cetro...) y 1 hechizo (Poder limitado, Frío burgalés, Saeta de fuego).
	
	**![](https://lh4.googleusercontent.com/_JLdULJHGDhMulkUHS0pPVsnzzDjysrPf8Bb9FVyzJlJGIHFFfNlGbKJlzOjYiRqH4S2BcBUaSgNDz35iG0st0NfW_8hxxd8CmRUpWJPjPJJnKCvResdWv642AEY=s1600)**

	**![](https://lh3.googleusercontent.com/HKDF40feN7hGjehy8COylL2AOYPxZbFQ7HRwhh-XHbbei7wzulwqk1sD-E6PW-Uq02OgUNy0mTFvv45P3-_u20qxzxxWmg5x1kxYyvAC9GkYwZKbn3mPwJ7qwoWu=s1600)**
	
	El movimiento del personaje se realizará con las teclas WASD, cambiando además la dirección a la que mira. Usando el click izquierdo usará el hechizo y el click derecho podrá usar el arma que tenga equipado. Mediante el botón el teclado Q, se abrirá el menú de pausa de juego en el que se visualizarán todas las secciones así como las cartas completamente que tienes en la mano y los *Cuartos de Carta* que posees hasta el momento.
	
	En cuanto a los demás elementos del combate, el personaje tendrá vida que se ira reduciendo con los golpes enemigos. La vida se representará con una barra en el que se muestre la vida actual del personaje. Además se tendrá que representar la cantidad de armadura que lleve la cual reducirá el daño hecho por los enemigos y depende del número y de cuales sean las piezas de armadura que lleve puesta el personaje.
	
	**Enemigos**
	
	Los enemigos de la mazmorra son aleatorios a lo largo de la diferentes zonas, es decir, un enemigo no solo se encontrará en una zona si no en cualquiera de forma aleatoria. Al ser eliminados dropean los siguientes elementos:
	
	- Carta de cualquier tipo asociado al enemigo en cuestión. Por ejemplo, el abuesqueleto dropea  la carta “*Bastón de Yayo*”.

	- Carta “*La Carta*”: una carta de bendición que hace referencia a las cartas de los restaurantes la cual regenera vida al usuario y su uso es instantáneo.

	- Carta “*La Carta*”: una maldición que hace referencia a las cartas de los restaurantes la cual regenera vida al usuario y su uso es instantáneo.
  
	- *Cuarto de carta* que servirá para subir la calidad de la carta con *El Cuervillo*.
	
- **Mazmorra:** Generación aleatoria del mundo y sus mazmorras

	Los escenarios están organizados en pisos de la mazmorra los cuales vamos a llamar zonas. En cada partida el jugador tendrá que decidir entre dos caminos diferentes después de superar la 1º zona, lo que significa que llegará a dos zonas diferentes en el mismo 2º nivel de la mazmorra. Después de superar al jefe de este 2º nivel llegarán a la misma 3º zona independientemente de la decisión que se haya tomado en el 1º nivel. Lo mismo ocurrirá en el 3º nivel de la mazmorra, el camino se disgregará en dos zonas diferentes en el mismo nivel.
	
	Se muestra gráficamente en la siguiente imagen:
	
	**![](https://lh3.googleusercontent.com/sXJx_3PfRcEyOyAOwzWIaSPBQD2eIlybWI1ArdG3_Sgqm6tYyu18F8ImOLFTxnavBJ3ag310XpQA9A_ZmrpoEq_OFz5VLy7zS1eNb0EMGX5HLnTBokbHY-gQJoPm=s1600)**
	
	Las salas se organizan en las salas estándar donde el jugador puede encontrar cofres, enemigos, personajes secundarios, etc; y las salas de jefe en donde el jugador tendrá que derrotar al jefe de esa zona. 
	
	Cuanto más se baje en los niveles, el número de salas a explorar hasta llegar a la sala del jefe aumentará y los enemigos que se encuentren estas, serán más fuertes otorgándoles más vida o daño. Como compensación las cartas que se encuentran en los niveles más bajos son más raras y poderosas.

	Cada vez que se supere una sala de jefe, el jugador llegará a una sala segura donde habrá una cierta probabilidad de encontrarse con “*El Cartero*” ya mencionado antes.

## 4.2 Controles y reglas de juego

- **Controles básicos:**
	- Desplazamiento: WASD 
	- Apuntar: el personaje realizará la acción hacia el lugar donde esté mirando el personaje.
	- Mano principal: Click izq
	- Mano secundaria: Click der
	- 'Q': Desplegar tu mano de cartas
	
- **Mano:**
	- Se dispone de un número limitado de slots para almacenar las cartas que se van recogiendo.
	- Desde la mano podemos equipar armas, armaduras y habilidades. Las Maldiciones se activan directamente cuando llegan a tu mano.
	- Una vez equipada una carta, NO puede volver a la mano.

- **Secciones del personaje:**
	- *Sección de Equipamiento:* Se equipan 3 cartas/objetos pertenecientes a los elementos casco, pecho y piernas.
	- *Sección de Maldiciones:* Las maldiciones se activan instantáneamente al recogerlas  y se equipan en esta sección.
	- *Sección de Habilidades:* Se equipan 2 habilidades, una de ellas es un arma y la otra un hechizo. El arma se utiliza con el click derecho del ratón y el hechizo se utiliza con el click izquierdo del ratón.
	
- **Cartas:**
	- Las cartas deben tener un nombre, una ilustración y una descripción. Además se darán, si es necesario, más especificaciones de los efectos de la carta hacia el personaje.

## 4.3 Niveles


En este apartado se detallan las diferentes zonas de la mazmorra, con su respectivo jefe, su contenido y contexto. Como se ha explicado anteriormente, la mazmorra dispondrá de diversos pisos los cuales se centran en un mismo tema. Debido a que *Jojomamalo* se cree el director que dirige la *Dumbgeon*, las zonas representan temáticas paródicas de géneros del cine.

En la primera fase solo se dispondrá de un nivel más la sala del jefe final para mostrar el funcionamiento del juego. Para las siguientes fases las zonas aumentan de número habiendo cuatro zonas principales más la última dedicada exclusivamente a *Jojomamalo*. Aquí se muestran estas zonas principales.

- **La Discocueva:** es en esencia una caverna espaciosa que ha sido remodelada para actuar como lugar de ocio. Cuenta con luces de colores, barras, mucha suciedad y música a todo volumen. En su interior se encuentra la sala de baile principal donde aparece el jefe de esta zona, el *Alma de la Fiesta*:

	- **El Alma de la Fiesta (Comedia):** un fantasma/espectro de lo más juerguista que nunca se separa de su vaso de kalimotxo y se dedica a bailar en su pista de baile para atacar a todo aquel que quiera pasar por ella. ¿Por qué hace esto? Porque le mola bailar y porque así aquellos a quienes mate se convertirán en fantasmas de su guateque por toda la eternidad, incapaces de hacer otra cosa que bailar y volver a bailar.

		El suelo de la sala está llena de baldosas de baile, el *Alma de la Fiesta* ataca lanzando “hechizos” que se mueven en las baldosas, según el color del que estén iluminadas tienen un efecto u otro. Además cuenta con un movimiento que consiste en que unos altavoces que tiene a sus espaldas hacen mucho ruido y le echan para atrás.
	
- **Elmo Street:** cubierta de niebla, *Elmo Street* es una zona residencial en la que habitan gran variedad de monstruos de la *Dumbgeon*. A pesar de ser de noche las calles están infestadas de enemigos que tratarán de evitar que el jugador llegue hasta la rotonda de la calle donde se encuentra *La Adolescente de la Curva*: 

	- **La Adolescente de la Curva (Terror):** literalmente solo puede moverse girando, no puede ir en línea recta y eso ha provocado que sea una rechazada y que nunca haya hecho amigos. Cualquiera diría que para pasar por ella solo tendrías que hacerte su amiga, pero debido a su pasado y a que está en su fase rebelde lo más probable es que vaya derechita a matarte. Bueno, derechita lo que se dice derechita no, pero tú ya me entiendes.

		El combate empezará con la *Adolescente de la Curva* intentando llegar a por el *Stadtnarr*, yendo en curvas y siendo muy patética. Al recibir un poco de daño se enfada y llama a su moto infernal con la que haría más o menos lo mismo, pero con patrones de curvas diversos, mucha velocidad y dejando un pequeño rastro de llamas que quema al jugador.
	
- **La Zona Media:** un lugar donde el mundo medieval y el moderno se unen en una extraña mezcla en la que habitan todo tipos de criaturas fantásticas pero con elementos del mundo actual como trajes o teléfonos móviles. Y el que se encarga de dirigir todo este lugar es *El Presidente Demonio*:

	- **El Presidente Demonio (Fantasía)**: un demonio que se presentó al cargo con la esperanza de hacer de su zona de la *Dumbgeon* un lugar mejor, legalizando los saqueos, impulsando el estudio de magias negras y armas mágicas de destrucción masiva… Pero al final cambiar el mundo es mucho más difícil de lo que parece, incluso en su posición no lo ha logrado, por ello está deseando que termine su mandato para poder olvidarse de este fracaso en su vida, pero parece que la fecha no llega nunca… 

		*El Presidente Demonio* es un demonio alto y fuerte, que viste una elegante chaqueta, con su camisa blanca y una corbata dignas de su puesto. Cuando llega la hora del combate, se quita su corbata que sirve como espada y con la que atacará de cerca. Según va perdiendo vida puede sacar decretos que prohíban el uso de algunas de las cartas del jugador. Además, puede volver momentáneamente dorada su corbata permitiéndole usar el *Sablazo de Hacienda*, que le hace daño al jugador y se lleva la mitad de esa vida para recuperarse. Como ataques a distancia puede agarrar funcionarios y lanzarlos al jugador, si le impactan el funcionario iniciará un proceso burocrático como renovar el DNI al *Stadtnarr* o algo así, lo cuál drena su salud un poco durante ese tiempo y le impide moverse, de manera que *El Presidente Demonio* puede acercarse a atacar.
	
- **Little France:** lugar que empieza recordando a París, lleno de flores y dónde se respira el amor y poco a poco va degenerando en un oscuro lugar lleno de fotos de la familia del personaje, un lugar que se conoce como el *Templo Stadtnarr* cuya dueña es *La Loca del Moño*:

	- **La Loca del Moño (Romance):** Está perdidamente enamorada de El *Stadtnarr*, da igual que sea viejo, joven o lo que sea. Está realmente obsesionada contigo que sabe perfectamente tu edad, tu altura, tu peso, tu signo zodiacal, tu DNI, tu contraseña de *Tuenti*, las veces que te duchas a la semana, lo que comiste ayer, el color de tu babi en infantil y por último pero no menos importante, las cartas ancestrales que llevas. El lugar donde habita es un templo dedicado a ti, lleno de fotitos tuyas y velas de colores. Te ha hecho fotos, bueno, a toda tu familia durante milenos y llenan las paredes del templo. Además tiene una estatua hecha de los huesos de tus antepasados. Hará lo que sea para que te quedes con ella. 

		*La Loca del Moño* sabe todo sobre el personaje, por ello tiene la capacidad de copiar las habilidades que portas o que has portado en los dos últimos combates. Por ello es como si lucharas contra ti mismo, solo que con más vida y más loca, mucho más loca.

- **Mostazar:** zona volcánica que en lugar de magma está conformada por mostaza picante. Para evitar tener que pisar tanto condimentado están habilitadas varias estructuras y pasarelas metálicas que conducen a la zona principal de extracción de mostaza, donde aguarda *Stradt Bader*:

	- **Stradt Bader(Ciencia Ficción):** un tipo enmascarado, con un traje que mezcla el de un astronauta y un samurái negro. Porta un *Estoque de Protones* de color naranja y es de una complexión similar al *Stadtnarr*. El tipo asegura ser el padre del *Stadtnarr* con insistencia, y le pide al jugador que le de los datos de su cuenta bancaria para poder darle una herencia que les ha dejado una tía abuela que tienen en El Tíbet. Pero evidentemente, es mentira, el tipo se llama Tadeo y no tiene nada que ver contigo en realidad, pero hará todo lo posible por quedarse con tu pasta y tus cartas ya sea mediante sus estafas o teniendo que recurrir a la Fuerza. 

	*Stradt Bader* puede atacar usando su *Estoque de Protones* que dura algo más que los normales, cuando se descarga corre a la pared principal para enchufarla y que se recargue. Mientras tanto, saca un imán típico de dibujo animado y lo usa para lanzar objetos metálicos al jugador.


## 4.4 Cartas ancestrales

Todas las cartas ancestrales se encuentran en el [documento de diseño de cartas](https://docs.google.com/spreadsheets/d/1_EQh6-Omko_iLok0002eK7mrBMM10u9T01P8n-8xUPw/edit?usp=sharing).

## 4.5 Planificación del modelo de juego para móvil
Para poder adaptar *Tales of the Dumbgeon* a dispositivos móviles se han establecido diferentes rutas de trabajo, que tratan de llevar la experiencia disponible en ordenadores a *smartphones* de diferente maneras.
Tratando siempre de que esta versión sea lo más fiel posible al juego original, pero sin descartar la posibilidad de tener que realizar recortes en varios apartados. Estos planes, ordenados por su prioridad, son:

-   **Plan A:** Cuando el juego se ejecute en un dispositivo móvil aparecerá un joystick y dos botones que emulen el funcionamiento de las teclas WASD y del click izquierdo y derecho.  
    - **Plan A.2:** Modificar el tamaño de la cámara si los botones no ocupan demasiado en la pantalla.  
    
    - **Plan A.3:** Establecer un *padding* en negro alrededor del juego que sirva como área para establecer los botones si el resultado no es convincente.
    
-   **Plan B:** *Autorun*, es decir, el juego se ejecutará similarmente en móvil y PC, pero en la versión móvil el combate se hará automáticamente, el jugador todavía podrá elegir a qué salas moverse y que cartas usar en cada momento.      

	-   **Plan B.2:** Introducir una mecánica sencilla de combate, como hacer click si el juego resulta demasiado aburrido.   

-   **Plan C:** Si todos los planes anteriores fallan u otorgan resultados no satisfactorios realizar una aplicación alternativa en el móvil que sirva de apoyo para el juego en pc, permitiendo abrir la biblioteca, hablar con personajes, modificar mazos e ideas similares sin que se pueda jugar realmente al juego.
    

  
Actualmente el desarrollo seguido para la implementación de *Tales of the Dumbgeon* en dispositivos móviles se corresponde con el **Plan A.3**.

# 5. Trasfondo
## 5.1 Descripción detallada de la historia  y la trama


Hace mucho mucho tiempo, en una dimensión muy lejana un joven mago llamado *Jojomamalo* descubrió el poder de las Cartas, unos misteriosos artefactos que regulan todo aquello que existe en el universo: las estrellas, los elementos, los seres vivos, los fines de semana… Con este poder el mago fue capaz de crear a su antojo como si fuera un Dios, pero algo le frenaba, su falta de originalidad. Por ello, dedicó todos sus esfuerzos en la creación de una carta que le permitiera moverse por otros universos en lo que se conoce como el *Mazoverso*.

En sus viajes, *Jojomamalo* pudo conocer una gran variedad de culturas, miles de ideas, millones de mundos. Con toda esta información, todas estas historias de las que se había enamorado, decidió crear la suya propia. Creó un lugar que pudiera albergar todas sus creaciones, la *Dumbgeon*, y allí con el poder de las Cartas empezó a crear a todo tipo de criaturas para que poblaran el lugar. Seres de toda índole inspirados, los envidiosos dirían que plagiados, de las historias que el mago había descubierto.

Así pues fueron pasando los siglos, *Jojomamalo* seguía creando y divirtiéndose viendo cómo actuaban sus locas criaturas. Pero había una, una que no estaba conforme con aquello. Un ser de aspecto idéntico al humano pero dotado de toda clase de defectos, un pobre alma tonta, torpe y surrealista. Un pobre ser conocido como *El Tonto del Pueblo*, el *Stadtnarr*, que solo servía como bufón, alguien del que *Jojomamalo* y el resto de criaturas pudieran reírse con sus desgracias. Hasta que se hartó.

Usando la carta especial de *Jojomamalo* abrió un portal a una dimensión particular, una en la que pudiera comenzar desde cero y huir para siempre de la *Dumbgeon*. El *Stadtnarr* se ocultó en una pequeña villa llamada *Pueblo Boñiga*, donde creó una familia y disfrutó de su nueva libertad lejos de las burlas y las bromas. Pero *Jojomamalo* no lo toleró.

Cuando se enteró de que su marioneta del humor se había marchado montó en cólera, como un niño al que le quitan sus juguetes, por lo que recorrió todo el *Mazoverso* hasta encontrarse con los descendientes del *Stadtnarr* en *Pueblo Boñiga*. Sin más dilaciones, envió una horda de monstruos de la *Dumbgeon* a recuperar a los bufones, pero sin éxito. No obstante, los paletos de *Pueblo Boñiga* se dieron cuenta al décimo octavo ataque que los monstruos tenían una fijación particular por los *Stadtnarr* y que no los herían tanto como al resto.

Por eso mismo acordaron en secreto enviar a uno de ellos a la *Dumbgeon*, haciéndolo pasar como una votación popular, para que disuadiera a los monstruos de atacar el pueblo una temporada. El plan salió a la perfección, pasó mucho tiempo hasta que *Pueblo Boñiga* recibiera otra incursión. Por ello, cada 69 años se envía a un nuevo *Stadtnarr* a la *Dumbgeon*.

Y así es como comienza esta historia, con un pequeño aldeano que se ve obligado a entrar en un lugar aterrador y desconocido para él, ignorante del legado de su familia puesto que el primero de ellos nunca se le ocurrió comentarlo, y con la misión que todos aquellos que le precedieron no lograron cumplir. Adentrarse en la *Dumbgeon*, sobrevivir a todo monstruo que hubiera dentro, llegar hasta el final y derrotar a su dueño, el mago *Jojomamalo* y así convertirse en el *Héroe del Pueblo*.

Hace mucho mucho tiempo, en una dimensión muy lejana un joven mago llamado *Jojomamalo* descubrió el poder de las Cartas, unos misteriosos artefactos que regulan todo aquello que existe en el universo: las estrellas, los elementos, los seres vivos, los fines de semana… Con este poder el mago fue capaz de crear a su antojo como si fuera un Dios, pero algo le frenaba, su falta de originalidad. Por ello, dedicó todos sus esfuerzos en la creación de una carta que le permitiera moverse por otros universos en lo que se conoce como el Mazoverso.

En sus viajes, Jojomamalo pudo conocer una gran variedad de culturas, miles de ideas, millones de mundos. Con toda esta información, todas estas historias de las que se había enamorado, decidió crear la suya propia. Creó un lugar que pudiera albergar todas sus creaciones, la Dumbgeon, y allí con el poder de las Cartas empezó a crear a todo tipo de criaturas para que poblaran el lugar. Seres de toda índole inspirados, los envidiosos dirían que plagiados, de las historias que el mago había descubierto.

Así pues fueron pasando los siglos, Jojomamalo seguía creando y divirtiéndose viendo cómo actuaban sus locas criaturas. Pero había una, una que no estaba conforme con aquello. Un ser de aspecto idéntico al humano pero dotado de toda clase de defectos, un pobre alma tonta, torpe y surrealista. Un pobre ser conocido como El Tonto del Pueblo, el Stadtnarr, que solo servía como bufón, alguien del que Jojomamalo y el resto de criaturas pudieran reírse con sus desgracias. Hasta que se hartó.

Usando la carta especial de Jojomamalo abrió un portal a una dimensión particular, una en la que pudiera comenzar desde cero y huir para siempre de la Dumbgeon. El Stradtnarr se ocultó en una pequeña villa llamada Pueblo Boñiga, donde creó una familia y disfrutó de su nueva libertad lejos de las burlas y las bromas. Pero Jojomamalo no lo toleró.

Cuando se enteró de que su marioneta del humor se había marchado montó en cólera, como un niño al que le quitan sus juguetes, por lo que recorrió todo el Mazoverso hasta encontrarse con los descendientes del Stadtnarr en Pueblo Boñiga. Sin más dilaciones, envió una horda de monstruos de la Dumbgeon a recuperar a los bufones, pero sin éxito. No obstante, los paletos de Pueblo Boñiga se dieron cuenta al décimo octavo ataque que los monstruos tenían una fijación particular por los Stadtnarr y que no los herían tanto como al resto.

Por eso mismo acordaron en secreto enviar a uno de ellos a la Dumbgeon, haciéndolo pasar como una votación popular, para que disuadiera a los monstruos de atacar el pueblo una temporada. El plan salió a la perfección, pasó mucho tiempo hasta que Pueblo Boñiga recibiera otra incursión. Por ello, cada 43,5 años periódico se envía a un nuevo Stadtnarr a la Dumbgeon.

Y así es como comienza esta historia, con un pequeño aldeano que se ve obligado a entrar en un lugar aterrador y desconocido para él, ignorante del legado de su familia puesto que el primero de ellos nunca se le ocurrió comentarlo, y con la misión que todos aquellos que le precedieron no lograron cumplir. Adentrarse en la Dumbgeon, sobrevivir a todo monstruo que hubiera dentro, llegar hasta el final y derrotar a su dueño, el mago Jojomamalo y así convertirse en el Héroe del Pueblo.

## 5.2 Personajes 

En este apartado se presentarán todos los personajes relevantes de la trama del videojuego:

-   **El Stadtnarr:**

	-   Descripción: Los *Stadtnarr* siempre han sido los tontos del pueblo, los parias, los marginados y los excluidos de Pueblo Boñiga. Por ello, cualquier situación con la que puedan deshacerse de ellos es buena y la *Dumbgeon* es la mejor opción.
    

		El *Stadtnarr*, ya que decir su nombre completo sería imposible, es el personaje controlado por el jugador. Cada vez que muere, un nuevo miembro de la familia *Stadtnarr* es mandado a la mazmorra a derrotar a *Jojomamalo*.

		El *Stadtnarr* no tiene ninguna virtud en especial, es un simple chico/a que ha vivido siempre en *Pueblo Boñiga* y no ha podido ir nunca a la escuela. Su sueño es poder demostrar que su familia no es tonta y que pueden valerse por sí mismos aunque siempre les sale rana.


**![](https://lh5.googleusercontent.com/PSIcIteJVgadtVTyMrjo8qdxZoMfWeRjK2LKGmfA9ULzD2gmoEUxcsHV75qBi86OftO84_UTi8BsHbqniSsZl0ap38EEVWFn5qi1S_zp5j-fiRl9c8O-75J9rf9G=s1600)**
**![](https://lh3.googleusercontent.com/q-h3PrYDNr8qV9a0p9Bd5GnKvXKsqv09wt7Akqlw1NXn_uuvSlC-qeC60wtyr5WoGcFO5gOPagwVEpkaNiN_HpC_lu9MfAAmvJSWUYeZDS8b6A-c_sYaykwwcQDh=s1600)**
-   **El Mago Jojomamalo:** 

	-   Descripción: *El Mago Jojomamalo* es el villano principal de Tales of the *Dumbgeon*. Su verdadera historia es la siguiente: *Jojomamalo* es un viajero de dimensiones el cual descubrió y aprendió el secreto de las Cartas. Con ese poder en sus manos comenzó a crear su paraíso perfecto plagiando obras de otras dimensiones y quedándose con lo que más le gustaba.
    
		De esta forma y con el eterno tiempo que tenía, construyó la *Dumbgeon* y con ella, todos los seres que deseaba, entre ellos al *Stadtnarr*, un simple bufón, un torpe y mal afortunado ser del que poder reírse para la eternidad.

		Sin embargo, El *Stadtnarr* después de siglos de burlas, bromas pesadas, mofa y pitorreo, consiguió abandonar a la *Dumbgeon* cayendo en una dimensión de fantasía medieval y se escondió en el pueblo más analfabeto que existía para pasar desapercibido. Jojomamalo no podía resistir la impotencia de haber perdido a su principal fuente de diversión.

		Por ello, viajó entre dimensiones buscando el rastro de mala suerte del *Stadtnarr* llegando a *Pueblo Boñiga*, pero como el tiempo pasa de forma diferente en cada plano, en ese pueblo ya habían pasado siglos desde que El *Stadtnarr* llegó, habiendo conseguido formar una familia.

		Desde entonces, la *Dumbgeon* se asienta cerca de *Pueblo Boñiga*, mandando oleadas periódicas de monstruos con la intención de recuperar a los *Stadtnarr* y que así *Jojomamalo* pueda seguir riéndose de ellos.


**![](https://lh5.googleusercontent.com/7S3MuuG3ZevyGHt2X8DXLq8eT4yTLCF-s6dzeO6xQyB26GutVcqC-bMuJePeRymR5prVAKRUK0lsvJ85a5jVf-HWkqPqlXdVmib7CkYkA84yasTZdgw3vGm5M3mA=s1600)**
-   **Francis “El Sabio de los Barriles:**
	- Descripción: *Francis* en pocas palabras es un viejo borracho que ha vivido siempre en *Pueblo Boñiga* No ha salido de allí jamás y no lo hará ya que nadie le quiere llevar en su carro. Se pasa el día en la taberna del pueblo contando historias y batallitas de viejo, aunque ninguna sea cierta. Perdió su ropa hace ya mucho, en alguno de los asedios de los monstruos, por ello ahora viste con barriles. Dice que es lo que se lleva ahora y que él va a la onda. Además, siempre va sumamente borracho y los demás lugareños le apodan “El Sabio de los Barriles*" para burlarse de él.
	
		**![](https://lh6.googleusercontent.com/ZxMyjLUoEGz5JXS_A9YXH7GKkc0CIfJHzG57fMsNDfbv_OBixBdvf3R00DcdEGWphJmuM6Uvn_uDjCdOp379-XQVf7TPbzQzdMPMRmrvUDRRQXchvVVmXG51HmVy=s1600)**
-   **El Cartero**:
	- Descripción: Es una más de las criaturas que se quedaron atrapadas en la *Dumbgeon*. Sin embargo, *El Cartero* no entró para acosar a los aventureros que entraran después de él, sino que busca a su “*Amor*” perdido. Su *Amor* fue secuestrado por *Jojomamalo* y como hizo con muchos más seres, los atrapó dentro de las cartas utilizando su magia de escritura. Colecciona las cartas ancestrales de la *Dumbgeon* esperando que, algún día, pueda encontrar la carta en la que está encerrada su *Amor*.
	
		**![](https://lh4.googleusercontent.com/qfZAGcUN45ulTny__cgNGVxbD1s_ODN0g7XUuoNYZnd3wq6Zrafiww8ldqstW0Uv_rZkJlTbp0tTbKwN305jCayYNdbDNhHnX58XCHAU6M_h8O96dy5OW6agMJTW=s1600)**
-   **El Cuervillo**:
	-   Descripción: “Calderero, Hojalatero. Afilador. Zahorí. Armadura de corcho. Tabaco. Pañuelos de seda traídos del *Pueblo Boñiga*. Papel de culo. Dulces y gominolas. Fino encaje y suaves plumas. ¡Vengan, señoras! ¡Vengan, muchachas! *El Cuervillo* solo se quedará un día en esta zona. ¡No esperen a que anochezca! Todo lo que necesites lo tiene *El Cuervillo*.”
 
		Este sagaz e intrépido cuervo ha vagado durante años la mazmorra y se sabe todos sus huecos y entresijos como la palma de la mano. Posee una gran colección de objetos que vende por un precio razonable, aunque a veces se le ve el plumero.

		**![](https://lh5.googleusercontent.com/U8FYk8k6t_P2XrXrjD2Wp4C38Wo-U3YtVx9XCFh69xAE7Wx1mUE7BVvwuwx1s9dhJPjynK58cr_qkw3hYbOU11u8FTi_9806tjl2HzxXzd6BzsNnBLNzI2KurYsJ=s1600)**

## 5.3 Entornos y lugares

-   **Pueblo Boñiga**:

	-   **Gremio de aventureros**: donde hay un tablón de desafíos que al cumplirse el siguiente *Stadtnarr* que mire el tablón podrá reclamar la carta recompensa y se añadirá esta a las cartas que pueden aparecer en la *Dumbgeon*.
    
	- **El Hogar del los Stadtnarr**:  un zulo en medio de Pueblo Boñiga el cual era una antigua biblioteca (actualmente en ruinas). Existen libros que se actualizan de forma automática guardando información esencial vista por los *Stadtnarr* en el interior de la *Dumbgeon*.

-   **La Dumbgeon**:
    
	-   **La Discocueva**: es en esencia una caverna espaciosa que ha sido remodelada para actuar como lugar de ocio. Cuenta con luces de colores, barras, mucha suciedad y música a todo volumen. En su interior se encuentra la sala de baile principal donde aparece el jefe de esta zona, el *Alma de la Fiesta*.

	-   **Elmo Street**: cubierta de niebla, *Elmo Street* es una zona residencial en la que habitan gran variedad de monstruos de la *Dumbgeon*. A pesar de ser de noche las calles están infestadas de enemigos que tratarán de evitar que el jugador llegue hasta la rotonda de la calle donde se encuentra *La Adolescente de la Curva*.

	-   **La Zona Media**:  un lugar donde el mundo medieval y el moderno se unen en una extraña mezcla en la que habitan todo tipos de criaturas fantásticas pero con elementos del mundo actual como trajes o teléfonos móviles. Y el que se encarga de dirigir todo este lugar es *El Presidente Demonio*.

	-   **Little France**: lugar que empieza recordando a París, lleno de flores y dónde se respira el amor y poco a poco va degenerando en un oscuro lugar lleno de fotos de la familia del personaje, un lugar que se conoce como el *Templo Stadtnarr* cuya dueña es *La Loca del Moño*.
    
	-   **Mostazar**: zona volcánica que en lugar de magma está conformada por mostaza picante. Para evitar tener que pisar tanto condimentado están habilitadas varias estructuras y pasarelas metálicas que conducen a la zona principal de extracción de mostaza, donde aguarda *Stradt Bader*.

# 6. Arte
## 6.1 Estética general del juego



## 6.2 Apartado visual
En este apartado se ofrecen los assets creados originalmente por el equipo de desarrollo

- Enemigo Abuesqueleto

![](https://user-images.githubusercontent.com/72553373/138588708-aadeacae-704f-4838-9d9d-a42278a18751.png)

- Entrada a la Dumbgeon

![](https://user-images.githubusercontent.com/72553373/138588690-49a056b3-8e47-4caf-8f6e-592bf8478d66.png)

- Suelo de la Discocueva

![](https://cdn.discordapp.com/attachments/808761273884999771/901763700833288232/DISCOCUEVA-PistaDeBaile.png)

- Columna de la Dumbgeon

![](https://cdn.discordapp.com/attachments/808761273884999771/901763704150954005/MAZMORRA-Columna.png)

- Suelo de la Dumbegon

![](https://cdn.discordapp.com/attachments/808761273884999771/901763707871305728/MAZMORRA-Suelo.png)

- Armadura --> Sombrero Mexicano

![](https://cdn.discordapp.com/attachments/808761273884999771/901776879919464459/CARTAS.png)

- Bendición --> Power Up

![](https://cdn.discordapp.com/attachments/808761273884999771/901776873636372490/powerUP_carta.png)

- Hechizo --> Poder Limitado

![](https://user-images.githubusercontent.com/72553373/138589934-0599b7f5-40c8-40d6-8bfe-aa0357152724.png)

- Maldición --> Analfabetismo

![](https://user-images.githubusercontent.com/72553373/138589947-54eb4694-2725-4190-b4cb-94e1ed7b547f.png)






## 6.3 Música
## 6.4 Ambiente Sonoro

# 7. Interfaz
## 7.1 Diseños básicos de los menús
**Menu principal**
![](https://lh6.googleusercontent.com/VJDgo9R6Am4oiIVVqNORmBLLV__7oS6JxU-0fHdbjyTuhp-e6VzhG-g1WN1LA7cfoCsntWyonaaFVzrG1Na6eHkIShmRuyNVha_xBaqPKFg2AE_Glx4ojm_ACd0mtw=s1600)

**Menu de Pausa**
![](https://lh3.googleusercontent.com/VZFGt3eZW-g9TLr_M6_D0tc0I_VR8HLu88EHXlbYC6Y27X1LefO8QPb-DtswItoTrbnrrJve_5elhFt1xOR2cEN96Z4iHQDg9k-_Zq3ORrVt2jGu1Gas7FzjvPT1iA=s1600)




## 7.2 Diagrama de flujo
En la siguiente imagen se presenta el diagrama de flujo de *Tales of the Dumbgeon*.
![](https://lh5.googleusercontent.com/ymUnwaTm2K_hdbZeXV9oY50qOISufA2hPHBojfK6oE5_TGOsKbRkJhamWFjXBWrnPawDS5naEjk47cveE9VwxgZWl3iH3VXwaDlAk6Ryg-JhAYWmM2wmjK1IG8eq_Q=s1600)

 # 8. Hoja de ruta del desarrollo
    
 ## 8.1 Hito 1
    
## 8.2 Hito 2
    
## 8.3 Hito 3
    
## 8.4 Fecha de lanzamiento
