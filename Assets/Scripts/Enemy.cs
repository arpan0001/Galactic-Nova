using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    static int points = 100;

    [SerializeField] float rotationOffset = 100f;

    bool gotHit = false;

    Transform myT;
    Vector3 randomRotation;

    void Awake()
    {
        myT = transform;
    }

    void Start()
    {
        randomRotation.x = Random.Range(-rotationOffset , rotationOffset );
        randomRotation.y = Random.Range(-rotationOffset , rotationOffset );
        randomRotation.z = Random.Range(-rotationOffset , rotationOffset );
    }

    void Update()
    {
        myT.Rotate(randomRotation * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.CompareTag("Player"))
        {
            if(!gotHit)
                EnemyHit();
        }
    }

    public void EnemyHit()
    {
        if(!gotHit)
        {
            gotHit = true;
            Debug.Log("Player Hit us!");
            EventManager.ScorePoints(points);
            EventManager.ReSpawnEnemy();
            Destroy(gameObject);
        }
    }
}
