using System;
using System.Runtime.InteropServices;

namespace RP.ScoutRobot.Common
{
    /// <summary>
    /// 结构体到Byte数组转换
    /// </summary>
    public static class MarshalHelper
    {
        /// <summary>
        /// 结构体转数组
        /// </summary>
        /// <param name="structObj"></param>
        /// <returns></returns>
        public static byte[] StructToBytes(object structObj)
        {

            int size = Marshal.SizeOf(structObj);//得到结构提的大小
            byte[] bytes = new byte[size];//创建数组
                                          //分配结构体大小的空间内存
            IntPtr structPut = Marshal.AllocHGlobal(size);
            //将结构体拷贝到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPut, false);
            //从内存空间拷贝到数组
            Marshal.Copy(structPut, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPut);
            //返回bytes
            return bytes;

        }
        /// <summary>
        /// byte数组转结构体
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T BytesToStruct<T>(byte[] bytes)where T:struct
        {
            //得到结构体的大小
            var type =typeof(T);
            int size = Marshal.SizeOf(type);
            //byte数组长度小于结构体的大小
            if (size > bytes.Length)
            {

                //返回空
                return default;

            }
            //分配结构体的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷贝到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回结构体
            return (T)obj;
        }
        /// <summary>
        /// 计算校验和
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte DataCheck(byte[] data)
        {
            int crc = 0;
            for (int i = 0; i < data.Length - 1; i++)
            {
                crc += data[i];
            }

            return (byte)(crc % 256);
        }
    }
}
