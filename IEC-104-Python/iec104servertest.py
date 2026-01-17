import ctypes 
import time
import struct
import sys
import keyboard
from pyiec104.iec104api import *

# enbale to view traffic
VIEW_TRAFFIC = 1

# print the struct sIEC104DataAttributeID and sIEC104DataAttributeData
def vPrintDataInformation(psIEC104DataAttributeID , psIEC104DataAttributeData ):
    print(f" IP Address {psIEC104DataAttributeID.contents.ai8IPAddress}")
    print(f" Port Number {psIEC104DataAttributeID.contents.u16PortNumber}")
    print(f" Common Address {psIEC104DataAttributeID.contents.u16CommonAddress}")
    print(f" Typeid ID is {psIEC104DataAttributeID.contents.eTypeID} IOA   {psIEC104DataAttributeID.contents.u32IOA}")
    print(f" Datatype->{psIEC104DataAttributeData.contents.eDataType} Datasize->{ psIEC104DataAttributeData.contents.eDataSize}" )

    if(psIEC104DataAttributeData.contents.tQuality) != eIEC870QualityFlags.GD :
        if(psIEC104DataAttributeData.contents.tQuality & eIEC870QualityFlags.IV) == eIEC870QualityFlags.IV:
            print(" IEC_INVALID_FLAG")
        if(psIEC104DataAttributeData.contents.tQuality & eIEC870QualityFlags.NT) == eIEC870QualityFlags.NT:
             print(" IEC_NONTOPICAL_FLAG")
        if(psIEC104DataAttributeData.contents.tQuality & eIEC870QualityFlags.SB) == eIEC870QualityFlags.SB:
             print(" IEC_SUBSTITUTED_FLAG")
        if(psIEC104DataAttributeData.contents.tQuality & eIEC870QualityFlags.BL) == eIEC870QualityFlags.BL:
             print(" IEC_BLOCKED_FLAG")

    data_type = psIEC104DataAttributeData.contents.eDataType

    if data_type in (eDataTypes.SINGLE_POINT_DATA, eDataTypes.DOUBLE_POINT_DATA, eDataTypes.UNSIGNED_BYTE_DATA):
        data = bytearray(ctypes.string_at(psIEC104DataAttributeData.contents.pvData, 1))
        u8data = struct.unpack('B', data)[0] 
        print(f" Data : {u8data}")

    elif data_type == eDataTypes.SIGNED_BYTE_DATA:
        data = bytearray(ctypes.string_at(psIEC104DataAttributeData.contents.pvData, 1))
        i8data = struct.unpack('b', data)[0]        
        print(f" Data : {i8data}")

    elif data_type == eDataTypes.UNSIGNED_WORD_DATA:
        data = bytearray(ctypes.string_at(psIEC104DataAttributeData.contents.pvData, 2))
        u16data = struct.unpack('H', data)[0]        
        print(f" Data : {u16data}")

    elif data_type == eDataTypes.SIGNED_WORD_DATA:
        data = bytearray(ctypes.string_at(psIEC104DataAttributeData.contents.pvData, 2))
        i16data = struct.unpack('h', data)[0]        
        print(f" Data : {i16data}")

    elif data_type == eDataTypes.UNSIGNED_DWORD_DATA:
        data = bytearray(ctypes.string_at(psIEC104DataAttributeData.contents.pvData, 4))
        u32data = struct.unpack('I', data)[0]        
        print(f" Data : {u32data}")


    elif data_type == eDataTypes.SIGNED_DWORD_DATA:
        data = bytearray(ctypes.string_at(psIEC104DataAttributeData.contents.pvData, 4))
        i32data = struct.unpack('i', data)[0]        
        print(f" Data : {i32data}")

    elif data_type == eDataTypes.FLOAT32_DATA:
        data = bytearray(ctypes.string_at(psIEC104DataAttributeData.contents.pvData, 4))
        f32data = struct.unpack('f', data)[0] 
        print(f" Data : {f32data:.3f}")

    if psIEC104DataAttributeData.contents.sTimeStamp.u16Year != 0:
        print(f" Date : {psIEC104DataAttributeData.contents.sTimeStamp.u8Day:02}-{psIEC104DataAttributeData.contents.sTimeStamp.u8Month:02}-{psIEC104DataAttributeData.contents.sTimeStamp.u16Year:04}  DOW -{psIEC104DataAttributeData.contents.sTimeStamp.u8DayoftheWeek}")
        print(f" Time : {psIEC104DataAttributeData.contents.sTimeStamp.u8Hour:02}:{psIEC104DataAttributeData.contents.sTimeStamp.u8Minute:02}:{psIEC104DataAttributeData.contents.sTimeStamp.u8Seconds:02}:{psIEC104DataAttributeData.contents.sTimeStamp.u16MilliSeconds:03}")

