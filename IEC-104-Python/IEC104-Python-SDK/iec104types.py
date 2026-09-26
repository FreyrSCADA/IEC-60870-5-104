import ctypes
from enum import Enum
from structureWithEnums import *
from iec60870common import *
from tgtcommon import *
from tgtdefines import *
from tgttypes import *



# brief  Max Size of Rx Message sent to callback  
IEC104_MAX_RX_MESSAGE = 255
# brief  Max Size of Tx Message sent to callback  
IEC104_MAX_TX_MESSAGE = 255
    
    
    
# Client connect state  
class eConnectState(IntEnum):     
        DATA_MODE   =   0   # Client send the startdt & data communication & command transmission follows 
        TEST_MODE   =   1  # Client send the test frame only to monitor the connection 
     


    
# File transfer Status value used in filetransfer callback
class eFileTransferStatus(IntEnum):    
        FILETRANSFER_NOTINITIATED = 0		#  file transfer not initiated   
        FILETRANSFER_STARTED = 1		#  file transfer procedure started	
        FILETRANSFER_INTERCEPTED = 2		#  file transfer operation interepted	
        FILETRANSFER_COMPLEATED = 3		#  file transfer compleated	
    

# File transfer Status value used in filetransfer callback
class eFileTransferDirection(IntEnum):    
        MONITOR_DIRECTION = 0 # in this mode server send files to client 
        CONTROL_DIRECTION = 1 # in this mode server receive files from client 

 
 
# List of error code returned by API functions 
class eIEC104AppErrorCodes(IntEnum):           
            APP_ERROR_ERRORVALUE_IS_NULL                = -4501       # IEC104 Error value is  null
            APP_ERROR_CREATE_FAILED                     = -4502       # IEC104 api create function failed 
            APP_ERROR_FREE_FAILED                       = -4503       # IEC104 api free function failed 
            APP_ERROR_INITIALIZE                        = -4504       # IEC104 server/client initialize function failed 
            APP_ERROR_LOADCONFIG_FAILED                 = -4505       # IEC104 apiLoad configuration function failed 
            APP_ERROR_CHECKALLOCLOGICNODE               = -4506       # IEC104 Load- check alloc logical node function failed 
            APP_ERROR_START_FAILED                      = -4507       # IEC104 api Start function failed 
            APP_ERROR_STOP_FAILED                       = -4508       # IEC104 api Stop function failed 
            APP_ERROR_SETDEBUGOPTIONS_FAILED            = -4509       # IEC104 set debug option failed 
            APP_ERROR_PHYSICALINITIALIZE_FAILED         = -4510       # IEC104 Physical Layer initialization failed  
            APP_ERROR_DATALINKINITIALIZE_FAILED         = -4511       # IEC104 datalink Layer initialization failed  
            APP_ERROR_INVALID_FRAMESTART                = -4512       # IEC104 receive Invalid start frame 68
            APP_ERROR_INVALID_SFRAMEFORMAT              = -4513       # IEC104 receive Invalid s format frame
            APP_ERROR_T3T1_FAILED                       = -4514       # IEC104 T3- T1 time failed
            APP_ERROR_UPDATE_FAILED                     = -4515       # IEC104 api update function  failed
            APP_ERROR_TIMESTRUCT_INVALID                = -4516       # IEC104 time structure invalid
            APP_ERROR_FRAME_ENCODE_FAILED               = -4517       # IEC104 encode operation invalid
            APP_ERROR_INVALID_FRAME                     = -4518       # IEC104 receive frame  invalid
            APP_ERROR_WRITE_FAILED                      = -4519       # IEC104 api write function  invalid
            APP_ERROR_SELECT_FAILED                     = -4520       # IEC104 api select function  invalid
            APP_ERROR_OPERATE_FAILED                    = -4521       # IEC104 api operate function  invalid
            APP_ERROR_CANCEL_FAILED                     = -4522       # IEC104 api cancel function  invalid
            APP_ERROR_READ_FAILED                       = -4523       # IEC104 api read function  invalid
            APP_ERROR_DECODE_FAILED                     = -4524       # IEC104 Decode failed
            APP_ERROR_GETDATATYPEANDSIZE_FAILED         = -4525       # IEC104 api get datatype and datasize  function  invalid
            APP_ERROR_CLIENTSTATUS_FAILED               = -4526       # IEC104 api get client status failed
            APP_ERROR_FILE_TRANSFER_FAILED              = -4527       # IEC104 File Transfer Failed
            APP_ERROR_LIST_DIRECTORY_FAILED             = -4528       # IEC104 List Directory Failed
            APP_ERROR_GET_OBJECTSTATUS_FAILED           = -4529       # IEC104 api get object status function failed
            APP_ERROR_CLIENT_CHANGESTATE_FAILED         = -4530       # IEC104 api client change the status function failed
            APP_ERROR_PARAMETERACT_FAILED               = -4531       # IEC104 api Parameter act function  invalid
    



