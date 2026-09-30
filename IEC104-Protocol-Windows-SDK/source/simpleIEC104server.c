/******************************************************************************
*
* (c) 2026 by FreyrSCADA Embedded Solution Pvt Ltd
*
********************************************************************************
*
* Disclaimer: This program is an example and should be used as such.
*             If you wish to use this program or parts of it in your application,
*             you must validate the code yourself.  FreyrSCADA Embedded Solution Pvt Ltd
*             can not be held responsible for the correct functioning
*             or coding of this example
*******************************************************************************/

/*****************************************************************************/
/*! \file       simpleiec104server.c
 *  \brief      Windows - C Source code file, IEC 60870-5-104 Server library test program
 *
 *  \par        FreyrSCADA Embedded Solution Pvt Ltd
 *              Email   : tech.support@freyrscada.com
 */
/*****************************************************************************/

/******************************************************************************
* Includes
******************************************************************************/
#include <time.h>
#include <conio.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <process.h>



#include "tgttypes.h"
#include "iec104api.h"


/*! \brief - in a loop simulate update - for particular IOA, value changes - generates a event  */
#define SIMULATE_UPDATE 1

/*! \brief - Enable traffic flags to show transmit and receive signal  */
#define VIEW_TRAFFIC 1


/******************************************************************************
* Error code - Print information
******************************************************************************/
const char *  errorcodestring(int errorcode)
{
     struct sIEC104ErrorCode sIEC104ErrorCodeDes  = {0};
     const char *i8ReturnedMessage = " ";

     sIEC104ErrorCodeDes.iErrorCode = errorcode;

     IEC104ErrorCodeString(&sIEC104ErrorCodeDes);

     i8ReturnedMessage = sIEC104ErrorCodeDes.LongDes;

     return (i8ReturnedMessage);
}

/******************************************************************************
* Error value - Print information
******************************************************************************/
const char *  errorvaluestring(int errorvalue)
{
    struct sIEC104ErrorValue sIEC104ErrorValueDes  = {0};
     const char *i8ReturnedMessage = " ";

     sIEC104ErrorValueDes.iErrorValue = errorvalue;

     IEC104ErrorValueString(&sIEC104ErrorValueDes);

     i8ReturnedMessage = sIEC104ErrorValueDes.LongDes;

     return (i8ReturnedMessage);
}

/******************************************************************************
* Print information
******************************************************************************/
void vPrintDataInformation(struct sIEC104DataAttributeID * psPrintID, const struct sIEC104DataAttributeData * psData)
{
    Unsigned8 u8data        = 0;
    Integer8 i8data     = 0;
    Unsigned16 u16data      = 0;
    Integer16 i16data       = 0;
    Float32   f32data   = 0;
    Integer32 i32data   = 0;
    Unsigned32 u32data      = 0;

    if(psPrintID == NULL)
    {
        printf("\r\n Data Attribute ID is NULL");
        return;
    }

    if(psData == NULL)
    {
        printf("\r\n Data is NULL");
        return;
    }

    printf("\r\n IP Address %s",psPrintID->ai8IPAddress);
    printf("\r\n Port Number %u",psPrintID->u16PortNumber);
    printf("\r\n Common Address %u",psPrintID->u16CommonAddress);
    printf("\r\n Typeid ID is  %u IOA %u ", psPrintID->eTypeID, psPrintID->u32IOA);
    printf("\r\n Datatype->%u Datasize->%u  ", psData->eDataType, psData->eDataSize );


    if(psData->tQuality != GD)
    {
        if((psData->tQuality & IV) == IV)
        {
            printf(" IEC_INVALID_FLAG");
        }

        if((psData->tQuality & NT) == NT)
        {
            printf(" IEC_NONTOPICAL_FLAG");
        }

        if((psData->tQuality & SB) == SB)
        {
            printf(" IEC_SUBSTITUTED_FLAG");
        }

        if((psData->tQuality & BL) == BL)
        {
            printf(" IEC_BLOCKED_FLAG");
        }
    }

    switch(psData->eDataType)
    {
        case SINGLE_POINT_DATA:
        case DOUBLE_POINT_DATA:
        case UNSIGNED_BYTE_DATA:

            memcpy(&u8data,psData->pvData,sizeof(Unsigned8));
            printf(" Data : %u",u8data);
            break;

        case SIGNED_BYTE_DATA :
            memcpy(&i8data,psData->pvData,sizeof(Unsigned8));
            printf(" Data : %d",i8data);
            break;

        case UNSIGNED_WORD_DATA:
            memcpy(&u16data,psData->pvData,sizeof(Unsigned16));
            printf(" Data : %u",u16data);
            break;

        case SIGNED_WORD_DATA :
            memcpy(&i16data,psData->pvData,sizeof(Unsigned16));
            printf(" Data : %d",i16data);
            break;

        case  UNSIGNED_DWORD_DATA :
            memcpy(&u32data,psData->pvData,sizeof(Unsigned32));
            printf(" Data : %u",u32data);
            break;

        case SIGNED_DWORD_DATA :
            memcpy(&i32data,psData->pvData,sizeof(Unsigned32));
            printf(" Data : %d",i32data);
            break;

        case  FLOAT32_DATA :
            memcpy(&f32data,psData->pvData,sizeof(Unsigned32));
            printf(" Data : %0.3f",f32data);
            break;

        default:
            break;
    }

   if( psData->sTimeStamp.u16Year != 0 )
    {
        printf( "\r\n Date : %02u-%02u-%04u  DOW -%u",psData->sTimeStamp.u8Day,psData->sTimeStamp.u8Month, psData->sTimeStamp.u16Year,psData->sTimeStamp.u8DayoftheWeek);

        printf( "\r\n Time : %02u:%02u:%02u:%03u", psData->sTimeStamp.u8Hour, psData->sTimeStamp.u8Minute, psData->sTimeStamp.u8Seconds, psData->sTimeStamp.u16MilliSeconds);
    }

}

