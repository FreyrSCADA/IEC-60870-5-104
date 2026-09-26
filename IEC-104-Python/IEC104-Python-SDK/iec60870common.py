import ctypes
from enum import *


	# Max Directory Path Size
MAX_DIRECTORY_PATH = 248
	# Max Value of station address/ common address present in the physical link
MAX_CA = 100
	
	
	
	
	
	
		 
	 # Flags for struct sIEC101Parameters.uiOptions flags 
class eApplicationOptionFlag(Enum):        
			APP_OPTION_NONE                                 = 0x00 # No options set 
			APP_SEQUENCE_BIT                                = 0x01 # Server builds iec frame with sequence for monitoring information without time stamp 

		
		
				# Flags for IEC101Cancel/cancel callback operation flags 
class eOperationFlag(Enum):        
			SELECT                  = 1 # Select Operation 
			OPERATE                 = 2 # Operate Operation
		

		# for IEC101Client status  flags 
class eStatus(IntEnum):        
			NOT_CONNECTED   =   0 # not connected 
			CONNECTED       =   1  # connected 
		
		
				#  Flags for eCauseofTransmissionSize - Cause of Transmission size
class eCauseofTransmissionSize(IntEnum):        
			COT_ONE_BYTE        = 1        # 1 Octet cause of transmission 
			COT_TWO_BYTE        = 2        # 2 Octet cause of transmission 
		
		
		# \brief List of Quality flags 
class eIEC870QualityFlags(IntEnum):    
		GD          = 0x0000   # Good / Valid 
		IV          = 0x0001   # Invalid 
		NT          = 0x0002   # Not Topical 
		SB          = 0x0004   # Substituted 
		BL          = 0x0008   # Blocked 
		OV          = 0x0010   # Overflow 
		EI          = 0x0020   # Elapsed time  invalid 
		TR          = 0x0040   # Equipement is in Transient State 
		CA          = 0x0080   # Counter was Adjusted 
		CR          = 0x0100   # Carry counter overflow  CY indicated in protocol spec
	
	
	 # \brief Control model configuration 
class eControlModelConfig(IntEnum):    
	STATUS_ONLY                                     = 0       # Status Only For input points In iec104 like M_SP_NA_1... for DNP3 BINARY_INPUT DOUBLE_INPUT...
	DIRECT_OPERATE                                  = 1       # Direct Operate
	SELECT_BEFORE_OPERATE                           = 2       # Select Before Operate 
	

		# \brief counter freeze flags 
class eCounterFreezeFlags(Enum):    
		COUNTER_READ                        = 0   # Counter Read no freeze no reset
		COUNTER_FREEZE              = 1    # Counter freeze without reset value
		COUNTER_FREEZE_WITH_RESET   = 2    # FREEZE Counter value & reset    
		COUNTER_RESET               = 3    # Counter reset 
	

#   Flags for eKPA - Kind of parameter
class eKindofParameter(Enum):        
			PARAMETER_NONE                                     = 0       # Not used
			PARAMETER_THRESHOLDVALUE                           = 1       # Threshold value
			PARAMETER_SMOOTHINGFACTOR                          = 2       # smoothing factor (filter time constant)
			PARAMETER_LOWLIMIT                                 = 3       # smoothing factor (filter time constant) 
			PARAMETER_HIGHLIMIT                                = 4       # smoothing factor (filter time constant) 
		
		
		
		# \brief Cause of Transmission 
