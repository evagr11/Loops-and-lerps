using System.Collections;
using System.Collections.Generic;
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
        instantiatedObject = GameObject.Instantiate(sphere, Vector3.zero, Quaternion.identity).transform;
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        float elapsedTime = 0f;
        float normalizedElapsedTime;

        while (true)
        {

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;

                normalizedElapsedTime = elapsedTime / duration;

                Vector3 CD = Vector3.Lerp(pointC.position, pointD.position, ease.Evaluate(normalizedElapsedTime));
                Vector3 A_CD = Vector3.Lerp(pointA.position, CD, ease.Evaluate(normalizedElapsedTime));
                Vector3 CD_B = Vector3.Lerp(CD, pointB.position, ease.Evaluate(normalizedElapsedTime));
                instantiatedObject.position = Vector3.Lerp(A_CD, CD_B, ease.Evaluate(normalizedElapsedTime));

                yield return new WaitForEndOfFrame();
            }

            elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;

                normalizedElapsedTime = elapsedTime / duration;

                Vector3 DC = Vector3.Lerp(pointD.position, pointC.position, ease.Evaluate(normalizedElapsedTime));
                Vector3 B_DC = Vector3.Lerp(pointB.position, DC, ease.Evaluate(normalizedElapsedTime));
                Vector3 DC_A = Vector3.Lerp(DC, pointA.position, ease.Evaluate(normalizedElapsedTime));
                instantiatedObject.position = Vector3.Lerp(B_DC, DC_A, ease.Evaluate(normalizedElapsedTime));

                yield return new WaitForEndOfFrame();
            }

            elapsedTime = 0f;

            yield return null;
        }
    }
}