using UnityEngine;

public class CapManager : MonoBehaviour
{
    public GameObject bellPrefab;
    public GameObject convexPrefab;
    public GameObject conicalPrefab;
    public GameObject flatPrefab;
    public GameObject knobbedPrefab;
    public GameObject sunkenPrefab;

    public Material brownMaterial;
    public Material buffMaterial;
    public Material cinnamonMaterial;
    public Material grayMaterial;
    public Material greenMaterial;
    public Material pinkMaterial;
    public Material purpleMaterial;
    public Material redMaterial;
    public Material whiteMaterial;
    public Material yellowMaterial;

    public GameObject CreateCap(Vector3 position, string capType, string color)
    {
        GameObject capPrefab = GetCapPrefab(capType);

        if (capPrefab != null)
        {
            GameObject cap = Instantiate(capPrefab, position, Quaternion.identity, transform);
            Material capMaterial = GetCapMaterial(color);

            if (capMaterial != null)
            {
                Renderer capRenderer = cap.GetComponent<Renderer>();
                if (capRenderer != null)
                {
                    capRenderer.material = capMaterial;
                }
            }

            // Adjust cap position based on capType
            AdjustCapPosition(cap, capType);

            return cap;
        }

        return null;
    }

    private void AdjustCapPosition(GameObject cap, string capType)
    {
        // Example adjustments based on capType
        switch (capType)
        {
            case "b": // Bell-shaped cap
                cap.transform.position += new Vector3(0, 0.3f, 0);
                break;
            case "x": // Convex cap
                cap.transform.position += new Vector3(0, -1.1f, 0);
                break;
            case "c": // Conical cap
                cap.transform.position += new Vector3(0, 0, 0);
                break;
            case "f": // Flat cap
                cap.transform.position += new Vector3(0, 0.2f, 0);
                break;
            case "k": // Knobbed cap
                cap.transform.position += new Vector3(0, 0, 0);
                break;
            case "s": // Sunken cap
                cap.transform.position += new Vector3(0, 1f, 0);
                break;
            default:
                break;
        }
    }

    private GameObject GetCapPrefab(string capType)
    {
        switch (capType)
        {
            case "b": return bellPrefab;
            case "x": return convexPrefab;
            case "c": return conicalPrefab;
            case "f": return flatPrefab;
            case "k": return knobbedPrefab;
            case "s": return sunkenPrefab;
            default: return null;
        }
    }

    private Material GetCapMaterial(string color)
    {
        switch (color)
        {
            case "n": return brownMaterial;
            case "b": return buffMaterial;
            case "c": return cinnamonMaterial;
            case "g": return grayMaterial;
            case "r": return greenMaterial;
            case "p": return pinkMaterial;
            case "u": return purpleMaterial;
            case "e": return redMaterial;
            case "w": return whiteMaterial;
            case "y": return yellowMaterial;
            default: return null;
        }
    }
}
