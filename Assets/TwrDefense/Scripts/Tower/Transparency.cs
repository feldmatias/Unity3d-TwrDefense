using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{

    public float transparency = 0.5f;
    private MeshRenderer[] meshRenderers;

    private void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    public void SetTransparent()
    {
        SetMaterialTransparent();
    }

    public void UnsetTransparent()
    {
        SetMaterialOpaque();
    }

    private void SetMaterialTransparent()
    {
        foreach (var meshRenderer in meshRenderers)
        {
            foreach (Material material in meshRenderer.materials)
            {
                material.SetFloat("_Mode", 2);
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;

                var color = material.color;
                color.a = transparency;
                material.color = color;
            }
        }
    }

    private void SetMaterialOpaque()
    {
        foreach (var meshRenderer in meshRenderers)
        {
            foreach (Material material in meshRenderer.materials)
            {
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;
            }
        }
    }
}
