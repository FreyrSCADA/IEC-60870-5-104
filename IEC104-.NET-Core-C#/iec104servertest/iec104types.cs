/*****************************************************************************/
/*! \file        iec104win32d.cs
 *  \brief       IEC 60870-5-104 arch-win32 c# wrapper file
 *  \author      FreyrSCADA Embedded Solution Pvt Ltd
 *  \copyright (c) FreyrSCADA Embedded Solution Pvt Ltd. All rights reserved.
 *
 * THIS IS PROPRIETARY SOFTWARE AND YOU NEED A LICENSE TO USE OR REDISTRIBUTE.
 *
 * THIS SOFTWARE IS PROVIDED BY FREYRSCADA AND CONTRIBUTORS ``AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
 * PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL FREYRSCADA OR CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR
 * BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
 * OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

 
/*****************************************************************************/
/*! \brief iec104 c# class  */

public partial class iec104types
{

    
    
    /*! \brief  Max Size of Rx Message sent to callback  */
    public const int IEC104_MAX_RX_MESSAGE = 255;
    /*! \brief  Max Size of Tx Message sent to callback  */
    public const int IEC104_MAX_TX_MESSAGE = 255;
    


    
    
     /*! \brief Client connect state  */
    public enum eConnectState
     {
        DATA_MODE   =   0,   /*!< Client send the startdt & data communication & command transmission follows */
        TEST_MODE   =   1,  /*!< Client send the test frame only to monitor the connection */
     }


    
    /*! \brief File transfer Status value used in filetransfer callback*/
    public enum eFileTransferStatus
    {
        FILETRANSFER_NOTINITIATED = 0,		/*!<  file transfer not initiated   */
        FILETRANSFER_STARTED = 1,		/*!<  file transfer procedure started	*/
        FILETRANSFER_INTERCEPTED = 2,		/*!<  file transfer operation interepted	*/
        FILETRANSFER_COMPLEATED = 3,		/*!<  file transfer compleated	*/
    }

    /*! \brief File transfer Status value used in filetransfer callback*/
    public enum eFileTransferDirection
    {
        MONITOR_DIRECTION = 0, /*!< in this mode, server send files to client */
        CONTROL_DIRECTION = 1, /*!< in this mode, server receive files from client */

    }



    
        /*! \brief List of error code returned by API functions */
    public class eIEC104AppErrorCodes
    {
            
            public const int APP_ERROR_ERRORVALUE_IS_NULL                = -4501;       /*!< IEC104 Error value is  null*/
            public const int APP_ERROR_CREATE_FAILED                     = -4502;       /*!< IEC104 api create function failed */
            public const int APP_ERROR_FREE_FAILED                       = -4503;       /*!< IEC104 api free function failed */
            public const int APP_ERROR_INITIALIZE                        = -4504;       /*!< IEC104 server/client initialize function failed */
            public const int APP_ERROR_LOADCONFIG_FAILED                 = -4505;       /*!< IEC104 apiLoad configuration function failed */
            public const int APP_ERROR_CHECKALLOCLOGICNODE               = -4506;       /*!< IEC104 Load- check alloc logical node function failed */
            public const int APP_ERROR_START_FAILED                      = -4507;       /*!< IEC104 api Start function failed */
            public const int APP_ERROR_STOP_FAILED                       = -4508;       /*!< IEC104 api Stop function failed */
            public const int APP_ERROR_SETDEBUGOPTIONS_FAILED            = -4509;       /*!< IEC104 set debug option failed */
            public const int APP_ERROR_PHYSICALINITIALIZE_FAILED         = -4510;       /*!< IEC104 Physical Layer initialization failed  */
            public const int APP_ERROR_DATALINKINITIALIZE_FAILED         = -4511;       /*!< IEC104 datalink Layer initialization failed  */
            public const int APP_ERROR_INVALID_FRAMESTART                = -4512;       /*!< IEC104 receive Invalid start frame 68*/
            public const int APP_ERROR_INVALID_SFRAMEFORMAT              = -4513;       /*!< IEC104 receive Invalid s format frame*/
            public const int APP_ERROR_T3T1_FAILED                       = -4514;       /*!< IEC104 T3- T1 time failed*/
            public const int APP_ERROR_UPDATE_FAILED                     = -4515;       /*!< IEC104 api update function  failed*/
            public const int APP_ERROR_TIMESTRUCT_INVALID                = -4516;       /*!< IEC104 time structure invalid*/
            public const int APP_ERROR_FRAME_ENCODE_FAILED               = -4517;       /*!< IEC104 encode operation invalid*/
            public const int APP_ERROR_INVALID_FRAME                     = -4518;       /*!< IEC104 receive frame  invalid*/
            public const int APP_ERROR_WRITE_FAILED                      = -4519;       /*!< IEC104 api write function  invalid*/
            public const int APP_ERROR_SELECT_FAILED                     = -4520;       /*!< IEC104 api select function  invalid*/
            public const int APP_ERROR_OPERATE_FAILED                    = -4521;       /*!< IEC104 api operate function  invalid*/
            public const int APP_ERROR_CANCEL_FAILED                     = -4522;       /*!< IEC104 api cancel function  invalid*/
            public const int APP_ERROR_READ_FAILED                       = -4523;       /*!< IEC104 api read function  invalid*/
            public const int APP_ERROR_DECODE_FAILED                     = -4524;       /*!< IEC104 Decode failed*/
            public const int APP_ERROR_GETDATATYPEANDSIZE_FAILED         = -4525;       /*!< IEC104 api get datatype and datasize  function  invalid*/
            public const int APP_ERROR_CLIENTSTATUS_FAILED               = -4526;       /*!< IEC104 api get client status failed*/
            public const int APP_ERROR_FILE_TRANSFER_FAILED              = -4527;       /*!< IEC104 File Transfer Failed*/
            public const int APP_ERROR_LIST_DIRECTORY_FAILED             = -4528;       /*!< IEC104 List Directory Failed*/
            public const int APP_ERROR_GET_OBJECTSTATUS_FAILED           = -4529;       /*!< IEC104 api get object status function failed*/
            public const int APP_ERROR_CLIENT_CHANGESTATE_FAILED         = -4530;       /*!< IEC104 api client change the status function failed*/
            public const int APP_ERROR_PARAMETERACT_FAILED               = -4531;       /*!< IEC104 api Parameter act function  invalid*/
    }



