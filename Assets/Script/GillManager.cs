using UnityEngine;

public class GillManager : MonoBehaviour
{
    public GameObject attachedPrefab;
    public GameObject descendingPrefab;
    public GameObject freePrefab;
    public GameObject notchedPrefab;

    public Material blackMaterial;
    public Material brownMaterial;
    public Material buffMaterial;
    public Material chocolateMaterial;
    public Material grayMaterial;
    public Material greenMaterial;
    public Material orangeMaterial;
    public Material pinkMaterial;
    public Material purpleMaterial;
    public Material redMaterial;
    public Material whiteMaterial;
    public Material yellowMaterial;

    public float gillRadius;

    public void PlaceGills(Vector3 capPosition, string ga, string gc, string gsp, string gsi)
    {
        int numberOfGills = GetNumberOfGills(gsp);

        for (int i = 0; i < numberOfGills; i++)
        {
            float angle = -i * Mathf.PI * 2 / numberOfGills;  // 角度を反対方向に変更

            // 回転を設定
            Quaternion rotation = Quaternion.Euler(0, angle * Mathf.Rad2Deg, 0);

            // 回転を反映させた位置を計算
            Vector3 offset = new Vector3(0, 0, -gillRadius); // 初期位置は中心からradiusだけ離れた位置
            Vector3 rotatedOffset = rotation * offset; // 回転を適用

            // 最終位置を計算
            Vector3 position = capPosition + rotatedOffset;

            GameObject gillPrefab = GetGillPrefab(ga);
            GameObject gill = Instantiate(gillPrefab, position, rotation, transform);

            // サイズの設定: プレハブのサイズをそのまま使用する
            gill.transform.localScale = new Vector3(0.01f, 0.1f, 0.3f); // 必要に応じて調整

            // マテリアルの設定
            Renderer renderer = gill.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = GetGillMaterial(gc);
            }
            else
            {
                Debug.LogWarning("Renderer component not found on gill prefab.");
            }
        }
    }

    private int GetNumberOfGills(string gsp)
    {
        switch (gsp)
        {
            case "c": return 45;    // close
            case "w": return 30;     // crowded
            case "d": return 15;     // distant
            default: return 5;     // デフォルト値
        }
    }

    private GameObject GetGillPrefab(string ga)
    {
        switch (ga)
        {
            case "a": return attachedPrefab;
            case "d": return descendingPrefab;
            case "f": return freePrefab;
            case "n": return notchedPrefab;
            default: return null;
        }
    }

    private Material GetGillMaterial(string gc)
    {
        switch (gc)
        {
            case "k": return blackMaterial;
            case "n": return brownMaterial;
            case "b": return buffMaterial;
            case "h": return chocolateMaterial;
            case "g": return grayMaterial;
            case "r": return greenMaterial;
            case "o": return orangeMaterial;
            case "p": return pinkMaterial;
            case "u": return purpleMaterial;
            case "e": return redMaterial;
            case "w": return whiteMaterial;
            case "y": return yellowMaterial;
            default: return null;
        }
    }
}
