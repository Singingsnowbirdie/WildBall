using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//остров с анимациями (задание 2)

public class Island : MonoBehaviour
{
    /// <summary>
    /// Аниматор
    /// </summary>
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Запускает рандомную анимацию
    /// </summary>
    public void ChangeAnimation()
    {
        int n = Random.Range(0, 3);
        switch (n)
        {
            case 0:
                anim.SetTrigger("Trigger_01");
                break;
            case 1:
                anim.SetTrigger("Trigger_02");
                break;
            case 2:
                anim.SetTrigger("Trigger_03");
                break;
        }
    }
}
