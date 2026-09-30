/******************************************************************************
*
* (c) 2021 by FreyrSCADA Embedded Solution Pvt Ltd
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
/*! \file       simpleIEC104client-autogendata.c
 *  \brief      linux C Source code file, IEC 60870-5-104 Client library test program - Auto Generation IEC104 Data
 *
 *  \par        FreyrSCADA Embedded Solution Pvt Ltd
 *              Email   : support@freyrscada.com
 */
/*****************************************************************************/

/******************************************************************************
* Includes
******************************************************************************/
#include <time.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include <unistd.h>
#include <sys/time.h>
#include <termios.h>
#include <fcntl.h>
#include <terminalinput.h>



#include "tgttypes.h"
#include "iec104api.h"


   IEC104Object                        myClient            = NULL;         // IEC 60870-5-104 Client object
   Boolean viewtraffic =	FALSE;



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


    printf("\r\n Server IP %s",psPrintID->ai8IPAddress);
    printf("\r\n Server Port %u",psPrintID->u16PortNumber);
    printf("\r\n Server CA %u",psPrintID->u16CommonAddress);
    printf("\r\n Data Attribute ID is  %u IOA %u ",psPrintID->eTypeID, psPrintID->u32IOA);
    printf("\r\n Datatype->%d Datasize->%d  ",psData->eDataType, psData->eDataSize );

    if((psPrintID->eTypeID == M_EP_TD_1) || (psPrintID->eTypeID == M_EP_TE_1) ||
        (psPrintID->eTypeID == M_EP_TF_1))
    {
        printf("\r\n Elapsed time %u",psData->u16ElapsedTime);
    }

    if(psData->tQuality != GD)
    {
        /* Now for the Status */
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

        if((psData->tQuality & OV) == OV)
        {
            printf(" IEC_OV_FLAG");
        }

        if((psData->tQuality & EI) == EI)
        {
            printf(" IEC_EI_FLAG");
        }

        if((psData->tQuality & TR) == TR)
        {
            printf(" IEC_TR_FLAG");
        }

        if((psData->tQuality & CA) == CA)
        {
            printf(" IEC_CA_FLAG");
        }

        if((psData->tQuality & CR) == CR)
        {
            printf(" IEC_CR_FLAG");
        }

    }


    if(psPrintID->eTypeID == M_EP_TE_1)
    {
        memcpy(&u8data,psData->pvData,sizeof(Unsigned8));

        if((u8data & GS) == GS)
        {
            printf(" General start of operation");
        }

        if((u8data & SL1) == SL1)
        {
            printf(" Start of operation phase L1");
        }

        if((u8data & SL2) == SL2)
        {
            printf(" Start of operation phase L2");
        }

        if((u8data & SL3) == SL3)
        {
            printf(" Start of operation phase L3");
        }

        if((u8data & SIE) == SIE)
        {
            printf(" Start of operation IE");
        }

        if((u8data & SRD) == SRD)
        {
            printf(" Start of operation in reverse direction");
        }
    }
    else if (psPrintID->eTypeID == M_EP_TF_1)
    {

        memcpy(&u8data,psData->pvData,sizeof(Unsigned8));

        if((u8data & GC) == GC)
        {
            printf(" General command to output circuit ");
        }

        if((u8data &  CL1) ==  CL1)
        {
            printf(" Command to output circuit phase L1");
        }

        if((u8data &  CL2) ==  CL2)
        {
            printf(" Command to output circuit phase L2");
        }

        if((u8data &  CL3) ==  CL3)
        {
            printf(" Command to output circuit phase L3");
        }



    }
    else
    {


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
                printf(" Data : %f",f32data);
                break;

            default:
                break;
        }

    }

    if( psData->sTimeStamp.u16Year != 0 )
    {
        printf( "\r\n Date : %u-%u-%u  DOW -%u",psData->sTimeStamp.u8Day,psData->sTimeStamp.u8Month, psData->sTimeStamp.u16Year,psData->sTimeStamp.u8DayoftheWeek);

        printf( "\r\n Time : %u:%02u:%02u:%04u:%04u", psData->sTimeStamp.u8Hour, psData->sTimeStamp.u8Minute, psData->sTimeStamp.u8Seconds, psData->sTimeStamp.u16MilliSeconds, psData->sTimeStamp.u16MicroSeconds );
    }

    if(psData->bTimeInvalid)
       printf(" Time Invalid");
    else
       printf(" Time Valid");

    if(psData->eTimeQuality == TIME_ASSUMED)
    {
        printf(" \t Time Assumed");
    }
    else
    {
       printf(" \t Time Reported");
    }
}



