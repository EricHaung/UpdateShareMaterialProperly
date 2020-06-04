using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialReplace
{
    private enum ModelType
    {
        Standard,
        Fade,
        Transparent
    }
    
    private GameObject target;
    private Dictionary<Material, Material> materialMap = new Dictionary<Material, Material>();

    public MaterialReplace(GameObject _target)
    {
        target = _target;
    }

    public void UpdateModelMaterial()
    {
        if (target != null)
        {
            Renderer[] rrs = target.GetComponentsInChildren<Renderer>();

            for (int i = 0; i < rrs.Length; i++)
            {
                List<Material> materials = new List<Material>();
                for (int j = 0; j < rrs[i].sharedMaterials.Length; j++)
                {
                    if (!materialMap.ContainsKey(rrs[i].sharedMaterials[j]))
                    {
                        Material tempMaterial = null;

                        
                        switch (rrs[i].sharedMaterials[j].color.a) //Put your condition here 
                        {
                            case 1:
                                tempMaterial = MaterialFactory(ModelType.Standard);
                                materialMap.Add(rrs[i].sharedMaterials[j], tempMaterial);
                                break; 
                            case 0.5f:
                                tempMaterial = MaterialFactory(ModelType.Fade);
                                materialMap.Add(rrs[i].sharedMaterials[j], tempMaterial);
                                break; 
                            case 0:
                                tempMaterial = MaterialFactory(ModelType.Transparent);
                                materialMap.Add(rrs[i].sharedMaterials[j], tempMaterial);
                                break; 
                            default:
                                tempMaterial = MaterialFactory(ModelType.Standard);
                                materialMap.Add(rrs[i].sharedMaterials[j], tempMaterial);
                                break; 
                        }

                        materials.Add(tempMaterial);
                    }
                    else
                    {
                        materials.Add(materialMap[rrs[i].sharedMaterials[j]]);
                    }
                }

                rrs[i].sharedMaterials = materials.ToArray();
            }
        }
        else
            Debug.LogError("Target is null");
    }

    public void RestoreModelMaterial()
    {
        if (target != null)
        {
            Renderer[] rrs = target.GetComponentsInChildren<Renderer>();

            for (int i = 0; i < rrs.Length; i++)
            {
                List<Material> materials = new List<Material>();
                for (int j = 0; j < rrs[i].sharedMaterials.Length; j++)
                {
                    if (materialMap.ContainsValue(rrs[i].sharedMaterials[j]))
                    {
                        foreach (var itme in materialMap)
                        {
                            if (itme.Value == rrs[i].sharedMaterials[j])
                            {
                                materials.Add(itme.Key);
                                break;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError(rrs[i].gameObject.name + " can't find response material");
                    }
                }
                rrs[i].sharedMaterials = materials.ToArray();
            }
        }
        else
            Debug.LogError("Target is null");
    }

    private Material MaterialFactory()
    {
        Material newMaterial = null;

        //Setup New Material

        return newMaterial;
    }
}
