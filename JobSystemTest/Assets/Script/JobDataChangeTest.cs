using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

public struct MyDataJob : IJob
{
    public float a;
    public float b;
    public NativeArray<float> result;
    public void Execute()
    {
        // Debug.LogFormat("wtf 开始执行Ijob {0}",a+b);
        result[0] = (a+b);
    }
}

public class JobDataChangeTest : MonoBehaviour
{
    void Start()
    {
        //安全性系统中拷贝数据的缺点是单个job的计算结果是与外部隔离的。为了突破这个限制，我们需要把结果放在一种共享内存——NativeContainer中
        //既是值类型，又有引用类型的特点，主线程跟Job线程都可以访问
        //NativeContainer是一种非托管数据类型,使用完必须调用Dispose释放掉，否则会造成内存泄漏

        NativeArray<float> result = new NativeArray<float>(1, Allocator.TempJob);

        MyDataJob jobData = new MyDataJob();
        jobData.a = 10;
        jobData.b = 10;
        jobData.result = result;
        JobHandle handle = jobData.Schedule();                  //调度，决定job放到哪些工人线程去执行。
        handle.Complete();                                      //真正执行job里面的代码。

        Debug.LogFormat("wtf 执行最终结果  {0}",result[0]);

        result.Dispose();
    }

}
