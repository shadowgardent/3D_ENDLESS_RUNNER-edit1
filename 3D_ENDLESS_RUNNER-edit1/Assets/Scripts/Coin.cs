using UnityEngine;

public class Coin : MonoBehaviour
{
    // ความเร็วในการหมุนของเหรียญ
    public float turnSeed = 5f;

    // ฟังก์ชันนี้ทำงานเมื่อมีวัตถุชนกับ Collider ของเหรียญ
    private void OnTriggerEnter(Collider other)
    {
        // ถ้าเหรียญชนกับสิ่งกีดขวาง (Obstacle) ให้ทำลายตัวเอง
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        // ตรวจสอบว่าวัตถุที่ชนไม่ใช่ผู้เล่น (Player) ถ้าไม่ใช่ ก็ไม่ต้องทำอะไร
        if (other.gameObject.name != "Player")
        {
            return;
        }

        // เพิ่มคะแนนให้ผู้เล่นผ่าน GameManager
        GameManager.inst.IncrementScore();

        // ทำลายเหรียญหลังจากถูกเก็บโดยผู้เล่น
        Destroy(gameObject);
    }

    void Update()
    {
        // ทำให้เหรียญหมุนตามแกน Z ตลอดเวลา
        transform.Rotate(0, 0, turnSeed * Time.deltaTime);
    }
}
