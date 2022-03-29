using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour {

    //аниматор
    public Animator TrapDoorAnim; 

    void Awake()
    {
        TrapDoorAnim = GetComponent<Animator>();
        StartCoroutine(OpenCloseTrap());
    }


    IEnumerator OpenCloseTrap()
    {
        TrapDoorAnim.SetTrigger("open");
        yield return new WaitForSeconds(3);
        TrapDoorAnim.SetTrigger("close");
        yield return new WaitForSeconds(6);
        StartCoroutine(OpenCloseTrap());
    }
}