/******************************************************************************
* Server Status Callback
******************************************************************************/
Integer16 cbServerStatus(Unsigned16 u16ObjectId, struct sIEC104ServerConnectionID *ptServerConnID, enum eStatus *peSat, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;

    printf("\n\r\n cbServerstatus() called");
	printf("\r\n Server ID : %u", u16ObjectId);

    if(*peSat == CONNECTED)
    {
    printf("\r\n Status - Connected");
    }
    else
    {
        printf("\r\n Status - Disconnected");
    }

    printf("\r\n Source IP Address %s Port %u ", ptServerConnID->ai8SourceIPAddress, ptServerConnID->u16SourcePortNumber);
    printf("\r\n Remote IP Address %s Port %u ", ptServerConnID->ai8RemoteIPAddress, ptServerConnID->u16RemotePortNumber);

    return i16ErrorCode;
}


/******************************************************************************
* Parameteract callback
******************************************************************************/
Integer16 cbParameterAct(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue,struct sIEC104ParameterActParameters *ptParameterActParams, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;

    printf("\n\r\n cbParameterAct() called");
	printf("\r\n Server ID : %u", u16ObjectId);
    vPrintDataInformation(ptOperateID, ptOperateValue);
    printf("\r\n Orginator Address %u",ptParameterActParams->u8OriginatorAddress);
    printf("\r\n Qualifier of Parameter Activation/Kind of Parameter %u",ptParameterActParams->u8QPA);
    

    return i16ErrorCode;
}

/******************************************************************************
* Read callback
******************************************************************************/
Integer16 cbRead(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID * psReadID, struct sIEC104DataAttributeData * psReadValue, struct sIEC104ReadParameters * psReadParams, tErrorValue * ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;

    printf("\n\r\n cbRead() called"); 
	printf("\r\n Server ID : %u", u16ObjectId);
    vPrintDataInformation(psReadID, psReadValue);
    printf("\r\n Orginator Address %u",psReadParams->u8OriginatorAddress);

    return i16ErrorCode;
}

/******************************************************************************
* Write callback
******************************************************************************/
Integer16 cbWrite(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptWriteID, struct sIEC104DataAttributeData *ptWriteValue,struct sIEC104WriteParameters *ptWriteParams, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;

    printf("\n\r\n cbWrite() called - Clock Sync Command from IEC104 client");
	printf("\r\n Server ID : %u", u16ObjectId);
    vPrintDataInformation(ptWriteID, ptWriteValue);
    printf("\r\n Orginator Address %u",ptWriteParams->u8OriginatorAddress);

    return i16ErrorCode;
}

