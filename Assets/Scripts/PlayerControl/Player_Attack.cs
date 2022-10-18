using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player_Attack : MonoBehaviour
{
    [SerializeField] private InputAction playerAttack;
    [SerializeField] private Animator playerAnimator;

    private void OnEnable()
    {
        playerAttack.Enable();
        PlayerBlackboard.Instance.isAttacking = false;
    }
    //OnDisable, Note: requisite for Unity Input System
    private void OnDisable()
    {
        playerAttack.Disable();
        PlayerBlackboard.Instance.isAttacking = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerBlackboard.Instance.isAttacking = !(playerAttack.enabled && playerAnimator != null);
    }

    // Update is called once per frame
    void Update()
    {

        PlayerBlackboard.Instance.isAttacking = playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("ATTACK");
        
        if(!PlayerBlackboard.Instance.isAttacking && (playerAttack.ReadValue<float>() > 0)){
            playerAnimator.SetTrigger("AttackTrigger");
        }
    }
}
