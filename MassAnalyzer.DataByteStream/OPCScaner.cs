using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc;
using Opc.Da;
using OpcCom;
using System.Threading;
/*******************************************************************************************************************************
 * 
 * 
 * 
 * 
  ******************************************************************************************************************************/
namespace MassAnalyzer.DataByteStream
{
    public class OPCScaner
    {

        #region 数据
        private byte simulationMode = 0;
        private byte dataPumpMode = 0;


        private byte cycleMode = 0;   //0单通道   1多通道
        private byte measureMode = 0;
        private byte numberOfCycles = 0;
        private byte beginChannel = 0;
        private byte endChannel = 0;
        private byte cycleCommand = 0;

        private byte[] dwellSpeed = new byte[128];
        private byte[] massMode = new byte[128];
        private byte[] autoRangeMode = new byte[128];
        private byte[] detectorRange = new byte[128];
        private byte[] detectorType = new byte[128];
        private byte[] cPLevel = new byte[128];
        public Single FirstMass
        {
            get { return firstMass[0]; }
            set { firstMass[0] = value; }
        }
        public Single LastMass
        {
            get { return firstMass[0] + massWidth[0]; }
            set { massWidth[0] = value - firstMass[0]; }
        }

        private Single[] firstMass = new Single[128];
        private Single[] massWidth = new Single[128];
        private Single[] sEMVoltage = new Single[128];

        private Single measureValue = 0f;
        private Single massValue = 0f;


        bool DetectorStatus = false;
        byte CycleStatus = 0;

        string[] itemNameOfPara =
       {
          "Hardware.Modules.Analyser.SI700.SimulationMode", //0 System.Byte  //是否为模拟模式 1是0否
          "General.DataPump.Mode",                          //1 System.Byte  //0内存溢出丢失继续扫描 1当太高内存占用率暂停扫描 2只有内存为空才开始扫描      byte
          "Channels.Parameters.Mass.FirstMass",             //2 System.Single[]  //  参数设置项目
          "Channels.Parameters.Mass.Width" ,                //3 System.Single[]                        //参数设置项目
          "Channels.Parameters.Mass.DwellSpeed",            //4 System.Byte[] // 0 /0.125 1/0.25 2/0.5 3/1 4/2 5/5 6/10 7/20  8/50 9/100 10/200 11/500 12/1000 13/2000 14/5000 15/10000 16/20000 17/60000 
          "Channels.Parameters.Mass.MassMode",              //5 System.Byte[] //0 sample 平均 2 SCAN-N 3SCAN-F 3 STAIR 4 PEAK-L 5PEAK-F 
          "Channels.Parameters.Amplifier.AutoRangeMode",    //6 System.Byte[]   0 FIX 1AUTO 2AUTODOWN
          "Channels.Parameters.Amplifier.DetectorRange",    //7 System.Byte[] 01234567对应 E-5 -6 -7 -8 -9 -10 -11 -12  //暂时默认项
          "Channels.Parameters.Detector.DetectorType",      //8 System.Byte[] 0法拉第   1IONCOUNT   2EXTERN1   3EXTERN1    4SEM    5 ANALOGIN    6TOTALPRESSURE  //可选项
          "General.Cycle.CycleMode",                        //9 System.Byte        0单通道1多通道         //默认1
          "General.Cycle.MeasureMode",                      //10 System.Byte                              //不懂暂时默认
          "General.Cycle.NumberOfCycles",                   //11 System.Int16设置循环次数,0无尽,1到10000次//默认项目   
          "General.Cycle.BeginChannel",                     //12 System.Byte                              //参数设置项目
          "General.Cycle.EndChannel",                       //13 System.Byte                              //自动统计写入项目
        //  "Analyser.Detector.Command",                      //14  System.Byte   电子倍增管开关 1开 2关    // 可选项
        //  "General.Cycle.Command",                          //15  System.Byte                             //命令控制项目
          "Channels.Parameters.Amplifier.CPLevel",          //16   System.Byte[]         0到255              //可选项
         "Channels.Parameters.Detector.SEMVoltage"          //17   System.Single[]  0到3500.00            //参数设置项目
        }
       ;
        /// <summary>
        /// 获得数据的组
        /// </summary>
        string[] DataSourceItems = {
            "General.DataPump.Data"
          };
        /// <summary>
        /// 开始扫描的组
        /// </summary>
        string[] itemNameofStart =
            {
             "General.Cycle.Command",                          //14  System.Byte                             //命令控制项目
             "Analyser.Detector.Command",                      //19  System.Byte   电子倍增管开关 1开 2关   // 可选项
            }
            ;
        #endregion
        #region 字段属性
        /// <summary>
        /// 用于判断以前有没有通道头的
        /// </summary>

