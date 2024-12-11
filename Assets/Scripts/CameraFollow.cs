using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // הדמות
    public float smoothSpeed = 0.125f; // מהירות הסחיבה של המצלמה
    public Vector3 offset;  // מרחק מהמקום שבו תעמוד המצלמה

    void Start()
    {
        // אם לא הגדרת offset ב-Inspector, תוכל להגדיר אותו כאן
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 5f, -10f);  // דוגמה למיקום המצלמה
        }
    }

    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;

        // אם הדמות עברה את חצי המסך (y=0 זה חצי המסך)
        if (player.position.y > 0)
        {
            // עדכון מיקום המצלמה כך שתעבור עם הדמות
            targetPosition.y = player.position.y + offset.y;
        }

        // הזזת המצלמה בצורה חלקה אחרי הדמות
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
