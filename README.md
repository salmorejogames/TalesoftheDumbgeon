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
	- Bendiciones


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
       
El videojuego seguirá un modelo *free to play*, en el que los jugadores no tendrán que pagar para jugar al título.

Se espera que gracias a la constante actividad en redes sociales y a la accesibilidad para jugar al juego se puedan conseguir una base de jugadores que generen ingresos.

Estos ingresos se generarán gracias a los anuncios ubicados en la página principal y desde un *Patreon* en el que los usuarios que apoyen monetariamente tendrán acceso a nuevos contenidos que se irán introduciendo al juego de forma periódica. Además, para que los jugadores sientan que les escuchamos y se sientan parte del proyecto pensamos ofrecerles la oportunidad de votar por una serie de contenidos para que elijan cuales quieren ver en el título a futuro.



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

## 3.4 Modelo de Lienzo

![image](https://user-images.githubusercontent.com/72553373/139840443-341361c7-5dc8-4c57-aa2e-7bb056e0a6e0.png)
![image](https://user-images.githubusercontent.com/72553373/139840520-ac595f80-4f0a-4ff1-ba72-139a66828402.png)
![image](https://user-images.githubusercontent.com/72553373/139840585-f4cca384-e5df-4e68-a476-6b5d357bf6c2.png)


# 4. Mecánicas de Juego y Elemento de Juego

En este apartado se profundizará en las diferentes mecánicas que componen a *Tales of the Dumbgeon* ahondando en los diversos fundamentos de su jugabilidad y explicando el rango de acciones de los jugadores.

## 4.1 Jugabilidad

*Tales of the Dumbgeon* es un juego de género roguelike con recolección de ítems en forma de cartas, combates de acción y exploración de un escenario generado proceduralmente. El jugador deberá tratar de llegar hasta el final de la mazmorra para completar el juego pudiendo morir en el proceso y en consecuencia teniendo que empezar desde el principio, pudiendo probar una nueva combinación de cartas que le suma valor a la rejugabilidad.

El esquema jugable de *Tales of the Dumbgeon* se basa en la recolección de las cartas del mago Jojomamalo. Estas cartas funcionan como el corazón de la jugabilidad pudiendo actuar como equipamiento para el personaje o habilidades extra para la aventura 

- **Cartas**: Recolección de cartas que generan habilidades y equipo

	Para poder hacerse con estos ítems el jugador deberá abrirse camino por la mazmorra, explorando distintas salas generadas de forma procedural y enfrentándose a diferentes enemigos utilizando esas mismas cartas, generando así un bucle de mejora constante mientras se avanza en el juego. 

	A lo largo del juego se podrán encontrar los siguientes tipos de carta:
	
	- **Carta Genérica:** Estas cartas son las que aparecen a lo largo de la mazmorra después de abrir los cofres y que se recogerán automáticamente cuando el jugador pase por encima. Esta se transformara en cualquiera de los tipos de cartas que se mencionan más adelante.

		![](https://cdn.discordapp.com/attachments/503507632418455564/917863262270423081/unknown.png)
	
	- **Armas:** Se equipan para usarse en combate y para incrementar los stats del personaje tales como su daño, armadura y velocidad. Cada una de ellas posee un elemento que las caracteriza. (Ejemplo: *Espada de Fe*).
	
		![](https://cdn.discordapp.com/attachments/503507632418455564/917863262941499412/unknown.png)
	
	- **Armadura:** Se equipan para incrementar los stats del personaje tales como su daño, defensa y velocidad. Cada una de ellas posee un elemento que las caracteriza. (Ejemplo: *Sayo de Saya*).
	
	![](https://cdn.discordapp.com/attachments/503507632418455564/912095416307302430/unknown.png)

	- **Hechizos:** Se equipa como habilidad para usarse en combate. (Ejemplo: *Saeta de fuego*).
	
	![](https://cdn.discordapp.com/attachments/503507632418455564/917863262593355846/unknown.png)
	
	
	
	- **Bendiciones:** Cartas que guardan en la mano del jugador para que este pueda usarlas cuando desee. Al activarlas ofrecen un efecto positivo al jugador y se consumen. (Ejemplo: *Power Up*).
	
	![](https://cdn.discordapp.com/attachments/503507632418455564/912096482130296872/unknown.png)

	
	Cuando el jugador muera en las partidas, una de las cartas que tenia equipadas se dejara de herencia al siguiente personaje y empezar desde el inicio con ella, creando una herencia de equipo y hechizo, que puedan ser útiles en las partidas posteriores.
	
	**Elementos**
	
	Tanto las cartas como los enemigos pueden tener asignado uno o varios elementos, en este caso nos centraremos en los elementos y su utilidad como mecánica. Los elementos afectan al tipo de daño que produce un arma/hechizo en el objetivo y en las armaduras proporcionan una defensa extra contra ataques de su mismo tipo elemental. Esto mismo se aplica en los enemigos, donde su elemento de ataque y de defensa sería el mismo.
	
	Los elementos que aparecen en el juego son: *Brisa*, *Copo*, *Guijarro*, *Brasa* y *Caos*. La eficacia que producen estos elementos contra otros viene determinado por el diagrama que aparece abajo. Con esto podemos ver:
	
	- Los ataques de *Copo* son muy eficaces contra enemigos de *Brasa*
	- Los ataques de *Brasa* son muy eficaces contra enemigos de *Brisa*
	- Los ataques de *Brisa* son muy eficaces contra enemigos de *Guijarro*
	- Los ataques de *Guijarro* son muy eficaces contra enemigos de *Caos*
	- Los ataques de *Caos* son muy eficaces contra enemigos de *Copo*
	- Los ataques de un elemento son poco eficaces contra si mismos

		![](https://cdn.discordapp.com/attachments/503507632418455564/917866036005601310/unknown.png)

		**![](https://lh3.googleusercontent.com/CAck00h4s0s1hczdFRtKAh4eYjEgT0EaYl-RSGphGWgY2Knzd1hqOgnyy4lei157WxVPLge2F615DF8wtdreYFj3ohlKyzGJ4f2AHHhvrd1JPdb6GRm3jwE8um-o=s1600)**
	
- **Combate:** Combate rápido cuerpo a cuerpo con habilidades y hechizos

	El combate será de acción y en tiempo real con perspectiva isométrica. El jugador tendrá que posicionarse dentro de las salas donde crea más conveniente, medir los tiempos en los que atacar o tratar de esquivar los envites enemigos, aprovechar al máximo las habilidades de las que dispone.

	En la mano de combate el jugador solo puede tener 4 cartas. Si se consigue una nueva se tendrá que decidir si quedársela, eliminando una que tengas o dejarla donde la has visto y perderla.
	
	En la sección de equipamiento solo se puede llevar 3 piezas de armadura (cabeza, pecho y piernas).
	![](https://lh3.googleusercontent.com/Kg1fRphJTC7OHa5SvYycS9TEhbsGbIho9LtMNxhzmJXcnT746xjuwMI0pPx2s8Wty657VhGVsjUH76HuSyhYSK_eTWrlcbU39dXCLvkGmAbkLeOI5Dm54XNjNRoQ=s1600)
	
	Por último, en la sección de habilidades se pueden poner 1 arma (espada, arco, cetro...) y 1 hechizo (Poder limitado, Frío burgalés, Saeta de fuego).	
	![](https://lh4.googleusercontent.com/_JLdULJHGDhMulkUHS0pPVsnzzDjysrPf8Bb9FVyzJlJGIHFFfNlGbKJlzOjYiRqH4S2BcBUaSgNDz35iG0st0NfW_8hxxd8CmRUpWJPjPJJnKCvResdWv642AEY=s1600)

	![](https://lh3.googleusercontent.com/HKDF40feN7hGjehy8COylL2AOYPxZbFQ7HRwhh-XHbbei7wzulwqk1sD-E6PW-Uq02OgUNy0mTFvv45P3-_u20qxzxxWmg5x1kxYyvAC9GkYwZKbn3mPwJ7qwoWu=s1600)
	
	El movimiento del personaje se realizará con las teclas WASD, cambiando además la dirección a la que mira. 

	Usando el click izquierdo usará el hechizo y el click derecho podrá usar el arma que tenga equipado. Mediante el botón el teclado Q, se abrirá el menú de pausa de juego en el que se visualizarán todas las secciones así como las cartas completamente que tienes en la mano.
	
	En cuanto a los demás elementos del combate, el personaje tendrá vida que se ira reduciendo con los golpes enemigos. La vida se representará con una barra en el que se muestre la vida actual del personaje.
	
	**Enemigos**
	
	Los enemigos de la mazmorra son procedimentales a lo largo de la diferentes zonas, es decir, un enemigo no solo se encontrará en una zona si no en cualquiera de forma aleatoria. Estos enemigos custodian cofres los cuales, dropean cuando son golpeados lo siguientes elementos::
	
	- Carta de armadura
	- Carta de arma
	- Carta de hechizo de cualquier elemento
	- Carta de Bendición
	
- **Mazmorra:** Generación aleatoria del mundo y sus mazmorras

	La mazmorra se construye de forma procedural a lo largo de la partida, por lo que al empezar una partida nueva, la forma del la mazmorra será diferente,  así como la disposición y numero de enemigos. Además en cada sala aparecerán cofres que dropearan diferentes cartas a las que salieron en la partida, añadiendo un gran fuerte de rejugabilidad al videojuego. 

	- Los enemigos aparecen de los nidos de monstruos. Estos nidos poseen una dificultad la cual mide el tipo y numero de enemigos que ese nido va a generar cuando el jugador entre en la sala. Cada uno de los enemigos tiene asociado una dificultad y el nido generara enemigos hasta llegar a la dificultad máxima.

		![](https://cdn.discordapp.com/attachments/503507632418455564/917870606802886666/unknown.png)

	Las salas se organizan en las salas estándar donde el jugador puede encontrar cofres, enemigos, personajes secundarios, etc; y la sala de jefe en donde el jugador tendrá que derrotar al jefe de la zona, El Mago Jojomamalo. 


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

### Enemigos generales

#### Abuesqueleto
Viejo, pero viejo viejo. El pobre se ha quedado en los huesos, pero aún sigue con energías para perserguirte e intentar zurrarte con su bastón.

Su patrón de ataque consiste en perseguir al jugador para propinarles golpes a melee con su bastón.
![](https://media.discordapp.net/attachments/503507632418455564/917871595333255168/unknown.png?width=1440&height=255)
#### Cerebro en un tarro
Es un cerebro y está en un tarro. Nada más. Oh, bueno, también dispara bolas de energía mental que pueden hacer que te duela tanto la cabeza que pierdas un par de años de vida.

Prefiere guardar las distancias y solo se moverá si el jugador se aleja demasiado, el resto del tiempo se dedica a atacar con proyectiles.
![](https://cdn.discordapp.com/attachments/503507632418455564/917874083784446072/cerebro_contento.png)
#### Caballero Banana
Nacido en el Reino Banana y atrapado en esta estúpida mazmorra, te embiste con su increíble velocidad para poder pelarte entero.

El Caballero Banana gira sobre si mismo para cargar una embestida, una vez ya ha cargado su ataque sale disparado directo al jugador para herirlo.
![](https://cdn.discordapp.com/attachments/503507632418455564/917873497047441478/banana_idle.png)
#### Pelusa del Ombligo
**![](https://lh6.googleusercontent.com/jF6ixA1xyvE7ErXIvzLF6u4tzoTbrEGcuzUBNqSBVc0mG8GYFg1y3nxh-NuWUeEUVtUPTd3MYi6pLqlHguREBYx0J6E2s0SZ9YuT5jc6_fgSunx233Qipdr_lii44bH2pS7DVCcJm9M5)
**
**![](https://lh3.googleusercontent.com/S92hNb9dZ2YxX6hEXasNQxGD11aj0C0F8T9kpOz8N8Zt7sdQms8kyacN3zgbVL8e9f2NI46mXvYTT3cM_8D8q2gcGZ9netyBQoS65fYjrxu_M0Q3KVs2CL2_4fCtX2DE2uGYJ0RxIWVK)**
### El Mago Jojomamalo

Jojomamalo comenzará la batalla en el lado contrario por el que entre el personaje principal. Es decir, si el jugador entra por la pared sureste, Jojomamalo estará en la pared noroeste. El combate contra Jojomamalo se divide en tres partes diferenciadas por el porcentaje de vida que tiene:

**Entre 100% y 70% de vida:**

El jugador no podrá golpear a Jojomamalo ya que este se teletransporta a una zona libre alrededor de la sala burlandose del jugador. Al tercer intento de golpe este si que será golpeado y aturdido durante 4 segundos en el que el jugador le molera a palos. En caso de que su vida esté fuera del rango comentado antes, pasará a la siguiente fase. En el caso contrario se seguirá este flujo hasta que se de la condición.

 
Mientras sucede este movimiento, Jojomamalo expulsará bolas de energía similar a un bullet hell. Las bolas de energía harán daño del elemento del que sea Jojomamalo en ese instante. Por ahora el daño estándar de la bola son 2 puntos, en caso de que su elemento sea el counter hará 4 puntos y si es del mismo 1. Estos disparos serán de la siguiente manera:


-  *En línea:* 5 bolas de energía que saldrán directas hacia el jugador formando un zig zag y no cambiarán su trayectoria.
    

	![](https://lh3.googleusercontent.com/cfSb0DB5_n8adjmZGe_wcCsj5y3jkQ2I1Y9XEWd3c_mM78mrxR914iyFwq_sjADXrnp49RRaNiMpLMMkpDjm2T5YDvjVxEp6FCPhcDC1B1O4kGocVu7vYRYXG_TnHAwHeMorN6UI)

  

-   *En arco*: 5 bolas de energía saldrán del centro de Jojomamalo para separarse formando un arco. Este disparo en concreto puede hacerlo hasta 3 veces seguidas.
    

	 ![](https://lh3.googleusercontent.com/pCbxk-1yjAeYw2eA_vEbiDmoCTgv01_uWNm4Upw9AjEu7zLkUOlysvAFt7oi3NmoEO0TZkBUcrXirvuPY73R4QfXdiIjVt9Y2EuyRkJ0ZFU4oPSqGD3CNhHlgDn0Sbe51TUNQb9E)
    

  

-   *En serpiente:* Comenzará una ristra de hasta 15 bolas que se dispara hacia delante mientras Jojomamalo se mueve de un lado al otro de la pared en la que se encuentra.
    
	![](https://lh4.googleusercontent.com/FIXFn7Sbek0ENjTd8zlpf9tCmYrXFfuQ6op7WfB53Yki00UOq7AkCBiLLcbDU-55_xcfsmTLN8CLLPvGppTYVA-WOBrqW2reFG1SuBGq9fgEWlvmNgGTn4hXJxbDfOjC-QglGn9t)

  

La decisión de utilizar un ataque u otro es tomada dependiendo de cuales han sido sus últimos dos ataques. Si los dos últimos ataques han sido el mismo (LL) , se elegirá al azar entre los otros dos ataques sobrantes a realizar (S ó A). En el caso de que los dos últimos ataques son diferentes habrá un 70% de probabilidad de que el próximo ataque sea uno de los dos que acaban de salir y un 30% de otro diferente, es decir:

Si LS → 60% para L ó S // 40% para A

Entre cada ataque Jojomamalo tendrá que recargar energía y tardará 6 segundos en volver a disparar.

Estas reglas del disparo se aplican en cualquier momento del combate a menos que se mencione lo contrario.

**Entre 69 y 40% de vida:**

Durante esta fase Jojomamalo podrá cambiar su elemento. Su elemento será escogido al azar en las primeras batallas contra el. Después de 3 batallas contra él, empezará la batalla con el elemento counter al elemento que más haya escogido el jugador para así dañar mucho más al jugador y que este tenga que escoger otra estrategia.

El cambio de elemento ocurrirá cuando, estando en esta fase, el jugador reste 10% de la vida de Jojomamalo con elemento principal de su arma y Jojomamalo cambiará a su elemento counter.

Jojomamalo añadirá un ataque más: las cartas trampa. Este ataque funciona de la siguiente manera: Jojomamalo detectará la posición del jugador y colocará en esa misma posición una zona de 9 “tiles” centrada en el personaje. 

Esta zona espera 2 segundos para crearse y avisar al jugador y después explotará del elemento en concreto que sea Jojomamalo, haciendo 4 puntos de daño de ese elemento al jugador. En caso de que Jojomamalo tenga elemento counter al jugador hará el doble de daño y si es el mismo la mitad.

  

![](https://lh4.googleusercontent.com/SiRyrJ3wpgOo8k3mRgfuD9EBWpEmMyye6D2k7_uzOda-PL9wQn5nYew6Bj5-WzFGnfBEEhXcBHUFIj8KGZ8XFmse1eglb0pjgsL2hkJt7504ueTUSfqW6EQY-OXvdry3ka2mlL4c)

La carta trampa podrá funcionar a la vez que las bolas de energía y sus tiempos son individuales.

Por otro lado, la mecánica del teletransporte funcionará de la misma manera solo que en vez de tener un contaje de dos teletransportes será solo de 1. Para añadir sorpresa al combate se implementará la mecánica de descarga.

Cuando el jugador vaya a golpear a Jojomamalo una segunda vez después del teletransporte este habrá comenzado, nada más teletransporte, a cargar energía. Tarda 5 segundos en explotar y mientras se carga el ataque, el jugador podrá golpear y Jojomamalo recibirá el daño. Sin embargo, ese daño no solo lo recibirá si no que lo irá acumulando como energía. Cuando termine el tiempo establecido explotará haciendo daño en área, si el jugador se encuentra a dos casillas o menos del Jojomamalo recibirá el daño del escudo de energía 10 puntos + el daño acumulado recibido por el jugador y que ha ido acumulando.

(Cuando el jugador vaya a golpear a Jojomamalo una segunda vez después del teletransporte, un símbolo de maldición saldrá sobre su cabeza haciendo que el jugador se coma el doble del daño que iba a recibir el Jojomamalo. El daño de elemento se transforma al que tiene Jojomamalo en ese momento por lo que sí es elemento counter del que tiene el jugador le hará el doble del daño. Por lo tanto en este ataque el jugador podrá recibir el cuádruple del daño que él iba a hacer. Debido a que es una mecánica muy especial, Jojomamalo solo podrá realizarla cada 40 segundos.)

**Entre 39 y 1% de vida:**

Durante esta fase Jojomamalo se da cuenta de que el jugador es un peligro y tendra que utilizar todo su poder. Para ello utiliza la última mecánica implementada: invocación de enemigos. Esta mecánica funciona de la siguiente manera:

Jojomamalo se aparta del combate en cuanto empieza esta fase a la pared más lejana del jugador. Tras esto, comenzará a hacer aparecer monstruos ya vistos en la mazmorra, entre ellos:

-   Abuesqueleto: Aparecerán cada 5 segundos uno de ellos y no podrá haber más de cuatro de ellos a la vez. Si el jugador elimina a uno de ellos y ya han pasado 5 segundos, aparecerá uno automáticamente.
    
-   Caballero de la Banana: Aparecerán cada 5 segundos uno de ellos y no podrá haber más de 3 de ellos a la vez. Si el jugador elimina a uno de ellos y ya han pasado 5 segundos, aparecerá automáticamente.
    
Las demás técnicas se seguirán aplicando en esta fase tanto las bolas de energía como las cartas trampas.


## 4.4 Cartas ancestrales

Todas las cartas ancestrales se encuentran en el [documento de diseño de cartas](https://docs.google.com/spreadsheets/d/1_EQh6-Omko_iLok0002eK7mrBMM10u9T01P8n-8xUPw/edit?usp=sharing).

## 4.5 Planificación del modelo de juego para móvil
Para poder adaptar *Tales of the Dumbgeon* a dispositivos móviles se han establecido diferentes rutas de trabajo, que tratan de llevar la experiencia disponible en ordenadores a *smartphones* de diferente maneras.
Tratando siempre de que esta versión sea lo más fiel posible al juego original, pero sin descartar la posibilidad de tener que realizar recortes en varios apartados. Estos planes, ordenados por su prioridad, son:

-   **Plan A:** Cuando el juego se ejecute en un dispositivo móvil aparecerá un joystick y dos botones que emulen el funcionamiento de las teclas WASD y del click izquierdo y derecho.  
    - **Plan A.2:** Modificar el tamaño de la cámara si los botones no ocupan demasiado en la pantalla.  
    
    - **Plan A.3:** Establecer un *padding* en negro alrededor del juego que sirva como área para establecer los botones si el resultado no es convincente.

  
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

		----- Patreon Ace up your sleeve -----

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
		
			----- ------------------------- -----

## 5.3 Entornos y lugares

**La Dumbgeon**: La disparatada morada de Jojomamalo con eternos pasillos y absurdos enemigos representan la prueba final de los Stadtnarr.
![](https://cdn.discordapp.com/attachments/503507632418455564/912105593106481172/unknown.png)

	----- Patreon Ace up your sleeve -----
	
-   **Pueblo Boñiga**:

	-   **Gremio de aventureros**: donde hay un tablón de desafíos que al cumplirse el siguiente *Stadtnarr* que mire el tablón podrá reclamar la carta recompensa y se añadirá esta a las cartas que pueden aparecer en la *Dumbgeon*.
    
	- **El Hogar del los Stadtnarr**:  un zulo en medio de Pueblo Boñiga el cual era una antigua biblioteca (actualmente en ruinas). Existen libros que se actualizan de forma automática guardando información esencial vista por los *Stadtnarr* en el interior de la *Dumbgeon*.

-   **La Dumbgeon**:
    
	-   **La Discocueva**: es en esencia una caverna espaciosa que ha sido remodelada para actuar como lugar de ocio. Cuenta con luces de colores, barras, mucha suciedad y música a todo volumen. En su interior se encuentra la sala de baile principal donde aparece el jefe de esta zona, el *Alma de la Fiesta*.

	-   **Elmo Street**: cubierta de niebla, *Elmo Street* es una zona residencial en la que habitan gran variedad de monstruos de la *Dumbgeon*. A pesar de ser de noche las calles están infestadas de enemigos que tratarán de evitar que el jugador llegue hasta la rotonda de la calle donde se encuentra *La Adolescente de la Curva*.

	-   **La Zona Media**:  un lugar donde el mundo medieval y el moderno se unen en una extraña mezcla en la que habitan todo tipos de criaturas fantásticas pero con elementos del mundo actual como trajes o teléfonos móviles. Y el que se encarga de dirigir todo este lugar es *El Presidente Demonio*.

	-   **Little France**: lugar que empieza recordando a París, lleno de flores y dónde se respira el amor y poco a poco va degenerando en un oscuro lugar lleno de fotos de la familia del personaje, un lugar que se conoce como el *Templo Stadtnarr* cuya dueña es *La Loca del Moño*.
    
	-   **Mostazar**: zona volcánica que en lugar de magma está conformada por mostaza picante. Para evitar tener que pisar tanto condimentado están habilitadas varias estructuras y pasarelas metálicas que conducen a la zona principal de extracción de mostaza, donde aguarda *Stradt Bader*.
	
				------ ------------------------- -----

# 6. Arte
## 6.1 Estética general del juego

Como se ha mencionado anteriormente el juego tendrá una vista isométrica y un estilo de dibujo que juega entre el *cartoon* americano y el *chibi* nipón. Además se ha inspirado fuertemente en la serie de animación: *"Hora de Aventuras"*. 

![image](https://user-images.githubusercontent.com/72553373/138601967-6c38dc81-12da-4d79-9b4a-bd80290cb64b.png)

Esta estética se ha elegido para dotar de personalidad al mundo y a sus personajes con una mezcla de corrientes algo atípica y que contribuyen en gran medida a construir la atmósfera desenfadada y cómica del título.

Además, esperamos que el uso de una estética más simple y menos detallista permita al equipo de arte agilizar su trabajo, encontrar una cohesión visual entre los diferente miembros e incluso dar la posibilidad de que miembros ajenos a este departamento puedan ayudar con tareas menores en caso de ser necesario.

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

Actualmente las piezas compuestas son: 
	 
 - [Tema de *Pueblo Boñiga*](https://github.com/salmorejogames/TalesoftheDumbgeon/blob/main/TalesOFDumbgeon/Assets/Music/PuebloBo%C3%B1iga.wav)
 - [Tema de la *Dumbgeon*](https://github.com/salmorejogames/TalesoftheDumbgeon/blob/main/TalesOFDumbgeon/Assets/Music/Walking%20in%20the%20Dumbgeon.wav)
 - [Tema de *Elmo Street*](https://github.com/salmorejogames/TalesoftheDumbgeon/blob/main/TalesOFDumbgeon/Assets/Music/ElmoStreet.wav)
 - [Tema de *Game Over*](https://github.com/salmorejogames/TalesoftheDumbgeon/blob/main/TalesOFDumbgeon/Assets/Music/FUNeral.wav)

## 6.4 Ambiente Sonoro

Cada piso de la mazmorra contará con su propia temática y por lo tanto con una composición musical diferente, que irá acompañada por efectos sonoros particulares que ayuden a la inmersión del jugador dentro del mundo del juego

# 7. Interfaz
## 7.1 Diseños básicos de los menús
**Pantalla inicial**
![](https://cdn.discordapp.com/attachments/503507632418455564/912102026266161203/unknown.png)
**Menu principal**![](https://cdn.discordapp.com/attachments/503507632418455564/912102128795922492/unknown.png)
**Tutorial**
![](https://cdn.discordapp.com/attachments/503507632418455564/912102230201602138/unknown.png)

**Menu de Ajustes**
![](https://cdn.discordapp.com/attachments/503507632418455564/912102321977167872/unknown.png)
**Pantalla de gameplay**
![](https://cdn.discordapp.com/attachments/503507632418455564/912102427577176085/unknown.png)
**Menu de pausa**
![](https://cdn.discordapp.com/attachments/503507632418455564/912102575107604500/unknown.png)
**Game Over**
![](https://cdn.discordapp.com/attachments/503507632418455564/912102748747616276/unknown.png)


## 7.2 Diagrama de flujo
En la siguiente imagen se presenta el diagrama de flujo de *Tales of the Dumbgeon*.
![](https://lh5.googleusercontent.com/ymUnwaTm2K_hdbZeXV9oY50qOISufA2hPHBojfK6oE5_TGOsKbRkJhamWFjXBWrnPawDS5naEjk47cveE9VwxgZWl3iH3VXwaDlAk6Ryg-JhAYWmM2wmjK1IG8eq_Q=s1600)

 # 8. Hoja de ruta del desarrollo
    
## Hito 1 - Versión Alpha

La fecha límite del hito 1 es el día 31 del mes de octubre del año 2021. En él se ha desarrollado el prototipo de Tales of the Dumbgeon hasta conseguir una versión Alpha apta para la continuación del proyecto. Para ello los diferentes departamentos del estudio han realizado las labores explicadas en los siguientes apartados:

-   **Diseño:**
    
	En el apartado de diseño se realizó, antes de cualquier otro elemento, un documento de diseño en el que se explicaban todas los componentes de diseño necesario para comenzar el trabajo y a futuro. Entre estos componentes se encuentran los siguientes:

	-   **Cartas:** las cartas son la base mecánica de *Tales of the Dumbgeon*. Como se ha explicado a lo largo de este documento, las cartas son el elemento que da habilidades, armas, armaduras, maldiciones y bendiciones al jugador. Para tener organizado los tipos, sus stats y efectos se ha realizado un documento excel que se actualiza con el tiempo cuando se generan más cartas nuevas. El enlace para llegar hasta él es el siguiente: [DocumentoCartas](https://docs.google.com/spreadsheets/d/1_EQh6-Omko_iLok0002eK7mrBMM10u9T01P8n-8xUPw/edit?usp=sharing).
    
	-   **Enemigos:** Estos son generados en la mazmorra y atacarán si descaro al jugador para hacer más difícil el viaje a lo largo de ésta. Se ha realizado una lista y a futuro se creará un documento excel similar al de las cartas para tener todos sus datos.
    
	-  **Zonas de la mazmorra:** Se han diseñado en concepto el aspecto y relación con la trama las zonas de la *Dumbgeon*. En el próximo hito se diseñará su estructura.
    
	-   **Jefes:** Se han diseñado los jefes de cada una de las zonas así como la forma del combate y en qué partes consiste aunque están sometidos a cambios futuros.
    
	-   **NPCs**: Se han generado personajes relevantes para la trama que sirvan como mecánicas en la mazmorra como *El Cartero* y *El Cuervillo*.
    

Por otro lado, se han producido algunas preguntas a responder por el departamento de diseño:

-   ¿Qué tipo de guardado se va realizar?
    
-   ¿Se realizará una cinemática inicial?
    

Por último, se ha realizado completamente el documento de diseño de juego y se irá actualizando con los diferentes hitos.

  

-  **Programación**:
    

	En el apartado de programación se implementaron una serie de características que conforman la base jugable del juego, siguiendo las pautas definidas por el departamento de **Diseño**:

	-   Adaptación a diferentes navegadores y a dispositivos móviles.
    
	-   Implementación del sistema de estadísticas aplicable al personaje principal y a los enemigos.
    
	-   Implementación de un sistema de movimiento en coordenadas isométricas para el personaje principal.
    
	-   Generación de las salas de la mazmorra.
    
	-   Implementación de una IA capaz de seguir al jugador para atacar.
    
	-   Implementación de un sistema de equipamiento de armaduras, armas y hechizos para el personaje principal.
    
	-   Implementación del sistema de cartas definido por el equipo de diseño.
    
	-   Sistema de combate basado en armas de 3 categorías.

-   **Arte:**
    

	El departamento de arte trabajó en la elaboración de diferentes *assets* para el juego entre los que se encuentran:
		
	-   *Sprite* del personaje principal masculino en 8 direcciones
    
	-   *Sprite* del personaje principal femenino en 8 direcciones
    
	-   *Sprite* del enemigo *Abuesqueleto* en 8 direcciones
    
	-   *Sprite* del arma *Espada de Fe*
    
	-   *Sprite* del arma *Bastón de Yayo*
    
	-   Arte de las cartas de Arma
    
	-   Arte de las cartas de Equipamiento
    
	-   Arte de las cartas de Maldición
    
	-   Arte de las cartas de Hechizo
    
	-   Arte de las cartas de Bendición
    
	-   *Tileset* de la *Discocueva*
    
	-   *Tileset* de Mazmorra
    

-   **Interfaces**
    

	El departamento de interfaces llevó a cabo los interfaces mínimos que se debían de entregar en este hito, entre ellos:

	-   Menú Principal
    
	-   Menú Pausa
    
	-   Escena de créditos
    
	-   *HUD* del jugador
    
	-   Escena de muerte

-   **Marketing**
    

	El equipo de marketing se ha encargado de promocionar el juego y darlo a conocer al mundo, para ello han realizado las siguientes acciones:

	-  	 Crear una cuenta de *Twitter* y usarla para dar difusión al juego.
    
	-   Crear una cuenta de *Instagram* y usarla para dar difusión al juego.
    
	-   Crear una cuenta de *Tik Tok* y usarla para dar difusión al juego.
    
	-   Crear un canal de *YouTube* para mostrar avances y trailers del título.
    
	-   Creación de un teaser trailer.
    
	-   Contacto con un *streamer* para que participe en las pruebas beta y de difusión al juego.

-   **Música**
    
	El compositor de la banda sonora de *Tales of the Dumbgeon* ha realizado los siguientes temas para este primer hito:

	-  	 [Tema de *Pueblo Boñiga*](https://github.com/salmorejogames/TalesoftheDumbgeon/blob/main/TalesOFDumbgeon/Assets/Music/PuebloBo%C3%B1iga.wav)
    
	-   [Tema de la *Dumbgeon*](https://github.com/salmorejogames/TalesoftheDumbgeon/blob/main/TalesOFDumbgeon/Assets/Music/Walking%20in%20the%20Dumbgeon.wav)
    
	-   [Tema de *Elmo Street*](https://github.com/salmorejogames/TalesoftheDumbgeon/blob/main/TalesOFDumbgeon/Assets/Music/ElmoStreet.wav)
    
	-   [Tema de *Game Over*](https://github.com/salmorejogames/TalesoftheDumbgeon/blob/main/TalesOFDumbgeon/Assets/Music/FUNeral.wav)
    
-   **Gestión**

	El departamento de gestión del proyecto ha realizado un documento para gestionar la producción del proyecto. En él se han tratado lo siguientes temas:

	-   Jerarquía de los equipos de desarrollo
    
	-   Uso de *Trello*
    
	-   Uso de *GitHub*
    
	-   Organización de los *sprints*
    
	-   Configuración de las revisiones
    

	Además se han celebrado diferentes reuniones a lo largo del hito entre ellas:

	-   *Daily Meeting*: Reuniones llevadas a cabo todos los días por la tarde.

	- *Revisiones de Sprint*: Realizadas los jueves y domingos para examinar el transcurso del proyecto. 
    
## 8.2 Hito 2
    
La fecha límite del hito 2 es el día 21 del mes de noviembre del año 2021. En él se ha desarrollado el juego de Tales of the Dumbgeon hasta conseguir una versión Beta apta para hacer las pruebas sobre el proyecto. Para ello los diferentes departamentos del estudio han realizado las labores explicadas en los siguientes apartados:

-   **Diseño**: En el apartado de diseño se redefinieron varios conceptos ya presentes en la fase Alpha con el objetivo de facilitar su implementación en el juego y para dar un acabado final mejor de cara al jugador.
    
	-   Cartas: las cartas han sufrido varios cambios. Para empezar, ahora una misma carta cuenta con varias versiones de sí misma, variando según el elemento que tenga. Esto permite una mayor variabilidad de elementos de juego con menos carga de trabajo. También se ha hecho que las estadísticas de la carta se generan aleatoriamente para que incluso con la misma arma cada partida sea diferente.
    
	-    Enemigos: se han definido los enemigos que pueden aparecer en el juego en el [DocumentoEnemigos](https://docs.google.com/spreadsheets/d/1288McVY26tAJtyNOAYZ1yEiYjnWewbAjJ_9ze4wnu2g/edit#gid=0). Estos tienen estadísticas aleatorias y su generación depende del nivel de dificultad de la sala en la que se encuentran. Además, pueden ser de cualquier elemento, generando así más variedad mecánica.
    
	-    Jefe Final: Jojomamalo cuenta con una variedad de movimientos mucho mayor al del resto de enemigos y un plan a futuro de contar con varias fases así como de diferentes patrones de acción siguiendo la ruta marcada en la asignatura de


-   **Programación:** En el apartado de programación se implementaron todas las características básicas que conforman la base jugable del juego, siguiendo las pautas definidas por el departamento de Diseño:

	-   Se han implementado varias mecánicas como la herencia aleatoria de cartas, el equipamiento de objetos o la posibilidad de eliminar cartas del inventario entre otras
    
	-   Se han pulido las mecánicas del personaje añadiendo todas las armas, hechizos y armaduras para poder jugar una partida completa con todas las mecánicas que ofrece el título.
    
	-  Cada enemigo tiene sus acciones únicas implementadas
    
	-   La mazmorra se genera proceduralmente pudiendo encontrar en sus salas generadores de enemigos o cofres para obtener nuevas cartas.
    
	-   Se ha mejorado la interfaz en móviles, personalizando los controles del joystick y botones y adaptando el tamaño de elementos de la interfaz.
	
	-   Se ha implementado el jefe final con una gran variedad de ataques.

-   **Arte**: El departamento de arte trabajó en la elaboración de diferentes assets para el juego entre los que se encuentran:

	-   Sprites del conjunto pícaro
    
	-   Sprites del conjunto guerrero
    
	-   Sprites del conjunto mago
    
	-   Sprite del enemigo Caballero Banana
    
	-   Sprite del enemigo Cerebro en un Tarro
	
	-   Sprite del enemigo Madre Pelusa
	
	-   Sprite del enemigo Hijo Pelusa
	
	-   Sprite del jefe Jojomamalo
	
	-   Sprite del arma Florete
	
	-   Sprite del arma Lanza
	
	-   Sprite del arma Pistola
	
	-   Sprite de los Hechizos
	
	-   Sprites de los proyectiles
	
	-   Tilesets extra de la Discocueva
	
	-   Animaciones del personaje principal

	-   Animaciones del Abuesqueleto

	-   Animaciones del Caballero Banana

	-   Animaciones del Cerebro en un Tarro
	
	-   Animaciones de la Madre Pelusa
	
	-   Animaciones del Hijo Pelusa
	
	-   Animaciones de Jojomamalo


-   **Interfaces**: El departamento de interfaces llevó a cabo varias mejoras en interfaces ya existentes y añadió unas nuevas:

	-   Se ha mejorado el Menú Principal con una animación de introducción y animaciones en los botones, añadiendo además un pequeño tutorial
    
	-   El Menú de Pausa también se ha pulido visualmente
    
	-   Menú de Ajustes para poder regular el sonido
    
	-   Escena de créditos pulida visualmente corrigiendo errores del fondo de la Alpha
    
	-   El HUD del jugador también ha sido mejorado usando ya los assets finales
	-   
	-   La Pantalla de Muerte también ha sido mejorada visualmente

-   **Marketing**: El equipo de marketing se ha encargado de promocionar el juego y darlo a conocer al mundo, para ello han realizado las siguientes acciones:

	-   Se ha cuidado la cuenta de Twitter tratando de nutrirla de contenido constante para mantener el interés del público
    
	-   Se ha cuidado la cuenta de Instagram tratando de nutrirla de contenido constante para mantener el interés del público
    
	-   Se ha cuidado la cuenta de Tik Tok tratando de nutrirla de contenido constante para mantener el interés del público
    
	-   Se ha subido al canal de YouTube el teaser trailer así como la banda sonora del juego
	
    
-   **Sonidos**: El compositor de la banda sonora de Tales of the Dumbgeon ha realizado los siguientes sonidos para este segundo hito:

	-   Golpe de Bastón
    
	-   Golpe de Espada
    
	-   Golpe de Lanza
    
	-   Hechizo de aire
    
	-   Hechizo de caos
	
	-   Hechizo de fuego
	
	-   Hechizo de hielo
	
	-   Hechizo de roca
	
	-   Hacer daño al monstruo
	
	-   Hacer daño al Stadnarr
	
	-   Pasos en la mazmorra
	
	-   Sonido de Bendición
	
	-   Sonido de Maldición
	
    
-   **Gestión**: El departamento de gestión del proyecto ha continuado con los documentos para gestión del proyecto. Entre otras cosas se han realizado:

	-   Actualizaciones de varios documentos como el GDD o los excels de cartas y enemigos
    
	-   Se ha continuado usando Trello
    
	-   Se ha continuado usando GitHub
    
	-   Organización de los *sprints*
    
	-   Configuración de las revisiones

	-   Daily Meeting: Reuniones llevadas a cabo todos los días por la tarde.

	-   Revisiones de Sprint: Realizadas los jueves y domingos para examinar el transcurso del proyecto.
    
    
## 8.3 Hito 3
    
## 8.4 Fecha de lanzamiento