# List of error value returned by API functions 
class eIEC104AppErrorValues(IntEnum):    
        APP_ERRORVALUE_ERRORCODE_IS_NULL                =   -4501          # APP Error code is Null 
        APP_ERRORVALUE_INVALID_INPUTPARAMETERS          =   -4502          # Supplied Parameters are invalid 
        APP_ERRORVALUE_INVALID_APPFLAG                  =   -4503          # Invalid Application Flag  Client not supported by the API
        APP_ERRORVALUE_UPDATECALLBACK_CLIENTONLY        =   -4504          # Update Callback used only for client
        APP_ERRORVALUE_NO_MEMORY                        =   -4505          # Allocation of memory has failed 
        APP_ERRORVALUE_INVALID_IEC104OBJECT             =   -4506          # Supplied IEC104Object is invalid 
        APP_ERRORVALUE_FREE_CALLED_BEFORE_STOP          =   -4507          # APP state is running free function called before stop function
        APP_ERRORVALUE_INVALID_STATE                    =   -4508          # IEC104OBJECT invalid state  
        APP_ERRORVALUE_INVALID_DEBUG_OPTION             =   -4509          # invalid debug option  
        APP_ERRORVALUE_ERRORVALUE_IS_NULL               =  -4510          # Error value is null 
        APP_ERRORVALUE_INVALID_IEC104PARAMETERS         =  -4511          # Supplied parameter are invalid 
        APP_ERRORVALUE_SELECTCALLBACK_SERVERONLY        =  -4512          # Select callback for server only 
        APP_ERRORVALUE_OPERATECALLBACK_SERVERONLY       =  -4513          # Operate callback for server only 
        APP_ERRORVALUE_CANCELCALLBACK_SERVERONLY        =  -4514          # Cancel callback for server only 
        APP_ERRORVALUE_READCALLBACK_SERVERONLY          =  -4515          # Read callback for server only 
        APP_ERRORVALUE_ACTTERMCALLBACK_SERVERONLY       =  -4516          # ACTTERM callback for server only 
        APP_ERRORVALUE_INVALID_OBJECTNUMBER             =  -4517          # Invalid total no of object 
        APP_ERRORVALUE_INVALID_COMMONADDRESS            =  -4518          # Invalid common address Slave cant use the common address -> global address 0 65535 the total number of ca we can use 5 items
        APP_ERRORVALUE_INVALID_K_VALUE                  =  -4519          # Invalid k value (range 1-65534) 
        APP_ERRORVALUE_INVALID_W_VALUE                  =  -4520          # Invalid w value (range 1-65534)
        APP_ERRORVALUE_INVALID_TIMEOUT                  =  -4521          # Invalid time out t (range 1-65534) 
        APP_ERRORVALUE_INVALID_BUFFERSIZE               =  -4522          # Invalid Buffer Size (100 -65535)
        APP_ERRORVALUE_INVALID_IEC104OBJECTPOINTER      =  -4523          # Invalid Object pointer 
        APP_ERRORVALUE_INVALID_MAXAPDU_SIZE             =  -4524          # Invalid APDU Size (range 41 - 252)
        APP_ERRORVALUE_INVALID_IOA                      =  -4525          # IOA Value mismatch 
        APP_ERRORVALUE_INVALID_CONTROLMODEL_SBOTIMEOUT  =  -4526          # Invalid control model |u32SBOTimeOut  for typeids from M_SP_NA_1 to M_EP_TF_1 -> STATUS_ONLY & u32SBOTimeOut 0  for type ids C_SC_NA_1 to C_BO_TA_1 should not STATUS_ONLY & u32SBOTimeOut 0
        APP_ERRORVALUE_INVALID_CYCLICTRANSTIME          =  -4527          # measured values cyclic tranmit time 0 or  60 Seconds to max 3600 seconds (1 hour) 
        APP_ERRORVALUE_INVALID_TYPEID                   =  -4528          # Invalid typeid 
        APP_ERRORVALUE_INVALID_PORTNUMBER               =  -4529          # Invalid Port number 
        APP_ERRORVALUE_INVALID_MAXNUMBEROFCONNECTION    =  -4530          # invalid max number of connection 
        APP_ERRORVALUE_INVALID_IPADDRESS                =  -4531          # Invalid ip address 
        APP_ERRORVALUE_INVALID_RECONNECTION             =  -4532          #  VALUE MUST BE 1 TO 10 
        APP_ERRORVALUE_INVALID_NUMBEROFOBJECT           =  -4533          # Invalid total no of object  u16NoofObject 1-10000
        APP_ERRORVALUE_INVALID_IOA_ADDRESS              =  -4534          # Invalid IOA 1-16777215
        APP_ERRORVALUE_INVALID_RANGE                    =  -4535          # Invalid IOA Range 1-1000
        APP_ERRORVALUE_104RECEIVEFRAMEFAILED            =  -4536          # IEC104 Receive failed        
        APP_ERRORVALUE_INVALID_UFRAMEFORMAT             =  -4537          # Invalid frame U format
        APP_ERRORVALUE_T3T1_TIMEOUT_FAILED              =  -4538          # t3 - t1 timeout failed           
        APP_ERRORVALUE_KVALUE_REACHED_T1_TIMEOUT_FAILED    =   -4539          # k value reached and t1 timeout 
        APP_ERRORVALUE_LASTIFRAME_T1_TIMEOUT_FAILED        =   -4540          # t1 timeout 
        APP_ERRORVALUE_INVALIDUPDATE_COUNT             =   -4541          # Invalid update count
        APP_ERRORVALUE_INVALID_DATAPOINTER             =   -4542          # Invalid data pointer
        APP_ERRORVALUE_INVALID_DATATYPE                =   -4543          # Invalid data type 
        APP_ERRORVALUE_INVALID_DATASIZE                =   -4544          # Invalid data size 
        APP_ERRORVALUE_UPDATEOBJECT_NOTFOUND           =   -4545          # Invalid update object not found 
        APP_ERRORVALUE_INVALID_DATETIME_STRUCT         =   -4546          # Invalid data & time structure 
        APP_ERRORVALUE_INVALID_PULSETIME               =   -4547          # Invalid pulse time flag 
        APP_ERRORVALUE_INVALID_COT                     =   -4548          # For commands the COT must be NOTUSED 
        APP_ERRORVALUE_INVALID_CA                      =   -4549          # For commands the COT must be NOTUSED 
        APP_ERRORVALUE_CLIENT_NOTCONNECTED             =   -4550          # For commands The client is not connected to server 
        APP_ERRORVALUE_INVALID_OPERATION_FLAG          =   -4551          # invalid operation flag in cancel function 
        APP_ERRORVALUE_INVALID_QUALIFIER               =   -4552          # invalid qualifier  KPA
        APP_ERRORVALUE_COMMAND_TIMEOUT                 =   -4553          # command timeout no response from server 
        APP_ERRORVALUE_INVALID_FRAMEFORMAT             =   -4554          # Invalid frame format
        APP_ERRORVALUE_INVALID_IFRAMEFORMAT            =   -4555          # invalid information frame format 
        APP_ERRORVALUE_INVALID_SFRAMENUMBER            =   -4556          # invalid s frame number 
        APP_ERRORVALUE_INVALID_KPA                     =   -4557          # invalid Kind of Parameter value 
        APP_ERRORVALUE_FILETRANSFER_TIMEOUT            =   -4558          # file transfer timeout no response from server 
        APP_ERRORVALUE_FILE_NOT_READY                  =   -4559          # file not ready 
        APP_ERRORVALUE_SECTION_NOT_READY               =   -4560          # Section not ready   
        APP_ERRORVALUE_FILE_OPEN_FAILED                =   -4561          # File Open Failed  
        APP_ERRORVALUE_FILE_CLOSE_FAILED               =   -4562          # File Close Failed 
        APP_ERRORVALUE_FILE_WRITE_FAILED               =   -4563          # File Write Failed 
        APP_ERRORVALUE_FILETRANSFER_INTERUPTTED        =   -4564          # File Transfer Interrupted 
        APP_ERRORVALUE_SECTIONTRANSFER_INTERUPTTED     =   -4565          # Section Transfer Interrupted 
        APP_ERRORVALUE_FILE_CHECKSUM_FAILED            =   -4566          # File Checksum Failed
        APP_ERRORVALUE_SECTION_CHECKSUM_FAILED         =   -4567          # Section Checksum Failed
        APP_ERRORVALUE_FILE_NAME_UNEXPECTED            =   -4568          # File Name Unexpected
        APP_ERRORVALUE_SECTION_NAME_UNEXPECTED         =   -4569          # Section Name Unexpected
        APP_ERRORVALUE_INVALID_QRP                     =   -4570          # INVALID Qualifier of Reset Process command 
        APP_ERRORVALUE_DIRECTORYCALLBACK_CLIENTONLY    =   -4571          # Directory Callback used only for client
        APP_ERRORVALUE_INVALID_BACKGROUNDSCANTIME      =   -4572          # BACKGROUND scan time 0 or  60 Seconds to max 3600 seconds (1 hour) 
        APP_ERRORVALUE_INVALID_FILETRANSFER_PARAMETER  =   -4573          # Server loadconfig file transfer enabled but the dir path and number of files not valid
        APP_ERRORVALUE_INVALID_CONNECTION_MODE         =   -4574          # Client loadconfig connection state either DATA_MODE / TEST_MODE    
        APP_ERRORVALUE_FILETRANSFER_DISABLED           =   -4575          # Client loadconfig setings file tranfer disabled   
        APP_ERRORVALUE_INVALID_INTIAL_DATABASE_QUALITYFLAG     = -4576        # Server loadconfig intial databse quality flag invalid
        APP_ERRORVALUE_INVALID_STATUSCALLBACK              = -4577        # Invalid status callback 
        APP_ERRORVALUE_DEMO_EXPIRED                        = -4578        # Demo software expired contact support@freyrscada.com
        APP_ERRORVALUE_SERVER_DISABLED                     = -4579        # Server functionality disabled in the api please contact support@freyrscada.com 
        APP_ERRORVALUE_CLIENT_DISABLED                     = -4580        # Client functionality disabled in the api please contact support@freyrscada.com
        APP_ERRORVALUE_DEMO_INVALID_POINTCOUNT             = -4581       # Demo software - Total Number of Points exceeded maximum 100 points
        APP_ERRORVALUE_INVALID_COT_SIZE                    = -4582          # Invalid cause of transmission (COT)size
        APP_ERRORVALUE_F_SC_NA_1_SCQ_MEMORY   				= -4583     # Server received F_SC_NA_1 SCQ requested memory space not available
        APP_ERRORVALUE_F_SC_NA_1_SCQ_CHECKSUM   			= -4584     # Server received F_SC_NA_1 SCQ checksum failed
        APP_ERRORVALUE_F_SC_NA_1_SCQ_COMMUNICATION   		= -4585     # Server received F_SC_NA_1 SCQ unexpected communication service
        APP_ERRORVALUE_F_SC_NA_1_SCQ_NAMEOFFILE   			= -4586     # Server received F_SC_NA_1 SCQ unexpected name of file
        APP_ERRORVALUE_F_SC_NA_1_SCQ_NAMEOFSECTION   		= -4587     # Server received F_SC_NA_1 SCQ unexpected name of Section
        APP_ERRORVALUE_F_SC_NA_1_SCQ_UNKNOWN   				= -4588     # Server received F_SC_NA_1 SCQ Unknown		
        APP_ERRORVALUE_F_AF_NA_1_SCQ_MEMORY   				= -4589     # Server received F_AF_NA_1 SCQ requested memory space not available
        APP_ERRORVALUE_F_AF_NA_1_SCQ_CHECKSUM   			= -4590     # Server received F_AF_NA_1 SCQ checksum failed
        APP_ERRORVALUE_F_AF_NA_1_SCQ_COMMUNICATION   		= -4591     # Server received F_AF_NA_1 SCQ unexpected communication service
        APP_ERRORVALUE_F_AF_NA_1_SCQ_NAMEOFFILE   			= -4592     # Server received F_AF_NA_1 SCQ unexpected name of file
        APP_ERRORVALUE_F_AF_NA_1_SCQ_NAMEOFSECTION   		= -4593     # Server received F_AF_NA_1 SCQ unexpected name of Section
        APP_ERRORVALUE_F_AF_NA_1_SCQ_UNKNOWN               = -4594     # Server received F_AF_NA_1 SCQ Unknown 

    
     
 
