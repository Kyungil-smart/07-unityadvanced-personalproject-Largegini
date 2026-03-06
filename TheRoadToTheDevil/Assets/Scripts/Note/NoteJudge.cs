using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NoteJudge : MonoBehaviour
{
    public float perfectHitDis;
    public float greatHitDis;
    public float goodHitDis;
    
    [SerializeField]private List<GameObject> _activeNotes;

    private void Awake()
    {
        perfectHitDis = 0.15f;
        greatHitDis = 0.3f;
        goodHitDis = 0.5f;
        
        _activeNotes = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.CompareTag("Note")) _activeNotes.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_activeNotes.Contains(other.gameObject))
        {
            _activeNotes.Remove(other.gameObject);
            // Miss
            // 플레이어 체력 감소
        }
    }
    public void ExecuteJudgment(PStateAnimIndex state)
    {
        if (_activeNotes.Count == 0) return;
        
        // 판정선에 가장 가까운 노트를 타겟팅
        GameObject target = _activeNotes[0];
        if ((int)state == (int)target.GetComponent<NoteController>().type)
        {
            float distance = Mathf.Abs(target.transform.position.x - transform.position.x);
            string result = CalculateGrade(distance);
            Debug.Log($"판정: {result} / 거리: {distance}");
            NoteManager.Instance.DestroyNote(target); 
            _activeNotes.RemoveAt(0);
        }

        else
        {
            // Miss
            // 플레이어 체력 감소
        }

    }

    private string CalculateGrade(float dist)
    {
        if (dist <= perfectHitDis) return "Perfect";
        if (dist <= greatHitDis) return "Great";
        if (dist <= goodHitDis) return "Good";
        return "Bad";
    }
    
    
}
