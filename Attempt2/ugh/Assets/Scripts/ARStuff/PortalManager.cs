using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{
    public GameObject mainCam;

    public GameObject sponza;

    private Material[] sponzaMaterials;

	// Use this for initialization
	void Start ()
    {
        sponzaMaterials = sponza.GetComponent<Renderer>().sharedMaterials;

    }
	
	// Update is called once per frame
	void OnTriggerStay ()
    {
        Vector3 camPosInPortalSpace = transform.InverseTransformPoint(mainCam.transform.position);

        if (camPosInPortalSpace.y < 0.5f)
        {
            //disable stencile shader
            for (int i = 0; i < sponzaMaterials.Length; ++i)
            {
                sponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
        }
        else
        {
            //endisable stencile shader
            for (int i = 0; i < sponzaMaterials.Length; ++i)
            {
                sponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
        }
    }
}
