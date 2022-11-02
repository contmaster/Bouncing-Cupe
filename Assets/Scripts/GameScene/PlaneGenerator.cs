using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGenerator : MonoBehaviour
{
    [SerializeField] private GameObject plane;
    [SerializeField] private Transform planeParent;
    private Transform _planeTransform;

    private Vector3 _lastSpawnedPos;
    
    [Header("Plane Options")]
    [SerializeField] private float planeXSpawnPos = 4.9f;

    [Header("Spawn Options")]
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [Header("Timer Variables")]
    [SerializeField] private float timeThick = 1f;
    private float elapsedTime = 0f;

    private void Start()
    {
        _planeTransform = plane.transform.GetComponent<Transform>();
        _lastSpawnedPos = _planeTransform.position;
    }

    private void Update()
    {
        Timer();
    }

    private void SpawnPlane()
    {
        Vector3 randomScale = new Vector3(Random.Range(3f, 5f), Random.Range(0.3f, 0.5f));
        Vector3 spawnRandomPos = new Vector3(Random.Range(-planeXSpawnPos, planeXSpawnPos), Random.Range(minY, maxY) + _lastSpawnedPos.y, 0);

        GameObject planeClone = Instantiate(plane, spawnRandomPos, Quaternion.identity);

        planeClone.transform.localScale = randomScale;
        planeClone.transform.SetParent(planeParent);

        _lastSpawnedPos.y = spawnRandomPos.y;
    }

    private void Timer()
    {
        if (elapsedTime <= timeThick)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            elapsedTime = 0;
            SpawnPlane();
        }
    }

}