# iec104 read callback 
def cbRead(u16ObjectId, psIEC104DataAttributeID, psIEC104DataAttributeData , psReadParams, ptErrorValue):
    i16rErrorCode = ctypes.c_short()
    i16rErrorCode = 0   
    print(" cbRead() called - Read Command from IEC104 client")
    print(" Server ID : %u" % u16ObjectId)
    vPrintDataInformation(psIEC104DataAttributeID, psIEC104DataAttributeData)
    message = f"Orginator Address {psReadParams.contents.u8OrginatorAddress}"
    print(message)
    return i16rErrorCode

# iec104 write callback 
def cbWrite(u16ObjectId, psIEC104DataAttributeID, psIEC104DataAttributeData, psIEC104WriteParameters, ptErrorValue):
    i16rErrorCode = ctypes.c_short()
    i16rErrorCode = 0   
    print(" cbWrite() called - Clock Sync Command from IEC104 client")
    print(" Server ID : %u" % u16ObjectId)
    vPrintDataInformation(psIEC104DataAttributeID, psIEC104DataAttributeData)
    message = f"Orginator Address {psIEC104WriteParameters.contents.u8OrginatorAddress}"
    print(message)
    return i16rErrorCode

# Freeze Callback
def cbFreeze( u16ObjectId, eCounterFreeze, psIEC104DataAttributeID , psIEC104DataAttributeData , psIEC104WriteParameters , ptErrorValue):

    i16rErrorCode = ctypes.c_short()
    i16rErrorCode = 0   
    print(" cbFreeze() called - freeze Command from IEC104 client")  

    print(" Server ID : %u" % u16ObjectId)
    vPrintDataInformation(psIEC104DataAttributeID, psIEC104DataAttributeData)
    message = f"Orginator Address {psIEC104WriteParameters.contents.u8OrginatorAddress}"
    print(message)

    print(f" Command Typeid : {psIEC104DataAttributeID.contents.eTypeID}")
    print(f" COT : {psIEC104WriteParameters.contents.eCause}")   

    return i16rErrorCode

# Select callback
def cbSelect(u16ObjectId, psIEC104DataAttributeID , psIEC104DataAttributeData ,psIEC104CommandParameters , ptErrorValue):

    i16rErrorCode = ctypes.c_short()
    i16rErrorCode = 0   
    print(" cbSelect() called - select Command from IEC104 client")

    print(" Server ID : %u" % u16ObjectId)
    vPrintDataInformation(psIEC104DataAttributeID, psIEC104DataAttributeData)
    message = f"Orginator Address {psIEC104CommandParameters.contents.u8OrginatorAddress}"
    print(message)
    
    print(f" Qualifier : {psIEC104CommandParameters.contents.eQOCQU}" )
    print(f" Pulse Duration : {psIEC104CommandParameters.contents.u32PulseDuration}" )

    return i16rErrorCode

