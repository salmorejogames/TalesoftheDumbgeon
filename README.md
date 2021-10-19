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


# 1. Introducción
Este es el documento de diseño de juego de “Tales of the Dumbgeon”. Un juego para web que pretende explorar un roguelike frenético y desenfadado de corte fantástico, con toques de humor absurdo, armas, monstruos y un maléfico hechicero.

## 1.1 Descripción breve del concepto     
Tales of the Dumbgeon es un videojuego de acción tipo roguelike basado en la obtención de cartas como equipamiento y habilidades, que será la mecánica principal gracias a la cual el jugador podrá llegar hasta el final de la Dumbgeon.

Mediante estas mecánicas el jugador podrá crear a lo largo de las partidas personajes únicos con sus virtudes y defectos, armas y armaduras legendarias y con algún que otra maldición.

Se inspira en juegos como *Enter the Gungeon*, *Dead Cells*, *Hades* y *The Binding of Isaac*.

## 1.2 Descripción breve de la historia y personajes
    

“El Pueblo Boñiga ha sido asaltado durante siglos por los monstruos y criaturas originadas en el interior de la maldita Dumbgeon. Es por eso que cada 69 años se celebra una votación amañada para elegir al héroe (carnada) que entrará en el interior de esta para liberar al pueblo de su yugo. En su interior las cartas ancestrales creadas por el Mago Jose Joaquin Martín Martinez López, más conocido como Jojomamalo, harán que el héroe se convierta en lo que quiera ser… literalmente y derrotar a los engendros de la Dumbgeon.

La familia Stadtnarr ha sido siempre el hazme reír del pueblo, los parias a los que nadie quiere. Es por eso que el pueblo los elige a ellos siempre, a lo largo de los años, para internar en la mazmorra a padres, hijos, nietos y abuelos.

¿Conseguirán los Stadtnarr llegar hasta el final de la Dumbgeon? ¿Descubrirán el secreto que encierra esta misteriosa mazmorra? ¿Habrá un secreto siquiera? Eso es algo que solo se podrá descubrir llegando… al corazón de la Dumbgeon. “

## 1.3 Propósito, público objetivo y plataformas
    

El propósito de detrás de la creación de *Tales of the Dumbgeon* es es la de crear un juego divertido y desenfadado de fácil acceso que permita a jugadores de todo el mundo divertirse durante esos ratos muertos frente al ordenador entre actividades más importantes.

*Tales of the Dumbgeon* está dirigido a un amplio abanico de edades aunque el mejor intervalo es entre 18 a 30 años ya que se utilizará humor negro y absurdo. Al ser un videojuego rejugable y desenfadado con una trama simple pero interesante es fácil que entre en el nicho de juegos casuales, un sector cada vez más nutrido de jugadores.

## 1.4 Características principales
    

El videojuego se basa en los siguientes puntos:

-   **Generación aleatoria del mundo y sus mazmorras:** para evitar la repetitividad de escenarios se implementará una generación aleatoria de los mismos, consiguiendo así que cada partida sea diferente y logrando que el juego no se haga pesado a pesar de tener que empezar de cero al morir.
 
-   **Recolección de cartas que generan habilidades y equipo:** por toda la mazmorra el jugador podrá conseguir una gran variedad de cartas, cada una representando una utilidad diferente. De esa forma habrá cartas que funcionarán como equipamiento para el personaje, nuevas habilidades o hasta maldiciones que dificulten la partida, todas ellas cargadas con un toque de humor.
    
-   **Combate rápido cuerpo a cuerpo con habilidades y hechizos**: la Dumbgeon estará repleta de enemigos contra los que el jugador deberá enfrentarse usando las habilidades que haya obtenido de las cartas.
    
-  ** Jefes finales con memoria:** los distintos enemigos finales de cada zona recordarán los anteriores encuentros que han tenido con el jugador, pudiendo hacer comentarios de diversa índole en función del ratio de victorias y derrotas del jugador.
    
-   **Herencia de habilidades:** al ser cada partida una incursión de un miembro de la familia Stadtnarr se incluirá una mecánica que permita la herencia de una de las cartas de antecesor al nuevo personaje.
    
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

Existen diversos departamentos para la gestión y el desarrollo de las tareas necesarias para la realización del proyecto.Cada departamento está formado por una o más personas y está dirigido por un líder. Una persona puede estar en más de un departamento.

  

El jefe de cada departamento está encargado de la asignación y evaluación de las tareas dentro de su equipo. Los problemas que surgen dentro de un departamento se llevan al líder del mismo. Si el problema que surge es un problema mayor o que necesita de otros departamentos el líder debe encargarse de contactar con el equipo de Dirección para formalizar una reunión grupal que pueda solucionarlo.

El equipo de dirección es un equipo especial, que se encargará de la organización de los departamentos, la resolución de problemas entre las personas y la gestión general del proyecto.


Las reuniones se realizan mediante Microsoft Teams.

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
## 4.1 Jugabilidad

## 4.2 Controles y reglas de juego

## 4.3 Niveles y misiones

## 4.4 Objetos, armas y power ups


# 5. Trasfondo
## 5.1 Descripción detallada de la historia  y la trama
## 5.2 Personajes 
## 5.3 Entornos y lugares

# 6. Arte
## 6.1 Estética general del juego
## 6.2 Apartado visual
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
