<div align="center">
  <img src="https://capsule-render.vercel.app/api?type=waving&color=0%3A134E4A%2C50%3A14B8A6%2C100%3ACCFBF1&height=200&section=header&text=Loops+and+Lerps&fontSize=60&fontColor=fff&fontAlignY=38&desc=Bucles%2C+interpolaciones+y+curvas+de+B%C3%A9zier+en+Unity&descAlignY=62&descSize=18" width="100%"/>
</div>

<div align="center">
  <a href="https://github.com/evagr11/Loops-and-lerps" target="_blank"><img src="https://img.shields.io/badge/Ver_Código-134E4A?style=for-the-badge&logo=github&logoColor=white" alt="Ver Código"></a>
</div>

<div align="center">
  <a href="https://git.io/typing-svg"><img src="https://readme-typing-svg.demolab.com/?font=JetBrains+Mono&size=18&duration=3500&pause=800&color=0D9488&center=true&vCenter=true&width=600&lines=Bucles+anidados+con+corrutinas%3BLerp+de+posici%C3%B3n%2C+escala%2C+rotaci%C3%B3n+y+color%3BCurvas+de+B%C3%A9zier+cuadr%C3%A1ticas+y+c%C3%BAbicas%3BAnimationCurves+para+el+easing" alt="Typing SVG" /></a>
</div>

# 🚀 Sobre el Proyecto

**Loops and Lerps** es una colección de cuatro escenas de **Unity** para practicar dos herramientas básicas de la programación de videojuegos: los **bucles** y la **interpolación lineal** (`Lerp`). Cada escena es un pequeño ejercicio animado y se pasa de una a otra pulsando la tecla `N`.

Todas las animaciones están hechas por código con **corrutinas**, sin usar el `Animator`, y el ritmo de cada movimiento se controla con una `AnimationCurve` editable desde el Inspector.

### 🎬 Escenas

<div align="center">

| # | Escena | Qué hace |
| :-: | :----- | :------- |
| 1 | **CubeEdges** | Construye poco a poco las aristas de un cubo de 5×5×5 con tres bucles `for` anidados, colocando solo los cubos donde se juntan dos caras. |
| 2 | **TargetList** | Una esfera recorre en bucle una lista de puntos interpolando a la vez su posición, su escala, su rotación y su color. |
| 3 | **QuadraticInterpolation** | Una esfera va y vuelve entre dos puntos siguiendo una **curva de Bézier cuadrática** (un punto de control). |
| 4 | **CubicInterpolation** | Lo mismo con una **curva de Bézier cúbica** (dos puntos de control), calculada con el algoritmo de De Casteljau. |

</div>

✨ **Qué se practica:**

*   🔁 **Bucles anidados en el tiempo:** `CubeEdges` usa una corrutina con `WaitForSeconds` para que se vea cómo se va generando el cubo pieza a pieza.
*   📏 **`Lerp` de distintos tipos:** `Vector3.Lerp` y `LerpUnclamped` para posición y escala, `Quaternion.Lerp` para la rotación y `Color.Lerp` para el material.
*   🌀 **Curvas de Bézier a base de Lerps:** Encadenando interpolaciones entre los puntos se consiguen trayectorias curvas, sin fórmulas complicadas.
*   📈 **Easing con `AnimationCurve`:** La misma animación puede ir a velocidad constante, acelerar, frenar o incluso pasarse del destino y volver, solo cambiando la curva.
*   🎮 **Cambio de escenas:** Un gestor con `DontDestroyOnLoad` (y un patrón *singleton* sencillo) recorre la lista de escenas con `N` y muestra un aviso en pantalla a los 5 segundos.

# 🧠 Contexto del Proyecto

Este proyecto se desarrolló durante el ciclo formativo de **Desarrollo de Aplicaciones Multiplataforma (DAM)** como práctica de introducción a Unity. El objetivo era entender cómo se mueven las cosas en un juego: recorrer posiciones con bucles, interpolar valores a lo largo del tiempo y controlar el ritmo de las animaciones con curvas.

