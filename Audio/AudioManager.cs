// using UnityEngine;  
// using UnityEngine.Audio;
//
// public class AudioManager : MonoBehaviour
// {
//     public static AudioManager instance { get; private set; }
//     public AudioSource soundAudio;
//     public AudioSource musicAudio;
//
//     private void Start()
//     {
//         instance = this;
//     }
//     /// <summary>
//     /// 按钮特效音
//     /// </summary>
//     /// <param name="soundPath"></param>
//     public void PlaySound(string soundPath)
//     {
//         soundAudio.PlayOneShot(Resources.Load<AudioClip>("Assets/Video/" + soundPath));
//     }
//     /// <summary>
//     /// 背景音乐
//     /// </summary>
//     /// <param name="musicPath"></param>
//     /// <param name="loop"></param>
//     public void PlayMusic(string musicPath, bool loop = true)
//     {
//         musicAudio.loop = loop;
//         musicAudio.clip = Resources.Load<AudioClip>("Assets/Video/" + musicPath);
//         musicAudio.Play();
//     }
//
//     public void StopMusic()
//     {
//         musicAudio.Stop();
//     }
//     
// }