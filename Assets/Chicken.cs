using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] private Animator chickenAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chickenAnimator.SetBool("isWalking", true); // пишешь это когда курица должна воспроизводить анимацию ходьбы
        chickenAnimator.SetBool("isWalking", false); // пишешь это когда курица должна стоять
    }
}
