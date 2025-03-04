using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // ตัวแปรที่ใช้เช็คว่ายังมีชีวิตอยู่มั้ย
    bool alive = true;

    // ความเร็วในการเคลื่อนที่ของตัวละคร
    public float speed = 5;

    public Rigidbody rb;
    
    float horizontalInput;

    // ค่าตัวคูณสำหรับการควบคุมการเคลื่อนที่ด้านข้าง
    public float horizontalMultiplier = 2;

    // ค่าที่ใช้เพิ่มความเร็วเมื่อผู้เล่นได้คะแนน
    public float speedIncreasePerPoint = 0.1f;

    public GameManager gameManager;


    private void FixedUpdate()
    {
        // ถ้าผู้เล่นตายแล้ว ให้หยุดการทำงาน
        if (!alive) return;

        // คำนวณการเคลื่อนที่ไปข้างหน้าตามความเร็วที่กำหนด
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;

        // คำนวณการเคลื่อนที่ไปทางซ้ายหรือขวาตามอินพุตที่ได้รับ
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;

        // ทำให้ Rigidbody เคลื่อนที่ไปตามค่าที่คำนวณ
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Update()
    {
        // รับค่าการกดปุ่มซ้าย-ขวา (A, D หรือ ปุ่มลูกศร)
        horizontalInput = Input.GetAxis("Horizontal");

        // ถ้าผู้เล่นตกจากพื้นไปต่ำกว่าระดับ -5 ให้ตาย
        if (transform.position.y < -5)
        {   
            
            Die();
            alive = false;
        }
    }

    // ฟังก์ชันผู้เล่นตาย
    public void Die()
    {
        // กำหนดค่า alive เป็น false เพื่อหยุดการเคลื่อนที่
        alive = false;
        
        gameManager.gameOver();

        
    }

}