# Operate callback
def cbOperate(u16ObjectId, psIEC104DataAttributeID , psIEC104DataAttributeData ,psIEC104CommandParameters , ptErrorValue):

    i16rErrorCode = ctypes.c_short()
    i16rErrorCode = 0   
    print(" cbOperate() called - operate Command from IEC104 client")

    print(" Server ID : %u" % u16ObjectId)
    vPrintDataInformation(psIEC104DataAttributeID, psIEC104DataAttributeData)
    message = f"Orginator Address {psIEC104CommandParameters.contents.u8OrginatorAddress}"
    print(message)

    print(f" Qualifier : {psIEC104CommandParameters.contents.eQOCQU}")
    print(f" Pulse Duration : {psIEC104CommandParameters.contents.u32PulseDuration}")
   

    return i16rErrorCode

# Operate pulse end callback
def cbpulseend(u16ObjectId, psIEC104DataAttributeID , psIEC104DataAttributeData ,psIEC104CommandParameters , ptErrorValue):

    i16rErrorCode = ctypes.c_short()
    i16rErrorCode = 0   
    print(" cbpulseend() called - pulse end Command from IEC104 client")


    print(" Server ID : %u" % u16ObjectId)
    vPrintDataInformation(psIEC104DataAttributeID, psIEC104DataAttributeData)
    message = f"Orginator Address {psIEC104CommandParameters.contents.u8OrginatorAddress}"
    print(message)

    print(f" Qualifier : {psIEC104CommandParameters.contents.eQOCQU}")
    print(f" Pulse Duration : {psIEC104CommandParameters.contents.u32PulseDuration}")
   

    return i16rErrorCode

# Cancel callback
def cbCancel(u16ObjectId, eOperation, psIEC104DataAttributeID , psIEC104DataAttributeData ,psIEC104CommandParameters , ptErrorValue):

    i16rErrorCode = ctypes.c_short()
    i16rErrorCode = 0   
    print(" cbCancel() called - cancel Command from IEC104 client")

    print(" Server ID : %u" % u16ObjectId)
    vPrintDataInformation(psIEC104DataAttributeID, psIEC104DataAttributeData)
    message = f"Orginator Address {psIEC104CommandParameters.contents.u8OrginatorAddress}"
    print(message)


    if eOperation   ==  eOperationFlag.OPERATE:
        print(" Operate operation to be cancel")
    elif eOperation   ==  eOperationFlag.SELECT:
        print(" Select operation to cancel")

    print(f" Qualifier : {psIEC104CommandParameters.contents.eQOCQU}")
    print(f" Pulse Duration :{psIEC104CommandParameters.contents.u32PulseDuration}")
    

    return i16rErrorCode

# Parameteract callback
def cbParameterAct(u16ObjectId, psIEC104DataAttributeID , psIEC104DataAttributeData , psIEC104ParameterActParameters , ptErrorValue):

    i16rErrorCode = ctypes.c_short()
    i16rErrorCode = 0   
    print(" cbParameterAct called - parameter act Command from IEC104 client")

    print(" Server ID : %u" % u16ObjectId)
    vPrintDataInformation(psIEC104DataAttributeID, psIEC104DataAttributeData)
    message = f"Orginator Address {psIEC104ParameterActParameters.contents.u8OrginatorAddress}"
    print(message)

    print(f" Qualifier of Parameter Activation/Kind of Parameter - {psIEC104ParameterActParameters.contents.u8QPA}")
    

    return i16rErrorCode

