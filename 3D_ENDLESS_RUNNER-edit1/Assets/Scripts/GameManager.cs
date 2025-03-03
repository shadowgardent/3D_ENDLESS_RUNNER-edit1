using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //  เก็บคะแนนของผู้เล่น
    public int score;

    //  สร้างตัวแปรแบบ Static เพื่อให้สามารถเข้าถึง GameManager ได้จากที่อื่นในโค้ด
    public static GameManager inst;

    //  ตัวแปรอ้างอิงไปที่ UI Text สำหรับแสดงคะแนน
    public Text scoreText;

    //  ตัวแปรอ้างอิงไปที่สคริปต์ PlayerMovement เพื่อเพิ่มความเร็วเมื่อได้คะแนน
    public PlayerMovement playerMovement;

    //  ตัวแปรสำหรับเก็บ UI จบเกม
    public GameObject GameOverUi;
    

    //  ฟังก์ชันเพิ่มคะแนน
    public void IncrementScore()
    {
        //  เพิ่มค่าคะแนนขึ้นทีละ 1
        score++;

        //  อัปเดตค่าแสดงผลคะแนนใน UI
        scoreText.text = "score: " + score;

        //  เพิ่มความเร็วของผู้เล่นทุกครั้งที่ได้คะแนน
        playerMovement.speed += playerMovement.speedIncreasePerPoint;

        //  เช็คว่าถ้าคะแนนถึง 40 ให้จบเกม
        if (score >= 40)
        {
            gameWin();
        }
    }

    //  ฟังก์ชันแสดง UI จบเกม และหยุดเกม
    public void gameOver()
    {
        GameOverUi.SetActive(true); // แสดง UI จบเกม
        Time.timeScale = 0f; // หยุดเกม
    }
     //  ฟังก์ชันแสดง UI จบเกม และหยุดเกม หากชนะ
    public void gameWin()
    {
        SceneManager.LoadScene("Win");
        
    }

    //  ฟังก์ชันรีสตาร์ทเกม
    public void restart()
    {
        
        Time.timeScale = 1f; // ทำให้เกมกลับมาเล่นได้
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //  ฟังก์ชันกลับไปที่เมนูหลัก
    public void mainmenu()
    {
        Time.timeScale = 1f; // ทำให้เกมกลับมาเล่นได้
        SceneManager.LoadSceneAsync(0);
    }

    //  ฟังก์ชันออกจากเกม
    public void Quit()
    {
        Application.Quit();
    }

    //  ฟังก์ชัน Awake ทำงานก่อน Start และใช้กำหนดค่า Singleton
    private void Awake()
    {
        //  กำหนดให้ inst เป็นอ็อบเจ็กต์ GameManager ปัจจุบัน เพื่อให้สามารถเรียกใช้งานจากที่อื่นได้
        inst = this;
    }
}
