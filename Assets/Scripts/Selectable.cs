using UnityEngine;

public class Selectable : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        Unselect();
    }
    
    public void Selected()
    {
        anim.SetBool("selected", true);
    }
    public void Unselect()
    {
        anim.SetBool("selected", false);
    }
}
