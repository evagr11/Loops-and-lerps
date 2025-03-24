using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEdges : MonoBehaviour
{
    [SerializeField] int height;
    [SerializeField] int width;
    [SerializeField] int length;
    [SerializeField] int start;

    [SerializeField] GameObject cube;

    [SerializeField] float timeBetweenSpawns;
    Vector3 position = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiateOverTime());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator InstantiateOverTime()
    {
        for (int i = start; i <= height + start - 1; i++)
        {
            for (int j = start; j <= width + start - 1; j++)
            {
                for (int k = start; k <= length + start - 1; k++)
                {

                    if ((i == start || i == height + start - 1) && (j == start || j == width + start - 1) ||
                        (j == start || j == width + start - 1) && (k == start || k == length + start - 1) ||
                        (i == start || i == height + start - 1) && (k == start || k == length + start - 1))
                    {
                        position = new Vector3(i, j, k);
                        Instantiate(cube, position, Quaternion.identity);
                        yield return new WaitForSeconds(timeBetweenSpawns);
                    }
                }
            }
        }
    }
}
