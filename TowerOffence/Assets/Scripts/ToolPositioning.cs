using UnityEngine;
using System.Collections;

public class ToolPositioning : MonoBehaviour
{
    public Transform[] toolDirPosition;
    public GameObject toolSprite;
    public PlayerMovement pMovement;
    public Tool tool;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        toolSprite.transform.position = toolDirPosition[pMovement.direction].position;
        toolSprite.transform.rotation = toolDirPosition[pMovement.direction].rotation;
    }
}
