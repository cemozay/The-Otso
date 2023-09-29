using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class gameManager : MonoBehaviour
{
    public static bool isInteracted = false;
    public GameObject[] npcObjects;
    private int currentNpcIndex = 0;
    [SerializeField] NavMeshSurface navMeshSurface;

    private void Update()
    {
        if (currentNpcIndex < npcObjects.Length)
        {
            if (!npcObjects[currentNpcIndex].activeSelf)
            {
                currentNpcIndex++;
                if (currentNpcIndex < npcObjects.Length)
                {
                    ActivateCurrentNpc();
                    RebuildNavMesh();
                }
            }
        }
    }

    void ActivateCurrentNpc()
    {
        npcObjects[currentNpcIndex].SetActive(true);
    }

    void RebuildNavMesh()
    {
        navMeshSurface.BuildNavMesh();
    }
}
