using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string[] sceneNames;
    [SerializeField] public TMP_Text mensajeUI;
    [SerializeField] private float segundosHastaMensaje = 5f;

    private Coroutine mensajeCoroutine;

    void Awake()
    {
        // Solo puede haber un gestor de escenas: si al volver a la primera escena
        // aparece otro, se destruye antes de que haga nada
        if (FindObjectsOfType<ChangeScene>().Length > 1)
        {
            enabled = false; // Para que no llegue a ejecutar Start ni Update
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        if (SceneData.CurrentSceneIndex == -1)
        {
            SceneData.CurrentSceneIndex = 0;
        }
    }

    void Start()
    {
        ReiniciarMensaje();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ChangeToNextScene();
        }
    }

    // Oculta el mensaje y lo vuelve a mostrar pasados unos segundos.
    // Se para la corrutina anterior para que no se acumulen si se pulsa N varias veces seguidas
    void ReiniciarMensaje()
    {
        mensajeUI.gameObject.SetActive(false);

        if (mensajeCoroutine != null)
        {
            StopCoroutine(mensajeCoroutine);
        }
        mensajeCoroutine = StartCoroutine(MostrarMensaje());
    }

    IEnumerator MostrarMensaje()
    {
        yield return new WaitForSeconds(segundosHastaMensaje);
        mensajeUI.gameObject.SetActive(true);
    }

    void ChangeToNextScene()
    {
        ReiniciarMensaje();

        SceneData.CurrentSceneIndex = (SceneData.CurrentSceneIndex + 1) % sceneNames.Length;

        SceneManager.LoadScene(sceneNames[SceneData.CurrentSceneIndex]);
    }
}

public static class SceneData
{
    public static int CurrentSceneIndex = -1;
}