    /*! \brief List of error value returned by API functions */
    public class eIEC104AppErrorValues
    {
        public const int APP_ERRORVALUE_ERRORCODE_IS_NULL                =   -4501;          /*!< APP Error code is Null */
        public const int APP_ERRORVALUE_INVALID_INPUTPARAMETERS          =   -4502;          /*!< Supplied Parameters are invalid */
        public const int APP_ERRORVALUE_INVALID_APPFLAG                  =   -4503;          /*!< Invalid Application Flag , Client not supported by the API*/
        public const int APP_ERRORVALUE_UPDATECALLBACK_CLIENTONLY        =   -4504;          /*!< Update Callback used only for client*/
        public const int APP_ERRORVALUE_NO_MEMORY                        =   -4505;          /*!< Allocation of memory has failed */
        public const int APP_ERRORVALUE_INVALID_IEC104OBJECT             =   -4506;          /*!< Supplied IEC104Object is invalid */
        public const int APP_ERRORVALUE_FREE_CALLED_BEFORE_STOP          =   -4507;          /*!< APP state is running free function called before stop function*/
        public const int APP_ERRORVALUE_INVALID_STATE                    =   -4508;          /*!< IEC104OBJECT invalid state */ 
        public const int APP_ERRORVALUE_INVALID_DEBUG_OPTION             =   -4509;          /*!< invalid debug option */ 
        public const int APP_ERRORVALUE_ERRORVALUE_IS_NULL               =  -4510;          /*!< Error value is null */
        public const int APP_ERRORVALUE_INVALID_IEC104PARAMETERS         =  -4511;          /*!< Supplied parameter are invalid */
        public const int APP_ERRORVALUE_SELECTCALLBACK_SERVERONLY        =  -4512;          /*!< Select callback for server only */
        public const int APP_ERRORVALUE_OPERATECALLBACK_SERVERONLY       =  -4513;          /*!< Operate callback for server only */
        public const int APP_ERRORVALUE_CANCELCALLBACK_SERVERONLY        =  -4514;          /*!< Cancel callback for server only */
        public const int APP_ERRORVALUE_READCALLBACK_SERVERONLY          =  -4515;          /*!< Read callback for server only */
        public const int APP_ERRORVALUE_ACTTERMCALLBACK_SERVERONLY       =  -4516;          /*!< ACTTERM callback for server only */
        public const int APP_ERRORVALUE_INVALID_OBJECTNUMBER             =  -4517;          /*!< Invalid total no of object */
        public const int APP_ERRORVALUE_INVALID_COMMONADDRESS            =  -4518;          /*!< Invalid common address Slave cant use the common address -> global address 0, 65535 the total number of ca we can use 5 items*/
        public const int APP_ERRORVALUE_INVALID_K_VALUE                  =  -4519;          /*!< Invalid k value (range 1-65534) */
        public const int APP_ERRORVALUE_INVALID_W_VALUE                  =  -4520;          /*!< Invalid w value (range 1-65534)*/
        public const int APP_ERRORVALUE_INVALID_TIMEOUT                  =  -4521;          /*!< Invalid time out t (range 1-65534) */
        public const int APP_ERRORVALUE_INVALID_BUFFERSIZE               =  -4522;          /*!< Invalid Buffer Size (100 -65,535)*/
        public const int APP_ERRORVALUE_INVALID_IEC104OBJECTPOINTER      =  -4523;          /*!< Invalid Object pointer */
        public const int APP_ERRORVALUE_INVALID_MAXAPDU_SIZE             =  -4524;          /*!< Invalid APDU Size (range 41 - 252)*/
        public const int APP_ERRORVALUE_INVALID_IOA                      =  -4525;          /*!< IOA Value mismatch */
        public const int APP_ERRORVALUE_INVALID_CONTROLMODEL_SBOTIMEOUT  =  -4526;          /*!< Invalid control model |u32SBOTimeOut , for typeids from M_SP_NA_1 to M_EP_TF_1 -> STATUS_ONLY & u32SBOTimeOut 0 , for type ids C_SC_NA_1 to C_BO_TA_1 should not STATUS_ONLY & u32SBOTimeOut 0*/
        public const int APP_ERRORVALUE_INVALID_CYCLICTRANSTIME          =  -4527;          /*!< measured values cyclic tranmit time 0, or  60 Seconds to max 3600 seconds (1 hour) */
        public const int APP_ERRORVALUE_INVALID_TYPEID                   =  -4528;          /*!< Invalid typeid */
        public const int APP_ERRORVALUE_INVALID_PORTNUMBER               =  -4529;          /*!< Invalid Port number */
        public const int APP_ERRORVALUE_INVALID_MAXNUMBEROFCONNECTION    =  -4530;          /*!< invalid max number of connection */
        public const int APP_ERRORVALUE_INVALID_IPADDRESS                =  -4531;          /*!< Invalid ip address */
        public const int APP_ERRORVALUE_INVALID_RECONNECTION             =  -4532;          /*!<  VALUE MUST BE 1 TO 10 */
        public const int APP_ERRORVALUE_INVALID_NUMBEROFOBJECT           =  -4533;          /*!< Invalid total no of object  u16NoofObject 1-10000*/
        public const int APP_ERRORVALUE_INVALID_IOA_ADDRESS              =  -4534;          /*!< Invalid IOA 1-16777215*/
        public const int APP_ERRORVALUE_INVALID_RANGE                    =  -4535;          /*!< Invalid IOA Range 1-1000*/
        public const int APP_ERRORVALUE_104RECEIVEFRAMEFAILED            =  -4536;          /*!< IEC104 Receive failed*/        
        public const int APP_ERRORVALUE_INVALID_UFRAMEFORMAT             =  -4537;          /*!< Invalid frame U format*/
        public const int APP_ERRORVALUE_T3T1_TIMEOUT_FAILED              =  -4538;          /*!< t3 - t1 timeout failed*/           
        public const int APP_ERRORVALUE_KVALUE_REACHED_T1_TIMEOUT_FAILED    =   -4539;          /*!< k value reached and t1 timeout */
        public const int APP_ERRORVALUE_LASTIFRAME_T1_TIMEOUT_FAILED        =   -4540;          /*!< t1 timeout */
        public const int APP_ERRORVALUE_INVALIDUPDATE_COUNT             =   -4541;          /*!< Invalid update count*/
        public const int APP_ERRORVALUE_INVALID_DATAPOINTER             =   -4542;          /*!< Invalid data pointer*/
        public const int APP_ERRORVALUE_INVALID_DATATYPE                =   -4543;          /*!< Invalid data type */
        public const int APP_ERRORVALUE_INVALID_DATASIZE                =   -4544;          /*!< Invalid data size */
        public const int APP_ERRORVALUE_UPDATEOBJECT_NOTFOUND           =   -4545;          /*!< Invalid update object not found */
        public const int APP_ERRORVALUE_INVALID_DATETIME_STRUCT         =   -4546;          /*!< Invalid data & time structure */
        public const int APP_ERRORVALUE_INVALID_PULSETIME               =   -4547;          /*!< Invalid pulse time flag */
        public const int APP_ERRORVALUE_INVALID_COT                     =   -4548;          /*!< For commands the COT must be NOTUSED */
        public const int APP_ERRORVALUE_INVALID_CA                      =   -4549;          /*!< For commands the COT must be NOTUSED */
        public const int APP_ERRORVALUE_CLIENT_NOTCONNECTED             =   -4550;          /*!< For commands The client is not connected to server */
        public const int APP_ERRORVALUE_INVALID_OPERATION_FLAG          =   -4551;          /*!< invalid operation flag in cancel function */
        public const int APP_ERRORVALUE_INVALID_QUALIFIER               =   -4552;          /*!< invalid qualifier , KPA*/
        public const int APP_ERRORVALUE_COMMAND_TIMEOUT                 =   -4553;          /*!< command timeout, no response from server */
        public const int APP_ERRORVALUE_INVALID_FRAMEFORMAT             =   -4554;          /*!< Invalid frame format*/
        public const int APP_ERRORVALUE_INVALID_IFRAMEFORMAT            =   -4555;          /*!< invalid information frame format */
        public const int APP_ERRORVALUE_INVALID_SFRAMENUMBER            =   -4556;          /*!< invalid s frame number */
        public const int APP_ERRORVALUE_INVALID_KPA                     =   -4557;          /*!< invalid Kind of Parameter value */
        public const int APP_ERRORVALUE_FILETRANSFER_TIMEOUT            =   -4558;          /*!< file transfer timeout, no response from server */
        public const int APP_ERRORVALUE_FILE_NOT_READY                  =   -4559;          /*!< file not ready */
        public const int APP_ERRORVALUE_SECTION_NOT_READY               =   -4560;          /*!< Section not ready */  
        public const int APP_ERRORVALUE_FILE_OPEN_FAILED                =   -4561;          /*!< File Open Failed */ 
        public const int APP_ERRORVALUE_FILE_CLOSE_FAILED               =   -4562;          /*!< File Close Failed */
        public const int APP_ERRORVALUE_FILE_WRITE_FAILED               =   -4563;          /*!< File Write Failed */
        public const int APP_ERRORVALUE_FILETRANSFER_INTERUPTTED        =   -4564;          /*!< File Transfer Interrupted */
        public const int APP_ERRORVALUE_SECTIONTRANSFER_INTERUPTTED     =   -4565;          /*!< Section Transfer Interrupted */
        public const int APP_ERRORVALUE_FILE_CHECKSUM_FAILED            =   -4566;          /*!< File Checksum Failed*/
        public const int APP_ERRORVALUE_SECTION_CHECKSUM_FAILED         =   -4567;          /*!< Section Checksum Failed*/
        public const int APP_ERRORVALUE_FILE_NAME_UNEXPECTED            =   -4568;          /*!< File Name Unexpected*/
        public const int APP_ERRORVALUE_SECTION_NAME_UNEXPECTED         =   -4569;          /*!< Section Name Unexpected*/
        public const int APP_ERRORVALUE_INVALID_QRP                     =   -4570;          /*!< INVALID Qualifier of Reset Process command */
        public const int APP_ERRORVALUE_DIRECTORYCALLBACK_CLIENTONLY    =   -4571;          /*!< Directory Callback used only for client*/
        public const int APP_ERRORVALUE_INVALID_BACKGROUNDSCANTIME      =   -4572;          /*!< BACKGROUND scan time 0, or  60 Seconds to max 3600 seconds (1 hour) */
        public const int APP_ERRORVALUE_INVALID_FILETRANSFER_PARAMETER  =   -4573;          /*!< Server loadconfig, file transfer enabled, but the dir path and number of files not valid*/
        public const int APP_ERRORVALUE_INVALID_CONNECTION_MODE         =   -4574;          /*!< Client loadconfig, connection state either DATA_MODE / TEST_MODE*/    
        public const int APP_ERRORVALUE_FILETRANSFER_DISABLED           =   -4575;          /*!< Client loadconfig setings, file tranfer disabled*/   
        public const int APP_ERRORVALUE_INVALID_INTIAL_DATABASE_QUALITYFLAG     = -4576;        /*!< Server loadconfig intial databse quality flag invalid*/
        public const int APP_ERRORVALUE_INVALID_STATUSCALLBACK              = -4577;        /*!< Invalid status callback */
        public const int APP_ERRORVALUE_DEMO_EXPIRED                        = -4578;        /*!< Demo software expired contact support@freyrscada.com*/
        public const int APP_ERRORVALUE_SERVER_DISABLED                     = -4579;        /*!< Server functionality disabled in the api, please contact support@freyrscada.com */
        public const int APP_ERRORVALUE_CLIENT_DISABLED                     = -4580;        /*!< Client functionality disabled in the api, please contact support@freyrscada.com*/
        public const int APP_ERRORVALUE_DEMO_INVALID_POINTCOUNT             = -4581;       /*!< Demo software - Total Number of Points exceeded, maximum 100 points*/
        public const int APP_ERRORVALUE_INVALID_COT_SIZE                    = -4582;          /*!< Invalid cause of transmission (COT)size*/
        public const int APP_ERRORVALUE_F_SC_NA_1_SCQ_MEMORY   				= -4583;     /*!< Server received F_SC_NA_1 SCQ requested memory space not available*/
		public const int APP_ERRORVALUE_F_SC_NA_1_SCQ_CHECKSUM   			= -4584;     /*!< Server received F_SC_NA_1 SCQ checksum failed*/
		public const int APP_ERRORVALUE_F_SC_NA_1_SCQ_COMMUNICATION   		= -4585;     /*!< Server received F_SC_NA_1 SCQ unexpected communication service*/
		public const int APP_ERRORVALUE_F_SC_NA_1_SCQ_NAMEOFFILE   			= -4586;     /*!< Server received F_SC_NA_1 SCQ unexpected name of file*/
		public const int APP_ERRORVALUE_F_SC_NA_1_SCQ_NAMEOFSECTION   		= -4587;     /*!< Server received F_SC_NA_1 SCQ unexpected name of Section*/
		public const int APP_ERRORVALUE_F_SC_NA_1_SCQ_UNKNOWN   				= -4588;     /*!< Server received F_SC_NA_1 SCQ Unknown*/		
		public const int APP_ERRORVALUE_F_AF_NA_1_SCQ_MEMORY   				= -4589;     /*!< Server received F_AF_NA_1 SCQ requested memory space not available*/
		public const int APP_ERRORVALUE_F_AF_NA_1_SCQ_CHECKSUM   			= -4590;     /*!< Server received F_AF_NA_1 SCQ checksum failed*/
		public const int APP_ERRORVALUE_F_AF_NA_1_SCQ_COMMUNICATION   		= -4591;     /*!< Server received F_AF_NA_1 SCQ unexpected communication service*/
		public const int APP_ERRORVALUE_F_AF_NA_1_SCQ_NAMEOFFILE   			= -4592;     /*!< Server received F_AF_NA_1 SCQ unexpected name of file*/
		public const int APP_ERRORVALUE_F_AF_NA_1_SCQ_NAMEOFSECTION   		= -4593;     /*!< Server received F_AF_NA_1 SCQ unexpected name of Section*/
        public const int APP_ERRORVALUE_F_AF_NA_1_SCQ_UNKNOWN               = -4594;     /*!< Server received F_AF_NA_1 SCQ Unknown*/ 

    }
     
 
    /*! \brief Update flags */
    public enum eUpdateFlags
    {
        UPDATE_DATA                                   = 0x01,       /*!< Update the data value*/
        UPDATE_QUALITY                                = 0x02,       /*!< Update the quality */
        UPDATE_TIME                                   = 0x04,       /*!< Update the timestamp*/
        UPDATE_ALL                                    = 0x07,       /*!< Update Data, Quality and Time Stamp */
    }

    
    
