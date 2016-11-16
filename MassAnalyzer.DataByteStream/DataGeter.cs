using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*************************************************************************************************************************************
 * 
 * DataGeter  的作用是作为一个收到字节流不断处理字节流。所以public的唯一方法只有 AcceptOPCServerData(byte[])
 * 
 * 当Datageter 判断接受到一张完整谱图触发事件 UpOneScanDataEvent  
 * 其 参数MyEventargs e 带来的信息有list[double] Mass List[float] intensity StartMass LastMass ScanTime
 * 内部处理有清除list[double] Mass List[float] 缓存的信息重新开始写入
 * **************************************************************************************************************************
 * 当DataGeter 判断一个数据点（就是一个质量数对应一个强度）到来触发 UpOneDataEvent 事件 带来的信息就是 massvalue 和intensity 
 * **************************************************************************************************************************
 * 
 * 
 * 
 * **************************************************************************************************************************
 */
namespace MassAnalyzer.DataByteStream
{
    public class DataGeter
    {
        #region 字段属性
       public dwellspd dwellSpd
        {
            get;
            private set;
        }
        Status status ;
        byte ChannelNum = 0;
        Datatype _datatye;
        private MyEventargs e;
        List<double> _intensityValueOneLoop;
        List<double> _massValueOneloop;
        List<byte> _databuffer;
        public List<byte> DataBuffer
        {
            get { return _databuffer; }
            set { _databuffer = value; }
        }
        bool _isStartScan = false;

        /// <summary>
        /// 上一次完成循环对应的质量数
        /// </summary>
        public List<double> MassValueOneloop
        {
            get
            {
                return _massValueOneloop;
            }
            set
            {
                _massValueOneloop = value;
            }
        }

        /// <summary>
        /// 上一次完成循环的信号强度的数据
        /// </summary>
        public List<double> IntensityValueOneLoop
        {
            get
            {
                return _intensityValueOneLoop;
            }
            set
            {
                _intensityValueOneLoop = value;
            }
        }
        /// <summary>
        /// 是否在扫描的状态
        /// </summary>
        public bool IsScanState
        {
            get
            {
                return _isStartScan;
            }

            set
            {
                _isStartScan = value;
            }
        }

        public double StartMass { get; private set; }
        public double LastMass { get; private set; }

        public Datatype Datatye
        {
            get
            {
                return _datatye;
            }
            set
            {
                _datatye = value;
            }
        }

        public byte ChannelNum1
        {
            get
            {
                return ChannelNum;
            }

            set
            {
                ChannelNum = value;
            }
        }
        #endregion
        #region 委托事件
        public delegate void UponeDataHander(double massvalue, double intensityvalue);
        public event UponeDataHander UpOneDataEvent;
        private void OnUpOneData(double _massvalue, double _intensityvalue)
        {
            if (UpOneDataEvent != null)
               // Console.WriteLine(_massvalue+"__"+_intensityvalue);
            UpOneDataEvent(_massvalue, _intensityvalue);
        }
        public delegate void UpOneScanDataHander(MyEventargs e);
        public event UpOneScanDataHander UpOneScanDataEvent;
        /// <summary>
        /// 引发UpOneScanDataEvent事件
        /// </summary>
        private void OnUpOneScanData()
        {
            if (this.UpOneScanDataEvent != null)
            {
                if (_intensityValueOneLoop.Count > 0)
                {
                    e.Intensitys = _intensityValueOneLoop;
                    e.massvalues = _massValueOneloop;
                  
                    e.StartMass = StartMass;
                    e.LastMass = LastMass;
                    e.DataType = _datatye.ToString();
                    this.UpOneScanDataEvent(e);
                }
            }
            _intensityValueOneLoop.Clear();
            _massValueOneloop.Clear();
        }
        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        public DataGeter()
        {
            _intensityValueOneLoop = new List<double>();
            _massValueOneloop = new List<double>();
            _databuffer = new List<byte>();
            e = new MyEventargs();

        }
        #region 方法
       