        EventWaitHandle waitHandleToSavFlie = new AutoResetEvent(false);
        EventWaitHandle waitHandleDecode = new AutoResetEvent(false);
        /// <summary>
        /// 解码专用线程
        /// </summary>
        Thread threadOfDecode;
        /// <summary>
        /// 把一次扫描保存的专用线程
        /// </summary>
        Thread ThreadOfReserveTofile;
        DataGeter datageter;
        /// <summary>
        /// 消息队列
        /// </summary>
        private Queue<byte[]> ListQueue = new Queue<byte[]>();
        /// <summary>
        /// OPC服务器
        /// </summary>
        public string[] OPCItemsEnum
        {
            get;
            set;
        }
        public Opc.Da.Server My_Server
        {
            get { return m_server; }
            set { m_server = value; }
        }
        /// <summary>
        ///OPC 服务器对象集合
        /// </summary>
        public Opc.Server[] servers
        {
            get;
            set;
        }
        /// <summary>
        /// 服务器名字数组
        /// </summary>
        public string[] OPCserversName
        {
            get;
            set;
        }
        /// <summary>
        /// opc服务器所在主机的名字
        /// </summary>
        public string HostPCName
        {
            get;
            set;
        }

        public DataGeter Datageter
        {
            get
            {
                return datageter;
            }

            set
            {
                datageter = value;
            }
        }

        public byte SimulationMode
        {
            get
            {
                return simulationMode;
            }

            set
            {
                simulationMode = value;
            }
        }

        public byte DataPumpMode
        {
            get
            {
                return dataPumpMode;
            }

            set
            {
                dataPumpMode = value;
            }
        }

        public byte CycleMode
        {
            get
            {
                return cycleMode;
            }

            set
            {
                cycleMode = value;
            }
        }

        public byte MeasureMode
        {
            get
            {
                return measureMode;
            }

            set
            {
                measureMode = value;
            }
        }

        public byte NumberOfCycles
        {
            get
            {
                return numberOfCycles;
            }

            set
            {
                numberOfCycles = value;
            }
        }

        public byte BeginChannel
        {
            get
            {
                return beginChannel;
            }

            set
            {
                beginChannel = value;
            }
        }

        public byte EndChannel
        {
            get
            {
                return endChannel;
            }

            set
            {
                endChannel = value;
            }
        }

        public byte CycleCommand
        {
            get
            {
                return cycleCommand;
            }

            set
            {
                cycleCommand = value;
            }
        }

        public byte[] DwellSpeed
        {
            get
            {
                return dwellSpeed;
            }

            set
            {
                dwellSpeed = value;
            }
        }

        public byte[] MassMode
        {
            get
            {
                return massMode;
            }

            set
            {
                massMode = value;
            }
        }

        public byte[] AutoRangeMode
        {
            get
            {
                return autoRangeMode;
            }

            set
            {
                autoRangeMode = value;
            }
        }

        public byte[] DetectorRange
        {
            get
            {
                return detectorRange;
            }

            set
            {
                detectorRange = value;
            }
        }

        public byte[] DetectorType
        {
            get
            {
                return detectorType;
            }

            set
            {
                detectorType = value;
            }
        }

        public byte[] CPLevel
        {
            get
            {
                return cPLevel;
            }

            set
            {
                cPLevel = value;
            }
        }