/******************************************************************************
* Freeze Callback
******************************************************************************/
Integer16 cbFreeze(Unsigned16 u16ObjectId, enum eCounterFreezeFlags eCounterFreeze, struct sIEC104DataAttributeID *ptFreezeID,  struct sIEC104DataAttributeData *ptFreezeValue, struct sIEC104WriteParameters *ptFreezeCmdParams, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;

    printf("\n\r\n cbFreeze() called");   
	printf("\r\n Server ID : %u", u16ObjectId);
    printf("\r\n Command Typeid %u", ptFreezeID->eTypeID);
    printf("\r\n COT %u", ptFreezeCmdParams->eCause);
    printf("\r\n Orginator Address  %u",ptFreezeCmdParams->u8OriginatorAddress );

    return i16ErrorCode;
}

/******************************************************************************
* Select callback
******************************************************************************/
Integer16 cbSelect(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptSelectID, struct sIEC104DataAttributeData *ptSelectValue,struct sIEC104CommandParameters *ptSelectParams, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;

    printf("\n\r\n cbSelect() called");
	printf("\r\n Server ID : %u", u16ObjectId);
    vPrintDataInformation(ptSelectID, ptSelectValue);
    printf("\r\n Orginator Address  %u",ptSelectParams->u8OriginatorAddress );
    printf("\r\n Qualifier %u",ptSelectParams->eQOCQU );
    printf("\r\n Pulse Duration %u",ptSelectParams->u32PulseDuration );

    return i16ErrorCode;
}


/******************************************************************************
* Operate callback
******************************************************************************/
Integer16 cbOperate(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue,struct sIEC104CommandParameters *ptOperateParams, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;

    printf("\n\r\n cbOperate() called");
	printf("\r\n Server ID : %u", u16ObjectId);
    vPrintDataInformation(ptOperateID, ptOperateValue);
    printf("\r\n Qualifier %u",ptOperateParams->eQOCQU);
    printf("\r\n Pulse Duration %u",ptOperateParams->u32PulseDuration);
    printf("\r\n Orginator Address %u",ptOperateParams->u8OriginatorAddress);

    return i16ErrorCode;
}


/******************************************************************************
* Operate pulse end callback
******************************************************************************/
Integer16 cbpulseend(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptOperateID, struct sIEC104DataAttributeData *ptOperateValue,struct sIEC104CommandParameters *ptOperateParams, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;

    printf("\n\r\n cbOperatepulse end() called");
	printf("\r\n Server ID : %u", u16ObjectId);
    vPrintDataInformation(ptOperateID, ptOperateValue);
    printf("\r\n Qualifier %u",ptOperateParams->eQOCQU);
    printf("\r\n Pulse Duration %u",ptOperateParams->u32PulseDuration);
    printf("\r\n Orginator Address %u",ptOperateParams->u8OriginatorAddress);

    return i16ErrorCode;
}

/******************************************************************************
* Cancel callback
******************************************************************************/
Integer16 cbCancel(Unsigned16 u16ObjectId, enum eOperationFlag eOperation, struct sIEC104DataAttributeID *ptCancelID, struct sIEC104DataAttributeData *ptCancelValue,struct sIEC104CommandParameters *ptCancelParams, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;

    printf("\n\r\n cbCancel() called");
	printf("\r\n Server ID : %u", u16ObjectId);

    if(eOperation   ==  OPERATE)
        printf("\r\n Operate operation to be cancel");

    if(eOperation   ==  SELECT)
        printf("\r\n Select operation to cancel");

    vPrintDataInformation(ptCancelID, ptCancelValue);
    printf("\r\n Qualifier %u",ptCancelParams->eQOCQU );
    printf("\r\n Pulse Duration %u",ptCancelParams->u32PulseDuration );
    printf("\r\n Orginator Address %u",ptCancelParams->u8OriginatorAddress );


    return i16ErrorCode;
}

