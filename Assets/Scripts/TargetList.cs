using System.Collections;
using UnityEngine;

public class TargetList : MonoBehaviour
{
    [SerializeField] GameObject sphere;
    [SerializeField] float duration;
    [SerializeField] Transform[] points;
    [SerializeField] Color[] colors;
    [SerializeField] AnimationCurve ease;

    private Transform instantiatedObject;
    private Renderer instantiatedObjectRenderer;

    void Start()
    {
        if (points.Length < 2 || colors.Length < points.Length)
        {
            Debug.LogWarning("TargetList: hacen falta al menos 2 puntos y un color por cada punto.");
            return;
        }

        instantiatedObject = Instantiate(sphere, Vector3.zero, Quaternion.identity).transform;
        instantiatedObjectRenderer = instantiatedObject.GetComponent<Renderer>();

        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        int currentPoint = 0;
        int nextPoint = 1;  
        float elapsedTime;
        float normalizedElapsedTime;
        Vector3 finalValue;
        Quaternion finalRotation;
        Color finalColor;

        while (true)
        {
            elapsedTime = 0;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                normalizedElapsedTime = Mathf.Clamp01(elapsedTime / duration);

                finalValue = Vector3.LerpUnclamped(points[currentPoint].position, points[nextPoint].position, ease.Evaluate(normalizedElapsedTime));
                instantiatedObject.position = finalValue;

                finalValue = Vector3.Lerp(points[currentPoint].localScale, points[nextPoint].localScale, ease.Evaluate(normalizedElapsedTime));
                instantiatedObject.localScale = finalValue;

                finalRotation = Quaternion.Lerp(points[currentPoint].rotation, points[nextPoint].rotation, ease.Evaluate(normalizedElapsedTime));
                instantiatedObject.rotation = finalRotation;

                finalColor = Color.Lerp(colors[currentPoint], colors[nextPoint], ease.Evaluate(normalizedElapsedTime));
                instantiatedObjectRenderer.material.color = finalColor;

                yield return null;
            }

            // Pasa al siguiente punto y vuelve al primero al llegar al final de la lista
            currentPoint = nextPoint;

            nextPoint = (nextPoint + 1) % points.Length;
        }
    }
}