        public float[] MassWidth
        {
            get
            {
                return massWidth;
            }

            set
            {
                massWidth = value;
            }
        }

        public float[] SEMVoltage
        {
            get
            {
                return sEMVoltage;
            }

            set
            {
                sEMVoltage = value;
            }
        }

        public float MeasureValue
        {
            get
            {
                return measureValue;
            }

            set
            {
                measureValue = value;
            }
        }

        public float MassValue
        {
            get
            {
                return massValue;
            }

            set
            {
                massValue = value;
            }
        }

        /// <summary>
        /// 服务器
        /// </summary>
        private Opc.Da.Server m_server = null;//定义数据存取服务器
        /// <summary>
        /// 订阅的组
        /// </summary>
        private Opc.Da.Subscription GroupOfPara = null;
        private Opc.Da.Subscription GroupOfdatasource = null;  //订阅的数据更新的组
        private Opc.Da.Subscription GroupOfCommand = null;//普通的组定义组对象（订阅者）
        private Opc.Da.SubscriptionState state = null;//定义组（订阅者）状态，相当于OPC规范中组的参数
        private Opc.IDiscovery m_discovery = new OpcCom.ServerEnumerator();//定义枚举基于COM服务器的接口，用来搜索所有的此类服务器。
        ItemIdentifier itemId = null;
        BrowseFilters filters = new BrowseFilters();


        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_HostPCName">连接的服务器的设备名</param>
        public OPCScaner(string _HostPCName)
        {
            HostPCName = _HostPCName;
            datageter = new DataGeter();
            StartThreadOfDecode();
            if (!compare("qms700-44515706.QMG700-DA-64-D2-41-00-D3-7F")) // 创建对象的时候第一次尝试查找服务器查找服务器
            {
                OnError("can't find specific OPC server");
            }

        }
        /// <summary>
        /// 给命令开始扫描
        /// </summary>
        public bool StartScan()
        {
            try
            {
                if (m_server == null || (!m_server.IsConnected))  //除了创建对象查找服务器失败的话  再次查找服务器
                {
                    if (ConnectServer())
                    {
                       

                        GroupOfdatasource.DataChanged += GroupOfdatasource_DataChanged;
                        byte start = 1;
                        System.Type[] typ = { start.GetType(), start.GetType() };
                        WriteSyn(GroupOfCommand.Items, new object[] { start, start }, typ);
                        datageter.IsScanState = true;
                        return true;
                    }
                    return false;
                }
                else
                {
                   
                    GroupOfdatasource.DataChanged += GroupOfdatasource_DataChanged;
                    byte start = 1;
                    System.Type[] typ = { start.GetType(), start.GetType() };
                    WriteSyn(GroupOfCommand.Items, new object[] { start, start }, typ);
                    datageter.IsScanState = true;
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 给命令停止扫描
        /// </summary>
        public bool StopScan()
        {
            try
            {
                GroupOfdatasource.DataChanged -= GroupOfdatasource_DataChanged;
                datageter.IsScanState = false;  //停止执行处理数据
                byte start = 2;
                System.Type[] typ = { start.GetType(), start.GetType() };
                WriteSyn(GroupOfCommand.Items, new object[] { start, start }, typ);
                GroupOfCommand = null;
                GroupOfdatasource = null;
                GroupOfPara = null;
                return true;
            }
            catch
            {
                return false;
            } 
        }
        private object[] OutObjectOfPara()
        {
            object[] para =
                {
                (byte)0,
                (byte)1,
                firstMass,
                massWidth,
                dwellSpeed,
                massMode,
                autoRangeMode,
                detectorRange,
                detectorType,
                cycleMode,
                measureMode,
                numberOfCycles,
                beginChannel,
                endChannel,
                cPLevel,
                sEMVoltage


            };
            return para;
            
        }
        /// <summary>
        /// 设定参数
        /// </summary>
        public void SetParameters()
        {
            object[] para = OutObjectOfPara();
                  System.Type[] typ = new System.Type[para.Length];
            for (int i = 0; i < para.Length; i++)
            {
                typ[i] = para[i].GetType();
            }

            WriteSyn(GroupOfPara.Items, para,typ);
        }
        public void DisConnect()
        {

            //GroupOfCommand.RemoveItems(GroupOfCommand.Items);
            //GroupOfdatasource.RemoveItems(GroupOfdatasource.Items);
            //GroupOfState.RemoveItems(GroupOfState.Items);


            //////结束：释放各资源
            //m_server.CancelSubscription(GroupOfCommand);//m_server前文已说明，通知服务器要求删除组。
            //m_server.CancelSubscription(GroupOfdatasource);//m_server前文已说明，通知服务器要求删除组。
            //m_server.CancelSubscription(GroupOfState);//m_server前文已说明，通知服务器要求删除组。
            //GroupOfCommand=null;
            //GroupOfdatasource=null;
            //GroupOfState=null;
            m_server.Disconnect();//断开服务器连接
        }
        /// <summary>
        /// 引发出错事件
        /// </summary>
        /// <param name="errorMsg"></param>
        private void OnError(string errorMsg)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 创建对象时候初始化服务器
        /// </summary>
        private void InnilizeServer()
        {
            try
            {
                    CreatGroupOfDataSource(DataSourceItems, "DataGroup", 1);
                    CreatCommandGroup(itemNameofStart, "Command", 100);
                    CreatGroupOfState(itemNameOfPara, "para", 500);      
            }
            catch
            {
                OnError("Innilize opc server error");
            }
        }
        private void StartThreadOfDecode()
        {
            threadOfDecode = new Thread(decode);
            threadOfDecode.IsBackground = true;
            threadOfDecode.Start();
        }

        /// <summary>
        /// 解码线程中运行的方法
        /// </summary>
        private void decode()
        {

            while (true)
            {
                if (ListQueue.Count > 0)
                {
                    datageter.AcceptOPCServerData(ListQueue.Dequeue());
                }
                else
                {
                    Thread.Sleep(1);
                }

            }
        }


        private void GroupOfdatasource_DataChanged(object subscriptionHandle, object requestHandle, ItemValueResult[] values)
        {
            foreach (ItemValueResult item in values)
            {
                ListQueue.Enqueue((byte[])item.Value);
            }
        }
        /// <summary>
        /// 查找服务器
        /// </summary>
        private void ObserveServer()
        {
          
                servers = m_discovery.GetAvailableServers(Specification.COM_DA_20, HostPCName, null);
                if (servers != null)
                {
                    List<string> _serversname = new List<string>();
                    foreach (Opc.Da.Server server in servers)
                    {
                        _serversname.Add(server.Name);
                    }
                    OPCserversName = _serversname.ToArray();
                }
            
          
        }
        /// <summary>
        /// 先查找服务器再根据服务器名字筛选出此对象要连接的服务器
        /// </summary>
        /// <param name="OpcServerName"></param>
        /// <returns>找到目标服务器返回true</returns>
        private bool compare(string OpcServerName)
        {

            try
            {
                ObserveServer();
                Opc.Da.Server ser = null;
                if (servers != null)
                {
                    foreach (Opc.Da.Server server in servers)
                    {
                        if (String.Compare(server.Name, OpcServerName, true) == 0)//不带计算机名为本地访问
                        {
                            m_server = server;
                            ser = server;
                            return true;
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 连接服务器  对象里面有服务器就连接 再初始化订阅组  无服务器就  查找再连接  再初始化订阅组
        /// </summary>
        private bool ConnectServer()
        {
            if (m_server != null)//非空连接服务器
            {
                m_server.Connect();
                InnilizeServer();
              
               // StartThreadOfDecode();
                return true;
            }
            else
            {
                if (compare("qms700-44515706.QMG700-DA-64-D2-41-00-D3-7F"))
                {
                    try
                    {
                        m_server.Connect();
                        InnilizeServer();
                      
                       // StartThreadOfDecode();
                        return true;
                    }
                    catch
                    {
                        OnError("can't connect servers");
                        return false;
                    }
                }
                else
                {
                    OnError("can't find servers");
                    return false;
                }
            }
        }
        /// <summary>
        /// 查看所有的项
        /// </summary>
        /// <returns>项的字符串数组</returns>
        public string[] EnumerateItems()
        {
            List<string> items = null;
            filters.BrowseFilter = browseFilter.all;
            if (m_server == null)
            { return null; }

            BrowsePosition pos = null;
            BrowseElement[] elements = m_server.Browse(itemId, filters, out pos);
            if (elements != null)
            {
                foreach (BrowseElement elem in elements)
                {
                    items.Add(elem.ItemName);
                    if (elem.HasChildren)
                    {
                        itemId = new ItemIdentifier(elem.ItemPath, elem.ItemName);
                        EnumerateItems();
                    }
                }
                OPCItemsEnum = items.ToArray();
            }
            return OPCItemsEnum;
        }
        /// <summary>
        /// 创建一个状态组 用于订阅
        /// </summary>
        /// <param name="itemName"></param>
        private void CreatGroupOfState(string[] itemName, string GroupName, int UpRate)
        {
            Item[] items = CreatItems(itemName);//定义数据项，即items
            state = new Opc.Da.SubscriptionState();//组（订阅者）状态，相当于OPC规范中组的参数
            state.Name = "订阅的状态组";//组名
            state.ServerHandle = null;//服务器给该组分配的句柄。
            state.ClientHandle = Guid.NewGuid().ToString();//客户端给该组分配的句柄。
            state.Active = true;//激活该组。
            state.UpdateRate = UpRate;//刷新频率为1秒。
            state.Deadband = 0;// 死区值，设为0时，服务器端该组内任何数据变化都通知组。
            state.Locale = null;//不设置地区值。
            GroupOfPara = (Opc.Da.Subscription)m_server.CreateSubscription(state);//创建组
        }
        /// <summary>
        /// 生成订阅的数据的组
        /// </summary>
        /// <param name="itemName"></param>
        private void CreatGroupOfDataSource(string[] itemName, string groupName, int UpdataRate)
        {
            Item[] items = CreatItems(itemName);//定义数据项，即items
            state = new Opc.Da.SubscriptionState();//组（订阅者）状态，相当于OPC规范中组的参数
            state.Name = groupName;//组名
            state.ServerHandle = null;//服务器给该组分配的句柄。
            state.ClientHandle = Guid.NewGuid().ToString();//客户端给该组分配的句柄。
            state.Active = true;//激活该组。
            state.UpdateRate = 0;//刷新频率为1ms。
            state.Deadband = 0;// 死区值，设为0时，服务器端该组内任何数据变化都通知组。
            state.Locale = null;//不设置地区值。

            GroupOfdatasource = (Opc.Da.Subscription)m_server.CreateSubscription(state);//创建组
            GroupOfdatasource.AddItems(items);

        }
        /// <summary>
        /// 控制开关的组
        /// </summary>
        /// <param name="itemName"></param>
        private void CreatCommandGroup(string[] itemName, string ParaItemName, int UpdataRate)
        {
            Item[] items = CreatItems(itemName);//定义数据项，即items
            state = new Opc.Da.SubscriptionState();//组（订阅者）状态，相当于OPC规范中组的参数
            state.Name = ParaItemName;//组名
            state.ServerHandle = null;//服务器给该组分配的句柄。
            state.ClientHandle = Guid.NewGuid().ToString();//客户端给该组分配的句柄。
            state.Active = true;//激活该组。
            state.UpdateRate = 100;//刷新频率为1秒。
            state.Deadband = 0;// 死区值，设为0时，服务器端该组内任何数据变化都通知组。
            state.Locale = null;//不设置地区值。
            GroupOfCommand = (Opc.Da.Subscription)m_server.CreateSubscription(state);//创建组                
            GroupOfCommand.AddItems(items);
        }
        /// <summary>
        /// 根据项名字数组产生items
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        private Item[] CreatItems(string[] itemName)
        {
            Item[] items = new Item[itemName.Length];
            for (int i = 0; i < itemName.Length; i++)
            {
                items[i] = new Item();
                items[i].ClientHandle = Guid.NewGuid().ToString();//客户端给该数据项分配的句柄。
                items[i].ItemPath = null; //该数据项在服务器中的路径。
                items[i].ItemName = itemName[i]; //该数据项在服务器中的名字。
            }
            return items;
        }

        public void OnDataChange(object subscriptionHandle, object requestHandle, ItemValueResult[] values)
        {

        }
        //ReadComplete回调
        public void OnReadComplete(object requestHandle, Opc.Da.ItemValueResult[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                // Console.WriteLine("发生异步读name:{0},value:{1}", values[i].ItemName, values[i].Value);
            }

            //if ((int)requestHandle == 1) // 异步调用Read时用户自己所分配请求标识符（用于区分多个不同的异步读调用）
            //  Console.WriteLine("事件信号句柄为{0}", requestHandle);
        }

        //WriteComplete回调
        public void OnWriteComplete(object requestHandle, Opc.IdentifiedResult[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                // Console.WriteLine("发生异步写name:{0},result:{1}", values[i].ItemName, values[i].ResultID.Name.Name);
            }

            //  if ((int)requestHandle == 1) // 异步调用Write时用户自己所分配请求标识符（用于区分多个不同的异步Write调用）
            //  Console.WriteLine("事件信号句柄为{0}", requestHandle);
        }
        public void Read()
        {
            ItemValueResult[] values = GroupOfCommand.Read(GroupOfCommand.Items);
            foreach (ItemValueResult bbb in values)
            {
                if (values[1].Quality.Equals(Opc.Da.Quality.Good))
                {
                    Console.WriteLine(values[0].Value.ToString());
                    //listBox1.Items.Add("成功读取变量为<" + textBox2.Text + ">的数据.值为<" + values[0].Value.ToString() + ">");
                }
            }


            //subscription.RemoveItems(subscription.Items);
            //m_server.CancelSubscription(subscription);//m_server前文已说明，通知服务器要求删除组。 
        }

        /// <summary>
        /// 订阅的方式读
        /// </summary>
        public void ReadBySubscri(Opc.Da.Subscription subscriptionGroup)
        {
            ////注册回调事件
            subscriptionGroup.DataChanged += new Opc.Da.DataChangedEventHandler(OnDataChange);
            subscriptionGroup.Refresh(); //一定要在 注册回掉事件 subscription.DataChanged之后,否则刷新后的Items无法通知会出错！！！

        }
        /// <summary>
        /// 异步读
        /// </summary>
        public void ReadSyn()
        {
            IRequest quest = null;
            GroupOfCommand.Read(GroupOfCommand.Items, 1, this.OnReadComplete, out quest); //读写时候，注意关闭客户端防火墙或进行相应设置

        }
        /// <summary>
        ///同步写 在订阅的items中，写入一个item
        /// </summary>
        /// <param name="items"></param>
        public void Write(Item[] item, object[] value, System.Type[] type)
        {
            ItemValue[] itemvalues = new ItemValue[item.Length];
            for (int i = 0; i < item.Length; i++)
            {
                itemvalues[i] = new ItemValue((ItemIdentifier)item[i]);//TItem类要先转成ItemIdentifier，才能转成ItemValue
                itemvalues[i].Value = System.Convert.ChangeType(value[i], type[i]);
            }
            GroupOfCommand.Write(itemvalues);
        }
        /// <summary>
        /// 异步写
        /// </summary>
        public void WriteSyn(Item[] item, object[] value, System.Type[] type)
        {
            IRequest quest = null;
            ItemValue[] itemvalues = new ItemValue[item.Length];
            for (int i = 0; i < item.Length; i++)
            {
                itemvalues[i] = new ItemValue((ItemIdentifier)item[i]);//TItem类要先转成ItemIdentifier，才能转成ItemValue

                itemvalues[i].Value = System.Convert.ChangeType(value[i], type[i]);
            }
            GroupOfCommand.Write(itemvalues, 1, this.OnWriteComplete, out quest);


        }
        /// <summary>
        /// 断开连接
        /// </summary>

    }
}

