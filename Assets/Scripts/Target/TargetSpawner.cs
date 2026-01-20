using System.Collections;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets = new List<GameObject>();
    [SerializeField] private int numberOfActive = 2;
    [SerializeField] private Material baseMat;

    private int activeCount;
    
    void Start()
    {
        foreach (GameObject t in targets) t.SetActive(false);

        StartCoroutine(SpawnLogic());
    }
    
    void Update()
    {
        int currentActive = 0;
        foreach (GameObject t in targets)
        {
            if (t.activeInHierarchy) currentActive++;
        }
    }

    private void ActivateTargets()
    {
        if (targets.Count <= numberOfActive) return;
    
        int currentActive = GetActiveCount();
    
        while (currentActive < numberOfActive)
        {
            int index = Random.Range(0, targets.Count);
            if (!targets[index].activeInHierarchy)
            {
                targets[index].SetActive(true);
                currentActive++; 
            }
        }
    }
    
    private int GetActiveCount()
    {
        int count = 0;
        foreach (GameObject t in targets)
        {
            if (t.activeInHierarchy) count++;
        }
        return count;
    }
    
    private IEnumerator SpawnLogic()
    {
        while(true)
        {
            int currentActive = GetActiveCount();
            if (currentActive < numberOfActive)
            {
                yield return new WaitForEndOfFrame();
                ActivateTargets();
            }
            yield return null;
        }
    }
}
