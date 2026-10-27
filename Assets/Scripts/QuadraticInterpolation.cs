using System.Collections;
using UnityEngine;

public class QuadraticInterpolation : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] Transform pointC;
    [SerializeField] GameObject sphere;
    [SerializeField] float duration;
    [SerializeField] AnimationCurve ease;
    private Transform instantiatedObject;

    void Start()
    {
        instantiatedObject = Instantiate(sphere, Vector3.zero, Quaternion.identity).transform;
        StartCoroutine(Animation());
    }

    // Curva de Bézier cuadrática: va de A a B usando C como punto de control.
    // Se calcula con dos Lerps y un Lerp entre sus resultados
    Vector3 Bezier(float t)
    {
        Vector3 AC = Vector3.Lerp(pointA.position, pointC.position, t);
        Vector3 CB = Vector3.Lerp(pointC.position, pointB.position, t);
        return Vector3.Lerp(AC, CB, t);
    }

    IEnumerator Animation()
    {
        while (true)
        {
            // Ida: de A a B
            yield return Recorrer(false);
            // Vuelta: de B a A por la misma curva
            yield return Recorrer(true);
        }
    }

    IEnumerator Recorrer(bool deVuelta)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            float t = ease.Evaluate(Mathf.Clamp01(elapsedTime / duration));
            instantiatedObject.position = Bezier(deVuelta ? 1f - t : t);

            yield return null;
        }
    }
}
