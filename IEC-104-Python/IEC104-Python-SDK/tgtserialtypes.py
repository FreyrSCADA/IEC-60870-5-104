


import ctypes
from enum import Enum
from structureWithEnums import *



class eSerialTypes(Enum):
    SERIAL_RS232 = 0  # Serial RS 232
    SERIAL_RS485 = 1  # Serial RS485
    SERIAL_RS422 = 2  # Serial RS422

class eSerialWordLength(Enum):
    WORDLEN_7BITS = 7  # Word Length 7 bits
    WORDLEN_8BITS = 8  # Word Length 8 bits

class eSerialStopBits(Enum):
    STOPBIT_1BIT = 1  # Stop bit is 1
    STOPBIT_2BIT = 2  # Stop bits is 2

class eSerialParity(Enum):
    NONE = 0  # No Parity
    ODD = 1   # Odd Parity
    EVEN = 2  # Even Parity

class eLinuxSerialFlowControl(Enum):
    FLOW_NONE = 0  # Disable Flow control
    FLOW_RTS_CTS = 1  # Enable Hardware RTS_CTS Flow control
    FLOW_XON_XOFF = 2  # Enable Software XON_XOFF Flow control

class eSerialBitRate(Enum):
    BITRATE_110 = 1     # Data rate of 110 Bit per second
    BITRATE_300 = 3	 	# Data rate of 300 Bit per second
    BITRATE_1200 = 12 	# Data rate of 1200 Bit per second 
    BITRATE_2400 = 24 	# Data rate of 2400 Bit per second 
    BITRATE_4800 = 48 	# Data rate of 4800 Bit per second 
    BITRATE_9600 = 96 	# Data rate of 9600 Bit per second 
    BITRATE_14400 = 144 	# Data rate of 14400 Bit per second 
    BITRATE_19200 = 192 	# Data rate of 19200 Bit per second 
    BITRATE_28800 = 288 	# Data rate of 28800 Bit per second 
    BITRATE_38400 = 384 	# Data rate of 38400 Bit per second 
    BITRATE_57600 = 576 	# Data rate of 57600 Bit per second 
    BITRATE_115200 = 1152 	# Data rate of 115200 Bit per second 
    BITRATE_230400 = 2304 	# Data rate of 230400 Bit per second     

    # brief Windows RTS control
class eWinRTScontrol(Enum):
        WIN_RTS_CONTROL_DISABLE     = 0	# Lowers the RTS line when the device is opened. The application can use EscapeCommFunction to change the state of the line 
        WIN_RTS_CONTROL_ENABLE      = 1	# Raises the RTS line when the device is opened. The application can use EscapeCommFunction to change the state of the line 
        WIN_RTS_CONTROL_HANDSHAKE   = 2	# Enables RTS flow-control handshaking. The driver raises the RTS line, enabling the DCE to send, when the input buffer has enough room to receive data. The driver lowers the RTS line, preventing the DCE to send, when the input buffer does not have enough room to receive data. If this value is used, it is an error for the application to adjust the line with EscapeCommFunction 
        WIN_RTS_CONTROL_TOGGLE      = 3	# Specifies that the RTS line will be high if bytes are available for transmission. After all buffered bytes have been sent, the RTS line will be low. If this value is set, it would be an error for an application to adjust the line with EscapeCommFunction. This value is ignored in Windows 95; it causes the driver to act as if RTS_CONTROL_ENABLE were specified 
    
    # brief Windows DTR control 
class eWinDTRcontrol(Enum):         
        WIN_DTR_CONTROL_DISABLE     =   0 # Lowers the DTR line when the device is opened. The application can adjust the state of the line with EscapeCommFunction 
        WIN_DTR_CONTROL_ENABLE      =   1 # Raises the DTR line when the device is opened. The application can adjust the state of the line with EscapeCommFunction 
        WIN_DTR_CONTROL_HANDSHAKE   =   2 # Enables DTR flow-control handshaking. If this value is used, it is an error for the application to adjust the line with EscapeCommFunction 
    
    
           
class sSerialFlowControl(StructureWithEnums):
    _fields_ = [("eWinRTS", ctypes.c_int),           #    Windows Property - RTS control property defines setting for RTS pin of RS-232-C  
                ("bWinCTSoutputflow", ctypes.c_bool), #Windows Property - CTS output flow property defines setting for CTS pin of RS-232-C 
                ("eWinDTR", ctypes.c_int),				#Windows Property - DTR control property defines setting for DTR pin of RS-232-C 
                ("bWinDSRoutputflow", ctypes.c_bool),  #Windows Property - DSR output flow property defines setting for DSR pin of RS-232-C 
                ("eLinuxFlowControl", ctypes.c_int)]   #Flow Control for linux - more detail https://www.cmrr.umn.edu/~strupp/serial.html 
    map = {
        "eWinRTS": eWinRTScontrol, "eWinDTR": eWinDTRcontrol, "eLinuxFlowControl": eLinuxSerialFlowControl
    }       
                
                
class sSerialTimeParameters(ctypes.Structure):
    _fields_ = [("u16PreDelay", ctypes.c_ushort),             # Delay before send or receive 
                ("u16PostDelay", ctypes.c_ushort),           # Delay after send or receive 
                ("u16InterCharacterDelay", ctypes.c_ushort), # Delay between characters during send or receive 
                ("u16CharacterTimeout", ctypes.c_ushort),   # Timeout if the character is not being sent or received 
                ("u8CharacterRetries", ctypes.c_ubyte),     # Number of retries to send or receive a character 
                ("u16MessageTimeout", ctypes.c_ushort),     # Message Timeout if entire message is not sent or received 
                ("u8MessageRetries", ctypes.c_ubyte),      # Message Retries to retry the entire message 
                ("u32Baud", ctypes.c_uint32)                 # Bits per second used to calculate post transmit delay for RS485 
                ]               
                
                
class sSerialCommunicationSettings(StructureWithEnums):
    _fields_ = [("eSerialType", ctypes.c_int),           # Serial Type
        ("eWordLength", ctypes.c_int),         # Serial Word Length 
        ("eStopBits", ctypes.c_int),           # Serial Stop Bits
        ("eSerialParity", ctypes.c_int),       # Serial Parity 
        ("eSerialBitRate", ctypes.c_int),      # Serial Bit Rate 
        ("u16SerialPortNumber", ctypes.c_ushort),   					# Serial COM port number
        ("u16InterMessageDelay", ctypes.c_ushort),  					# Time between sending and receiving of message only applies after transmitting the message 
        ("sFlowControl", sSerialFlowControl),         # Flow Control 
        ("sTxTimeParam", sSerialTimeParameters),          # Transmission Time parameters 
        ("sRxTimeParam", sSerialTimeParameters)]          # Reception Time parameters 
    map = {
        "eSerialType": eSerialTypes, "eWordLength": eSerialWordLength, "eStopBits": eSerialStopBits, "eSerialParity": eSerialParity, "eSerialBitRate": eSerialBitRate
    }  



  
        
     