# Product Implementation Document

## 1.- Canvas, Cliente y Espacio de Juego

Para mantener un aspecto uniforme en el juego independientemente de su plataforma, se han implementado los siguientes elementos en Unity:

 - **Script CameraBlackBars:** Este script se encarga de mantener fijo el aspect ratio de la cámara. El target aspect esta hardcodeado en el script, si en algún momento se quisiese tener diferentes valores, se puede hacer una variable publica que almacene el valor. Este script debe estar dentro de la cámara principal de la escena.
 - **Cámara Secundaria:** Una cámara hija de la cámara principal que se encarga de renderizar la pantalla sobrante tras mantener el aspect ratio. Su profundidad debe ser inferior a la de la cámara principal y su cullingMask debe estar marcado como nothing para que no se visualice nada del juego. En el background se pone un fondo negro, de manera que el espacio sobrante de la pantalla sea una barra negra.
 - **Canvas Interno a la Cámara:** Para adaptar el canvas a la pantalla de juego, se pondrá el canvas como hijo de la cámara principal. Dentro del canvas se cambiará el render mode a Screen Space - Camera para que se adapte a esta, y el canvas scaler a Scale With Screen Size, indicando un tamaño de referencia de 1280 x 720, qué es el tamaño ideado para el canvas de juego en el HTML.
 - **WebGL Template --> Better Template:** Se está utilizando un template de WebGl externo para que el juego se adapte al espacio que tiene asociado. En Itch.io podemos establecer un tamaño para asociarle, el cual será de 1280 x 720. El template está asignado desde Project Settings > Player > Settings for WebGL > Resolution and Presentation. Aquí también se indicará el tamaño por defecto del canvas al ya mencionado.
 - **Plugin JavaScript CheckIfMobile:** En la carpeta plugins se ha introducido un plugin JavaScript que nos permitirá saber si el dispositivo en el que se está jugando es un dispositivo móvil o no. Se ha introducido un Script normal para otorgar la función CheckIfMobile.isMobile(), que indicará este dato.

## 2.- Personaje 

### Movimiento 

Se ha hecho una implementación de prueba no definitiva, que debe ser  sustituida. Esta cuenta con los scripts ButtonManager, Movement y PlayerController.

# Referencias
WebGL Better Template: https://github.com/greggman/better-unity-webgl-template
