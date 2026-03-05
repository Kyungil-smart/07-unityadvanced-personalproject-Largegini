using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NoteManager : MonoBehaviour
{
    private static NoteManager _instance;

    public static NoteManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindAnyObjectByType<NoteManager>();

            return _instance;
        }
    }
    
    // 생성된 노트 관리
    private Timer _spawnTimer;
    private float _spawnRate;

    private int _noteTypenum;
    
    [SerializeField] public NoteSpawner noteSpawner;
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
        
        noteSpawner.CreateNote(randomType);
        _spawnTimer.ResetTimer(_spawnRate);
    }
    // 디스폰명령

    public void DestroyNote()
    {
        
    }
}