# Update flags 
class eUpdateFlags(IntEnum):    
        UPDATE_DATA                                   = 0x01       # Update the data value
        UPDATE_QUALITY                                = 0x02       # Update the quality 
        UPDATE_TIME                                   = 0x04       # Update the timestamp
        UPDATE_ALL                                    = 0x07       # Update Data Quality and Time Stamp 
        
    
        
    
#  IEC104 Debug Parameters 
class sIEC104DebugParameters(ctypes.Structure):
    _fields_ = [
        ("u32DebugOptions",ctypes.c_uint32)                # Debug Options 
    ]

#  IEC104 Update Option Parameters  
class sIEC104UpdateOptionParameters(ctypes.Structure):
    _fields_ = [
        ("u16Count",ctypes.c_ushort)            # Number of IEC 104 Data attribute ID and Data attribute data to be updated simultaneously 
    ]


#  IEC104 Object Structure 
class sIEC104Object(StructureWithEnums):
    _fields_ = [            
        ("eTypeID",ctypes.c_int),                    # Type Identifcation 
        ("eIntroCOT",ctypes.c_int),                 # Interrogation group 
        ("eControlModel",ctypes.c_int),              # Control Model specified in eControlModelFlags 
        ("eKPA",ctypes.c_int),                         # For typeids,P_ME_NA_1, P_ME_NB_1, P_ME_NC_1 - Kind of parameter , refer enum eKPA for other typeids - PARAMETER_NONE
        ("u32IOA",ctypes.c_uint32),                     # Informatiion Object Address 
        ("u16Range",ctypes.c_ushort),                   # Range 
        ("u32SBOTimeOut",ctypes.c_uint32),              # Select Before Operate Timeout in milliseconds 
        ("u16CommonAddress",ctypes.c_ushort),            # Common Address , 0 - not used, 1-65534 station address, 65535 = global address (only master can use this)
        ("u32CyclicTransTime",ctypes.c_uint32),         # Periodic or Cyclic Transmissin time in seconds. If 0 do not transmit Periodically (only applicable to measured values, and the reporting typeids M_ME_NA_1, M_ME_NB_1, M_ME_NC_1, M_ME_ND_1) MINIMUM 60 Seconds, max 3600 seconds (1 hour)
        ("u32BackgroundScanPeriod",ctypes.c_uint32),    # in seconds, if 0 the background scan will not be performed, MINIMUM 60 Seconds, max 3600 seconds (1 hour), all monitoring iinformation except Integrated totals will be transmitteed . the reporting typeid without timestamp
        ("ai8Name", ctypes.c_char * APP_OBJNAMESIZE) # Name 
                
    ]
map = {
        "eTypeID": eIEC870TypeID,"eIntroCOT": eIEC870COTCause,"eControlModel":eControlModelConfig,"eKPA":eKindofParameter
    } 
    

