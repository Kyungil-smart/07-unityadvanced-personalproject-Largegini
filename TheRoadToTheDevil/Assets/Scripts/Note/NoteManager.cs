using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NoteManager : MonoBehaviour
{
    private static NoteManager _noteManager;

    public static NoteManager Instance()
    {
        if (_noteManager == null)
            _noteManager = new NoteManager();
        return _noteManager;
    }
    
    // 생성된 노트 관리
    private Timer _spawnTimer;
    private float _spawnRate;

    private int _noteTypenum;
    
    [SerializeField] public NoteSpawner _noteSpawner;
    // 스폰 명령

    private void Awake()
    {
        _spawnRate = 3f;
        _spawnTimer = new Timer(_spawnRate);
        
        _noteTypenum = Enum.GetNames(typeof(NoteType)).Length;
    }

    private void FixedUpdate()
    {
        if (_spawnTimer.IsEnabled)
            SpawnNote();
        
        else
            _spawnTimer.UpdateTimer();  
    }


    public void SpawnNote()
    {
        // 조건
        NoteType randomType = (NoteType)Random.Range(0, _noteTypenum);
        
        _noteSpawner.CreateNote(randomType);
        _spawnTimer.ResetTimer(_spawnRate);
    }
    // 디스폰명령

    public void DestroyNote()
    {
        
    }
}
