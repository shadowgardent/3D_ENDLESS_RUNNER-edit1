using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    // พรีแฟบของพื้นแต่ละแผ่น
    public GameObject groundTile;

    // ตำแหน่งที่ใช้สำหรับสร้างพื้นแผ่นต่อไป
    Vector3 nextspawnpoint;

    // ฟังก์ชันสำหรับสร้างพื้นใหม่
    public void SpawnTile(bool spawnItems)
    {
        // สร้างแผ่นพื้นใหม่ที่ตำแหน่ง nextspawnpoint
        GameObject temp = Instantiate(groundTile, nextspawnpoint, Quaternion.identity);

        // อัปเดตตำแหน่งสำหรับแผ่นพื้นถัดไป โดยอ้างอิงจากลูกวัตถุ (Child 1)
        nextspawnpoint = temp.transform.GetChild(1).transform.position;

        // ถ้า spawnItems เป็น true ให้สุ่มสร้างสิ่งกีดขวางและเหรียญบนพื้น
        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
        }
    }

    private void Start()
    {
        // วนลูปสร้างพื้นเริ่มต้นทั้งหมด 15 แผ่น
        for (int i = 0; i < 15; i++)
        {
            // สองแผ่นแรกไม่มีสิ่งกีดขวางหรือเหรียญ เพื่อให้ผู้เล่นเริ่มต้นได้ง่ายขึ้น
            if (i < 2)
            {
                SpawnTile(false);
            }
            else
            {
                // แผ่นที่เหลือมีการสุ่มวางสิ่งกีดขวางและเหรียญ
                SpawnTile(true);
            }
        }
    }
}
