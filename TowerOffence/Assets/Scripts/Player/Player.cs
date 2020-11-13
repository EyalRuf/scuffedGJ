using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] public PlayerInput pInput { get; set; }
    [SerializeField] public PlayerMovement pMovement { get; set; }
    [SerializeField] public PlayerLife pLife { get; set; }
    [SerializeField] public PlayerAttack pAttack { get; set; }
    [SerializeField] public PlayerResources pResources { get; set; }
    [SerializeField] public PlayerAnimations pAnimations { get; set; }

    // Use this for initialization
    void Start()
    {
        pInput = GetComponent<PlayerInput>();
        pMovement = GetComponent<PlayerMovement>();
        pLife = GetComponent<PlayerLife>();
        pAttack = GetComponent<PlayerAttack>();
        pResources = GetComponent<PlayerResources>();
        pAnimations = GetComponent<PlayerAnimations>();
    }
}
