/******************************************************************************
*
* (c) 2026, 2027 by FreyrSCADA Embedded Solution Pvt Ltd
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
/*! \file       iec104servertest.cs
 *  \brief      C# Source code file, IEC 60870-5-104 Server library test program
 *
 *  \par        FreyrSCADA Embedded Solution Pvt Ltd
 *              Email   : tech.support@freyrscada.com
 */
/*****************************************************************************/

/*! \brief - in a loop simulate update - for particular IOA , value changes - generates a event  */
#define SIMULATE_UPDATE 

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
        * Print information
        ******************************************************************************/
        static void vPrintDataInformation(ref iec104types.sIEC104DataAttributeID psPrintID, ref iec104types.sIEC104DataAttributeData psData)
        {

           
            Console.WriteLine("Station Address " + psPrintID.u16CommonAddress);
            Console.WriteLine("Data Attribute TypeID is  {0:D} IOA {1:D} ", psPrintID.eTypeID, psPrintID.u32IOA);
            Console.WriteLine("Data is  datatype->{0:D} datasize->{1:D}  ", psData.eDataType, psData.eDataSize);


            if (psData.tQuality != (ushort)iec60870common.eIEC870QualityFlags.GD)
            {

                /* Now for the Status */
                if ((psData.tQuality & (ushort)iec60870common.eIEC870QualityFlags.IV) == (ushort)iec60870common.eIEC870QualityFlags.IV)
                {
                    Console.WriteLine(" IEC_INVALID_FLAG");
                }

                if ((psData.tQuality & (ushort)iec60870common.eIEC870QualityFlags.NT) == (ushort)iec60870common.eIEC870QualityFlags.NT)
                {
                    Console.WriteLine(" IEC_NONTOPICAL_FLAG");
                }

                if ((psData.tQuality & (ushort)iec60870common.eIEC870QualityFlags.SB) == (ushort)iec60870common.eIEC870QualityFlags.SB)
                {
                    Console.WriteLine(" IEC_SUBSTITUTED_FLAG");
                }

                if ((psData.tQuality & (ushort)iec60870common.eIEC870QualityFlags.BL) == (ushort)iec60870common.eIEC870QualityFlags.BL)
                {
                    Console.WriteLine(" IEC_BLOCKED_FLAG");
                }

            }           

            switch (psData.eDataType)
            {
                case tgtcommon.eDataTypes.SINGLE_POINT_DATA:
                case tgtcommon.eDataTypes.DOUBLE_POINT_DATA:
                case tgtcommon.eDataTypes.UNSIGNED_BYTE_DATA:
                    Console.WriteLine("Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadByte(psData.pvData));
                    break;

                case tgtcommon.eDataTypes.SIGNED_BYTE_DATA:                    
                    sbyte i8data = unchecked((sbyte)System.Runtime.InteropServices.Marshal.ReadByte(psData.pvData));
                    Console.Write("Data : ");
                    Console.WriteLine(i8data);
                    break;

                case tgtcommon.eDataTypes.UNSIGNED_WORD_DATA:          
                    ushort u16data = unchecked((ushort)System.Runtime.InteropServices.Marshal.ReadInt16(psData.pvData));
                    Console.Write("Data : ");
                    Console.WriteLine(u16data);
                    break;

                case tgtcommon.eDataTypes.SIGNED_WORD_DATA:
                    Console.WriteLine("Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadInt16(psData.pvData));
                    break;

                case tgtcommon.eDataTypes.UNSIGNED_DWORD_DATA:
                    uint u32data = unchecked((uint)System.Runtime.InteropServices.Marshal.ReadInt32(psData.pvData));
                    Console.Write("Data : ");
                    Console.WriteLine(u32data);
                    break;
                
                case tgtcommon.eDataTypes.SIGNED_DWORD_DATA:
                   Console.WriteLine("Data : {0:D}", System.Runtime.InteropServices.Marshal.ReadInt32(psData.pvData));
                    break;

                case tgtcommon.eDataTypes.FLOAT32_DATA:
                    SingleInt32Union f32data;
                    f32data.f = 0;
                    f32data.i = System.Runtime.InteropServices.Marshal.ReadInt32(psData.pvData);
                    Console.WriteLine(string.Format("Data : {0:0.00#}", f32data.f));
                    break;

                default:
                    break;
            }


            if (psData.sTimeStamp.u8Seconds != 0)
            {

                Console.Write("Date : {0:D}-{1:D}-{2:D}  DOW-{3:D} ", psData.sTimeStamp.u8Day, psData.sTimeStamp.u8Month, psData.sTimeStamp.u16Year, psData.sTimeStamp.u8DayoftheWeek);

                Console.WriteLine("Time : {0:D}:{1:D2}:{2:D2}:{3:D4}", psData.sTimeStamp.u8Hour, psData.sTimeStamp.u8Minute, psData.sTimeStamp.u8Seconds, psData.sTimeStamp.u16MilliSeconds);
            }
        }

        /******************************************************************************
        * Read callback
        ******************************************************************************/
        static short cbRead(ushort u16ObjectId, ref iec104types.sIEC104DataAttributeID ptReadID, ref iec104types.sIEC104DataAttributeData ptReadValue, ref iec104types.sIEC104ReadParameters ptReadParams, ref short ptErrorValue)
        {
            Console.WriteLine("cbRead() called");
			Console.WriteLine("Server ID " + u16ObjectId);

            vPrintDataInformation(ref ptReadID, ref ptReadValue);
            Console.WriteLine("Orginator Address "+ ptReadParams.u8OrginatorAddress);
            return (short)tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Write callback
        ******************************************************************************/
        static short cbWrite(ushort u16ObjectId, ref iec104types.sIEC104DataAttributeID ptWriteID, ref iec104types.sIEC104DataAttributeData ptWriteValue, ref iec104types.sIEC104WriteParameters ptWriteParams, ref short ptErrorValue)
        {
            Console.WriteLine("cbWrite() called- Clock Sync Command from IEC104 Client");
			Console.WriteLine("Server ID " + u16ObjectId);

            vPrintDataInformation(ref ptWriteID, ref ptWriteValue);
            Console.WriteLine("Orginator Address "+ ptWriteParams.u8OrginatorAddress);
            return (short)tgterrorcodes.eTgtErrorCodes.EC_NONE;

        }

        /******************************************************************************
        * Select callback
        ******************************************************************************/
        static short cbSelect(ushort u16ObjectId, ref iec104types.sIEC104DataAttributeID ptSelectID, ref iec104types.sIEC104DataAttributeData ptSelectValue, ref iec104types.sIEC104CommandParameters ptSelectParams, ref short ptErrorValue)
        {
            Console.WriteLine();
            Console.WriteLine("cbSelect() called");
			Console.WriteLine("Server ID " + u16ObjectId);

            vPrintDataInformation(ref ptSelectID, ref ptSelectValue);
            Console.WriteLine("Orginator Address " + ptSelectParams.u8OrginatorAddress);
            Console.WriteLine("Qualifier "+ ptSelectParams.eQOCQU);
            Console.WriteLine("Pulse Duration "+ ptSelectParams.u32PulseDuration);

            return (short)tgterrorcodes.eTgtErrorCodes.EC_NONE;

        }

        /******************************************************************************
        * Operate callback
        ******************************************************************************/
        static short cbOperate(ushort u16ObjectId, ref iec104types.sIEC104DataAttributeID ptOperateID, ref iec104types.sIEC104DataAttributeData ptOperateValue, ref iec104types.sIEC104CommandParameters ptOperateParams, ref short ptErrorValue)
        {
            Console.WriteLine();
            Console.WriteLine("cbOperate() called");
			Console.WriteLine("Server ID " + u16ObjectId);

            vPrintDataInformation(ref ptOperateID, ref ptOperateValue);
            Console.WriteLine("Orginator Address " + ptOperateParams.u8OrginatorAddress);
            Console.WriteLine("Qualifier "+ ptOperateParams.eQOCQU);
            Console.WriteLine("Pulse Duration "+ ptOperateParams.u32PulseDuration);

            return (short)tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Cancel callback
        ******************************************************************************/
        static short cbCancel(ushort u16ObjectId, iec60870common.eOperationFlag eOperation, ref iec104types.sIEC104DataAttributeID ptCancelID, ref iec104types.sIEC104DataAttributeData ptCancelValue, ref iec104types.sIEC104CommandParameters ptCancelParams, ref short ptErrorValue)
        {
            Console.WriteLine();
            Console.WriteLine("\n\r\n cbCancel() called");
			Console.WriteLine("Server ID " + u16ObjectId);

            if (eOperation == iec60870common.eOperationFlag.OPERATE)
                Console.WriteLine("Operate operation to be cancel");

            if (eOperation == iec60870common.eOperationFlag.SELECT)
                Console.WriteLine("Select operation to cancel");

            vPrintDataInformation(ref ptCancelID, ref ptCancelValue);

            Console.WriteLine("Qualifier "+ ptCancelParams.eQOCQU);
            Console.WriteLine("Pulse duration "+ ptCancelParams.u32PulseDuration);
            Console.WriteLine("Orginator address "+ ptCancelParams.u8OrginatorAddress);

            return (short)tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Freeze Callback
        ******************************************************************************/
        static short cbFreeze(ushort u16ObjectId, iec60870common.eCounterFreezeFlags eCounterFreeze, ref iec104types.sIEC104DataAttributeID ptFreezeID, ref iec104types.sIEC104DataAttributeData ptFreezeValue, ref iec104types.sIEC104WriteParameters ptFreezeCmdParams, ref short ptErrorValue)
        {
            Console.WriteLine();
            Console.WriteLine("cbFreeze() called");
			Console.WriteLine("Server ID " + u16ObjectId);

            
            Console.WriteLine("Command ID "+ ptFreezeID.eTypeID);
            Console.WriteLine("COT "+ ptFreezeCmdParams.eCause);
            Console.WriteLine("Orginator Address " + ptFreezeCmdParams.u8OrginatorAddress);

            return (short)tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Debug callback
        ******************************************************************************/
        static short cbDebug(ushort u16ObjectId, ref iec104types.sIEC104DebugData ptDebugData, ref short ptErrorValue)
        {
            //Console.WriteLine("\n\r\n cbDebug() called");
            Console.WriteLine();      
			Console.Write("Server ID " + u16ObjectId);

            Console.Write(" Date:{0:D}-{1:D}-{2:D}", ptDebugData.sTimeStamp.u8Day, ptDebugData.sTimeStamp.u8Month, ptDebugData.sTimeStamp.u16Year);

            Console.Write(" Time:{0:D}:{1:D2}:{2:D2}:{3:D4}", ptDebugData.sTimeStamp.u8Hour, ptDebugData.sTimeStamp.u8Minute, ptDebugData.sTimeStamp.u8Seconds, ptDebugData.sTimeStamp.u16MilliSeconds);

            if ((ptDebugData.u32DebugOptions & (uint)tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_RX) == (uint)tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_RX)
            {            
               
                Console.Write(" IP: " + ptDebugData.ai8IPAddress + " Port: " + ptDebugData.u16PortNumber + " <- ");
                
                for (ushort i = 0; i < ptDebugData.u16RxCount; i++)
                    Console.Write("{0:X2} ", ptDebugData.au8RxData[i]);
                
            }

            if ((ptDebugData.u32DebugOptions & (uint)tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_TX) == (uint)tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_TX)
            {
                Console.Write(" IP: " + ptDebugData.ai8IPAddress + " Port: " + ptDebugData.u16PortNumber + " -> ");

                for (ushort i = 0; i < ptDebugData.u16TxCount; i++)
                    Console.Write("{0:X2} ", ptDebugData.au8TxData[i]);
                
            }

            if ((ptDebugData.u32DebugOptions & (uint)tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_ERROR) == (uint)tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_ERROR)
            {
                Console.WriteLine("Error message "+ ptDebugData.au8ErrorMessage);
                Console.WriteLine("ErrorCode "+ ptDebugData.iErrorCode);
                Console.WriteLine("ErrorValue "+ ptDebugData.tErrorvalue);
            }

            if ((ptDebugData.u32DebugOptions & (uint)tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_WARNING) == (uint)tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_WARNING)
            {
                
                Console.WriteLine("Warning message " + ptDebugData.au8WarningMessage);
                Console.WriteLine("ErrorCode " + ptDebugData.iErrorCode);
                Console.WriteLine("ErrorValue " + ptDebugData.tErrorvalue);
            }

            return (short)tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }


        /******************************************************************************
        * Operate pulse end callback
        ******************************************************************************/
        static short cbpulseend(ushort u16ObjectId, ref iec104types.sIEC104DataAttributeID ptOperateID, ref iec104types.sIEC104DataAttributeData ptOperateValue, ref iec104types.sIEC104CommandParameters ptOperateParams, ref short ptErrorValue)
        {
            Console.WriteLine("cbOperatepulse end() called");
			Console.WriteLine("Server ID " + u16ObjectId);
           
            vPrintDataInformation( ref ptOperateID, ref ptOperateValue);
            Console.WriteLine("Orginator Address " + ptOperateParams.u8OrginatorAddress);
            Console.WriteLine("Qualifier "+ ptOperateParams.eQOCQU);
            Console.WriteLine("Pulse duration "+ ptOperateParams.u32PulseDuration);


            return (short)tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Parameteract callback
        ******************************************************************************/
        static short cbParameterAct(ushort u16ObjectId, ref iec104types.sIEC104DataAttributeID ptOperateID, ref iec104types.sIEC104DataAttributeData ptOperateValue, ref iec104types.sIEC104ParameterActParameters ptParameterActParams, ref short ptErrorValue)
        {
            Console.WriteLine("cbParameterAct() called");
			Console.WriteLine("Server ID " + u16ObjectId);
            vPrintDataInformation(ref ptOperateID, ref ptOperateValue);
            Console.WriteLine("Orginator Address "+ ptParameterActParams.u8OrginatorAddress);
            Console.WriteLine("Qualifier of parameter activation/kind of parameter "+ ptParameterActParams.u8QPA);
            return (short)tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Server Status Callback
        ******************************************************************************/
        static short cbServerStatus(ushort u16ObjectId, ref iec104types.sIEC104ServerConnectionID ptServerConnID, ref iec60870common.eStatus peSat, ref short ptErrorValue)
        {           
            Console.WriteLine("cbServerstatus() called");
			Console.WriteLine("Server ID " + u16ObjectId);

            if (peSat == iec60870common.eStatus.CONNECTED)
            {
                Console.WriteLine("Status - Connected");
            }
            else
            {
                Console.WriteLine("Status - Disconnected");
            }    

            Console.WriteLine("Source IP "+ ptServerConnID.ai8SourceIPAddress +" Port " + ptServerConnID.u16SourcePortNumber);
            Console.WriteLine("Remote IP "+ ptServerConnID.ai8RemoteIPAddress +" Port " + ptServerConnID.u16RemotePortNumber);

            return (short)tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }

        /******************************************************************************
        * Server File Transfer Callback
        ******************************************************************************/
        static short cbServerFileTransferCallback(iec104types.eFileTransferDirection eDirection, ushort u16ObjectId, ref iec104types.sIEC104ServerConnectionID ptServerConnID, ushort u16CommonAddress, uint u32IOA, ushort u16FileName, uint u32LengthOfFile, ref iec104types.eFileTransferStatus peFileTransferSat, ref short ptErrorValue)
        {
            Console.WriteLine("cbServerFileTransferCallback() called");
            Console.WriteLine("Server ID " + u16ObjectId);

            if (eDirection == iec104types.eFileTransferDirection.MONITOR_DIRECTION)
            {
                Console.WriteLine("File transfer in Monitor Direction - Client Receive file from server");
            }
            else if (eDirection == iec104types.eFileTransferDirection.CONTROL_DIRECTION)
            {
                Console.WriteLine("File transfer in CONTROL Direction - server receive file from client");
            }



            Console.WriteLine("Source IP: " + ptServerConnID.ai8SourceIPAddress + " Port " + ptServerConnID.u16SourcePortNumber);
            Console.WriteLine("Remote IP: " + ptServerConnID.ai8RemoteIPAddress + " Port " + ptServerConnID.u16RemotePortNumber);
            Console.WriteLine("Common Address(CA): " + u16CommonAddress);
            Console.WriteLine("Information Object Address(IOA): " + u32IOA);
            Console.WriteLine("File name: " + u16FileName);
            Console.WriteLine("Length Of File: " + u32LengthOfFile);


            do
            {
                if (peFileTransferSat == iec104types.eFileTransferStatus.FILETRANSFER_NOTINITIATED)
                {
                    Console.WriteLine("FILETRANSFER_NOTINITIATED");
                    break;
                }
                if (peFileTransferSat == iec104types.eFileTransferStatus.FILETRANSFER_STARTED)
                {
                    Console.WriteLine("FILETRANSFER_STARTED");
                    break;
                }
                if (peFileTransferSat == iec104types.eFileTransferStatus.FILETRANSFER_INTERCEPTED)
                {
                    Console.WriteLine("FILETRANSFER_INTERCEPTED");
                    break;
                }
                if (peFileTransferSat == iec104types.eFileTransferStatus.FILETRANSFER_COMPLEATED)
                {
                    Console.WriteLine("FILETRANSFER_COMPLEATED");
                    break;
                }
            } while (false);


            return (short)tgterrorcodes.eTgtErrorCodes.EC_NONE;
        }



        /******************************************************************************
        * Error code - Print information
        ******************************************************************************/
        static string errorcodestring(short errorcode)
        {
            iec104types.sIEC104ErrorCode sIEC104ErrorCodeDes;
            sIEC104ErrorCodeDes = new iec104types.sIEC104ErrorCode();

            sIEC104ErrorCodeDes.iErrorCode = errorcode;
           
            iec104api.IEC104ErrorCodeString( ref sIEC104ErrorCodeDes);

            string returnmessage = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(sIEC104ErrorCodeDes.LongDes);

            return returnmessage;
        }

        /******************************************************************************
        * Error value - Print information
        ******************************************************************************/
        static string  errorvaluestring(short errorvalue)
        {
            iec104types.sIEC104ErrorValue sIEC104ErrorValueDes;
            sIEC104ErrorValueDes = new iec104types.sIEC104ErrorValue(); 

             sIEC104ErrorValueDes.iErrorValue = errorvalue;

             iec104api.IEC104ErrorValueString(ref sIEC104ErrorValueDes);

             string returnmessage = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(sIEC104ErrorValueDes.LongDes);

             return returnmessage;
        }


        /******************************************************************************
        * main()
        ******************************************************************************/        
        static void Main(string[] args)
        {
            System.DateTime date;                   // update date and time structute
            System.IntPtr iec104serverhandle;       // IEC 60870-5-104 Server object
            iec104types.sIEC104Parameters parameters;    // IEC104 Server object callback paramters 

            System.Console.WriteLine(" \n\t\t**** IEC 60870-5-104 Protocol Server Library Test ****");

            
            try
            {
                if (String.Compare(System.Runtime.InteropServices.Marshal.PtrToStringAnsi(iec104api.IEC104GetLibraryVersion()), iec104api.IEC104_VERSION, true) != 0)
                {
                    System.Console.WriteLine("Error: Version Number Mismatch");
                    System.Console.WriteLine("Library Version is : {0:D}", System.Runtime.InteropServices.Marshal.PtrToStringAnsi(iec104api.IEC104GetLibraryVersion()));
                    System.Console.WriteLine("The Version used is : {0:D}", iec104api.IEC104_VERSION);
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

            System.Console.WriteLine("Library Version is : {0:D}", System.Runtime.InteropServices.Marshal.PtrToStringAnsi(iec104api.IEC104GetLibraryVersion()));
            System.Console.WriteLine("Library Build on   : {0:D}", System.Runtime.InteropServices.Marshal.PtrToStringAnsi(iec104api.IEC104GetLibraryBuildTime()));
            System.Console.WriteLine("Library Licence Information  : {0:D}", System.Runtime.InteropServices.Marshal.PtrToStringAnsi(iec104api.IEC104GetLibraryLicenseInfo()));


            iec104serverhandle = System.IntPtr.Zero;
            parameters = new iec104types.sIEC104Parameters();

            // Initialize IEC 60870-5-104 Server object parameters
            parameters.eAppFlag = tgtcommon.eApplicationFlag.APP_SERVER;                                               // This is a IEC104 Server
            parameters.ptReadCallback = new iec104types.IEC104ReadCallback(cbRead);                                      // Read Callback
            parameters.ptWriteCallback = new iec104types.IEC104WriteCallback(cbWrite);                                   // Write Callback
            parameters.ptUpdateCallback = null;                                                                     // Update Callback
            parameters.ptSelectCallback = new iec104types.IEC104ControlSelectCallback(cbSelect);                         // Select Callback
            parameters.ptOperateCallback = new iec104types.IEC104ControlOperateCallback(cbOperate);                      // Operate Callback
            parameters.ptCancelCallback = new iec104types.IEC104ControlCancelCallback(cbCancel);                         // Cancel Callback
            parameters.ptFreezeCallback = new iec104types.IEC104ControlFreezeCallback(cbFreeze);                         // Freeze Callback
            parameters.ptDebugCallback = new iec104types.IEC104DebugMessageCallback(cbDebug);                            // Debug Callback
            parameters.ptPulseEndActTermCallback = new iec104types.IEC104ControlPulseEndActTermCallback(cbpulseend);     // pulse end callback            
            parameters.ptParameterActCallback = new iec104types.IEC104ParameterActCallback(cbParameterAct);              // Parameter activation callback            
            parameters.ptServerStatusCallback = new iec104types.IEC104ServerStatusCallback(cbServerStatus);              // server status callback
            parameters.ptClientStatusCallback = null;                                                               // client connection status Callback
            parameters.ptDirectoryCallback = null;                                                                  // Directory Callback
            parameters.ptServerFileTransferCallback = cbServerFileTransferCallback;                                 // Function called when server received a new file from client via control direction file transfer
            parameters.u16ObjectId = 1;   																			// Server ID which used in callbacks to identify the iec 104 server object         
            parameters.u32Options = 0;
            short iErrorCode = 0;                                                                                     // API Function return error paramter
            short ptErrorValue = 0;                                                                                 // API Function return addtional error paramter

            do
            {
                // Create a Server object
                iec104serverhandle = iec104api.IEC104Create(ref parameters, ref iErrorCode, ref ptErrorValue);
                if (iec104serverhandle == System.IntPtr.Zero)
                {
                    System.Console.WriteLine("IEC 60870-5-104 Library API Function - Create failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue)); 
                    break;
                }

                // Server load configuration - communication and protocol configuration parameters
                iec104types.sIEC104ConfigurationParameters psIEC104Config;
                psIEC104Config = new iec104types.sIEC104ConfigurationParameters();

                                         

                // Set Server configuration  
                // check Server configuration - TCP/IP Address
                psIEC104Config.sServerSet.sServerConParameters.ai8SourceIPAddress = "127.0.0.1";

                psIEC104Config.sServerSet.sServerConParameters.u16MaxNumberofRemoteConnection = 1;

                iec104types.sIEC104ServerRemoteIPAddressList[] psServerRemoteIPAddressList = new iec104types.sIEC104ServerRemoteIPAddressList[psIEC104Config.sServerSet.sServerConParameters.u16MaxNumberofRemoteConnection];
                
                psIEC104Config.sServerSet.sServerConParameters.psServerRemoteIPAddressList = System.Runtime.InteropServices.Marshal.AllocHGlobal(
                psIEC104Config.sServerSet.sServerConParameters.u16MaxNumberofRemoteConnection * System.Runtime.InteropServices.Marshal.SizeOf(psServerRemoteIPAddressList[0]));
                
                //Remote IP Address , use 0,0.0.0 to accept all remote station ip
                psServerRemoteIPAddressList[0].ai8RemoteIPAddress = "0.0.0.0";

                IntPtr tmp1 = new IntPtr(psIEC104Config.sServerSet.sServerConParameters.psServerRemoteIPAddressList.ToInt64());
                System.Runtime.InteropServices.Marshal.StructureToPtr(psServerRemoteIPAddressList[0], tmp1, true);

                psIEC104Config.sServerSet.sServerConParameters.u16PortNumber = 2404;
                psIEC104Config.sServerSet.sServerConParameters.i16k = 12;
                psIEC104Config.sServerSet.sServerConParameters.i16w = 8;
                psIEC104Config.sServerSet.sServerConParameters.u8t0 = 30;
                psIEC104Config.sServerSet.sServerConParameters.u8t1 = 15;
                psIEC104Config.sServerSet.sServerConParameters.u8t2 = 10;
                psIEC104Config.sServerSet.sServerConParameters.u16t3 = 20;
                psIEC104Config.sServerSet.sServerConParameters.u16EventBufferSize = 50;
                psIEC104Config.sServerSet.sServerConParameters.u32ClockSyncPeriod = 0;
                psIEC104Config.sServerSet.sServerConParameters.bGenerateACTTERMrespond = 1;
                psIEC104Config.sServerSet.sServerConParameters.bEnableRedundancy = 0;
                psIEC104Config.sServerSet.sServerConParameters.ai8RedundSourceIPAddress = "127.0.0.1";
                psIEC104Config.sServerSet.sServerConParameters.ai8RedundRemoteIPAddress = "0.0.0.0";
                psIEC104Config.sServerSet.sServerConParameters.u16RedundPortNumber = 2400;

				
				psIEC104Config.sServerSet.bServerInitiateTCPconnection = 0; // In this server will connect to client, so always FALSE.
                psIEC104Config.sServerSet.u16LongPulseTime = 20000;
                psIEC104Config.sServerSet.u16ShortPulseTime = 5000;

                psIEC104Config.sServerSet.au16CommonAddress = new ushort[iec60870common.MAX_CA];
                psIEC104Config.sServerSet.u8TotalNumberofStations = 1; 
                psIEC104Config.sServerSet.au16CommonAddress[0] = 1;
                psIEC104Config.sServerSet.au16CommonAddress[1] = 0;
                psIEC104Config.sServerSet.au16CommonAddress[2] = 0;
                psIEC104Config.sServerSet.au16CommonAddress[3] = 0;
                psIEC104Config.sServerSet.au16CommonAddress[4] = 0;


                psIEC104Config.sServerSet.bEnableDoubleTransmission = 0;
                psIEC104Config.sServerSet.bEnablefileftransfer = 0;
                psIEC104Config.sServerSet.ai8FileTransferDirPath ="C:\\iec104filetransfer";
                psIEC104Config.sServerSet.u16MaxFilesInDirectory = 10;
                psIEC104Config.sServerSet.bTransmitSpontMeasuredValue = 1;
                psIEC104Config.sServerSet.bTranmitInterrogationMeasuredValue = 1;
                psIEC104Config.sServerSet.bTransmitBackScanMeasuredValue = 1;
                psIEC104Config.sServerSet.benabaleUTCtime = 0;
                psIEC104Config.sServerSet.u8InitialdatabaseQualityFlag = (byte)iec60870common.eIEC870QualityFlags.GD;
                psIEC104Config.sServerSet.eCOTsize = iec60870common.eCauseofTransmissionSize.COT_TWO_BYTE;
                psIEC104Config.sServerSet.bSequencebitSet = 0;
    
#if VIEW_TRAFFIC
				psIEC104Config.sServerSet.sDebug.u32DebugOptions =  (uint)( tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_TX | tgtcommon.eDebugOptionsFlag.DEBUG_OPTION_RX);
                
#else
				psIEC104Config.sServerSet.sDebug.u32DebugOptions = 0;

#endif
                
                psIEC104Config.sServerSet.u16NoofObject = 2;        // Define number of objects

                // Allocate memory for objects
                iec104types.sIEC104Object[] psIEC104Objects = new iec104types.sIEC104Object[psIEC104Config.sServerSet.u16NoofObject];
                psIEC104Config.sServerSet.psIEC104Objects = System.Runtime.InteropServices.Marshal.AllocHGlobal(
                    psIEC104Config.sServerSet.u16NoofObject * System.Runtime.InteropServices.Marshal.SizeOf(psIEC104Objects[0]));
                for (int i = 0; i < psIEC104Config.sServerSet.u16NoofObject; ++i)
                {
                    switch (i)
                    {

                        case 0:
                            psIEC104Objects[i].ai8Name = "Measuredfloat 100-109";
                            psIEC104Objects[i].eTypeID = iec60870common.eIEC870TypeID.M_ME_TF_1;
                            psIEC104Objects[i].u32IOA = 100;
                            psIEC104Objects[i].eIntroCOT = iec60870common.eIEC870COTCause.INRO6;
                            psIEC104Objects[i].u16Range = 10;
                            psIEC104Objects[i].u32CyclicTransTime = 0;
                            psIEC104Objects[i].eControlModel = iec60870common.eControlModelConfig.STATUS_ONLY;
                            psIEC104Objects[i].u32SBOTimeOut    =   0;
                            psIEC104Objects[i].u16CommonAddress =   1;
                            break;

                        case 1:
                            psIEC104Objects[i].ai8Name = "C_SE_TC 100-109";
                            psIEC104Objects[i].eTypeID = iec60870common.eIEC870TypeID.C_SE_TC_1;
                            psIEC104Objects[i].u32IOA = 100;
                            psIEC104Objects[i].eIntroCOT = iec60870common.eIEC870COTCause.NOTUSED;
                            psIEC104Objects[i].u16Range = 10;
                            psIEC104Objects[i].eControlModel = iec60870common.eControlModelConfig.DIRECT_OPERATE;
                            psIEC104Objects[i].u32SBOTimeOut = 0;
                            psIEC104Objects[i].u32CyclicTransTime = 0;
                            psIEC104Objects[i].u16CommonAddress =   1;
                            break;
                    }
                    IntPtr tmp = new IntPtr(psIEC104Config.sServerSet.psIEC104Objects.ToInt64() + i * System.Runtime.InteropServices.Marshal.SizeOf(psIEC104Objects[0]));
                    System.Runtime.InteropServices.Marshal.StructureToPtr(psIEC104Objects[i], tmp, true);
                }

                // Load configuration
                iErrorCode = iec104api.IEC104LoadConfiguration(iec104serverhandle, ref psIEC104Config, ref ptErrorValue);
                if (iErrorCode != 0)
                {
                    System.Console.WriteLine("IEC 60870-5-104 Library API Function - Load Config failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue)); 
                    break;
                }

                // Start Server
                iErrorCode = iec104api.IEC104Start(iec104serverhandle, ref ptErrorValue);
                if (iErrorCode != 0)
                {
                    System.Console.WriteLine("IEC 60870-5-104 Library API Function - Start failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }
#if SIMULATE_UPDATE             
                // update id & parameters        
                ushort uiCount = 1;
                iec104types.sIEC104DataAttributeID[] psDAID = new iec104types.sIEC104DataAttributeID[uiCount];
                iec104types.sIEC104DataAttributeData[] psNewValue = new iec104types.sIEC104DataAttributeData[uiCount];

                psDAID[0].u16CommonAddress = 1;
                psDAID[0].eTypeID = iec60870common.eIEC870TypeID.M_ME_TF_1;
                psDAID[0].u32IOA = 104;
                psDAID[0].pvUserData = IntPtr.Zero;
                psNewValue[0].tQuality = (ushort)iec60870common.eIEC870QualityFlags.GD;
            
                psNewValue[0].pvData = System.Runtime.InteropServices.Marshal.AllocHGlobal((int)tgttypes.eDataSizes.FLOAT32_SIZE);
                psNewValue[0].eDataType = tgtcommon.eDataTypes.FLOAT32_DATA;
                psNewValue[0].eDataSize = tgttypes.eDataSizes.FLOAT32_SIZE;

           
                SingleInt32Union f32data;
                f32data.i = 0;
                f32data.f = 1;
#endif

                System.Console.WriteLine("\r\n Enter CTRL-X to Exit");
                

                while( true )
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

#if SIMULATE_UPDATE 
                        date = DateTime.Now;
                        //current date 
                        psNewValue[0].sTimeStamp.u8Day = (byte)date.Day;
                        psNewValue[0].sTimeStamp.u8Month = (byte)date.Month;
                        psNewValue[0].sTimeStamp.u16Year = (ushort)date.Year;

                        //time
                        psNewValue[0].sTimeStamp.u8Hour = (byte)date.Hour;
                        psNewValue[0].sTimeStamp.u8Minute = (byte)date.Minute;
                        psNewValue[0].sTimeStamp.u8Seconds = (byte)date.Second;
                        psNewValue[0].sTimeStamp.u16MilliSeconds = (ushort)date.Millisecond;
                        psNewValue[0].sTimeStamp.u16MicroSeconds = 0;
                        psNewValue[0].sTimeStamp.i8DSTTime = 0; //No Day light saving time
                        psNewValue[0].sTimeStamp.u8DayoftheWeek = (byte)date.DayOfWeek;


                        f32data.f += 1f;            

                  
                        //Console.WriteLine("Update Measured Float Value {0:F}", f32data.f);

                        System.Runtime.InteropServices.Marshal.WriteInt32(psNewValue[0].pvData, f32data.i);

                        //Update Server
                        iErrorCode = iec104api.IEC104Update(iec104serverhandle, (byte)1, ref psDAID[0], ref psNewValue[0], uiCount, ref ptErrorValue);
                        if (iErrorCode != 0)
                        {
                            Console.WriteLine("IEC 60870-5-104 Library API Function - IEC104Update() failed");
                            System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                            System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                            
                        }
#endif
                        Thread.Sleep(1000);
                    }



                
                }

                Thread.Sleep(1000);

                // Stop Server
                iErrorCode = iec104api.IEC104Stop(iec104serverhandle, ref ptErrorValue);
                if (iErrorCode != 0)
                {
                    System.Console.WriteLine("IEC 60870-5-104 Library API Function - Stop failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }

                Thread.Sleep(1000);

                // Free Server
                iErrorCode = iec104api.IEC104Free(iec104serverhandle, ref ptErrorValue);
                if (iErrorCode != 0)
                {
                    System.Console.WriteLine("IEC 60870-5-104 Library API Function - Free failed");
                    System.Console.WriteLine("iErrorCode {0:D}: {1}", iErrorCode, errorcodestring(iErrorCode));
                    System.Console.WriteLine("iErrorValue {0:D}: {1}", ptErrorValue, errorvaluestring(ptErrorValue));
                    break;
                }

            }while(false);

            System.Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
         
    }            
}
