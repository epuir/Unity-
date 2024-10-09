using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dTest : MonoBehaviour
{
   [SerializeField]
   private GameObject show;

   private Material materal;
   
   private AudioSource[] audios;
   private bool IsSuccess = false;
   int temp = 0;
   private int P_num = 0;

   private float stime = 0.4f;
   private float begoreplay_time = 0.05f;
   private float afterplayer_time = 0.1f;
   private int times = 7;
   
   private void Start()
   {
      materal = show.GetComponent<MeshRenderer>().material;
      
      
      audios = GameObject.Find("YX").transform.GetComponents<AudioSource>();
      audios[1].Play();
      StartCoroutine(TestPlaytimes(stime,begoreplay_time,afterplayer_time,times));
      Debug.Log(audios.Length);

      LinkedList<int> a = new LinkedList<int>();
   }


   private void Update()
   {
      
      
      //Debug.LogWarning(IsSuccess);
      if (Input.GetMouseButtonDown(0))
      {
         if (IsSuccess)
         {
            audios[0].Play();
            Debug.LogWarning("成功");
         }
         else
         {
            audios[2].Play();
            Debug.LogError("失败");
         }
         
      }
   }


   /// <summary>
   /// 表示一个接节拍
   /// </summary>
   /// <param name="stime">每一次判定和音效的间隔时间</param>
   /// <param name="beforeplayer_time">播放前的判定时间</param>
   /// <param name="afterplayer_time">播放后的延后判定时间</param>
   /// <param name="times">一次的次数</param>
   /// <returns></returns>

   IEnumerator TestPlaytimes(float stime, float beforeplayer_time,float afterplayer_time,int times)
   {
      while (true)
      {
         yield return StartCoroutine(Playtimes(stime, beforeplayer_time, afterplayer_time, times));
         
      }
   }
   IEnumerator Playtimes(float stime, float beforeplayer_time,float afterplayer_time,int times)
   {
      Debug.Log("开始尝试");
      while (temp<times)
      {
         yield return StartCoroutine(StartPlay(stime,beforeplayer_time,afterplayer_time));
         temp++;
      }
      Debug.Log("结束尝试");
      temp = 0;
   }
   
   
   
   
   /// <summary>
   /// 一个节拍加区间
   /// </summary>
   /// <param name="stime"></param>
   /// <param name="ptime"></param>
   /// <returns></returns>
   IEnumerator StartPlay(float stime,float beforeplayer_time,float afterplayer_time)
   {
      // if (temp == 3)
      // {
         yield return StartCoroutine(Play(beforeplayer_time, afterplayer_time));
      //    temp = 0;
      // }
      yield return new WaitForSeconds(stime);
   }
   
   /// <summary>
   /// 一次判定
   /// </summary>
   /// <param name="ptime">判定区时间</param>
   /// <returns></returns>
   IEnumerator Play(float beforeplayer_time,float afterplayer_time)
   {
     // if(temp == 6)
      IsSuccess = true;
      materal.color = Color.blue;
      Debug.Log("开始判断");
      yield return new WaitForSeconds(beforeplayer_time);
      audios[2].Play();
      yield return new WaitForSeconds(afterplayer_time);
      Debug.Log("结束判断");
      IsSuccess = false;
      materal.color = Color.red;
      
   }
}
