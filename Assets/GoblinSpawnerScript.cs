using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawnerScript : MonoBehaviour
{
    [SerializeField] private Goblin _goblin;
    [SerializeField] private Transform _motherGoblin;
    private Transform[] _goblinHoles;
    private WaitForSeconds _waitTwoSeconds = new WaitForSeconds(2);
    private System.Random _random = new System.Random();

    void Start()
    {
        _goblinHoles = new Transform[_motherGoblin.childCount];

        for (int i = 0; i < _motherGoblin.childCount; i++)
        {
            _goblinHoles[i] = _motherGoblin.GetChild(i);
        }

        StartCoroutine(SpawnGoblins(_goblin));
    }

    private IEnumerator SpawnGoblins(Goblin goblin)
    {
        while (true)
        {
            Transform target = _goblinHoles[_random.Next(0, _motherGoblin.childCount)];

            Instantiate(goblin, target.transform.position, Quaternion.identity);

            yield return _waitTwoSeconds;
        }
    }
}