# Debug callback
def cbDebug(u16ObjectId,  psIEC104DebugData , ptErrorValue):
    i16rErrorCode = ctypes.c_short()
    i16rErrorCode = 0 

    u16nav = ctypes.c_ushort()
    u16nav = 0
    
   
    #printf(" cbDebug() called");
    
    print(f"{psIEC104DebugData.contents.sTimeStamp.u8Hour}:{psIEC104DebugData.contents.sTimeStamp.u8Minute}:{psIEC104DebugData.contents.sTimeStamp.u8Seconds} Server ID: {u16ObjectId}", end='')

    if (psIEC104DebugData.contents.u32DebugOptions & eDebugOptionsFlag.DEBUG_OPTION_TX) == eDebugOptionsFlag.DEBUG_OPTION_TX:
        print(f" IP {psIEC104DebugData.contents.ai8IPAddress} Port {psIEC104DebugData.contents.u16PortNumber}", end='')
        print(f" -> ", end='')
        
        #print(f"u16TxCount - {psIEC104DebugData.contents.u16TxCount} len aaray - {len(psIEC104DebugData.contents.au8TxData)}")
        

        for u16nav in range(psIEC104DebugData.contents.u16TxCount):
            print(f" {psIEC104DebugData.contents.au8TxData[u16nav]:02x}", end='')
        

        
    if (psIEC104DebugData.contents.u32DebugOptions & eDebugOptionsFlag.DEBUG_OPTION_RX) == eDebugOptionsFlag.DEBUG_OPTION_RX:
        print(f" IP {psIEC104DebugData.contents.ai8IPAddress} Port {psIEC104DebugData.contents.u16PortNumber}", end='')
        print(" <-", end='')

        #print(f"u16RxCount - {psIEC104DebugData.contents.u16RxCount} len aaray - {len(psIEC104DebugData.contents.au8RxData)}")

        
        for u16nav in range(psIEC104DebugData.contents.u16RxCount):
            print(f" {psIEC104DebugData.contents.au8RxData[u16nav]:02x}", end='')
        

        
    if (psIEC104DebugData.contents.u32DebugOptions & eDebugOptionsFlag.DEBUG_OPTION_ERROR) == eDebugOptionsFlag.DEBUG_OPTION_ERROR:
        print(f" Error message {psIEC104DebugData.contents.au8ErrorMessage}")
        print(f" ErrorCode {psIEC104DebugData.contents.iErrorCode}")
        print(f" ErrorValue {psIEC104DebugData.contents.tErrorvalue}")

    print("", flush=True)

    
    return i16rErrorCode

# Server Status Callback
def cbServerStatus(u16ObjectId, psIEC104ServerConnectionID , peSat, ptErrorValue):

    i16rErrorCode = ctypes.c_short()
    i16rErrorCode = 0   
    print(" cbServerStatus called ")

    print(" Server ID : %u" % u16ObjectId)

    if peSat.contents.value == eStatus.CONNECTED:
        print(" Status - Connected")
    else:
        print(" Status - Disconnected")
    
    print(f" Source IP Address %s Port %u " % (psIEC104ServerConnectionID.contents.ai8SourceIPAddress, psIEC104ServerConnectionID.contents.u16SourcePortNumber))
    print(f" Remote IP Address %s Port %u " % (psIEC104ServerConnectionID.contents.ai8RemoteIPAddress, psIEC104ServerConnectionID.contents.u16RemotePortNumber))

    return i16rErrorCode

# print error code and description
def errorcodestring(errorcode):
    sIEC104ErrorCodeDes = sIEC104ErrorCode()
    sIEC104ErrorCodeDes.iErrorCode = errorcode
    iec104_lib.IEC104ErrorCodeString(sIEC104ErrorCodeDes)
    return sIEC104ErrorCodeDes.LongDes.decode("utf-8")

# print error value and description
def errorvaluestring(errorvalue):
    sIEC104ErrorValueDes = sIEC104ErrorValue()
    sIEC104ErrorValueDes.iErrorValue = errorvalue   
    iec104_lib.IEC104ErrorValueString(sIEC104ErrorValueDes)
    return sIEC104ErrorValueDes.LongDes.decode("utf-8")

