
import ctypes
from enum import *

    #  Max Size of Object Name 
APP_OBJNAMESIZE  =       48



     # Application Object State  

class eAppState(Enum):     
         APP_STATE_UNKNOWN           = 0            # A Unknown Object 
         APP_STATE_NEW               = 1            # A Newly create Object 
         APP_STATE_LOADED            = 2            # Object is loaded with a config and ready to run 
         APP_STATE_RUNNING           = 3            # Object is running  
         APP_STATE_STOPPED           = 4            # Object Stopped 
         APP_STATE_FREED             = 5            # Object freed  
     

         #  Time Quality flag 
class eTimeQualityFlags(Enum):    
        TIME_ASSUMED                        = 0# TIME   Assumed, not reported
        TIME_REPORTED                       = 1# TIME   reported. 

    

     # Application Flag 
class eApplicationFlag(IntEnum):     
        APP_SERVER          =   1# Server Application 
        APP_CLIENT          =   2# Client Application 
        APP_SERVERCLIENT    =   3# ServerClient Application 
     

    # Data types 
class eDataTypes(IntEnum):    
        UNSUPPORTED_DATA        = 0# Unsupported                        (0 Bit)                   
        SINGLE_POINT_DATA       = 1# Single Point Data Type             (1 Bit)     
        DOUBLE_POINT_DATA       = 2# Double Point  Data Type            (2 Bits)      
        UNSIGNED_BYTE_DATA      = 3# Unsigned Byte Data Type            (8 Bits)      
        SIGNED_BYTE_DATA        = 4# Signed Byte Data Type              (8 Bits)              
        UNSIGNED_WORD_DATA      = 5# Unsigned Word Data Type            (16 Bits)     
        SIGNED_WORD_DATA        = 6# Signed Word Data Type              (16 Bits)             
        UNSIGNED_DWORD_DATA     = 7# Unsigned Double Word Data Type     (32 Bits)             
        SIGNED_DWORD_DATA       = 8# Signed Double Word Data Type       (32 Bits)    
        UNSIGNED_LWORD_DATA     = 9# Unsigned Long word Data Type       (64 Bits)   
        SIGNED_LWORD_DATA       = 10# Singed long word Data Type         (64 Bits)   
        UNSIGNED_LLWORD_DATA    = 11# Unsigned Long Long Word Data Type  (128 Bits)  
        SIGNED_LLWORD_DATA      = 12# Signed Long Long Word Data Type    (128 Bits)  
        FLOAT32_DATA            = 13# Float 32 Data Type                 (32 Bits)    
        FLOAT64_DATA            = 14# Float 64 Data Type                 (64 Bits)   
        FLOAT128_DATA           = 15# Float 128 Data Type                (128 Bits)  
        VISIBLE_STRING_DATA     = 16# Visible String Data Type           (2040 Bits)  
        MAX_DATATYPES = 17
    

    #   Debug options flag 
class eDebugOptionsFlag(IntEnum):    
        DEBUG_OPTION_NONE                               = 0x0000# No options set 
        DEBUG_OPTION_ERROR                              = 0x0001# Error Messages only 
        DEBUG_OPTION_WARNING                            = 0x0002# Warning Message only      
        DEBUG_OPTION_RX                                 = 0x0004# Rx Messages 
        DEBUG_OPTION_TX                                 = 0x0008# Tx Messages 
        

        
    # SET Time Structure       
class sTargetTimeStamp(ctypes.Structure):
    _fields_ = [("u8Day", ctypes.c_ubyte),              # Day 1 to 31 
        ("u8Month", ctypes.c_ubyte),            # Month 1 to 12 
        ("u16Year",ctypes.c_ushort),            # Year 1970 to 9999 
        ("u8DayoftheWeek", ctypes.c_ubyte),     # 0 = Not Used Day of the week Mon = 1 to Sun = 7 
        ("u8Hour", ctypes.c_ubyte),             # Hour 0 to 23 
        ("u8Minute", ctypes.c_ubyte),           # Minutes 0 to 59 
        ("u8Seconds", ctypes.c_ubyte),          # Seconds 0 to 59 
        ("u16MilliSeconds",ctypes.c_ushort),    # Milliseconds 0 to 999 
        ("u16MicroSeconds",ctypes.c_ushort),    # Micro Seconfs 0 to 999 
        ("i8DSTTime", ctypes.c_byte)]          # -1 DST Unknown, 0 (No DST), 1 to 24 (DST hour) 
    
    