/******************************************************************************
* Update callback
******************************************************************************/
Integer16 cbUpdate(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID * psOperateID, struct sIEC104DataAttributeData * psOperateValue, struct sIEC104UpdateParameters * psOperateParams, tErrorValue * ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;

    printf("\n\r\n cbUpdate called");
	printf("\r\n Client ID : %u", u16ObjectId);
     vPrintDataInformation(psOperateID, psOperateValue);
     printf("\r\n COT: %u",psOperateParams->eCause);

	 printf("\r\n");
	 
	 printf("\r\n Enter CTRL-X to Exit \t s - Send command called \t e - enable view traffic \t d - disable view traffic");
     printf("\r\n");

    return i16ErrorCode;
}

/******************************************************************************
* client status callback
******************************************************************************/
Integer16 cbClientstatus(Unsigned16 u16ObjectId, struct sIEC104DataAttributeID *ptDataID, enum eStatus *peSat, tErrorValue *ptErrorValue)
{
     Integer16 i16ErrorCode = EC_NONE;

     do
     {
         printf("\n\r\n cbClientstatus called");
		 printf("\r\n Client ID : %u", u16ObjectId);
         printf("\r\n Server IP Address %s ", ptDataID->ai8IPAddress);
         printf("\r\n Server Port number %u", ptDataID->u16PortNumber);
         printf("\r\n Server CA %u", ptDataID->u16CommonAddress);

         if(*peSat  ==  NOT_CONNECTED)
         {
             printf("\r\n Not Connected");
         }
         else
         {
             printf("\r\n Connected");
         }


     }while(FALSE);

	 printf("\r\n");
	 
	 printf("\r\n Enter CTRL-X to Exit \t s - Send command called \t e - enable view traffic \t d - disable view traffic");
     printf("\r\n");


     return i16ErrorCode;
}

/******************************************************************************
* Debug callback
******************************************************************************/
Integer16 cbDebug(Unsigned16 u16ObjectId, struct sIEC104DebugData * ptDebugData, tErrorValue *ptErrorValue)
{
    Integer16 i16ErrorCode = EC_NONE;
    Unsigned8 u8nav                = 0;


	if(viewtraffic == TRUE)
	{

   // printf("\n\r\n cbDebug() called");


    printf("\r\n %u:%u:%u Client ID %u", ptDebugData->sTimeStamp.u8Hour, ptDebugData->sTimeStamp.u8Minute, ptDebugData->sTimeStamp.u8Seconds,u16ObjectId);

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

	printf("\r\n");

	}


    return i16ErrorCode;
}

