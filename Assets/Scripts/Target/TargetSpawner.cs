using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets = new List<GameObject>();
    [SerializeField] private int numberOfActive = 2;
    [SerializeField] private Material baseMat;

    private int activeCount;

    void Update()
    {
        CheckTargets();
    }

    private void CheckTargets()
    {
        activeCount = 0;
        foreach (GameObject target in targets)
        {
            if (target.activeInHierarchy) activeCount++;

            if (activeCount <= 0) 
            {
                StartCoroutine(ActivateTargets());
            }
        }
    }

    private IEnumerator ActivateTargets()
    {
        foreach (GameObject target in targets)
        {
            MeshRenderer mr = target.GetComponent<MeshRenderer>();
            mr.material = baseMat;
        }

        for (int i = 1; i < numberOfActive; i++)
        {
            int index = Random.Range(0, targets.Count);
            targets[index].SetActive(true);
            
            yield return new WaitForSeconds(1f);
        }
    }
}
