using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class SortingLayerAdjustor : MonoBehaviour
{
    Transform t;
    SpriteRenderer sr;
    public Player p1;
    public Player p2;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        if (p1 == null)
        {
            Player[] pArr = FindObjectsOfType<Player>();
            if (pArr.Length > 1)
            {
                p1 = pArr[0];
                p2 = pArr[1];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p1Pos = p1.transform.position;
        Vector2 p2Pos = p2.transform.position;
        Vector2 myPos = t.position;
        Vector2 posToSortWith = p1Pos;

        float dis1 = Vector2.Distance(myPos, p1Pos);
        float dis2 = Vector2.Distance(myPos, p2Pos);

        if (dis1 < dis2)
        {
            posToSortWith = p1Pos;
        } 

        if (posToSortWith.y > myPos.y)
        {
            sr.sortingOrder = 10;
        } else
        {
            sr.sortingOrder = 0;
        }
    }
}
