using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
   // 오브젝트 생성
   public void CreateNote(NoteType noteType)
   {
          //Debug.Log(noteType.ToString());
          GameObject obj = Instantiate(Resources.Load<GameObject>(noteType.ToString()), transform);
          obj.transform.position = transform.position;
   }
}
