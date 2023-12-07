using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerObject : MonoBehaviour
{
    [SerializeField] private GameObject SliceablePrefab;
    [SerializeField] private GameObject ExplosivePrefab;
    [SerializeField] private GameObject HealerPrefab;

    [SerializeField] private Manager manager;

    int randNum;
    public List<Transform> SpawnPos = new List<Transform>();
    public bool spawningBool = true;
    public float spawnTime;
    public float launchForce = 150;

    
    public void StartGame()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        yield return new WaitForSeconds(spawnTime);
        randNum = Random.Range(0, SpawnPos.Count);
        Vector3 position = SpawnPos[randNum].position;
        Quaternion rotation = SpawnPos[randNum].rotation;

        int randball = Random.Range(0, 6);

        GameObject sliceable;

        if(randball == 5)
        {
            sliceable = Instantiate(HealerPrefab, position, rotation);
        }
        else if(randball >= 3 && randball < 5)
        {
            sliceable = Instantiate(ExplosivePrefab, position, rotation);
        }
        else
        {
            sliceable = Instantiate(SliceablePrefab, position, rotation);
        }


        SliceableObject obj = sliceable.GetComponent<SliceableObject>();
        obj.SetUp(manager, SpawnPos[randNum].up, launchForce);

        if(spawningBool)
            StartCoroutine(Spawning());
    }
}
