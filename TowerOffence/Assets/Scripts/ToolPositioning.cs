using UnityEngine;

public class ToolPositioning : MonoBehaviour
{
    public Transform[] toolDirPosition;
    public GameObject toolSprite;
    public PlayerMovement pMovement;
    public Tool tool;
    public GameObject toolHead;
    public GameObject toolBody;
    public float damageToScaleFactor;
    public float rangeToScaleFactor;

    // Use this for initialization
    void Start()
    {
        float toolRange = tool.range;
        float toolDmg = tool.damage;

        float headScale = toolDmg * damageToScaleFactor;
        float bodyScale = toolRange * rangeToScaleFactor;

        toolHead.transform.localScale = new Vector2(headScale, headScale);
        toolBody.transform.localScale = new Vector2(toolBody.transform.localScale.x, bodyScale);

        //toolHead.transform.localPosition = new Vector2(toolHead.transform.localPosition.x + bodyScale,
        //    toolHead.transform.localPosition.y + bodyScale);
    }

    // Update is called once per frame
    void Update()
    {
        toolSprite.transform.localPosition = toolDirPosition[pMovement.direction].localPosition;
        toolSprite.transform.rotation = toolDirPosition[pMovement.direction].rotation;
    }
}