        public void AcceptOPCServerData(byte[] data)
        {
            if (_isStartScan)          //如果开始了扫描 才处理数据
            {
                if(data.Length>=4)
                {
                  //  _databuffer.AddRange(data);
                    Decode(ref data );
                }
                else
                {
                    _databuffer.AddRange(data);
                }
                #region

                #endregion
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer">要处理的缓存</param>
        /// <param name="countSum"></param>
        /// <param name="temp"></param>
        private void Decode( ref byte[] data)
        {
           
                int temp = 0;   //list buffer 处理了几个
                int count = data.Length;

                 while(LoopConvert(ref temp,ref count,ref data))   //循环处理
                    {

                    }

           
        }
        /// <summary>
        /// 一直处理  返回true继续处理返回false 循环处理可以结束了
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private bool LoopConvert(ref int temp, ref int count,ref byte[] _databuffer)
        {
            if ((count - temp) >= 4)
            {
                if (_databuffer[temp + 2] == 0)  //连续测量状态
                {
                    byte n = _databuffer[temp + 3];
                  
                    if ((count - temp) >= (n * 8) + 4)   //根据tlump的个数比如有N个那么预期由 8N+4个byte长度 有的话处理
                    {
                        continuityStauesConvert(ref count,ref temp, n,ref _databuffer);
                        return true;
                        //后面和处理固定长度一样了
                    }
                    else                                                 //如果没有达到预期的长度
                    {
                        //_databuffer.RemoveRange(0, temp);
                        Console.WriteLine(108);
                        return false;
                    }

                }
                else if (_databuffer[temp + 2] == 1)   //通道开始
                {

                    if (count - temp >= 14)                         //count-temp 待处理的缓存长度
                    {
                        ChannelStartConvert(ref count, ref temp);
                        temp += 14;
                        return true;
                    }
                    else                                    //如果待处理缓存长度没有达到14 不进行处理
                    {
                        // _databuffer.RemoveRange(0, temp);   // 把已处理的缓存 删去 留下没处理的 给下次来了拼接起来一起处理
                        Console.WriteLine(107);
                        return false;
                    }
                }
                else if (_databuffer[temp + 2] == 2)   //通道结束
                {
                    if (count - temp >= 4)
                    {
                        temp += 4;
                        return true;
                    }
                    else
                    {
                        // _databuffer.RemoveRange(0, temp);
                        Console.WriteLine(106);
                        return false;
                    }


                }
                else if (_databuffer[temp + 2] == 3)   //通道 Abort
                {
                    if (count - temp >= 4)
                    {
                        temp += 4;
                        //_isStartScan = false;
                        return true;
                    }
                    else
                    {
                        // _databuffer.RemoveRange(0, temp);
                        Console.WriteLine(105);
                        return false;
                    }
                }
                else if (_databuffer[temp + 2] == 4)    //循环结束
                {
                    if (count - temp >= 4)
                    {
                        //_isStartScan = false;
                        temp += 4;
                        
                        return true;
                    }
                    else
                    {
                        //  _databuffer.RemoveRange(0, temp);
                        Console.WriteLine(104);
                        return false;
                    }

                }
                else if (_databuffer[temp + 2] == 5)    //通道状态
                {

                    if (count - temp >= 10)
                    {
                        UpDataChannelMsg(ref count, ref temp,ref _databuffer);
                        temp += 10;
                        return true;

                    }
                    else
                    {
                        //   _databuffer.RemoveRange(0, temp);
                        Console.WriteLine(103);
                        return false;
                    }
                }
                else if (_databuffer[temp + 2] == 6)     //测量结束
                {
                    if (count - temp >= 4)
                    {
                        temp += 4;
                  //      _isStartScan = false;
                        return true;
                    }
                    else
                    {
                        // _databuffer.RemoveRange(0, temp);
                        Console.WriteLine(102);
                        return false;
                    }
                }
                else                                  //说明整个都是错误的 没有找到帧头
                {
                    // _databuffer.Clear();              // 
                    Console.WriteLine(101);
                    return false;
                }

            }
            else
            {

                //  _databuffer.RemoveRange(0, temp);
                //Console.WriteLine(false);
                return false;
            }
        }

   
     
        private void CompleteOneScan()
        {
            //   OnUpOneScanData();
            _intensityValueOneLoop.Clear();
            _massValueOneloop.Clear();
        }

        private void ChannelStartConvert(ref int count,ref int temp)
        {
            if(_massValueOneloop.Count>1)  //如果有内容
            {
                OnUpOneScanData();   //如果之前记录一次扫描 的有数据触发事件
                _massValueOneloop.Clear();
                _intensityValueOneLoop.Clear();  //把内容删了 准备接收下一次
            }
        }

        private void UpDataChannelMsg(ref int count, ref int temp,ref byte[]_databuffer)
        {
            ChannelNum = _databuffer[temp ];                                 //根据 temp  得到通道信息
            _datatye = (Datatype)_databuffer[temp+1];
            status = (Status)_databuffer[temp + +2];
            StartMass = (((_databuffer[temp + 5] * 256) + (_databuffer[temp + 4]))/ 64.0);
            LastMass= (((_databuffer[temp + 7] * 256) + (_databuffer[temp + 6])) / 64.0);
            dwellSpd = (dwellspd)_databuffer[temp + 8];
        }

        private void continuityStauesConvert(ref int count, ref int temp,int N,ref byte[] _databuffer)
        {
            temp += 4;
            for (int i = 0; i < N; i++)
            {
                double intensity = BitConverter.ToSingle(_databuffer, temp);
                double mass= (((_databuffer[temp + 5] * 256) + (_databuffer[temp + 4])) / 64.0);
                _massValueOneloop.Add(mass);
                _intensityValueOneLoop.Add(intensity);
                OnUpOneData(mass, intensity);
                temp += 8;
            }
        }
    }
    #endregion


    public enum dwellspd
    {
        Eight_K_PerS = 0,
        Four_K_PerS,
        TWO_K_PERS,
        ONR_K_PERS,
        FIVE_HUN_PERS,
        TWO_HUN_PERS,
        ONE_HUN_PERS,
        FIFTY_PERS,
        TWENTY_PERS,
        TEN_PERS,
        FIVE_PERS,
        TWO_PERS,
        ONE_PERS,
        TWO_S_M,
        FIVE_S_M,
        TEN_S_M,
        TWENTY_S_M,
        ONE_MIN_M
    }
    public enum Datatype
    {
        SampleTable = (System.Byte)0,
        ScanNormal,
        ScanFIR,
        ScanStairTable,
        PeakLever,
        PeakFIR,
        AdjustFine,
        OffsetMeasure,
        Analoginput,
        totalPressure,
        Jobbreak = (System.Byte)255

    }
    public enum Status
    {
        ContinuousMeasuringdata = (System.Byte)0,
        ChannelStart,
        ChannelEnd,
        ChanelAbort,
        CycleEnd,
        ChanelInformation,
        MeasurementEnd,
    }
}
public class MyEventargs
{
    public List<double> Intensitys { get; set; }
    public List<double> massvalues { get; set; }
    public string DataType { get; set; }
    public double StartMass { get; set; }
    public double LastMass { get; set; }
    public DateTime DataAcquireTime { get; set; }



}


