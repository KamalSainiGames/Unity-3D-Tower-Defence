using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;
    private void Awake()
    {
        points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
    //to check line 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(
                transform.GetChild(i).position,
                transform.GetChild(i + 1).position);
        }
    }
}
