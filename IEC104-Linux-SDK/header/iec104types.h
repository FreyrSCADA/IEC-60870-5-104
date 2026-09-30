/*****************************************************************************/
/*! \file        iec104types.h
 *  \brief       IEC104 API Types Header file
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


/*!
 * \defgroup IEC104 Call-back IEC60870-5-104 API Call-back functions
 */


#ifndef IEC104TYPES_H
    /*! \brief  Define IEC104 Types */
    #define IEC104TYPES_H       1

#include "iec60870common.h"
   


    #ifdef __cplusplus
        extern "C" {
    #endif




    /*! \brief  Max Size of Rx Message sent to callback  */
    #define IEC104_MAX_RX_MESSAGE          255
    /*! \brief  Max Size of Tx Message sent to callback  */
    #define IEC104_MAX_TX_MESSAGE          255




     /*! \brief Client connect state  */
     enum eConnectState
     {
        DATA_MODE   =   0,   /*!< Client send the startdt & data communication & command transmission follows */
        TEST_MODE   =   1,  /*!< Client send the test frame only to monitor the connection */
     };


   
    

	/*! \brief File transfer Status value used in filetransfer callback*/
	enum eFileTransferStatus
	{
		FILETRANSFER_NOTINITIATED 	=	0,		/*!<  file transfer not initiated   */
		FILETRANSFER_STARTED 		= 	1,		/*!<  file transfer procedure started	*/
		FILETRANSFER_INTERCEPTED 	= 	2,		/*!<  file transfer operation interepted	*/
		FILETRANSFER_COMPLEATED 	= 	3,		/*!<  file transfer compleated	*/
	};

		/*! \brief File transfer Status value used in filetransfer callback*/
	enum eFileTransferDirection
	{
		MONITOR_DIRECTION	=	0, /*!< in this mode, server send files to client */
		CONTROL_DIRECTION	=	1, /*!< in this mode, server receive files from client */
			
	};

	


    /*! \brief List of error code returned by API functions */
    enum eIEC104AppErrorCodes
    {
            IEC104_APP_ERROR_ERRORVALUE_IS_NULL                = -4501,       /*!< IEC104 Error value is  null*/
            IEC104_APP_ERROR_CREATE_FAILED                     = -4502,       /*!< IEC104 api create function failed */
            IEC104_APP_ERROR_FREE_FAILED                       = -4503,       /*!< IEC104 api free function failed */
            IEC104_APP_ERROR_INITIALIZE                        = -4504,       /*!< IEC104 server/client initialize function failed */
            IEC104_APP_ERROR_LOADCONFIG_FAILED                 = -4505,       /*!< IEC104 apiLoad configuration function failed */
            IEC104_APP_ERROR_CHECKALLOCLOGICNODE               = -4506,       /*!< IEC104 Load- check alloc logical node function failed */
            IEC104_APP_ERROR_START_FAILED                      = -4507,       /*!< IEC104 api Start function failed */
            IEC104_APP_ERROR_STOP_FAILED                       = -4508,       /*!< IEC104 api Stop function failed */
            IEC104_APP_ERROR_SETDEBUGOPTIONS_FAILED            = -4509,       /*!< IEC104 set debug option failed */
            IEC104_APP_ERROR_PHYSICALINITIALIZE_FAILED         = -4510,       /*!< IEC104 Physical Layer initialization failed  */
            IEC104_APP_ERROR_DATALINKINITIALIZE_FAILED         = -4511,       /*!< IEC104 datalink Layer initialization failed  */
            IEC104_APP_ERROR_INVALID_FRAMESTART                = -4512,       /*!< IEC104 receive Invalid start frame 68*/
            IEC104_APP_ERROR_INVALID_SFRAMEFORMAT              = -4513,       /*!< IEC104 receive Invalid s format frame*/
            IEC104_APP_ERROR_T3T1_FAILED                       = -4514,       /*!< IEC104 T3- T1 time failed*/
            IEC104_APP_ERROR_UPDATE_FAILED                     = -4515,        /*!< IEC104 api update function  failed*/
            IEC104_APP_ERROR_TIMESTRUCT_INVALID                = -4516,        /*!< IEC104 time structure invalid*/
            IEC104_APP_ERROR_FRAME_ENCODE_FAILED               = -4517,        /*!< IEC104 encode operation invalid*/
            IEC104_APP_ERROR_INVALID_FRAME                     = -4518,        /*!< IEC104 receive frame  invalid*/
            IEC104_APP_ERROR_WRITE_FAILED                      = -4519,        /*!< IEC104 api write function  invalid*/
            IEC104_APP_ERROR_SELECT_FAILED                     = -4520,        /*!< IEC104 api select function  invalid*/
            IEC104_APP_ERROR_OPERATE_FAILED                    = -4521,        /*!< IEC104 api operate function  invalid*/
            IEC104_APP_ERROR_CANCEL_FAILED                     = -4522,        /*!< IEC104 api cancel function  invalid*/
            IEC104_APP_ERROR_READ_FAILED                       = -4523,        /*!< IEC104 api read function  invalid*/
            IEC104_APP_ERROR_DECODE_FAILED                     = -4524,        /*!< IEC104 Decode failed*/
            IEC104_APP_ERROR_GETDATATYPEANDSIZE_FAILED         = -4525,        /*!< IEC104 api get datatype and datasize  function  invalid*/
            IEC104_APP_ERROR_CLIENTSTATUS_FAILED               = -4526,        /*!< IEC104 api get client status failed*/
            IEC104_APP_ERROR_FILE_TRANSFER_FAILED              = -4527,        /*!< IEC104 File Transfer Failed*/
            IEC104_APP_ERROR_LIST_DIRECTORY_FAILED             = -4528,        /*!< IEC104 List Directory Failed*/
            IEC104_APP_ERROR_GET_OBJECTSTATUS_FAILED           = -4529,        /*!< IEC104 api get object status function failed*/
            IEC104_APP_ERROR_CLIENT_CHANGESTATE_FAILED         = -4530,        /*!< IEC104 api client change the status function failed*/
            IEC104_APP_ERROR_PARAMETERACT_FAILED               = -4531,        /*!< IEC104 api Parameter act function  invalid*/
    };



    /*! \brief List of error value returned by API functions */
    enum eIEC104AppErrorValues
    {
        IEC104_APP_ERRORVALUE_ERRORCODE_IS_NULL                =   -4501,          /*!< APP Error code is Null */
        IEC104_APP_ERRORVALUE_INVALID_INPUTPARAMETERS          =   -4502,          /*!< Supplied Parameters are invalid */
        IEC104_APP_ERRORVALUE_INVALID_APPFLAG                  =   -4503,          /*!< Invalid Application Flag , Server / Client not supported by the API function*/
        IEC104_APP_ERRORVALUE_UPDATECALLBACK_CLIENTONLY        =   -4504,          /*!< Update Callback used only for client*/
        IEC104_APP_ERRORVALUE_NO_MEMORY                        =   -4505,          /*!< Allocation of memory has failed */
        IEC104_APP_ERRORVALUE_INVALID_IEC104OBJECT             =   -4506,          /*!< Supplied IEC104Object is invalid */
        IEC104_APP_ERRORVALUE_FREE_CALLED_BEFORE_STOP          =   -4507,          /*!< APP state is running free function called before stop function*/
        IEC104_APP_ERRORVALUE_INVALID_STATE                    =   -4508,          /*!< IEC104OBJECT invalid state */
        IEC104_APP_ERRORVALUE_INVALID_DEBUG_OPTION             =   -4509,          /*!< invalid debug option */
        IEC104_APP_ERRORVALUE_ERRORVALUE_IS_NULL               =   -4510,          /*!< Error value is null */
        IEC104_APP_ERRORVALUE_INVALID_IEC104PARAMETERS         =   -4511,          /*!< Supplied parameter are invalid */
        IEC104_APP_ERRORVALUE_SELECTCALLBACK_SERVERONLY        =   -4512,          /*!< Select callback for server only */
        IEC104_APP_ERRORVALUE_OPERATECALLBACK_SERVERONLY       =   -4513,          /*!< Operate callback for server only */
        IEC104_APP_ERRORVALUE_CANCELCALLBACK_SERVERONLY        =   -4514,          /*!< Cancel callback for server only */
        IEC104_APP_ERRORVALUE_READCALLBACK_SERVERONLY          =   -4515,          /*!< Read callback for server only */
        IEC104_APP_ERRORVALUE_ACTTERMCALLBACK_SERVERONLY       =   -4516,          /*!< ACTTERM callback for server only */
        IEC104_APP_ERRORVALUE_INVALID_OBJECTNUMBER             =   -4517,          /*!< Invalid total no of object */
        IEC104_APP_ERRORVALUE_INVALID_COMMONADDRESS            =   -4518,          /*!< Invalid common address Slave cant use the common address -> global address 0, 65535 the total number of ca we can use 5 items*/
        IEC104_APP_ERRORVALUE_INVALID_K_VALUE                  =   -4519,          /*!< Invalid k value (range 1-65534) */
        IEC104_APP_ERRORVALUE_INVALID_W_VALUE                  =   -4520,          /*!< Invalid w value (range 1-65534)*/
        IEC104_APP_ERRORVALUE_INVALID_TIMEOUT                  =   -4521,          /*!< Invalid time out t (range 1-65534) */
        IEC104_APP_ERRORVALUE_INVALID_BUFFERSIZE               =   -4522,          /*!< Invalid Buffer Size (100 -65,535)*/
        IEC104_APP_ERRORVALUE_INVALID_IEC104OBJECTPOINTER      =   -4523,          /*!< Invalid Object pointer */
        IEC104_APP_ERRORVALUE_INVALID_MAXAPDU_SIZE             =   -4524,          /*!< Invalid APDU Size (range 41 - 252)*/
        IEC104_APP_ERRORVALUE_INVALID_IOA                      =   -4525,          /*!< IOA Value mismatch */
        IEC104_APP_ERRORVALUE_INVALID_CONTROLMODEL_SBOTIMEOUT  =   -4526,          /*!< Invalid control model |u32SBOTimeOut , for typeids from M_SP_NA_1 to M_EP_TF_1 -> STATUS_ONLY & u32SBOTimeOut 0 , for type ids C_SC_NA_1 to C_BO_TA_1 should not STATUS_ONLY & u32SBOTimeOut 0*/
        IEC104_APP_ERRORVALUE_INVALID_CYCLICTRANSTIME          =   -4527,          /*!< measured values cyclic transmit time 0, or  60 Seconds to max 3600 seconds (1 hour) */
        IEC104_APP_ERRORVALUE_INVALID_TYPEID                   =   -4528,          /*!< Invalid typeid */
        IEC104_APP_ERRORVALUE_INVALID_PORTNUMBER               =   -4529,          /*!< Invalid Port number */
        IEC104_APP_ERRORVALUE_INVALID_MAXNUMBEROFCONNECTION    =   -4530,          /*!< invalid max number of remote connection */
        IEC104_APP_ERRORVALUE_INVALID_IPADDRESS                =   -4531,          /*!< Invalid ip address */
        IEC104_APP_ERRORVALUE_INVALID_RECONNECTION             =   -4532,          /*!<  VALUE MUST BE 1 TO 10 */
        IEC104_APP_ERRORVALUE_INVALID_NUMBEROFOBJECT           =   -4533,          /*!< Invalid total no of object  u16NoofObject 1-10000*/
        IEC104_APP_ERRORVALUE_INVALID_IOA_ADDRESS              =   -4534,          /*!< Invalid IOA 1-16777215*/
        IEC104_APP_ERRORVALUE_INVALID_RANGE                    =   -4535,          /*!< Invalid IOA Range 1-1000*/
        IEC104_APP_ERRORVALUE_104RECEIVEFRAMEFAILED            =   -4536,          /*!< IEC104 Receive failed*/
        IEC104_APP_ERRORVALUE_INVALID_UFRAMEFORMAT             =   -4537,          /*!< Invalid frame U format*/
        IEC104_APP_ERRORVALUE_T3T1_TIMEOUT_FAILED              =   -4538,          /*!< t3 - t1 timeout failed*/
        IEC104_APP_ERRORVALUE_KVALUE_REACHED_T1_TIMEOUT_FAILED =   -4539,          /*!< k value reached and t1 timeout */
        IEC104_APP_ERRORVALUE_LASTIFRAME_T1_TIMEOUT_FAILED     =   -4540,          /*!< t1 timeout */
        IEC104_APP_ERRORVALUE_INVALIDUPDATE_COUNT              =   -4541,          /*!< Invalid update count*/
        IEC104_APP_ERRORVALUE_INVALID_DATAPOINTER              =   -4542,          /*!< Invalid data pointer*/
        IEC104_APP_ERRORVALUE_INVALID_DATATYPE                 =   -4543,          /*!< Invalid data type */
        IEC104_APP_ERRORVALUE_INVALID_DATASIZE                 =   -4544,          /*!< Invalid data size */
        IEC104_APP_ERRORVALUE_UPDATEOBJECT_NOTFOUND            =   -4545,          /*!< Invalid update object not found */
        IEC104_APP_ERRORVALUE_INVALID_DATETIME_STRUCT          =   -4546,          /*!< Invalid data & time structure */
        IEC104_APP_ERRORVALUE_INVALID_PULSETIME                =   -4547,          /*!< Invalid pulse time flag */
        IEC104_APP_ERRORVALUE_INVALID_COT                      =   -4548,          /*!< For commands the COT must be NOTUSED */
        IEC104_APP_ERRORVALUE_INVALID_CA                       =   -4549,          /*!< For commands the CA must be NOTUSED */
        IEC104_APP_ERRORVALUE_CLIENT_NOTCONNECTED              =   -4550,          /*!< For commands The client is not connected to server */
        IEC104_APP_ERRORVALUE_INVALID_OPERATION_FLAG           =   -4551,          /*!< invalid operation flag in cancel function */
        IEC104_APP_ERRORVALUE_INVALID_QUALIFIER                =   -4552,          /*!< invalid qualifier , KPA*/
        IEC104_APP_ERRORVALUE_COMMAND_TIMEOUT                  =   -4553,          /*!< command timeout, no response from server */
        IEC104_APP_ERRORVALUE_INVALID_FRAMEFORMAT              =   -4554,          /*!< Invalid frame format*/
        IEC104_APP_ERRORVALUE_INVALID_IFRAMEFORMAT             =   -4555,          /*!< invalid information frame format */
        IEC104_APP_ERRORVALUE_INVALID_SFRAMENUMBER             =   -4556,          /*!< invalid s frame number */
        IEC104_APP_ERRORVALUE_INVALID_KPA                      =   -4557,          /*!< invalid Kind of Parameter value */
        IEC104_APP_ERRORVALUE_FILETRANSFER_TIMEOUT             =   -4558,          /*!< file transfer timeout, no response from server */
        IEC104_APP_ERRORVALUE_FILE_NOT_READY                   =   -4559,          /*!< file not ready */
        IEC104_APP_ERRORVALUE_SECTION_NOT_READY                =   -4560,          /*!< Section not ready */
        IEC104_APP_ERRORVALUE_FILE_OPEN_FAILED                 =   -4561,          /*!< File Open Failed */
        IEC104_APP_ERRORVALUE_FILE_CLOSE_FAILED                =   -4562,          /*!< File Close Failed */
        IEC104_APP_ERRORVALUE_FILE_WRITE_FAILED                =   -4563,          /*!< File Write Failed */
        IEC104_APP_ERRORVALUE_FILETRANSFER_INTERUPTTED         =   -4564,          /*!< File Transfer Interrupted */
        IEC104_APP_ERRORVALUE_SECTIONTRANSFER_INTERUPTTED      =   -4565,          /*!< Section Transfer Interrupted */
        IEC104_APP_ERRORVALUE_FILE_CHECKSUM_FAILED             =   -4566,          /*!< File Checksum Failed*/
        IEC104_APP_ERRORVALUE_SECTION_CHECKSUM_FAILED          =   -4567,          /*!< Section Checksum Failed*/
        IEC104_APP_ERRORVALUE_FILE_NAME_UNEXPECTED             =   -4568,          /*!< File Name Unexpected*/
        IEC104_APP_ERRORVALUE_SECTION_NAME_UNEXPECTED          =   -4569,          /*!< Section Name Unexpected*/
        IEC104_APP_ERRORVALUE_INVALID_QRP                      =   -4570,          /*!< INVALID Qualifier of Reset Process command */
        IEC104_APP_ERRORVALUE_DIRECTORYCALLBACK_CLIENTONLY     =   -4571,          /*!< Directory Callback used only for client*/
        IEC104_APP_ERRORVALUE_INVALID_BACKGROUNDSCANTIME       =   -4572,          /*!< BACKGROUND scan time 0, or  60 Seconds to max 3600 seconds (1 hour) */
        IEC104_APP_ERRORVALUE_INVALID_FILETRANSFER_PARAMETER   =   -4573,          /*!< Server loadconfig, file transfer enabled, but the dir path and number of files not valid*/
        IEC104_APP_ERRORVALUE_INVALID_CONNECTION_MODE          =   -4574,          /*!< Client loadconfig, connection state either DATA_MODE / TEST_MODE*/
        IEC104_APP_ERRORVALUE_FILETRANSFER_DISABLED            =   -4575,          /*!< Client loadconfig setings, file tranfer disabled*/
        IEC104_APP_ERRORVALUE_INVALID_INTIAL_DATABASE_QUALITYFLAG  	= -4576,        /*!< Server loadconfig intial databse quality flag invalid*/
        IEC104_APP_ERRORVALUE_INVALID_STATUSCALLBACK               	= -4577,        /*!< Invalid status callback */
        IEC104_APP_ERRORVALUE_TRIAL_EXPIRED                         = -4578,        /*!< Trial software expired contact tech.support@freyrscada.com*/
        IEC104_APP_ERRORVALUE_SERVER_DISABLED                      	= -4579,        /*!< Server functionality disabled in the api, please contact tech.support@freyrscada.com */
        IEC104_APP_ERRORVALUE_CLIENT_DISABLED                      	= -4580,        /*!< Client functionality disabled in the api, please contact tech.support@freyrscada.com*/
        IEC104_APP_ERRORVALUE_TRIAL_INVALID_POINTCOUNT              = -4581,      /*!< Trial software - Total Number of Points exceeded, maximum 100 points*/
        IEC104_APP_ERRORVALUE_INVALID_COT_SIZE                 		= -4582,          /*!< Invalid cause of transmission (COT)size*/
        IEC104_APP_ERRORVALUE_F_SC_NA_1_SCQ_MEMORY   				= -4583,     /*!< Server received F_SC_NA_1 SCQ requested memory space not available*/
		IEC104_APP_ERRORVALUE_F_SC_NA_1_SCQ_CHECKSUM   				= -4584,     /*!< Server received F_SC_NA_1 SCQ checksum failed*/
		IEC104_APP_ERRORVALUE_F_SC_NA_1_SCQ_COMMUNICATION   		= -4585,     /*!< Server received F_SC_NA_1 SCQ unexpected communication service*/
		IEC104_APP_ERRORVALUE_F_SC_NA_1_SCQ_NAMEOFFILE   			= -4586,     /*!< Server received F_SC_NA_1 SCQ unexpected name of file*/
		IEC104_APP_ERRORVALUE_F_SC_NA_1_SCQ_NAMEOFSECTION   		= -4587,     /*!< Server received F_SC_NA_1 SCQ unexpected name of Section*/
		IEC104_APP_ERRORVALUE_F_SC_NA_1_SCQ_UNKNOWN   				= -4588,     /*!< Server received F_SC_NA_1 SCQ Unknown*/		
		IEC104_APP_ERRORVALUE_F_AF_NA_1_SCQ_MEMORY   				= -4589,     /*!< Server received F_AF_NA_1 SCQ requested memory space not available*/
		IEC104_APP_ERRORVALUE_F_AF_NA_1_SCQ_CHECKSUM   				= -4590,     /*!< Server received F_AF_NA_1 SCQ checksum failed*/
		IEC104_APP_ERRORVALUE_F_AF_NA_1_SCQ_COMMUNICATION   		= -4591,     /*!< Server received F_AF_NA_1 SCQ unexpected communication service*/
		IEC104_APP_ERRORVALUE_F_AF_NA_1_SCQ_NAMEOFFILE   			= -4592,     /*!< Server received F_AF_NA_1 SCQ unexpected name of file*/
		IEC104_APP_ERRORVALUE_F_AF_NA_1_SCQ_NAMEOFSECTION   		= -4593,     /*!< Server received F_AF_NA_1 SCQ unexpected name of Section*/
		IEC104_APP_ERRORVALUE_F_AF_NA_1_SCQ_UNKNOWN   				= -4594,     /*!< Server received F_AF_NA_1 SCQ Unknown*/
    };

   
    /*! \brief Update flags */
    enum eUpdateFlags
    {
        UPDATE_DATA                                   = 0x01,       /*!< Update the data value*/
        UPDATE_QUALITY                                = 0x02,       /*!< Update the quality */
        UPDATE_TIME                                   = 0x04,       /*!< Update the timestamp*/
        UPDATE_ALL                                    = 0x07,       /*!< Update Data, Quality and Time Stamp */
    };



    /*! \brief  IEC104 Debug Parameters */
    struct sIEC104DebugParameters
    {
        Unsigned32                      u32DebugOptions;                /*!< Debug Options */
    };


    /*! \brief  IEC104 Update Option Parameters */
    struct sIEC104UpdateOptionParameters
    {
        Unsigned16 u16Count;            /*!< Number of IEC 104 Data attribute ID and Data attribute data to be updated simultaneously */
    };

    /*! \brief  IEC104 Object Structure */
    struct sIEC104Object
    {
        enum eIEC870TypeID                  eTypeID;                    /*!< Type Identifcation */
        enum eIEC870COTCause                eIntroCOT;                  /*!< Interrogation group */
        enum eControlModelConfig            eControlModel;              /*!< Control Model specified in eControlModelFlags */
        enum eKindofParameter               eKPA;                       /*!< For typeids,P_ME_NA_1, P_ME_NB_1, P_ME_NC_1 - Kind of parameter , refer enum eKPA for other typeids - PARAMETER_NONE*/
        Unsigned32                          u32IOA;                     /*!< Informatiion Object Address */
        Unsigned16                          u16Range;                   /*!< Range */
        Unsigned32                          u32SBOTimeOut;              /*!< Select Before Operate Timeout in milliseconds */
        Unsigned16                          u16CommonAddress;           /*!< Common Address , 0 - not used, 1-65534 station address, 65535 = global address (only master can use this)*/
        Unsigned32                          u32CyclicTransTime;         /*!< Periodic or Cyclic Transmissin time in seconds. If 0 do not transmit Periodically (only applicable to measured values, and the reporting typeids M_ME_NA_1, M_ME_NB_1, M_ME_NC_1, M_ME_ND_1) MINIMUM 60 Seconds, max 3600 seconds (1 hour)*/
        Unsigned32                          u32BackgroundScanPeriod;    /*!< in seconds, if 0 the background scan will not be performed, MINIMUM 60 Seconds, max 3600 seconds (1 hour), all monitoring iinformation except Integrated totals will be transmitteed . the reporting typeid without timestamp*/
        Integer8                            ai8Name[APP_OBJNAMESIZE];   /*!< Name */

    };

	/*! \brief	IEC104 Server Remote IPAddress list*/

	struct sIEC104ServerRemoteIPAddressList
		{
			Integer8                ai8RemoteIPAddress[MAX_IPV4_ADDRSIZE];  /*!< Remote IP Address , use 0,0.0.0 to accept all remote station ip*/
        
		};

    /*! \brief  IEC104 Server Connection Structure */
    struct sServerConnectionParameters
    {
        Integer16               i16k;                                   /*!< Maximum difference receive sequence number to send state variable (k: 1 to 32767) default - 12*/
        Integer16               i16w;                                   /*!< Latest acknowledge after receiving w I format APDUs (w: 1 to 32767 APDUs, accuracy 1 APDU (Recommendation: w should not exceed two-thirds of k) default :8)*/
        Unsigned8               u8t0;                                   /*!< Time out of connection establishment in seconds (1-255s)*/
        Unsigned8               u8t1;                                   /*!< Time out of send or test APDUs in seconds (1-255s)*/
        Unsigned8               u8t2;                                   /*!< Time out for acknowledges in case of no data message t2 M t1 in seconds (1-172800 sec)*/
        Unsigned16              u16t3;                                  /*!< Time out for sending test frames in case of long idle state in seconds ( 1 to 48h( 172800sec)) */
        Unsigned16              u16EventBufferSize;                     /*!< SOE - Event Buffer Size (50 -65,535)*/
        Unsigned32              u32ClockSyncPeriod;                     /*!< Clock Synchronisation period in milliseconds. If 0 than Clock Synchronisation command is not expected from Master */
        /*Controlled stations expect the reception of clock synchronization messages within agreed
        time intervals. When the synchronization command does not arrive within this time interval,
        the controlled station sets all time-tagged information objects with a mark that the time tag
        may be inaccurate (invalid).*/
        Boolean                 bGenerateACTTERMrespond;                /*!< if Yes , Generate ACTTERM  responses for operate commands*/
		Unsigned16              u16PortNumber;                          /*!<  Port Number , default 2404*/
        Boolean                 bEnableRedundancy;                      /*!<  enable redundancy for the connection */
        Unsigned16              u16RedundPortNumber;                          /*!< Redundancy Port Number */
		Unsigned16              u16MaxNumberofRemoteConnection;               /*!< 1-5; max number of parallel client communication (struct sIEC104ServerRemoteIPAddressList*)*/
        struct sIEC104ServerRemoteIPAddressList  *psServerRemoteIPAddressList; 
        Integer8                ai8SourceIPAddress[MAX_IPV4_ADDRSIZE];  /*!< Server IP Address , use 0.0.0.0 / network ip address*/
        Integer8                ai8RedundSourceIPAddress[MAX_IPV4_ADDRSIZE];  /*!< Redundancy Server IP Address , use 0.0.0.0 / network ip address */
        Integer8                ai8RedundRemoteIPAddress[MAX_IPV4_ADDRSIZE];  /*!< Redundancy Remote IP Address , use 0,0.0.0 to accept all remote station ip */

    } ;

    /*! \brief  Server settings  */
    struct sServerSettings
    {
        Boolean                         bEnablefileftransfer;                   /*!< enable / disable File Transfer */
        Unsigned16                      u16MaxFilesInDirectory;                 /*!< Maximum No of Files in Directory(default 25) */
        Boolean                         bEnableDoubleTransmission;              /*!< enable double transmission */
        Unsigned8                       u8TotalNumberofStations;                /*!< in a single physical device/ server, we can run many stations - nmuber of stations in our server, according to Common Address (1-5) */
        Boolean                         benabaleUTCtime;                        /*!< enable utc time/ local time*/
        Boolean                         bTransmitSpontMeasuredValue;            /*!< Transmit M_ME measured values in spontanous message */
        Boolean                         bTransmitInterrogationMeasuredValue;    /*!< Transmit M_ME measured values in General interrogation */
        Boolean                         bTransmitBackScanMeasuredValue;         /*!< Transmit M_ME measured values in background message */
        Unsigned16                      u16ShortPulseTime;                      /*!< Short Pulse Time in milliseconds */
        Unsigned16                      u16LongPulseTime;                       /*!< Long Pulse Time in milliseconds */
		Boolean							bServerInitiateTCPconnection;			/*!< Server will initiate the TCP/IP connection to Client, default FALSE if true, the u16MaxNumberofConnection must be one, and  bEnableRedundancy must be FALSE;*/
        Unsigned8                       u8InitialdatabaseQualityFlag;           /*!< 0-online, 1 BIT- iv, 2 BIT-nt,  MAX VALUE -3   */
        Boolean                         bUpdateCheckTimestamp;                  /*!< if it true ,the timestamp change also generate event  during the iec104update */
		Boolean 						bSequencebitSet;						  /*!< If it true, Server builds iec frame with sequence for monitoring information without time stamp */
		enum eCauseofTransmissionSize   eCOTsize;                              /*!< Cause of transmission size - Default - COT_TWO_BYTE*/
    	Unsigned16                      u16NoofObject;                          /*!< Total number of IEC104 Objects (struct sIEC104Object *)*/
        struct sIEC104DebugParameters   sDebug;                                 /*!< Debug options settings on loading the configuarion See struct sIEC104DebugParameters */
        struct sIEC104Object            *psIEC104Objects;                       /*!< Pointer to strcuture IEC 104 Objects */
        struct sServerConnectionParameters sServerConParameters;              /*!< pointer to number of parallel client communication */
        Integer8                        ai8FileTransferDirPath[MAX_DIRECTORY_PATH]; /*!< File Transfer Directory Path */
        Unsigned16                      au16CommonAddress[MAX_CA];              /*!< station address- Common Address , 1-65534 , 65535 = global address (only master can use this)*/
    };

    /*! \brief  client connection parameters  */
    struct sClientConnectionParameters
    {
        enum eConnectState                  eState;                                         /*!< Connection mode - Data mode, - data transfer enabled, Test Mode - socket connection established only test signals transmited */
        Unsigned8                           u8TotalNumberofStations;                        /*!< total number of station/sector range 1-5 */
        Unsigned8                           u8OriginatorAddress;                            /*!< Orginator Address , 0 - not used, 1-255*/
        Integer16                           i16k;                                           /*!< Maximum difference receive sequence number to send state variable (k: 1 to 32767) default - 12*/
        Integer16                           i16w;                                           /*!< Latest acknowledge after receiving w I format APDUs (w: 1 to 32767 APDUs, accuracy 1 APDU (Recommendation: w should not exceed two-thirds of k) default :8)*/
        Unsigned8                           u8t0;                                           /*!< Time out of connection establishment in seconds (1-255s)*/
        Unsigned8                           u8t1;                                           /*!< Time out of send or test APDUs in seconds (1-255s)*/
        Unsigned8                           u8t2;                                           /*!< Time out for acknowledges in case of no data message t2 M t1 in seconds (1-255s)*/
        Unsigned16                          u16t3;                                          /*!< Time out for sending test frames in case of long idle state in seconds ( 1 to 172800 sec) */
        Unsigned32                          u32GeneralInterrogationInterval;                /*!< in sec if 0 , gi will not send in particular interval, else in particular seconds GI will send to server*/
        Unsigned32                          u32Group1InterrogationInterval;                 /*!< in sec if 0 , group 1 interrogation will not send in particular interval, else in particular seconds group 1 interrogation will send to server*/
        Unsigned32                          u32Group2InterrogationInterval;                 /*!< in sec if 0 , group 2 interrogation will not send in particular interval, else in particular seconds group 2 interrogation will send to server*/
        Unsigned32                          u32Group3InterrogationInterval;                 /*!< in sec if 0 , group 3 interrogation will not send in particular interval, else in particular seconds group 3 interrogation will send to server*/
        Unsigned32                          u32Group4InterrogationInterval;                 /*!< in sec if 0 , group 4 interrogation will not send in particular interval, else in particular seconds group 4 interrogation will send to server*/
        Unsigned32                          u32Group5InterrogationInterval;                 /*!< in sec if 0 , group 5 interrogation will not send in particular interval, else in particular seconds group 5 interrogation will send to server*/
        Unsigned32                          u32Group6InterrogationInterval;                 /*!< in sec if 0 , group 6 interrogation will not send in particular interval, else in particular seconds group 6 interrogation will send to server*/
        Unsigned32                          u32Group7InterrogationInterval;                 /*!< in sec if 0 , group 7 interrogation will not send in particular interval, else in particular seconds group 7 interrogation will send to server*/
        Unsigned32                          u32Group8InterrogationInterval;                 /*!< in sec if 0 , group 8 interrogation will not send in particular interval, else in particular seconds group 8 interrogation will send to server*/
        Unsigned32                          u32Group9InterrogationInterval;                 /*!< in sec if 0 , group 9 interrogation will not send in particular interval, else in particular seconds group 9 interrogation will send to server*/
        Unsigned32                          u32Group10InterrogationInterval;                /*!< in sec if 0 , group 10 interrogation will not send in particular interval, else in particular seconds group 10 interrogation will send to server*/
        Unsigned32                          u32Group11InterrogationInterval;                /*!< in sec if 0 , group 11 interrogation will not send in particular interval, else in particular seconds group 11 interrogation will send to server*/
        Unsigned32                          u32Group12InterrogationInterval;                /*!< in sec if 0 , group 12 interrogation will not send in particular interval, else in particular seconds group 12 interrogation will send to server*/
        Unsigned32                          u32Group13InterrogationInterval;                /*!< in sec if 0 , group 13 interrogation will not send in particular interval, else in particular seconds group 13 interrogation will send to server*/
        Unsigned32                          u32Group14InterrogationInterval;                /*!< in sec if 0 , group 14 interrogation will not send in particular interval, else in particular seconds group 14 interrogation will send to server*/
        Unsigned32                          u32Group15InterrogationInterval;                /*!< in sec if 0 , group 15 interrogation will not send in particular interval, else in particular seconds group 15 interrogation will send to server*/
        Unsigned32                          u32Group16InterrogationInterval;                /*!< in sec if 0 , group 16 interrogation will not send in particular interval, else in particular seconds group 16 interrogation will send to server*/
        Unsigned32                          u32CounterInterrogationInterval;                /*!< in sec if 0 , ci will not send in particular interval*/
        Unsigned32                          u32Group1CounterInterrogationInterval;          /*!< in sec if 0 , group 1 counter interrogation will not send in particular interval*/
        Unsigned32                          u32Group2CounterInterrogationInterval;          /*!< in sec if 0 , group 2 counter interrogation will not send in particular interval*/
        Unsigned32                          u32Group3CounterInterrogationInterval;          /*!< in sec if 0 , group 3 counter interrogation will not send in particular interval*/
        Unsigned32                          u32Group4CounterInterrogationInterval;          /*!< in sec if 0 , group 4 counter interrogation will not send in particular interval*/
        Unsigned32                          u32ClockSyncInterval;                           /*!< in sec if 0 , clock sync, will not send in particular interval */
        Unsigned32                          u32CommandTimeout;                              /*!< in ms, minimum 3000  */
        Unsigned32                          u32FileTransferTimeout;                         /*!< in ms, minimum 3000  */
        Boolean                             bCommandResponseActtermUsed;                    /*!< server sends ACTTERM in command response */
        Unsigned16                          u16PortNumber;                                  /*!< Port Number */
        Boolean                             bEnablefileftransfer;                           /*!< enable / disable File Transfer */
        Boolean                             bUpdateCallbackCheckTimestamp;                  /*!< if it true ,the timestamp change also create the updatecallback */
		enum eCauseofTransmissionSize   	eCOTsize;                              			/*!< Cause of transmission size - Default - COT_TWO_BYTE*/
    	Unsigned16                          u16NoofObject;                                  /*!< Total number of IEC104 Objects (struct sIEC104Object *)*/
        struct sIEC104Object                *psIEC104Objects;                               /*!< Pointer to strcuture IEC104 Objects */
        Unsigned16                          au16CommonAddress[MAX_CA];                      /*!< in a single physical device we can run many stations,station address- Common Address , 0 - not used, 1-65534 , 65535 = global address (only master can use this)*/
        Integer8                            ai8DestinationIPAddress[MAX_IPV4_ADDRSIZE];     /*!< Server IP Address */
		Integer8                            ai8FileTransferDirPath[MAX_DIRECTORY_PATH];     /*!< File Transfer Directory Path */

    };

    /*! \brief  Client settings  */
    struct sClientSettings
    {
        Boolean                             bAutoGenIEC104DataObjects;          /*!< if it true ,the IEC104 Objects created automaticallay, use u16NoofObject = 0, psIEC104Objects = NULL*/
		Unsigned16 							u16UpdateBuffersize;				/*!< if bAutoGenIEC104DataObjects true, update callback buffersize, approx 3 * max count of monitoring points in the server */		
		Boolean								bClientAcceptTCPconnection;			/*!< Client will accept the TCP/IP connection from server, default - False, if true u16TotalNumberofConnection = 1 , and bAutoGenIEC104DataObjects = true*/
        Unsigned16                          u16TotalNumberofConnection;         /*!< total number of connection (struct sClientConnectionParameters *)*/
        Boolean                             benabaleUTCtime;                    /*!< enable utc time/ local time*/
        struct sIEC104DebugParameters       sDebug;                             /*!< Debug options settings on loading the configuarion See struct sIEC104DebugParameters */
        struct sClientConnectionParameters  *psClientConParameters;             /*!< pointer to client connection parameters */
		Integer8                			ai8SourceIPAddress[MAX_IPV4_ADDRSIZE];  		/*!< client own IP Address , use 0.0.0.0 / network ip address for binding socket*/   
		
    };

    /*! \brief  IEC104 Configuration parameters  */
    struct sIEC104ConfigurationParameters
    {
        struct sServerSettings          sServerSet;                         /*!< Server settings */
        struct sClientSettings          sClientSet;                         /*!< Client settings */
    };


    /*! \brief      IEC104 Data Attribute */
    struct sIEC104DataAttributeID
    {
        Unsigned16                      u16PortNumber;          /*!< Port Number */
        Unsigned16                      u16CommonAddress;       /*!< Orginator Address /Common Address , 0 - not used, 1-65534 station address, 65535 = global address (only master can use this)*/
        Unsigned32                      u32IOA;                 /*!< Information Object Address */
        enum eIEC870TypeID              eTypeID;                /*!< Type Identification */
        void                            *pvUserData;            /*!< Application specific User Data */
        Integer8                        ai8IPAddress[MAX_IPV4_ADDRSIZE];                        /*!< IP Address */
    };

    /*! \brief      IEC104 Data Attribute Data */
    struct sIEC104DataAttributeData
    {
        struct sTargetTimeStamp    sTimeStamp;      /*!< TimeStamp */
        tIEC870Quality          tQuality;           /*!< Quality of Data see eIEC104QualityFlags */
        enum    eDataTypes      eDataType;          /*!< Data Type */
        enum    eDataSizes      eDataSize;          /*!< Data Size */
        enum eTimeQualityFlags eTimeQuality;  		/*!< time quality */
        Unsigned16              u16ElapsedTime;     /*!< Elapsed time(M_EP_TA_1, M_EP_TD_1) /Relay duration time(M_EP_TB_1, M_EP_TE_1) /Relay Operating time (M_EP_TC_1, M_EP_TF_1)  In Milliseconds */
        Boolean                 bTimeInvalid;       /*!< time Invalid */
		Boolean 				bTRANSIENT; 		/*!<transient state indication result value step position information*/
		Unsigned8				u8Sequence; 		/*!< m_it - Binary counter reading - Sequence notation*/
		void                    *pvData;            /*!< Pointer to Data */
    };

    /*! \brief      Parameters provided by read callback   */
    struct sIEC104ReadParameters
    {
        Unsigned8   u8OriginatorAddress;        /*!< client orginator address */
        Unsigned8   u8Dummy;                    /*!< Dummy only for future expansion purpose */
    };

    /*! \brief      Parameters provided by write callback   */
    struct sIEC104WriteParameters
    {
        Unsigned8               u8OriginatorAddress;        /*!< client orginator address */
        enum eIEC870COTCause    eCause;                     /*!< cause of transmission */
        Unsigned8               u8Dummy;                    /*!< Dummy only for future expansion purpose */
    };

    /*! \brief      Parameters provided by update callback   */
    struct sIEC104UpdateParameters
    {
        enum eIEC870COTCause    eCause;                         /*!< Cause of transmission */
        enum eKindofParameter   eKPA;                           /*!< For typeids,P_ME_NA_1, P_ME_NB_1, P_ME_NC_1 - Kind of parameter , refer enum eKPA*/

    };

    /*! \brief      Parameters provided by Command callback   */
    struct sIEC104CommandParameters
    {
        Unsigned8                   u8OriginatorAddress;        /*!<  client orginator address */
        enum eCommandQOCQU          eQOCQU;                     /*!< Qualifier of Commad */
        Unsigned32                  u32PulseDuration;           /*!< Pulse Duration Based on the Command Qualifer */

    };

    /*! \brief      Parameters provided by parameter act callback   */
    struct sIEC104ParameterActParameters
    {
         Unsigned8              u8OriginatorAddress;            /*!<  client orginator address */
         Unsigned8              u8QPA;                          /*!< Qualifier of parameter activation/kind of parameter , for typeid P_AC_NA_1, please refer 7.2.6.25, for typeid 110,111,112 please refer KPA 7.2.6.24*/
    };


    /*! \brief  IEC104 Debug Callback Data */
    struct sIEC104DebugData
    {
        Unsigned32                      u32DebugOptions;                            /*!< Debug Option see eDebugOptionsFlag */
        Integer16                       iErrorCode;                                 /*!< error code if any */
        tErrorValue                     tErrorvalue;                                /*!< error value if any */
        Unsigned16                      u16RxCount;                                 /*!< Receive data count */
        Unsigned16                      u16TxCount;                                 /*!< Transmitted data count */
        Unsigned16                      u16PortNumber;                              /*!<  Port Number*/
        struct sTargetTimeStamp            sTimeStamp;                                 /*!< TimeStamp */
        Unsigned8                       au8ErrorMessage[MAX_ERROR_MESSAGE];         /*!< error message */
        Unsigned8                       au8WarningMessage[MAX_WARNING_MESSAGE];     /*!< warning message */
        Unsigned8                       au8RxData[IEC104_MAX_RX_MESSAGE];                  /*!< Received data  */
        Unsigned8                       au8TxData[IEC104_MAX_TX_MESSAGE];                  /*!< Transmitted data */
        Integer8                        ai8IPAddress[MAX_IPV4_ADDRSIZE];            /*!<IP Address */
    };

    /*! \brief IEC104 File Attributes*/
    struct sIEC104FileAttributes
    {
        Boolean                     bFileDirectory;                  /*!< File /Directory File-1,Directory 0 */
        Unsigned16                  u16FileName;                     /*!< File Name */
        UnSize                      zFileSize;                       /*!< File size*/
        Boolean                     bLastFileOfDirectory;            /*!< Last File Of Directory*/
        struct sTargetTimeStamp        sLastModifiedTime;               /*!< Last Modified Time*/
    };

    /*! \brief IEC104 Directory List*/
    struct sIEC104DirectoryList
    {
        Unsigned16                      u16FileCount;                         /*!< File Count read from the Directory */
        struct sIEC104FileAttributes    *psFileAttrib;                        /*!< Pointer to File Attributes */
    };

     /*! \brief server connection detail*/
    struct sIEC104ServerConnectionID
    {
        Unsigned16              u16SourcePortNumber;                    /*!< Source port number */
        Unsigned16              u16RemotePortNumber;                     /*!< remote port number */
        Integer8                ai8SourceIPAddress[MAX_IPV4_ADDRSIZE];  /*!< Server IP Address , use 0.0.0.0 / network ip address*/
        Integer8                ai8RemoteIPAddress[MAX_IPV4_ADDRSIZE];  /*!< Remote IP Address , use 0,0.0.0 to accept all remote station ip*/
     };

    /*! \brief error code more description */
    struct sIEC104ErrorCode
    {
         Integer16 iErrorCode;        /*!< errorcode */
         char* shortDes;     /*!< error code short description*/
         char* LongDes;     /*!< error code brief description*/
    };


    /*! \brief error value more description */
    struct sIEC104ErrorValue
    {
         Integer16 iErrorValue;       /*!< errorvalue */
         char* shortDes;     /*!< error value short description*/
         char* LongDes;     /*!< error value brief description*/
    };


    /*! \brief  Forward declaration */
    struct sIEC104AppObject;

    /*! \brief  Pointer to IEC 104 object */
    typedef struct sIEC104AppObject *IEC104Object;


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
    typedef Integer16 (*IEC104ReadCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptReadID, struct sIEC104DataAttributeData *ptReadValue, struct sIEC104ReadParameters *ptReadParams, tErrorValue *ptErrorValue );

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
    typedef Integer16 (*IEC104WriteCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptWriteID, struct sIEC104DataAttributeData *ptWriteValue,struct sIEC104WriteParameters *ptWriteParams, tErrorValue *ptErrorValue);


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
    typedef Integer16 (*IEC104UpdateCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptUpdateID, struct sIEC104DataAttributeData *ptUpdateValue, struct sIEC104UpdateParameters *ptUpdateParams, tErrorValue *ptErrorValue);

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
    typedef Integer16 (*IEC104DirectoryCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID * ptDirectoryID,  struct sIEC104DirectoryList *ptDirList, tErrorValue *ptErrorValue);

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
    typedef Integer16 (*IEC104ControlSelectCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptSelectID, struct sIEC104DataAttributeData *ptSelectValue,struct sIEC104CommandParameters *ptSelectParams, tErrorValue *ptErrorValue);


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
    typedef Integer16 (*IEC104ControlOperateCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue,struct sIEC104CommandParameters *ptOperateParams, tErrorValue *ptErrorValue);


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
    typedef Integer16 (*IEC104ControlCancelCallback)(Unsigned16 u16ObjectId, enum eOperationFlag eOperation, struct sIEC104DataAttributeID *ptCancelID, struct sIEC104DataAttributeData *ptCancelValue,struct sIEC104CommandParameters *ptCancelParams, tErrorValue *ptErrorValue);


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
    typedef Integer16 (*IEC104ControlFreezeCallback)(Unsigned16 u16ObjectId, enum eCounterFreezeFlags eCounterFreeze, struct sIEC104DataAttributeID *ptFreezeID,  struct sIEC104DataAttributeData *ptFreezeValue, struct sIEC104WriteParameters *ptFreezeCmdParams, tErrorValue *ptErrorValue);

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
     typedef Integer16 (*IEC104ControlPulseEndActTermCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue,struct sIEC104CommandParameters *ptOperateParams, tErrorValue *ptErrorValue);

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
    typedef Integer16 (*IEC104DebugMessageCallback)(Unsigned16 u16ObjectId, struct sIEC104DebugData *ptDebugData, tErrorValue *ptErrorValue);



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
    typedef Integer16 (*IEC104ParameterActCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue,struct sIEC104ParameterActParameters *ptParameterActParams, tErrorValue *ptErrorValue);


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
     typedef Integer16 (*IEC104ClientStatusCallback)(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptDataID, enum eStatus *peSat, tErrorValue *ptErrorValue);

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
    typedef Integer16 (*IEC104ServerStatusCallback)(Unsigned16 u16ObjectId, struct sIEC104ServerConnectionID *ptServerConnID, enum eStatus *peSat, tErrorValue *ptErrorValue);

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

	typedef Integer16 (*IEC104ServerFileTransferCallback)(enum eFileTransferDirection eDirection, Unsigned16 u16ObjectId, struct sIEC104ServerConnectionID *ptServerConnID, Unsigned16 u16CommonAddress, Unsigned32 u32IOA, Unsigned16 u16FileName, Unsigned32 u32LengthOfFile, enum eFileTransferStatus *peFileTransferSat, tErrorValue *ptErrorValue);


    /*! \brief      Create Server/client parameters structure  */
    struct sIEC104Parameters
    {
        enum eApplicationFlag                   eAppFlag;                           /*!< Flag set to indicate the type of application */
        Unsigned32                              u32Options;                         /*!< Options flag, used to set client/server */
        Unsigned16                              u16ObjectId;                        /*!< User idenfication will be retured in the callback for iec104object identification*/
        IEC104ReadCallback                      ptReadCallback;                     /*!< Read callback function. If equal to NULL then callback is not used. */
        IEC104WriteCallback                     ptWriteCallback;                    /*!< Write callback function. If equal to NULL then callback is not used. */
        IEC104UpdateCallback                    ptUpdateCallback;                   /*!< Update callback function. If equal to NULL then callback is not used. */
        IEC104ControlSelectCallback             ptSelectCallback;                   /*!< Function called when a Select Command is executed.  If equal to NULL then callback is not used*/
        IEC104ControlOperateCallback            ptOperateCallback;                  /*!< Function called when a Operate command is executed.  If equal to NULL then callback is not used */
        IEC104ControlCancelCallback             ptCancelCallback;                   /*!< Function called when a Cancel command is executed.  If equal to NULL then callback is not used */
        IEC104ControlFreezeCallback             ptFreezeCallback;                   /*!< Function called when a Freeze Command is executed.  If equal to NULL then callback is not used*/
        IEC104ControlPulseEndActTermCallback    ptPulseEndActTermCallback;          /*!< Function called when a pulse  command time expires.  If equal to NULL then callback is not used */
        IEC104DebugMessageCallback              ptDebugCallback;                    /*!< Function called when debug options are set. If equal to NULL then callback is not used */
        IEC104ParameterActCallback              ptParameterActCallback;             /*!< Function called when a Parameter act command is executed.  If equal to NULL then callback is not used */
        IEC104DirectoryCallback                 ptDirectoryCallback;                /*!< Directory callback function. List The Files in the Directory. */
        IEC104ClientStatusCallback              ptClientStatusCallback;             /*!< Function called when client connection status changed */
        IEC104ServerStatusCallback              ptServerStatusCallback;             /*!< Function called when server connection status changed */		
		IEC104ServerFileTransferCallback		ptServerFileTransferCallback; 		/*!< Function called when server received a new file from client via control direction file transfer */
    };


    #ifdef __cplusplus
        }
    #endif


    /*

    Cyclic data transmission:

    Cyclic data transfer is initiated in a similar way as the background scan from the substation.
    It is independent of other commands from the central station. Cyclic data transfer continuously refreshes the process data of the central station.
    The process data are usually measured values that are recorded at regular intervals.
    Cyclic data transfer is often used for monitoring non-time-critical or  relatively slowly changing process data (e.g. temperature sensor data).
    Cyclic/periodic data are transferred to the central station with cause of transmission <1> periodic/cyclic.

    Background scan:

    The background scan is used for refreshing the process information sent from the substation to the central station as an additional safety contribution to
    the station interrogation and for spontaneous transfers.
    Application objects with the same type IDs as for the station interrogation may be transferred continuously with low priority, and with <2> background
    scan as the cause of transmission.  The valid ASDU type IDs are listed in the compatibility list for the station (table type ID <-> cause of transmission).
    The background scan is initiated by the substation and is independent of the station interrogation commands.

    */

#endif

/*!
 *\}
 */

