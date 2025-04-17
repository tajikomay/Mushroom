using UnityEngine;

public class StalkManager : MonoBehaviour
{
    public GameObject stalkPrefab;
    public GameObject bulbousPrefab;
    public GameObject clubPrefab;
    public GameObject cupPrefab;
    public GameObject equalPrefab;
    public GameObject rhizomorphsPrefab;
    public GameObject rootedPrefab;
    public GameObject ringPrefab;

    public Material brownMaterial;
    public Material buffMaterial;
    public Material cinnamonMaterial;
    public Material grayMaterial;
    public Material orangeMaterial;
    public Material pinkMaterial;
    public Material redMaterial;
    public Material whiteMaterial;
    public Material yellowMaterial;

    public GameObject CreateStalk(Vector3 position, string ssh, string sr, string scar, string scbr, string rn)
    {
        GameObject upperStalk = Instantiate(stalkPrefab, position, Quaternion.identity, transform);
        SetStalkColor(upperStalk, scar);

        GameObject lowerStalk = Instantiate(stalkPrefab, position + new Vector3(0, -0.5f, 0), Quaternion.identity, transform);
        SetStalkColor(lowerStalk, scbr);

        AttachRoot(lowerStalk, sr);

        int ringCount = GetRingCount(rn);
        AttachRings(upperStalk, lowerStalk, ringCount);

        return upperStalk;
    }

    private void SetStalkColor(GameObject stalk, string color)
    {
        Material stalkMaterial = GetStalkMaterial(color);

        if (stalkMaterial != null)
        {
            Renderer stalkRenderer = stalk.GetComponent<Renderer>();
            if (stalkRenderer != null)
            {
                stalkRenderer.material = stalkMaterial;
            }
        }
    }

    private Material GetStalkMaterial(string color)
    {
        switch (color)
        {
            case "n": return brownMaterial;
            case "b": return buffMaterial;
            case "c": return cinnamonMaterial;
            case "g": return grayMaterial;
            case "o": return orangeMaterial;
            case "p": return pinkMaterial;
            case "e": return redMaterial;
            case "w": return whiteMaterial;
            case "y": return yellowMaterial;
            default: return null;
        }
    }

    private void AttachRoot(GameObject stalk, string rootType)
    {
        GameObject rootPrefab = GetRootPrefab(rootType);
        if (rootPrefab != null)
        {
            Instantiate(rootPrefab, stalk.transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity, stalk.transform);
        }
    }

    private GameObject GetRootPrefab(string rootType)
    {
        switch (rootType)
        {
            case "b": return bulbousPrefab;
            case "c": return clubPrefab;
            case "u": return cupPrefab;
            case "e": return equalPrefab;
            case "z": return rhizomorphsPrefab;
            case "r": return rootedPrefab;
            case "?": return null;
            default: return null;
        }
    }

    private int GetRingCount(string rn)
    {
        switch (rn)
        {
            case "n": return 0;
            case "o": return 1;
            case "t": return 2;
            default: return 0;
        }
    }

    private void AttachRings(GameObject upperStalk, GameObject lowerStalk, int ringCount)
    {
        float yOffset = 0.25f;
        for (int i = 0; i < ringCount; i++)
        {
            Instantiate(ringPrefab, upperStalk.transform.position + new Vector3(0, -yOffset * (i + 1), 0), Quaternion.identity, upperStalk.transform);
        }
    }
}
