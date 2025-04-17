using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class GameManager : MonoBehaviour
{
    public CapManager capManager;
    public GillManager gillManager;
    public StalkManager stalkManager;

    public TextAsset csvFile; // CSVファイルをインスペクターから指定
    public Vector3 startPosition;
    public float spacing; // グリッド間隔
    public int gridColumns;

    private void Start()
    {
        List<MushroomData> mushroomDataList = ParseCSV(csvFile.text);

        for (int i = 0; i < mushroomDataList.Count; i++)
        {
            MushroomData data = mushroomDataList[i];
            Vector3 position = startPosition + new Vector3((i % gridColumns) * spacing, 0, (i / gridColumns) * spacing);

            // Stalkを生成
            GameObject stalk = stalkManager.CreateStalk(position, data.ssh, data.sr, data.scar, data.scbr, data.rn);

            // Capを生成
            GameObject cap = capManager.CreateCap(position + new Vector3(0, 0.5f, 0), data.capType, data.capColor);

            // Gillを生成
            gillManager.PlaceGills(position + new Vector3(0, 0.5f, 0), data.ga, data.gc, data.gsp, data.gsi);
        }
    }

    private List<MushroomData> ParseCSV(string csvText)
    {
        List<MushroomData> mushroomDataList = new List<MushroomData>();
        StringReader reader = new StringReader(csvText);
        bool firstLine = true;

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            if (firstLine)
            {
                firstLine = false;
                continue; // ヘッダー行をスキップ
            }

            string[] columns = line.Split(',');

            // CSVからデータを取り出し、MushroomDataオブジェクトを作成
            MushroomData data = new MushroomData
            {
                capType = columns[2],   // csh
                capColor = columns[4],  // cc
                ga = columns[7],        // ga
                gsp = columns[8],       // gsp
                gsi = columns[9],       // gsi
                gc = columns[10],        // gc
                ssh = columns[11],      // ssh
                sr = columns[12],       // sr
                scar = columns[15],     // scar
                scbr = columns[16],     // scbr
                rn = columns[19]        // rn
            };

            mushroomDataList.Add(data);
        }

        return mushroomDataList;
    }
}

[System.Serializable]
public class MushroomData
{
    public string capType;
    public string capColor;
    public string ga;
    public string gsp;
    public string gsi;
    public string gc;
    public string ssh;
    public string sr;
    public string scar;
    public string scbr;
    public string rn;
}
