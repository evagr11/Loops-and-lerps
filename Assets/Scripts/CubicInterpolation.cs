using System.Collections;
using UnityEngine;

public class CubicInterpolation : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] Transform pointC;
    [SerializeField] Transform pointD;
    [SerializeField] GameObject sphere;
    [SerializeField] float duration;
    [SerializeField] AnimationCurve ease;
    private Transform instantiatedObject;

    void Start()
    {
        instantiatedObject = Instantiate(sphere, Vector3.zero, Quaternion.identity).transform;
        StartCoroutine(Animation());
    }

    // Curva de Bézier cúbica: va de A a B usando C y D como puntos de control.
    // Algoritmo de De Casteljau: tres Lerps, luego dos y por último uno
    Vector3 Bezier(float t)
    {
        Vector3 AC = Vector3.Lerp(pointA.position, pointC.position, t);
        Vector3 CD = Vector3.Lerp(pointC.position, pointD.position, t);
        Vector3 DB = Vector3.Lerp(pointD.position, pointB.position, t);

        Vector3 AC_CD = Vector3.Lerp(AC, CD, t);
        Vector3 CD_DB = Vector3.Lerp(CD, DB, t);

        return Vector3.Lerp(AC_CD, CD_DB, t);
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
