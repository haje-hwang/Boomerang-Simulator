using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoverOutline : MonoBehaviour
{
    public Material Outline;
    private Material[] Original_Mat;

    private Renderer[] childs_renderer;
    private void Awake()
    {
        childs_renderer = new Renderer[transform.childCount];
        Original_Mat = new Material[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).TryGetComponent<Renderer>(out childs_renderer[i]);
            Original_Mat[i] = childs_renderer[i].material;
        }
    }
    public void DrawOutline()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            // if(!Original_Mat[i].Equals(childs_renderer[i].material) && !Original_Mat[i].Equals(Outline))
            // {
            //     Original_Mat[i] = childs_renderer[i].material;
            // }
            childs_renderer[i].material = Outline;
        }        
    }

    public void EraseOutline()
    {
        if(!Original_Mat.Equals(null))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                childs_renderer[i].material = Original_Mat[i];
            }  
        }
    }
}
