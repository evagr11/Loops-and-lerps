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
        instantiatedObject = GameObject.Instantiate(sphere, Vector3.zero, Quaternion.identity).transform;
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
                normalizedElapsedTime = elapsedTime / duration;

                finalValue = Vector3.LerpUnclamped(points[currentPoint].position, points[nextPoint].position, ease.Evaluate(normalizedElapsedTime));
                instantiatedObject.position = finalValue;

                finalValue = Vector3.Lerp(points[currentPoint].localScale, points[nextPoint].localScale, ease.Evaluate(normalizedElapsedTime));
                instantiatedObject.localScale = finalValue;

                finalRotation = Quaternion.Lerp(points[currentPoint].rotation, points[nextPoint].rotation, ease.Evaluate(normalizedElapsedTime));
                instantiatedObject.rotation = finalRotation;

                finalColor = Color.Lerp(colors[currentPoint], colors[nextPoint], ease.Evaluate(normalizedElapsedTime));
                instantiatedObjectRenderer.material.color = finalColor;

                elapsedTime += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            currentPoint = nextPoint;

            nextPoint = (nextPoint + 1) % points.Length;
        }
    }
}