void sendcommand()
{

	Integer16                    i16ErrorCode        = EC_NONE;     // API Function return error paramter
    tErrorValue                             tErrorValue       = EV_NONE;    // API Function return additional error parameter

	Float32 f32data                                         = 1;            // Initial command data

	Unsigned32 ioa	=	0;

	struct sIEC104DataAttributeID sWriteDAID;                               // Command data identification parameters
    struct sIEC104DataAttributeData sWriteValue;                            // Command data value parameters
    struct sIEC104CommandParameters sCommandParams          =   {0};        // Command addional input parameters

	struct tm * timeinfo;                                                   // command data- date and time structute
    time_t now;                                                             // to get current data and time


	set_tty_cooked(); //Unix setup to reverse tty_set_raw()
   	printf("\r\n");

		printf ("Enter Information object address (IOA): ");
		scanf("%u", &ioa);
		printf("\r\n");

		printf ("Enter update float value: ");
		scanf("%f", &f32data);
		printf("\r\n");


                            time(&now);
                            timeinfo = localtime(&now);
                            timeinfo->tm_year += 1900;

                            //current date
                            sWriteValue.sTimeStamp.u8Day            =   (Unsigned8)timeinfo->tm_mday;
                            sWriteValue.sTimeStamp.u8Month          =   (Unsigned8)(timeinfo->tm_mon + 1);
                            sWriteValue.sTimeStamp.u16Year          =   timeinfo->tm_year;

                            //time
                            sWriteValue.sTimeStamp.u8Hour           =   (Unsigned8)timeinfo->tm_hour;
                            sWriteValue.sTimeStamp.u8Minute         =   (Unsigned8)timeinfo->tm_min;
                            sWriteValue.sTimeStamp.u8Seconds        =   (Unsigned8)(timeinfo->tm_sec);
                            sWriteValue.sTimeStamp.u16MilliSeconds  =   0;
                            sWriteValue.sTimeStamp.u16MicroSeconds  =   0;
                            sWriteValue.sTimeStamp.i8DSTTime        =   0; //No Day light saving time
                            sWriteValue.sTimeStamp.u8DayoftheWeek   =   4;

                            strcpy((char*)sWriteDAID.ai8IPAddress,"127.0.0.1");
                            sWriteDAID.u16PortNumber                =   2404;
                            sWriteDAID.eTypeID      =   C_SE_TC_1;
                            sWriteDAID.u32IOA       =   ioa;
                            sWriteDAID.u16CommonAddress = 1;
                            sWriteValue.eDataType   =   FLOAT32_DATA;
                            sWriteValue.eDataSize   =   FLOAT32_SIZE;
                            sWriteValue.tQuality    =   GD;
                            sWriteValue.pvData      =   &f32data;

                            //Send Operate Command
                            i16ErrorCode = IEC104Operate(myClient, &sWriteDAID, &sWriteValue, &sCommandParams,  &tErrorValue);  //Stop myServer
                            if(i16ErrorCode != EC_NONE)
                            {
                                printf("\r\n IEC 60870-5-104 Library API Function - IEC104Operate C_SE_TC_1 command operate failed:  %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));

                            }
							else
							{
								 printf("\r\n Command Send success");
							}





		set_tty_raw() ;  // Unix setup to read a character at a time.

		printf("\r\n");
		
		printf("\r\n Enter CTRL-X to Exit \t s - Send command called \t e - enable view traffic \t d - disable view traffic");
        printf("\r\n");

}


/******************************************************************************
* main()
******************************************************************************/
int main (void)
{

    Integer16							i16ErrorCode          = EC_NONE;      // API Function return error parameter
    tErrorValue                         tErrorValue         = EV_NONE;      // API Function return additional error paramter
    struct sIEC104Parameters            sParameters         = {0};          // IEC104 Client object callback paramters
    Unsigned16                   u16Char                    =   0;          // Get control+x key to stop send command
    struct sIEC104ConfigurationParameters  sIEC104Config;                   // Client protocol , point configuration parameters
    	Boolean bexit							=	FALSE;




   do
   {
       printf("\r\n \t\t**** FreyrSCADA - IEC 60870-5-104 Client Library Test ****");
       // Check library version against the library header file
        if(strcmp((char*)IEC104GetLibraryVersion(), IEC104_VERSION) != 0)
        {
            printf("\r\n Error: Version Number Mismatch");
            printf("\r\n Library Version is  : %s", IEC104GetLibraryVersion());
            printf("\r\n The Version used is : %s", IEC104_VERSION);
           	printf("\r\n");
			getchar();
			return(0);
        }

        printf("\r\n Library Version is : %s", IEC104GetLibraryVersion());
        printf("\r\n Library Build on   : %s", IEC104GetLibraryBuildTime());

        // Initialize IEC 60870-5-104 Client object parameters
        sParameters.eAppFlag          = APP_CLIENT;             // This is a IEC104 CLIENT
        sParameters.u32Options        = 0;
        sParameters.ptReadCallback    = NULL;                   // Read Callback
        sParameters.ptWriteCallback   = NULL;                   // Write Callback
        sParameters.ptUpdateCallback  = cbUpdate;               // Update Callback
        sParameters.ptSelectCallback  = NULL;                   // Select Callback
        sParameters.ptOperateCallback = NULL;                   // Operate Callback
        sParameters.ptCancelCallback  = NULL;                   // Cancel Callback
        sParameters.ptFreezeCallback  = NULL;                   // Freeze Callback
        sParameters.ptDebugCallback   = cbDebug;                // Debug Callback
        sParameters.ptPulseEndActTermCallback = NULL;           // pulse end callback
        sParameters.ptParameterActCallback = NULL;              // Parameter activation callback
        sParameters.ptServerStatusCallback =  NULL;             // server status callback
        sParameters.ptDirectoryCallback    = NULL;              // Directory Callback
        sParameters.ptClientStatusCallback   = cbClientstatus;  // client connection status Callback
		sParameters.u16ObjectId = 1;  //Client ID which used in callbacks to identify the iec 104 client object



        // Create a Client object
        myClient = IEC104Create(&sParameters, &i16ErrorCode, &tErrorValue);
        if(myClient == NULL)
        {
            printf("\r\n IEC 60870-5-104 Library API Function - IEC104Create() failed:  %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
            break;
        }

        // Client load configuration - communication and protocol configuration parameters
		strcpy((char*)sIEC104Config.sClientSet.ai8SourceIPAddress,"0.0.0.0");	/*!< client own IP Address , use 0.0.0.0 / network ip address for binding socket*/   
		
        sIEC104Config.sClientSet.benabaleUTCtime    =   FALSE;
        sIEC104Config.sClientSet.sDebug.u32DebugOptions =    ( DEBUG_OPTION_TX | DEBUG_OPTION_RX );
        sIEC104Config.sClientSet.u16TotalNumberofConnection =   1;

        sIEC104Config.sClientSet.psClientConParameters  = NULL;
        sIEC104Config.sClientSet.psClientConParameters  =   (struct sClientConnectionParameters*)malloc (sIEC104Config.sClientSet.u16TotalNumberofConnection    * sizeof(struct sClientConnectionParameters));
        if(sIEC104Config.sClientSet.psClientConParameters   == NULL)
        {
            printf("\r\n Error: Not enough memory to alloc objects");
            break;
        }
        //client 1 configuration Starts
		// check server configuration - TCP/IP Address
		strcpy((char*)sIEC104Config.sClientSet.psClientConParameters[0].ai8DestinationIPAddress,"127.0.0.1");  // iec 104 server ip address
        sIEC104Config.sClientSet.psClientConParameters[0].u16PortNumber             =   2404;  // iec 104 server port number


		sIEC104Config.sClientSet.psClientConParameters[0].i16k                      =   12;
        sIEC104Config.sClientSet.psClientConParameters[0].i16w                      =   8;
        sIEC104Config.sClientSet.psClientConParameters[0].u8t0                      = 30;
        sIEC104Config.sClientSet.psClientConParameters[0].u8t1                      = 15;
        sIEC104Config.sClientSet.psClientConParameters[0].u8t2                      = 10;
        sIEC104Config.sClientSet.psClientConParameters[0].u16t3                     = 20;

        sIEC104Config.sClientSet.psClientConParameters[0].eState =  DATA_MODE;
        sIEC104Config.sClientSet.psClientConParameters[0].u8TotalNumberofStations           =   1;
        sIEC104Config.sClientSet.psClientConParameters[0].au16CommonAddress[0]          =   1;
        sIEC104Config.sClientSet.psClientConParameters[0].au16CommonAddress[1]          =   0;
        sIEC104Config.sClientSet.psClientConParameters[0].au16CommonAddress[2]          =   0;
        sIEC104Config.sClientSet.psClientConParameters[0].au16CommonAddress[3]          =   0;
        sIEC104Config.sClientSet.psClientConParameters[0].au16CommonAddress[4]          =   0;
        sIEC104Config.sClientSet.psClientConParameters[0].u8OriginatorAddress           =   0;


        sIEC104Config.sClientSet.psClientConParameters[0].u32GeneralInterrogationInterval   =   0;    /*!< in sec if 0 , gi will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group1InterrogationInterval    =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group2InterrogationInterval    =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group3InterrogationInterval    =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group4InterrogationInterval    =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group5InterrogationInterval    =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group6InterrogationInterval    =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group7InterrogationInterval    =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group8InterrogationInterval    =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group9InterrogationInterval    =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group10InterrogationInterval   =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group11InterrogationInterval   =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group12InterrogationInterval   =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group13InterrogationInterval   =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group14InterrogationInterval   =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group15InterrogationInterval   =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group16InterrogationInterval   =   0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32CounterInterrogationInterval   =   0;    /*!< in sec if 0 , ci will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group1CounterInterrogationInterval =   0;    /*!< in sec if 0 , group 1 counter interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group2CounterInterrogationInterval =   0;    /*!< in sec if 0 , group 1 counter interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group3CounterInterrogationInterval =   0;    /*!< in sec if 0 , group 1 counter interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32Group4CounterInterrogationInterval =   0;    /*!< in sec if 0 , group 1 counter interrogation will not send in particular interval*/
        sIEC104Config.sClientSet.psClientConParameters[0].u32ClockSyncInterval  =   0;              /*!< in sec if 0 , clock sync, will not send in particular interval */

        sIEC104Config.sClientSet.psClientConParameters[0].u32CommandTimeout =   10000;
        sIEC104Config.sClientSet.psClientConParameters[0].u32FileTransferTimeout    =   50000;
        sIEC104Config.sClientSet.psClientConParameters[0].bCommandResponseActtermUsed   =   TRUE;


        sIEC104Config.sClientSet.psClientConParameters[0].bEnablefileftransfer = FALSE;
        strcpy((char*)sIEC104Config.sClientSet.psClientConParameters[0].ai8FileTransferDirPath,"C:\\");
        sIEC104Config.sClientSet.psClientConParameters[0].bUpdateCallbackCheckTimestamp = FALSE;
		sIEC104Config.sClientSet.psClientConParameters[0].eCOTsize = COT_TWO_BYTE;

		sIEC104Config.sClientSet.bAutoGenIEC104DataObjects = TRUE;

         // Define number of objects
        sIEC104Config.sClientSet.psClientConParameters[0].u16NoofObject             =   0;

        // Allocate memory for objects
        sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects = NULL;

        // client 1 configuration ends


        // Load configuration
        i16ErrorCode = IEC104LoadConfiguration(myClient, &sIEC104Config, &tErrorValue);
        if(i16ErrorCode != EC_NONE)
        {
            printf("\r\n IEC 60870-5-104 Library API Function - IEC104LoadConfiguration() failed:   %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
            break;
        }

        // Start Client
        i16ErrorCode = IEC104Start(myClient, &tErrorValue);
        if(i16ErrorCode != EC_NONE)
        {
            printf("\r\n IEC 60870-5-104 Library API Function - IEC104Start() failed:  %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
            break;
        }


		fflush(stdout);
        set_tty_raw();         /* set up character-at-a-time */


        printf("\r\n Enter CTRL-X to Exit \t s - Send command called \t e - enable view traffic \t d - disable view traffic");
        printf("\r\n");

        sleep(5);



    // Loop
    while(bexit ==	FALSE)
    {


          u16Char =kb_getc();                                  /* char typed by user? */
		  if(u16Char == 0)
          {
            continue;
          }
		  else
		  {
				switch(u16Char)
				{
					case 0x03: //CTRL + C
					case 0x18: //CTRL + X
						set_tty_cooked();                           /* restore normal TTY mode */
                        bexit = TRUE;
                        break;

					case 0x73:  // s - send command called
						printf("\r\n ***********send command called ***********\r\n");
						sendcommand();
						break;

					case 0x65:  // e - enable view traffic
						printf("\r\n ***********view traffic enabled ***********\r\n");
						viewtraffic =TRUE;
						break;

					case 0x64:  // d - disable view traffic
					printf("\r\n ***********view traffic disabled ***********\r\n");
						viewtraffic =FALSE;
						break;

					default:
						break;
				}
		  }


		// update time interval
        usleep(1);

    }



        // Stop Client
        i16ErrorCode = IEC104Stop(myClient, &tErrorValue);
        if(i16ErrorCode != EC_NONE)
        {
            printf("\r\n IEC 60870-5-104 Library API Function - IEC104Stop() failed:  %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
            break;
        }


   }while(FALSE);

   printf("\r\n Enter any key to free");
   printf("\r\n");
   getchar();

   // Free Client
   i16ErrorCode = IEC104Free(myClient, &tErrorValue);
   if(i16ErrorCode != EC_NONE)
   {
        printf("\r\n IEC 60870-5-104 Library API Function - IEC104Free() failed:  %d - %s, %d - %s ", i16ErrorCode, errorcodestring(i16ErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
   }

   printf("\r\n Bye \r\n");


   return(0);

}
