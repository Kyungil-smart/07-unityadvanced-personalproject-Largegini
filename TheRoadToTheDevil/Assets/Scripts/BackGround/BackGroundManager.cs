using System;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    // 역할
    // 생성된 배경 관리
    [SerializeField] public GameObject tree;
    [SerializeField] public GameObject cloud;
    [SerializeField] public GameObject mountain;
    
    private Queue<GameObject> _backGrounds = new Queue<GameObject>();
    // 카메라 밖 좌표
    private Vector3 _spawnOffset;
    // 스폰 포인트
    [SerializeField] public Transform spawnPoint;
    // 디스폰 포인트
    [SerializeField] public Transform DespawnPoint;
    
    // 생성 주기
    private float _treeSpawnRate;
    private Timer _treeSpawnTimer;
    
    private float _cloudSpawnRate;
    private Timer _cloudSpawnTimer;
    
    private float _mountainSpawnRate;
    private Timer _mountainSpawnTimer;

    private void Awake()
    {
        _spawnOffset = new Vector3(0, 1.5f, 0);
        
        _treeSpawnRate = 1f;
        _mountainSpawnRate = 1.5f;
        _cloudSpawnRate = 3f;
        
        _treeSpawnTimer = new Timer(_treeSpawnRate);
        _mountainSpawnTimer = new Timer(_mountainSpawnRate);
        _cloudSpawnTimer = new Timer(_cloudSpawnRate);
    }

    void FixedUpdate()
    {
        if (_treeSpawnTimer.IsEnabled)
        {
            Spawn(BackGroundType.TREE);
        }
        
        else _treeSpawnTimer.UpdateTimer();

        if (_mountainSpawnTimer.IsEnabled)
        {
            Spawn(BackGroundType.MOUNTAIN);
        }
        
        else _mountainSpawnTimer.UpdateTimer();

        if (_cloudSpawnTimer.IsEnabled)
        {
            Spawn(BackGroundType.CLOUD);
        }
        
        else _cloudSpawnTimer.UpdateTimer();
        
        Despawn();
    }
    
    // 생성
    private void Spawn(BackGroundType type)
    {
        GameObject obj;
        switch (type)
        {
            case BackGroundType.TREE:
                obj = Instantiate(tree, spawnPoint.position + _spawnOffset, 
                    spawnPoint.rotation);
                _treeSpawnTimer.ResetTimer(_treeSpawnRate);
                _backGrounds.Enqueue(obj);
                break;
            case BackGroundType.MOUNTAIN :
                obj = Instantiate(mountain, spawnPoint.position + _spawnOffset + new Vector3(5.1f, 0, 0), 
                    spawnPoint.rotation);
                _mountainSpawnTimer.ResetTimer(_mountainSpawnRate);
                _backGrounds.Enqueue(obj);
                break;
            case BackGroundType.CLOUD:
                obj = Instantiate(cloud, spawnPoint.position + new Vector3(0, 4.3f,0), 
                    spawnPoint.rotation);
                _cloudSpawnTimer.ResetTimer(_cloudSpawnRate);
                _backGrounds.Enqueue(obj);
                break;
        }
    }
    
    // 삭제
    private void Despawn()
    {
        if (_backGrounds.Count == 0)
            return;
        
        GameObject obj = _backGrounds.Dequeue();

        if (obj.transform.position.x < DespawnPoint.position.x)
            Destroy(obj);
        else
            _backGrounds.Enqueue(obj);
    }
}