class eIEC870COTCause(IntEnum):    
		NOTUSED         = 0
		PERCYC          = 1        # Periodic Cyclic 
		BACK            = 2        # Back ground scan 
		SPONT           = 3        # Spontaneous 
		INIT            = 4        # Initialised 
		REQ             = 5        # Request or Requested 
		ACT             = 6        # Activation 
		ACTCON          = 7        # Activation Confirmation 
		DEACT           = 8        # Deactivation 
		DEACTCON        = 9        # Deactication Confirmation 
		ACTTERM         = 10       # Activation Confirmation 
		RETREM          = 11       # Return information caused by a remote command 
		RETLOC          = 12       # Return information caused by a local command 
		FILETRANFER     = 13       # File transfer 
		INROGEN         = 20       # Interrogated by station interrogation 
		INRO1           = 21       # Interrogated by group 1 interrogation 
		INRO2           = 22       # Interrogated by group 2 interrogation 
		INRO3           = 23       # Interrogated by group 3 interrogation 
		INRO4           = 24       # Interrogated by group 4 interrogation 
		INRO5           = 25       # Interrogated by group 5 interrogation 
		INRO6           = 26       # Interrogated by group 6 interrogation 
		INRO7           = 27       # Interrogated by group 7 interrogation 
		INRO8           = 28       # Interrogated by group 8 interrogation 
		INRO9           = 29       # Interrogated by group 9 interrogation 
		INRO10          = 30       # Interrogated by group 10 interrogation 
		INRO11          = 31       # Interrogated by group 11 interrogation 
		INRO12          = 32       # Interrogated by group 12 interrogation 
		INRO13          = 33       # Interrogated by group 13 interrogation 
		INRO14          = 34       # Interrogated by group 14 interrogation 
		INRO15          = 35       # Interrogated by group 15 interrogation 
		INRO16          = 36       # Interrogated by group 16 interrogation 
		REQCOGEN        = 37       # Requested by general counter request 
		REQCO1          = 38       # Requested by group 1 counter request 
		REQCO2          = 39       # Requested by group 2 counter request 
		REQCO3          = 40       # Requested by group 3 counter request 
		REQCO4          = 41       # Requested by group 4 counter request 
		UNKNOWN_TYPEID  = 44       # Unkown Type Identification 
		UNKNOWN_COT     = 45       # Unknown cause of transmission 
		UNKNOWN_CASDU   = 46       # Unknown common address of ASDU 
		UNKNOWN_IOA     = 47       # Unknown information object address 
	


	
				# \brief  Start events of protection equipment flag 
class eStartEventsofProtFlags(Enum):    
		GS                                      = 0x01       # GS = general start of operation
		SL1                                     = 0x02       # SL1 = start of operation phase L1 
		SL2                                     = 0x04       # SL2 = start of operation phase L2 
		SL3                                     = 0x08       # SL3 = start of operation phase L3 
		SIE                                     = 0x10       # SIE = start of operation IE (earth current) 
		SRD                                     = 0x20       # SRD = start of operation in reverse direction 
	

		# \brief  Packed output circuit information of protection equipment flag 
class ePackedOutputCircuitInfoofProtFlags(Enum):    
		GC                                      = 0x01       # GC = general command to output circuit 
		CL1                                     = 0x02       # CL1 = command to output circuit phase L1 
		CL2                                     = 0x04       # CL2 = command to output circuit phase L2 
		CL3                                     = 0x08       # CL3 = command to output circuit phase L3 
	
	
	
	# List of Command Qualifier 
class eCommandQOCQU(Enum):    
		NOADDDEF = 0               #  No Additional Definition 
		SHORTPULSE = 1             # Short Pulse Duration 
		LONGPULSE = 2              # Long Pulse Duration 
		PERSISTANT = 3             # Persistant 
		COMPATIBLE_RANGE_START = 4 # Compatible Range Start 
		COMPATIBLE_RANGE_END = 8   # Compatible Range End 
		PREDEFINED_RANGE_START = 9 # Pre Defined Range Start 
		PREDEFINED_RANGE_END = 15  # Pre Defined Range End 
		PRIVATE_RANGE_START = 16   # Private Range Start 
		PRIVATE_RANGE_END = 31     # Private Range End 
	
		
	# Type Identication List 