#	IEC104 Server Remote IPAddress list
class sIEC104ServerRemoteIPAddressList(ctypes.Structure):
    _fields_ = [
       
            ("ai8RemoteIPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE)
    ]
    

    
#  IEC104 Server Connection Structure 
class sServerConnectionParameters(ctypes.Structure):
    _fields_ = [       

        ("i16k",ctypes.c_short),                                    # Maximum difference receive sequence number to send state variable (k: 1 to 32767) default - 12
        ("i16w",ctypes.c_short),                                    # Latest acknowledge after receiving w I format APDUs (w: 1 to 32767 APDUs, accuracy 1 APDU (Recommendation: w should not exceed two-thirds of k) default :8)
        ("u8t0", ctypes.c_ubyte),                                    # Time out of connection establishment in seconds (1-255s)
        ("u8t1", ctypes.c_ubyte),                                    # Time out of send or test APDUs in seconds (1-255s)
        ("u8t2", ctypes.c_ubyte),                                    # Time out for acknowledges in case of no data message t2 M t1 in seconds (1-172800 sec)
        ("u16t3",ctypes.c_ushort),                                   # Time out for sending test frames in case of long idle state in seconds ( 1 to 48h( 172800sec)) 
        ("u16EventBufferSize",ctypes.c_ushort),                      # SOE - Event Buffer Size (50 -65,535)
        ("u32ClockSyncPeriod",ctypes.c_uint32),                      # Clock Synchronisation period in milliseconds. If 0 than Clock Synchronisation command is not expected from Master 
        ("bGenerateACTTERMrespond",ctypes.c_bool),                 # if Yes , Generate ACTTERM  responses for operate commands
        ("u16PortNumber",ctypes.c_ushort),                           #  Port Number , default 2404
        ("bEnableRedundancy",ctypes.c_bool),                       #  enable redundancy for the connection  
        ("u16RedundPortNumber",ctypes.c_ushort),                          # Redundancy Port Number 
        ("u16MaxNumberofRemoteConnection",ctypes.c_ushort),               # 1-5; max number of parallel client communication struct sIEC104ServerRemoteIPAddressList
        ("psServerRemoteIPAddressList", ctypes.POINTER(sIEC104ServerRemoteIPAddressList)),           # Pointer to struct sIEC104ServerRemoteIPAddressList 
        ("ai8SourceIPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE),	
        ("ai8RedundSourceIPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE),		
        ("ai8RedundRemoteIPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE)
            
   ]
    
#  Server settings  
class sServerSettings(StructureWithEnums):
    _fields_ = [
        ("bEnablefileftransfer",ctypes.c_bool),                   # enable / disable File Transfer 
        ("u16MaxFilesInDirectory",ctypes.c_ushort),                 # Maximum No of Files in Directory(default 25) 
        ("bEnableDoubleTransmission",ctypes.c_bool),              # enable double transmission  
        ("u8TotalNumberofStations", ctypes.c_ubyte),                # in a single physical device/ server, we can run many stations - nmuber of stations in our server ,according to common address (1-5) 
        ("benabaleUTCtime",ctypes.c_bool),                        # enable utc time/ local time      
        ("bTransmitSpontMeasuredValue",ctypes.c_bool),            # transmit M_ME measured values in spontanous message  
        ("bTranmitInterrogationMeasuredValue",ctypes.c_bool),     # transmit M_ME measured values in General interrogation 
        ("bTransmitBackScanMeasuredValue",ctypes.c_bool),         # transmit M_ME measured values in background message      
        ("u16ShortPulseTime",ctypes.c_ushort),                      # Short Pulse Time in milliseconds 
        ("u16LongPulseTime",ctypes.c_ushort),                       # Long Pulse Time in milliseconds 
        ("bServerInitiateTCPconnection",ctypes.c_bool),			# Server will initiate the TCP/IP connection to Client, if true, the u16MaxNumberofConnection must be one, and  bEnableRedundancy must be FALSE;
        ("u8InitialdatabaseQualityFlag", ctypes.c_ubyte),           # 0-online, 1 BIT- iv, 2 BIT-nt,  MAX VALUE -3   
        ("bUpdateCheckTimestamp",ctypes.c_bool),                  # if it true ,the timestamp change also generate event  during the iec104update 
        ("bSequencebitSet",ctypes.c_bool),						  # If it true, Server builds iec frame with sequence for monitoring information without time stamp 
        ("eCOTsize", ctypes.c_int),                              # Cause of transmission size - Default - COT_TWO_BYTE
        ("u16NoofObject",ctypes.c_ushort),                          # Total number of IEC104 Objects 1-10000        
        ("sDebug",sIEC104DebugParameters),                # Debug options settings on loading the configuarion See struct sIEC104DebugParameters             
        ("psIEC104Objects", ctypes.POINTER(sIEC104Object)),                    # Pointer to strcuture IEC 104 Objects 
        ("sServerConParameters",sServerConnectionParameters),             # pointer to number of parallel client communication 
        ("ai8FileTransferDirPath", ctypes.c_char * MAX_DIRECTORY_PATH),
        ("au16CommonAddress", ctypes.c_ushort * MAX_CA)
    
    ]
    map = {
        "eCOTsize": eCauseofTransmissionSize
        } 
        
        
                  
        
        
    
#  client connection parameters  
class sClientConnectionParameters(ctypes.Structure):
    _fields_ = [
        ("eState", ctypes.c_int),                                        # Connection mode - Data mode, - data transfer enabled, Test Mode - socket connection established only test signals transmited 
        ("u8TotalNumberofStations", ctypes.c_ubyte),                        # total number of station/sector range 1-5 
        ("u8OrginatorAddress", ctypes.c_ubyte),                     # Orginator Address , 0 - not used, 1-255
        ("i16k",ctypes.c_short),                                   # Maximum difference receive sequence number to send state variable (k: 1 to 32767) default - 12
        ("i16w", ctypes.c_short),                                   # Latest acknowledge after receiving w I format APDUs (w: 1 to 32767 APDUs, accuracy 1 APDU (Recommendation: w should not exceed two-thirds of k) default :8)
        ("u8t0", ctypes.c_ubyte),                                   # Time out of connection establishment in seconds (1-255s)
        ("u8t1", ctypes.c_ubyte),                                   # Time out of send or test APDUs in seconds (1-255s)
        ("u8t2", ctypes.c_ubyte),                                   # Time out for acknowledges in case of no data message t2 M t1 in seconds (1-255s)
        ("u16t3", ctypes.c_ushort),                                  # Time out for sending test frames in case of long idle state in seconds ( 1 to 172800 sec) 
        ("u32GeneralInterrogationInterval", ctypes.c_uint32),    # in sec if 0 , gi will not send in particular interval, else in particular seconds GI will send to server
        ("u32Group1InterrogationInterval", ctypes.c_uint32),    # in sec if 0 , group 1 interrogation will not send in particular interval, else in particular seconds group 1 interrogation will send to server
        ("u32Group2InterrogationInterval", ctypes.c_uint32),        # in sec if 0 , group 2 interrogation will not send in particular interval, else in particular seconds group 2 interrogation will send to server
        ("u32Group3InterrogationInterval", ctypes.c_uint32),        # in sec if 0 , group 3 interrogation will not send in particular interval, else in particular seconds group 3 interrogation will send to server
        ("u32Group4InterrogationInterval", ctypes.c_uint32),        # in sec if 0 , group 4 interrogation will not send in particular interval, else in particular seconds group 4 interrogation will send to server
        ("u32Group5InterrogationInterval", ctypes.c_uint32),        # in sec if 0 , group 5 interrogation will not send in particular interval, else in particular seconds group 5 interrogation will send to server
        ("u32Group6InterrogationInterval", ctypes.c_uint32),        # in sec if 0 , group 6 interrogation will not send in particular interval, else in particular seconds group 6 interrogation will send to server
        ("u32Group7InterrogationInterval", ctypes.c_uint32),        # in sec if 0 , group 7 interrogation will not send in particular interval, else in particular seconds group 7 interrogation will send to server
        ("u32Group8InterrogationInterval", ctypes.c_uint32),        # in sec if 0 , group 8 interrogation will not send in particular interval, else in particular seconds group 8 interrogation will send to server
        ("u32Group9InterrogationInterval", ctypes.c_uint32),        # in sec if 0 , group 9 interrogation will not send in particular interval, else in particular seconds group 9 interrogation will send to server
        ("u32Group10InterrogationInterval", ctypes.c_uint32),    # in sec if 0 , group 10 interrogation will not send in particular interval, else in particular seconds group 10 interrogation will send to server
        ("u32Group11InterrogationInterval", ctypes.c_uint32),    # in sec if 0 , group 11 interrogation will not send in particular interval, else in particular seconds group 11 interrogation will send to server
        ("u32Group12InterrogationInterval", ctypes.c_uint32),    # in sec if 0 , group 12 interrogation will not send in particular interval, else in particular seconds group 12 interrogation will send to server
        ("u32Group13InterrogationInterval", ctypes.c_uint32),    # in sec if 0 , group 13 interrogation will not send in particular interval, else in particular seconds group 13 interrogation will send to server
        ("u32Group14InterrogationInterval", ctypes.c_uint32),    # in sec if 0 , group 14 interrogation will not send in particular interval, else in particular seconds group 14 interrogation will send to server
        ("u32Group15InterrogationInterval", ctypes.c_uint32),    # in sec if 0 , group 15 interrogation will not send in particular interval, else in particular seconds group 15 interrogation will send to server
        ("u32Group16InterrogationInterval", ctypes.c_uint32),    # in sec if 0 , group 16 interrogation will not send in particular interval, else in particular seconds group 16 interrogation will send to server
        ("u32CounterInterrogationInterval", ctypes.c_uint32),    # in sec if 0 , ci will not send in particular interval
        ("u32Group1CounterInterrogationInterval", ctypes.c_uint32),    # in sec if 0 , group 1 counter interrogation will not send in particular interval
        ("u32Group2CounterInterrogationInterval", ctypes.c_uint32),    # in sec if 0 , group 2 counter interrogation will not send in particular interval
        ("u32Group3CounterInterrogationInterval", ctypes.c_uint32),    # in sec if 0 , group 3 counter interrogation will not send in particular interval
        ("u32Group4CounterInterrogationInterval", ctypes.c_uint32),    # in sec if 0 , group 4 counter interrogation will not send in particular interval            
        ("u32ClockSyncInterval", ctypes.c_uint32),               # in sec if 0 , clock sync, will not send in particular interval 
        ("u32CommandTimeout", ctypes.c_uint32),                  # in ms, minimum 3000  
        ("u32FileTransferTimeout", ctypes.c_uint32),             # in ms, minimum 3000   
        ("bCommandResponseActtermUsed", ctypes.c_bool),        # server sends ACTTERM in command response 
        ("u16PortNumber", ctypes.c_ushort),                                  # Port Number 
        ("bEnablefileftransfer", ctypes.c_bool),                           # enable / disable File Transfer 
        ("bUpdateCallbackCheckTimestamp", ctypes.c_bool),                  # if it true ,the timestamp change also create the updatecallback    
        ("eCOTsize", ctypes.c_int),                              # Cause of transmission size - Default - COT_TWO_BYTE
        ("u16NoofObject", ctypes.c_ushort),                                  # Total number of IEC104 Objects 0-10000        
        ("psIEC104Objects",ctypes.POINTER(sIEC104Object)),                             # Pointer to strcuture IEC104 Objects
        ("au16CommonAddress", ctypes.c_ushort * MAX_CA),
        ("ai8DestinationIPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE),		
        ("ai8FileTransferDirPath", ctypes.c_char * MAX_DIRECTORY_PATH)
    ]
    
    map = {
        "eState": eConnectState, "eCOTsize": eCauseofTransmissionSize
        } 
        
         
    
#  Client settings       
class sClientSettings(ctypes.Structure):  
    _fields_ = [
        ("bAutoGenIEC104DataObjects", ctypes.c_bool),						# if it true ,the IEC104 Objects created automaticallay, use u16NoofObject = 0, psIEC104Objects = NULL
        ("u16UpdateBuffersize", ctypes.c_ushort),				# if bAutoGenIEC104DataObjects true, update callback buffersize, approx 3 * max count of monitoring points in the server 		
        ("bClientAcceptTCPconnection",ctypes.c_bool),			# Client will accept the TCP/IP connection from server, default - False, if true u16TotalNumberofConnection = 1 , and bAutoGenIEC104DataObjects = true
        ("u16TotalNumberofConnection",ctypes.c_ushort),                             # total number of connection 
        ("benabaleUTCtime",ctypes.c_bool),                            # enable utc time/ local time 
        ("sDebug",sIEC104DebugParameters),                             # Debug options settings on loading the configuarion See struct sIEC104DebugParameters             
        ("psClientConParameters",ctypes.POINTER(sClientConnectionParameters)),          # pointer to client connection parameters 
        ("ai8SourceIPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE)	        
    ]

#  IEC104 Configuration parameters  
class sIEC104ConfigurationParameters(ctypes.Structure):
     _fields_ = [                        
        ("sServerSet", sServerSettings),                         # Server settings  
        ("sClientSet", sClientSettings)                         # Client settings              
    ]
    

#      IEC104 Data Attribute 
class sIEC104DataAttributeID(StructureWithEnums):
      _fields_ = [
        ("u16PortNumber",ctypes.c_ushort),                              # Port Number   
        ("u16CommonAddress",ctypes.c_ushort),                               # Orginator Address /Common Address , 0 - not used, 1-65534 station address, 65535 = global address (only master can use this)
        ("u32IOA",ctypes.c_uint32),                 # Information Object Address         
        ("eTypeID",ctypes.c_int),  	               # Type Identification      
         ("pvUserData",ctypes.c_void_p),   # Application specific User Data 	
        ("ai8IPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE)			
    ]
map = {
        "eTypeID": eIEC870TypeID
        } 

    
#      IEC104 Data Attribute Data 
class sIEC104DataAttributeData(StructureWithEnums):
     _fields_ = [      
        ("sTimeStamp",sTargetTimeStamp), # TimeStamp 
        ("tQuality",ctypes.c_ushort),           # Quality of Data see eIEC104QualityFlags         
        ("eDataType",ctypes.c_int),           # Data Type 
        ("eDataSize",ctypes.c_int),           # Data Size 
        ("eTimeQuality",ctypes.c_int),        # time quality         
        ("u16ElapsedTime",ctypes.c_ushort),      # Elapsed time(M_EP_TA_1, M_EP_TD_1) /Relay duration time(M_EP_TB_1, M_EP_TE_1) /Relay Operating time (M_EP_TC_1, M_EP_TF_1)  In Milliseconds 
        ("bTimeInvalid",ctypes.c_bool),       # time Invalid 
        ("bTRANSIENT",ctypes.c_bool), 		#transient state indication result value step position information
        ("u8Sequence", ctypes.c_ubyte), 		# m_it - Binary counter reading - Sequence notation        
        ("pvData",ctypes.c_void_p)            # Pointer to Data  
    ]    
    
map = {
        "eDataType": eDataTypes, "eDataSize": eDataSizes, "eTimeQuality":eTimeQualityFlags
        } 

#      Parameters provided by read callback   
class sIEC104ReadParameters(ctypes.Structure):
     _fields_ = [
        ("u8OrginatorAddress", ctypes.c_ubyte),     # client orginator address 
        ("u8Dummy", ctypes.c_ubyte)                # Dummy only for future expansion purpose 
    ]

#      Parameters provided by write callback   
class sIEC104WriteParameters(StructureWithEnums):
     _fields_ = [
        ("u8OrginatorAddress", ctypes.c_ubyte),         # client orginator address         
        ("eCause",ctypes.c_int),          # cause of transmission         
        ("u8Dummy", ctypes.c_ubyte)                    # Dummy only for future expansion purpose 
    ]
    
map = {
        "eCause": eIEC870COTCause
        } 

#      Parameters provided by update callback   
class sIEC104UpdateParameters(StructureWithEnums):
     _fields_ = [
        ("eCause",ctypes.c_int),                        # Cause of transmission 
        ("eKPA",ctypes.c_int)                     # For typeids,P_ME_NA_1, P_ME_NB_1, P_ME_NC_1 - Kind of parameter , refer enum eKPA

    ]
    
map = {
        "eCause": eIEC870COTCause,"eKPA":eKindofParameter
        } 

#      Parameters provided by Command callback   
class sIEC104CommandParameters(StructureWithEnums):
     _fields_ = [
        ("u8OrginatorAddress", ctypes.c_ubyte),                 #  client orginator address 
        ("eQOCQU",ctypes.c_int),                     # Qualifier of Commad 
        ("u32PulseDuration",ctypes.c_uint32)           # Pulse Duration Based on the Command Qualifer 
        
    ]
    
map = {
        "eQOCQU": eCommandQOCQU
        } 

#      Parameters provided by parameter act callback   
class sIEC104ParameterActParameters(ctypes.Structure):
     _fields_ = [
         ("u8OrginatorAddress", ctypes.c_ubyte),             #  client orginator address 
         ("u8QPA", ctypes.c_ubyte)                      # Qualifier of parameter activation/kind of parameter , for typeid P_AC_NA_1, please refer 7.2.6.25, for typeid 110,111,112 please refer KPA 7.2.6.24
    ]
    
#  IEC104 Debug Callback Data 
class sIEC104DebugData(ctypes.Structure):
     _fields_ = [
        ("u32DebugOptions",ctypes.c_uint32),                            # Debug Option see eDebugOptionsFlag 
        ("iErrorCode",ctypes.c_short),                                # error code if any 
        ("tErrorvalue",ctypes.c_short),                                # error value if any 
        ("u16RxCount",ctypes.c_ushort),                                 # Receive data count 
        ("u16TxCount",ctypes.c_ushort),                                 # Transmitted data count 
        ("u16PortNumber",ctypes.c_ushort),                          #  Port Number
        ("sTimeStamp",sTargetTimeStamp),           # TimeStamp	
        ("au8ErrorMessage", ctypes.c_ubyte * MAX_ERROR_MESSAGE),		
        ("au8WarningMessage", ctypes.c_ubyte * MAX_WARNING_MESSAGE),		
        ("au8RxData", ctypes.c_ubyte * IEC104_MAX_RX_MESSAGE), 
        ("au8TxData", ctypes.c_ubyte * IEC104_MAX_TX_MESSAGE),		
        ("ai8IPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE)	
        
    ]

# IEC104 File Attributes
class sIEC104FileAttributes(ctypes.Structure):
     _fields_ = [
        ("bFileDirectory",ctypes.c_bool),                  # File /Directory File-1,Directory 0                       
        ("u16FileName",ctypes.c_ushort),                     # File Name 
        ("zFileSize", ctypes.c_uint),                     # File size
        ("bLastFileOfDirectory",ctypes.c_bool),            # Last File Of Directory
        ("sLastModifiedTime",sTargetTimeStamp)               # Last Modified Time        
    ]

# IEC104 Directory List
class sIEC104DirectoryList(ctypes.Structure):
     _fields_ = [
        ("u16FileCount",ctypes.c_ushort),                         # File Count read from the Directory 
        ("psFileAttrib",ctypes.POINTER(sIEC104FileAttributes))# Pointer to File Attributes 
    ]

# server connection detail
class sIEC104ServerConnectionID(ctypes.Structure):
      _fields_ = [
        ("u16SourcePortNumber",ctypes.c_ushort),                     # Source port number       
        ("u16RemotePortNumber",ctypes.c_ushort),                      # remote port number	
        ("ai8SourceIPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE),	
        ("ai8RemoteIPAddress", ctypes.c_char * MAX_IPV4_ADDRSIZE)
     ]

# error code more description 
class sIEC104ErrorCode(ctypes.Structure):
     _fields_ = [
        ("iErrorCode", ctypes.c_short),     # errorcode 
        ("shortDes",ctypes.c_char_p),       # error code short description
        ("LongDes",ctypes.c_char_p)        # error code brief description
    ]

    
# error value more description 
class sIEC104ErrorValue(ctypes.Structure):
     _fields_ = [
         ("iErrorValue",ctypes.c_short),        # errorvalue 
         ("shortDes",ctypes.c_char_p),       # string - error value short description
         ("LongDes",ctypes.c_char_p)        # string - error value brief description
    ]
     

    
    
#    /*! \brief  Forward declaration */
class sIEC104AppObject(ctypes.Structure):
        pass

IEC104Object = ctypes.POINTER(sIEC104AppObject)
    
tErrorValue = ctypes.c_short
ptErrorValue= ctypes.POINTER(tErrorValue)
    
iErrorCode = ctypes.c_short
    
u16ObjectId = ctypes.c_ushort
    
'''
    /*! \brief          IEC104 Read call-back
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptReadID        Pointer to IEC 104 Data Attribute ID
     *  \param[out]     ptReadValue     Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptReadParams    Pointer to Read parameters
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample read call-back
     *                  enum eIEC104AppErrorCodes cbRead(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptReadID,struct sIEC104DataAttributeData *ptReadValue, struct sIEC104ReadParameters *ptReadParams, tErrorValue *ptErrorValue )
     *                  {
     *                      enum eIEC104AppErrorCodes     iErrorCode      = IEC104_APP_ERROR_NONE;
     *
     *                      // If the type ID and IOA matches handle and update the value.
     *
     *
     *                      return iErrorCode;
     *                  }
     *  \endcode
     */
'''
    
# typedef Integer16 (*IEC104ReadCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptReadID, struct sIEC104DataAttributeData *ptReadValue, struct sIEC104ReadParameters *ptReadParams, tErrorValue *ptErrorValue );
IEC104ReadCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sIEC104DataAttributeID), ctypes.POINTER(sIEC104DataAttributeData), ctypes.POINTER(sIEC104ReadParameters),ptErrorValue )


'''
    /*! \brief          IEC104 Write call-back
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptWriteID       Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptWriteValue    Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptWriteParams   Pointer to Write parameters
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample write call-back
     *                  enum eIEC104AppErrorCodes cbWrite(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptWriteID,struct sIEC104DataAttributeData *ptWriteValue, struct sIEC104WriteParameters *ptWriteParams, tErrorValue *ptErrorValue )
     *                  {
     *                      enum eIEC104AppErrorCodes     iErrorCode      = IEC104_APP_ERROR_NONE;
     *                      struct sTargetTimeStamp    sReceivedTime   = {0};
     *
     *                      // If the type ID is Clock Synchronisation than set time and date based on target
     *                      if(ptWriteID->eTypeID == C_CS_NA_1)
     *                      {
     *                          memcpy(&sReceivedTime, ptWriteValue->sTimeStamp, sizeof(struct sTargetTimeStamp));
     *                          SetTimeDate(&sReceivedTime);
     *                      }
     *
     *                      return iErrorCode;
     *                  }
     *  \endcode
     */
     '''
#typedef Integer16 (*IEC104WriteCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptWriteID, struct sIEC104DataAttributeData *ptWriteValue,struct sIEC104WriteParameters *ptWriteParams, tErrorValue *ptErrorValue);
IEC104WriteCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sIEC104DataAttributeID), ctypes.POINTER(sIEC104DataAttributeData), ctypes.POINTER(sIEC104WriteParameters), ptErrorValue )

'''
    /*! \brief          IEC104 Update call-back
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptUpdateID       Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptUpdateValue    Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptUpdateParams   Pointer to Update parameters
     *  \param[out]     ptErrorValue     Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample update call-back
     *                  enum eIEC104AppErrorCodes cbUpdate(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptUpdateID, struct sIEC104DataAttributeData *ptUpdateValue, struct sIEC104UpdateParameters *ptUpdateParams, tErrorValue *ptErrorValue )
     *                  {
     *                      enum eIEC104AppErrorCodes     iErrorCode          = IEC104_APP_ERROR_NONE;
     *
     *                      // Check -  received the type ID and IOA than display the value
     *                      // received the update from server
     *
     *                      return iErrorCode;
     *                  }
     *  \endcode
     */
     '''
#typedef Integer16 (*IEC104UpdateCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptUpdateID, struct sIEC104DataAttributeData *ptUpdateValue, struct sIEC104UpdateParameters *ptUpdateParams, tErrorValue *ptErrorValue);
IEC104UpdateCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sIEC104DataAttributeID), ctypes.POINTER(sIEC104DataAttributeData), ctypes.POINTER(sIEC104UpdateParameters), ptErrorValue )

'''
    /*! \brief          IEC104 Directory call-back
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptDirectoryID    Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptDirList        Pointer to IEC 104 sIEC104DirectoryList
     *  \param[out]     ptErrorValue     Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  Integer16 cbDirectory(struct sIEC104DataAttributeID * psDirectoryID, const struct sIEC104DirectoryList *psDirList, tErrorValue * ptErrorValue)
     *                  {
     *                      Integer16 iErrorCode       =  EC_NONE;
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
     *                      return iErrorCode;
     *                  }
     *  \endcode
     */
     '''
#typedef Integer16 (*IEC104DirectoryCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID * ptDirectoryID,  struct sIEC104DirectoryList *ptDirList, tErrorValue *ptErrorValue);
IEC104DirectoryCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sIEC104DataAttributeID),  ctypes.POINTER(sIEC104DirectoryList), ptErrorValue )

'''
    /*! \brief          IEC104 Control Select call-back
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptSelectID       Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptSelectValue    Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptSelectParams   Pointer to select parameters
     *  \param[out]     ptErrorValue     Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample select call-back
     *
     *                  enum eIEC104AppErrorCodes cbSelect(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptSelectID, struct sIEC104DataAttributeData *ptSelectValue, struct sIEC104CommandParameters *ptSelectParams, tErrorValue *ptErrorValue )
     *                  {
     *                      enum eIEC104AppErrorCodes     iErrorCode          = IEC104_APP_ERROR_NONE;
     *
     *                      // Check Server received Select command from client, Perform Select in the hardware according to the typeID and IOA
     *                      // Hardware Control Select Operation;
     *
     *                      return iErrorCode;
     *                  }
     *  \endcode
     */
     '''
#typedef Integer16 (*IEC104ControlSelectCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptSelectID, struct sIEC104DataAttributeData *ptSelectValue,struct sIEC104CommandParameters *ptSelectParams, tErrorValue *ptErrorValue);
IEC104ControlSelectCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sIEC104DataAttributeID), ctypes.POINTER(sIEC104DataAttributeData), ctypes.POINTER(sIEC104CommandParameters), ptErrorValue )

