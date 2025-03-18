using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // สร้าง Singleton เพื่อให้มีเพียง AudioManager ตัวเดียวในเกม
    public static AudioManager instance;

    // เก็บไฟล์เสียงต่าง ๆ ที่ใช้ในเกม
    public AudioClip allGameMusic;
    public AudioClip dieSound;
    public AudioClip coinSound;

    private AudioSource audioSource;

    private void Awake()
    {      
        instance = this;
        
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded; // เมื่อโหลดฉากใหม่ให้เรียกฟังก์ชันนี้
    }

    private void Start()
    {
        PlayMusic(); // เริ่มเล่นเพลงเมื่อเริ่มเกม
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) // เมื่อฉากใหม่ถูกโหลด ฟังก์ชันนี้จะถูกเรียกอัตโนมัติ

    {
        // เมื่อโหลดฉากใหม่ ตรวจสอบว่า AudioSource ยังอยู่ และเล่นเพลงอีกครั้ง
        if (audioSource != null) //ถ้า audioSource ไม่เป็น null หมายความว่า มันยังอยู่ และสามารถเรียก PlayMusic(); เพื่อเล่นเพลงได้
        {
            PlayMusic();
        }
    }

    public void PlayMusic()
    {          
        audioSource.clip = allGameMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayDieSound()
    {    
        audioSource.Stop(); // หยุดเพลงหลักก่อน
        audioSource.PlayOneShot(dieSound); // เล่นเสียงเมื่อตาย
    }

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinSound); // เล่นเสียงเก็บเหรียญ
    }
}