# update particular typeid and IOA FROM USER INPUT
def update(myServer):

    i16ErrorCode = ctypes.c_short()
    tErrorValue =  ctypes.c_short()
    
    print("UPDATE CALLED")
    while True:
        try:
            u32ioa = ctypes.c_uint32(int(input("MeasuredFloat(M_ME_TF_1) Enter Information object address(IOA)- 100 to 109 ")))
        except ValueError:
            print("Please enter a number 100 to 109")
        else:
            break

    while True:
        try:
            f32value = ctypes.c_float(float(input("Enter update float value: ")))
        except ValueError:
            print("Please enter a float number ")
        else:
            break

   
    psDAID = sIEC104DataAttributeID()
    psNewValue  = sIEC104DataAttributeData()

    psDAID.u16CommonAddress                     =  1
    psDAID.eTypeID                              =  eIEC870TypeID.M_ME_TF_1
    psDAID.u32IOA                               =   u32ioa
    psDAID.pvUserData                           =   None
    psNewValue.tQuality                         =   eIEC870QualityFlags.GD

    #psNewValue.pvData                           =   ctypes.cast(ctypes.pointer(f32value),ctypes.c_void_p)
    psNewValue.pvData = ctypes.c_void_p(ctypes.addressof(f32value))
    
    psNewValue.eDataType                        =   eDataTypes.FLOAT32_DATA
    psNewValue.eDataSize                        =   eDataSizes.FLOAT32_SIZE

    now = time.time()
    timeinfo = time.localtime(now)
    
    #current date
    psNewValue.sTimeStamp.u8Day = timeinfo.tm_mday
    psNewValue.sTimeStamp.u8Month = timeinfo.tm_mon
    psNewValue.sTimeStamp.u16Year = timeinfo.tm_year 

    psNewValue.sTimeStamp.u8Hour = timeinfo.tm_hour
    psNewValue.sTimeStamp.u8Minute = timeinfo.tm_min
    psNewValue.sTimeStamp.u8Seconds = timeinfo.tm_sec
    psNewValue.sTimeStamp.u16MilliSeconds = 0
    psNewValue.sTimeStamp.u16MicroSeconds = 0
    psNewValue.sTimeStamp.i8DSTTime = 0
    psNewValue.sTimeStamp.u8DayoftheWeek = 4
    psNewValue.bTimeInvalid = False

    #printf(" update float value %f",f32data);
    # Update server
   
    i16ErrorCode = iec104_lib.IEC104Update(myServer, True,ctypes.byref(psDAID),ctypes.byref(psNewValue),1,ctypes.byref((tErrorValue)))
    if i16ErrorCode != 0:
        message = f"IEC 60870-5-104 Library API Function - IEC104Update() failed: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message)     

    else:
        message = f"IEC 60870-5-104 Library API Function - IEC104Update() success: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message) 