'''
    /*! \brief          IEC104 Control Operate call-back
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptOperateID      Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptOperateValue   Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptOperateParams  Pointer to Operate parameters
     *  \param[out]     ptErrorValue     Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample control operate call-back
     *
     *                  enum eIEC104AppErrorCodes cbOperate(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue, struct sIEC104CommandParameters *ptOperateParams, tErrorValue *ptErrorValue )
     *                  {
     *                      enum eIEC104AppErrorCodes     iErrorCode          = IEC104_APP_ERROR_NONE;
     *
     *                      // Check Server received Operate command from client, Perform Operate in the hardware according to the typeID and IOA
     *                      // Hardware Control Operate Operation;
     *
     *                      return iErrorCode;

     *                  }
     *  \endcode
     */
     '''
#typedef Integer16 (*IEC104ControlOperateCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue,struct sIEC104CommandParameters *ptOperateParams, tErrorValue *ptErrorValue);
IEC104ControlOperateCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sIEC104DataAttributeID), ctypes.POINTER(sIEC104DataAttributeData), ctypes.POINTER(sIEC104CommandParameters), ptErrorValue )
    
'''
    /*! \brief          IEC104 Control Cancel call-back
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      enum eOperationFlag eOperation - select/ operate to cancel
     *  \param[in]      ptCancelID      Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptCancelValue   Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptCancelParams  Pointer to Cancel parameters
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample control cancel call-back
     *
     *                  enum eIEC104AppErrorCodes cbCancel(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptCancelID, struct sIEC104DataAttributeData *ptCancelValue, struct sIEC104CommandParameters *ptCancelParams, tErrorValue *ptErrorValue )
     *                  {
     *                      enum eIEC104AppErrorCodes     iErrorCode          = IEC104_APP_ERROR_NONE;
     *
     *                      // Check Server received cancel command from client, Perform cancel in the hardware according to the typeID and IOA
     *                      // Hardware Control Cancel Operation;
     *
     *                      return iErrorCode;

     *                  }
     *  \endcode
     */
     '''