# 🛠️ Stack Tecnológico

<div align="center">
  <img src="https://img.shields.io/badge/Unity-000000?style=for-the-badge&logo=unity&logoColor=white" alt="Unity">
  <img src="https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="C#">
  <img src="https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white" alt="Visual Studio">
  <img src="https://img.shields.io/badge/Status-Terminado-0D9488?style=for-the-badge" alt="Status Terminado">
</div>

<br>

<div align="center">

| Componente | Tecnología |
| :--------- | :--------- |
| **Motor** | `Unity 2022.3 LTS` (2022.3.50f1) |
| **Lenguaje** | `C#` |
| **Animación** | Corrutinas, `Vector3.Lerp`, `Quaternion.Lerp`, `Color.Lerp` y `AnimationCurve` |
| **Escenas** | `SceneManager` y `DontDestroyOnLoad` |
| **Interfaz** | `TextMeshPro` |

</div>

# 📂 Estructura del Proyecto

```bash
Loops-and-lerps/
├── Assets/
│   ├── Scenes/
│   │   ├── CubeEdges.unity                # Escena inicial (con el gestor de escenas)
│   │   ├── TargetList.unity
│   │   ├── QuadraticInterpolation.unity
│   │   └── CubicInterpolation.unity
│   ├── Scripts/
│   │   ├── ChangeScene.cs                 # Cambia de escena con N y muestra el aviso
│   │   ├── CubeEdges.cs                   # Aristas de un cubo con bucles anidados
│   │   ├── TargetList.cs                  # Recorrido por una lista de puntos
│   │   ├── QuadraticInterpolation.cs      # Bézier cuadrática
│   │   └── CubicInterpolation.cs          # Bézier cúbica
│   └── Prefabs/
│       ├── Cube.prefab
│       └── Sphere.prefab
├── Packages/
└── ProjectSettings/
```

# 🚀 Cómo Utilizar el Proyecto

Necesitas **Unity Hub** y la versión **Unity 2022.3.50f1** (o cualquier 2022.3 LTS).

1.  **Clona el repositorio:**
    ```bash
    git clone https://github.com/evagr11/Loops-and-lerps.git
    ```
2.  **Ábrelo desde Unity Hub:** `Add` > `Add project from disk` y selecciona la carpeta `Loops-and-lerps`.
3.  **Abre la escena** `Assets/Scenes/CubeEdges.unity`. Tiene que ser esta, porque es la que contiene el gestor de escenas.
4.  **Pulsa Play** y usa la tecla `N` para pasar a la siguiente escena. Después de la última se vuelve a la primera.

> [!TIP]
> Prueba a cambiar la `AnimationCurve` (`ease`) del objeto `GameManager` en el Inspector para ver cómo cambia el movimiento de la esfera, o mueve los puntos `PointA`, `PointB`, `PointC` y `PointD` mientras se ejecuta para deformar la curva en directo.

# 🎯 Mejoras futuras

- ✏️ Dibujar la curva de Bézier en la escena con un `LineRenderer` o con `Gizmos`.
- 🔙 Poder volver a la escena anterior con otra tecla.
- 🧊 Generar otras figuras con bucles: un cubo relleno, una pirámide o una esfera de cubos.

<br>

<div align="center">
  <p>Creado por <strong>Eva Gallardo</strong></p>
  <a href="https://github.com/evagr11" target="_blank">
    <img src="https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white" alt="GitHub">
  </a>
  <a href="https://www.linkedin.com/in/eva-gallardo-romero-830362349/" target="_blank">
    <img src="https://img.shields.io/badge/LinkedIn-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white" alt="LinkedIn">
  </a>
</div>

<div align="center">
  <img src="https://capsule-render.vercel.app/api?type=waving&color=0%3A134E4A%2C50%3A14B8A6%2C100%3ACCFBF1&height=120&section=footer" width="100%"/>
</div>
