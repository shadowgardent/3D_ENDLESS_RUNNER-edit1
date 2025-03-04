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
        // ตรวจสอบว่ามี AudioManager อยู่แล้วหรือไม่
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ป้องกันการทำลายเมื่อเปลี่ยนฉาก
        }
        else
        {
            Destroy(gameObject); // ถ้ามีอยู่แล้ว ให้ทำลายตัวใหม่
            return;
        }

        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded; // เมื่อโหลดฉากใหม่ให้เรียกฟังก์ชันนี้
    }

    private void Start()
    {
        PlayMusic(); // เริ่มเล่นเพลงเมื่อเริ่มเกม
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // เมื่อโหลดฉากใหม่ ตรวจสอบว่า AudioSource ยังอยู่ และเล่นเพลงอีกครั้ง
        if (audioSource != null)
        {
            PlayMusic();
        }
    }

    public void PlayMusic()
    {
            if (audioSource == null) return;
            audioSource.clip = allGameMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayDieSound()
    {
        if (audioSource == null) return;
        audioSource.Stop(); // หยุดเพลงหลักก่อน
        audioSource.PlayOneShot(dieSound); // เล่นเสียงเมื่อตาย
    }

    public void PlayCoinSound()
    {
        if (audioSource == null) return;
        audioSource.PlayOneShot(coinSound); // เล่นเสียงเก็บเหรียญ
    }
}
