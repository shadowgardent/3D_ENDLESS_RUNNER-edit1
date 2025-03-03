using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // ประกาศตัวแปรอ้างอิงไปยังสคริปต์ PlayerMovement
    PlayerMovement playerMovement;

    void Start()
    {
        // ค้นหา GameObject ที่มีสคริปต์ PlayerMovement และเก็บอ้างอิงไว้ในตัวแปร
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    // ฟังก์ชันนี้ทำงานเมื่อมีการชนกันระหว่างออบเจ็กต์นี้กับออบเจ็กต์อื่น
    private void OnCollisionEnter(Collision collision)
    {
        // เช็คว่าถ้าสิ่งที่ชนเป็น GameObject ที่ชื่อ "Player"
        if (collision.gameObject.name == "Player")
        {
            // เรียกใช้ฟังก์ชัน Die() ในสคริปต์ PlayerMovement เพื่อฆ่าผู้เล่น
            playerMovement.Die();
        }
    }

}
