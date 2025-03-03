using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // อ้างอิงไปที่ตำแหน่งของผู้เล่น
    public Transform player;

    // ตัวแปรเก็บค่าระยะห่างระหว่างกล้องกับผู้เล่น
    Vector3 offset;

    void Start()
    {
        // คำนวณระยะห่างระหว่างตำแหน่งเริ่มต้นของกล้องกับผู้เล่น
        offset = transform.position - player.position;
    }

    void Update()
    {
        // กำหนดตำแหน่งใหม่ของกล้องให้ตามผู้เล่น โดยรักษาระยะห่าง (offset) ไว้
        Vector3 targetPosition = player.position + offset;

        // ทำให้กล้องอยู่ตรงกลางแกน X เสมอ (ป้องกันกล้องเคลื่อนที่ตามผู้เล่นไปทางซ้าย-ขวา)
        targetPosition.x = 0;

        // อัปเดตตำแหน่งของกล้อง
        transform.position = targetPosition;
    }
}