    /*! \brief  IEC104 Debug Parameters */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
    CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104DebugParameters
    {
        public uint u32DebugOptions;                /*!< Debug Options */
    }

    /*! \brief  IEC104 Update Option Parameters */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
    CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104UpdateOptionParameters
    {
        public ushort u16Count;            /*!< Number of IEC 104 Data attribute ID and Data attribute data to be updated simultaneously */
    }


    /*! \brief  IEC104 Object Structure */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104Object
    {            
        public iec60870common.eIEC870TypeID                  eTypeID;                    /*!< Type Identifcation */
        public iec60870common.eIEC870COTCause eIntroCOT;                  /*!< Interrogation group */
        public iec60870common.eControlModelConfig eControlModel;              /*!< Control Model specified in eControlModelFlags */
        public iec60870common.eKindofParameter eKPA;                         /*!< For typeids,P_ME_NA_1, P_ME_NB_1, P_ME_NC_1 - Kind of parameter , refer enum eKPA for other typeids - PARAMETER_NONE*/
        public uint                           u32IOA;                     /*!< Informatiion Object Address */
        public ushort                         u16Range;                   /*!< Range */
        public uint                           u32SBOTimeOut;              /*!< Select Before Operate Timeout in milliseconds */
        public ushort                         u16CommonAddress;            /*!< Common Address , 0 - not used, 1-65534 station address, 65535 = global address (only master can use this)*/
        public uint                           u32CyclicTransTime;         /*!< Periodic or Cyclic Transmissin time in seconds. If 0 do not transmit Periodically (only applicable to measured values, and the reporting typeids M_ME_NA_1, M_ME_NB_1, M_ME_NC_1, M_ME_ND_1) MINIMUM 60 Seconds, max 3600 seconds (1 hour)*/
        public uint                           u32BackgroundScanPeriod;    /*!< in seconds, if 0 the background scan will not be performed, MINIMUM 60 Seconds, max 3600 seconds (1 hour), all monitoring iinformation except Integrated totals will be transmitteed . the reporting typeid without timestamp*/
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtcommon.APP_OBJNAMESIZE)]
        public string                         ai8Name;   /*!< Name */
                
    }

    /*! \brief	IEC104 Server Remote IPAddress list*/
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
	public struct sIEC104ServerRemoteIPAddressList
    {
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
        public string ai8RemoteIPAddress;  /*!< Remote IP Address , use 0,0.0.0 to accept all remote station ip*/
        
    }
    
        /*! \brief  IEC104 Server Connection Structure */
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sServerConnectionParameters
    {       

        public short               i16k;                                    /*!< Maximum difference receive sequence number to send state variable (k: 1 to 32767) default - 12*/
        public short               i16w;                                    /*!< Latest acknowledge after receiving w I format APDUs (w: 1 to 32767 APDUs, accuracy 1 APDU (Recommendation: w should not exceed two-thirds of k) default :8)*/
        public byte                u8t0;                                    /*!< Time out of connection establishment in seconds (1-255s)*/
        public byte                u8t1;                                    /*!< Time out of send or test APDUs in seconds (1-255s)*/
        public byte                u8t2;                                    /*!< Time out for acknowledges in case of no data message t2 M t1 in seconds (1-172800 sec)*/
        public ushort              u16t3;                                   /*!< Time out for sending test frames in case of long idle state in seconds ( 1 to 48h( 172800sec)) */
        public ushort              u16EventBufferSize;                      /*!< SOE - Event Buffer Size (50 -65,535)*/
        public uint                u32ClockSyncPeriod;                      /*!< Clock Synchronisation period in milliseconds. If 0 than Clock Synchronisation command is not expected from Master */
        public byte                bGenerateACTTERMrespond;                 /*!< if Yes , Generate ACTTERM  responses for operate commands*/
        public ushort              u16PortNumber;                           /*!<  Port Number , default 2404*/
        public byte                bEnableRedundancy;                       /*!<  enable redundancy for the connection */ 
        public ushort              u16RedundPortNumber;                          /*!< Redundancy Port Number */
        public ushort u16MaxNumberofRemoteConnection;               /*!< 1-5; max number of parallel client communication struct sIEC104ServerRemoteIPAddressList*/
        public System.IntPtr psServerRemoteIPAddressList;             /*!< Pointer to struct sIEC104ServerRemoteIPAddressList */
        
    
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
        public string              ai8SourceIPAddress;  /*!< Server IP Address , use 0.0.0.0 / network ip address*/
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
        public string              ai8RedundSourceIPAddress;  /*!< Redundancy Server IP Address , use 0.0.0.0 / network ip address */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
        public string ai8RedundRemoteIPAddress;  /*!< Redundancy Remote IP Address , use 0,0.0.0 to accept all remote station ip */
            
    }
    
    /*! \brief  Server settings  */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sServerSettings
    {
        public byte                         bEnablefileftransfer;                   /*!< enable / disable File Transfer */
        public ushort                       u16MaxFilesInDirectory;                 /*!< Maximum No of Files in Directory(default 25) */
        public byte                         bEnableDoubleTransmission;              /*!< enable double transmission */ 
        public byte                         u8TotalNumberofStations;                /*!< in a single physical device/ server, we can run many stations - nmuber of stations in our server ,according to common address (1-5) */
        public byte                         benabaleUTCtime;                        /*!< enable utc time/ local time*/      
        public byte                         bTransmitSpontMeasuredValue;            /*!< transmit M_ME measured values in spontanous message */ 
        public byte                         bTranmitInterrogationMeasuredValue;     /*!< transmit M_ME measured values in General interrogation */
        public byte                         bTransmitBackScanMeasuredValue;         /*!< transmit M_ME measured values in background message */     
        public ushort                       u16ShortPulseTime;                      /*!< Short Pulse Time in milliseconds */
        public ushort                       u16LongPulseTime;                       /*!< Long Pulse Time in milliseconds */
        public byte                         bServerInitiateTCPconnection;			/*!< Server will initiate the TCP/IP connection to Client, if true, the u16MaxNumberofConnection must be one, and  bEnableRedundancy must be FALSE;*/
        public byte                         u8InitialdatabaseQualityFlag;           /*!< 0-online, 1 BIT- iv, 2 BIT-nt,  MAX VALUE -3   */
        public byte                         bUpdateCheckTimestamp;                  /*!< if it true ,the timestamp change also generate event  during the iec104update */
        public byte 						bSequencebitSet;						  /*!< If it true, Server builds iec frame with sequence for monitoring information without time stamp */
		public iec60870common.eCauseofTransmissionSize eCOTsize;                              /*!< Cause of transmission size - Default - COT_TWO_BYTE*/
    	public ushort                       u16NoofObject;                          /*!< Total number of IEC104 Objects 1-10000*/
        public sIEC104DebugParameters       sDebug;                                 /*!< Debug options settings on loading the configuarion See struct sIEC104DebugParameters */            
        public System.IntPtr                psIEC104Objects;                    /*!< Pointer to strcuture IEC 104 Objects */
        public sServerConnectionParameters  sServerConParameters;             /*!< pointer to number of parallel client communication */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = iec60870common.MAX_DIRECTORY_PATH)]
        public string                       ai8FileTransferDirPath; /*!< File Transfer Directory Path */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = iec60870common.MAX_CA, ArraySubType = System.Runtime.InteropServices.UnmanagedType.U2)]
        public ushort[]                     au16CommonAddress;                      /*!< in a single physical device we can run many stations,station address- Common Address , 0 - not used, 1-65534 , 65535 = global address (only master can use this)*/
       
    
    }
    
        /*! \brief  client connection parameters  */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sClientConnectionParameters
    {
        public eConnectState            eState;                                         /*!< Connection mode - Data mode, - data transfer enabled, Test Mode - socket connection established only test signals transmited */
        public byte                     u8TotalNumberofStations;                        /*!< total number of station/sector range 1-5 */
        public byte                     u8OrginatorAddress;                     /*!< Orginator Address , 0 - not used, 1-255*/
        public short                    i16k;                                   /*!< Maximum difference receive sequence number to send state variable (k: 1 to 32767) default - 12*/
        public short                    i16w;                                   /*!< Latest acknowledge after receiving w I format APDUs (w: 1 to 32767 APDUs, accuracy 1 APDU (Recommendation: w should not exceed two-thirds of k) default :8)*/
        public byte                     u8t0;                                   /*!< Time out of connection establishment in seconds (1-255s)*/
        public byte                     u8t1;                                   /*!< Time out of send or test APDUs in seconds (1-255s)*/
        public byte                     u8t2;                                   /*!< Time out for acknowledges in case of no data message t2 M t1 in seconds (1-255s)*/
        public ushort                   u16t3;                                  /*!< Time out for sending test frames in case of long idle state in seconds ( 1 to 172800 sec) */
        public uint                     u32GeneralInterrogationInterval;    /*!< in sec if 0 , gi will not send in particular interval, else in particular seconds GI will send to server*/
        public uint                     u32Group1InterrogationInterval;     /*!< in sec if 0 , group 1 interrogation will not send in particular interval, else in particular seconds group 1 interrogation will send to server*/
        public uint                          u32Group2InterrogationInterval;        /*!< in sec if 0 , group 2 interrogation will not send in particular interval, else in particular seconds group 2 interrogation will send to server*/
        public uint                          u32Group3InterrogationInterval;        /*!< in sec if 0 , group 3 interrogation will not send in particular interval, else in particular seconds group 3 interrogation will send to server*/
        public uint                          u32Group4InterrogationInterval;        /*!< in sec if 0 , group 4 interrogation will not send in particular interval, else in particular seconds group 4 interrogation will send to server*/
        public uint                          u32Group5InterrogationInterval;        /*!< in sec if 0 , group 5 interrogation will not send in particular interval, else in particular seconds group 5 interrogation will send to server*/
        public uint                          u32Group6InterrogationInterval;        /*!< in sec if 0 , group 6 interrogation will not send in particular interval, else in particular seconds group 6 interrogation will send to server*/
        public uint                          u32Group7InterrogationInterval;        /*!< in sec if 0 , group 7 interrogation will not send in particular interval, else in particular seconds group 7 interrogation will send to server*/
        public uint                          u32Group8InterrogationInterval;        /*!< in sec if 0 , group 8 interrogation will not send in particular interval, else in particular seconds group 8 interrogation will send to server*/
        public uint                          u32Group9InterrogationInterval;        /*!< in sec if 0 , group 9 interrogation will not send in particular interval, else in particular seconds group 9 interrogation will send to server*/
        public uint                          u32Group10InterrogationInterval;    /*!< in sec if 0 , group 10 interrogation will not send in particular interval, else in particular seconds group 10 interrogation will send to server*/
        public uint                          u32Group11InterrogationInterval;    /*!< in sec if 0 , group 11 interrogation will not send in particular interval, else in particular seconds group 11 interrogation will send to server*/
        public uint                          u32Group12InterrogationInterval;    /*!< in sec if 0 , group 12 interrogation will not send in particular interval, else in particular seconds group 12 interrogation will send to server*/
        public uint                          u32Group13InterrogationInterval;    /*!< in sec if 0 , group 13 interrogation will not send in particular interval, else in particular seconds group 13 interrogation will send to server*/
        public uint                          u32Group14InterrogationInterval;    /*!< in sec if 0 , group 14 interrogation will not send in particular interval, else in particular seconds group 14 interrogation will send to server*/
        public uint                          u32Group15InterrogationInterval;    /*!< in sec if 0 , group 15 interrogation will not send in particular interval, else in particular seconds group 15 interrogation will send to server*/
        public uint                          u32Group16InterrogationInterval;    /*!< in sec if 0 , group 16 interrogation will not send in particular interval, else in particular seconds group 16 interrogation will send to server*/
        public uint                          u32CounterInterrogationInterval;    /*!< in sec if 0 , ci will not send in particular interval*/
        public uint                          u32Group1CounterInterrogationInterval;    /*!< in sec if 0 , group 1 counter interrogation will not send in particular interval*/
        public uint                          u32Group2CounterInterrogationInterval;    /*!< in sec if 0 , group 2 counter interrogation will not send in particular interval*/
        public uint                          u32Group3CounterInterrogationInterval;    /*!< in sec if 0 , group 3 counter interrogation will not send in particular interval*/
        public uint                          u32Group4CounterInterrogationInterval;    /*!< in sec if 0 , group 4 counter interrogation will not send in particular interval*/            
        public uint                          u32ClockSyncInterval;               /*!< in sec if 0 , clock sync, will not send in particular interval */
        public uint                          u32CommandTimeout;                  /*!< in ms, minimum 3000  */
        public uint                          u32FileTransferTimeout;             /*!< in ms, minimum 3000  */ 
        public byte                             bCommandResponseActtermUsed;        /*!< server sends ACTTERM in command response */
        public ushort                           u16PortNumber;                                  /*!< Port Number */
        public byte                             bEnablefileftransfer;                           /*!< enable / disable File Transfer */
        public byte                             bUpdateCallbackCheckTimestamp;                  /*!< if it true ,the timestamp change also create the updatecallback */
        public iec60870common.eCauseofTransmissionSize eCOTsize;                              /*!< Cause of transmission size - Default - COT_TWO_BYTE*/
    	public ushort                           u16NoofObject;                                  /*!< Total number of IEC104 Objects 0-10000*/
        public System.IntPtr                    psIEC104Objects;                            /*!< Pointer to strcuture IEC104 Objects */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = iec60870common.MAX_CA, ArraySubType = System.Runtime.InteropServices.UnmanagedType.U2)]
        public ushort[]                         au16CommonAddress;                      /*!< in a single physical device we can run many stations,station address- Common Address , 0 - not used, 1-65534 , 65535 = global address (only master can use this)*/
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
        public string                           ai8DestinationIPAddress;    /*!< Server IP Address */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = iec60870common.MAX_DIRECTORY_PATH)]     
        public string                           ai8FileTransferDirPath;     /*!< File Transfer Directory Path */
        
    }
    
        /*! \brief  Client settings  */     
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sClientSettings  
    {
        public byte                 bAutoGenIEC104DataObjects;						/*!< if it true ,the IEC104 Objects created automaticallay, use u16NoofObject = 0, psIEC104Objects = NULL*/
        public ushort               u16UpdateBuffersize;				/*!< if bAutoGenIEC104DataObjects true, update callback buffersize, approx 3 * max count of monitoring points in the server */		
		public byte                 bClientAcceptTCPconnection;			/*!< Client will accept the TCP/IP connection from server, default - False, if true u16TotalNumberofConnection = 1 , and bAutoGenIEC104DataObjects = true*/
        public ushort               u16TotalNumberofConnection;                             /*!< total number of connection */
        public byte                 benabaleUTCtime;                            /*!< enable utc time/ local time*/ 
        public sIEC104DebugParameters   sDebug;                             /*!< Debug options settings on loading the configuarion See struct sIEC104DebugParameters */            
        public System.IntPtr        psClientConParameters;          /*!< pointer to client connection parameters */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
        public string              ai8SourceIPAddress; 	/*!< client own IP Address , use 0.0.0.0 / network ip address for binding socket*/   
		
    }

    /*! \brief  IEC104 Configuration parameters  */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104ConfigurationParameters
    {                        
        public sServerSettings          sServerSet;                         /*!< Server settings */ 
        public sClientSettings          sClientSet;                         /*!< Client settings */             
    }
    

    /*! \brief      IEC104 Data Attribute */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104DataAttributeID
    {
        public ushort                           u16PortNumber;                              /*!< Port Number */  
        public ushort                           u16CommonAddress;                               /*!< Orginator Address /Common Address , 0 - not used, 1-65534 station address, 65535 = global address (only master can use this)*/
        public uint                             u32IOA;                 /*!< Information Object Address */
        public iec60870common.eIEC870TypeID                    eTypeID;                /*!< Type Identification */
        public System.IntPtr                    pvUserData;            /*!< Application specific User Data */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
        public string                           ai8IPAddress;                       /*!< IP Address */ 
    }

    
    /*! \brief      IEC104 Data Attribute Data */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104DataAttributeData
    {
        public tgtcommon.sTargetTimeStamp                sTimeStamp;         /*!< TimeStamp */
        public ushort                       tQuality;           /*!< Quality of Data see eIEC104QualityFlags */
        public tgtcommon.eDataTypes eDataType;          /*!< Data Type */
        public tgttypes.eDataSizes eDataSize;          /*!< Data Size */
        public tgtcommon.eTimeQualityFlags eTimeQuality; /*!< time quality */
        public ushort                       u16ElapsedTime;      /*!< Elapsed time(M_EP_TA_1, M_EP_TD_1) /Relay duration time(M_EP_TB_1, M_EP_TE_1) /Relay Operating time (M_EP_TC_1, M_EP_TF_1)  In Milliseconds */
        public byte                         bTimeInvalid;       /*!< time Invalid */
        public byte                         bTRANSIENT; 		/*!<transient state indication result value step position information*/
        public byte                         u8Sequence; 		/*!< m_it - Binary counter reading - Sequence notation*/
        public System.IntPtr pvData;            /*!< Pointer to Data */ 
    }

    /*! \brief      Parameters provided by read callback   */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104ReadParameters
    {
        public byte   u8OrginatorAddress;     /*!< client orginator address */
        public byte   u8Dummy;                /*!< Dummy only for future expansion purpose */
    }

    /*! \brief      Parameters provided by write callback   */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104WriteParameters
    {
        public byte             u8OrginatorAddress;         /*!< client orginator address */
        public iec60870common.eIEC870COTCause eCause;           /*!< cause of transmission */
        public byte             u8Dummy;                    /*!< Dummy only for future expansion purpose */
    }

    /*! \brief      Parameters provided by update callback   */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104UpdateParameters
    {
        public iec60870common.eIEC870COTCause eCause;                         /*!< Cause of transmission */
        public iec60870common.eKindofParameter eKPA;                      /*!< For typeids,P_ME_NA_1, P_ME_NB_1, P_ME_NC_1 - Kind of parameter , refer enum eKPA*/

    }

    /*! \brief      Parameters provided by Command callback   */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104CommandParameters
    {
        public byte                     u8OrginatorAddress;                 /*!<  client orginator address */
        public iec60870common.eCommandQOCQU eQOCQU;                     /*!< Qualifier of Commad */
        public uint                     u32PulseDuration;           /*!< Pulse Duration Based on the Command Qualifer */
        
    }

    /*! \brief      Parameters provided by parameter act callback   */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104ParameterActParameters
    {
         public byte                u8OrginatorAddress;             /*!<  client orginator address */
         public byte                u8QPA;                      /*!< Qualifier of parameter activation/kind of parameter , for typeid P_AC_NA_1, please refer 7.2.6.25, for typeid 110,111,112 please refer KPA 7.2.6.24*/
    }
    
        /*! \brief  IEC104 Debug Callback Data */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104DebugData
    {
        public uint                         u32DebugOptions;                            /*!< Debug Option see eDebugOptionsFlag */
        public short                        iErrorCode;                                 /*!< error code if any */
        public short                        tErrorvalue;                                /*!< error value if any */
        public ushort                       u16RxCount;                                 /*!< Receive data count */
        public ushort                       u16TxCount;                                 /*!< Transmitted data count */
        public ushort                       u16PortNumber;                          /*!<  Port Number*/
        public tgtcommon.sTargetTimeStamp sTimeStamp;                                 /*!< TimeStamp */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_ERROR_MESSAGE)]
        public string                       au8ErrorMessage;         /*!< error message */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_WARNING_MESSAGE)]
        public string                       au8WarningMessage;     /*!< warning message */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = IEC104_MAX_RX_MESSAGE)]
        public byte[]                       au8RxData;                 /*!< Received data  */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = IEC104_MAX_TX_MESSAGE)]
        public byte[]                       au8TxData;                  /*!< Transmitted data  */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
        public string                       ai8IPAddress;   /*!<IP Address */
        
    }

    /*! \brief IEC104 File Attributes*/
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104FileAttributes
    {
        public byte                         bFileDirectory;                  /*!< File /Directory File-1,Directory 0 */                      
        public ushort                       u16FileName;                     /*!< File Name */
        public uint                         zFileSize;                       /*!< File size*/
        public byte                         bLastFileOfDirectory;            /*!< Last File Of Directory*/
        public tgtcommon.sTargetTimeStamp sLastModifiedTime;               /*!< Last Modified Time*/        
    }

    /*! \brief IEC104 Directory List*/
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104DirectoryList
    {
        public ushort                      u16FileCount;                         /*!< File Count read from the Directory */
        public System.IntPtr               psFileAttrib;                        /*!< Pointer to File Attributes */
    }

     /*! \brief server connection detail*/
     [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104ServerConnectionID
    {
        public ushort              u16SourcePortNumber;                     /*!< Source port number */      
        public ushort              u16RemotePortNumber;                      /*!< remote port number */
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]
        public string               ai8SourceIPAddress; /*!< Server IP Address , use 0.0.0.0 / network ip address*/ 
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = tgtdefines.MAX_IPV4_ADDRSIZE)]      
        public string               ai8RemoteIPAddress; /*!< Remote IP Address , use 0,0.0.0 to accept all remote station ip*/ 
     }

    /*! \brief error code more description */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104ErrorCode
    {
        public short iErrorCode;     /*!< errorcode */
        public System.IntPtr shortDes;       /*!< error code short description*/
         public System.IntPtr LongDes;        /*!< error code brief description*/
    }

    
    /*! \brief error value more description */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104ErrorValue
    {
         public short iErrorValue;        /*!< errorvalue */
         public System.IntPtr shortDes;       /*!< string - error value short description*/
         public System.IntPtr LongDes;        /*!< string - error value brief description*/
    }


    /*! \brief          IEC104 Read call-back
     *  \ingroup        IEC104Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptReadID        Pointer to IEC 104 Data Attribute ID
     *  \param[out]     ptReadValue     Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptReadParams    Pointer to Read parameters      
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample read call-back
     *                  enum eAppErrorCodes cbRead(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptReadID,struct sIEC104DataAttributeData *ptReadValue, struct sIEC104ReadParameters *ptReadParams, tErrorValue *ptErrorValue )
     *                  {
     *                      enum eAppErrorCodes     eErrorCode      = APP_ERROR_NONE;
     *                      Unsigned16              u16AnalogVal    = 0;
     *
     *                      // If the type ID and IOA matches increment the analog value and send it.
     *                      if((ptReadID->eTypeID == M_ME_TD_1) && (ptReadID->u32IOA == 5000))
     *                      {
     *                          u16AnalogVal++;
     *                          ptReadParams->pvData = &u16AnalogVal;
     *                      }
     *                          
     *                      return eErrorCode;
     *                  }
     *  \endcode
     */ 
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104ReadCallback(ushort u16ObjectId, ref sIEC104DataAttributeID ptReadID, ref sIEC104DataAttributeData ptReadValue, ref sIEC104ReadParameters ptReadParams, ref short ptErrorValue);

    /*! \brief          IEC104 Write call-back
     *  \ingroup        IEC104Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptWriteID       Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptWriteValue    Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptWriteParams   Pointer to Write parameters       
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample write call-back
     *                  enum eAppErrorCodes cbWrite(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptWriteID,struct sIEC104DataAttributeData *ptWriteValue, struct sIEC104WriteParameters *ptWriteParams, tErrorValue *ptErrorValue )
     *                  {
     *                      enum eAppErrorCodes     eErrorCode      = APP_ERROR_NONE;
     *                      struct sTargetTimeStamp    sReceivedTime   = {0};
     *
     *                      // If the type ID is Clock Synchronisation than set time and date based on target
     *                      if(ptWriteID->eTypeID == C_CS_NA_1)
     *                      {
     *                          memcpy(&sReceivedTime, ptWriteValue->sTimeStamp, sizeof(struct sTargetTimeStamp));
     *                          SetTimeDate(&sReceivedTime);
     *                      }
     *                          
     *                      return eErrorCode;
     *                  }
     *  \endcode
     */   
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104WriteCallback(ushort u16ObjectId, ref sIEC104DataAttributeID ptWriteID, ref sIEC104DataAttributeData ptWriteValue, ref sIEC104WriteParameters ptWriteParams, ref short ptErrorValue);

    /*! \brief          IEC104 Update call-back
     *  \ingroup        IEC104Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptUpdateID       Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptUpdateValue    Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptUpdateParams   Pointer to Update parameters       
     *  \param[out]     ptErrorValue     Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample update call-back
     *                  enum eAppErrorCodes cbUpdate(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptUpdateID, struct sIEC104DataAttributeData *ptUpdateValue, struct sIEC104UpdateParameters *ptUpdateParams, tErrorValue *ptErrorValue )
     *                  {
     *                      enum eAppErrorCodes     eErrorCode          = APP_ERROR_NONE;
     *                      Float32                 f32TemperatueVal    = 0.0;
     *
     *                      // Check if we received the type ID and IOA than display the temperature
     *                      if((ptUpdateID->eTypeID == M_ME_TF_1) && (ptUpdateID->u32IOA == 7000))
     *                      {
     *                          memcpy(&f32TemperatueVal, ptUpdateValue->pvData, ptUpdateValue-> eDataSize);
     *                          DisplayTemperature(f32TemperatueVal);
     *                      }
     *                          
     *                      return eErrorCode;
     *                  }
     *  \endcode
     */        
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104UpdateCallback(ushort u16ObjectId, ref sIEC104DataAttributeID ptUpdateID, ref sIEC104DataAttributeData ptUpdateValue, ref sIEC104UpdateParameters ptUpdateParams, ref short ptErrorValue);

    /*! \brief          IEC104 Directory call-back
     *  \ingroup        IEC104Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptDirectoryID    Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptDirList        Pointer to IEC 104 sIEC104DirectoryList 
     *  \param[out]     ptErrorValue     Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  enum eTgtErrorCodes cbDirectory(struct sIEC104DataAttributeID * psDirectoryID, const struct sIEC104DirectoryList *psDirList, tErrorValue * ptErrorValue)
     *                  {
     *                      enum eTgtErrorCodes eErrorCode       =  EC_NONE;
     *                      Unsigned16          u16UptoFileCount =  ZERO;
     *  
     *                      printf("\n Directory CallBack Called");
     *                 
     *                      printf("\r\n server ip %s",psDirectoryID->ai8IPAddress);
     *                      printf("\r\n server port %u",psDirectoryID->u16PortNumber);
     *                      printf("\r\n server ca %u",psDirectoryID->u16CommonAddress);
     *                      printf("\r\n Data Attribute ID is  %u IOA %u ",psDirectoryID->eTypeID, psDirectoryID->u32IOA);
     *                 
     *                      printf("\n No Of Files in the Directory :%u", psDirList->u16FileCount);
     *                  u16UptoFileCount = 0;
     *                      while(u16UptoFileCount < psDirList->u16FileCount)
     *                      {
     *                          printf("\n \n Object Index:%u   File Name:%u    SizeofFile:%lu", u16UptoFileCount, psDirList->psFileAttrib[u16UptoFileCount].u16FileName, psDirList->psFileAttrib[u16UptoFileCount].zFileSize);
     *                          printf("\n Time:%02d:%02d:%02d:%02d:%02d",  psDirList->psFileAttrib[u16UptoFileCount].sLastModifiedTime.u8Hour, psDirList->psFileAttrib[u16UptoFileCount].sLastModifiedTime.u8Minute, psDirList->psFileAttrib[u16UptoFileCount].sLastModifiedTime.u8Seconds, psDirList->psFileAttrib[u16UptoFileCount].sLastModifiedTime.u16MilliSeconds, psDirList->psFileAttrib[u16UptoFileCount].sLastModifiedTime.u16MicroSeconds);
     *                          printf(" Date:%02d:%02d:%04d:%02d\n", psDirList->psFileAttrib[u16UptoFileCount].sLastModifiedTime.u8Day, psDirList->psFileAttrib[u16UptoFileCount].sLastModifiedTime.u8Month,psDirList->psFileAttrib[u16UptoFileCount].sLastModifiedTime.u16Year,psDirList->psFileAttrib[u16UptoFileCount].sLastModifiedTime.u8DayoftheWeek);
     *                          u16UptoFileCount++;
     *                      }
     *                      return eErrorCode;
     *                  }            
     *  \endcode
     */ 
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104DirectoryCallback(ushort u16ObjectId, ref sIEC104DataAttributeID ptDirectoryID, ref sIEC104DirectoryList ptDirList, ref short ptErrorValue);

    /*! \brief          IEC104 Control Select call-back
     *  \ingroup        IEC104Call-back
     *  
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptSelectID       Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptSelectValue    Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptSelectParams   Pointer to select parameters       
     *  \param[out]     ptErrorValue     Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample select call-back
     *                  
     *                  enum eAppErrorCodes cbSelect(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptSelectID, struct sIEC104DataAttributeData *ptSelectValue, struct sIEC104CommandParameters *ptSelectParams, tErrorValue *ptErrorValue )     
     *                  {
     *                      enum eAppErrorCodes     eErrorCode          = APP_ERROR_NONE;
     *                      Unsigned8               u8CommandVal        = 0;
     *
     *                      // Check if we received the type ID and IOA and perform Select in the hardware
     *                      if((ptSelectID->eTypeID == C_SC_NA_1) && (ptSelectID->u32IOA == 9000))
     *                      {
     *                          memcpy(&u8CommandVal, ptSelectValue->pvData, ptSelectValue->eDataSize);
     *                          HardwareControlSelect(u8CommandVal);
     *                      }
     *                          
     *                      return eErrorCode;
     *                  }
     *  \endcode
     */        
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104ControlSelectCallback(ushort u16ObjectId, ref sIEC104DataAttributeID ptSelectID, ref sIEC104DataAttributeData ptSelectValue, ref sIEC104CommandParameters ptSelectParams, ref short ptErrorValue);

    /*! \brief          IEC104 Control Operate call-back
     *  \ingroup        IEC104Call-back
     *  
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptOperateID      Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptOperateValue   Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptOperateParams  Pointer to Operate parameters       
     *  \param[out]     ptErrorValue     Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample control operate call-back
     *                  
     *                  enum eAppErrorCodes cbOperate(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue, struct sIEC104CommandParameters *ptOperateParams, tErrorValue *ptErrorValue )     
     *                  {
     *                      enum eAppErrorCodes     eErrorCode          = APP_ERROR_NONE;
     *                      Unsigned8               u8CommandVal        = 0;
     *
     *                      // Check if we received the type ID and IOA and perform Operate in the hardware
     *                      if((ptOperateID->eTypeID == C_SC_NA_1) && (ptOperateID->u32IOA == 9000))
     *                      {
     *                          memcpy(&u8CommandVal, ptOperateValue->pvData, ptOperateValue->eDataSize);
     *                          HardwareControlOperate(u8CommandVal);
     *                      }
     *                          
     *                      return eErrorCode;
     *                  }
     *  \endcode
     */            
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104ControlOperateCallback(ushort u16ObjectId, ref sIEC104DataAttributeID ptOperateID, ref sIEC104DataAttributeData ptOperateValue, ref sIEC104CommandParameters ptOperateParams, ref short ptErrorValue);

    /*! \brief          IEC104 Control Cancel call-back
     *  \ingroup        IEC104Call-back
     *   
     *  \param[in]      u16ObjectId     IEC104 object identifier
	 *  \param[in]      eOperation		enum of	eOperationFlag 
     *  \param[in]      ptCancelID      Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptCancelValue   Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptCancelParams  Pointer to Cancel parameters       
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample control cancel call-back
     *                  
     *                  enum eAppErrorCodes cbCancel(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptCancelID, struct sIEC104DataAttributeData *ptCancelValue, struct sIEC104CommandParameters *ptCancelParams, tErrorValue *ptErrorValue )     
     *                  {
     *                      enum eAppErrorCodes     eErrorCode          = APP_ERROR_NONE;
     *                      Unsigned8               u8CommandVal        = 0;
     *
     *                      // Check if we received the type ID and IOA and perform Cancel in the hardware
     *                      if((ptCancelID->eTypeID == C_SC_NA_1) && (ptCancelID->u32IOA == 9000))
     *                      {
     *                          memcpy(&u8CommandVal, ptCancelValue->pvData, ptCancelValue->eDataSize);
     *                          HardwareControlCancel(u8CommandVal);
     *                      }
     *                          
     *                      return eErrorCode;
     *                  }
     *  \endcode
     */                
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104ControlCancelCallback(ushort u16ObjectId, iec60870common.eOperationFlag eOperation, ref sIEC104DataAttributeID ptCancelID, ref sIEC104DataAttributeData ptCancelValue, ref sIEC104CommandParameters ptCancelParams, ref short ptErrorValue);

    /*! \brief          IEC104 Control Freeze Callback
     *  \ingroup        IEC104Call-back
     *   
     *  \param[in]      u16ObjectId     IEC104 object identifier
	 *  \param[in]      eCounterFreeze	enum of	eIEC104CounterFreezeFlags 
     *  \param[in]      ptFreezeID       Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptFreezeValue    Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptFreezeCmdParams   Pointer to Freeze parameters       
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample Control Freeze Callback
     *                  enum eAppErrorCodes cbControlFreezeCallback(Unsigned16 u16ObjectId, enum eIEC104CounterFreezeFlags eCounterFreeze, struct sIEC104DataAttributeID *ptFreezeID,  struct sIEC104DataAttributeData *ptFreezeValue, struct sIEC104WriteParameters *ptFreezeCmdParams, tErrorValue *ptErrorValue )
     *                  {
     *                      enum eAppErrorCodes     eErrorCode      = APP_ERROR_NONE;
     *                      struct sTargetTimeStamp    sReceivedTime   = {0};
     *
     *                      // get freeze counter interrogation groub & process it in harware level
     *                          
     *                      return eErrorCode;
     *                  }
     *  \endcode
     */
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104ControlFreezeCallback(ushort u16ObjectId, iec60870common.eCounterFreezeFlags eCounterFreeze, ref sIEC104DataAttributeID ptFreezeID, ref sIEC104DataAttributeData ptFreezeValue, ref sIEC104WriteParameters ptFreezeCmdParams, ref short ptErrorValue);

    /*! \brief          IEC104 Control Pulse End ActTerm Callback
     *  \ingroup        IEC104 Call-back
     *  
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptOperateID      Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptOperateValue   Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptOperateParams  Pointer to pulse end parameters       
     *  \param[out]     ptErrorValue     Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample control operate call-back
     *                  
     *                  enum eAppErrorCodes cbPulseEndActTermCallback(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue, struct sIEC104CommandParameters *ptOperateParams, tErrorValue *ptErrorValue )     
     *                  {
     *                      enum eAppErrorCodes     eErrorCode          = APP_ERROR_NONE;
     *                      Unsigned8               u8CommandVal        = 0;
     *
     *                      // Check if we received the type ID and IOA and perform pulse end Operate in the hardware
     *                      if((ptOperateID->eTypeID == C_SC_NA_1) && (ptOperateID->u32IOA == 9000))
     *                      {
     *                          memcpy(&u8CommandVal, ptOperateValue->pvData, ptOperateValue->eDataSize);
     *                          HardwareControlOperate(u8CommandVal);
     *                      }
     *                          
     *                      return eErrorCode;
     *                  }
     *  \endcode
     */    
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104ControlPulseEndActTermCallback(ushort u16ObjectId, ref sIEC104DataAttributeID ptOperateID, ref sIEC104DataAttributeData ptOperateValue, ref sIEC104CommandParameters ptOperateParams, ref short ptErrorValue);

    /*! \brief          IEC104 Debug call-back
     *  \ingroup        IEC104Call-back
     *   
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptDebugData     Pointer to debug data
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample debug call-back
     *                  
     *                  enum eAppErrorCodes cbDebug(Unsigned16 u16ObjectId, struct sIEC104DebugData *ptDebugData, tErrorValue *ptErrorValue )     
     *                  {
     *                      enum eAppErrorCodes     eErrorCode          = APP_ERROR_NONE;
     *                      Unsigned16  nu16Count = 0;
     *                      // If Debug Option set is Rx DATA than print receive data
     *                      if((ptDebugData->u32DebugOptions & DEBUG_OPTION_RX) == DEBUG_OPTION_RX) 
     *                      {
     *                          printf("\r\n Rx :");
     *                          for(nu16Count = 0;  nu16Count < ptDebugData->u16RxCount; u16RxCount++)
     *                          {
     *                              printf(" %02X", ptDebugData->au8RxData[nu16Count];
     *                          }
     *                      }
     *
     *                      // If Debug Option set is Tx DATA than print transmission data
     *                      if((ptDebugData->u32DebugOptions & DEBUG_OPTION_TX) == DEBUG_OPTION_TX) 
     *                      {
     *                          printf("\r\n Tx :");
     *                          for(nu16Count = 0;  nu16Count < ptDebugData->u16TxCount; u16TxCount++)
     *                          {
     *                              printf(" %02X", ptDebugData->au8TxData[nu16Count];
     *                          }
     *                      }
     *                          
     *                      return eErrorCode;
     *                  }
     *  \endcode
     */                    
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104DebugMessageCallback(ushort u16ObjectId, ref sIEC104DebugData ptDebugData, ref short ptErrorValue);

    /*! \brief  Parameter Act Command  CallBack 
     *  \ingroup        IEC104 Call-back
     * 
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptOperateID      Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptOperateValue   Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptParameterActParams  Pointer to Parameter Act Params     
     *  \param[out]     ptErrorValue     Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample Parameter Act call-back
     *                  
     *                  enum eAppErrorCodes cbParameterAct(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue,struct sIEC104ParameterActParameters *ptParameterActParams, tErrorValue *ptErrorValue)     
     *                  {
     *                      enum eAppErrorCodes     eErrorCode          = APP_ERROR_NONE;
     *                      Unsigned8               u8CommandVal        = 0;
     *
     *                      // print & process parameter value for particular typeid & ioa
     *                          
     *                      return eErrorCode;
     *                  }
     *  \endcode
     */
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104ParameterActCallback(ushort u16ObjectId, ref sIEC104DataAttributeID ptOperateID, ref sIEC104DataAttributeData ptOperateValue, ref sIEC104ParameterActParameters ptParameterActParams, ref short ptErrorValue);

    /*! \brief          IEC104 Client connection status call-back
    *  \ingroup        IEC104Call-back
    * 
    *  \param[in]      u16ObjectId     IEC104 object identifier
    *  \param[out]      ptDataID      Pointer to IEC 104 Data Attribute ID
    *  \param[out]      peSat   Pointer to enum eStatus 
    *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
    
    *
    *  \return         APP_ERROR_NONE on success
    *  \return         otherwise error code
    *
    *  \code
    *                  //Sample client status call-back
    *                  
    *                       enum eTgtErrorCodes cbClientstatus(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptDataID, enum eStatus *peSat, tErrorValue *ptErrorValue)
    *                       {
    *                            enum eTgtErrorCodes eErrorCode = EC_NONE;
    *                       
    *                            do
    *                            {
    *                                printf("\r\n server ip address %s ", ptDataID->ai8IPAddress);
    *                                printf("\r\n server port number %u", ptDataID->u16PortNumber);
    *                                printf("\r\n server ca %u", ptDataID->u16CommonAddress);
    *                       
    *                                if(*peSat  ==  NOT_CONNECTED)
    *                                {
    *                                    printf("\r\n not connected");
    *                               }
    *                               else
    *                               {
    *                                printf("\r\n connected");
    *                                }    
    *                     
    *                          }while(FALSE);    
    *                       
    *                            return eErrorCode;
    *                      }
    *  \endcode
    */
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104ClientStatusCallback(ushort u16ObjectId, ref sIEC104DataAttributeID ptDataID, ref iec60870common.eStatus peSat, ref short ptErrorValue); 

    /*! \brief          IEC104 server connection status call-back
    *  \ingroup        IEC104 Call-back
    *   
    *  \param[in]      u16ObjectId     IEC104 object identifier
    *  \param[out]      ptServerConnID     Pointer to struct sIEC104ServerConnectionID
    *  \param[out]      peSat   Pointer to enum eStatus 
    *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
    *
    *  \return         APP_ERROR_NONE on success
    *  \return         otherwise error code
    *
    *  \code
    *                  //Sample server status call-back
    *                  
    *                      enum eTgtErrorCodes cbServerStatus(Unsigned16 u16ObjectId, struct sIEC104ServerConnectionID *ptServerConnID, enum eStatus *peSat, tErrorValue *ptErrorValue)
    *                      {
    *                          enum eTgtErrorCodes eErrorCode = EC_NONE;
    *                     
    *
    *                          printf("\r\n cbServerstatus() called");
    *                          if(*peSat == CONNECTED)
    *                          {
    *                          printf("\r\n status - connected");
    *                          }
    *                          else
    *                          {
    *                          printf("\r\n status - disconnected");
    *                          }
    *
    *                          printf("\r\n source ip %s port %u ", ptServerConnID->ai8SourceIPAddress, ptServerConnID->u16SourcePortNumber);
    *                          printf("\r\n remote ip %s port %u ", ptServerConnID->ai8RemoteIPAddress, ptServerConnID->u16RemotePortNumber);
    *
    *                          return eErrorCode;
    *                      }
    *  \endcode
    */
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104ServerStatusCallback(ushort u16ObjectId, ref sIEC104ServerConnectionID ptServerConnID, ref iec60870common.eStatus peSat, ref short ptErrorValue); 

	/*! \brief          Function called when server received a new file from client via control direction file transfer
     *  \ingroup        IEC104 Call-back
     *
	 *  \param[out]		 eDirection - file transfer direction with enum eFileTransferDirection 
     *  \param[out]      u16ObjectId     IEC104 object identifier
     *  \param[out]      ptServerConnID     Pointer to struct sIEC104ServerConnectionID
	 *  \param[out]		 u16CommonAddress - station address or common address
	 *  \param[out]		 u32IOA - uint Information Object address
     *  \param[out]      u16FileName - Unsigned16 
     *  \param[out]      u32LengthOfFile - Unsigned32 
	 *  \param[out]      peFileTransferSat - enum eFileTransferStatus 
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample IEC104 Server File Transfer Callback
     *
     *Integer16 cbServerFileTransferCallback(eFileTransferDirection eDirection, ushort u16ObjectId, ref sIEC104ServerConnectionID ptServerConnID, ushort u16CommonAddress, uint u32IOA, ushort u16FileName, uint u32LengthOfFile, ref eFileTransferStatus peFileTransferSat, ref short ptErrorValue)
     *{
     *	 Integer16 i16ErrorCode = EC_NONE;
	 *
	 *	 printf("\n\r\n cbServerFileTransferCallback() called");
	 * 	 printf("\r\n Server ID : %u", u16ObjectId);
	 *   printf("\r\n Source IP Address %s Port %u ", ptServerConnID->ai8SourceIPAddress, ptServerConnID->u16SourcePortNumber);
	 *   printf("\r\n Remote IP Address %s Port %u ", ptServerConnID->ai8RemoteIPAddress, ptServerConnID->u16RemotePortNumber);
	 *
	 *   printf("\r\n File Name %u Length Of File %u ", u16FileName, u32LengthOfFile);
	 *
	 *   return i16ErrorCode;
	 *}

     *  \endcode
     */

	[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate short IEC104ServerFileTransferCallback(iec104types.eFileTransferDirection eDirection, ushort u16ObjectId, ref sIEC104ServerConnectionID ptServerConnID, ushort u16CommonAddress, uint u32IOA, ushort u16FileName, uint u32LengthOfFile, ref eFileTransferStatus peFileTransferSat, ref short ptErrorValue);

	
    /*! \brief      Create Server/client parameters structure  */
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,
        CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct sIEC104Parameters
    {
        public tgtcommon.eApplicationFlag                         eAppFlag;                           /*!< Flag set to indicate the type of application */
        public uint                                     u32Options;                         /*!< Options flag, used to set client/server */
        public ushort                                   u16ObjectId;                        /*!<  user idenfication will be retured in the callback for iec104object identification*/
        public IEC104ReadCallback                      ptReadCallback;                     /*!< Read callback function. If equal to NULL then callback is not used. */
        public IEC104WriteCallback                     ptWriteCallback;                    /*!< Write callback function. If equal to NULL then callback is not used. */
        public IEC104UpdateCallback                    ptUpdateCallback;                   /*!< Update callback function. If equal to NULL then callback is not used. */
        public IEC104ControlSelectCallback             ptSelectCallback;                   /*!< Function called when a Select Command is executed.  If equal to NULL then callback is not used*/
        public IEC104ControlOperateCallback            ptOperateCallback;                  /*!< Function called when a Operate command is executed.  If equal to NULL then callback is not used */
        public IEC104ControlCancelCallback             ptCancelCallback;                   /*!< Function called when a Cancel command is executed.  If equal to NULL then callback is not used */
        public IEC104ControlFreezeCallback             ptFreezeCallback;                   /*!< Function called when a Freeze Command is executed.  If equal to NULL then callback is not used*/
        public IEC104ControlPulseEndActTermCallback    ptPulseEndActTermCallback;          /*!< Function called when a pulse  command time expires.  If equal to NULL then callback is not used */                      
        public IEC104DebugMessageCallback              ptDebugCallback;                    /*!< Function called when debug options are set. If equal to NULL then callback is not used */
        public IEC104ParameterActCallback              ptParameterActCallback;              /*!< Function called when a Parameter act command is executed.  If equal to NULL then callback is not used */
        public IEC104DirectoryCallback                 ptDirectoryCallback;                /*!< Directory callback function. List The Files in the Directory. */
        public IEC104ClientStatusCallback              ptClientStatusCallback;              /*!< Function called when client connection status changed */
        public IEC104ServerStatusCallback              ptServerStatusCallback;              /*!< Function called when server connection status changed */
		public IEC104ServerFileTransferCallback		   ptServerFileTransferCallback; 		/*!< Function called when server received a new file from client via control direction file transfer */

	}


}
