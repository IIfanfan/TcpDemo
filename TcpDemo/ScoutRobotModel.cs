using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace RP.ScoutRobot.Communication
{
    /// <summary>
    /// 通信命令枚举
    /// </summary>
    public enum CommandEnum
    {
        /// <summary>
        /// 机器人初始化
        /// </summary>
        RobotInit = 1,
        /// <summary>
        /// 读取机器人配置
        /// </summary>
        ReadConfig = 2,
        /// <summary>
        /// 下发机器人配置
        /// </summary>
        DownloadConfig = 3,
        /// <summary>
        /// 读取机器人运动状态
        /// </summary>
        ReadRobotRunStatus = 4,
        /// <summary>
        /// 读取机器人软件状态
        /// </summary>
        ReadRobotSoftWareStatus = 5,
        /// <summary>
        /// 机器人控制
        /// </summary>
        RobotControl = 12,
        /// <summary>
        /// 设置机器人速度
        /// </summary>
        SetRobotSpeed = 13,
        /// <summary>
        /// 读取云台数据
        /// </summary>
        ReadCloudPlateInfo = 14,
        /// <summary>
        /// 云台控制
        /// </summary>
        CloudPlateControl = 15,
        /// <summary>
        /// 读取云台运行信息
        /// </summary>
        ReadCloudPlateRunInfo=17,
        /// <summary>
        /// 创建地图
        /// </summary>
        CreateMap = 21,
        /// <summary>
        /// 上传地图
        /// </summary>
        UploadMap = 22,
        /// <summary>
        /// 启动任务
        /// </summary>
        StartTask = 23,
        /// <summary>
        /// 下发地图
        /// </summary>
        DownLoadMap = 24,
        /// <summary>
        /// 任务控制
        /// </summary>
        TaskControl=25,
        /// <summary>
        /// 读取可见光摄像头信息
        /// </summary>
        ReadNormalCameraConfig = 52,
        /// <summary>
        /// 读取红外光摄像头信息
        /// </summary>
        ReadInfraredCameraConfig = 53,
        /// <summary>
        /// 读表
        /// </summary>
        ReadMeter = 54,
        /// <summary>
        /// 拍照
        /// </summary>
        PhotoGraph = 55,
        /// <summary>
        /// 测温
        /// </summary>
        MeasureTemperature = 56,
        /// <summary>
        /// 读取读表结果
        /// </summary>
        ReadMeterResult=57,
        /// <summary>
        /// 上传停泊点巡检信息
        /// </summary>
        UploadTaskMapPoint = 71,
        /// <summary>
        /// 上传动作巡检信息
        /// </summary>
        UploadTaskAction = 72,
        /// <summary>
        /// 上传报警信息
        /// </summary>
        UploadTaskAlarm = 73,
        /// <summary>
        /// 上传结果
        /// </summary>
        UploadResult = 81,
        /// <summary>
        /// 下发任务数据（只是上位机使用，没有具体交互接口）
        /// </summary>
        DownLoadTaskRunInfoFile=101
    }

    #region 机器人初始化参数

    /// <summary>
    /// 机器人初始化下发参数
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RobotInitConfig
    {
        public float Speed_L;//线速度
    }
    #endregion

    #region 机器人配置

    /// <summary>
    /// 机器人配置
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RobotConfig
    {
        public float Speed_L;//线速度
    }

    #endregion

    #region 读取运行状态模型

    /// <summary>
    /// 读取机器人运行状态结构
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RobotRunStatus
    {
        public byte CarState;//运行状态，0-正常，1-异常，2-充电，3-避障，4-防跌落
        public byte CarControlModel;//控制模式，0-手动，1-can总线，2-Uart
        public float BaterVolt;//电池电压
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] ExceptInfo;//故障信息
        public float SpeedL;//线速度
        public float SpeedW;//角速度
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public MotorInfo[] MotorInfo;//电机数据
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public LightInfo[] LightInfo;//灯光信息
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Laser;//激光雷达传感器状态
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Ultrasonic;//超声波传感器状态
        public byte Touch;//碰撞传感器状态
        public byte Radar;//激光雷达传感器状态
        public byte NetCollecter;//采集板卡状态
        public byte Power;//电源状态
        public byte CloudPlateForm;//云台状态
        public byte NormalCamera;//可见光相机状态
        public byte InfraredCamera;//红外光相机状态
    }
    //底盘信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MotorInfo
    {
        public float Amper;//电流
        public float Rpm;//转速
        public float Temp;//温度
    }

    //灯光信息
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LightInfo
    {
        public byte Brightness;//亮度
        public byte BrghtMode;//模式，0-常开，1-关闭，2-呼吸，3-自定义
    }
    #endregion

    #region 读取软件状态

    /// <summary>
    /// 机器人软件状态
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SoftWareStatus
    {
        public byte NormalCameraNet;//视觉模块状态
        public byte InfraredCameraNet;//测温模块状态
        public byte VoiceStatus;//语音模块
        public byte RosNode;//Ros节点状态
        public byte MapUpLoadState;//是否有地图上传
        public byte TaskAlarm;//任务报警上传
        public byte TaskValueState;//巡检数据上传
        public int MapId;//地图Id,0-没有地图，-1正在生成地图
        public float LocationX;//X坐标
        public float LocationY;//Y坐标
        public float RobotAngle;//机器人位姿角度
        public float PTZAngle;//旋转角
        public float PTZEAngle;//俯仰角
        public float VideoFocal;//可见光焦距        
        public int TaskRunId;//当前巡检任务编号（没有新任务时一直是上一次巡检编号）
        public byte TaskRunStatus;//巡检任务巡检状态，0-正在执行，1-暂停，2-执行完成，3-用户结束，
        public byte IsMapUpdate;//地图是否有更新
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string MapUrl;//地图下载地址
        public int CreatingMapPercent;//创建地图百分比，-1：异常
        public byte IsReadMeterResult;//是否有表计读取结果
    }

    #endregion

    #region 读取Socket数据

    /// <summary>
    /// 机器人软件状态
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SocketDateStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string devId;//设备编号
        public short temperature;//温度
        public short valueB;//B值（离地距离）
        public short accelerationX;//X轴加速度
        public short accelerationY;//Y轴加速度
        public short accelerationZ;//Z轴加速度
        public byte isAlarm;//是否报警（坠落报警）
        public short pitchAngle;//俯仰角
        public short headingAngle;//航向角
        public short rollAngle;//翻滚角
    }

    #endregion
   
    #region 机器人速度

    /// <summary>
    /// 下发机器人速度
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RobotSpeed
    {
        public float Speed_L;//线速度
        public float Speed_W;//转向速度
    }

    #endregion

    #region 获取云台数据

    /// <summary>
    /// 读取云台数据
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CloudPlateInfo
    {
        public byte HorizontalAngle; //水平角度
        public byte PitchAngle;//俯仰角度
        public byte ZoomValue;//变倍值
        public byte FocusValue;//聚焦值
        public float PresetBitSpeed;//预置位速度
        public int PositioningSpeed;//定位速度
        public int ScanningSpeed;//扫描速度
        public int WatchTime;//守望时间
    }
    #endregion

    #region 读取云台运行数据
    /// <summary>
    /// 读取云台运行数据
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CloudPlateRunInfo
    {
        public float PTZAngle;//旋转角
        public float PTZEAngle;//俯仰角
        public float VideoFocal;//可见光焦距  
    }
    #endregion

    #region 地图上传

    /// <summary>
    /// 读取地图上传地址
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MapUpload
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string MapImageUrl;//地图图片地址
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string Map3DUrl;//3d地图地址
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string MapDescUrl;//地图停泊点地址
    }
    #endregion

    #region 下发地图

    /// <summary>
    /// 下发地图
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MapDownload
    {
        public int MapId;//地图编号
        public byte IsNeedDownLoad;//是否需要机器人下载
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string MapImageUrl;//地图图片地址
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string Map3DUrl;//3d地图地址
    }
    #endregion

    #region 任务信息

    /// <summary>
    /// 下发启动任务信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TaskInfo
    {
        public int TaskId;//任务编号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string TaskName;//任务名称
        public int TaskRunId;//任务执行编号
        public DateTime RunDateTime;//执行时间
        public int Level;//任务等级（任务执行类型）
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string MapImageUrl;//地图图片地址
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string PointFileUrl;//停泊点位设置信息地址
    }
    #endregion

    #region 可见光摄像头信息

    /// <summary>
    /// 读取可见光相机配置信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NormalCameraConfig
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string IpAddr;//IP地址
        public int Port;//端口号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string SerialNumber;//序列号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string PassWord;//密码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string UserId;//用户名
    }
    #endregion

    #region 红外光相机配置

    /// <summary>
    /// 读取红外光相机配置
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InfraredCameraConfig
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string CameraName;//相机名称
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string CameraId;//相机序列号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string CameraType;//类型
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string HardwareId;//硬件版本号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string SoftwareId;//软件版本号
        public int DataWidth;//数据宽度
        public int DataHeight;//数据高度
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string FPAID;//探测器序列号
    }
    #endregion

    #region 读表返回值

    /// <summary>
    /// 读表返回信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ReadMeterResult
    {
        public float ResultValue;//读表结果
        public int IsException;//是否有异常
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string ImageUrl;//检测图片地址
    }

    #endregion

    #region 红外检测返回值

    /// <summary>
    /// 读取红外检测返回信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TemperateResult
    {
        public float ResultValue;//读表结果
        public int IsException;//是否有异常
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string ImageUrl;//检测图片地址
    }

    #endregion

    #region 停泊点巡检信息

    /// <summary>
    /// 读取停泊点巡检信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MapPointRunInfo
    {
        public int TaskId;//任务编号
        public int TaskRunId;//任务执行编号
        public int MapPointId;//停泊点编号
        public int RunStatus;//巡检状态，1-巡检完成，2-超时退出，3-异常退出
        public DateTime RunDateTime;//巡检时间
    }

    #endregion

    #region 停泊点动作巡检信息

    /// <summary>
    /// 读取停泊点动作巡检信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MapPointActionRunInfo
    {
        public int TaskId;//任务编号
        public int TaskRunId;//任务执行编号
        public int MapPointId;//停泊点编号、
        public int MapPointActionId;//停泊点动作编号
        public int RunStatus;//巡检状态，1-巡检完成，2-超时退出，3-异常退出
        public float MeterValue;//表计读数
        public byte IsException;//是否有异常
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string NormalCameraImage;//可见光图片
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string InfraredCameraImage;//红外光图片
        public DateTime RunDateTime;//巡检时间
    }

    #endregion

    #region 报警信息

    /// <summary>
    /// 读取报警信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AlarmInfo
    {
        public int TaskId;//任务编号
        public int TaskRunId;//任务执行编号
        public int MapPointId;//停泊点编号
        public int MapPointActionId;//停泊点动作编号
        public int AlarmType;//报警类型，0-温度过高，1-漏油，2-异物，3-表计读数异常
        public float RunValue;//表计读数
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
        public string NormalCameraImage;//可见光图片
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
        public string InfraredCameraImage;//红外光图片
        public DateTime AlarmDateTime;//报警时间
    }

    #endregion

    #region 下发上传标识

    /// <summary>
    /// 上传数据结果
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UploadResult
    {
        public byte UploadType;//上传类型
        public byte Result;//结果，1-成功，0-失败
        public int DataId;//数据标识
    }

    #endregion

    #region 枚举

    /// <summary>
    /// 机器人状态枚举
    /// </summary>
    public enum RobotCarStatusEnum
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 0,
        /// <summary>
        /// 异常
        /// </summary>
        [Description("异常")]
        Exception = 1,
        /// <summary>
        /// 充电
        /// </summary>
        [Description("充电")]
        Charge = 2,
        /// <summary>
        /// 避障
        /// </summary>
        [Description("避障")]
        AvoidingStop = 3,
        /// <summary>
        /// 防跌落
        /// </summary>
        [Description("防跌落")]
        DropStop = 4
    }

    /// <summary>
    /// 灯光状态枚举
    /// </summary>
    public enum RobotBrightModeEnum
    {
        /// <summary>
        /// 常开
        /// </summary>
        [Description("打开")]
        Open = 0,
        /// <summary>
        /// 关闭
        /// </summary>
        [Description("关闭")]
        Close = 1,
        /// <summary>
        /// 呼吸灯
        /// </summary>
        [Description("呼吸灯")]
        Breathing = 2,
        /// <summary>
        /// 自定义
        /// </summary>
        [Description("自定义")]
        Customize = 3
    }

    /// <summary>
    /// 机器人控制枚举
    /// </summary>
    public enum RobotControlEnum
    {
        /// <summary>
        /// 回零
        /// </summary>
        Zero = 0,
        /// <summary>
        /// 前进
        /// </summary>
        Advance = 1,
        /// <summary>
        /// 后退
        /// </summary>
        Back = 2,
        /// <summary>
        /// 左转
        /// </summary>
        TurnLeft = 3,
        /// <summary>
        /// 右转
        /// </summary>
        TurnRight = 4,
        /// <summary>
        /// 停止
        /// </summary>
        Stop = 5
    }

    /// <summary>
    /// 云台控制枚举
    /// </summary>
    public enum RobotCloudPlateControlEnum
    {
        /// <summary>
        /// 回零
        /// </summary>
        Zere = 0,
        /// <summary>
        /// 向上
        /// </summary>
        Up = 1,
        /// <summary>
        /// 向下
        /// </summary>
        Down = 2,
        /// <summary>
        /// 左转
        /// </summary>
        TureLeft = 3,
        /// <summary>
        /// 右转
        /// </summary>
        TureRight = 4,
        /// <summary>
        /// 停止
        /// </summary>
        Stop = 5,
        /// <summary>
        /// 拉近（放大）
        /// </summary>
        Enlarge=6,
        /// <summary>
        /// 拉远（缩小）
        /// </summary>
        Narrow=7,
        /// <summary>
        /// 开灯
        /// </summary>
        TurnOnLight=8,
        /// <summary>
        /// 关灯
        /// </summary>
        TurnOffLight=9,
        /// <summary>
        /// 打开雨刷
        /// </summary>
        TurnOnWiper=10,
        /// <summary>
        /// 关闭雨刷
        /// </summary>
        TurnOffWiper=11
    }

    /// <summary>
    /// 创建地图枚举
    /// </summary>
    public enum RobotCreateMapEnum
    {
        /// <summary>
        /// 地图初始化
        /// </summary>
        InitMap = 0,
        /// <summary>
        /// 保存地图
        /// </summary>
        SaveMap = 1,
        /// <summary>
        /// 恢复地图
        /// </summary>
        Return = 2
    }

    /// <summary>
    /// 任务控制枚举
    /// </summary>
    public enum RobotTaskControlEnum
    {
        /// <summary>
        /// 暂停
        /// </summary>
        Pause=0,
        /// <summary>
        /// 继续
        /// </summary>
        Resume=1,
        /// <summary>
        /// 停止
        /// </summary>
        Stop=2,
        /// <summary>
        /// 一键返航
        /// </summary>
        Back=3
    }

    /// <summary>
    /// 可见光命令
    /// </summary>
    public enum RobotNormalCameraComandEnum
    {
        /// <summary>
        /// 读表
        /// </summary>
        RedMeter = 0,
        /// <summary>
        /// 油位识别
        /// </summary>
        OilLevel = 1,
        /// <summary>
        /// 异物识别
        /// </summary>
        Other = 2,
        /// <summary>
        /// 拍照
        /// </summary>
        Photogragh = 3
    }

    /// <summary>
    /// 任务等级枚举，值越大等级越高
    /// </summary>
    public enum RobotTaskLevelEnum
    {
        /// <summary>
        /// 日常任务
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 定时任务
        /// </summary>
        Timing = 1,
        /// <summary>
        /// 立即执行任务
        /// </summary>
        Immediately
    }

    /// <summary>
    /// 巡检结果状态
    /// </summary>
    public enum RobotTaskRunStatusEnum
    {
        /// <summary>
        /// 巡检完成
        /// </summary>
        Finish = 0,
        /// <summary>
        /// 超时退出
        /// </summary>
        Timeout = 1,
        /// <summary>
        /// 异常退出
        /// </summary>
        Exception = 2
    }

    /// <summary>
    /// 报警类型
    /// </summary>
    public enum RobotAlarmTypeEnum
    {
        /// <summary>
        /// 温度异常
        /// </summary>
        TemperateException = 0,
        /// <summary>
        /// 漏油
        /// </summary>
        OilOut = 1,
        /// <summary>
        /// 异物
        /// </summary>
        ForeignBody = 2,
        /// <summary>
        /// 表计读数异常
        /// </summary>
        MeterValueException = 3
    }

    /// <summary>
    /// 上传结果标识类型
    /// </summary>
    public enum RobotUploadResultTypeEnum
    {
        /// <summary>
        /// 地图
        /// </summary>
        Map = 0,
        /// <summary>
        /// 任务动作
        /// </summary>
        TaskPointAction = 1,
        /// <summary>
        /// 报警信息上传
        /// </summary>
        Alarm=2,
        /// <summary>
        /// 地图更新
        /// </summary>
        MapUpdate=3
    }

    /// <summary>
    /// byte表示的Bool型枚举
    /// </summary>
    public enum RobotByteBoolEnum
    {
        False = 0,
        True = 1
    }

    /// <summary>
    /// 底盘异常枚举
    /// </summary>
    public enum ExceptInfoEnum
    {
        [Description("校验和异常")]
        ExceptByte0,
        [Description("电机驱动高温警告")]
        ExceptByte1,
        [Description("电机过流警告")]
        ExceptByte2,
        [Description("电池欠压警告")]
        ExceptByte3,
        [Description("预留1")]
        ExceptByte4,
        [Description("预留2")]
        ExceptByte5,
        [Description("预留3")]
        ExceptByte6,
        [Description("预留4")]
        ExceptByte7,
        [Description("电池欠压")]
        ExceptByte8,
        [Description("电池过压")]
        ExceptByte9,
        [Description("电机1通信故障")]
        ExceptByte10,
        [Description("电机2通信故障")]
        ExceptByte11,
        [Description("电机3通信故障")]
        ExceptByte12,
        [Description("电机4通信故障")]
        ExceptByte13,
        [Description("电机驱动过温保护")]
        ExceptByte14,
        [Description("电机过流保护")]
        ExceptByte15
    }

    #endregion
}
