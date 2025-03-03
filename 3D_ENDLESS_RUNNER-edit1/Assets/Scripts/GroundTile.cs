using UnityEngine;

public class GroundTile : MonoBehaviour
{
    // อ้างอิงถึงสคริปต์ GroundSpawner เพื่อให้สามารถเรียกใช้ฟังก์ชันสร้างพื้นใหม่ได้
    GroundSpawner groundSpawner;

    private void Start()
    {
        // ค้นหา GameObject ที่มีสคริปต์ GroundSpawner และเก็บอ้างอิงไว้ในตัวแปร
        groundSpawner = FindFirstObjectByType<GroundSpawner>();
    }

    // ฟังก์ชันนี้จะทำงานเมื่อวัตถุอื่นออกจาก Collider ของพื้น
    private void OnTriggerExit(Collider other)
    {
        // เรียกใช้ฟังก์ชัน SpawnTile() เพื่อสร้างพื้นใหม่ต่อจากพื้นปัจจุบัน
        groundSpawner.SpawnTile(true);

        // ทำลาย GameObject นี้ (พื้นเก่า) หลังจาก 2 วินาที
        Destroy(gameObject, 2);
    }

    // พรีแฟบของสิ่งกีดขวางที่จะใช้สร้างอุปสรรคในพื้นแต่ละแผ่น
    public GameObject obstaclePrefab;

    // ฟังก์ชันสำหรับสุ่มวางสิ่งกีดขวางบนพื้น
    public void SpawnObstacle()
    {
        // เลือกตำแหน่งแบบสุ่มจากลูกวัตถุที่อยู่บนพื้น (index 2-4)
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // สร้างสิ่งกีดขวางที่ตำแหน่งที่สุ่มได้ โดยกำหนดให้เป็นลูกของพื้น
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    // พรีแฟบของเหรียญที่จะใช้สร้างเหรียญในพื้นแต่ละแผ่น
    public GameObject coinPrefab;

    // ฟังก์ชันสำหรับสุ่มวางเหรียญบนพื้น
    public void SpawnCoins()
    {
        // จำนวนเหรียญที่จะสร้าง
        int coinsToSpawn = 4;

        // วนลูปสร้างเหรียญตามจำนวนที่กำหนด
        for (int i = 0; i < coinsToSpawn; i++)
        {
            // สร้างเหรียญใหม่บนพื้น
            GameObject temp = Instantiate(coinPrefab, transform);

            // กำหนดตำแหน่งแบบสุ่มภายใน Collider ของพื้น
            temp.transform.position = GetRandomPointIncollider(GetComponent<Collider>());
        }
    }

    // ฟังก์ชันสำหรับหาตำแหน่งแบบสุ่มภายใน Collider ของพื้น
    Vector3 GetRandomPointIncollider(Collider collider)
    {
        // สร้างตำแหน่งสุ่มภายในขอบเขตของ Collider
        Vector3 point = new Vector3
            (
                Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        // ตรวจสอบว่าจุดที่สุ่มได้อยู่ภายใน Collider หรือไม่
        if (point != collider.ClosestPoint(point))
        {
            // ถ้าไม่อยู่ภายใน ให้สุ่มตำแหน่งใหม่อีกครั้ง
            point = GetRandomPointIncollider(collider);
        }

        // กำหนดตำแหน่ง Y ของเหรียญให้อยู่ที่ระดับ 1 (ไม่ให้เหรียญลอยสูงหรือต่ำเกินไป)
        point.y = 1;

        return point;
    }
}
