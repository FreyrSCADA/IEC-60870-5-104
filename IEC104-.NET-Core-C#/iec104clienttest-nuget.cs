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
/*! \file       iec104clienttest-nuget.cs
 *  \brief      C# Source code file, IEC 60870-5-104 Client library test program for https://www.nuget.org/packages/iec60870_5_104/
 *
 *  \par        FreyrSCADA Embedded Solution Pvt Ltd
 *              Email   : tech.support@freyrscada.com
 */
/*****************************************************************************/

/*! \brief - In a loop simulate issue command - for particular IOA , value changes - issue a command to server  */
//#define SIMULATE_COMMAND 

/*! \brief - Enable traffic flags to show transmit and receive signal  */
#define VIEW_TRAFFIC 

using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace iec104test
{
    class Program
    {

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
        struct SingleInt32Union
        {
            [System.Runtime.InteropServices.FieldOffset(0)]
            public float f;
            [System.Runtime.InteropServices.FieldOffset(0)]
            public int i;
        }


        /******************************************************************************
        * Update callback
        ******************************************************************************/
        static short cbUpdate(ushort u16ObjectId, ref iec60870_5_104.iec104types.sIEC104DataAttributeID ptUpdateID, ref iec60870_5_104.iec104types.sIEC104DataAttributeData ptUpdateValue, ref iec60870_5_104.iec104types.sIEC104UpdateParameters ptUpdateParams, ref short ptErrorValue)
        {
            Console.WriteLine();
            Console.WriteLine("cbUpdate() called");
            Console.WriteLine("Client ID " + u16ObjectId);
            Console.WriteLine("Station Address " + ptUpdateID.u16CommonAddress);

            Console.WriteLine("Data TypeID is  {0:D} IOA {1:D} ", ptUpdateID.eTypeID, ptUpdateID.u32IOA);
            Console.WriteLine("datatype->{0:D} datasize->{1:D} ", ptUpdateValue.eDataType, ptUpdateValue.eDataSize);

            if (ptUpdateID.eTypeID == iec60870_5_104.iec60870common.eIEC870TypeID.M_EP_TE_1)
            {
                byte u8data = unchecked((byte)System.Runtime.InteropServices.Marshal.ReadByte(ptUpdateValue.pvData));

                if ((u8data & (byte)iec60870_5_104.iec60870common.eStartEventsofProtFlags.GS) == (byte)iec60870_5_104.iec60870common.eStartEventsofProtFlags.GS)
                {
                    Console.WriteLine("General start of operation");
                }

                if ((u8data & (byte)iec60870_5_104.iec60870common.eStartEventsofProtFlags.SL1) == (byte)iec60870_5_104.iec60870common.eStartEventsofProtFlags.SL1)
                {
                    Console.WriteLine("Start of operation phase L1");
                }

                if ((u8data & (byte)iec60870_5_104.iec60870common.eStartEventsofProtFlags.SL2) == (byte)iec60870_5_104.iec60870common.eStartEventsofProtFlags.SL2)
                {
                    Console.WriteLine("Start of operation phase L2");
                }

                if ((u8data & (byte)iec60870_5_104.iec60870common.eStartEventsofProtFlags.SL3) == (byte)iec60870_5_104.iec60870common.eStartEventsofProtFlags.SL3)
                {
                    Console.WriteLine("Start of operation phase L3");
                }

                if ((u8data & (byte)iec60870_5_104.iec60870common.eStartEventsofProtFlags.SIE) == (byte)iec60870_5_104.iec60870common.eStartEventsofProtFlags.SIE)
                {
                    Console.WriteLine("Start of operation IE");
                }

                if ((u8data & (byte)iec60870_5_104.iec60870common.eStartEventsofProtFlags.SRD) == (byte)iec60870_5_104.iec60870common.eStartEventsofProtFlags.SRD)
                {
                    Console.WriteLine("Start of operation in reverse direction");
                }
            }
            else if (ptUpdateID.eTypeID == iec60870_5_104.iec60870common.eIEC870TypeID.M_EP_TF_1)
            {

                byte u8data = unchecked((byte)System.Runtime.InteropServices.Marshal.ReadByte(ptUpdateValue.pvData));


                if ((u8data & (byte)iec60870_5_104.iec60870common.ePackedOutputCircuitInfoofProtFlags.GC) == (byte)iec60870_5_104.iec60870common.ePackedOutputCircuitInfoofProtFlags.GC)
                {
                    Console.WriteLine("General command to output circuit ");
                }

                if ((u8data & (byte)iec60870_5_104.iec60870common.ePackedOutputCircuitInfoofProtFlags.CL1) == (byte)iec60870_5_104.iec60870common.ePackedOutputCircuitInfoofProtFlags.CL1)
                {
                    Console.WriteLine("Command to output circuit phase L1");
                }

                if ((u8data & (byte)iec60870_5_104.iec60870common.ePackedOutputCircuitInfoofProtFlags.CL2) == (byte)iec60870_5_104.iec60870common.ePackedOutputCircuitInfoofProtFlags.CL2)
                {
                    Console.WriteLine("Command to output circuit phase L2");
                }

                if ((u8data & (byte)iec60870_5_104.iec60870common.ePackedOutputCircuitInfoofProtFlags.CL3) == (byte)iec60870_5_104.iec60870common.ePackedOutputCircuitInfoofProtFlags.CL3)
                {
                    Console.WriteLine("Command to output circuit phase L3");
                }

            }
            else
            {

                switch (ptUpdateValue.eDataType)
                {
                    case iec60870_5_104.tgtcommon.eDataTypes.SINGLE_POINT_DATA:
                    case iec60870_5_104.tgtcommon.eDataTypes.DOUBLE_POINT_DATA:
                    case iec60870_5_104.tgtcommon.eDataTypes.UNSIGNED_BYTE_DATA:
                        Console.WriteLine("Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadByte(ptUpdateValue.pvData));
                        break;

                    case iec60870_5_104.tgtcommon.eDataTypes.SIGNED_BYTE_DATA:
                        sbyte i8data = unchecked((sbyte)System.Runtime.InteropServices.Marshal.ReadByte(ptUpdateValue.pvData));
                        Console.Write("Data : ");
                        Console.WriteLine(i8data);
                        break;

                    case iec60870_5_104.tgtcommon.eDataTypes.UNSIGNED_WORD_DATA:
                        ushort u16data = unchecked((ushort)System.Runtime.InteropServices.Marshal.ReadInt16(ptUpdateValue.pvData));
                        Console.Write("Data : ");
                        Console.WriteLine(u16data);
                        break;

                    case iec60870_5_104.tgtcommon.eDataTypes.SIGNED_WORD_DATA:
                        Console.WriteLine("Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadInt16(ptUpdateValue.pvData));
                        break;

                    case iec60870_5_104.tgtcommon.eDataTypes.UNSIGNED_DWORD_DATA:
                        uint u32data = unchecked((uint)System.Runtime.InteropServices.Marshal.ReadInt32(ptUpdateValue.pvData));
                        Console.Write("Data : ");
                        Console.WriteLine(u32data);
                        break;

                    case iec60870_5_104.tgtcommon.eDataTypes.SIGNED_DWORD_DATA:
                        Console.WriteLine("Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadInt32(ptUpdateValue.pvData));
                        break;

                    case iec60870_5_104.tgtcommon.eDataTypes.FLOAT32_DATA:
                        SingleInt32Union f32data;
                        f32data.f = 0;
                        f32data.i = System.Runtime.InteropServices.Marshal.ReadInt32(ptUpdateValue.pvData);
                        //Console.WriteLine("Data : {0:F}", f32data.f);
                        Console.WriteLine(string.Format("Data : {0:0.00#}", f32data.f));

                        break;

                    default:
                        break;
                }

            }


            if (ptUpdateValue.tQuality != (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.GD)
            {

                /* Now for the Status */
                if ((ptUpdateValue.tQuality & (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.IV) == (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.IV)
                {
                    Console.WriteLine("IEC_INVALID_FLAG");
                }

                if ((ptUpdateValue.tQuality & (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.NT) == (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.NT)
                {
                    Console.WriteLine("IEC_NONTOPICAL_FLAG");
                }

                if ((ptUpdateValue.tQuality & (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.SB) == (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.SB)
                {
                    Console.WriteLine("IEC_SUBSTITUTED_FLAG");
                }

                if ((ptUpdateValue.tQuality & (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.BL) == (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.BL)
                {
                    Console.WriteLine("IEC_BLOCKED_FLAG");
                }

                if ((ptUpdateValue.tQuality & (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.OV) == (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.OV)
                {
                    Console.WriteLine("IEC_OV_FLAG");
                }

                if ((ptUpdateValue.tQuality & (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.EI) == (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.EI)
                {
                    Console.WriteLine("IEC_EI_FLAG");
                }

                if ((ptUpdateValue.tQuality & (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.TR) == (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.TR)
                {
                    Console.WriteLine("IEC_TR_FLAG");
                }

                if ((ptUpdateValue.tQuality & (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.CA) == (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.CA)
                {
                    Console.WriteLine("IEC_CA_FLAG");
                }

                if ((ptUpdateValue.tQuality & (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.CR) == (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.CR)
                {
                    Console.WriteLine("IEC_CR_FLAG");
                }


            }

            if ((ptUpdateID.eTypeID == iec60870_5_104.iec60870common.eIEC870TypeID.M_EP_TD_1) ||
                    (ptUpdateID.eTypeID == iec60870_5_104.iec60870common.eIEC870TypeID.M_EP_TE_1) ||
                    (ptUpdateID.eTypeID == iec60870_5_104.iec60870common.eIEC870TypeID.M_EP_TF_1))
            {
                Console.WriteLine("Elapsed time {0:D}", ptUpdateValue.u16ElapsedTime);
            }



            Console.WriteLine("COT:" + ptUpdateParams.eCause);


            if (ptUpdateValue.sTimeStamp.u8Seconds != 0)
            {

                Console.Write("Date : {0:D}-{1:D}-{2:D}  DOW -{3:D} ", ptUpdateValue.sTimeStamp.u8Day, ptUpdateValue.sTimeStamp.u8Month, ptUpdateValue.sTimeStamp.u16Year, ptUpdateValue.sTimeStamp.u8DayoftheWeek);

                Console.WriteLine("Time : {0:D}:{1:D2}:{2:D2}:{3:D4}", ptUpdateValue.sTimeStamp.u8Hour, ptUpdateValue.sTimeStamp.u8Minute, ptUpdateValue.sTimeStamp.u8Seconds, ptUpdateValue.sTimeStamp.u16MilliSeconds);
            }


            if ((ptUpdateID.eTypeID == iec60870_5_104.iec60870common.eIEC870TypeID.M_IT_NA_1) ||
                    (ptUpdateID.eTypeID == iec60870_5_104.iec60870common.eIEC870TypeID.M_IT_TA_1) ||
                    (ptUpdateID.eTypeID == iec60870_5_104.iec60870common.eIEC870TypeID.M_IT_TB_1))
            {
                Console.WriteLine("Elapsed time {0:D}", ptUpdateValue.u8Sequence);
            }

            if ((ptUpdateID.eTypeID == iec60870_5_104.iec60870common.eIEC870TypeID.M_ST_NA_1) ||
                    (ptUpdateID.eTypeID == iec60870_5_104.iec60870common.eIEC870TypeID.M_ST_TA_1) ||
                    (ptUpdateID.eTypeID == iec60870_5_104.iec60870common.eIEC870TypeID.M_ST_TB_1))
            {
                if (ptUpdateValue.bTRANSIENT == 1)
                    Console.WriteLine("transient  - true");
                else
                    Console.WriteLine("transient  - false");
            }


            return (short)iec60870_5_104.tgterrorcodes.eTgtErrorCodes.EC_NONE;

        }

        /******************************************************************************
        * Debug callback
        ******************************************************************************/
        static short cbDebug(ushort u16ObjectId, ref iec60870_5_104.iec104types.sIEC104DebugData ptDebugData, ref short ptErrorValue)
        {
            //Console.WriteLine("\r\n cbDebug() called");
            Console.WriteLine();
            Console.Write("Client ID " + u16ObjectId);

            Console.Write(" Date : {0:D}-{1:D}-{2:D}", ptDebugData.sTimeStamp.u8Day, ptDebugData.sTimeStamp.u8Month, ptDebugData.sTimeStamp.u16Year);

            Console.Write(" Time : {0:D}:{1:D2}:{2:D2}:{3:D4}", ptDebugData.sTimeStamp.u8Hour, ptDebugData.sTimeStamp.u8Minute, ptDebugData.sTimeStamp.u8Seconds, ptDebugData.sTimeStamp.u16MilliSeconds);

            if ((ptDebugData.u32DebugOptions & (uint)iec60870_5_104.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_RX) == (uint)iec60870_5_104.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_RX)
            {

                Console.Write(" IP: " + ptDebugData.ai8IPAddress + " Port: " + ptDebugData.u16PortNumber + " <- ");

                for (ushort i = 0; i < ptDebugData.u16RxCount; i++)
                    Console.Write("{0:X2} ", ptDebugData.au8RxData[i]);

            }

            if ((ptDebugData.u32DebugOptions & (uint)iec60870_5_104.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_TX) == (uint)iec60870_5_104.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_TX)
            {
                Console.Write(" IP: " + ptDebugData.ai8IPAddress + " Port: " + ptDebugData.u16PortNumber + " -> ");

                for (ushort i = 0; i < ptDebugData.u16TxCount; i++)
                    Console.Write("{0:X2} ", ptDebugData.au8TxData[i]);

            }

            if ((ptDebugData.u32DebugOptions & (uint)iec60870_5_104.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_ERROR) == (uint)iec60870_5_104.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_ERROR)
            {
                Console.WriteLine("Error message " + ptDebugData.au8ErrorMessage);
                Console.WriteLine("ErrorCode " + ptDebugData.iErrorCode);
                Console.WriteLine("ErrorValue " + ptDebugData.tErrorvalue);
            }

            if ((ptDebugData.u32DebugOptions & (uint)iec60870_5_104.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_WARNING) == (uint)iec60870_5_104.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_WARNING)
            {

                Console.WriteLine("Warning message " + ptDebugData.au8WarningMessage);
                Console.WriteLine("ErrorCode " + ptDebugData.iErrorCode);
                Console.WriteLine("ErrorValue " + ptDebugData.tErrorvalue);
            }

            return (short)iec60870_5_104.tgterrorcodes.eTgtErrorCodes.EC_NONE;

        }

        /******************************************************************************
        * client status callback
        ******************************************************************************/
        static short cbClientStatus(ushort u16ObjectId, ref iec60870_5_104.iec104types.sIEC104DataAttributeID ptDataID, ref iec60870_5_104.iec60870common.eStatus peSat, ref short ptErrorValue)
        {
            Console.WriteLine("\r\n cbClientstatus() called");
            Console.WriteLine("Client ID " + u16ObjectId);

            if (peSat == iec60870_5_104.iec60870common.eStatus.CONNECTED)
            {
                Console.WriteLine("Status - Connected");
            }
            else
            {
                Console.WriteLine("Status - Disconnected");
            }

            Console.WriteLine("Server IP Address " + ptDataID.ai8IPAddress);
            Console.WriteLine("Server Port number " + ptDataID.u16PortNumber);
            Console.WriteLine("Server CA " + ptDataID.u16CommonAddress);


            return (short)iec60870_5_104.tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Error code - Print information
        ******************************************************************************/
        static string errorcodestring(short errorcode)
        {
            iec60870_5_104.iec104types.sIEC104ErrorCode sIEC104ErrorCodeDes;
            sIEC104ErrorCodeDes = new iec60870_5_104.iec104types.sIEC104ErrorCode();

            sIEC104ErrorCodeDes.iErrorCode = errorcode;

            iec60870_5_104.iec104api.IEC104ErrorCodeString(ref sIEC104ErrorCodeDes);

            string returnmessage = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(sIEC104ErrorCodeDes.LongDes);

            return returnmessage;
        }

        /******************************************************************************
        * Error value - Print information
        ******************************************************************************/
        static string errorvaluestring(short errorvalue)
        {
            iec60870_5_104.iec104types.sIEC104ErrorValue sIEC104ErrorValueDes;
            sIEC104ErrorValueDes = new iec60870_5_104.iec104types.sIEC104ErrorValue();

            sIEC104ErrorValueDes.iErrorValue = errorvalue;

            iec60870_5_104.iec104api.IEC104ErrorValueString(ref sIEC104ErrorValueDes);

            string returnmessage = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(sIEC104ErrorValueDes.LongDes);

            return returnmessage;
        }


        /******************************************************************************
        * main module
        ******************************************************************************/
        static void Main(string[] args)
        {
            System.DateTime date;                           // data and time for command parameters
            System.IntPtr iec104clienthandle;               // IEC104 Client object callback paramters
            iec60870_5_104.iec104types.sIEC104Parameters parameters;            // Client protocol , point configuration parameters
            iec60870_5_104.iec104types.sIEC104DataAttributeID sWriteDAID;       // Command data identification parameters
            iec60870_5_104.iec104types.sIEC104DataAttributeData sWriteValue;    // Command data value parameters
            iec60870_5_104.iec104types.sIEC104CommandParameters sCommandParams; // Command data parameters

            System.Console.WriteLine(" \n\t\t**** FreyrSCADA - IEC 60870-5-104 Client Library Test ****");

            try
            {
                if (String.Compare(System.Runtime.InteropServices.Marshal.PtrToStringAnsi(iec60870_5_104.iec104api.IEC104GetLibraryVersion()), iec60870_5_104.iec104api.IEC104_VERSION, true) != 0)
                {
                    System.Console.WriteLine("\r\nError: Version Number Mismatch");
                    System.Console.WriteLine("Library Version is : {0:D}", System.Runtime.InteropServices.Marshal.PtrToStringAnsi(iec60870_5_104.iec104api.IEC104GetLibraryVersion()));
                    System.Console.WriteLine("The Version used is : {0:D}", iec60870_5_104.iec104api.IEC104_VERSION);
                    System.Console.Write("Press <Enter> to exit... ");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                    return;
                }
            }
            catch (DllNotFoundException e)
            {
                System.Console.WriteLine(e.ToString());
                System.Console.Write("Press <Enter> to exit... ");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                return;
            }


            System.Console.WriteLine("Library Version is : {0:D}", System.Runtime.InteropServices.Marshal.PtrToStringAnsi(iec60870_5_104.iec104api.IEC104GetLibraryVersion()));
            System.Console.WriteLine("Library Build on   : {0:D}", System.Runtime.InteropServices.Marshal.PtrToStringAnsi(iec60870_5_104.iec104api.IEC104GetLibraryBuildTime()));
            System.Console.WriteLine("Library Licence Information  : {0:D}", System.Runtime.InteropServices.Marshal.PtrToStringAnsi(iec60870_5_104.iec104api.IEC104GetLibraryLicenseInfo()));

            iec104clienthandle = System.IntPtr.Zero;
            parameters = new iec60870_5_104.iec104types.sIEC104Parameters();

            // Initialize IEC 60870-5-104 Client object parameters
            parameters.eAppFlag = iec60870_5_104.tgtcommon.eApplicationFlag.APP_CLIENT;                   // This is a IEC104 CLIENT
            parameters.ptReadCallback = null;                                           // Read Callback
            parameters.ptWriteCallback = null;                                          // Write Callback
            parameters.ptUpdateCallback = new iec60870_5_104.iec104types.IEC104UpdateCallback(cbUpdate);    // Update Callback
            parameters.ptSelectCallback = null;                                         // Select Callback
            parameters.ptOperateCallback = null;                                        // Operate Callback
            parameters.ptCancelCallback = null;                                         // Cancel Callback
            parameters.ptFreezeCallback = null;                                         // Freeze Callback
            parameters.ptDebugCallback = new iec60870_5_104.iec104types.IEC104DebugMessageCallback(cbDebug);// Debug Callback
            parameters.ptPulseEndActTermCallback = null;                                // Pulseend Callback
            parameters.ptParameterActCallback = null;                                   // Parameter act Callback
            parameters.ptServerStatusCallback = null;                                   // Server status Callback
            parameters.ptClientStatusCallback = new iec60870_5_104.iec104types.IEC104ClientStatusCallback(cbClientStatus); // Client status Callback
            parameters.ptDirectoryCallback = null;                                      //Directory callback
            parameters.ptServerFileTransferCallback = null;                                 // Function called when server received a new file from client via control direction file transfer
            parameters.u16ObjectId = 1;       											//Client ID which used in callbacks to identify the iec 104 client object     
            parameters.u32Options = 0;
            short iErrorCode = 0;                                                         // API Function return error paramter
            short ptErrorValue = 0;                                                     // API Function return addtional error paramter

            do
            {
                // Create a Client object
                iec104clienthandle = iec60870_5_104.iec104api.IEC104Create(ref parameters, ref iErrorCode, ref ptErrorValue);
                if (iec104clienthandle == System.IntPtr.Zero)
                {
                    System.Console.WriteLine("IEC 60870-5-104 Library API Function - Create failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }

                iec60870_5_104.iec104types.sIEC104ConfigurationParameters psIEC104Config;
                psIEC104Config = new iec60870_5_104.iec104types.sIEC104ConfigurationParameters();
                // Client load configuration - communication and protocol configuration parameters 


                psIEC104Config.sClientSet.ai8SourceIPAddress = "0.0.0.0"; /*!< client own IP Address , use 0.0.0.0 / network ip address for binding socket*/

                psIEC104Config.sClientSet.bClientAcceptTCPconnection = 0;
                psIEC104Config.sClientSet.benabaleUTCtime = 0;

#if VIEW_TRAFFIC
                psIEC104Config.sClientSet.sDebug.u32DebugOptions = (uint)(iec60870_5_104.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_TX | iec60870_5_104.tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_RX);

#else
				psIEC104Config.sClientSet.sDebug.u32DebugOptions = 0;

#endif

                //client 1 configuration Starts                
                psIEC104Config.sClientSet.u16TotalNumberofConnection = 1;
                iec60870_5_104.iec104types.sClientConnectionParameters[] psClientConParameters = new iec60870_5_104.iec104types.sClientConnectionParameters[psIEC104Config.sClientSet.u16TotalNumberofConnection];
                psIEC104Config.sClientSet.psClientConParameters = System.Runtime.InteropServices.Marshal.AllocHGlobal(
                psIEC104Config.sClientSet.u16TotalNumberofConnection * System.Runtime.InteropServices.Marshal.SizeOf(psClientConParameters[0]));


                // check Server configuration - TCP/IP Address
                psClientConParameters[0].ai8DestinationIPAddress = "127.0.0.1";
                psClientConParameters[0].u16PortNumber = 2404;

                psClientConParameters[0].u8OrginatorAddress = 0;
                psClientConParameters[0].i16k = 12;
                psClientConParameters[0].i16w = 8;
                psClientConParameters[0].u8t0 = 30;
                psClientConParameters[0].u8t1 = 15;
                psClientConParameters[0].u8t2 = 10;
                psClientConParameters[0].u16t3 = 20;

                psIEC104Config.sClientSet.bAutoGenIEC104DataObjects = 0;
                psClientConParameters[0].eState = iec60870_5_104.iec104types.eConnectState.DATA_MODE;

                psClientConParameters[0].au16CommonAddress = new ushort[iec60870_5_104.iec60870common.MAX_CA];
                psClientConParameters[0].u8TotalNumberofStations = 1;
                psClientConParameters[0].au16CommonAddress[0] = 1;

                psClientConParameters[0].u32GeneralInterrogationInterval = 10;    /*!< in sec if 0 , gi will not send in particular interval*/
                psClientConParameters[0].u32Group1InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group2InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group3InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group4InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group5InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group6InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group7InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group8InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group9InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group10InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group11InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group12InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group13InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group14InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group15InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group16InterrogationInterval = 0;    /*!< in sec if 0 , group 1 interrogation will not send in particular interval*/
                psClientConParameters[0].u32CounterInterrogationInterval = 10;    /*!< in sec if 0 , ci will not send in particular interval*/
                psClientConParameters[0].u32Group1CounterInterrogationInterval = 0;    /*!< in sec if 0 , group 1 counter interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group2CounterInterrogationInterval = 0;    /*!< in sec if 0 , group 1 counter interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group3CounterInterrogationInterval = 0;    /*!< in sec if 0 , group 1 counter interrogation will not send in particular interval*/
                psClientConParameters[0].u32Group4CounterInterrogationInterval = 0;    /*!< in sec if 0 , group 1 counter interrogation will not send in particular interval*/
                psClientConParameters[0].u32ClockSyncInterval = 10;              /*!< in sec if 0 , clock sync, will not send in particular interval */

                psClientConParameters[0].u32CommandTimeout = 10000;
                psClientConParameters[0].u32FileTransferTimeout = 50000;
                psClientConParameters[0].bCommandResponseActtermUsed = 1;



                psClientConParameters[0].bEnablefileftransfer = 0;
                psClientConParameters[0].ai8FileTransferDirPath = "C:\\";
                psClientConParameters[0].bUpdateCallbackCheckTimestamp = 0;
                psClientConParameters[0].eCOTsize = iec60870_5_104.iec60870common.eCauseofTransmissionSize.COT_TWO_BYTE;

                psIEC104Config.sClientSet.bAutoGenIEC104DataObjects = 1;
                psClientConParameters[0].u16NoofObject = 0;        // Define number of objects
                                                                   // Allocate memory for objects
                psClientConParameters[0].psIEC104Objects = System.IntPtr.Zero;


                // client 1 configuration ends

                IntPtr tmp1 = new IntPtr(psIEC104Config.sClientSet.psClientConParameters.ToInt64());
                System.Runtime.InteropServices.Marshal.StructureToPtr(psClientConParameters[0], tmp1, true);

                // Load configuration
                iErrorCode = iec60870_5_104.iec104api.IEC104LoadConfiguration(iec104clienthandle, ref psIEC104Config, ref ptErrorValue);
                if (iErrorCode != 0)
                {
                    System.Console.WriteLine("IEC 60870-5-104 Library API Function - Load Config failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }

                // Start Client
                iErrorCode = iec60870_5_104.iec104api.IEC104Start(iec104clienthandle, ref ptErrorValue);
                if (iErrorCode != 0)
                {
                    System.Console.WriteLine("IEC 60870-5-104 Library API Function - Start failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }

#if SIMULATE_COMMAND
                // command data
                sWriteDAID = new iec60870_5_104.iec104types.sIEC104DataAttributeID();               // Command data identification parameters
                sWriteValue = new iec60870_5_104.iec104types.sIEC104DataAttributeData();            // Command data value parameters
                sCommandParams = new iec60870_5_104.iec104types.sIEC104CommandParameters();         // Command data parameters


                sWriteDAID.ai8IPAddress = "127.0.0.1";
                sWriteDAID.u16PortNumber = 2404;
                sWriteDAID.eTypeID = iec60870_5_104.iec60870common.eIEC870TypeID.C_SE_TC_1;
                sWriteDAID.u32IOA = 6000;
                sWriteDAID.u16CommonAddress = 1;

                sWriteValue.tQuality = (ushort)iec60870_5_104.iec60870common.eIEC870QualityFlags.GD;


                sWriteValue.pvData = System.Runtime.InteropServices.Marshal.AllocHGlobal((int)iec60870_5_104.tgttypes.eDataSizes.FLOAT32_SIZE);
                sWriteValue.eDataType = iec60870_5_104.tgtcommon.eDataTypes.FLOAT32_DATA;
                sWriteValue.eDataSize = iec60870_5_104.tgttypes.eDataSizes.FLOAT32_SIZE;

                SingleInt32Union f32data;
                f32data.i = 0;
                f32data.f = 1;
#endif

                System.Console.WriteLine("\r\n Enter CTRL-X to Exit");


                Thread.Sleep(3000);

                while (true)
                {
                    if (Console.KeyAvailable) // since .NET 2.0
                    {
                        char c = Console.ReadKey().KeyChar;
                        if (c == 24)
                        {
                            break;
                        }
                    }
                    else
                    {
#if SIMULATE_COMMAND
                        date = DateTime.Now;
                        //current date 
                        sWriteValue.sTimeStamp.u8Day = (byte)date.Day;
                        sWriteValue.sTimeStamp.u8Month = (byte)date.Month;
                        sWriteValue.sTimeStamp.u16Year = (ushort)date.Year;

                        //time
                        sWriteValue.sTimeStamp.u8Hour = (byte)date.Hour;
                        sWriteValue.sTimeStamp.u8Minute = (byte)date.Minute;
                        sWriteValue.sTimeStamp.u8Seconds = (byte)date.Second;
                        sWriteValue.sTimeStamp.u16MilliSeconds = (ushort)date.Millisecond;
                        sWriteValue.sTimeStamp.u16MicroSeconds = 0;
                        sWriteValue.sTimeStamp.i8DSTTime = 0; //No Day light saving time
                        sWriteValue.sTimeStamp.u8DayoftheWeek = (byte)date.DayOfWeek;



                        f32data.f += 1f;


                        //Console.WriteLine("Command Measured Value {0:F}", f32data.f);

                        System.Runtime.InteropServices.Marshal.WriteInt32(sWriteValue.pvData, f32data.i);

                        // operate command
                        iErrorCode = iec60870_5_104.iec104api.IEC104Operate(iec104clienthandle, ref sWriteDAID, ref sWriteValue, ref sCommandParams, ref ptErrorValue);
                        if (iErrorCode != 0)
                        {
                            Console.WriteLine("IEC 60870-5-104 Library API Function - IEC104Operate() failed: {0:D} {1:D}", iErrorCode, ptErrorValue);
                            System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                            System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                        }
#endif
                        Thread.Sleep(2000);
                    }
                }

                // Stop Client
                iErrorCode = iec60870_5_104.iec104api.IEC104Stop(iec104clienthandle, ref ptErrorValue);
                if (iErrorCode != 0)
                {
                    System.Console.WriteLine("IEC 60870-5-104 Library API Function - Stop failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }

                // Free Client
                iErrorCode = iec60870_5_104.iec104api.IEC104Free(iec104clienthandle, ref ptErrorValue);
                if (iErrorCode != 0)
                {
                    System.Console.WriteLine("IEC 60870-5-104 Library API Function - Free failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }

            } while (false);


            System.Console.Write("\nPress <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

    }
}