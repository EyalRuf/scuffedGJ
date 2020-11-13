using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    const string ANIM_PROP_NAME_DIR = "direction";
    const string ANIM_PROP_NAME_IS_WALKING = "isWalking";
    const string ANIM_PROP_NAME_ATTACK = "attack";
    const string ANIM_PROP_NAME_SLAP = "slap";

    Animator pAnimator;
    Player p;

    // Use this for initialization
    void Start()
    {
        pAnimator = GetComponent<Animator>();
        p = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        pAnimator.SetInteger(ANIM_PROP_NAME_DIR, p.pMovement.direction);
        pAnimator.SetBool(ANIM_PROP_NAME_IS_WALKING, p.pMovement.isWalking);
    }

    public void AttackAnimation()
    {
        pAnimator.SetTrigger(ANIM_PROP_NAME_ATTACK);
    }

    public void SlapAnimation()
    {
        pAnimator.SetTrigger(ANIM_PROP_NAME_SLAP);
    }
}