#typedef Integer16 (*IEC104ControlCancelCallback)(Unsigned16 u16ObjectId, enum eOperationFlag eOperation, struct sIEC104DataAttributeID *ptCancelID, struct sIEC104DataAttributeData *ptCancelValue,struct sIEC104CommandParameters *ptCancelParams, tErrorValue *ptErrorValue);
    
eOperation = ctypes.c_int

IEC104ControlCancelCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, eOperation, ctypes.POINTER(sIEC104DataAttributeID), ctypes.POINTER(sIEC104DataAttributeData), ctypes.POINTER(sIEC104CommandParameters), ptErrorValue )
    
'''
    /*! \brief          IEC104 Control Freeze Callback
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptFreezeID       Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptFreezeValue    Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptFreezeParams   Pointer to Freeze parameters
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample Control Freeze Callback
     *                  enum eIEC104AppErrorCodes cbControlFreezeCallback(Unsigned16 u16ObjectId, enum eCounterFreezeFlags eCounterFreeze, struct sIEC104DataAttributeID *ptFreezeID,  struct sIEC104DataAttributeData *ptFreezeValue, struct sIEC104WriteParameters *ptFreezeCmdParams, tErrorValue *ptErrorValue )
     *                  {
     *                      enum eIEC104AppErrorCodes     iErrorCode      = IEC104_APP_ERROR_NONE;
     *
     *                      // get freeze counter interrogation groub & process it in hardware level
     *
     *                      return iErrorCode;
     *                  }
     *  \endcode
     */
     '''
    #typedef Integer16 (*IEC104ControlFreezeCallback)(Unsigned16 u16ObjectId, enum eCounterFreezeFlags eCounterFreeze, struct sIEC104DataAttributeID *ptFreezeID,  struct sIEC104DataAttributeData *ptFreezeValue, struct sIEC104WriteParameters *ptFreezeCmdParams, tErrorValue *ptErrorValue);

