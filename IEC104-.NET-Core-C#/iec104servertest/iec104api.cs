/*****************************************************************************/
/*! \file        IEC104API.cs
 *  \brief       IEC104 API Header file
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

using System.Runtime.InteropServices;

public partial class iec104api
{



    /*! \brief          IEC870-5-104 API Version Number */
    public const string IEC104_VERSION = "21.06.022";


    /*! \brief             Get IEC 104 Library Version
     *  \par               Function used to get the version of the IEC 104 Library
     *
     *  \return            version number of library as a string of char with format A.BB.CCC
     *  Example Usage:
     *  \code
     *      printf("Version number: %s", IEC104GetLibraryVersion(void));
     *  \endcode
     */

#if Windows
  [DllImport("iec104x64d.dll", EntryPoint = "IEC104GetLibraryVersion", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif



    public static extern System.IntPtr IEC104GetLibraryVersion();

    /*! \brief          Get Library Build Time
     *  \par            Function used to get the build time of the IEC 104 Library
     *
     *  \return         Build time of the library as a string of char. Format "Mmm dd yyyy hh:mm:ss"
     *        
     *  Example Usage:
     *  \code
     *      printf("Build Time: %s", IEC104GetLibraryBuildTime(void));
     *  \endcode
     */

#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104GetLibraryBuildTime", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif
    public static extern System.IntPtr IEC104GetLibraryBuildTime();

    /*! \brief       Create a client or server object with call-backs for reading, writing and updating data objects
    *
    *  \param[in]      psParameters    IEC 104 Object Parameters
    *  \param[out]     peErrorCode     Pointer to Error Code (if any error occurs)
    *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
    *
    *  \return         Pointer to new IEC 104 object
    *  \return         NULL if an error occured (errorCode will contain an error code)
    *
    *  \code
    *                  // Sample Server Create
    *                  enum eAppErrorCodes         eErrorCode          = APP_ERROR_NONE;
    *                  IEC104Object                myIEC104ObjServer   = NULL;
    *                  struct sIEC104Parameters    sParameters         = {0};
    *                  tAppErrorValue              tErrorValue         = APP_ERRORVALUE_NONE;
    *
    *                  // Setup the required object parameters
    *                  sParameters.eAppFlag            = APP_SERVER;           // IEC 104 Server
    *                  sParameters.u32Options          = APP_OPTION_NONE;      // No Options
    *                  sParameters.ptReadCallback    = cbRead;                 // Read Callback
    *                  sParameters.ptWriteCallback   = cbWrite;                // Write Callback           
    *                  sParameters.ptUpdateCallback  = NULL;                   // Update Callback
    *                  sParameters.ptSelectCallback  = cbSelect;                // Select Callback
    *                  sParameters.ptOperateCallback = cbOperate;              // Operate Callback
    *                  sParameters.ptCancelCallback  = cbCancel;               // Cancel Callback
    *                  sParameters.ptFreezeCallback  = cbFreeze;               // freeze Callback
    *                  sParameters.ptDebugCallback   = cbDebug;                // Debug Callback
    *                  sParameters.ptPulseEndActTermCallback = cbpulseend;     // pulse end callback   
    *                  sParameters.ptParameterActCallback = cbParameterAct;    // parameter act Callback
    *                  sParameters.ptServerStatusCallback =  cbServerStatus;   // server connecction Callback
    *
    *                  //Create a server object
    *                  myIEC104ObjServer = IEC104Create(&sParameters, &eErrorCode, &tErrorValue);
    *                  if(myIEC104Obj == NULL)
    *                  {
    *                      printf("Error in Server Creation : %i %i", eErrorCode, tErrorValue);
    *                  }
    *  \endcode
    *   
    *  \code
    *                  // Sample Client Create
    *                  enum eAppErrorCodes         eErrorCode            = APP_ERROR_NONE;
    *                  IEC104Object                myIEC104ObjClient     = NULL;
    *                  struct sIEC104Parameters    sParameters           = {0};
    *                  tAppErrorValue              tErrorValue           = APP_ERRORVALUE_NONE;
    *
    *                  // Setup the required object parameters   
    *                  sParameters.eAppFlag            = APP_CLIENT;           // IEC 104 Server
    *                  sParameters.u32Options          = APP_OPTION_NONE;      // No Options 
    *                  sParameters.ptReadCallback      = NULL;                 // Read Call-back
    *                  sParameters.ptWriteCallback     = NULL;                 // Write Call-back           
    *                  sParameters.ptUpdateCallback    = cbUpdate;             // Update Call-back
    *                  sParameters.ptSelectCallback    = NULL;                 // Select Call-back
    *                  sParameters.ptOperateCallback   = NULL;                 // Operate Call-back
    *                  sParameters.ptCancelCallback    = NULL;             // Cancel Callback
    *                  sParameters.ptFreezeCallback    = NULL;             // freeze Callback
    *                  sParameters.ptDebugCallback     = cbDebug;              // Debug Callback
    *                  sParameters.ptPulseEndActTermCallback = NULL;     // pulse end callback
    *                  sParameters.ptClientStatusCallback   = cbClientstatus;         // client connection Callback
    *
    *                  //Create a client object
    *                  myIEC104ObjClient = IEC104Create(&sParameters, &eErrorCode, &tErrorValue);
    *                  if(myIEC104Obj == NULL)
    *                  {
    *                      printf("Error in Client Creation : %i %i", eErrorCode, tErrorValue);
    *                  }
    *  \endcode
    */

#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104Create", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif

    public static extern System.IntPtr IEC104Create(ref iec104types.sIEC104Parameters psParameters, ref short peErrorCode, ref short ptErrorValue);


    /*!\brief          Load the configuration to be used by IEC 104 object.
   
      \param[in]      myIEC104Obj     IEC 104 object 
      \param[in]      psIEC104Config  Pointer to IEC 104 Configuration parameters 
      \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
   
      \return         APP_ERROR_NONE on success
      \return         otherwise error code
   
      \code
      Sample Server Load Configuration
   
        enum eAppErrorCodes                     eErrorCode      = APP_ERROR_NONE;
        tAppErrorValue                          tErrorValue     = APP_ERRORVALUE_NONE;
        struct sIEC104ConfigurationParameters   sIEC104Config   = {0};
        
        sIEC104Config.sServerSet.u16MaxNumberofConnection   =   1;
        sIEC104Config.sServerSet.psServerConParameters = NULL;
        sIEC104Config.sServerSet.psServerConParameters = calloc(   sIEC104Config.sServerSet.u16MaxNumberofConnection, sizeof(struct sServerConnectionParameters));
        if( sIEC104Config.sServerSet.psServerConParameters == NULL)
        {
            printf("\r\nError: Not enough memory to alloc objects");
            break;
        }
        sIEC104Config.sServerSet.psServerConParameters[0].i16k                      =   12;
        sIEC104Config.sServerSet.psServerConParameters[0].i16w                      =   8;
        sIEC104Config.sServerSet.psServerConParameters[0].u8t0                      = 30;
        sIEC104Config.sServerSet.psServerConParameters[0].u8t1                      = 15;
        sIEC104Config.sServerSet.psServerConParameters[0].u8t2                      = 10;
        sIEC104Config.sServerSet.psServerConParameters[0].u16t3                     = 20;
        sIEC104Config.sServerSet.psServerConParameters[0].u16EventBufferSize            =   50;
        sIEC104Config.sServerSet.psServerConParameters[0].u32ClockSyncPeriod            =   0;
        sIEC104Config.sServerSet.psServerConParameters[0].bGenerateACTTERMrespond   =   TRUE;
        strcpy((char*)sIEC104Config.sServerSet.psServerConParameters[0].ai8SourceIPAddress,"127.0.0.1");
        strcpy((char*)sIEC104Config.sServerSet.psServerConParameters[0].ai8RemoteIPAddress,"0.0.0.0");
        sIEC104Config.sServerSet.psServerConParameters[0].u16PortNumber             =   2404;
        sIEC104Config.sServerSet.psServerConParameters[0].bEnableRedundancy =   FALSE;
        strcpy((char*)sIEC104Config.sServerSet.psServerConParameters[0].ai8RedundSourceIPAddress,"127.0.0.1");
        strcpy((char*)sIEC104Config.sServerSet.psServerConParameters[0].ai8RedundRemoteIPAddress,"0.0.0.0");
        sIEC104Config.sServerSet.psServerConParameters[0].u16RedundPortNumber               =   2400;
       
       
        //sIEC104Config.sServerSet.sDebug.u32DebugOptions     = 0;
        sIEC104Config.sServerSet.sDebug.u32DebugOptions     =   ((DEBUG_OPTION_ERROR | DEBUG_OPTION_TX) | DEBUG_OPTION_RX);
        sIEC104Config.sServerSet.bEnablefileftransfer   = FALSE;
        strcpy((char*)sIEC104Config.sServerSet.ai8FileTransferDirPath, (char*)"C:\\kr\\FileTransferServer");
        sIEC104Config.sServerSet.u16MaxFilesInDirectory     =   10;
        sIEC104Config.sServerSet.bEnableDoubleTransmission = FALSE;
        sIEC104Config.sServerSet.u8TotalNumberofStations    =   1;
        sIEC104Config.sServerSet.au16CommonAddress[0]   =   1;
        sIEC104Config.sServerSet.au16CommonAddress[1]   =   0;
        sIEC104Config.sServerSet.au16CommonAddress[2]   =   0;
        sIEC104Config.sServerSet.au16CommonAddress[3]   =   0;
        sIEC104Config.sServerSet.au16CommonAddress[4]   =   0;
        sIEC104Config.sServerSet.benabaleUTCtime =  FALSE;
       
        sIEC104Config.sServerSet.bTransmitSpontMeasuredValue = TRUE;
        sIEC104Config.sServerSet.bTranmitInterrogationMeasuredValue =TRUE;
        sIEC104Config.sServerSet.bTransmitBackScanMeasuredValue = TRUE;
       
        sIEC104Config.sServerSet.u16ShortPulseTime          =   5000;
        sIEC104Config.sServerSet.u16LongPulseTime           =   20000;
       
        sIEC104Config.sServerSet.u16NoofObject              =   2;        // Define number of objects
       
        // Allocate memory for objects
        sIEC104Config.sServerSet.psIEC104Objects = calloc(   sIEC104Config.sServerSet.u16NoofObject, sizeof(struct sIEC104Object));
        if(   sIEC104Config.sServerSet.psIEC104Objects == NULL)
        {
            printf("\r\nError: Not enough memory to alloc objects");
            break;
        }
       
        // Init objects
        //first object detail
       
       
        strncpy((char*)   sIEC104Config.sServerSet.psIEC104Objects[0].ai8Name,"M_ME_TF_1 100-109",APP_OBJNAMESIZE);
        sIEC104Config.sServerSet.psIEC104Objects[0].eTypeID     =  M_ME_TF_1;
        sIEC104Config.sServerSet.psIEC104Objects[0].u32IOA          = 100;
        sIEC104Config.sServerSet.psIEC104Objects[0].u16Range        = 10;
        sIEC104Config.sServerSet.psIEC104Objects[0].eIntroCOT       = INRO6;
        sIEC104Config.sServerSet.psIEC104Objects[0].eControlModel   =   STATUS_ONLY;
        sIEC104Config.sServerSet.psIEC104Objects[0].u32SBOTimeOut   =   0;
        sIEC104Config.sServerSet.psIEC104Objects[0].u16CommonAddress    =   1;
       
       
        strncpy((char*)sIEC104Config.sServerSet.psIEC104Objects[1].ai8Name,"C_SE_TC_1",APP_OBJNAMESIZE);
        sIEC104Config.sServerSet.psIEC104Objects[1].eTypeID     =  C_SE_TC_1;
        sIEC104Config.sServerSet.psIEC104Objects[1].u32IOA          = 100;
        sIEC104Config.sServerSet.psIEC104Objects[1].eIntroCOT       = NOTUSED;
        sIEC104Config.sServerSet.psIEC104Objects[1].u16Range        = 10;
        sIEC104Config.sServerSet.psIEC104Objects[1].eControlModel  = DIRECT_OPERATE;
        sIEC104Config.sServerSet.psIEC104Objects[1].u32SBOTimeOut   = 0;
        sIEC104Config.sServerSet.psIEC104Objects[1].u16CommonAddress    =   1;
       
        // Load configuration
        eErrorCode = IEC104LoadConfiguration(myServer, &sIEC104Config, &tErrorValue);
        if(eErrorCode != EC_NONE)
        {
            printf("\r\nError: IEC104LoadConfiguration() failed: %d - %s, %d - %s ", eErrorCode, errorcodestring(eErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
        }
   
   
      \endcode
   
     \code
     // Sample Client Load Configuration
   
            enum eAppErrorCodes                     eErrorCode      = APP_ERROR_NONE;
            tAppErrorValue                          tErrorValue     = APP_ERRORVALUE_NONE;
            struct sIEC104ConfigurationParameters   sIEC104Config   = {0};
   
            sIEC104Config.sClientSet.benabaleUTCtime    =   FALSE;
            //sIEC104Config.sClientSet.sDebug.u32DebugOptions   =    (DEBUG_OPTION_ERROR | DEBUG_OPTION_WARNING) ;
            sIEC104Config.sClientSet.sDebug.u32DebugOptions =    ( DEBUG_OPTION_TX | DEBUG_OPTION_RX);
            sIEC104Config.sClientSet.u16TotalNumberofConnection =   1;
            sIEC104Config.sClientSet.psClientConParameters  =   malloc (sIEC104Config.sClientSet.u16TotalNumberofConnection * sizeof(struct sClientConnectionParameters));
   
            //server 1 config Starts
            sIEC104Config.sClientSet.psClientConParameters[0].eState =  DATA_MODE;
            sIEC104Config.sClientSet.psClientConParameters[0].u8TotalNumberofStations           =   1;
            sIEC104Config.sClientSet.psClientConParameters[0].au16CommonAddress[0]          =   1;
            sIEC104Config.sClientSet.psClientConParameters[0].au16CommonAddress[1]          =   0;
            sIEC104Config.sClientSet.psClientConParameters[0].au16CommonAddress[2]          =   0;
            sIEC104Config.sClientSet.psClientConParameters[0].au16CommonAddress[3]          =   0;
            sIEC104Config.sClientSet.psClientConParameters[0].au16CommonAddress[4]          =   0;
            sIEC104Config.sClientSet.psClientConParameters[0].u8OrginatorAddress            =   0;
            sIEC104Config.sClientSet.psClientConParameters[0].i16k                      =   12;
            sIEC104Config.sClientSet.psClientConParameters[0].i16w                      =   8;
            sIEC104Config.sClientSet.psClientConParameters[0].u8t0                      = 30;
            sIEC104Config.sClientSet.psClientConParameters[0].u8t1                      = 15;
            sIEC104Config.sClientSet.psClientConParameters[0].u8t2                      = 10;
            sIEC104Config.sClientSet.psClientConParameters[0].u16t3                     = 20;
   
            sIEC104Config.sClientSet.psClientConParameters[0].u32GeneralInterrogationInterval   =   0;    // in sec if 0 , gi will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group1InterrogationInterval    =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group2InterrogationInterval    =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group3InterrogationInterval    =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group4InterrogationInterval    =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group5InterrogationInterval    =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group6InterrogationInterval    =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group7InterrogationInterval    =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group8InterrogationInterval    =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group9InterrogationInterval    =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group10InterrogationInterval   =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group11InterrogationInterval   =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group12InterrogationInterval   =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group13InterrogationInterval   =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group14InterrogationInterval   =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group15InterrogationInterval   =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group16InterrogationInterval   =   0;    // in sec if 0 , group 1 interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32CounterInterrogationInterval   =   0;    // in sec if 0 , ci will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group1CounterInterrogationInterval =   0;    // in sec if 0 , group 1 counter interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group2CounterInterrogationInterval =   0;    // in sec if 0 , group 1 counter interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group3CounterInterrogationInterval =   0;    // in sec if 0 , group 1 counter interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32Group4CounterInterrogationInterval =   0;    // in sec if 0 , group 1 counter interrogation will not send in particular interval
            sIEC104Config.sClientSet.psClientConParameters[0].u32ClockSyncInterval  =   0;              // in sec if 0 , clock sync, will not send in particular interval 
   
            sIEC104Config.sClientSet.psClientConParameters[0].u32CommandTimeout =   10000;
            sIEC104Config.sClientSet.psClientConParameters[0].u32FileTransferTimeout    =   50000;
            sIEC104Config.sClientSet.psClientConParameters[0].bCommandResponseActtermUsed   =   TRUE;
   
   
            strcpy((char*)sIEC104Config.sClientSet.psClientConParameters[0].ai8DestinationIPAddress,"127.0.0.1");
            sIEC104Config.sClientSet.psClientConParameters[0].u16PortNumber             =   2404;
   
   
            sIEC104Config.sClientSet.psClientConParameters[0].bEnablefileftransfer = FALSE;
            strcpy((char*)sIEC104Config.sClientSet.psClientConParameters[0].ai8FileTransferDirPath,"C:\\");
            sIEC104Config.sClientSet.psClientConParameters[0].bUpdateCallbackCheckTimestamp = FALSE;
   
   
            sIEC104Config.sClientSet.psClientConParameters[0].u16NoofObject             =   2;        // Define number of objects
   
            // Allocate memory for objects
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects = calloc(   sIEC104Config.sClientSet.psClientConParameters[0].u16NoofObject, sizeof(struct sIEC104Object));
            if(   sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects == NULL)
            {
                printf("\r\nError: Not enough memory to alloc objects");
                break;
            }
   
            // Init objects
            //first object detail
   
   
            strcpy((char*)sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[0].ai8Name,"100");
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[0].eTypeID        = M_ME_TF_1;
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[0].u32IOA         = 100;
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[0].eIntroCOT      = INRO1;
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[0].u16Range       = 10;
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[0].eControlModel  =  STATUS_ONLY ;
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[0].u32SBOTimeOut  = 0;
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[0].u16CommonAddress   =   1;
   
            strncpy((char*)sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[1].ai8Name,"C_SE_TC_1",APP_OBJNAMESIZE);
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[1].eTypeID        = C_SE_TC_1;
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[1].u32IOA         = 100;
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[1].eIntroCOT      = NOTUSED;
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[1].u16Range       = 10;
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[1].eControlModel  = DIRECT_OPERATE;
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[1].u32SBOTimeOut  = 0;
            sIEC104Config.sClientSet.psClientConParameters[0].psIEC104Objects[1].u16CommonAddress   =   1;
           // server 1 config ends
   
   
            // Load configuration
            eErrorCode = IEC104LoadConfiguration(myClient, &sIEC104Config, &tErrorValue);
            if(eErrorCode != EC_NONE)
            {
                printf("\r\nError: IEC104LoadConfiguration() failed:   %d - %s, %d - %s ", eErrorCode, errorcodestring(eErrorCode),  tErrorValue , errorvaluestring(tErrorValue));
               
            }
   
     \endcode
    */


#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104LoadConfiguration", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif

    public static extern short IEC104LoadConfiguration(System.IntPtr myIEC104Obj, ref iec104types.sIEC104ConfigurationParameters psIEC104Config, ref short ptErrorValue);

    /*! \brief          Free memory used by IEC 104 object.
     *
     *  \param[in]      myIEC104Obj     IEC 104 object to free
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  // Sample Stop function
     *                  enum eAppErrorCodes         eErrorCode      = APP_ERROR_NONE;
     *                  tAppErrorValue              tErrorValue     = APP_ERRORVALUE_NONE;
     *
     *                  //Free IEC 104 Object
     *                  eErrorCode = IEC104Free(myIEC104ObjServer, &tErrorValue);
     *                  if(eErrorCode != APP_ERROR_NONE)
     *                  {
     *                      printf("Free IEC 104 Object has failed: %i %i", eErrorCode, tErrorValue);
     *                  }
     *  \endcode
     */


#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104Free", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif


    public static extern short IEC104Free(System.IntPtr myIEC104Obj, ref short ptErrorValue);

    /*! \brief          Start IEC 104 object communication
    *
    *  \param[in]      myIEC104Obj     IEC 104 object to Start
    *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
    *
    *  \return         APP_ERROR_NONE on success
    *  \return         otherwise error code
    *
    *  \code
    *                  enum eAppErrorCodes     eErrorCode      = APP_ERROR_NONE;
    *                  tAppErrorValue          tErrorValue     = APP_ERRORVALUE_NONE;
    *
    *                  //Start the IEC 104 Server or Client Object based on the object created
    *                  eErrorCode = IEC104Start(myIEC104Object, &tErrorValue);
    *                  if(eErrorCode != APP_ERROR_NONE)
    *                  {
    *                      printf("Start IEC 104 has failed: %i %i", eErrorCode, tErrorValue);
    *                  }
    *  \endcode
    */


#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104Start", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif

    public static extern short IEC104Start(System.IntPtr myIEC104Obj, ref short ptErrorValue);

    /*! \brief          Stop IEC 104 object communication
     *
     *  \param[in]      myIEC104Obj     IEC 104 object to Stop
     *  \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while creating the object)
     *
     *  \return         APP_ERROR_NONE on success
     *  \return         otherwise error code
     *
     *  \code
     *                  // Sample Free function
     *                  enum eAppErrorCodes     eErrorCode      = APP_ERROR_NONE;
     *                  tAppErrorValue          tErrorValue     = APP_ERRORVALUE_NONE;
     *
     *                  //Stop the IEC 104 Object
     *                  eErrorCode = IEC104Stop(myIEC104Obj, &tErrorValue);
     *                  if(eErrorCode != APP_ERROR_NONE)
     *                  {
     *                      printf("Stop IEC 104 has failed: %i %i", eErrorCode, tErrorValue);
     *                  }
     *  \endcode
     */




#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104Stop", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif

    public static extern short IEC104Stop(System.IntPtr myIEC104Obj, ref short ptErrorValue);

    /*!\brief           Update IEC104 data attribute ID to the New Value. 
        \ingroup        Management
    
        \param[in]      myIEC104Obj     IEC104 object to Update
        \param[in]      bGenEvent       Boolean value - to genertate the event, othervise, just update the database value
        \param[in]      psDAID          Pointer to IEC104 Data Attribute ID
        \param[in]      psNewValue      Pointer to IEC104 Data Attribute Data
        \param[in]      u16Count        Number of IEC104 Data attribute ID and Data attribute data to be updated simultaneously
        \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while updating the data point)
    
        \return         EC_NONE on success
        \return         otherwise error code

        Server Example Usage:
        \code
            
            enum eTgtErrorCodes                    eErrorCode       = EC_NONE;
            tErrorValue                         tErrorValue      = EV_NONE;
        
            struct sIEC104DataAttributeID *psDAID                   = NULL; //update dataaddtribute
            struct sIEC104DataAttributeData *psNewValue             = NULL; //updtae new value
            unsigned int uiCount;

            Unsigned8   u8Data                      = 1;
            Float32 f32Data                         = -10;
            Boolean bGenEvent  = TRUE;

            // update parameters
            uiCount     =   2;
            psDAID      =   calloc(uiCount,sizeof(struct sIEC104DataAttributeID));
            psNewValue  =   calloc(uiCount,sizeof(struct sIEC104DataAttributeData));        
        
            psDAID[0].eTypeID                           =   M_SP_NA_1;
            psDAID[0].u32IOA                            =   5006;
            psDAID[0].pvUserData                        =   NULL;
            psNewValue[0].tQuality                      =   GD;
            //current date 11/8/2012
            psNewValue[0].sTimeStamp.u8Day              =   8;
            psNewValue[0].sTimeStamp.u8Month            =   11;
            psNewValue[0].sTimeStamp.u16Year            =   2012;
        
            //time 13.35.0
            psNewValue[0].sTimeStamp.u8Hour             =   13;
            psNewValue[0].sTimeStamp.u8Minute           =   36;
            psNewValue[0].sTimeStamp.u8Seconds          =   0;
            psNewValue[0].sTimeStamp.u16MilliSeconds    =   0;
            psNewValue[0].sTimeStamp.u16MicroSeconds    =   0;
            psNewValue[0].sTimeStamp.i8DSTTime          =   0; //No Day light saving time
            psNewValue[0].sTimeStamp.u8DayoftheWeek     =   4;
        
            psNewValue[0].pvData                        =   &u8Data;
            psNewValue[0].eDataType                     =   SINGLE_POINT_DATA;
            psNewValue[0].eDataSize                     =   DOUBLE_POINT_SIZE;
        
            psDAID[1].eTypeID                           =   M_ME_TF_1;
            psDAID[1].u32IOA                            =   7006L;
            psDAID[1].pvUserData                        =   NULL;
            psNewValue[1].tQuality                      =   GD;
            //current date 11/8/2012
            psNewValue[1].sTimeStamp.u8Day              =   8;
            psNewValue[1].sTimeStamp.u8Month            =   11;
            psNewValue[1].sTimeStamp.u16Year            =   2012;
        
            //time 13.35.0
            psNewValue[1].sTimeStamp.u8Hour             =   13;
            psNewValue[1].sTimeStamp.u8Minute           =   36;
            psNewValue[1].sTimeStamp.u8Seconds          =   0;
            psNewValue[1].sTimeStamp.u16MilliSeconds    =   0;
            psNewValue[1].sTimeStamp.u16MicroSeconds    =   0;
            psNewValue[1].sTimeStamp.i8DSTTime          =   0; //No Day light saving time
            psNewValue[1].sTimeStamp.u8DayoftheWeek     =   4;
        
            psNewValue[1].pvData                        =   &f32Data;
            psNewValue[1].eDataType                     =   FLOAT32_DATA;
            psNewValue[1].eDataSize                     =   FLOAT32_SIZE;

            // Update server
            eErrorCode = IEC104Update(myServer,bGenEvent,psDAID,psNewValue,uiCount,&tErrorValue);  //Update myServer
            if(eErrorCode != EC_NONE)
            {
                printf("\r\nError: IEC104Update() failed:  %i %i", eErrorCode, tErrorValue);
            }

        \endcode 
    */


#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104Update", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif

    public static extern short IEC104Update(System.IntPtr myIEC104Obj, byte bGenEvent, ref iec104types.sIEC104DataAttributeID psDAID, ref iec104types.sIEC104DataAttributeData psNewValue, ushort u16Count, ref short ptErrorValue);

    /*!\brief           IEC104Client - send clock sync, General Interrogation, counter interrogation command. 
        \ingroup        Management
     
        \param[in]      myIEC104Obj       IEC104 object 
        \param[in]      eCounterFreeze    enum eIEC104CounterFreezeFlags
        \param[in]      psDAID            Pointer to IEC104_DataAttributeID structure (or compatable) that idendifies the point that is to be written
        \param[in]      psWriteValue      Pointer to Object Data structure that hold the new value of the struct sIEC104DataAttributeData 
        \param[in]      ptWriteParams     Pointer to struct sIEC104WriteParameters 
        \param[out]     ptErrorValue      Pointer to Error Value 
     
        \return         EC_NONE on success
        \return         otherwise error code
         
     
       Client Example Usage:
       \code
     
        enum eTgtErrorCodes                    eErrorCode        = EC_NONE;
        tErrorValue                         tErrorValue       = EV_NONE;
     
        struct sIEC104DataAttributeID sDAID;
        struct sIEC104DataAttributeData sWriteValue;
     
        strcpy((char*)sDAID.ai8IPAddress,"127.0.0.1");
        sDAID.u16PortNumber             =   2404;
        sDAID.eTypeID               =   C_IC_NA_1;
        sDAID.u16CommonAddress    =   1;
     
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
         
                 
        eErrorCode =    IEC104Write(myClient, IEC104_READ, &sDAID, &sWriteValue,&tErrorValue);
        if(eErrorCode != EC_NONE)
        {
            printf("\r\nError: IEC104Write() failed:  %i %i", eErrorCode, tErrorValue);
        }
     
     \endcode
     
    */



#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104Write", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif

    public static extern short IEC104Write(System.IntPtr myIEC104Obj, iec60870common.eCounterFreezeFlags eCounterFreeze, ref iec104types.sIEC104DataAttributeID psDAID, ref iec104types.sIEC104DataAttributeData psWriteValue, ref iec104types.sIEC104WriteParameters ptWriteParams, ref short ptErrorValue);

    /*!\brief           IEC104Client Select a given control Data object.             
        \ingroup        Management
     
        \param[in]      myIEC104Obj       IEC104 object 
        \param[in]      psDAID          Pointer to IEC104 Data Attribute ID of control that is to be Selected
        \param[in]      psSelectValue   Pointer to IEC104 Data Attribute Data (The value the control is to be set)
        \param[in]      psSelectParams  Pointer to IEC104 Data Attribute Parameters (Quality Paramters)
        \param[out]     ptErrorValue    Pointer to Error Value 
     
        \return         EC_NONE on success
        \return         otherwise error code
     
        Client Example Usage:
        \code
     
            enum eTgtErrorCodes                    eErrorCode        = EC_NONE;
            tErrorValue                         tErrorValue       = EV_NONE;
     
            Float32             f32value        =   0;
            struct sIEC104DataAttributeID sDAID;
            struct sIEC104DataAttributeData sSelectValue;
            struct sIEC104CommandParameters sSelectParams;
     
            strcpy((char*)sDAID.ai8IPAddress,"127.0.0.1");
            sDAID.u16PortNumber             =   2404;
            sDAID.eTypeID               =   C_SE_TC_1;
            sDAID.u16CommonAddress    =   1;
            sDAID.u32IOA                =   8006;
     
            f32value                    =   -1.2345;
            sSelectValue.eDataSize      =   FLOAT32_SIZE;
            sSelectValue.eDataType      =   FLOAT32_DATA;
            sSelectValue.pvData         =   &f32value;
     
            sSelectParams.eQOCQU        =   NOADDDEF;
            memset(&sSelectValue.sTimeStamp, 0, sizeof(struct sTargetTimeStamp));
     
            //current date 11/8/2012
            sSelectValue.sTimeStamp.u8Day               =   8;
            sSelectValue.sTimeStamp.u8Month             =   11;
            sSelectValue.sTimeStamp.u16Year             =   2012;
     
            //time 13.35.0
            sSelectValue.sTimeStamp.u8Hour              =   13;
            sSelectValue.sTimeStamp.u8Minute            =   36;
            sSelectValue.sTimeStamp.u8Seconds           =   0;
            sSelectValue.sTimeStamp.u16MilliSeconds     =   0;
            sSelectValue.sTimeStamp.u16MicroSeconds     =   0;
            sSelectValue.sTimeStamp.i8DSTTime           =   0; //No Day light saving time
            sSelectValue.sTimeStamp.u8DayoftheWeek      =   4;
             
             
            eErrorCode =    IEC104Select(myClient,&sDAID, &sSelectValue, &sSelectParams,&tErrorValue);
            if(eErrorCode != EC_NONE)
            {
                printf("\r\nError: IEC104Select() failed:  %i %i", eErrorCode, tErrorValue);
            }
     
        \endcode
    */


#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104Select", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif

    public static extern short IEC104Select(System.IntPtr myIEC104Obj, ref iec104types.sIEC104DataAttributeID psDAID, ref iec104types.sIEC104DataAttributeData psSelectValue, ref iec104types.sIEC104CommandParameters psSelectParams, ref short ptErrorValue);

    /*!\brief           Send an Operate command on given control Data object. 
        \ingroup        Management
     
        \param[in]      myIEC104Obj       IEC104 object 
        \param[in]      psDAID          Pointer to IEC104 Data Attribute ID of control that is to be Operated
        \param[in]      psOperateValue  Pointer to IEC104 Data Attribute Data (The value the control is to be set )
        \param[in]      psOperateParams Pointer to IEC104 Data Attribute Parameters (Quality Paramters)
        \param[out]     ptErrorValue    Pointer to Error Value 
     
        \return         EC_NONE on success
        \return         otherwise error code
     
        Client Example Usage:
        \code
         
            enum eTgtErrorCodes                    eErrorCode        = EC_NONE;
            tErrorValue                         tErrorValue       = EV_NONE;
     
            Float32             f32value        =   0;
            struct sIEC104DataAttributeID sDAID;
            struct sIEC104DataAttributeData sOperateValue;
            struct sIEC104CommandParameters sOperateParams;
     
     
     
            strcpy((char*)sDAID.ai8IPAddress,"127.0.0.1");
            sDAID.u16PortNumber             =   2404;
            sDAID.eTypeID               =   C_SE_TC_1;
            sDAID.u16CommonAddress    =   1;
            sDAID.u32IOA                =   8006;
     
            f32value                    =   -1.2345;
            sOperateValue.eDataSize     =   FLOAT32_SIZE;
            sOperateValue.eDataType     =   FLOAT32_DATA;
            sOperateValue.pvData            =   &f32value;
     
            sOperateParams.eQOCQU       =   NOADDDEF;
            memset(&sOperateValue.sTimeStamp, 0, sizeof(struct sTargetTimeStamp));
     
            //current date 11/8/2012
            sOperateValue.sTimeStamp.u8Day              =   8;
            sOperateValue.sTimeStamp.u8Month                =   11;
            sOperateValue.sTimeStamp.u16Year                =   2012;
     
            //time 13.35.0
            sOperateValue.sTimeStamp.u8Hour             =   13;
            sOperateValue.sTimeStamp.u8Minute           =   36;
            sOperateValue.sTimeStamp.u8Seconds          =   0;
            sOperateValue.sTimeStamp.u16MilliSeconds        =   0;
            sOperateValue.sTimeStamp.u16MicroSeconds        =   0;
            sOperateValue.sTimeStamp.i8DSTTime          =   0; //No Day light saving time
            sOperateValue.sTimeStamp.u8DayoftheWeek     =   4;
             
             
            eErrorCode =    IEC104Operate(myClient,&sDAID, &sOperateValue, &sOperateParams,&tErrorValue);
            if(eErrorCode != EC_NONE)
            {
                printf("\r\nError: IEC104Operate() failed:  %i %i", eErrorCode, tErrorValue);
            }
             
        \endcode            
    */


#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104Operate", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif

    public static extern short IEC104Operate(System.IntPtr myIEC104Obj, ref iec104types.sIEC104DataAttributeID psDAID, ref iec104types.sIEC104DataAttributeData psOperateValue, ref iec104types.sIEC104CommandParameters psOperateParams, ref short ptErrorValue);

    /*!\brief           Cancel current command on given control Data object. 
        \ingroup        Management
     
         
        \param[in]      myIEC104Obj     IEC104 object 
        \param[in]      eOperation      Select/Operate to cancel enum eOperationFlag
        \param[in]      psDAID          Pointer to IEC104 Data Attribute ID of control that is to be canceled
        \param[in]      psCancelValue   Pointer to IEC104 Data Attribute Data (The value the control is to be set to)
        \param[in]      psCancelParams  Pointer to struct sIEC104CommandParameters (Quality Paramters)
        \param[out]     ptErrorValue    Pointer to Error Value 
     
        \return         EC_NONE on success
        \return         otherwise error code
     
        Client Example Usage:
        \code
     
            enum eTgtErrorCodes                    eErrorCode        = EC_NONE;
            tErrorValue                         tErrorValue       = EV_NONE;
     
            Float32             f32value        =   0;
            enum eOperationFlag eOperation = OPERATE;
            struct sIEC104DataAttributeID sDAID;
            struct sIEC104DataAttributeData sCancelValue;
            struct sIEC104CommandParameters sCancelParams;
     
            strcpy((char*)sDAID.ai8IPAddress,"127.0.0.1");
            sDAID.u16PortNumber             =   2404;
            sDAID.eTypeID               =   C_SE_TC_1;
            sDAID.u16CommonAddress    =   1;
            sDAID.u32IOA                =   8006;
     
            f32value                    =   -1.2345;
            sCancelValue.eDataSize      =   FLOAT32_SIZE;
            sCancelValue.eDataType      =   FLOAT32_DATA;
            sCancelValue.pvData         =   &f32value;
     
            sCancelParams.eQOCQU        =   NOADDDEF;
            memset(&sCancelValue.sTimeStamp, 0, sizeof(struct sTargetTimeStamp));
     
            //current date 11/8/2012
            sCancelValue.sTimeStamp.u8Day               =   8;
            sCancelValue.sTimeStamp.u8Month             =   11;
            sCancelValue.sTimeStamp.u16Year             =   2012;
     
            //time 13.35.0
            sCancelValue.sTimeStamp.u8Hour              =   13;
            sCancelValue.sTimeStamp.u8Minute            =   36;
            sCancelValue.sTimeStamp.u8Seconds           =   0;
            sCancelValue.sTimeStamp.u16MilliSeconds     =   0;
            sCancelValue.sTimeStamp.u16MicroSeconds     =   0;
            sCancelValue.sTimeStamp.i8DSTTime           =   0; //No Day light saving time
            sCancelValue.sTimeStamp.u8DayoftheWeek      =   4;
             
             
            eErrorCode =    IEC104Cancel(OPERATE, myClient,&sDAID, &sCancelValue, &sCancelParams,&tErrorValue);
            if(eErrorCode != EC_NONE)
            {
                printf("\r\nError: IEC104Cancel() failed:  %i %i", eErrorCode, tErrorValue);
            }
             
     
        \endcode            
    */


#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104Cancel", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif
    public static extern short IEC104Cancel(iec60870common.eOperationFlag eOperation, System.IntPtr myIEC104Obj, ref iec104types.sIEC104DataAttributeID psDAID, ref iec104types.sIEC104DataAttributeData psCancelValue, ref iec104types.sIEC104CommandParameters psCancelParams, ref short ptErrorValue);

    /*!\brief           Read a value to a given Object ID. 
        \ingroup        Management
    
        \param[in]      myIEC104Obj       IEC104 object 
        \param[in]      psDAID          Pointer to IEC104 DataAttributeID structure (or compatable) that idendifies the point that is to be read
        \param[in]      psReturnedValue Pointer to Object Data structure that hold the returned value
        \param[out]     ptErrorValue    Pointer to Error Value (if any error occurs while reading the object)
    
        \return         EC_NONE on success
        \return         otherwise error code

        Client Example Usage:
        \code
        
            enum eTgtErrorCodes                    eErrorCode        = EC_NONE;
            tErrorValue                         tErrorValue       = EV_NONE;
        
            struct sIEC104DataAttributeID sDAID;
            struct sIEC104DataAttributeData sReturnedValue;
        
            strcpy((char*)sDAID.ai8IPAddress,"127.0.0.1");
            sDAID.u16PortNumber             =   2404;                    
            sDAID.eTypeID               =   M_SP_NA_1;
            sDAID.u16CommonAddress    =   1;
            sDAID.u32IOA                =   8006;
                    
            eErrorCode =    IEC104Read(myClient,&sDAID, &sReturnedValue,&tErrorValue);
            if(eErrorCode != EC_NONE)
            {
                printf("\r\nError: IEC104Read() failed:  %i %i", eErrorCode, tErrorValue);
            }
            
        \endcode            
    */


#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104Read", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif

    public static extern short IEC104Read(System.IntPtr myIEC104Obj, ref iec104types.sIEC104DataAttributeID psDAID, ref iec104types.sIEC104DataAttributeData psReturnedValue, ref short ptErrorValue);

    /*! \brief           Set IEC104 debug options.
       \par             Upadte Debug option for the IEC104 Object
       \ingroup         Management
     
       \param[in]   myIEC104Obj           IEC104 object to Get Type and Size
       \param[in]   psDebugParams       Pointer to debug parameters
       \param[out]  ptErrorValue        Pointer to Error Value (if any error occurs while creating the object)
     
       \return      EC_NONE on success
       \return      otherwise error code

       Client Example Usage:
       \code
                    
             // Set debug option sample code                              
             enum eAppErrorCodes                     eErrorCode              = APP_ERROR_NONE;
             tAppErrorValue                              tErrorValue             = APP_ERRORVALUE_NONE;
             struct sIEC104DebugParameters   sDebugParams        = {0};
             
             // Set the debug option to error, transmission and reception data 
             sDebugParams.u32DebugOptions = DEBUG_OPTION_ERROR | DEBUG_OPTION_TX |                                               DEBUG_OPTION_RX;
             
             //Call function to set debug options
             eErrorCode = IEC104SetDebugOptions(myIEC104Obj, &sDebugParams, &tErrorValue);
             if(eErrorCode != APP_ERROR_NONE)
             {
                 printf("Set debug options IEC 104 has failed: %i %i", eErrorCode, tErrorValue);
             }
       \endcode 

     */


#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104SetDebugOptions", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif

    public static extern short IEC104SetDebugOptions(System.IntPtr myIEC104Obj, ref iec104types.sIEC104DebugParameters psDebugParams, ref short ptErrorValue);

    /*! \brief        Get IEC104 data type and data size to the returned Value.
       \par          Get IEC104 data type and data size for Group ID
       \ingroup      Management
     
       \param[in]    myIEC104Obj         IEC104 object to Get Type and Size
       \param[in]    psDAID              Pointer to IEC104 Data Attribute ID
       \param[out]   psReturnedValue     Pointer to IEC104 Data Attribute Data containing only data type and data size.
       \param[out]   ptErrorValue        Pointer to Error Value
     
       \return       EC_NONE on success
       \return       otherwise error code

        Example Usage:
        \code

       
                // Get data type and size function sample code
                enum eAppErrorCodes                  eErrorCode              = APP_ERROR_NONE;
                tAppErrorValue                           tErrorValue             = APP_ERRORVALUE_NONE;
                struct sIEC104DataAttributeID        sDAID                   = {0};
                struct sIEC104DataAttributeData sReturnedValue   = {0};
             
                // Set the Type ID for which you want to get the data type and size 
                sDAID.eTypeID    = C_SC_NA_1;
             
                // Call function to get type and size
                eErrorCode = IEC104GetDataTypeAndSize(myIEC104Obj, &sDAID, &sReturnedValue, &tErrorValue);
                if(eErrorCode != APP_ERROR_NONE)
                {
                     printf("Get Type IEC 104 has failed: %i %i", eErrorCode, tErrorValue);
                }
                else
                {
                     printf("\r\n Type is : %u, Size is %u", sReturnedValue.eDataType, sReturnedValue.eDataSize);
                }
         \endcode 
     */

#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104GetDataTypeAndSize", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif

    public static extern short IEC104GetDataTypeAndSize(System.IntPtr myIEC104Obj, ref iec104types.sIEC104DataAttributeID psDAID, ref iec104types.sIEC104DataAttributeData psReturnedValue, ref short ptErrorValue);

    /*!\brief           Send an Parameter Act command on given control Data object. 
        \ingroup        Management

        \param[in]      myIEC104Obj       IEC104 object 
        \param[in]      psDAID          Pointer to IEC104 Data Attribute ID of control that is to be Operated
        \param[in]      psOperateValue  Pointer to IEC104 Data Attribute Data (The value the control is to be set )
        \param[in]      psParaParams Pointer to IEC104 Data Attribute Parameters (Quality Paramters)
        \param[out]     ptErrorValue    Pointer to Error Value 

        \return         EC_NONE on success
        \return         otherwise error code

        Client Example Usage:
        \code
        
            enum eTgtErrorCodes                    eErrorCode        = EC_NONE;
            tErrorValue                         tErrorValue       = EV_NONE;

            Float32             f32value        =   0;
            struct sIEC104DataAttributeID sDAID;
            struct sIEC104DataAttributeData sOperateValue;
            struct sIEC104ParameterActParameters sParaParams;

            sDAID.eTypeID               =   P_ME_NC_1;
            sDAID.u16CommonAddress    =   1;
            sDAID.u32IOA                =   8006;

            f32value                    =   -1.2345;
            sOperateValue.eDataSize     =   FLOAT32_SIZE;
            sOperateValue.eDataType     =   FLOAT32_DATA;
            sOperateValue.pvData            =   &f32value;

            sOperateParams.eQOCQU       =   NOADDDEF;
            memset(&sOperateValue.sTimeStamp, 0, sizeof(struct sTargetTimeStamp));

            //current date 11/8/2012
            sOperateValue.sTimeStamp.u8Day              =   8;
            sOperateValue.sTimeStamp.u8Month                =   11;
            sOperateValue.sTimeStamp.u16Year                =   2012;

            //time 13.35.0
            sOperateValue.sTimeStamp.u8Hour             =   13;
            sOperateValue.sTimeStamp.u8Minute           =   36;
            sOperateValue.sTimeStamp.u8Seconds          =   0;
            sOperateValue.sTimeStamp.u16MilliSeconds        =   0;
            sOperateValue.sTimeStamp.u16MicroSeconds        =   0;
            sOperateValue.sTimeStamp.i8DSTTime          =   0; //No Day light saving time
            sOperateValue.sTimeStamp.u8DayoftheWeek     =   4;
            
            
            eErrorCode =    IEC104ParameterAct(myClient,&sDAID, &sOperateValue, &sOperateParams,&tErrorValue);
            if(eErrorCode != EC_NONE)
            {
                printf("\r\nError: IEC104ParameterAct() failed: %i %i", eErrorCode, tErrorValue);
            }
            
        \endcode            
    */


#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104ParameterAct", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif

    public static extern short IEC104ParameterAct(System.IntPtr myIEC104Obj, ref iec104types.sIEC104DataAttributeID psDAID, ref iec104types.sIEC104DataAttributeData psOperateValue, ref iec104types.sIEC104ParameterActParameters psParaParams, ref short ptErrorValue);

    /*! \brief        IEC104 Get File.
       \par          IEC104 Get file Using File Name.
       \ingroup      Management
     
       \param[in]    myIEC104Obj         IEC104 object - file transfer in monitor direction
       \param[in]    psDAID              Pointer to IEC104 Data Attribute ID
       \param[in]    u16FileName         File Name.
       \param[out]   ptErrorValue        Pointer to Error Value
     
       \return       EC_NONE on success
       \return       otherwise error code

        Client Example Usage:
        \code

       enum eTgtErrorCodes                 eErrorCode        = EC_NONE;
       tErrorValue                      tErrorValue       = EV_NONE;
       struct sIEC104DataAttributeID sWriteDAID     =   {0};
       Unsigned16   u16FileName                         = 0;
       
       strcpy((char*)sWriteDAID.ai8IPAddress,"127.0.0.1");
       sWriteDAID.u16PortNumber  =   2404;
       sWriteDAID.u16CommonAddress =     0;
       sWriteDAID.u32IOA             =   0;
       u16FileName = 1042;
     
       printf("\r\n Going for File Tranfer");
       eErrorCode = IEC104GetFile(myClient, &sWriteDAID, u16FileName,  &tErrorValue);  
       if(eErrorCode != EC_NONE)
       {
         printf("\r\n Error File Transfer Failed: %i %i", eErrorCode,  tErrorValue);
         break;
       }
       else
       {
             printf("\r\n File Tranfer Success\n\n");
       }
       \endcode
     */

#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104GetFile", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
#endif
    public static extern short IEC104GetFile(System.IntPtr myIEC104Obj, ref iec104types.sIEC104DataAttributeID psDAID, ushort u16FileName, ref short ptErrorValue);

    /*! \brief        IEC104 Send File- Client Send file to Server
   \par          IEC104 Send file Using File Name.
   \ingroup      Management
     
   \param[in]    myIEC104Obj         IEC104 object - file transfer in control direction
   \param[in]    psDAID              Pointer to IEC104 Data Attribute ID
   \param[in]    u16FileName         File Name.
   \param[out]   ptErrorValue        Pointer to Error Value
     
   \return       EC_NONE on success
   \return       otherwise error code

    Client Example Usage:
    \code

   Integer16                 iErrorCode        = EC_NONE;
   tErrorValue                      tErrorValue       = EV_NONE;
   struct sIEC104DataAttributeID sWriteDAID     =   {0};
   Unsigned16   u16FileName                         = 0;
       
   strcpy((char*)sWriteDAID.ai8IPAddress,"127.0.0.1");
   sWriteDAID.u16PortNumber  =   2404;
   sWriteDAID.u16CommonAddress =     0;
   sWriteDAID.u32IOA             =   0;
   u16FileName = 1042;
     
   printf("\r\n Going for File Tranfer");
   iErrorCode = IEC104SendFile(myClient, &sWriteDAID, u16FileName,  &tErrorValue);  
   if(iErrorCode != EC_NONE)
   {
     printf("\r\n Error File Transfer Failed: %i %i", iErrorCode,  tErrorValue);
     break;
   }
   else
   {
         printf("\r\n File Tranfer Success\n\n");
   }
   \endcode
 */


#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104SendFile", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
# endif
    public static extern short IEC104SendFile(System.IntPtr myIEC104Obj, ref iec104types.sIEC104DataAttributeID psDAID, ushort u16FileName, ref short ptErrorValue);

    /*! \brief        Get IEC104 Client Connection Status.
       \par          Get IEC104  Client connection status.
       \ingroup      Management
     
       \param[in]    myIEC104Obj         IEC104 object 
       \param[in]    psDAID              Pointer to IEC104 Data Attribute ID
       \param[out]    peSat           Pointer to enum eStatus 
       \param[out]   ptErrorValue        Pointer to Error Value
     
       \return       EC_NONE on success
       \return       otherwise error code  
    
       Example Usage:
             \code
             
             enum eTgtErrorCodes                 eErrorCode        = EC_NONE;
             tErrorValue                      tErrorValue       = EV_NONE;
             enum eStatus eSat = 0;
                struct sIEC104DataAttributeID sDAID     =   {0};
    
                strcpy((char*)sDAID.ai8IPAddress,"127.0.0.1");
                sDAID.u16PortNumber =   2404;
                sDAID.u16CommonAddress  =   1;
                sDAID.u32IOA           =   0;
             
    
             
                  eErrorCode = IEC104ClientStatus(myClient, &sDAID, &eSat, &tErrorValue);  
                  if(eErrorCode != EC_NONE)
                  {
                      printf("\r\n IEC104ClientStatus Failed: %i %i", eErrorCode,  tErrorValue);
                      break;
                  }
                  else
                  {
                          printf("\r\n IEC104ClientStatus  Success\n\n\n");
                  }
             
          \endcode
     */
#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104ClientStatus", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
# endif
    public static extern short IEC104ClientStatus(System.IntPtr myIEC104Obj, ref iec104types.sIEC104DataAttributeID psDAID, ref iec60870common.eStatus peSat, ref short ptErrorValue);

    /*! \brief        IEC104 Client Change State - data mode/ test mode
       \par          change IEC104 Client state.
       \ingroup      Management
     
       \param[in]    myIEC104Obj         IEC104 object 
       \param[in]    psDAID              Pointer to IEC104 Data Attribute ID
       \param[in]    eState           enum eConnectState 
       \param[out]   ptErrorValue        Pointer to Error Value
     
       \return       EC_NONE on success
       \return       otherwise error code  
       Example Usage:
             \code
             
             enum eTgtErrorCodes                 eErrorCode        = EC_NONE;
             tErrorValue                      tErrorValue       = EV_NONE;
            enum eConnectState eState = TEST_MODE;
                struct sIEC104DataAttributeID sDAID     =   {0};
    
                strcpy((char*)sDAID.ai8IPAddress,"127.0.0.1");
                sDAID.u16PortNumber =   2404;
                sDAID.u16CommonAddress  =   1;
                sDAID.u32IOA           =   0;
             
    
             
                  eErrorCode = IEC104ClientChangeState(myClient, &sDAID, eState, &tErrorValue); 
                  if(eErrorCode != EC_NONE)
                  {
                      printf("\r\n IEC104ClientStatus Failed: %i %i", eErrorCode,  tErrorValue);
                      break;
                  }
                  else
                  {
                          printf("\r\n IEC104ClientChangeState  Success\n\n\n");
                  }
             
          \endcode
     */
#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104ClientChangeState", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
# endif
    public static extern short IEC104ClientChangeState(System.IntPtr myIEC104Obj, ref iec104types.sIEC104DataAttributeID psDAID, iec104types.eConnectState eState, ref short ptErrorValue);

    /*! \brief        Get IEC104 object Status.
       \par          Get IEC104 Get object status -  loaded, running, stoped, freed.
       \ingroup      Management
     
       \param[in]    myIEC104Obj         IEC104 object 
       \param[out]   peCurrentState   Pointer to enum  eAppState   
       \param[out]   ptErrorValue        Pointer to Error Value
     
       \return       EC_NONE on success
       \return       otherwise error code

       Example Usage:
             \code
             
             enum eTgtErrorCodes                 eErrorCode        = EC_NONE;
             tErrorValue                      tErrorValue       = EV_NONE;
             enum  eAppState  eCurrentState = 0,

             
                  eErrorCode = GetIEC104ObjectStatus(myClient, &eCurrentState, &tErrorValue);  
                  if(eErrorCode != EC_NONE)
                  {
                      printf("\r\nGetIEC104ObjectStatus Failed: %i %i", eErrorCode,  tErrorValue);
                      break;
                  }
                  else
                  {
                          printf("\r\n GetIEC104ObjectStatus  Success\n\n\n");
                  }
             
          \endcode

     */
#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "GetIEC104ObjectStatus", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
# endif
    public static extern short GetIEC104ObjectStatus(System.IntPtr myIEC104Obj, ref tgtcommon.eAppState peCurrentState, ref short ptErrorValue);

    /*! \brief        IEC104 List Directory
       \par          Get Directory List as call Backs
       \ingroup      Management
     
       \param[in]    myIEC104Obj         IEC104 object to Get Type and Size
       \param[in]    psDAID              Pointer to IEC104 Data Attribute ID
       \param[out]   ptErrorValue        Pointer to Error Value
     
       \return       EC_NONE on success
       \return       otherwise error code

       Client Example Usage:
       \code

       enum eTgtErrorCodes                 eErrorCode        = EC_NONE;
       tErrorValue                      tErrorValue       = EV_NONE;
       struct sIEC104DataAttributeID sWriteDAID     =   {0};

            strcpy((char*)sWriteDAID.ai8IPAddress,"127.0.0.1");
            sWriteDAID.u16PortNumber    =   2404;
            sWriteDAID.u16CommonAddress =   1;
            sWriteDAID.u32IOA           =   0;

            eErrorCode = IEC104ListDirectory(myClient, &sWriteDAID, &tErrorValue);  
            if(eErrorCode != EC_NONE)
            {
                printf("\r\n Error List Directory Failed: %i %i", eErrorCode,  tErrorValue);
                break;
            }
            else
            {
                    printf("\r\n List Directory  Success\n\n\n");
            }

            \endcode
     */
#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104ListDirectory", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
# endif
    public static extern short IEC104ListDirectory(System.IntPtr myIEC104Obj, ref iec104types.sIEC104DataAttributeID psDAID, ref short ptErrorValue);

    /*! \brief        Get Error code String
      \par         For particular Error code , get Error String
      \ingroup     Management
    
      \param[in,out]  psIEC104ErrorCodeDes - Pointer to struct sIEC104ErrorCode 
    
      \return         error code string
    
      Example Usage:
      \code
    
      struct sIEC104ErrorCode sIEC104ErrorCodeDes  = {0};
      const char *i8ReturnedMessage = " ";
    
      sIEC104ErrorCodeDes.iErrorCode = errorcode;
    
      IEC104ErrorCodeString(&sIEC104ErrorCodeDes);
    
      i8ReturnedMessage = sIEC104ErrorCodeDes.LongDes;
    
      \endcode
    
    */
#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104ErrorCodeString", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
# endif
    public static extern void IEC104ErrorCodeString(ref iec104types.sIEC104ErrorCode psIEC104ErrorCodeDes);

    /*! \brief        Get Error value String
      \par         For particular Error value , get Error String
      \ingroup     Management

      \param[in,out]       psIEC104ErrorValueDes - Pointer to struct sIEC104ErrorValue 

      \return          error value string 

      Example Usage:
      \code

      struct sIEC104ErrorValue sIEC104ErrorValueDes  = {0};
       const char *i8ReturnedMessage = " ";
      
       sIEC104ErrorValueDes.iErrorValue = errorvalue;
      
       IEC104ErrorValueString(&sIEC104ErrorValueDes);
      
       i8ReturnedMessage = sIEC104ErrorValueDes.LongDes;


      \endcode
    */
#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104ErrorValueString", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
# endif
    public static extern void IEC104ErrorValueString(ref iec104types.sIEC104ErrorValue psIEC104ErrorValueDes);

    /*! \brief             Get IEC 104 Library License information
     *  \par               Function used to get IEC 104 Library License information
     *
     *  \return            License information of library as a string of char 
     *  Example Usage:
     *  \code
     *      printf("Version number: %s", IEC104GetLibraryLicenseInfo(void));
     *  \endcode
     */
#if Windows
    [DllImport("iec104x64d.dll", EntryPoint = "IEC104GetLibraryLicenseInfo", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
#elif Linux
     [DllImport("libx86_x64-iec104.so")]
# endif
    public static extern System.IntPtr IEC104GetLibraryLicenseInfo();

}