/******************************************************************************
* Debug callback
******************************************************************************/
Integer16  cbDebug(Unsigned16 u16ObjectId,  struct sIEC104DebugData * ptDebugData, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;
    Unsigned8 u8nav                = 0;

    //printf("\n\r\n cbDebug() called");
    printf("\r\n %u:%u:%u Server ID: %u", ptDebugData->sTimeStamp.u8Hour, ptDebugData->sTimeStamp.u8Minute, ptDebugData->sTimeStamp.u8Seconds,u16ObjectId);

    if((ptDebugData->u32DebugOptions & DEBUG_OPTION_TX ) == DEBUG_OPTION_TX)
    {
        printf(" IP %s Port %u", ptDebugData->ai8IPAddress, ptDebugData->u16PortNumber);
        printf("\r\n ->");

        for(u8nav = 0; u8nav < (ptDebugData->u16TxCount); u8nav++)
        {
            printf(" %02x",ptDebugData->au8TxData[u8nav]);
        }
    }

    if((ptDebugData->u32DebugOptions & DEBUG_OPTION_RX ) == DEBUG_OPTION_RX)
    {
        printf(" IP %s Port %u", ptDebugData->ai8IPAddress, ptDebugData->u16PortNumber);
        printf("\r\n <-");

        for(u8nav = 0; u8nav < (ptDebugData->u16RxCount); u8nav++)
        {
            printf(" %02x",ptDebugData->au8RxData[u8nav]);
        }
    }

    if((ptDebugData->u32DebugOptions & DEBUG_OPTION_ERROR ) == DEBUG_OPTION_ERROR)
    {
        printf("\r\n Error message %s", ptDebugData->au8ErrorMessage);
        printf("\r\n ErrorCode %d", ptDebugData->iErrorCode);
        printf("\r\n ErrorValue %d", ptDebugData->tErrorvalue);
    }

    return i16ErrorCode;
}