# main program
def main():
    print(" \t\t**** IEC 60870-5-104 Protocol Server Library Test ****")
    # Check library version against the library header file
    if iec104_lib.IEC104GetLibraryVersion().decode("utf-8") != IEC104_VERSION:
        print(" Error: Version Number Mismatch")
        print(" Library Version is  : {}".format(iec104_lib.IEC104GetLibraryVersion().decode("utf-8")))
        print(" The Header Version used is : {}".format(IEC104_VERSION))
        print("")
        input(" Press Enter to free IEC 104 Server object")
        exit(0)

    print("Library Version is : {}".format(iec104_lib.IEC104GetLibraryVersion().decode("utf-8")))
    print("Library Build on   : {}".format(iec104_lib.IEC104GetLibraryBuildTime().decode("utf-8")))
    print("Library License Information   : {}\r\n".format(iec104_lib.IEC104GetLibraryLicenseInfo().decode("utf-8")))

    i16ErrorCode = ctypes.c_short()
    tErrorValue =  ctypes.c_short()
    sParameters = sIEC104Parameters()

   

    # Initialize IEC 60870-5-104 Server object parameters
    sParameters.eAppFlag          =  eApplicationFlag.APP_SERVER        # This is a IEC104 Server      
    sParameters.ptReadCallback    = IEC104ReadCallback(cbRead)               # Read Callback
    sParameters.ptWriteCallback   = IEC104WriteCallback(cbWrite)                # Write Callback
    sParameters.ptUpdateCallback  = ctypes.cast(None,IEC104UpdateCallback) #IEC104UpdateCallback(0)                 # Update Callback
    sParameters.ptSelectCallback  = IEC104ControlSelectCallback(cbSelect)               # Select Callback
    sParameters.ptOperateCallback = IEC104ControlOperateCallback(cbOperate)              # Operate Callback
    sParameters.ptCancelCallback  = IEC104ControlCancelCallback(cbCancel)              # Cancel Callback
    sParameters.ptFreezeCallback  = IEC104ControlFreezeCallback(cbFreeze)              # Freeze Callback
    sParameters.ptDebugCallback   = IEC104DebugMessageCallback(cbDebug)                # Debug Callback
    sParameters.ptPulseEndActTermCallback = IEC104ControlPulseEndActTermCallback(cbpulseend)    # pulse end callback
    sParameters.ptParameterActCallback = IEC104ParameterActCallback(cbParameterAct)   # Parameter activation callback
    sParameters.ptServerStatusCallback = IEC104ServerStatusCallback(cbServerStatus)   # server status callback
    sParameters.ptDirectoryCallback    = IEC104DirectoryCallback(0)              # Directory Callback
    sParameters.ptClientStatusCallback   = IEC104ClientStatusCallback(0)           # client connection status Callback
    sParameters.u32Options        = 0
    sParameters.u16ObjectId				= 1				#Server ID which used in callbacks to identify the iec 104 server object   


    # Create a server object

    myServer =  iec104_lib.IEC104Create(ctypes.byref(sParameters), ctypes.byref((i16ErrorCode)), ctypes.byref((tErrorValue)))
    if i16ErrorCode.value != 0:
        message = f"IEC 60870-5-104 Library API Function - IEC104Create() failed: {i16ErrorCode.value} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message)    
        exit(0) 
    else:
        message = f"IEC 60870-5-104 Library API Function - IEC104Create() success: {i16ErrorCode.value} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message) 

    while(True):

        sIEC104Config = sIEC104ConfigurationParameters()

        sIEC104Config.sServerSet.sServerConParameters.ai8SourceIPAddress = "127.0.0.1".encode('utf-8') # own server bind address
        sIEC104Config.sServerSet.sServerConParameters.u16PortNumber             =   2404

        sIEC104Config.sServerSet.sServerConParameters.u16MaxNumberofRemoteConnection = 1

        arraypointer = ( sIEC104ServerRemoteIPAddressList * sIEC104Config.sServerSet.sServerConParameters.u16MaxNumberofRemoteConnection)()

        sIEC104Config.sServerSet.sServerConParameters.psServerRemoteIPAddressList = ctypes.cast(arraypointer, ctypes.POINTER(sIEC104ServerRemoteIPAddressList))


        arraypointer[0].ai8RemoteIPAddress = "0.0.0.0".encode('utf-8')

        
        sIEC104Config.sServerSet.sServerConParameters.u16PortNumber = 2404
        sIEC104Config.sServerSet.sServerConParameters.i16k = 12
        sIEC104Config.sServerSet.sServerConParameters.i16w = 8
        sIEC104Config.sServerSet.sServerConParameters.u8t0 = 30
        sIEC104Config.sServerSet.sServerConParameters.u8t1 = 15
        sIEC104Config.sServerSet.sServerConParameters.u8t2 = 10
        sIEC104Config.sServerSet.sServerConParameters.u16t3 = 20
        sIEC104Config.sServerSet.sServerConParameters.u16EventBufferSize = 50
        sIEC104Config.sServerSet.sServerConParameters.u32ClockSyncPeriod = 0
        sIEC104Config.sServerSet.sServerConParameters.bGenerateACTTERMrespond = True
        sIEC104Config.sServerSet.sServerConParameters.bEnableRedundancy = False
        sIEC104Config.sServerSet.sServerConParameters.ai8RedundSourceIPAddress = "127.0.0.1".encode('utf-8')
        sIEC104Config.sServerSet.sServerConParameters.ai8RedundRemoteIPAddress = "0.0.0.0".encode('utf-8')
        sIEC104Config.sServerSet.sServerConParameters.u16RedundPortNumber = 2400

        sIEC104Config.sServerSet.bServerInitiateTCPconnection = False; # In this server will connect to client, so always FALSE.
        sIEC104Config.sServerSet.u16LongPulseTime = 20000
        sIEC104Config.sServerSet.u16ShortPulseTime = 5000

        sIEC104Config.sServerSet.u8TotalNumberofStations    =   1
        sIEC104Config.sServerSet.au16CommonAddress[0]   =   1
        sIEC104Config.sServerSet.au16CommonAddress[1]   =   0
        sIEC104Config.sServerSet.au16CommonAddress[2]   =   0
        sIEC104Config.sServerSet.au16CommonAddress[3]   =   0
        sIEC104Config.sServerSet.au16CommonAddress[4]   =   0


        sIEC104Config.sServerSet.sServerConParameters.bGenerateACTTERMrespond   =   True
        sIEC104Config.sServerSet.bEnableDoubleTransmission = False

        sIEC104Config.sServerSet.bEnablefileftransfer   = False
        sIEC104Config.sServerSet.ai8FileTransferDirPath = "\\FileTransferServer".encode('utf-8')
        sIEC104Config.sServerSet.u16MaxFilesInDirectory     =   10

        sIEC104Config.sServerSet.sServerConParameters.bEnableRedundancy =   False
        sIEC104Config.sServerSet.sServerConParameters.ai8RedundSourceIPAddress = "127.0.0.1".encode('utf-8')
        sIEC104Config.sServerSet.sServerConParameters.ai8RedundRemoteIPAddress = "0.0.0.0".encode('utf-8')
        sIEC104Config.sServerSet.sServerConParameters.u16RedundPortNumber      =   2400

        sIEC104Config.sServerSet.bTransmitSpontMeasuredValue = True
        sIEC104Config.sServerSet.bTranmitInterrogationMeasuredValue = True
        sIEC104Config.sServerSet.bTransmitBackScanMeasuredValue = True
        sIEC104Config.sServerSet.eCOTsize = eCauseofTransmissionSize.COT_TWO_BYTE
        sIEC104Config.sServerSet.bSequencebitSet = False

        
        # Debug option settings
        if  'VIEW_TRAFFIC' in globals():
            sIEC104Config.sServerSet.sDebug.u32DebugOptions   =   (eDebugOptionsFlag.DEBUG_OPTION_RX | eDebugOptionsFlag.DEBUG_OPTION_TX)
        else:
            sIEC104Config.sServerSet.sDebug.u32DebugOptions  =   0


        
        sIEC104Config.sServerSet.benabaleUTCtime =  False
        sIEC104Config.sServerSet.u8InitialdatabaseQualityFlag   =   eIEC870QualityFlags.GD     

        sIEC104Config.sServerSet.bServerInitiateTCPconnection = False


        # configure number of point in server database
        sIEC104Config.sServerSet.u16NoofObject              =   2        # Define number of objects
        sIEC104Config.sServerSet.psIEC104Objects  = ( sIEC104Object * sIEC104Config.sServerSet.u16NoofObject)()

        sIEC104Config.sServerSet.psIEC104Objects[0].ai8Name = "M_ME_TF_1 100-109".encode('utf-8')
        sIEC104Config.sServerSet.psIEC104Objects[0].eTypeID     =  eIEC870TypeID.M_ME_TF_1
        sIEC104Config.sServerSet.psIEC104Objects[0].u32IOA          = 100
        sIEC104Config.sServerSet.psIEC104Objects[0].u16Range        = 10
        sIEC104Config.sServerSet.psIEC104Objects[0].eIntroCOT       = eIEC870COTCause.INRO6
        sIEC104Config.sServerSet.psIEC104Objects[0].eControlModel   =   eControlModelConfig.STATUS_ONLY
        sIEC104Config.sServerSet.psIEC104Objects[0].u32SBOTimeOut   =   0
        sIEC104Config.sServerSet.psIEC104Objects[0].u16CommonAddress    =   1

        #Second object detail
        sIEC104Config.sServerSet.psIEC104Objects[1].ai8Name = "C_SE_TC_1".encode('utf-8')
        sIEC104Config.sServerSet.psIEC104Objects[1].eTypeID     =  eIEC870TypeID.C_SE_TC_1
        sIEC104Config.sServerSet.psIEC104Objects[1].u32IOA          = 100
        sIEC104Config.sServerSet.psIEC104Objects[1].eIntroCOT       = eIEC870COTCause.NOTUSED
        sIEC104Config.sServerSet.psIEC104Objects[1].u16Range        = 10
        sIEC104Config.sServerSet.psIEC104Objects[1].eControlModel  = eControlModelConfig.DIRECT_OPERATE
        sIEC104Config.sServerSet.psIEC104Objects[1].u32SBOTimeOut   = 0
        sIEC104Config.sServerSet.psIEC104Objects[1].u16CommonAddress    =   1

            

        i16ErrorCode =  iec104_lib.IEC104LoadConfiguration(myServer, ctypes.byref(sIEC104Config), ctypes.byref((tErrorValue)))
        if i16ErrorCode != 0:
            message = f"IEC 60870-5-104 Library API Function - IEC104IEC104LoadConfiguration() failed: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
            print(message)    
            break

        else:
            message = f"IEC 60870-5-104 Library API Function - IEC104IEC104LoadConfiguration() success: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
            print(message) 



        i16ErrorCode =  iec104_lib.IEC104Start(myServer, ctypes.byref((tErrorValue)))
        if i16ErrorCode != 0:
            message = f"IEC 60870-5-104 Library API Function - IEC104Start() failed: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
            print(message)    
            break

        else:
            message = f"IEC 60870-5-104 Library API Function - IEC104Start() success: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
            print(message) 

        print("press x to exit")

        while(True):
            if keyboard.is_pressed('x'):
                print("x pressed, exiting main program")
                keyboard.release('x')
                time.sleep(0.1)
                break
            elif keyboard.is_pressed('u'):
                print("u pressed, update called")
                keyboard.release('u')
                time.sleep(0.1)
                update(myServer)

            #Xprint("sleep called")
            time.sleep(50 /1000)

        break
            
            

      


    # iec 104 stop api fn
    i16ErrorCode =  iec104_lib.IEC104Stop(myServer, ctypes.byref((tErrorValue)))
    if i16ErrorCode != 0:
        message = f"IEC 60870-5-104 Library API Function - IEC104Stop() failed: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message)        
    else:
        message = f"IEC 60870-5-104 Library API Function - IEC104Stop() success: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message) 


     # iec 104 free api fn
    i16ErrorCode =  iec104_lib.IEC104Free(myServer, ctypes.byref((tErrorValue)))
    if i16ErrorCode != 0:
        message = f"IEC 60870-5-104 Library API Function - IEC104Free() failed: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message)    
    else:
        message = f"IEC 60870-5-104 Library API Function - IEC104Free() success: {i16ErrorCode} - {errorcodestring(i16ErrorCode)}, {tErrorValue.value} - {errorvaluestring(tErrorValue)}"
        print(message) 


    print("Exiting the program...")
    

if __name__ == "__main__":
    main()