class eIEC870TypeID(IntEnum):    
		M_SP_NA_1 = 1      #  Single-point information 
		M_SP_TA_1 = 2      #  Single-point information with time tag - Applicable for IEC 101 only
		M_DP_NA_1 = 3      #  Double-point information 
		M_DP_TA_1 = 4      #  Double-point information with time tag - Applicable for IEC 101 only
		M_ST_NA_1 = 5      #  Step position information 
		M_ST_TA_1 = 6      #  Step position information with time tag - Applicable for IEC 101 only
		M_BO_NA_1 = 7      #  Bitstring of 32 bit  
		M_BO_TA_1 = 8      #  Bitstring of 32 bit with time tag - Applicable for IEC 101 only 
		M_ME_NA_1 = 9      #  Measured value normalized value 
		M_ME_TA_1 = 10     #  Measured value normalized value with time tag   - Applicable for IEC 101 only
		M_ME_NB_1 = 11     #  Measured value scaled value 
		M_ME_TB_1 = 12     #  Measured value scaled value with time tag  - Applicable for IEC 101 only
		M_ME_NC_1 = 13     #  Measured value short floating point value 
		M_ME_TC_1 = 14     #  Measured value short floating point value with time tag - Applicable for IEC 101 only 
		M_IT_NA_1 = 15     #  Integrated totals 
		M_IT_TA_1 = 16     #  Integrated totals with time tag  - Applicable for IEC 101 only
		M_EP_TA_1 = 17     #  Event of protection equipment with time tag  - Applicable for IEC 101 only
		M_EP_TB_1 = 18     #  Packed start events of protection equipment with time tag  - Applicable for IEC 101 only
		M_EP_TC_1 = 19     #  Packed output circuit information of protection equipment with time tag  - Applicable for IEC 101 only
		M_PS_NA_1 = 20     #  Packed single-point information with status change detection  - Applicable for IEC 101 only
		M_ME_ND_1 = 21     #  Measured value normalized value without quality descriptor 
		M_SP_TB_1 = 30     #  Single-point information with time tag CP56Time2a 
		M_DP_TB_1 = 31     #  Double-point information with time tag CP56Time2a 
		M_ST_TB_1 = 32     #  Step position information with time tag CP56Time2a 
		M_BO_TB_1 = 33     #  Bitstring of 32 bit with time tag CP56Time2a 
		M_ME_TD_1 = 34     #  Measured value normalized value with time tag CP56Time2a 
		M_ME_TE_1 = 35     #  Measured value scaled value with time tag CP56Time2a 
		M_ME_TF_1 = 36     #  Measured value short floating point value with time tag CP56Time2a 
		M_IT_TB_1 = 37     #  Integrated totals with time tag CP56Time2a 
		M_EP_TD_1 = 38     #  Event of protection equipment with time tag CP56Time2a 
		M_EP_TE_1 = 39     #  Packed start events of protection equipment with time tag CP56Time2a 
		M_EP_TF_1 = 40     #  Packed output circuit information of protection equipment with time tag CP56Time2a 
		C_SC_NA_1 = 45     #  Single command 
		C_DC_NA_1 = 46     #  Double command 
		C_RC_NA_1 = 47     #  Regulating step command 
		C_SE_NA_1 = 48     #  Set point command normalized value 
		C_SE_NB_1 = 49     #  Set point command scaled value 
		C_SE_NC_1 = 50     #  Set point command short floating point value 
		C_BO_NA_1 = 51     #  Bitstring of 32 bit command 
		C_SC_TA_1 = 58     #  Single command with time tag CP56Time2a 
		C_DC_TA_1 = 59     #  Double command with time tag CP56Time2a 
		C_RC_TA_1 = 60     #  Regulating step command with time tag CP56Time2a 
		C_SE_TA_1 = 61     #  Set point command normalized value with time tag CP56Time2a 
		C_SE_TB_1 = 62     #  Set point command scaled value with time tag CP56Time2a 
		C_SE_TC_1 = 63     #  Set point command short floating point value with time tag CP56Time2a 
		C_BO_TA_1 = 64     #  Bitstring of 32 bit command with time tag CP56Time2a 
		M_EI_NA_1 = 70     #  End of initialization 
		C_IC_NA_1 = 100    #  Interrogation command 
		C_CI_NA_1 = 101    #  Counter interrogation command 
		C_RD_NA_1 = 102    #  Read command 
		C_CS_NA_1 = 103    #  Clock synchronization command 
		C_TS_NA_1 = 104    #  Test command  - Applicable for IEC 101 only
		C_RP_NA_1 = 105    #  Reset process command 
		C_CD_NA_1 = 106    #  Delay acquisition command  - Applicable for IEC 101 only
		C_TS_TA_1 = 107    #  Test command with time tag CP56Time2a 
		P_ME_NA_1 = 110    #  Parameter of measured value normalized value 
		P_ME_NB_1 = 111    #  Parameter of measured value scaled value 
		P_ME_NC_1 = 112    #  Parameter of measured value short floating point value 
		P_AC_NA_1 = 113    #  Parameter activation 
		F_FR_NA_1 = 120    #  File ready 
		F_SR_NA_1 = 121    #  Section ready 
		F_SC_NA_1 = 122    #  Call directory select file call file call section 
		F_LS_NA_1 = 123    #  Last section last segment 
		F_AF_NA_1 = 124    #  Ack file ack section 
		F_SG_NA_1 = 125    #  Segment 
		F_DR_TA_1 = 126    #  Directory 
	

