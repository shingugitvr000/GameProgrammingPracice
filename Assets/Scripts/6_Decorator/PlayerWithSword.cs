using UnityEngine;

public class PlayerWithSword : MonoBehaviour
{
    private SwordForge forge;

    void Start()
    {
        forge = FindObjectOfType<SwordForge>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            forge?.TestAttack();
        }
    }
}