using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
   // 오브젝트 생성
   public void CreateNote(NoteType noteType)
   {
       GameObject obj = Instantiate(Resources.Load<GameObject>(noteType.ToString()), transform);
       obj.GetComponent<NoteController>().type = noteType;
       
       if (noteType == NoteType.Lazer)
       {
           // 노트길이 받아와 생성
           obj.transform.position = transform.position + new Vector3(0, 0.8f, 0);
       }
       
       else if (noteType == NoteType.Bullet)
       {
           obj.transform.position = transform.position + new Vector3(0, 0.5f, 0);
       }

       else
       {
           obj.transform.position = transform.position;
       }
   }
}
