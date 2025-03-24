using System.Collections;
using System.Collections.Generic;
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

                Vector3 AC = Vector3.Lerp(pointA.position, pointC.position, ease.Evaluate(normalizedElapsedTime));
                Vector3 CB = Vector3.Lerp(pointC.position, pointB.position, ease.Evaluate(normalizedElapsedTime));
                instantiatedObject.position = Vector3.Lerp(AC, CB, ease.Evaluate(normalizedElapsedTime));

                yield return new WaitForEndOfFrame();
            }

            elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;

                normalizedElapsedTime = elapsedTime / duration;

                Vector3 BC = Vector3.Lerp(pointB.position, pointC.position, ease.Evaluate(normalizedElapsedTime));
                Vector3 CA = Vector3.Lerp(pointC.position, pointA.position, ease.Evaluate(normalizedElapsedTime));
                instantiatedObject.position = Vector3.Lerp(BC, CA, ease.Evaluate(normalizedElapsedTime));

                yield return new WaitForEndOfFrame();
            }

            elapsedTime = 0f;

            yield return null;
        }
    }
}