eCounterFreeze =  ctypes.c_int

IEC104ControlFreezeCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, eCounterFreeze, ctypes.POINTER(sIEC104DataAttributeID), ctypes.POINTER(sIEC104DataAttributeData), ctypes.POINTER(sIEC104WriteParameters), ptErrorValue )

'''
    /*! \brief          IEC104 Control Pulse End ActTerm Callback
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptOperateID      Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptOperateValue   Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptOperateParams  Pointer to pulse end parameters
     *  \param[out]     ptErrorValue     Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample control operate call-back
     *
     *                  enum eIEC104AppErrorCodes cbPulseEndActTermCallback(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue, struct sIEC104CommandParameters *ptOperateParams, tErrorValue *ptErrorValue )
     *                  {
     *                      enum eIEC104AppErrorCodes     iErrorCode          = IEC104_APP_ERROR_NONE;
     *
     *                      // After pulse end, send need to send pulse end command termination signal to client
     *                      // Hardware PulseEnd ActTerm Operation;
     *
     *                      return iErrorCode;

     *                  }
     *  \endcode
     */
     '''
#typedef Integer16 (*IEC104ControlPulseEndActTermCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue,struct sIEC104CommandParameters *ptOperateParams, tErrorValue *ptErrorValue);
    
IEC104ControlPulseEndActTermCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sIEC104DataAttributeID), ctypes.POINTER(sIEC104DataAttributeData), ctypes.POINTER(sIEC104CommandParameters), ptErrorValue )

'''
    /*! \brief          IEC104 Debug call-back
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptDebugData     Pointer to debug data
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample debug call-back
     *
     *                  enum eIEC104AppErrorCodes cbDebug(Unsigned16 u16ObjectId, struct sIEC104DebugData *ptDebugData, tErrorValue *ptErrorValue )
     *                  {
     *                      enum eIEC104AppErrorCodes     iErrorCode          = IEC104_APP_ERROR_NONE;
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
     *                      return iErrorCode;
     *                  }
     *  \endcode
     */
     '''
#typedef Integer16 (*IEC104DebugMessageCallback)(Unsigned16 u16ObjectId, struct sIEC104DebugData *ptDebugData, tErrorValue *ptErrorValue);
    
IEC104DebugMessageCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sIEC104DebugData), ptErrorValue )

