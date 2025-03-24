using TMPro;
using System.Collections; 
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string[] sceneNames;
    [SerializeField] public TMP_Text mensajeUI;

    void Start()
    {
        mensajeUI.gameObject.SetActive(false); 

        StartCoroutine(MostrarMensaje());

        if (FindObjectsOfType<ChangeScene>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        if (SceneData.CurrentSceneIndex == -1)
        {
            SceneData.CurrentSceneIndex = 0;
        }


    }
    IEnumerator MostrarMensaje()
    {
        yield return new WaitForSeconds(5f); 
        mensajeUI.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            mensajeUI.gameObject.SetActive(false);

            ChangeToNextScene();

        }

    }

    void ChangeToNextScene()
    {
        StartCoroutine(MostrarMensaje());

        SceneData.CurrentSceneIndex++;

        if (SceneData.CurrentSceneIndex >= sceneNames.Length)
        {
            SceneData.CurrentSceneIndex = 0;
        }

        SceneManager.LoadScene(sceneNames[SceneData.CurrentSceneIndex]);
    }

}

public static class SceneData
{
    public static int CurrentSceneIndex = -1;
}