/******************************************************************************
* main()
******************************************************************************/
int main (void)
{
    Integer16                    i16ErrorCode        = EC_NONE;     // API Function return error paramter
    tErrorValue                             tErrorValue       = EV_NONE;    // API Function return additional error parameter
    IEC104Object                              myServer         = NULL;      // IEC 60870-5-104 Server object
    Unsigned16                   u16Char         =   0;                     // Get control+x key to stop update values
    struct sIEC104DataAttributeID *psDAID       =   NULL;                   // update data attribute
    struct sIEC104DataAttributeData *psNewValue =   NULL;                   // update new value
    Float32 f32data                         = 0;                            // update data
    struct sIEC104ConfigurationParameters  sIEC104Config;                   // server protocol , point configuration parameters
    struct sIEC104Parameters               sParameters;                     // IEC104 Server object callback paramters 
    unsigned int uiCount;                                                   // update number of parameters
    struct tm * timeinfo;                                                   // update date and time structute
    time_t now;                                                             // to get current data and time                                       
    



   do
   {
       printf("\r\n \t\t**** IEC 60870-5-104 Protocol Server Library Test ****");
       // Check library version against the library header file
        if(strcmp((char*)IEC104GetLibraryVersion(), IEC104_VERSION) != 0)
        {
            printf("\r\n Error: Version Number Mismatch");
            printf("\r\n Library Version is  : %s", IEC104GetLibraryVersion());
            printf("\r\n The Version used is : %s", IEC104_VERSION);
            printf("\r\n");
			printf("\r\n Press Enter to free IEC 104 Server object");
			getchar();
			return(0);
        }

        printf("\r\n Library Version is : %s", IEC104GetLibraryVersion());
        printf("\r\n Library Build on   : %s", IEC104GetLibraryBuildTime());
		printf("\r\n Library License Information   : %s", IEC104GetLibraryLicenseInfo());

        memset(&sParameters, 0, sizeof(struct sIEC104Parameters));

        // Initialize IEC 60870-5-104 Server object parameters
        sParameters.eAppFlag          = APP_SERVER;             // This is a IEC104 Server      
        sParameters.ptReadCallback    = cbRead;                 // Read Callback
        sParameters.ptWriteCallback   = cbWrite;                // Write Callback
        sParameters.ptUpdateCallback  = NULL;                   // Update Callback
        sParameters.ptSelectCallback  = cbSelect;               // Select Callback
        sParameters.ptOperateCallback = cbOperate;              // Operate Callback
        sParameters.ptCancelCallback  = cbCancel;               // Cancel Callback
        sParameters.ptFreezeCallback  = cbFreeze;               // Freeze Callback
        sParameters.ptDebugCallback   = cbDebug;                // Debug Callback
        sParameters.ptPulseEndActTermCallback = cbpulseend;     // pulse end callback
        sParameters.ptParameterActCallback = cbParameterAct;    // Parameter activation callback
        sParameters.ptServerStatusCallback =  cbServerStatus;   // server status callback
        sParameters.ptDirectoryCallback    = NULL;              // Directory Callback
        sParameters.ptClientStatusCallback   = NULL;            // client connection status Callback
        sParameters.u32Options        = 0;
		sParameters.u16ObjectId				= 1;				//Server ID which used in callbacks to identify the iec 104 server object   


        // Create a server object
        myServer = IEC104Create(&sParameters, &i16ErrorCode, &tErrorValue);
        if(myServer == NULL)
        {
            printf("\r\n IEC 60870-5-104 Library API Function - IEC104Create() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
            break;
        }

        // Server load configuration - communication and protocol configuration parameters
         memset(&sIEC104Config,0,sizeof(struct sIEC104ConfigurationParameters));

		// check server configuration - TCP/IP Address
        strcpy((char*)sIEC104Config.sServerSet.sServerConParameters.ai8SourceIPAddress,"127.0.0.1"); // own server bind address
		sIEC104Config.sServerSet.sServerConParameters.u16PortNumber             =   2404;

		sIEC104Config.sServerSet.sServerConParameters.u16MaxNumberofRemoteConnection = 1;
		sIEC104Config.sServerSet.sServerConParameters.psServerRemoteIPAddressList = NULL;
		sIEC104Config.sServerSet.sServerConParameters.psServerRemoteIPAddressList = (struct sIEC104ServerRemoteIPAddressList*) calloc(sIEC104Config.sServerSet.sServerConParameters.u16MaxNumberofRemoteConnection,sizeof(struct sIEC104ServerRemoteIPAddressList));
		if(sIEC104Config.sServerSet.sServerConParameters.psServerRemoteIPAddressList == NULL)
		{
			printf("\r\n Error: Not enough memory to alloc objects");
            break;
		}
		//Remote IP Address , use 0,0.0.0 to accept all remote station ip
		strcpy((char*)sIEC104Config.sServerSet.sServerConParameters.psServerRemoteIPAddressList[0].ai8RemoteIPAddress,"0.0.0.0"); // Remote IP Address ,use 0,0.0.0 to accept all remote station ip

		
        
        sIEC104Config.sServerSet.sServerConParameters.i16k                      =  12;
        sIEC104Config.sServerSet.sServerConParameters.i16w                      =  8;
        sIEC104Config.sServerSet.sServerConParameters.u8t0                      = 30;
        sIEC104Config.sServerSet.sServerConParameters.u8t1                      = 15;
        sIEC104Config.sServerSet.sServerConParameters.u8t2                      = 10;
        sIEC104Config.sServerSet.sServerConParameters.u16t3                     = 20;

		sIEC104Config.sServerSet.sServerConParameters.u16EventBufferSize            =   50;
        sIEC104Config.sServerSet.sServerConParameters.u32ClockSyncPeriod            =   0;
        
        sIEC104Config.sServerSet.u16LongPulseTime           =   20000;
        sIEC104Config.sServerSet.u16ShortPulseTime          =   5000;
		        
        sIEC104Config.sServerSet.u8TotalNumberofStations    =   1;
		sIEC104Config.sServerSet.au16CommonAddress[0]   =   1;
        sIEC104Config.sServerSet.au16CommonAddress[1]   =   0;
        sIEC104Config.sServerSet.au16CommonAddress[2]   =   0;
        sIEC104Config.sServerSet.au16CommonAddress[3]   =   0;
        sIEC104Config.sServerSet.au16CommonAddress[4]   =   0;
        
        sIEC104Config.sServerSet.sServerConParameters.bGenerateACTTERMrespond   =   TRUE;
        sIEC104Config.sServerSet.bEnableDoubleTransmission = FALSE;
        
        sIEC104Config.sServerSet.bEnablefileftransfer   = FALSE;
        strcpy((char*)sIEC104Config.sServerSet.ai8FileTransferDirPath, (char*)"\\FileTransferServer");
        sIEC104Config.sServerSet.u16MaxFilesInDirectory     =   10;
        
        sIEC104Config.sServerSet.sServerConParameters.bEnableRedundancy =   FALSE;
        strcpy((char*)sIEC104Config.sServerSet.sServerConParameters.ai8RedundSourceIPAddress,"127.0.0.1");
        strcpy((char*)sIEC104Config.sServerSet.sServerConParameters.ai8RedundRemoteIPAddress,"0.0.0.0");
        sIEC104Config.sServerSet.sServerConParameters.u16RedundPortNumber               =   2400;

        sIEC104Config.sServerSet.bTransmitSpontMeasuredValue = TRUE;
        sIEC104Config.sServerSet.bTransmitInterrogationMeasuredValue =TRUE;
        sIEC104Config.sServerSet.bTransmitBackScanMeasuredValue = TRUE;
		sIEC104Config.sServerSet.eCOTsize = COT_TWO_BYTE;
		sIEC104Config.sServerSet.bSequencebitSet = FALSE;
		

#ifdef VIEW_TRAFFIC
        sIEC104Config.sServerSet.sDebug.u32DebugOptions     =   (DEBUG_OPTION_RX | DEBUG_OPTION_TX);
#else
		sIEC104Config.sServerSet.sDebug.u32DebugOptions     = 0;
#endif

        
		sIEC104Config.sServerSet.benabaleUTCtime =  FALSE;
        sIEC104Config.sServerSet.u8InitialdatabaseQualityFlag   =   GD;     
        
		sIEC104Config.sServerSet.bServerInitiateTCPconnection = FALSE;

        sIEC104Config.sServerSet.u16NoofObject              =   2;        // Define number of objects

        // Allocate memory for objects
        sIEC104Config.sServerSet.psIEC104Objects = NULL;
        sIEC104Config.sServerSet.psIEC104Objects = (struct sIEC104Object *)calloc(   sIEC104Config.sServerSet.u16NoofObject, sizeof(struct sIEC104Object));
        if(sIEC104Config.sServerSet.psIEC104Objects == NULL)
        {
            printf("\r\n Error: Not enough memory to alloc objects");
            break;
        }

        // Initialise objects
        //First object detail
		
        strncpy((char*)sIEC104Config.sServerSet.psIEC104Objects[0].ai8Name,"M_ME_TF_1 100-109",APP_OBJNAMESIZE);
        sIEC104Config.sServerSet.psIEC104Objects[0].eTypeID     =  M_ME_TF_1;
        sIEC104Config.sServerSet.psIEC104Objects[0].u32IOA          = 100;
        sIEC104Config.sServerSet.psIEC104Objects[0].u16Range        = 10;
        sIEC104Config.sServerSet.psIEC104Objects[0].eIntroCOT       = INRO6;
        sIEC104Config.sServerSet.psIEC104Objects[0].eControlModel   =   STATUS_ONLY;
        sIEC104Config.sServerSet.psIEC104Objects[0].u32SBOTimeOut   =   0;
        sIEC104Config.sServerSet.psIEC104Objects[0].u16CommonAddress    =   1;

        //Second object detail
        strncpy((char*)sIEC104Config.sServerSet.psIEC104Objects[1].ai8Name,"C_SE_TC_1",APP_OBJNAMESIZE);
        sIEC104Config.sServerSet.psIEC104Objects[1].eTypeID     =  C_SE_TC_1;
        sIEC104Config.sServerSet.psIEC104Objects[1].u32IOA          = 100;
        sIEC104Config.sServerSet.psIEC104Objects[1].eIntroCOT       = NOTUSED;
        sIEC104Config.sServerSet.psIEC104Objects[1].u16Range        = 10;
        sIEC104Config.sServerSet.psIEC104Objects[1].eControlModel  = DIRECT_OPERATE;
        sIEC104Config.sServerSet.psIEC104Objects[1].u32SBOTimeOut   = 0;
        sIEC104Config.sServerSet.psIEC104Objects[1].u16CommonAddress    =   1;

        // Load configuration
        i16ErrorCode = IEC104LoadConfiguration(myServer, &sIEC104Config, &tErrorValue);
        if(i16ErrorCode != EC_NONE)
        {
            printf("\r\n IEC 60870-5-104 Library API Function - IEC104LoadConfiguration() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
            break;
        }

        // Start server
        i16ErrorCode = IEC104Start(myServer, &tErrorValue);  
        if(i16ErrorCode != EC_NONE)
        {
            printf("\r\n IEC 60870-5-104 Library API Function - IEC104Start() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
            break;
        }

		Sleep(2000);

        printf("\r\n Enter CTRL-X to Exit");
        printf("\r\n");

#ifdef SIMULATE_UPDATE
        // Update Parameters
        uiCount    =   1;
        psDAID     = (struct sIEC104DataAttributeID *)  calloc(uiCount,sizeof(struct sIEC104DataAttributeID));
        psNewValue  = (struct sIEC104DataAttributeData *)  calloc(uiCount,sizeof(struct sIEC104DataAttributeData));


        psDAID[0].u16CommonAddress                     =  1;
        psDAID[0].eTypeID                              =  M_ME_TF_1;
        psDAID[0].u32IOA                               =   100L;
        psDAID[0].pvUserData                           =   NULL;
        psNewValue[0].tQuality                         =   GD;

        psNewValue[0].pvData                           =   &f32data;
        psNewValue[0].eDataType                        =   FLOAT32_DATA;
        psNewValue[0].eDataSize                        =   FLOAT32_SIZE;

#endif



    // Loop
    while(TRUE)
    {


        if(_kbhit())      
        {
          u16Char = _getch() & 0x00FF;
          if(u16Char == 24)
          {
            break;
          }
        }
        else
        {


#ifdef SIMULATE_UPDATE

            time(&now);
            timeinfo = localtime(&now);
            timeinfo->tm_year += 1900;

            //current date
            psNewValue->sTimeStamp.u8Day            =   (Unsigned8)timeinfo->tm_mday;
            psNewValue->sTimeStamp.u8Month          =   (Unsigned8)(timeinfo->tm_mon + 1);
            psNewValue->sTimeStamp.u16Year          =   timeinfo->tm_year;

            // current time
            psNewValue->sTimeStamp.u8Hour           =   (Unsigned8)timeinfo->tm_hour;
            psNewValue->sTimeStamp.u8Minute         =   (Unsigned8)timeinfo->tm_min;
            psNewValue->sTimeStamp.u8Seconds        =   (Unsigned8)(timeinfo->tm_sec);
            psNewValue->sTimeStamp.u16MilliSeconds  =   0;
            psNewValue->sTimeStamp.u16MicroSeconds  =   0;
            psNewValue->sTimeStamp.i8DSTTime        =   0; //No Day light saving time
            psNewValue->sTimeStamp.u8DayoftheWeek   =   4;
            psNewValue->bTimeInvalid = FALSE;
            
            // Increment the Update value to generate event
            f32data                     += (float)1;

            //printf("\r\n update float value %f",f32data);
            // Update server
            i16ErrorCode = IEC104Update(myServer,TRUE,psDAID,psNewValue,uiCount,&tErrorValue);  //Update myServer
            if(i16ErrorCode != EC_NONE)
            {
                printf("\r\n IEC 60870-5-104 Library API Function - IEC104Update() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
				
			}
#endif



        }

// update time interval

        Sleep(2000);


    }

#ifdef SIMULATE_UPDATE
        free(psDAID);
        free(psNewValue);
#endif

        // Stop server
        i16ErrorCode = IEC104Stop(myServer, &tErrorValue);  
        if(i16ErrorCode != EC_NONE)
        {
            printf("\r\n IEC 60870-5-104 Library API Function - IEC104Stop() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
            break;
        }


   }while(FALSE);
  

   printf("\r\n Press Enter to free IEC 104 Server object");

   while(TRUE)
   {
    if(_kbhit())
		break;
   }

   // Free server
   i16ErrorCode = IEC104Free(myServer, &tErrorValue);  
   if(i16ErrorCode != EC_NONE)
   {
        printf("\r\n IEC 60870-5-104 Library API Function - IEC104Free() failed: %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
   }    
   
   return(0);

}