'''
    /*! \brief  Parameter Act Command  CallBack
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[in]      ptOperateID      Pointer to IEC 104 Data Attribute ID
     *  \param[in]      ptOperateValue   Pointer to IEC 104 Data Attribute Data
     *  \param[in]      ptParameterActParams  Pointer to Parameter Act Params
     *  \param[out]     ptErrorValue     Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample Parameter Act call-back
     *
     *                  enum eIEC104AppErrorCodes cbParameterAct(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue,struct sIEC104ParameterActParameters *ptParameterActParams, tErrorValue *ptErrorValue)
     *                  {
     *                      enum eIEC104AppErrorCodes     iErrorCode          = IEC104_APP_ERROR_NONE;
     *                      Unsigned8               u8CommandVal        = 0;
     *
     *                      // parameter activation & process parameter value for particular typeid & ioa in hardware value like threshold value for analog input
     *
     *                      return iErrorCode;
     *                  }
     *  \endcode
     */
     '''
#typedef Integer16 (*IEC104ParameterActCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue,struct sIEC104ParameterActParameters *ptParameterActParams, tErrorValue *ptErrorValue);
IEC104ParameterActCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sIEC104DataAttributeID), ctypes.POINTER(sIEC104DataAttributeData), ctypes.POINTER(sIEC104ParameterActParameters), ptErrorValue )
    
'''
     /*! \brief          IEC104 Client connection status call-back
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[out]      ptDataID      Pointer to IEC 104 Data Attribute ID
     *  \param[out]      peSat   Pointer to enum eStatus
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)

     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample client status call-back
     *
     *                       Integer16 cbClientstatus(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptDataID, enum eStatus *peSat, tErrorValue *ptErrorValue)
     *                       {
     *                            Integer16 iErrorCode = EC_NONE;
     *
     *                            do
     *                            {
     *                                printf("\r\n server ip address %s ", ptDataID->ai8IPAddress);
     *                                printf("\r\n server port number %u", ptDataID->u16PortNumber);
     *                                printf("\r\n server ca %u", ptDataID->u16CommonAddress);
     *
     *                                if(*peSat  ==  NOT_CONNECTED)
     *                                  {
     *                                    printf("\r\n not connected");
     *                                  }
     *                               else
     *                                  {
     *                                      printf("\r\n connected");
     *                                  }
     *
     *                          }while(FALSE);
     *
     *                            return iErrorCode;
     *                      }
     *  \endcode
     */
     '''
#  typedef Integer16 (*IEC104ClientStatusCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptDataID, enum eStatus *peSat, tErrorValue *ptErrorValue);
    
eSat = ctypes.c_short
peSat= ctypes.POINTER(eSat)
    
IEC104ClientStatusCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sIEC104DataAttributeID),peSat, ptErrorValue )

'''
    /*! \brief          IEC104 server connection status call-back
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[out]      ptServerConnID     Pointer to struct sIEC104ServerConnectionID
     *  \param[out]      peSat   Pointer to enum eStatus
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample server status call-back
     *
     *                      Integer16 cbServerStatus(Unsigned16 u16ObjectId, struct sIEC104ServerConnectionID *ptServerConnID, enum eStatus *peSat, tErrorValue *ptErrorValue)
     *                      {
     *                          Integer16 iErrorCode = EC_NONE;
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
     *                          return iErrorCode;
     *                      }
     *  \endcode
     */
     '''
#typedef Integer16 (*IEC104ServerStatusCallback)(Unsigned16 u16ObjectId, struct sIEC104ServerConnectionID *ptServerConnID, enum eStatus *peSat, tErrorValue *ptErrorValue);

IEC104ServerStatusCallback = ctypes.CFUNCTYPE(iErrorCode, u16ObjectId, ctypes.POINTER(sIEC104ServerConnectionID), peSat, ptErrorValue )

'''
    /*! \brief          Function called when server received a new file from client via control direction file transfer
     *  \ingroup        IEC104 Call-back
     *
     *  \param[in]      u16ObjectId     IEC104 object identifier
     *  \param[out]      ptServerConnID     Pointer to struct sIEC104ServerConnectionID
     *  \param[out]      Unsigned16 u16FileName
     *  \param[out]      Unsigned32 u32LengthOfFile
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         IEC104_APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  //Sample IEC104 Server File Transfer Callback
     *
     *Integer16 cbServerFileTransferCallback(Unsigned16 u16ObjectId, struct sIEC104ServerConnectionID *ptServerConnID, Unsigned16 u16FileName, Unsigned32 u32LengthOfFile, tErrorValue *ptErrorValue)
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
     '''
#typedef Integer16 (*IEC104ServerFileTransferCallback)(enum eFileTransferDirection eDirection, Unsigned16 u16ObjectId, struct sIEC104ServerConnectionID *ptServerConnID, Unsigned16 u16CommonAddress, Unsigned32 u32IOA, Unsigned16 u16FileName, Unsigned32 u32LengthOfFile, enum eFileTransferStatus *peFileTransferSat, tErrorValue *ptErrorValue);
    
eDirection = ctypes.c_short
u16CommonAddress = ctypes.c_ushort
    
u32IOA = ctypes.c_uint32
u16FileName = ctypes.c_ushort
u32LengthOfFile = ctypes.c_uint32
eFileTransferSat = ctypes.c_short
peFileTransferSat = ctypes.POINTER(eFileTransferSat)
    
IEC104ServerFileTransferCallback = ctypes.CFUNCTYPE(iErrorCode, eDirection, u16ObjectId, ctypes.POINTER(sIEC104ServerConnectionID), u16CommonAddress, u32IOA, u16FileName, u32LengthOfFile, peFileTransferSat, ptErrorValue )

# /*! \brief      Create Server/client parameters structure  */
class sIEC104Parameters(StructureWithEnums):
     _fields_ = [
        ("eAppFlag", ctypes.c_int),		                          # Flag set to indicate the type of application 
        ("u32Options", ctypes.c_uint32),                         # Options flag, used to set client/server 
        ("u16ObjectId", ctypes.c_ushort),                      # User idenfication will be retured in the callback for iec104object identification
        ("ptReadCallback", IEC104ReadCallback),                    # Read callback function. If equal to NULL then callback is not used. 
        ("ptWriteCallback", IEC104WriteCallback),                   # Write callback function. If equal to NULL then callback is not used. 
        ("ptUpdateCallback", IEC104UpdateCallback),                  # Update callback function. If equal to NULL then callback is not used. 
        ("ptSelectCallback", IEC104ControlSelectCallback),                  # Function called when a Select Command is executed.  If equal to NULL then callback is not used
        ("ptOperateCallback", IEC104ControlOperateCallback),                 # Function called when a Operate command is executed.  If equal to NULL then callback is not used 
        ("ptCancelCallback", IEC104ControlCancelCallback),                   # Function called when a Cancel command is executed.  If equal to NULL then callback is not used 
        ("ptFreezeCallback",IEC104ControlFreezeCallback),                   # Function called when a Freeze Command is executed.  If equal to NULL then callback is not used
        ("ptPulseEndActTermCallback", IEC104ControlPulseEndActTermCallback),          # Function called when a pulse  command time expires.  If equal to NULL then callback is not used 
        ("ptDebugCallback", IEC104DebugMessageCallback),                   # Function called when debug options are set. If equal to NULL then callback is not used 
        ("ptParameterActCallback", IEC104ParameterActCallback),             # Function called when a Parameter act command is executed.  If equal to NULL then callback is not used 
        ("ptDirectoryCallback", IEC104DirectoryCallback),                # Directory callback function. List The Files in the Directory. 
        ("ptClientStatusCallback", IEC104ClientStatusCallback),             # Function called when client connection status changed 
        ("ptServerStatusCallback", IEC104ServerStatusCallback),             # Function called when server connection status changed 		
        ("ptServerFileTransferCallback", IEC104ServerFileTransferCallback) 		# Function called when server received a new file from client via control direction file transfer 
   
        
    ]

map = {
        "eAppFlag": eApplicationFlag
        } 

                  
