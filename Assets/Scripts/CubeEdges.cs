using System.Collections;
using UnityEngine;

public class CubeEdges : MonoBehaviour
{
    [SerializeField] int height;
    [SerializeField] int width;
    [SerializeField] int length;
    [SerializeField] int start;

    [SerializeField] GameObject cube;

    [SerializeField] float timeBetweenSpawns;

    void Start()
    {
        StartCoroutine(InstantiateOverTime());
    }

    // Recorre todas las posiciones del cubo con tres bucles anidados
    // y solo instancia un cubo cuando la posición está en una arista
    IEnumerator InstantiateOverTime()
    {
        int endI = start + height - 1;
        int endJ = start + width - 1;
        int endK = start + length - 1;

        for (int i = start; i <= endI; i++)
        {
            for (int j = start; j <= endJ; j++)
            {
                for (int k = start; k <= endK; k++)
                {
                    bool bordeI = i == start || i == endI;
                    bool bordeJ = j == start || j == endJ;
                    bool bordeK = k == start || k == endK;

                    // Una arista es donde coinciden al menos dos caras
                    if ((bordeI && bordeJ) || (bordeJ && bordeK) || (bordeI && bordeK))
                    {
                        Instantiate(cube, new Vector3(i, j, k), Quaternion.identity);
                        yield return new WaitForSeconds(timeBetweenSpawns);
                    }
                }
            }
        }
    }
}
